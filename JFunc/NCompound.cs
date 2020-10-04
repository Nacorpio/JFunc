using System.Collections.Generic;

using JetBrains.Annotations;

namespace JFunc
{

  public class NCompound : NItem, INCompound
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NItem"/> class.
    /// </summary>
    public NCompound([NotNull] string name, [CanBeNull] IEnumerable<INItem> items = null) : base(name)
    {
      Items = new NItemCollection(this, items);
    }

    /// <summary>
    /// Gets the properties of the <see cref="INCompound"/>.
    /// </summary>
    public INItemCollection Items { get; }

    /// <summary>
    /// Creates and returns a new <see cref="NCompound"/> instance, specifying its name and items.
    /// </summary>
    /// <param name="name">The name of the compound.</param>
    /// <param name="items">The items of the compound.</param>
    /// <returns>The newly created compound.</returns>
    public static NCompound Create([NotNull] string name, [CanBeNull] IEnumerable<INItem> items = null)
    {
      return new NCompound(name, items);
    }
  }

}