using JetBrains.Annotations;

using Newtonsoft.Json;

namespace JFunc
{

  public class NClass : NObject, INClass
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NClass"/> class.
    /// </summary>
    public NClass([NotNull] string name) : base(name)
    {
      Items = new NItemCollection(this);
    }

    /// <summary>
    /// Gets the items of the <see cref="NClass"/>.
    /// </summary>
    [JsonProperty("items")]
    public INItemCollection Items { get; }
  }

}