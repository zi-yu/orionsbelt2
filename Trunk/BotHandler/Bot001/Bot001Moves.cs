using System;

namespace BotHandler.Engine {
	public class Bot001Moves : Moves {

		#region Fields

		protected static Bot001Moves instance = new Bot001Moves();

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

		private Bot001Moves() {
        	botName = "Bot001";
        }

        #endregion Constructor


	}
}
