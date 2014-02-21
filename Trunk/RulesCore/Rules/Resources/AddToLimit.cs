using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class AddToLimit : IRule  {

        #region Properties

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private int level = 0;

        public int Level
        {
            get { return level; }
            set { level = value; }
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
            return Result.Success;
        }

        public bool AppliesToArgs(RuleArgs args)
        {
            if (args.PlanetResource == null) {
                return false;
            }
            return IsForLevel(args.PlanetResource.Level) && args.NextState == NextState;
        }

        public bool UndoAppliesToArgs(RuleArgs args)
        {
            return args.PlanetResource.State == ResourceState.Destroyed;
        }

        public bool IsForLevel(int level)
        {
            if (Level < 1) {
                return true;
            }
            return Level == level;
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
            if (Level > 0) {
                args.Player.AddToLimit(null, Quantity * factor);
            } else {
                args.Player.AddToLimit(null, LimitByLevel(resource.Level) * factor);
            }
        }

        public void Undo(RuleArgs args)
        {
            for (int i = 1; i < args.PlanetResource.Level + 1; ++i) {
                args.PlanetResource.Level = i;
                ProcessLogic(args, -1);
            }
        }

        #endregion

        #region Static Utils

        public int LimitByLevel(int level)
        {
            if (Level > 0) {
                return Quantity;
            }
            return (int)Math.Ceiling(180 * Math.Pow(level, 2)) - (int)Math.Ceiling(180 * Math.Pow(level-1, 2));
        }

        internal static void Add(IResourceWithRulesInfo owner)
        {
            AddToLimit adder = new AddToLimit();
            owner.Rules.Register(adder);
        }

        internal static void Add(IResourceWithRulesInfo owner, int quantity)
        {
            for(int iter = 1; iter <= 10; ++iter)
            {
                Add(owner, quantity, iter);
            }
        }

        internal static void Add(IResourceWithRulesInfo owner, int quantity, int level)
        {
            AddToLimit adder = new AddToLimit();

            adder.Quantity = quantity;
            adder.Level = level;

            owner.Rules.Register(adder);
        }

        #endregion Static Utils

        #region ToString

        public override string ToString()
        {
            return "Add To Limit";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int level)
        {
            return string.Format("+{0} {1}",
                    LimitByLevel(level),
                    translator.Translate("LimitOf")
                );
        }

        #endregion ToString

    };
}
