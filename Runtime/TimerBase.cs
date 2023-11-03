using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Pixelogic.helper
{
    /// <summary>
    ///has functions and methods relating to counting up and down in time
    /// </summary>
    public class TimerBase
    {
        float currentTime;
        float maxTime;
        bool isCountingDown;
        bool shouldCount = true;
        UnityEvent handlTimerEnd = new UnityEvent();


 
        public TimerBase(float maxTime,bool isCountingDown,UnityEvent a)
        {
            handlTimerEnd = a;
            this.maxTime = maxTime;
           if(isCountingDown) this.currentTime = this.maxTime;
           else this.currentTime = 0;

            this.isCountingDown = isCountingDown;
        
        }
        public TimerBase(UnityEvent a)
        {
            handlTimerEnd = a;
      
            this.maxTime = 1;
            currentTime = maxTime;  
            isCountingDown = true;
        }
        public float Tick(float deltaTime)
        {
         if(!shouldCount) return currentTime;
            if(isCountingDown) currentTime -= deltaTime;
           else currentTime += deltaTime;
            CheckEndTime();
            return currentTime;
        }
        public  bool CheckEndTime()
        {
            if (isCountingDown)
            {
               if(currentTime <= 0)
                {
                    handlTimerEnd?.Invoke();
                   
                    Reset();
                    return true;
                }
                return false;
            }  
            else
            {
                if(currentTime >= maxTime)
                {
                    handlTimerEnd?.Invoke();
                  Reset();
                  return true;
                }
                return false;
            }
            
            
        }
   public float returnTime()
        {
            return currentTime;
        }
      public  void Reset()
        {
            if (isCountingDown) currentTime = maxTime;
            else currentTime = 0;
        }
    }
  
}
