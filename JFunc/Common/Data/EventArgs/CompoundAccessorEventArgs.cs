using JetBrains.Annotations;

using JFunc.API.Collections;

namespace JFunc.Common.Data.EventArgs
{

  public class CompoundAccessorEventArgs : System.EventArgs
  {
    public CompoundAccessorEventArgs([NotNull] INItemCollection collection)
    {
      Collection = collection;
    }

    public INItemCollection Collection { get; }
  }

}