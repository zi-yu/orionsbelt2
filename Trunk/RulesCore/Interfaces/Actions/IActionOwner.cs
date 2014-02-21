using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents an entity that has private actions
    /// </summary>
    public interface IActionOwner {

        /// <summary>
        /// Related actions
        /// </summary>
        IList<ITimedAction> Actions { get;}

        /// <summary>
        /// Registers an action
        /// </summary>
        /// <param name="action">The action</param>
        void RegisterAction(ITimedAction action);

        /// <summary>
        /// Removes an action
        /// </summary>
        /// <param name="action">The action</param>
        void RemoveAction(ITimedAction action);

        /// <summary>
        /// Handles added/removed actions
        /// </summary>
        void SyncActions();

    };
}
