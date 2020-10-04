using Newtonsoft.Json;

namespace JFunc
{

  /// <summary>
  /// Defines functionality for an object that has a name.
  /// </summary>
  public interface INamed
  {
    /// <summary>
    /// Gets the name of the object.
    /// </summary>
    [JsonProperty("name", Order = 0)]
    string Name { get; }
  }

}