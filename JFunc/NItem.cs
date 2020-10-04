using JetBrains.Annotations;

namespace JFunc
{

  public abstract class NItem : NObject, INItem
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NItem"/> class.
    /// </summary>
    protected NItem([NotNull] string name) : base(name)
    {
    }

    /// <summary>
    /// Returns a value indicating whether the item is a property.
    /// </summary>
    /// <returns><c>true</c> if the item is a property; otherwise, <c>false</c>.</returns>
    public bool IsProperty() => this is INProperty;

    /// <summary>
    /// Returns a value indicating whether the item is a compound.
    /// </summary>
    /// <returns><c>true</c> if the item is a compound; otherwise, <c>false</c>.</returns>
    public bool IsCompound() => this is INCompound;


    /// <summary>
    /// Converts the current item to a property.
    /// </summary>
    /// <typeparam name="T">The property value type.</typeparam>
    /// <returns>The current instance as a property.</returns>
    public NProperty<T> AsProperty<T>()
    {
      return this as NProperty<T>;
    }

    /// <summary>
    /// Converts the current item to a compound.
    /// </summary>
    /// <returns>The current instance as a compound.</returns>
    public NCompound AsCompound()
    {
      return this as NCompound;
    }
  }

}