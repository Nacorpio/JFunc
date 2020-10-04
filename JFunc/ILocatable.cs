using Newtonsoft.Json;

namespace JFunc
{

  /// <summary>
  /// Defines functionality for an object that can be located by a path.
  /// </summary>
  public interface ILocatable
  {
    /// <summary>
    /// Gets the path of the object.
    /// </summary>
    [JsonProperty("path", Order = 1)]
    string Path { get; }
  }

}