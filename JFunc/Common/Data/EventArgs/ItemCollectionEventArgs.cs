using JetBrains.Annotations;

using JFunc.API.Collections;

namespace JFunc.Common.Data.EventArgs
{

  public class ItemCollectionEventArgs : System.EventArgs
  {
    public ItemCollectionEventArgs([NotNull] INItemCollection collection)
    {
      Collection = collection;
    }

    public INItemCollection Collection { get; }
  }

}