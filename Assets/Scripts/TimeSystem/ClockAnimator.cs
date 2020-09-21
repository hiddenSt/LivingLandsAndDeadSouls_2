using UnityEngine;

namespace TimeSystem {
  public class ClockAnimator : MonoBehaviour {
    private void Update() {
      hoursTransform.localRotation = Quaternion.Euler(0f, 0f, time.hour * -hoursToDegrees);
    }

    //data members
    public float hoursToDegrees = 360f / 12f;
    public TimeController time;
    public Transform hoursTransform;
  }
}