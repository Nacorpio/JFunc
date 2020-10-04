using JetBrains.Annotations;

using JFunc.API.Collections;

namespace JFunc.Common.Data.EventArgs
{

  public class PropertyAccessorEventArgs : System.EventArgs
  {
    public PropertyAccessorEventArgs([NotNull] INItemCollection collection)
    {
      Collection = collection;
    }

    public INItemCollection Collection { get; }
  }

}