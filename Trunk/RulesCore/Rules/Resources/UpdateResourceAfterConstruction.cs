using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class UpdateResourceAfterConstruction : IRule  {

        #region Properties

        #endregion Properties

        #region IRule Members

        public ResourceState TargetState {
            get { return ResourceState.Complete; }
        }

        public ResourceState NextState {
            get { return ResourceState.Running; }
        }

        public bool IsGlobal {
            get { return true; }
        }

        public Result CanProcess(RuleArgs args)
        {
            return Result.Success;
        }

        public bool AppliesToArgs(RuleArgs args)
        {
            return args.NextState == ResourceState.Running;
        }

        public bool UndoAppliesToArgs(RuleArgs args)
        {
            return false;
        }

        public bool IsForLevel(int level)
        {
            return true;
        }

        public void Process(RuleArgs args)
        {
            ProcessLogic(args, 1);
        }

        private static void ProcessLogic(RuleArgs args, int factor)
        {
            IPlanetResource resource = args.PlanetResource;
            IResourceOwner owner = args.ResourceOwner;

            if (resource == null || owner == null) {
                throw new RulesException("Can't process without resource and owner");
            }

            if (!RulesUtils.IsUpgrade(resource)) {
                int quantity = resource.Quantity;
                if (resource.Info.Type == ResourceType.Facility) {
                    resource.Quantity = 1;
                    resource.Level = 1;
                    resource.State = ResourceState.Running;
                } else {
                    owner.AddQuantity(resource.Info, quantity * factor);
                    resource.State = ResourceState.Deleted;
                }
            } else {
                resource.Quantity = 1;
                resource.State = ResourceState.Running;
            }

            if (resource.Info.CountsForFacilityLevel && resource.Level > args.Planet.FacilityLevel) {
                args.Planet.FacilityLevel = resource.Level;
            }
        }

        public void Undo(RuleArgs args)
        {
        }

        #endregion

        #region Static Utils

        private static UpdateResourceAfterConstruction instance = new UpdateResourceAfterConstruction();

        internal static void Add(IResourceWithRulesInfo info)
        {
            info.Rules.Register(instance);
        }

        #endregion Static Utils

        #region ToString

        public override string ToString()
        {
            return "Make Resource Available";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int targetLevel)
        {
            return string.Empty;
        }

        #endregion ToString

    };
}
