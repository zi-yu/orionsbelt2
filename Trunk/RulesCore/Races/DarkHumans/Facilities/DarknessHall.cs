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
    [DesignPatterns.Attributes.FactoryKey("DarknessHall")]
    public class DarknessHall : BaseDarkHumansFacility {

        #region Properties

        public override string Name {
            get { return "DarknessHall"; }
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

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 9, 2, 0, level);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Gold.Resource, 1);
            AddToModifier.Add(this, Titanium.Resource, 1);
            AddToModifier.Add(this, Uranium.Resource, 1, 4);

            AddToLimit.Add(this, 1000, 1);
            AddToLimit.Add(this, 1000, 5);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            //=B2*0.062*POWER(B2,2)-0.062
            return Cost.CalculateDuration(1, 0, 0.062, 2, 0.062, level);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 2, typeof(DominationYard), 1, MaxLevel);
        }

        protected override void BuildCostRules()
        {
            //=(B2/4)*180*POWER(B2,2)-(180/4)-5600
            Cost.Add(this, typeof(Uranium), 4, 4,180, 2,5600);
            //=(B2/4)*150*POWER(B2,2)-(150/4)
            Cost.Add(this, typeof(Titanium), 4, 4, 150, 2, 0);
            //=(B2/4)*240*POWER(B2,2)-(240/4)
            Cost.Add(this, typeof(Gold), 4, 4, 240, 2, 0);
            //=(B2/8)*220*POWER(B2,2)-1000
            Cost.Add(this, typeof(Cryptium), 8, 0, 220, 2, 1000);
            //=(B2/6)*120*POWER(B2,2)-4000
            Cost.Add(this, typeof(Argon), 6, 0, 120, 2, 4000);
            //=(B2/6)*120*POWER(B2,2)-2000
            Cost.Add(this, typeof(Radon), 6, 0, 120, 2, 2000);
            //=(B2/5)*150*POWER(B2,2)-13000
            Cost.Add(this, typeof(Astatine), 5, 0, 150, 2, 13000);
            //=(B2/8)*120*POWER(B2,2)-9000
            Cost.Add(this, typeof(Prismal), 8, 0, 120, 2, 9000);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(DarknessHall)); }
        }

        #endregion Static Utils

    };

}
