using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Humans Deep Space Scanner
    /// </summary>
    public class DeepSpaceScanner : BaseHumansFacility {

        #region Properties

        public override string Name {
            get { return "DeepSpaceScanner"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        public override int MaxLevel
        {
            get
            {
                return 2;
            }
        }

        #endregion Properties

        #region RuleSet

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 40, 2, 0, level, true);
        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 3000, 2, 0, level, true);
        }

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(CommandCenter), 7);
        }

        protected override void BuildCostRules()
        {
            //=B2*22000*POWER(1,2)
            //=B2*26000*POWER(1,2)
            //=B2*28000*POWER(1,2)
            Cost.Add(this, typeof(Mithril), 1, 0, 22000, 2, 0, true);
            Cost.Add(this, typeof(Serium), 1, 0, 26000, 2, 0, true);
            Cost.Add(this, typeof(Energy), 1, 0, 28000, 2, 0, true);

            Cost.Add(this, typeof(Argon), 1, 0, 6000, 2, 0, true);
            Cost.Add(this, typeof(Prismal), 1, 0, 5000, 2, 0, true);
            Cost.Add(this, typeof(Radon), 1, 0, 9000, 2, 12000, true);
            Cost.Add(this, typeof(Astatine), 1, 0, 7000, 2, 0, true);
        }

        protected override void BuildOnCompleteRules(){
            UpdateResourceAfterConstruction.Add(this);
            UpdateUltimateAfterConstruction.Add(this);
            UpdateScoreAfterConstruction.Add(this);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(DeepSpaceScanner)); }
        }

        #endregion Static Utils

    };

}
