namespace Utility {

  public abstract class Identifier {
    public abstract bool EqualsTo(Identifier other);
    public abstract bool GreaterThan(Identifier other);
    public abstract bool SmallerThan(Identifier other);

    
  }
}
