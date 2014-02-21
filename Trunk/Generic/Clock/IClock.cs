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

namespace OrionsBelt.Generic {

    public delegate void ClockTicked();

    /// <summary>
    /// Manages time in the game
    /// </summary>
    public interface IClock {

        #region Generic Properties

        /// <summary>
        /// The current clock time
        /// </summary>
        int Tick { get; set; }

        /// <summary>
        /// Triggered event upon tick change
        /// </summary>
        event ClockTicked Ticked;

        #endregion Generic Properties

        #region Configuration Properties

        /// <summary>
        /// How many millis per tick
        /// </summary>
        int MillisPerTick { get;}

        int MinutesPerTick { get; }

        #endregion Configuration Properties

        #region Utility Methods

        /// <summary>
        /// Advances to the next tick
        /// </summary>
        void Advance();

        /// <summary>
        /// Starts the clock
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the clock
        /// </summary>
        void Stop();

        /// <summary>
        /// Converts the current tick to a datetime
        /// </summary>
        /// <returns>The current datetime</returns>
        DateTime GetCurrentDate();

        /// <summary>
        /// Gets the date when this clock was rebooted
        /// </summary>
        /// <returns></returns>
        DateTime GetStartDate();

        /// <summary>
        /// Gets the time remaining to reach the given tick
        /// </summary>
        /// <param name="targetTick">The target tick</param>
        /// <returns>The time left</returns>
        TimeSpan GetTimeLeft(int targetTick);

        /// <summary>
        /// Gets the time when the tick will ocurr
        /// </summary>
        /// <param name="targetTick">The target tick</param>
        /// <returns>The calendar time</returns>
        DateTime GetDate(int targetTick);

        /// <summary>
        /// Converts the given timespan to Ticks
        /// </summary>
        /// <param name="span">The time span</param>
        /// <returns>The ticks</returns>
        int ConvertToTicks(TimeSpan span);

        /// <summary>
        /// Converts the given tick quantity to a timespan
        /// </summary>
        /// <param name="ticks">The ticks</param>
        /// <returns>The time span</returns>
        TimeSpan ConvertToTimeSpan(int ticks);

        /// <summary>
        /// Returns current tick plus the specified delay
        /// </summary>
        /// <param name="duration">The delay</param>
        /// <returns>The end tick</returns>
        int EndTickByDelay(int duration);

        /// <summary>
        /// The number of millis to Tick
        /// </summary>
        int MillisToTick { get;}

        #endregion Utility Methods

    };

}
