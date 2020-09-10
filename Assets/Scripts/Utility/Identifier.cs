namespace Utility {

  public interface Identifier {
    bool EqualsTo(Identifier other);
    bool GreaterThan(Identifier other);
    bool SmallerThan(Identifier other);
  }
}
