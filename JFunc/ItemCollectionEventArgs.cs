using System;

using JetBrains.Annotations;

namespace JFunc
{

  public class ItemCollectionEventArgs : EventArgs
  {
    public ItemCollectionEventArgs([NotNull] INItemCollection collection)
    {
      Collection = collection;
    }

    public INItemCollection Collection { get; }
  }

}