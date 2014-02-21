using System;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class BattleUtils {

		#region Fields

		private readonly BattleInfo battleInfo;
		private static readonly Random random = new Random((int)DateTime.Now.Ticks);
		
		#endregion Fields

		#region Private

		/// <summary>
		/// Gets the unit value of all the units in the board, and afects the owner of
		/// each unit with that value
		/// </summary>
		/// <returns>The total value of the board</returns>
		private int GetBoardUnitValue() {
			int total = 0;
			foreach( IElement element in battleInfo.Board.Values ) {
				if( element.Unit is Flag ) {
					continue;
				}
				int unitValue = element.Unit.GetFinalUnitValue(element.Owner, battleInfo.BattleStatistics);
				int unitTotalValue = unitValue * element.Quantity;
				element.Owner.VictoryPercentage += unitTotalValue;
				total += unitTotalValue;
			}
			return total;
		}

		/// <summary>
		/// Gets the unit value of all the units in the initialContainer, and afects the owner of
		/// each unit with that value. The unit value is only retrieved if the owner hasn't positioned.
		/// </summary>
		/// <returns>The total value of the initial container</returns>
		private int GetInitialContainerTotalValue() {
			int total = 0;
			foreach( BattlePlayer battlePlayer in battleInfo.Players ) {
				if(!battlePlayer.HasPositioned) {
					foreach( IElement element in battlePlayer.InitialContainer.InitialUnits ) {
						int unitValue = element.Unit.GetFinalUnitValue(element.Owner, battleInfo.BattleStatistics);
						int unitTotalValue = unitValue * element.Quantity;
						element.Owner.VictoryPercentage += unitTotalValue;
						total += unitTotalValue;
					}
				}
			}
			return total;
		}

		#endregion

		#region Initial Loading

		/// <summary>
		/// Loads the initial containers and finds out which is the
		/// index of the current player (affects current id).
		/// </summary>
		internal void LoadPlayerInformation() {
			int i = 0;
			foreach( PlayerBattleInformation playerBattleInformation in battleInfo.Battle.PlayerInformation ) {
				IPositionConversion positionConversion = battleInfo.GetPositionConverters(i);
				IBattleOwner owner = battleInfo.GetBattleOwner(playerBattleInformation);
				IBattlePlayer battlePlayer = new BattlePlayer(playerBattleInformation, positionConversion, i, owner, battleInfo);
				battleInfo.Players.Add(battlePlayer);
				if( battleInfo.Battle.CurrentPlayer == battlePlayer.Owner.Id ) {
					battleInfo.CurrentBattlePlayer = battlePlayer;
					battlePlayer.IsTurn = true;
				}
				battleInfo.BattleStatistics.AddPlayer(battlePlayer);
				++i;
			}
		}

		/// <summary>
		/// Loads the last state of the battle
		/// </summary>
		/// <param name="finalState"></param>
		internal void LoadFinalState( string finalState ) {
			string[] finalStateSplitted = finalState.Split(';');
			foreach( string rawData in finalStateSplitted ) {
				if( rawData.Length == 0 ) {
					continue;
				}

				string[] data = rawData.Split(':');
				IElement element = ElementParser.ParseElement(data[1]);
				element.Owner = battleInfo.Players[int.Parse(data[0])];

				battleInfo.Board.Add(element.Coordinate, element);
				battleInfo.BattleStatistics.Add(element.Owner, element);
			}
		}

		/// <summary>
		/// Loads the information from the board into the container
		/// </summary>
		internal void LoadBoard() {
			string[] battleFinalStates = battleInfo.Battle.BattleExtension[0].BattleFinalStates.Split('|');
			if( battleFinalStates.Length > 0 ) {
				string finalState = battleFinalStates[battleFinalStates.Length - 1];
				if( finalState.Length > 0 ) {
					LoadFinalState(finalState);
				}
			}
		}

		/// <summary>
		/// Load the terrain for the battle
		/// </summary>
		internal void LoadTerrain() {
			battleInfo.Terrain = (Terrain) Enum.Parse(typeof(Terrain), battleInfo.Battle.Terrain, true);
		}

		/// <summary>
		/// Calculate the percentage of victory of the player
		/// </summary>
		internal void CalculatePercentage() {
			double total = GetBoardUnitValue();
			total += GetInitialContainerTotalValue();
			
			foreach( BattlePlayer battlePlayer in battleInfo.Players ) {
				double result = (battlePlayer.VictoryPercentage / total) +0.005d;
				battlePlayer.VictoryPercentage = (int)(result * 100);
			}
		}

		/// <summary>
		/// Calculates the score of all the players. We have to Update the score of
		/// all the players because it might have occured a strike back.
		/// </summary>
		internal void CalculateScore() {
			battleInfo.Score.SetPlayersScore(battleInfo.Players);
		}

		#endregion Initial Loading

		#region Final Persistance

		/// <summary>
		/// Updates the initial container information
		/// </summary>
		internal void UpdatePlayerBattleInformation() {
			for( int i = 0; i < battleInfo.Players.Count; ++i ) {
				IBattlePlayer player = battleInfo.Players[i];
				player.UpdatePlayerBattleInfo();
			}
		}

		/// <summary>
		/// Updates the board with the new Information
		/// </summary>
		internal void UpdateBattleBoard() {
			StringBuilder builder = new StringBuilder();
			foreach( IElement element in battleInfo.Board.Values ) {
				string eStr = element.ToString();
				if( eStr.Length != 0 ) {
					builder.AppendFormat("{0}:{1};", element.Owner.PlayerNumber, eStr);
				}
			}

			if( battleInfo.Battle.BattleExtension[0].BattleFinalStates.Length == 0 ) {
				battleInfo.Battle.BattleExtension[0].BattleFinalStates = builder.ToString();
			} else {
				battleInfo.Battle.BattleExtension[0].BattleFinalStates = string.Format("{0}|{1}", battleInfo.Battle.BattleExtension[0].BattleFinalStates, builder);
			}
		}

		/// <summary>
		/// Loads Miscellaneous battle information
		/// </summary>
		internal void LoadMisc() {
		    battleInfo.IsTeamBattle = battleInfo.Battle.IsTeamBattle;
		    battleInfo.IsDeployTime = battleInfo.Battle.IsDeployTime;
			battleInfo.BattleMode = (BattleMode)Enum.Parse(typeof (BattleMode), battleInfo.Battle.BattleMode);

			if( !string.IsNullOrEmpty(battleInfo.Battle.TournamentMode) ) {
				battleInfo.TournamentMode = (TournamentMode) Enum.Parse(typeof(TournamentMode), battleInfo.Battle.TournamentMode);	
			}
		}

		#endregion Final Persistance

		#region Give Up

		public void GiveUp(IBattlePlayer player) {
			battleInfo.RemovePlayerUnits(player);
			player.HasGaveUp = true;
			if( player.LoseScore > 0 ) {
				player.LoseScore /= 2;
			}


		}

		#endregion Give Up

		#region Constructor

		public BattleUtils( BattleInfo battleInfo ) {
			this.battleInfo = battleInfo;
		}

		#endregion Constructor

	}
}