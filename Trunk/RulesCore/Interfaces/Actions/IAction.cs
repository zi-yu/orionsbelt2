using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents an abstract action
    /// </summary>
    public interface IAction {

        /// <summary>
        /// The action's name
        /// </summary>
        string Name { get;}

        /// <summary>
        /// Raw action's data
        /// </summary>
        string Data { get; set;}

        /// <summary>
        /// Executes some actions
        /// </summary>
        void Process();

    };
}
