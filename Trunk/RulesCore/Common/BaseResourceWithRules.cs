using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Common {

    /// <summary>
    /// This class represents a generic resource with rules
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class BaseResourceWithRules : BaseResource, IResourceWithRulesInfo {

        #region IResourceWithRulesInfo Members

        private RuleSet rules = new RuleSet();
        public IRuleSet Rules {
            get { return rules; }
        }

        public abstract ResourceState InitialState {get;}

        public override int StartLevel {
            get {
                return 1;
            }
        }

        #endregion

        #region Methods

        public override Result IsUpgradeAvailable(IPlanetResource resource)
        {
            int nextLevel = resource.Level + 1;
            return CanProcessRules(resource.Owner, resource, ResourceState.Available, nextLevel, 1);
        }

        public override Result IsBuildAvailable(IPlanet planet)
        {
            if (!IsBuildable) {
                return Result.Fail;
            }
            return CanProcessBuildRules(planet, ResourceState.Available);
        }

        public override Result CheckCost(IResourceOwner owner, IPlanetResource resource, int quantity)
        {
            return CanProcessRules(owner, resource, ResourceState.InQueue, resource.Level, quantity);
        }

        public override void OnComplete(IPlanetResource resource)
        {
            ProcessRules(resource.Owner, resource, ResourceState.Running, resource.Level, resource.Quantity);
        }

        public override void OnDestroy(IPlanetResource resource)
        {
            UndoRules(resource.Owner, resource, ResourceState.Running, resource.Level, resource.Quantity);
        }

        public override void ProcessCost(IPlanetResource resource)
        {
            ProcessRules(resource.Owner, resource, ResourceState.InQueue, resource.Level, resource.Quantity);
        }

        public override void UndoCost(IPlanetResource resource)
        {
            UndoRules(resource.Owner, resource, ResourceState.InQueue, resource.Level, resource.Quantity);
        }

        public override void Init()
        {
            BuildDependecyRules();
            BuildCostRules();
            BuildOnCompleteRules();
        }

        protected virtual void BuildOnCompleteRules()
        {
            UpdateResourceAfterConstruction.Add(this);
            UpdateScoreAfterConstruction.Add(this);
        }

        protected virtual void BuildCostRules()
        {

        }

        protected virtual void BuildDependecyRules()
        {
        }

        #endregion Methods

        #region Utilities

        protected Result CanProcessRules(IResourceOwner owner, IPlanetResource resource, ResourceState nextState, int nextLevel, int quantity)
        {
            return Rules.CanProcess(RuleArgs.Create(owner, resource, nextState, nextLevel, quantity));
        }

        private Result CanProcessBuildRules(IPlanet planet, ResourceState nextState)
        {
            return Rules.CanProcess(RuleArgs.Create(planet, nextState));
        }

        protected Result ProcessRules(IResourceOwner owner, IPlanetResource resource, ResourceState nextState, int nextLevel, int quantity)
        {
            return Rules.Process(RuleArgs.Create(owner, resource, nextState, nextLevel, quantity));
        }

        protected Result UndoRules(IResourceOwner owner, IPlanetResource resource, ResourceState nextState, int nextLevel, int quantity)
        {
            return Rules.Undo(RuleArgs.Create(owner, resource, nextState, nextLevel, quantity));
        }

        #endregion Utilities

    };

}
