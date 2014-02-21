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
    [DesignPatterns.Attributes.FactoryKey("Nest")]
    public class Nest : BaseBugsFacility {

        #region Properties

        public override string Name {
            get { return "Nest"; }
        }

        public override bool CountsForFacilityLevel {
            get { return true; }
        }

        public override bool IsRare {
            get { return false; }
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
            AddToModifier.Add(this, Elk.Resource, 1);
            AddToModifier.Add(this, Protol.Resource, 1);

            AddToLimit.Add(this, 2000);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            //=B2*0.062*POWER(B2,2)-0.062
            return Cost.CalculateDuration(1, 0, 0.062, 2, 0.062, level);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 2, typeof(Incubator), 1, MaxLevel);
        }

        protected override void BuildCostRules()
        {
            //=(B2/4)*220*POWER(B2,2)-(55)
            Cost.Add(this, typeof(Elk), 4, 0, 220, 2, 55);
            //=(B2/4)*280*POWER(B2,2)-(70)
            Cost.Add(this, typeof(Protol), 4, 0, 280, 2, 70);
            //=(B2/6)*240*POWER(B2,2)-1500
            Cost.Add(this, typeof(Prismal), 6, 0, 240, 2, 1500);
            //=(B2/4)*160*POWER(B2,2)-9000
            Cost.Add(this, typeof(Radon), 4, 0, 160, 2, 9000);
            //=(B2/4)*120*POWER(B2,2)-4000
            Cost.Add(this, typeof(Cryptium), 4, 0, 120, 2, 4000);
            //=(B2/5)*250*POWER(B2,2)-26000
            Cost.Add(this, typeof(Astatine), 5, 0, 250, 2, 26000);
            //=(B2/8)*120*POWER(B2,2)-11000
            Cost.Add(this, typeof(Argon), 8, 0, 120, 2, 11000);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(Nest)); }
        }

        #endregion Static Utils

    };

}
