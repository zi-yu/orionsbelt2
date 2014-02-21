using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class AddToModifier : IRule  {

        #region Properties

        private IResourceInfo info;

        public IResourceInfo Info
        {
            get { return info; }
            set { info = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private int levelFilter = 0;

        public int LevelFilter
        {
            get { return levelFilter; }
            set { levelFilter = value; }
        }

        #endregion Properties

        #region IRule Members

        public ResourceState TargetState {
            get { return ResourceState.Complete; }
        }

        public ResourceState NextState {
            get { return ResourceState.Running; }
        }

        public bool IsGlobal {
            get { return false; }
        }

        public Result CanProcess(RuleArgs args)
        {
            return Result.Ignore;
        }

        public bool AppliesToArgs(RuleArgs args)
        {
            return args.NextState == NextState;
        }

        public bool UndoAppliesToArgs(RuleArgs args)
        {
            return args.PlanetResource.State == ResourceState.Destroyed;
        }

        public bool IsForLevel(int level)
        {
            return level > LevelFilter;
        }

        public void Process(RuleArgs args)
        {
            ProcessLogic(args, 1);
        }

        private void ProcessLogic(RuleArgs args, int factor)
        {
            IPlanetResource resource = args.PlanetResource;
            IModifierHandler owner = args.ResourceOwner as IModifierHandler;

            if (resource == null || owner == null) {
                throw new RulesException("Can't process without resource and owner");
            }

            if (IsForLevel(resource.Level)) {
                owner.AddToModifier(Info, ModifierByLevel(Quantity, resource.Level) * factor);
            }
        }

        public void Undo(RuleArgs args)
        {
            ProcessLogic(args, -1);
        }

        #endregion

        #region Static Utils

        public int ModifierByLevel(int quantity, int level)
        {
            return 1;
        }

        internal static void Add(IResourceWithRulesInfo owner, IResourceInfo info, int quantity)
        {
            Add(owner, info, quantity, -1);
        }

        internal static void Add(IResourceWithRulesInfo owner, IResourceInfo info, int quantity, int levelFilter)
        {
            AddToModifier adder = new AddToModifier();

            adder.Info = info;
            adder.Quantity = quantity;
            adder.LevelFilter = levelFilter;

            owner.Rules.Register(adder);
        }

        internal static void Add(IResourceWithRulesInfo owner, int quantity)
        {
            foreach (IResourceInfo info in RulesUtils.GetIntrinsicNonConceptualResources()) {
                if (!info.IsRare) {
                    Add(owner, info, quantity);
                }
            }
        }

        #endregion Static Utils

        #region ToString

        public override string ToString()
        {
            return "Add To Modifier";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int level)
        {
            if (!IsForLevel(level)) {
                return string.Empty;
            }
            return string.Format("+{0} <a href='{2}'>{1}</a> {3}",
                    ModifierByLevel(Quantity, level),
                    translator.Translate(Info.Name),
                    ManualUtils.GetUrlOnResourcePage(Info),
                    translator.Translate("PerTick")
                );
        }

        #endregion ToString

    };
}
