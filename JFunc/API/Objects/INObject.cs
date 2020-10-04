using JetBrains.Annotations;

using Newtonsoft.Json;

namespace JFunc.API.Objects
{

  /// <summary>
  /// Defines functionality for an object defined in JSON.
  /// </summary>
  public interface INObject : INamed, ILocatable
  {
    /// <summary>
    /// Gets the zero-based index of the object within its parent.
    /// </summary>
    [JsonIgnore]
    int Index { get; }

    /// <summary>
    /// Gets the zero-based depth of the object within its hierarchy.
    /// </summary>
    [JsonIgnore]
    int Depth { get; }


    /// <summary>
    /// Gets the parent of the <see cref="INObject"/>.
    /// </summary>
    [JsonIgnore]
    INObject Parent { get; }

    /// <summary>
    /// Sets the parent of the <see cref="INObject"/>.
    /// </summary>
    /// <param name="newParent">The new parent object.</param>
    void SetParent([NotNull] INObject newParent);
  }

}