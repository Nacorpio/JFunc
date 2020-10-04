using Newtonsoft.Json;

namespace JFunc
{

  /// <summary>
  /// Defines functionality for a class defined in JSON.
  /// </summary>
  public interface INClass : INObject
  {
    /// <summary>
    /// Gets the items of the <see cref="INClass"/>.
    /// </summary>
    [JsonProperty("items", Order = 3)]
    INItemCollection Items { get; }
  }

}