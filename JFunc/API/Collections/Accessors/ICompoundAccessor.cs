using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using JFunc.API.Objects;
using JFunc.Common.Data.EventArgs;

namespace JFunc.API.Collections.Accessors
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
    /// <param name="compoundName">The name of the new component.</param>
    /// <param name="items">The items of the new component.</param>
    void CreateCompound([NotNull] string compoundName, [CanBeNull] IEnumerable<INItem> items = null);


    /// <summary>
    /// Adds the specified compound.
    /// </summary>
    /// <param name="compound">The compound to add.</param>
    void AddCompound([NotNull] INCompound compound);
  }

}