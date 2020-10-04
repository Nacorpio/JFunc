using JetBrains.Annotations;

using JFunc.API.Collections;
using JFunc.API.Objects;

namespace JFunc.Common.Data.EventArgs
{

  public class ItemAddedEventArgs : ItemCollectionEventArgs
  {
    public ItemAddedEventArgs([NotNull] INItemCollection collection, [NotNull] INItem item) : base(collection)
    {
      Item = item;
    }

    public INItem Item { get; }
  }

}