using UnityEngine;

namespace TimeSystem {
  
  public class ClockAnimator : MonoBehaviour {
    public float hoursToDegrees = 360f / 12f;
    public TimeController time;
    public Transform hoursTransform;
    
    private void Update() {
      hoursTransform.localRotation = Quaternion.Euler(0f, 0f, time.hour * -hoursToDegrees);
    }
  }
  
}