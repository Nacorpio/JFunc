using System;

using JetBrains.Annotations;

namespace JFunc
{

  public class CompoundAccessorEventArgs : EventArgs
  {
    public CompoundAccessorEventArgs([NotNull] INItemCollection collection)
    {
      Collection = collection;
    }

    public INItemCollection Collection { get; }
  }

}