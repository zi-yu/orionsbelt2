using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a rules container
    /// </summary>
    public interface IRuleSet {

        #region RuleSet Management Methods

        /// <summary>
        /// Registers a rule
        /// </summary>
        /// <param name="nextState">The state transition that applies to this rule</param>
        /// <param name="rule">The rule</param>
        void Register(IRule rule);

        /// <summary>
        /// Gets the registered rules for the given state
        /// </summary>
        /// <param name="state">The target state</param>
        /// <returns>The rules</returns>
        IList<IRule> GetRulesByState(ResourceState state);

        /// <summary>
        /// Enumerates trough all rules
        /// </summary>
        /// <returns></returns>
        IEnumerable<IRule> GetAll();

        #endregion RuleSet Management Methods

        #region Rule Related Methods

        /// <summary>
        /// Checks if the current RuleArgs can be processed
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The query result</returns>
        Result CanProcess(RuleArgs args);

        /// <summary>
        /// Executes all the given rules
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The result</returns>
        Result Process(RuleArgs args);

        /// <summary>
        /// Does the oposite of Process
        /// </summary>
        /// <param name="args">The args</param>
        /// <returns>The result</returns>
        Result Undo(RuleArgs args);

        #endregion Rule Related Methods

    };

}
