using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

using JFunc.API.Collections;
using JFunc.API.Collections.Accessors;
using JFunc.API.Objects;
using JFunc.Common.Data.EventArgs;
using JFunc.Common.Objects;

namespace JFunc.Common.Collections
{
  /// <summary>
  /// Represents a collection of <see cref="NItem"/> objects. 
  /// </summary>
  public class NItemCollection : INItemCollection
  {
    private readonly Dictionary<string, INItem> _items;

    private readonly HashSet<string> _propertyNames;
    private readonly HashSet<string> _compoundNames;


    /// <summary>
    /// Raised when an item has been added to the <see cref="INItemCollection"/>.
    /// </summary>
    public event EventHandler<ItemAddedEventArgs> ItemAdded;

    /// <summary>
    /// Raised when an item has been removed from the <see cref="INItemCollection"/>.
    /// </summary>
    public event EventHandler<ItemRemovedEventArgs> ItemRemoved;


    /// <summary>
    /// Raised when a property has been added.
    /// </summary>
    public event EventHandler<PropertyAddedEventArgs> PropertyAdded;

    /// <summary>
    /// Raised when a property has been removed.
    /// </summary>
    public event EventHandler<PropertyRemovedEventArgs> PropertyRemoved;


    /// <summary>
    /// Raised when a property value has changed.
    /// </summary>
    public event EventHandler<PropertyValueChangedEventArgs> PropertyValueChanged;


    /// <summary>
    /// Raised when a compound has been added.
    /// </summary>
    public event EventHandler<CompoundAddedEventArgs> CompoundAdded;

    /// <summary>
    /// Raised when a compound has been removed.
    /// </summary>
    public event EventHandler<CompoundRemovedEventArgs> CompoundRemoved;


    /// <summary>
    /// Initializes a new instance of the <see cref="NItemCollection"/> class.
    /// </summary>
    public NItemCollection(INObject owner, IEnumerable<INItem> items = null)
    {
      Owner = owner;

      _propertyNames = new HashSet<string>();
      _compoundNames = new HashSet<string>();

      switch (items)
      {
        case null:
          _items = new Dictionary<string, INItem>();
          return;

        default:
          _items = items.ToDictionary(x => x.Name, x => x);

          break;
      }
    }


    /// <summary>
    /// Gets an item with the specified name.
    /// </summary>
    /// <param name="itemName">The name of the item to get.</param>
    /// <returns>The item, if found; otherwise, <c>null</c>.</returns>
    public INItem this[string itemName] => TryGetItem(itemName, out var item) ? item : null;


    /// <summary>
    /// Gets the owner object of the <see cref="NItemCollection"/>.
    /// </summary>
    public INObject Owner { get; }


    /// <summary>
    /// Gets the total number of items contained in the <see cref="NItemCollection"/>.
    /// </summary>
    public int Count => _items.Count;


    /// <summary>
    /// Adds the specified item to the <see cref="NItemCollection"/>.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void Add(INItem item)
    {
      if (Contains(item))
      {
        return;
      }

      if (!( item is NItem i ))
      {
        return;
      }

      i.Depth = Owner.Depth + 1;
      i.Index = Count;

      _items.Add(item.Name, item);
      OnItemAdded(new ItemAddedEventArgs(this, item));

      switch (item)
      {
        case INProperty property:
          {
            _propertyNames.Add(property.Name);
            OnPropertyAdded(new PropertyAddedEventArgs(this, property));

            break;
          }

        case INCompound compound:
          {
            _compoundNames.Add(item.Name);
            OnCompoundAdded(new CompoundAddedEventArgs(this, compound));

            break;
          }
      }
    }


    /// <summary>
    /// Adds the specified collection of items to the <see cref="NItemCollection"/>.
    /// </summary>
    /// <param name="items">The items to add.</param>
    public void AddRange(IEnumerable<INItem> items)
    {
      foreach (var item in items)
      {
        Add(item);
      }
    }


    /// <summary>
    /// Removes an item with the specified name from the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="itemName">The name of the item to remove.</param>
    /// <returns><c>true</c> if the item was removed; otherwise, <c>false</c>.</returns>
    public bool Remove(string itemName)
    {
      if (!_items.Remove(itemName))
      {
        return false;
      }

      if (_propertyNames.Contains(itemName))
      {
        _propertyNames.Remove(itemName);
        OnPropertyRemoved(new PropertyRemovedEventArgs(this, itemName));
      }

      if (_compoundNames.Contains(itemName))
      {
        _compoundNames.Remove(itemName);
        OnCompoundRemoved(new CompoundRemovedEventArgs(this, itemName));
      }

      OnItemRemoved(new ItemRemovedEventArgs(this, itemName));
      return true;
    }

    /// <summary>
    /// Removes the specified item from the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <returns><c>true</c> if the item was removed; otherwise, <c>false</c>.</returns>
    public bool Remove(INItem item)
    {
      return Remove(item.Name);
    }


    /// <summary>
    /// Removes the specified collection of items from the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="items">The items to remove.</param>
    /// <returns><c>true</c> if the items were removed; otherwise, <c>false</c>.</returns>
    public bool RemoveAll(IEnumerable<INItem> items)
    {
      return items.All(Remove);
    }

    /// <summary>
    /// Removes the items with the specified names from the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="itemNames">The names of the items to remove.</param>
    /// <returns><c>true</c> if the items were removed; otherwise, <c>false</c>.</returns>
    public bool RemoveAll(params string[] itemNames)
    {
      return itemNames.All(Remove);
    }


    /// <summary>
    /// Returns the property accessor of this instance.
    /// </summary>
    /// <returns>The property accessor.</returns>
    public IPropertyAccessor GetPropertyAccessor() => this;

    /// <summary>
    /// Returns the compound accessor of this instance.
    /// </summary>
    /// <returns>The compound accessor.</returns>
    public ICompoundAccessor GetCompoundAccessor() => this;


    /// <summary>
    /// Adds a new property with the specified name and value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="propertyName">The name of the property to add.</param>
    /// <param name="value">The value of the property.</param>
    public void CreateProperty<T>(string propertyName, T value = default)
    {
      if (HasProperty(propertyName))
      {
        return;
      }

      var property = NProperty<T>.Create(propertyName, value);
      property.SetParent(Owner);

      AddProperty(property);
    }

    /// <summary>
    /// Adds a new compound with the specified name and items.
    /// </summary>
    /// <param name="compoundName">The name of the compound to add.</param>
    /// <param name="items">The items of the compound.</param>
    public void CreateCompound(string compoundName, IEnumerable<INItem> items = null)
    {
      if (HasCompound(compoundName))
      {
        return;
      }

      var compound = NCompound.Create(compoundName, items);
      compound.SetParent(Owner);

      AddCompound(compound);
    }


    /// <summary>
    /// Adds the specified property to the <see cref="NItemCollection"/>.
    /// </summary>
    /// <param name="property">The property to add.</param>
    public void AddProperty(INProperty property)
    {
      if (HasProperty(property))
      {
        return;
      }

      property.SetParent(Owner);
      Add(property);

      OnPropertyAdded(new PropertyAddedEventArgs(this, property));
    }

    /// <summary>
    /// Adds the specified compound.
    /// </summary>
    /// <param name="compound">The compound to add.</param>
    public void AddCompound(INCompound compound)
    {
      if (HasCompound(compound))
      {
        return;
      }

      compound.SetParent(Owner);
      Add(compound);

      OnCompoundAdded(new CompoundAddedEventArgs(this, compound));
    }


    /// <summary>
    /// Returns an item with the specified name.
    /// </summary>
    /// <param name="itemName">The name of the item to get.</param>
    /// <returns>The item, if found; otherwise, <c>null</c>.</returns>
    public INItem GetItem(string itemName)
    {
      return TryGetItem(itemName, out var result) ? result : null;
    }


    /// <summary>
    /// Returns a property with the specified name.
    /// </summary>
    /// <param name="propertyName">The name of the property to get.</param>
    /// <returns>The property, if found; otherwise, <c>null</c>.</returns>
    public INProperty GetProperty(string propertyName)
    {
      return GetItem(propertyName) is INProperty property ? property : null;
    }

    /// <summary>
    /// Returns a property with the specified name.
    /// </summary>
    /// <typeparam name="T">The property value type.</typeparam>
    /// <param name="propertyName">The name of the property to get.</param>
    /// <returns>The property, if found; otherwise, <c>null</c>.</returns>
    public INProperty<T> GetProperty<T>(string propertyName)
    {
      return GetItem(propertyName) is INProperty<T> property ? property : null;
    }


    /// <summary>
    /// Finds and returns a compound with the specified name.
    /// </summary>
    /// <param name="compoundName">The name of the compound to find.</param>
    /// <returns>The compound, if found; otherwise, <c>null</c>.</returns>
    public INCompound GetCompound(string compoundName)
    {
      return GetItem(compoundName) is INCompound compound ? compound : null;
    }


    /// <summary>
    /// Sets the new value of a property with the specified name.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="propertyName">The name of the property to set the value of.</param>
    /// <param name="value">The new value of the property.</param>
    public void SetPropertyValue<T>(string propertyName, T value = default)
    {
      if (!TryGetProperty(propertyName, out var p))
      {
        return;
      }

      if (!(p is NProperty<T> property))
      {
        return;
      }

      property.Value = value;
    }

    /// <summary>
    /// Returns the value of a property with the specified name.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="propertyName">The name of the property to get the value of.</param>
    /// <returns>The property, if found; otherwise, <c>default</c>.</returns>
    public T GetPropertyValue<T>(string propertyName)
    {
      return GetProperty<T>(propertyName).Value;
    }


    /// <summary>
    /// Finds and returns an item with the specified name.
    /// </summary>
    /// <param name="itemName">The name of the item to find.</param>
    /// <param name="result">The resulting item.</param>
    /// <returns><c>true</c> if the item was found; otherwise, <c>false</c>.</returns>
    public bool TryGetItem(string itemName, out INItem result)
    {
      if (!_items.TryGetValue(itemName, out var item))
      {
        result = null;
        return false;
      }

      result = item;
      return true;
    }

    /// <summary>
    /// Finds and returns a property with the specified name.
    /// </summary>
    /// <param name="propertyName">The name of the property to find.</param>
    /// <param name="result">The resulting property.</param>
    /// <returns><c>true</c> if the property was found; otherwise, <c>false</c>.</returns>
    public bool TryGetProperty(string propertyName, [CanBeNull] out INProperty result)
    {
      if (!TryGetItem(propertyName, out var item))
      {
        result = null;
        return false;
      }

      if (!(item is INProperty property))
      {
        result = null;
        return false;
      }

      result = property;
      return true;
    }

    /// <summary>
    /// Finds and returns a compound with the specified name.
    /// </summary>
    /// <param name="compoundName">The name of the compound to find.</param>
    /// <param name="result">The resulting compound.</param>
    /// <returns><c>true</c> if the compound was found; otherwise, <c>false</c>.</returns>
    public bool TryGetCompound(string compoundName, out INCompound result)
    {
      if (!TryGetItem(compoundName, out var c))
      {
        result = null;
        return false;
      }

      if (!(c is INCompound compound))
      {
        result = null;
        return false;
      }

      result = compound;
      return true;
    }


    /// <summary>
    /// Finds and returns the value of a property with the specified name.
    /// </summary>
    /// <typeparam name="T">The property value type.</typeparam>
    /// <param name="propertyName">The name of the property to get the value of.</param>
    /// <param name="result">The resulting property.</param>
    /// <returns><c>true</c> if the property was found; otherwise, <c>false</c>.</returns>
    public bool TryGetPropertyValue<T>(string propertyName, out T result)
    {
      if (!TryGetProperty(propertyName, out var p))
      {
        result = default;
        return false;
      }

      if (!(p is INProperty<T> property))
      {
        result = default;
        return false;
      }

      result = property.Value;
      return true;
    }


    /// <summary>
    /// Returns a value indicating whether the <see cref="NItemCollection"/> contains an item with the specified name.
    /// </summary>
    /// <param name="itemName">The name of the item to find.</param>
    /// <returns><c>true</c> if the item was found; otherwise, <c>false</c>.</returns>
    public bool Contains(string itemName)
    {
      return _items.ContainsKey(itemName);
    }

    /// <summary>
    /// Returns a value indicating whether the <see cref="NItemCollection"/> contains the specified item.
    /// </summary>
    /// <param name="item">The item to find.</param>
    /// <returns><c>true</c> if the item was found; otherwise, <c>false</c>.</returns>
    public bool Contains(INItem item)
    {
      return Contains(item.Name);
    }


    /// <summary>
    /// Returns a value indicating whether a property with the specified name exists.
    /// </summary>
    /// <param name="propertyName">The name of the property to find.</param>
    /// <returns><c>true</c> if the property was found; otherwise, <c>false</c>.</returns>
    public bool HasProperty(string propertyName)
    {
      return _propertyNames.Contains(propertyName);
    }

    /// <summary>
    /// Returns a value indicating whether the specified property exists.
    /// </summary>
    /// <param name="property">The property to find.</param>
    /// <returns><c>true</c> if the property was found; otherwise, <c>false</c>.</returns>
    public bool HasProperty(INProperty property)
    {
      return HasProperty(property.Name);
    }


    /// <summary>
    /// Returns a value indicating whether a compound with the specified name exists.
    /// </summary>
    /// <param name="compoundName">The name of the compound to find.</param>
    /// <returns><c>true</c> if the compound was found; otherwise, <c>false</c>.</returns>
    public bool HasCompound(string compoundName)
    {
      return _compoundNames.Contains(compoundName);
    }

    /// <summary>
    /// Returns a value indicating whether the specified compound exists.
    /// </summary>
    /// <param name="compound">The compound to find.</param>
    /// <returns><c>true</c> if the compound was found; otherwise, <c>false</c>.</returns>
    public bool HasCompound(INCompound compound)
    {
      return HasCompound(compound.Name);
    }

    /// <summary>
    /// Returns a value indicating whether the specified properties exist.
    /// </summary>
    /// <param name="properties">The properties to find.</param>
    /// <returns><c>true</c> if the properties exist; otherwise, <c>false</c>.</returns>
    public bool HasProperties(IEnumerable<INProperty> properties)
    {
      return properties.All(HasProperty);
    }

    /// <summary>
    /// Returns a value indicating whether the properties with the specified names exist.
    /// </summary>
    /// <param name="propertyNames">The names of the properties to find.</param>
    /// <returns><c>true</c> if the properties exist; otherwise, <c>false</c>.</returns>
    public bool HasProperties(params string[] propertyNames)
    {
      return propertyNames.All(HasProperty);
    }


    /// <summary>
    /// Returns a value indicating whether the specified collection of compounds exists.
    /// </summary>
    /// <param name="compounds">The compounds to find.</param>
    /// <returns><c>true</c> if the compounds were found; otherwise, <c>false</c>.</returns>
    public bool HasCompounds(IEnumerable<INCompound> compounds)
    {
      return compounds.All(HasCompound);
    }

    /// <summary>
    /// Returns a value indicating whether compounds with the specified names exist.
    /// </summary>
    /// <param name="compoundNames">The names of the compounds to find.</param>
    /// <returns><c>true</c> if the compounds were found; otherwise, <c>false</c>.</returns>
    public bool HasCompounds(params string[] compoundNames)
    {
      return compoundNames.All(HasCompound);
    }


    /// <summary>
    /// Returns a collection of all existing compounds.
    /// </summary>
    /// <returns>A collection of the existing compounds.</returns>
    public IEnumerable<INCompound> GetCompounds()
    {
      return _items.Values.Where(x => x is INCompound).Cast<INCompound>();
    }

    /// <summary>
    /// Returns a collection of the existing properties.
    /// </summary>
    /// <returns>The existing properties.</returns>
    public IEnumerable<INProperty> GetProperties()
    {
      return _items.Values.Where(x => x is INProperty).Cast<INProperty>();
    }


    /// <summary>Returns an enumerator that iterates through the collection.</summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public IEnumerator<INItem> GetEnumerator()
    {
      return _items.Values.GetEnumerator();
    }

    /// <summary>Returns an enumerator that iterates through a collection.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }


    protected virtual void OnItemAdded(ItemAddedEventArgs e)
    {
      ItemAdded?.Invoke(this, e);
    }

    protected virtual void OnItemRemoved(ItemRemovedEventArgs e)
    {
      ItemRemoved?.Invoke(this, e);
    }


    protected virtual void OnPropertyAdded(PropertyAddedEventArgs e)
    {
      PropertyAdded?.Invoke(this, e);
    }

    protected virtual void OnPropertyRemoved(PropertyRemovedEventArgs e)
    {
      PropertyRemoved?.Invoke(this, e);
    }


    protected virtual void OnPropertyValueChanged(PropertyValueChangedEventArgs e)
    {
      PropertyValueChanged?.Invoke(this, e);
    }


    protected virtual void OnCompoundAdded(CompoundAddedEventArgs e)
    {
      CompoundAdded?.Invoke(this, e);
    }

    protected virtual void OnCompoundRemoved(CompoundRemovedEventArgs e)
    {
      CompoundRemoved?.Invoke(this, e);
    }
  }

}