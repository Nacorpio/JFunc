using JetBrains.Annotations;

using JFunc.API.Collections;
using JFunc.API.Objects;

namespace JFunc.Common.Data.EventArgs
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