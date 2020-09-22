namespace Utility {
  public class Identifier {
    public Identifier() {
      _id = _idCounter;
      ++_idCounter;
    }

    public bool EqualsTo(Identifier other) {
      return other._id == _id;
    }

    public int GetId() {
      return _id;
    }

    private static int _idCounter = 1;
    private int _id;
  }
}