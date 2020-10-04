using System;

using JetBrains.Annotations;

namespace JFunc
{

  public class PropertyAccessorEventArgs : EventArgs
  {
    public PropertyAccessorEventArgs([NotNull] INItemCollection collection)
    {
      Collection = collection;
    }

    public INItemCollection Collection { get; }
  }

}