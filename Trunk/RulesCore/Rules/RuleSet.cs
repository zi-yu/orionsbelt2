using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Rules {

    /// <summary>
    ///  Rule Collection and handling
    /// </summary>
    public class RuleSet : IRuleSet {

        #region Properties

        private Dictionary<ResourceState, List<IRule>> rules = new Dictionary<ResourceState,List<IRule>>();

        public Dictionary<ResourceState, List<IRule>> Rules {
            get { return rules; }
            set { rules = value; }
        }

        #endregion Properties

        #region RuleSet Management Methods

        public void Register(IRule rule)
        {
            List<IRule> list = GetList(rule.NextState);
            list.Add(rule);
        }

        private List<IRule> GetList(ResourceState nextState)
        {
            if (Rules.ContainsKey(nextState)) {
                return Rules[nextState];
            }

            List<IRule> list = new List<IRule>();
            Rules.Add(nextState, list);
            return list;
        }

        public IEnumerable<IRule> GetAll()
        {
            foreach (IList<IRule> rules in Rules.Values) {
                foreach(IRule rule in rules ) {
                    yield return rule;
                }
            }
        }

        #endregion RuleSet Management Methods

        #region Rule Related Methods

        public Result CanProcess(RuleArgs args)
        {
            Result result = new Result();

            foreach (IRule rule in GetRulesForArgs(args)) {
                Result ruleResult = rule.CanProcess(args);
                result.Merge(ruleResult);
            }

            if (result.Total == 0) {
                return Result.Success;
            }

            return result;
        }

        public IList<IRule> GetRulesByState(ResourceState state)
        {
            return GetList(state);
        }

        private IEnumerable<IRule> GetRulesForArgs(RuleArgs args)
        {
            foreach (KeyValuePair<ResourceState, List<IRule>> pair in Rules) {
                foreach (IRule rule in pair.Value) {
                    if( rule.AppliesToArgs(args) ) {
                        yield return rule;
                    }
                }
            }
        }

        private IEnumerable<IRule> GetUndoRulesForArgs(RuleArgs args)
        {
            foreach (KeyValuePair<ResourceState, List<IRule>> pair in Rules) {
                foreach (IRule rule in pair.Value) {
                    if( rule.UndoAppliesToArgs(args) ) {
                        yield return rule;
                    }
                }
            }
        }

        public Result Process(RuleArgs args)
        {
            foreach (IRule rule in GetRulesForArgs(args)) {
                rule.Process(args);
            }

            return Result.Success;
        }

        public Result Undo(RuleArgs args)
        {
            if (args.PlanetResource.State == ResourceState.Destroyed) {
                int lastLevel = args.PlanetResource.Level;
                for (int i = 1; i <= lastLevel; ++i) {
                    args.PlanetResource.Level = i;
                    UndoByLevel(args);
                }
            } else {
                UndoByLevel(args);    
            }
            
            return Result.Success;
        }

        private void UndoByLevel(RuleArgs args)
        {
            foreach (IRule rule in GetUndoRulesForArgs(args))  {
                rule.Undo(args);
            }
        }

        #endregion Rule Related Methods

    };
}
