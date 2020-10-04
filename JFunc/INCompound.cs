using Newtonsoft.Json;

namespace JFunc
{
  /// <summary>
  /// Defines functionality for a compound defined in JSON.
  /// </summary>
  public interface INCompound : INItem
  {
    /// <summary>
    /// Gets the properties of the <see cref="INCompound"/>.
    /// </summary>
    [JsonProperty("items", Order = 2, Required = Required.AllowNull)]
    INItemCollection Items { get; }
  }

}