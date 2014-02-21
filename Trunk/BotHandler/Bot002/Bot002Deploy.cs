namespace BotHandler.Engine {
	public class Bot002Deploy : Bot001Deploy {

		#region Constructor

        private Bot002Deploy() {
        	botName = "Bot002";
        }

		static Bot002Deploy(){
            instance = new Bot002Deploy();

        }
    
        #endregion Constructor

    }
}
