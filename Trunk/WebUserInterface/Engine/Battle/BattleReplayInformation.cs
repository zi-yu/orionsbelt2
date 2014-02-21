using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.WebBattle {
	
	public class BattleReplayInformation {

		#region Fields

		private readonly string battleFinalState;
		private string movesList;
		private readonly string finalStatesIndexes;
		protected static readonly char[] separator = new char[] { ';' };
        protected static readonly string emptyArray = "[]";

		#endregion Fields

		#region Private

		private static string GetJsonStringArray( string[] array, int startIdx ) {
            if( array.Length != 0 ) {
			    StringBuilder builder = new StringBuilder();

			    builder.AppendFormat("['{0}'", array[startIdx]);
			    for( int i = startIdx + 1; i < array.Length; ++i ) {
				    builder.AppendFormat(",'{0}'", array[i]);
			    }
			    builder.Append("]");

			    return builder.ToString();
            }
            return emptyArray;
		}

		private static string GetJsonArray( string[] array ) {
            if (array.Length != 0) {
                StringBuilder builder = new StringBuilder();

                builder.AppendFormat("[{0}", array[0]);
                for (int i = 1; i < array.Length; ++i) {
                    builder.AppendFormat(",{0}", array[i]);
                }
                builder.Append("]");

                return builder.ToString();
            }
            return emptyArray;
		}

		private static string GetJsonFinalStateIndexes( IEnumerable<string> finalStates ) {
			List<string> indexes = new List<string>();

			int count = 0;
			foreach( string s in finalStates ) {
				string[] occurs = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				indexes.Add(string.Format("{{ start:{0},count:{1} }}", count, occurs.Length));
				count += occurs.Length;
			}

			return GetJsonArray(indexes.ToArray());
		}

        private void GetMovesList(IBattleInfo battleInfo, IBattlePlayer battlePlayer){
	        string[] s = battleInfo.GetMovesList(battlePlayer);
            if (s.Length == 0 || (s.Length == 1 && s[0].Length == 0) ){
                movesList = "[]";
            }else{
	            if(s.Length > 0 && s[0].Length == 0) {
	                movesList = GetJsonStringArray(s, 1);
	            }else {
	                movesList = GetJsonStringArray(s, 0);
	            }
            }
	    }

		#endregion

		#region Public

		/// <summary>
		/// Get's the final states of the battle in Json Format
		/// </summary>
		public string BattleFinalState {
			get { return battleFinalState; }
		}

		/// <summary>
		/// Get's all the movements of the battle in Json Format
		/// </summary>
		public string MovesList {
			get { return movesList; }
		}

		/// <summary>
		/// Get's an array with the number of movements per turn in Json Format
		/// </summary>
		public string MovesIndexes {
			get { return finalStatesIndexes; }
		}

		#endregion Public

		#region Constructor

		public BattleReplayInformation(IBattleInfo battleInfo,IBattlePlayer battlePlayer) {
			GetMovesList(battleInfo, battlePlayer);

		    string[] finalStates = battleInfo.GetFinalStates(battlePlayer);
			battleFinalState = GetJsonStringArray(finalStates, battleInfo.NumberOfPlayers - 1);
			finalStatesIndexes = GetJsonFinalStateIndexes(finalStates);
		}

	    

	    #endregion Constructor
	}
}
