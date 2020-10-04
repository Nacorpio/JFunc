using JetBrains.Annotations;

using JFunc.API.Collections;

namespace JFunc.Common.Data.EventArgs
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