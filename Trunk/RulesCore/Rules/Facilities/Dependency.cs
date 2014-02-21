using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class Dependency : IFacilityRule {

        #region IRule Members

        public ResourceState TargetState {
            get { return ResourceState.UnAvailable; }
        }

        public ResourceState NextState {
            get { return ResourceState.Available; }
        }

        public bool IsGlobal {
            get { return false; }
        }

        public int TargetLevel {
            get { return FacilityLevel; }
        }

        public bool AppliesToArgs(RuleArgs args)
        {
            return args.TargetLevel == TargetLevel;
        }

        public bool UndoAppliesToArgs(RuleArgs args)
        {
            return false;
        }

        public bool IsForLevel(int level)
        {
            return level == TargetLevel;
        }

        public Result CanProcess(RuleArgs args)
        {
            IResourceOwner planet = args.ResourceOwner;
            if (!IsResourceRunning(planet)) {
                return Result.Create(new DependencyFacilityNotRunningResult(FacilityDependency.Name));
            }
            bool available = planet.HasResourceLevel(FacilityDependency, FacilityDependencyLevel);
            return Result.Create(new DependencyResult(FacilityDependency.Name, FacilityDependencyLevel, available));
        }

        private bool IsResourceRunning(IResourceOwner planet)
        {
            foreach (IPlanetResource resource in planet.GetResources(FacilityDependency)) {
                if (resource.State == ResourceState.Running) {
                    return true;
                }
            }
            return false;
        }

        public void Process(RuleArgs args)
        {
        }

        public void Undo(RuleArgs args)
        {
        }

        #endregion

        #region Properties

        private IResourceWithRulesInfo facilityInfo;

        public IResourceWithRulesInfo FacilityInfo
        {
            get { return facilityInfo; }
            set { facilityInfo = value; }
        }

        private int facilityLevel;

        public int FacilityLevel
        {
            get { return facilityLevel; }
            set { facilityLevel = value; }
        }

        private IResourceWithRulesInfo facilityDependency;

        public IResourceWithRulesInfo FacilityDependency
        {
            get { return facilityDependency; }
            set { facilityDependency = value; }
        }

        private int facilityDependencyLevel;

        public int FacilityDependencyLevel
        {
            get { return facilityDependencyLevel; }
            set { facilityDependencyLevel = value; }
        }

        #endregion Properties

        #region ToString

        public override string ToString()
        {
            return string.Format("Level {0} Dependency: {1} level {2}", FacilityLevel, FacilityDependency.Name, FacilityDependencyLevel);
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int targetLevel)
        {
            return string.Format("<a href='{2}'>{0}</a> {3} {1}", 
                        translator.Translate(FacilityDependency.Name), 
                        FacilityDependencyLevel,
                        ManualUtils.GetUrlOnResourcePage(FacilityDependency),
                        translator.Translate("Level")
                    );
        }

        #endregion ToString

        #region Static Utils

        internal static void Add(IResourceWithRulesInfo info, int targetFacilityLevel, Type buildingDependency, int buildingDependencyLevel)
        {
            Dependency dependency = new Dependency();

            dependency.FacilityInfo = info;
            dependency.FacilityLevel = targetFacilityLevel;
            dependency.FacilityDependency = RulesUtils.GetFacility(buildingDependency);
            dependency.FacilityDependencyLevel = buildingDependencyLevel;

            info.Rules.Register(dependency);
        }

        internal static void Add(IResourceWithRulesInfo info, int targetFacilityLevel, Type buildingDependency, int buildingDependencyLevel, int maxLevel)
        {
            for(int i = targetFacilityLevel; i <= maxLevel && buildingDependencyLevel <= maxLevel; ++i)
            {
                Add(info, i, buildingDependency,  buildingDependencyLevel++);
            }
        }

        public static Dependency Get(Type info, int targetFacilityLevel, Type buildingDependency, int buildingDependencyLevel)
        {
            Dependency dependency = new Dependency();

            dependency.FacilityInfo = RulesUtils.GetFacility(info);
            dependency.FacilityLevel = targetFacilityLevel;
            dependency.FacilityDependency = RulesUtils.GetFacility(buildingDependency);
            dependency.FacilityDependencyLevel = buildingDependencyLevel;

            return dependency;
        }

        #endregion Static Utils

    };
}
