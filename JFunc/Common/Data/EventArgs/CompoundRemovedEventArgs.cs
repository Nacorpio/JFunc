using JetBrains.Annotations;

using JFunc.API.Collections;

namespace JFunc.Common.Data.EventArgs
{

  public class CompoundRemovedEventArgs : CompoundAccessorEventArgs
  {
    public CompoundRemovedEventArgs([NotNull] INItemCollection collection, [NotNull] string compoundName) : base(collection)
    {
      CompoundName = compoundName;
    }

    public string CompoundName { get; }
  }

}