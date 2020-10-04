using JetBrains.Annotations;

namespace JFunc
{

  public class CompoundAddedEventArgs : CompoundAccessorEventArgs
  {
    public CompoundAddedEventArgs([NotNull] INItemCollection collection, [NotNull] INCompound compound) : base(collection)
    {
      Compound = compound;
    }

    public INCompound Compound { get; }
  }

}