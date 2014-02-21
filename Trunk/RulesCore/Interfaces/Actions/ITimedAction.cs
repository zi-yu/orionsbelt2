using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents an abstract action
    /// </summary>
    public interface ITimedAction : IAction, IBackToStorage<TimedActionStorage> {

        #region Properties

        /// <summary>
        /// The action start tick
        /// </summary>
        int StartTick { get; set;}

        /// <summary>
        /// The action end tick
        /// </summary>
        int EndTick { get; set;}

        /// <summary>
        /// The action's interval if recursive
        /// </summary>
        int Interval { get;}

        /// <summary>
        /// Indicates if the action will loop
        /// </summary>
        Occurrence Occurrence { get; }

        /// <summary>
        /// The action's visibility
        /// </summary>
        Visibility Visibility { get; }

        /// <summary>
        /// True if the action already started
        /// </summary>
        bool Started { get;}

        /// <summary>
        /// True it the action has ended
        /// </summary>
        bool Ended { get;}

        /// <summary>
        /// True if the action has a DB representation
        /// </summary>
        bool IsPersistable { get;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Starts the action
        /// </summary>
        /// <param name="delay">The time will take the action to process</param>
        void Start(int delay);

        /// <summary>
        /// Ends the action
        /// </summary>
        /// <param name="processAction">True if Process() should still be called</param>
        void ForceEnd(bool processAction);

        #endregion Methods

    };
}
