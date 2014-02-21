using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Humans Serium Extractor
    /// </summary>
    public class SeriumExtractor : BaseHumansFacility {

        #region Properties

        public override string Name {
            get { return "SeriumExtractor"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        #endregion Properties

        #region RuleSet

        protected override void BuildDependecyRules()
        {
            Dependency.Add(this, 1, typeof(CommandCenter), 1,MaxLevel);

        }

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 4, 2, 0, level);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, Serium.Resource, 1);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return Cost.CalculateDuration(1, 0, 0.06, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=(B2/6)*240*POWER(B2,2)-2200
            Cost.Add(this, typeof(Mithril), 6, 0, 240, 2, 2200);
            //=20*POWER(B2,2)
            Cost.Add(this, typeof(Serium), 0, 0, 20, 2, 0);
            //=220*POWER(B2,2)
            Cost.Add(this, typeof(Energy), 0, 0, 220, 2, 0);

            //=90*POWER(B2,2)-2000
            Cost.Add(this, typeof(Argon), 0, 0, 90, 2, 2000);
            //=(B2/10)*60*POWER(B2,2)-1000
            Cost.Add(this, typeof(Prismal), 10, 0, 60, 2, 1000);
            //=90*POWER(B2,2)-5500
            Cost.Add(this, typeof(Radon), 0, 0, 90, 2, 5500);
            //=80*POWER(B2,2)-3800
            Cost.Add(this, typeof(Astatine), 0, 0, 80, 2, 3800);
            //=(B2/15)*100*POWER(B2,2)-4500
            Cost.Add(this, typeof(Cryptium), 15, 0, 100, 2, 4500);
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(SeriumExtractor)); }
        }

        #endregion Static Utils

    };

}
