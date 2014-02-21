using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Generic.Log;

namespace OrionsBelt.Generic {

    /// <summary>
    /// Manages time in the game
    /// </summary>
    public abstract class Clock : IClock {

        #region Static Utils

        private static object sync = new object();
        private static IClock instance;

        public static IClock Instance {
            get {
                lock (sync) {
                    if (instance == null) {
                        PrepareClock();
                    }
                }
                return instance;
            }
            set { instance = value; }
        }

        private static void PrepareClock()
        {
            if (Server.UsingInProcClock) {
                instance = new TickClock(true);
            } else {
                instance = new ProxyClock();
            }
            instance.Start();
        }

        #endregion Static Utils

        #region IClock Members

        public event ClockTicked Ticked;

        public abstract int Tick { get; set; }

        public abstract int MillisPerTick { get; set;}

        public abstract int MinutesPerTick { get; }

        public abstract void Advance();

        public abstract void Start();
        
        public abstract void Stop();

        public abstract DateTime GetDate(int targetTick);

        public abstract DateTime GetCurrentDate();

        public abstract DateTime GetStartDate();

        public abstract TimeSpan GetTimeLeft(int targetTick);

        protected virtual void OnTicked()
        {
            if (Ticked != null){
                Ticked();
            }
        }

        public int ConvertToTicks(TimeSpan span)
        {
            double raw = span.TotalMilliseconds / MillisPerTick;
            return (int)Math.Ceiling(raw);
        }

        public TimeSpan ConvertToTimeSpan(int ticks)
        {
            double t = ticks;
            double mills = MillisPerTick;
            double all = t * mills;
            return TimeSpan.FromMilliseconds(all);
        }

        public int EndTickByDelay(int duration)
        {
            return Tick + duration;
        }

        public int MillisToTick {
            get {
                return (int)GetTimeLeft(Tick + 1).TotalMilliseconds;
            }
        }

        #endregion

        #region Logs

        protected void LogStart(int started, DateTime lastTickDate)
        {
            //Logger.Debug(LogType.Clock, "{4} Started, StartTick={0} Tick={1} LastTickDate={2} MillisPerTick={3} StackTrace={5}",
            //        started, Tick, lastTickDate, MillisPerTick, GetType().Name, Environment.StackTrace
            //    );
        }

        protected void LogTick(TimeSpan elapsed)
        {
            //Logger.Debug(LogType.Clock, "{0} Advanced, NewTick:{1} Elapsed:{2}",
            //        GetType().Name, Tick, elapsed
            //    );
        }

        protected void LogTimerStart(long dueTime)
        {
            //double due = dueTime;
            //due = due / 1000 / 60;

            //Logger.Debug(LogType.Clock, "{2} Timer Started at {0}, Tick:{1} DueTime:{3} NextRun: {4}",
            //    DateTime.Now, Tick, GetType().Name, due, DateTime.Now.AddMilliseconds(dueTime+MillisPerTick));
        }

        #endregion Logs

    };

}
