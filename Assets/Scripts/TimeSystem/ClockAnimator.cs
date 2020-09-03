using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeSystem
{
    public class ClockAnimator : MonoBehaviour
    {
        // Start is called before the first frame update
        float hoursToDegrees = 360f / 12f;

        // Update is called once per frame
        void Update()
        {
            hoursTransform.localRotation = Quaternion.Euler(0f, 0f, time.hour * -hoursToDegrees);
        }
        
        //data members
        public TimeController time;
        public Transform hoursTransform;
    }
}
