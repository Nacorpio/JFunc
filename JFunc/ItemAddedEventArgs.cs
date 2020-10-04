using JetBrains.Annotations;

namespace JFunc
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