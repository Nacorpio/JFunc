using JetBrains.Annotations;

namespace JFunc
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