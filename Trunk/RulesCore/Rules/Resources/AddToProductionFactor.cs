using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class AddToProductionFactor : IRule {

        #region Properties

        private int baseFactor;

        public int BaseFactor {
            get { return baseFactor; }
            set { baseFactor = value; }
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
            return args.NextState == NextState;
        }

        public bool UndoAppliesToArgs(RuleArgs args)
        {
            return args.PlanetResource.State == ResourceState.Destroyed;
        }

        public bool IsForLevel(int level)
        {
            return true;
        }
        
        public void Process(RuleArgs args)
        {
            ProcessLogic(args, 1);
        }

        private void ProcessLogic(RuleArgs args, int factor)
        {
            IPlanet planet = args.Planet;

            if (planet == null) {
                throw new RulesException("Can't process without planet");
            }

            planet.ProductionFactor += ByLevelIncrement * BaseFactor * factor;
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

        internal static void Add(IResourceWithRulesInfo owner, int baseFactor)
        {
            AddToProductionFactor adder = new AddToProductionFactor();
            adder.BaseFactor = baseFactor;
            owner.Rules.Register(adder);
        }

        public const double ByLevelIncrement = 0.5;

        #endregion Static Utils

        #region ToString

        public override string ToString()
        {
            return "Add To ProductionFactor";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int level)
        {
            return string.Format("{2}{0} {1}",
                    ByLevelIncrement,
                    translator.Translate("ProductionFactor"),
                    BaseFactor < 0 ? "-" : "+"
                );
        }

        #endregion ToString

    };
}
