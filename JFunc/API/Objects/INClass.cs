using JFunc.API.Collections;

using Newtonsoft.Json;

namespace JFunc.API.Objects
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