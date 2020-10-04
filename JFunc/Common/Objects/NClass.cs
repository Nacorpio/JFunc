using JetBrains.Annotations;

using JFunc.API.Collections;
using JFunc.API.Objects;
using JFunc.Common.Collections;

using Newtonsoft.Json;

namespace JFunc.Common.Objects
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