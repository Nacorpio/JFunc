using Newtonsoft.Json;

namespace JFunc
{

  /// <summary>
  /// Defines functionality for a generic property defined in JSON.
  /// </summary>
  public interface INProperty<out T> : INProperty
  {
    /// <summary>
    /// Gets the value of the <see cref="INProperty{T}"/>.
    /// </summary>
    [JsonProperty("value", Order = 2, Required = Required.Always)]
    new T Value { get; }
  }

  /// <summary>
  /// Defines functionality for a property defined in JSON.
  /// </summary>
  public interface INProperty : INItem
  {
    /// <summary>
    /// Gets the value of the <see cref="INProperty"/>.
    /// </summary>
    [JsonProperty("value", Order = 2, Required = Required.AllowNull)]
    object Value { get; }
  }

}