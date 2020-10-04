using JFunc.Common.Objects;

namespace JFunc.API.Objects
{

  /// <summary>
  /// Defines functionality for an item defined in JSON.
  /// </summary>
  public interface INItem : INObject
  {
    /// <summary>
    /// Returns a value indicating whether the item is a property.
    /// </summary>
    /// <returns><c>true</c> if the item is a property; otherwise, <c>false</c>.</returns>
    bool IsProperty();

    /// <summary>
    /// Returns a value indicating whether the item is a compound.
    /// </summary>
    /// <returns><c>true</c> if the item is a compound; otherwise, <c>false</c>.</returns>
    bool IsCompound();


    /// <summary>
    /// Converts the current item to a property.
    /// </summary>
    /// <typeparam name="T">The property value type.</typeparam>
    /// <returns>The current instance as a property.</returns>
    NProperty<T> AsProperty<T>();

    /// <summary>
    /// Converts the current item to a compound.
    /// </summary>
    /// <returns>The current instance as a compound.</returns>
    NCompound AsCompound();
  }

}