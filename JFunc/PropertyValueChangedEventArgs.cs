using JetBrains.Annotations;

namespace JFunc
{

  public class PropertyValueChangedEventArgs : PropertyAccessorEventArgs
  {
    public PropertyValueChangedEventArgs
    (
      [NotNull] INItemCollection collection,
      [NotNull] INProperty property,
      [CanBeNull] object oldValue,
      [CanBeNull] object newValue) : base(
      collection
    )
    {
      Property = property;
      OldValue = oldValue;
      NewValue = newValue;
    }

    public INProperty Property { get; }

    public object OldValue { get; }
    public object NewValue { get; }
  }

}