using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class UltimateUnitRestriction : IRule  {

        #region Properties

        private IResourceWithRulesInfo resource;

        public IResourceWithRulesInfo Resource
        {
            get { return resource; }
            set { resource = value; }
        }

        #endregion Properties

        #region IRule Members

        public ResourceState TargetState {
            get { return ResourceState.Running; }
        }

        public bool IsGlobal {
            get { return false; }
        }

        public ResourceState NextState {
            get { return ResourceState.InQueue; }
        }

        public Result CanProcess(RuleArgs args)
        {
            return args.Player.CanBuildUltimateUnit(args.PlanetResource.Quantity);
        }

        public bool AppliesToArgs(RuleArgs args)
        {
            return args.NextState == NextState;
        }

        public bool UndoAppliesToArgs(RuleArgs args)
        {
            return false;
        }

        public bool IsForLevel(int level)
        {
            return true;
        }

        public void Process(RuleArgs args)
        {
        }

        public void Undo(RuleArgs args)
        {
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return "UltimateUnitRestriction";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int targetLevel)
        {
            return translator.Translate("UltimateUnitRestriction");
        }

        #endregion ToString

        #region Static Utils

        internal static void Add(IResourceWithRulesInfo info)
        {
            UltimateUnitRestriction cost = new UltimateUnitRestriction();
            info.Rules.Register(cost);
        }

        #endregion Static Utils

    };
}
