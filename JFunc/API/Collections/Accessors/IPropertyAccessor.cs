using System;

using JetBrains.Annotations;

using JFunc.API.Objects;
using JFunc.Common.Data.EventArgs;

namespace JFunc.API.Collections.Accessors
{

  public interface IPropertyAccessor : IReadOnlyPropertyAccessor
  {
    /// <summary>
    /// Raised when a property has been added.
    /// </summary>
    event EventHandler<PropertyAddedEventArgs> PropertyAdded;

    /// <summary>
    /// Raised when a property has been removed.
    /// </summary>
    event EventHandler<PropertyRemovedEventArgs> PropertyRemoved;

    /// <summary>
    /// Raised when a property value has changed.
    /// </summary>
    event EventHandler<PropertyValueChangedEventArgs> PropertyValueChanged;


    /// <summary>
    /// Adds a new property with the specified name and value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="propertyName">The name of the property to add.</param>
    /// <param name="value">The value of the property.</param>
    void CreateProperty<T>([NotNull] string propertyName, T value = default);

    /// <summary>
    /// Adds the specified property.
    /// </summary>
    /// <param name="property">The property to add.</param>
    void AddProperty([NotNull] INProperty property);


    /// <summary>
    /// Sets the new value of a property with the specified name.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="propertyName">The name of the property to set the value of.</param>
    /// <param name="value">The new value of the property.</param>
    void SetPropertyValue<T>([NotNull] string propertyName, T value = default);
  }

}