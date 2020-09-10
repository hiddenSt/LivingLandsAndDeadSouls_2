namespace Utility {

  public class CommonIdentifier : Identifier {
    public bool GreaterThan(Identifier other) {
      return true;
    }

    public bool EqualsTo(Identifier other) {
      return true;
    }

    public bool SmallerThan(Identifier other) {
      return true;
    }
  }
}
