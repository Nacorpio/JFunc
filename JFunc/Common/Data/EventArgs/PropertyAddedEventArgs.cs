using JetBrains.Annotations;

using JFunc.API.Collections;
using JFunc.API.Objects;

namespace JFunc.Common.Data.EventArgs
{

  public class PropertyAddedEventArgs : PropertyAccessorEventArgs
  {
    public PropertyAddedEventArgs([NotNull] INItemCollection collection, [NotNull] INProperty property) : base(collection)
    {
      Property = property;
    }

    public INProperty Property { get; }
  }

}