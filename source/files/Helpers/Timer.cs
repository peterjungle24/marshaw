using System;
using System.Collections.Generic;
using UnityEngine;

namespace welp
{
    public static class timer_manage
    {
        public static bool test_bool;

        public static void ApplyHooks()
        {
            foreach (var timer in timer_manage.TimerRegistered)
            {
                timer.Advance();

                //if the current Svalue is same as value_wanted, it restart
                if (timer.current_value >= timer.value_wanted)
                {
                    test_bool = true;
                }
            }

            TimerRegistered.RemoveAll(t => t.value_reached); //Cleanup
        }

        public static List<Timer> TimerRegistered = new();  //current timers
    }
    public class Timer
    {
        public float value_wanted;  //The number of ticks to run the stealthTimer for
        public float current_value; //The number of ticks processed since starting the stealthTimer
        public bool continuous;

        public bool is_running => current_value > 0 && !value_reached;  //checks if is running
        public virtual bool value_reached => !continuous && current_value >= value_wanted;  //if is not continuous, and math.
        public bool is_equal => current_value == value_wanted;

        public Timer(float counter)
        {
            value_wanted = counter;
        }
        public Timer()
        {

        }

        public void Start()
        {
            current_value = 0f; //resets the stealthTimer

            if (!timer_manage.TimerRegistered.Contains(this))
            {
                timer_manage.TimerRegistered.Add(this);
            }
        }
        public virtual void Advance()
        {
            current_value++;
        }
        public void Stop()
        {
            //Set fields back to default values
            current_value = 0;

            //Unregister this stealthTimer to prevent future updates
            timer_manage.TimerRegistered.Remove(this);
        }
    }
    public class FlagTimer : Timer
    {
        //timer_limit is unnecessary

        public int interval;            //sprite timer that sets a flag every time an interval period is reached
        public bool interval_reached;   //when the interval is reached

        public FlagTimer(int interval, int timer_limit) : base(timer_limit)
        {
            Debug.Log("Ctor 0 from FlagTimer");
            this.interval = interval;
            this.continuous = true; //sets the continuous to True

            if (interval == 0f)
            {
                Debug.Log("Interval was 0");
                throw new ArgumentException("Interval cannot be zero");
            }
            Debug.Log(this.interval);
        }
        public FlagTimer(int interval) : this(interval, 0)
        {
            this.interval = interval;
            Debug.Log("Ctor 1 from FlagTimer");
            Debug.Log(this.interval);
        }

        public override void Advance()
        {
            base.Advance(); //calls the original method
        }
    }
}
