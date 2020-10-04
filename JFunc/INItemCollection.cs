using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace JFunc
{

  public interface INItemCollection : IReadOnlyNItemCollection, IEnumerable<INItem>, IPropertyAccessor, ICompoundAccessor
  {
    /// <summary>
    /// Raised when an item has been added to the <see cref="INItemCollection"/>.
    /// </summary>
    event EventHandler<ItemAddedEventArgs> ItemAdded;

    /// <summary>
    /// Raised when an item has been removed from the <see cref="INItemCollection"/>.
    /// </summary>
    event EventHandler<ItemRemovedEventArgs> ItemRemoved;


    /// <summary>
    /// Gets the owner of the <see cref="INItemCollection"/>.
    /// </summary>
    INObject Owner { get; }


    /// <summary>
    /// Adds the specified item to the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="item">The item to add.</param>
    void Add([NotNull] INItem item);

    /// <summary>
    /// Adds the specified collection of items to the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="items">The items to add.</param>
    void AddRange([NotNull] IEnumerable<INItem> items);


    /// <summary>
    /// Removes an item with the specified name from the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="itemName">The name of the item to remove.</param>
    /// <returns><c>true</c> if the item was removed; otherwise, <c>false</c>.</returns>
    bool Remove([NotNull] string itemName);

    /// <summary>
    /// Removes the specified item from the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <returns><c>true</c> if the item was removed; otherwise, <c>false</c>.</returns>
    bool Remove([NotNull] INItem item);


    /// <summary>
    /// Removes the specified collection of items from the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="items">The items to remove.</param>
    /// <returns><c>true</c> if the items were removed; otherwise, <c>false</c>.</returns>
    bool RemoveAll([NotNull] IEnumerable<INItem> items);

    /// <summary>
    /// Removes the items with the specified names from the <see cref="INItemCollection"/>.
    /// </summary>
    /// <param name="itemNames">The names of the items to remove.</param>
    /// <returns><c>true</c> if the items were removed; otherwise, <c>false</c>.</returns>
    bool RemoveAll([NotNull] params string[] itemNames);


    /// <summary>
    /// Returns the property accessor of this instance.
    /// </summary>
    /// <returns>The property accessor.</returns>
    IPropertyAccessor GetPropertyAccessor();

    /// <summary>
    /// Returns the compound accessor of this instance.
    /// </summary>
    /// <returns>The compound accessor.</returns>
    ICompoundAccessor GetCompoundAccessor();
  }

}