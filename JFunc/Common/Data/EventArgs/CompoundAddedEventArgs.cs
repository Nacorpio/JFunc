using JetBrains.Annotations;

using JFunc.API.Collections;
using JFunc.API.Objects;

namespace JFunc.Common.Data.EventArgs
{

  public class CompoundAddedEventArgs : CompoundAccessorEventArgs
  {
    public CompoundAddedEventArgs([NotNull] INItemCollection collection, [NotNull] INCompound compound) : base(collection)
    {
      Compound = compound;
    }

    public INCompound Compound { get; }
  }

}