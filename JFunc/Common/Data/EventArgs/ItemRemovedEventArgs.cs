using JetBrains.Annotations;

using JFunc.API.Collections;

namespace JFunc.Common.Data.EventArgs
{

  public class ItemRemovedEventArgs : ItemCollectionEventArgs
  {
    public ItemRemovedEventArgs([NotNull] INItemCollection collection, [NotNull] string itemName) : base(collection)
    {
      ItemName = itemName;
    }

    public string ItemName { get; }
  }

}