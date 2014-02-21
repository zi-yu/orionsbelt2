using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class AddRareToModifier : IRule  {

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
            return false;
        }

        public bool IsForLevel(int level)
        {
            return level % 2 == 1;
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

            IResourceInfo rare = RulesUtils.GetRandomRareResource(args.Planet.RaceInformation);

            if (resource.Level % 2 == 1) {
                owner.AddToModifier(rare, factor);
            }
        }

        public void Undo(RuleArgs args)
        {
            ProcessLogic(args, -1);
        }

        #endregion

        #region Static Utils

        internal static void Add(IResourceWithRulesInfo owner)
        {
            AddRareToModifier adder = new AddRareToModifier();
            owner.Rules.Register(adder);
        }

        #endregion Static Utils

        #region ToString

        public override string ToString()
        {
            return "Add Random Rare To Modifier";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int level)
        {
            return translator.Translate(GetType().Name);
        }

        #endregion ToString

    };
}
