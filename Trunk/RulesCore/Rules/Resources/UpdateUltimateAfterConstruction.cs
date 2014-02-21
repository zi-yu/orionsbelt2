using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class UpdateUltimateAfterConstruction : IRule  {

        #region Properties

        #endregion Properties

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
            return args.NextState == ResourceState.Running;
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
            ProcessLogic(args, 1);
        }

        private static void ProcessLogic(RuleArgs args, int factor)
        {
            IPlanetResource resource = args.PlanetResource;
            if( resource.State == ResourceState.Running ){
                ++args.Player.UltimateWeaponLevel;
            }
        }

        public void Undo(RuleArgs args)
        {
        }

        #endregion

        #region Static Utils

		private static UpdateUltimateAfterConstruction instance = new UpdateUltimateAfterConstruction();

        internal static void Add(IResourceWithRulesInfo info)
        {
            info.Rules.Register(instance);
        }

        #endregion Static Utils

        #region ToString

        public override string ToString()
        {
            return "Update Ultimate Weapon Level";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int targetLevel)
        {
            return string.Empty;
        }

        #endregion ToString

    };
}
