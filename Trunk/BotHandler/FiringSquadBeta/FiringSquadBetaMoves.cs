using System;

namespace BotHandler.Engine {
	public class FiringSquadBetaMoves : Moves {

		#region Fields

		protected static FiringSquadBetaMoves instance = new FiringSquadBetaMoves();

		#endregion Fields

		#region Properties

		public static Moves Instance {
			get { return instance; }
		}

		#endregion Properties
	
		#region Public

		public override void MakeMoves(Battle battle) {
            SimpleElement[,] start = battle.GetSimpleRepresentation();
			Bot001Calculator movesCalculator = new Bot001Calculator(battle.Turn, battle.Terrain);
                       
            MakeMoves(battle, movesCalculator.Calculate(start));
		}

		#endregion Public

		#region Constructor

		private FiringSquadBetaMoves() {
        	botName = "FiringSquadBeta";
        }

        #endregion Constructor


	}
}
