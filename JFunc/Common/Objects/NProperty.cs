using JetBrains.Annotations;

using JFunc.API.Objects;

namespace JFunc.Common.Objects
{

  public static class NProperty
  {
    /// <summary>
    /// Creates and returns a new <see cref="NProperty{T}"/> instance, specifying its name and value.
    /// </summary>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns>The newly created property.</returns>
    public static NProperty<T> Create<T>([NotNull] string propertyName, T value = default)
    {
      return NProperty<T>.Create(propertyName, value);
    }
  }

  public class NProperty<T> : NItem, INProperty<T>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NProperty{T}"/> class, specifying its name and value.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    internal NProperty(string name, T value = default) : base(name)
    {
      Value = value;
    }

    /// <summary>
    /// Gets the value of the <see cref="INProperty{T}"/>.
    /// </summary>
    public T Value { get; internal set; }

    /// <summary>
    /// Gets the value of the <see cref="INProperty"/>.
    /// </summary>
    object INProperty.Value => Value;

    /// <summary>
    /// Creates and returns a new <see cref="NProperty{T}"/> instance, specifying its name and value.
    /// </summary>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns>The newly created property.</returns>
    public static NProperty<T> Create([NotNull] string propertyName, T value = default)
    {
      return new NProperty<T>(propertyName, value);
    }
  }

}