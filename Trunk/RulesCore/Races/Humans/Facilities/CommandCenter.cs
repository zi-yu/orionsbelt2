using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Dark Humans Command Center
    /// </summary>
    public class CommandCenter : BaseHumansFacility {

        #region Properties

        public override string Name {
            get { return "CommandCenter"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override bool CountsForFacilityLevel {
            get { return true; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Running; }
        }

        #endregion Properties

        #region RuleSet

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Energy.Resource, 1);
            AddToModifier.Add(this, Serium.Resource, 1);
            AddToModifier.Add(this, Mithril.Resource, 1, 4);

            AddToLimit.Add(this, 1000, 1);
            AddToLimit.Add(this, 1000, 5);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 2, typeof(SolarPanel), 1);
            Dependency.Add(this, 2, typeof(SeriumExtractor), 1);

            Dependency.Add(this, 3, typeof(UnitYard), 2, MaxLevel);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.072, 2, 0.072, level);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 10, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=(B2/3)*150*POWER(B2,2)-(150/3)-5000
            Cost.Add(this, typeof(Mithril), 3, 3, 150, 2, 5000);
            //=(B2/4)*120*POWER(B2,2)-(120/4)
            Cost.Add(this, typeof(Serium), 4, 4, 180, 2, 0);
            //=(B2/6)*220*POWER(B2,2)-(220/6)
            Cost.Add(this, typeof(Energy), 6, 6, 220, 2, 0);
            //=(B2/8)*220*POWER(B2,2)-1000
            Cost.Add(this, typeof(Argon), 8, 0, 220, 2, 1000);
            //=(B2/6)*120*POWER(B2,2)-4000
            Cost.Add(this, typeof(Prismal), 6, 0, 120, 2, 4000);
            //=(B2/6)*120*POWER(B2,2)-2000
            Cost.Add(this, typeof(Radon), 6, 0, 120, 2, 2000);
            //=(B2/5)*150*POWER(B2,2)-13000
            Cost.Add(this, typeof(Astatine), 5, 0, 150, 2, 13000);
            //=(B2/8)*120*POWER(B2,2)-9000
            Cost.Add(this, typeof(Cryptium), 8, 0, 120, 2, 9000);
            
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(CommandCenter)); }
        }

        #endregion Static Utils

    };

}
