using System;
using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel1")]
	public class WormHoleLevel1 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel1 instance = new WormHoleLevel1();

		#endregion Fields

		#region Public

        public override int Cooldown{
            get { return 10; }
        }

		public override int Duration {
            get { return 1; }
		}

        public override bool CanPass(IPlayer owner, IPlayer playerToPass) {
            return owner.Id == playerToPass.Id;
        }

		public override object create(object args) {
			return instance;
		}

		#endregion Public

        #region Contructor

        public WormHoleLevel1() {
            intrinsicResources = 200;
            rareResources = 50;
        }

        #endregion Contructor

    }
}
