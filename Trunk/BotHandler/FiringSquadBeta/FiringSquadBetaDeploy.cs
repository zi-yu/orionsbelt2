namespace BotHandler.Engine {
    public class FiringSquadBetaDeploy : Deploy{

		#region Fields

		protected static Deploy instance = new FiringSquadBetaDeploy();
        
		#endregion Fields

		#region Properties

		public static Deploy Instance {
			get { return instance; }
		}

		#endregion Properties

        #region Public

        public override void MakeDeploy(Battle battle) {
        	string deploy = FiringSquadDeploy.GetFiringSquadDeploy(battle);
			MakeDeploy(battle,deploy);
		}

		#endregion Public

        #region Constructor

		protected FiringSquadBetaDeploy() {
			botName = "FiringSquadBeta";
        }
        
        #endregion Constructor

    }
}
