using JetBrains.Annotations;

namespace JFunc
{

  public class CompoundRemovedEventArgs : CompoundAccessorEventArgs
  {
    public CompoundRemovedEventArgs([NotNull] INItemCollection collection, [NotNull] string compoundName) : base(collection)
    {
      CompoundName = compoundName;
    }

    public string CompoundName { get; }
  }

}