using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a generic rule
    /// </summary>
    public interface IRule {

        #region Properties

        /// <summary>
        /// This rule applies to resources in the TargetState state
        /// </summary>
        ResourceState TargetState { get;}

        /// <summary>
        /// After Process, this rules takes the resource to NextState
        /// </summary>
        ResourceState NextState { get;}

        /// <summary>
        /// This rule is global and does not need specific properties
        /// </summary>
        bool IsGlobal { get;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Processes this rule
        /// </summary>
        void Process(RuleArgs args);

        /// <summary>
        /// Resets this rule actions
        /// </summary>
        void Undo(RuleArgs args);

        /// <summary>
        /// Checks if the current IPlanetResource can advance to nextState
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The query result</returns>
        Result CanProcess(RuleArgs args);

        /// <summary>
        /// True if this rule applies to the given args
        /// </summary>
        /// <param name="args">The args</param>
        /// <returns>True if applies</returns>
        bool AppliesToArgs(RuleArgs args);

        /// <summary>
        /// True if this rule applies to the given args
        /// </summary>
        /// <param name="args">The args</param>
        /// <returns>True if applies</returns>
        bool UndoAppliesToArgs(RuleArgs args);

        /// <summary>
        /// True if this action runs for the specified level
        /// </summary>
        /// <param name="level">True</param>
        /// <returns></returns>
        bool IsForLevel(int level);

        /// <summary>
        /// Translates this rule with a language translator
        /// </summary>
        /// <param name="translator">The language translator</param>
        /// <param name="info">The resource</param>
        /// <param name="level">The target level to display</param>
        /// <returns>The localized string</returns>
        string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int level);

        #endregion Methods

    };

}
