using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using DesignPatterns;
using OrionsBelt.RulesCore.Results;
using System;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Common {

    /// <summary>
    /// This class represents a generic resource
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class BaseResource : IResourceInfo, IFactory {

        #region IResource Members

        public abstract string Name { get;}

        public abstract ResourceType Type { get;}

        public abstract bool CanUnloadFromFleet { get;}

        public virtual bool CanPassWormHoles {
            get { return CanUnloadFromFleet;  }
        }

        public virtual bool IsTradeRouteSpecific {
            get { return Races == RaceUtils.NoRace; }
        }

        public virtual bool IsResourceCost {
            get { return false; }
        }

        public abstract bool IsRare { get;}

        public bool CanLevelUp {
            get { return MaxLevel > 1; }
        }

        public abstract int MaxLevel { get;}

        public virtual bool Conceptual {
            get { return false; }
        }

        public abstract Race[] Races { get; }

        public abstract bool CanAcumulate { get;}

        public virtual AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.None;
            }
        }

        public virtual int StartLevel {
            get {
                return 1;
            }
        }

        public virtual bool CountsForFacilityLevel {
            get { return false; }
        }

        public bool IsAvailableToRace(Race race)
        {
            foreach (Race curr in Races) {
                if (curr == race || curr == Race.Global) {
                    return true;
                }
            }

            return false;
        }

        public virtual Result IsAvailable(IPlanetResource resource)
        {
            if (resource.State != ResourceState.UnAvailable) {
                return Result.Create(new ResourceAvailable());
            }
            return Result.Create( new ResourceNotAvailable() ) ;
        }

        public virtual void Init()
        {
        }

        public abstract Result IsUpgradeAvailable(IPlanetResource resource);

        public abstract Result IsBuildAvailable(IPlanet planet);

        public abstract Result CheckCost(IResourceOwner owner, IPlanetResource resource, int quantity);

        public int GetBuildDuration(IResourceOwner owner, IPlanetResource resource)
        {
            return RulesUtils.GetBuildDuration(owner, resource.Info, resource.Level, resource.Quantity);
        }

        public virtual int GetFixedBuildDuration(int level, int quantity)
        {
            return 0;
        }

        public virtual double GetBaseCostAttenuation(RuleArgs args, IIntrinsicInfo resource)
        {
            return 1;
        }

        public virtual int GetScore(int level, int quantity)
        {
            return 0;
        }

        public abstract bool IsBuildable { get;}

        public virtual void OnComplete(IPlanetResource resource)
        {
        }

        public virtual void OnDestroy(IPlanetResource resource)
        {
        }

        public virtual void ProcessCost(IPlanetResource resource)
        { 
        }

        public virtual void UndoCost(IPlanetResource resource)
        { 
        }

		public virtual bool IsDroppable {
			get { return false; }
    	}

		public virtual int DropRate {
			get { return 0; }
		}

        #endregion

        #region Other Members

        public string Identifier {
            get { return string.Format("{0}.{1}", Type, Name); }
        }

        #endregion Other Members

        #region IFactory Members

        public object create(object args)
        {
            return this;
        }

        #endregion

    };

}
