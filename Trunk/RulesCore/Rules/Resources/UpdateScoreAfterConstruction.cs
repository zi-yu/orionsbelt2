using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.RulesCore.Rules {

    public class UpdateScoreAfterConstruction : IRule  {

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
            return args.PlanetResource.State == ResourceState.Destroyed;
        }

        public bool IsForLevel(int level)
        {
            return true;
        }

        public void Process(RuleArgs args)
        {
            IPlanet planet = args.Planet;
            IPlayer owner = args.Player;
            IPlanetResource resource = args.PlanetResource;

            if (planet == null || owner == null || null == resource)
            {
                throw new RulesException("Can't process without resource and owner");
            }

            int score = resource.Info.GetScore(resource.Level, 1);
            planet.Score += score;
            owner.Score += score;
        }

        public void Undo(RuleArgs args)
        {
            IPlanet planet = args.Planet;
            IPlayer owner = args.Player;
            IPlanetResource resource = args.PlanetResource;

            if (planet == null || owner == null || null == resource)
            {
                throw new RulesException("Can't process without resource and owner");
            }

            int score = resource.Info.GetScore(resource.Level, 1);
            planet.Score -= score;
            owner.Score -= score;
        }

        #endregion

        #region Static Utils

        private static UpdateScoreAfterConstruction instance = new UpdateScoreAfterConstruction();

        internal static void Add(IResourceWithRulesInfo info)
        {
            info.Rules.Register(instance);
        }

        #endregion Static Utils

        #region ToString

        public override string ToString()
        {
            return "Make Score Available";
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info,
                               int level)
        {
            int score = info.GetScore(level, 1);
            if (score == 0) {
                return string.Empty;
            }
            return string.Format("+{0} {1}",
                    score,
                    translator.Translate("ToScore")
                );
        }


        #endregion ToString

    };
}
