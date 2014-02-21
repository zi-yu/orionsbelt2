using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class PlayerPlanetLevelDependency : IFacilityRule {

        #region IRule Members

        public ResourceState TargetState {
            get { return ResourceState.InQueue; }
        }

        public ResourceState NextState {
            get { return ResourceState.Available; }
        }

        public bool IsGlobal {
            get { return false; }
        }

        public int TargetLevel {
            get { return 0; }
        }

        public bool AppliesToArgs(RuleArgs args)
        {
            return args.NextState == TargetState;
        }

        public bool UndoAppliesToArgs(RuleArgs args)
        {
            return false;
        }

        public bool IsForLevel(int level)
        {
            return true;
        }

        public Result CanProcess(RuleArgs args)
        {
            IPlanetResource resource = args.PlanetResource;
            IPlanet planet = args.Planet;
            IPlayer player = args.Player;

            int planetLevel = AdjustLevel(planet.Level);
            if (planetLevel < resource.Level) {
                return Result.Create(new CheckPlanetLevel(planet.Level, resource.Level * 2 - 1));
            }

            int playerLevel = AdjustLevel(player.PlanetLevel);
            if (playerLevel < resource.Level) {
                return Result.Create(new CheckPlayerPlanetLevel(player.PlanetLevel, resource.Level * 2 -1));
            }

            return Result.Ignore;
        }

        private int AdjustLevel(int n)
        {
            double dn = n;
            return (int)Math.Ceiling(dn / 2);
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
            return "Insuficient player level";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int targetLevel)
        {
            return translator.Translate(GetType().Name);
        }

        #endregion ToString

        #region Static Utils

        internal static void Add(IResourceWithRulesInfo info)
        {
            PlayerPlanetLevelDependency dependency = new PlayerPlanetLevelDependency();
            info.Rules.Register(dependency);
        }

        #endregion Static Utils

    };
}
