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
    public class Extractor : BaseFacility {

        #region Properties

        public override string Name {
            get { return "Extractor"; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override bool CountsForFacilityLevel {
            get { return true; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        public override int MaxLevel
        {
            get
            {
                return 5;
            }
        }

        #endregion Properties

        #region RuleSet

        public override int GetScore(int level, int quantity)
        {
            return Cost.Calculate(1, 0, 40, 2, 0, level);
        }

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            PlayerPlanetLevelDependency.Add(this);
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            AddToModifier.Add(this, 1);
            AddRareToModifier.Add(this);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            //=B2/4*0.5*POWER(B2,2)
            return Cost.CalculateDuration(4, 0, 0.5, 2, 0, level);
        }

        protected override void BuildCostRules()
        {
            //=(B2/2)*80*POWER(B2,3)
            Cost.Add(this, typeof(Astatine), 2, 0, 80, 3, 0);
            //=100*POWER(B2,3)-120
            Cost.Add(this, typeof(Radon), 0, 0, 100, 3, 120);
            //=B2/4*400*POWER(B2,2)-850
            Cost.Add(this, typeof(Cryptium), 4, 0, 400, 2, 850);
            //=B2/4*600*POWER(B2,2)-4300
            Cost.Add(this, typeof(Prismal), 4, 0, 600, 2, 4300);
            //=B2*600*POWER(B2,2)-53000
            Cost.Add(this, typeof(Argon), 1, 0, 600, 2, 53000);
            
        }

        #endregion RuleSet

        #region Static Utils

        public static IFacilityInfo Resource {
            get { return (IFacilityInfo)RulesUtils.GetResource(typeof(Extractor)); }
        }

        #endregion Static Utils

        #region BaseFacility Implementation

        public override Race[] Races {
            get { return RaceUtils.AllRaces; }
        }

        #endregion BaseFacility Implementation

    };

}
