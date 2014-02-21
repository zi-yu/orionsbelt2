using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class UpdateFleetAfterConstruction : IRule  {

        #region IRule Members

        public ResourceState TargetState {
            get { return ResourceState.Complete; }
        }

        public ResourceState NextState {
            get { return ResourceState.Running; }
        }

        public bool IsGlobal {
            get { return true; }
        }

        public Result CanProcess(RuleArgs args)
        {
            return Result.Success;
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
            return level == 1;
        }

        public void Process(RuleArgs args)
        {
            ProcessLogic(args, 1);
        }

        private static void ProcessLogic(RuleArgs args, int factor)
        {
            IPlanetResource resource = args.PlanetResource;
			IUnitInfo unit = (IUnitInfo)resource.Info;
			if (unit.IsUltimate) {
                args.Planet.CreateUltimateFleet(unit);
			}else {
				args.Planet.DefenseFleet.Add(resource);
			}
        }

        public void Undo(RuleArgs args)
        {
        }

        #endregion

        #region Static Utils

        private static UpdateFleetAfterConstruction instance = new UpdateFleetAfterConstruction();

        internal static void Add(IResourceWithRulesInfo info)
        {
            info.Rules.Register(instance);
        }

        #endregion Static Utils

        #region ToString

        public override string ToString()
        {
            return "Move units to Defense Fleet";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int targetLevel)
        {
            return translator.Translate("MoveUnitsToDefenseFleet");
        }

        #endregion ToString

    };
}
