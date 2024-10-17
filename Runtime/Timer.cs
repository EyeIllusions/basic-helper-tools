using Pixelogic.helper;
using UnityEngine;
using UnityEngine.Events;


namespace Pixelogic.Util
{
    /// <summary>
    ///handles counting up and down in time
    /// </summary>
    public class Timer : MonoBehaviour
    {
        [Tooltip("will pause when enabled") ]
        public bool isTimerPaused = false;
        [Tooltip("will count down from this variable if (shouldCountDown) is true and will count up to this variable if (shouldCountDown) is false")]
        public float timerStart = 1;
        [Tooltip("will change whether the timer will count up to (timerStart) or down from(timerStart) to 0")]
        public bool shouldCountDown = false;
        [Tooltip("will be called when the timer ends")]
        public UnityEvent handleTimerEvent;
         TimerBase timer;
        
        private void Awake()
        {
            timer  = new TimerBase(timerStart,shouldCountDown,handleTimerEvent);
        }
       

        private void Update()
        {
            if(!isTimerPaused) timer.Tick(Time.deltaTime);
        }
 
      // allows the user to reset the timer
   public void Reset()
   {
       timer.Reset();
   }
    public void GetCurrentTime()
    {
        return timer.currentTime;
    }

    }



}
