using JetBrains.Annotations;

namespace JFunc
{

  public class PropertyAddedEventArgs : PropertyAccessorEventArgs
  {
    public PropertyAddedEventArgs([NotNull] INItemCollection collection, [NotNull] INProperty property) : base(collection)
    {
      Property = property;
    }

    public INProperty Property { get; }
  }

}