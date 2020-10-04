using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace JFunc
{

  public interface ICompoundAccessor : IReadOnlyCompoundAccessor
  {
    /// <summary>
    /// Raised when a compound has been added.
    /// </summary>
    event EventHandler<CompoundAddedEventArgs> CompoundAdded;

    /// <summary>
    /// Raised when a compound has been removed.
    /// </summary>
    event EventHandler<CompoundRemovedEventArgs> CompoundRemoved;


    /// <summary>
    /// Adds a new compound with the specified name and items.
    /// </summary>
    /// <param name="compoundName">The name of the compound to add.</param>
    /// <param name="items">The items of the compound.</param>
    void AddCompound([NotNull] string compoundName, [CanBeNull] IEnumerable<INItem> items = null);
  }

}