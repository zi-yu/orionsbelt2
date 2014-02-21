using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Common {

    /// <summary>
    /// This class represents a facility
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class BaseFacility : BaseResourceWithRules, IFacilityInfo {

        #region BaseResource Implementation

        public override ResourceType Type {
            get { return ResourceType.Facility;  }
        }

        public override bool CanAcumulate {
            get { return false; }
        }

        public override bool CanUnloadFromFleet {
            get { return false; }
        }

        public override bool IsBuildable {
            get { return true; }
        }

        public override int MaxLevel {
            get { return 10;  }
        }

        #endregion BaseResource Implementation

        #region BaseResource Methods

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 10 * level * level * level + 10;
        }

        public override double GetBaseCostAttenuation(RuleArgs args, IIntrinsicInfo resource)
        {
            if(resource.IsRare)
            {
                return base.GetBaseCostAttenuation(args, resource) * 0.5;
            }
            return base.GetBaseCostAttenuation(args, resource);
        }

        #endregion BaseResource Methods

    };

}
