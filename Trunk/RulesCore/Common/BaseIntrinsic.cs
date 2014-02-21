using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Common {

    /// <summary>
    /// This class represents a facility
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class BaseIntrinsic: BaseResource, IIntrinsicInfo {

        #region BaseResource Implementation

        public override ResourceType Type {
            get { return ResourceType.Intrinsic;  }
        }

        public override bool CanUnloadFromFleet {
            get { return true; }
        }

        public override bool CanAcumulate {
            get { return true; }
        }

        public override bool IsBuildable {
            get { return false; }
        }

        public override int MaxLevel {
            get { return 1;  }
        }

        #endregion BaseResource Implementation

        #region Methods

        public override Result IsAvailable(IPlanetResource resource)
        {
            return Result.Success;
        }

        public override Result IsUpgradeAvailable(IPlanetResource resource)
        {
            return Result.Fail;
        }

        public override Result IsBuildAvailable(IPlanet planet)
        {
            return Result.Fail;
        }

        public override Result CheckCost(IResourceOwner owner, IPlanetResource resource, int quantity)
        {
            return Result.Fail;
        }

        #endregion Methods

    };

}
