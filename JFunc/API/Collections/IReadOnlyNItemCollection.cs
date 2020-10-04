using JetBrains.Annotations;

using JFunc.API.Collections.Accessors;
using JFunc.API.Objects;

namespace JFunc.API.Collections
{

  public interface IReadOnlyNItemCollection : IReadOnlyPropertyAccessor, IReadOnlyCompoundAccessor
  {
    /// <summary>
    /// Gets an item with the specified name.
    /// </summary>
    /// <param name="itemName">The name of the item to get.</param>
    /// <returns>The item, if found; otherwise, <c>null</c>.</returns>
    [CanBeNull]
    INItem this[[NotNull] string itemName] { get; }


    /// <summary>
    /// Gets the total number of items contained in the <see cref="IReadOnlyNItemCollection"/>.
    /// </summary>
    int Count { get; }


    /// <summary>
    /// Returns an item with the specified name.
    /// </summary>
    /// <param name="itemName">The name of the item to get.</param>
    /// <returns>The item, if found; otherwise, <c>null</c>.</returns>
    [CanBeNull]
    INItem GetItem([NotNull] string itemName);


    /// <summary>
    /// Returns a value indicating whether the <see cref="IReadOnlyNItemCollection"/> contains an item with the specified name.
    /// </summary>
    /// <param name="itemName">The name of the item to find.</param>
    /// <returns><c>true</c> if the item was found; otherwise, <c>false</c>.</returns>
    [Pure]
    bool Contains([NotNull] string itemName);

    /// <summary>
    /// Returns a value indicating whether the <see cref="IReadOnlyNItemCollection"/> contains the specified item.
    /// </summary>
    /// <param name="item">The item to find.</param>
    /// <returns><c>true</c> if the item was found; otherwise, <c>false</c>.</returns>
    [Pure]
    bool Contains([NotNull] INItem item);


    /// <summary>
    /// Finds and returns an item with the specified name.
    /// </summary>
    /// <param name="itemName">The name of the item to find.</param>
    /// <param name="result">The resulting item.</param>
    /// <returns><c>true</c> if the item was found; otherwise, <c>false</c>.</returns>
    bool TryGetItem([NotNull] string itemName, out INItem result);
  }

}