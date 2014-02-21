using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using OrionsBelt.Generic.Log;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.Generic {

    /// <summary>
    /// Manages time in the game
    /// </summary>
    public class TickClock : Clock {

        #region Ctor

        public TickClock(int startTick, int millisPerTick)
        {
            Started = startTick;
            Tick = startTick;
            LastTickDate = DateTime.Now;
            MillisPerTick = millisPerTick;
            LogStart(Started, LastTickDate);

        }

        public TickClock()
            : this(true)
        { 
        }

        public TickClock(bool prepare)
        {
            if (prepare) { 
                Started = Server.Properties.CurrentTick;
                Tick = Started;
                LastTickDate = Server.Properties.LastTickDate;
                MillisPerTick = Server.Properties.MillisPerTick;
                LogStart(Started, LastTickDate);
            }
        }

        #endregion Ctor

        #region Clock Properties

        private int tick;
        public override int Tick {
            get { return tick; }
            set {
                tick = value; 
            }
        }

        private int started;
        public int Started {
            get { return started; }
            set { started = value; }
        }

        private int millisPerTick;
        public override int MillisPerTick {
            get { return millisPerTick; }
            set { millisPerTick = value; }
        }

        public override int MinutesPerTick
        {
            get { return MillisPerTick / 60 / 1000; }
        }

        private DateTime lastTickDate;
        public DateTime LastTickDate {
            get { return lastTickDate; }
            set { lastTickDate = value; }
        }

        private System.Threading.Timer timer;
        public System.Threading.Timer CurrentTimer {
            get { return timer;  }
            set { timer = value; }
        }

        #endregion Clock Properties

        #region Clock Methods

        public override void Advance()
        {
            DateTime start = DateTime.Now;

            ++Tick;
            OnTicked();
            LastTickDate = DateTime.Now;
            Server.Persist(Tick, LastTickDate);

            TimeSpan elapsed = DateTime.Now - start;
            LogTick(elapsed);
        }

        public override void Start()
        {
            Console.Write("Auto-Starting {0}... ", GetType().Name);
			if (Server.Properties.Running && !Server.IsChronos) {
                if (CurrentTimer != null) {
                    CurrentTimer.Dispose();
                }
                long dueTime = GetTimerDueTime();
                CurrentTimer = new System.Threading.Timer(StaticAdvance, this, dueTime, MillisPerTick);
                LogTimerStart(dueTime);
                Console.WriteLine("Started!");
            } else {
                Console.WriteLine("Aborted! Overrided by Running:{0} && IsChronos:{1}", Server.Properties.Running, Server.IsChronos);
            }
        }

        private long GetTimerDueTime()
        {
            long due = (long)GetTimeToNextTick().TotalMilliseconds;
            if (due < 15000) {
                return 15000;
            }
            return due;
        }

        public static void StaticAdvance(object state)
        {
            try {
                ((TickClock)state).Advance();
            } catch (Exception ex) {
                ExceptionLogger.Log(ex);
            }
        }

        public override void Stop()
        {
        }

        public override DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }

        public override DateTime GetStartDate()
        {
            return DateTime.Now;
        }

        public override DateTime GetDate(int targetTick)
        {
            int ticksLeft = targetTick - Tick;
            return DateTime.Now.AddMinutes(MinutesPerTick*ticksLeft);
        }

        public override TimeSpan GetTimeLeft(int targetTick)
        {
            TimeSpan timeToNextTick = GetTimeToNextTick();
            int ticksLeft = GetTicksLeft(targetTick) - 1; 
            return timeToNextTick.Add(TimeSpan.FromMilliseconds(MillisPerTick * ticksLeft));
        }

        private int GetTicksLeft(int targetTick)
        {
            return (targetTick - Tick);
        }

        private TimeSpan GetTimeToNextTick()
        {
            return LastTickDate.AddMilliseconds(MillisPerTick) - DateTime.Now;
        }

        #endregion Clock Methods

    };

}
