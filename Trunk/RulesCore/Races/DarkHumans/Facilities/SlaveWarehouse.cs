using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Humans Silo
    /// </summary>
    public class SlaveWarehouse : BaseDarkHumansFacility {

        #region Properties

        public override string Name {
            get { return "SlaveWarehouse"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        #endregion Properties

        #region RuleSet

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 3, 2, 0, level);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(DarknessHall), 1, MaxLevel);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.042, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=300*POWER(B2,2)
            Cost.Add(this, typeof(Gold), 0, 0, 300, 2, 0);
            //=(B2/3)*140*POWER(B2,2)
            Cost.Add(this, typeof(Titanium), 3, 0, 140, 2, 0);
            //=(B2/4)*120*POWER(B2,2)-(120/4)-250
            Cost.Add(this, typeof(Uranium), 4, 4, 120, 2, 250);

            //=120*POWER(B2,2)-1000
            Cost.Add(this, typeof(Cryptium), 0, 0, 120, 2, 1000);
            //=(B2/8)*80*POWER(B2,2)-3000
            Cost.Add(this, typeof(Argon), 8, 0, 80, 2, 3000);
            //=80*POWER(B2,2)-1300
            Cost.Add(this, typeof(Radon), 0, 0, 80, 2, 1300);
            //=(B2/8)*120*POWER(B2,2)-7000
            Cost.Add(this, typeof(Astatine), 8, 0, 120, 2, 7000);
            //=(B2/8)*100*POWER(B2,2)-9000
            Cost.Add(this, typeof(Prismal), 8, 0, 100, 2, 9000);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToLimit.Add(this);
            AddToProductionFactor.Add(this, -1);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(SlaveWarehouse)); }
        }

        #endregion Static Utils

    };

}
