﻿using JetBrains.Annotations;

using Newtonsoft.Json;

namespace JFunc
{

  public abstract class NObject : INObject
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NObject"/> class.
    /// </summary>
    /// <param name="objectName">The name of the object.</param>
    protected NObject([NotNull] string objectName)
    {
      Name = objectName;
    }

    /// <summary>
    /// Gets the name of the object.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; }

    /// <summary>
    /// Gets the path of the object.
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; }


    /// <summary>
    /// Gets the parent of the <see cref="NObject"/>.
    /// </summary>
    [JsonIgnore]
    public INObject Parent { get; private set; }


    /// <summary>
    /// Sets the parent of the <see cref="NObject"/>.
    /// </summary>
    /// <param name="newParent">The new parent object.</param>
    public void SetParent(INObject newParent)
    {
      Parent = newParent;
    }
  }

}