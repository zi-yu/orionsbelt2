using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a quest that needs specific inputs
    /// </summary>
    public interface IQuestSpecificData<T> {

        /// <summary>
        /// Processes the given information
        /// </summary>
        /// <param name="information">The information</param>
        void Process(T information);

    };

}
