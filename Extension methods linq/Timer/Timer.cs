using System;

namespace Timer
{
    /*
     * Using delegates write a class Timer that has can execute certain method at each t seconds.
     * Read in MSDN about the keyword event in C# and how to publish events.
     * Re-implement the above using .NET events and following the best practices.
     */
    class Timer
    {
        public delegate void Tick(object sender, TimerTickEventArgs args);
        public event Tick OnTick;

        public TimeSpan Interval { get; set; }

        private bool isStarted = false;

        public void Start()
        {
            isStarted = true;
            var startTime = DateTime.Now;
            while (isStarted)
            {
                var elapsed = DateTime.Now - startTime;
                TimeSpan elapsedTime = new TimeSpan(elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
                if (elapsedTime >= this.Interval)
                {
                    OnTick(this, new TimerTickEventArgs());
                    startTime = DateTime.Now;
                }
            }
        }

        public void Stop()
        {
            isStarted = false;
        }
    }
}
