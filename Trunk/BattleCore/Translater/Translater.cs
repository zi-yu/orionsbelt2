using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore.Translate {
	public class Translater {

		#region Fields

		private readonly Dictionary<string, ITranslate> translaters = new Dictionary<string, ITranslate>();
		private readonly char[] separator = new char[] { ';' };
		private readonly FinalStateTranslater finalStateTranslater;
		private readonly IBattlePlayer player;

		#endregion Fields

		#region Private

		private string GenericTranslation( string movements, bool toSpecific ) {
			if( player.PlayerNumber == 0 ) {
				return movements;
			}

			StringBuilder builder = new StringBuilder();
			string[] finalStateSplitted = movements.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			foreach( string s in finalStateSplitted ) {
				string[] state = s.Split(':');
				string finalStateTranslated;
				if( toSpecific ) {
					finalStateTranslated = translaters[state[0]].TranslateToSpecific(state[1]);
				}else {
					finalStateTranslated = translaters[state[0]].TranslateToBase(state[1]);
				}
				builder.AppendFormat("{0}:{1};", state[0], finalStateTranslated);
			}
			return builder.ToString();
		}

		#endregion

		#region Public

		/// <summary>
		/// Translates all the final States
		/// </summary>
		/// <param name="finalState">Final states to translate</param>
		/// <returns>An array with all the final states translated</returns>
		public string[] TranslateFinalState( string[] finalState ) {
			if( player.PlayerNumber == 0 ) {
				return finalState;
			}

			List<string> moves = new List<string>();

			foreach( string move in finalState ) {
				StringBuilder builder = new StringBuilder();
				string[] finalStateSplitted = move.Split(separator, StringSplitOptions.RemoveEmptyEntries);

				foreach( string s in finalStateSplitted ) {
					string[] state = s.Split(':');
					string finalStateTranslated = finalStateTranslater.Translate(state[1]);
					builder.AppendFormat("{0}:{1};", state[0], finalStateTranslated);
				}

				moves.Add(builder.ToString());
			}

			return moves.ToArray();

		}

		/// <summary>
		/// Translates all the movements
		/// </summary>
		/// <param name="movements">Movements to translate</param>
		/// <returns>An array with all the movements translated</returns>
		public string[] TranslateAllMovements( string[] movements ) {
			if( player.PlayerNumber == 0 ) {
				return movements;
			}

			List<string> moves = new List<string>();

			foreach (string move in movements) {
				moves.Add(TranslateMovements(move));
			}

			return moves.ToArray();
		}

		/// <summary>
		/// Translates a set of movements
		/// </summary>
		/// <param name="movements">Set of movements to translate</param>
		/// <returns>The movements translated</returns>
		public string TranslateMovements( string movements ) {
			return GenericTranslation(movements, true);
		}

		/// <summary>
		/// Translates a set of movements to store in the database
		/// </summary>
		/// <param name="movements">Set of movements to translate</param>
		/// <returns>The movements translated</returns>
		public string TranslateMovementsToStore( string movements ) {
			return GenericTranslation(movements, false);
		}

		#endregion Public

		#region Constructor

		public Translater( IBattlePlayer player ) {
			this.player = player;
			translaters["m"] = new MoveTranslater(player);
			translaters["bk"] = new MoveTranslater(player);
			translaters["r"] = new RotationTranslater(player);
			translaters["b"] = new BattleTranslater(player);
			translaters["e"] = new EggTranslater(player);
			finalStateTranslater = new FinalStateTranslater(player);
		}

		#endregion Constructor
	}
}
