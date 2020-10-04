using JetBrains.Annotations;

namespace JFunc
{

  public class PropertyRemovedEventArgs : PropertyAccessorEventArgs
  {
    public PropertyRemovedEventArgs([NotNull] INItemCollection collection, [NotNull] string propertyName) : base(collection)
    {
      PropertyName = propertyName;
    }

    public string PropertyName { get; }
  }

}