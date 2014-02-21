using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IBattleInfo {

		/// <summary>
		/// Id of the battle
		/// </summary>
		int Id { get; }

		/// <summary>
		/// Terrain information
		/// </summary>
		Terrain Terrain { get; set; }

		/// <summary>
		/// Current Turn
		/// </summary>
		int CurrentTurn { get; }

        /// <summary>
        /// Has end with a give up
        /// </summary>
        bool HasGiveUp { get; set; }

		/// <summary>
		/// Number of player of this battle
		/// </summary>
		int NumberOfPlayers { get; }

        /// <summary>
        /// True if this battle was placed on a planet
        /// </summary>
		bool IsBattleInPlanet { get;}

        /// <summary>
        /// True if this battle was placed on a planet and was meatn for pillage
        /// </summary>
        bool IsPlanetPillage { get;}

		/// <summary>
		/// Gets the initial container from the Player to play
		/// </summary>
		IInitialContainer InitialContainer { get; }

		/// <summary>
		/// Discovers the current player and returns true if it 
		/// is it's time to position his units
		/// </summary>
		bool IsDeployTime {get;set;}

		/// <summary>
		/// Unit Statistics
		/// </summary>
		IBattleStatistics BattleStatistics {get;}

		/// <summary>
		/// Object that handles the score
		/// </summary>
		IScore Score {get;}

		/// <summary>
		/// Mode of the battle
		/// </summary>
		BattleMode BattleMode {get;set;}

		/// <summary>
		/// Mode of the tournament
		/// </summary>
		TournamentMode TournamentMode { get;set;}

		/// <summary>
		/// Current player
		/// </summary>
		IBattlePlayer CurrentBattlePlayer {get;set;}

		/// <summary>
		/// List of the Players of this battle
		/// </summary>
		List<IBattlePlayer> Players {get;set;}

		/// <summary>
		/// returns true if all players have positioned their units
		/// </summary>
		bool AllPlayersPositioned {get;}

		/// <summary>
		/// Checks if the fleets need to be updated
		/// </summary>
		bool UpdateFleets {get;}

		/// <summary>
		/// Timeouts Allowed
		/// </summary>
		int TimeoutsAllowed {get;}

		/// <summary>
		/// Checks if the players already positioned and the battle hasn't ended
		/// </summary>
		bool IsInBattle {get;}

		/// <summary>
		/// Type of the battle
		/// </summary>
		BattleType BattleType {get;set;}

	    /// <summary>
	    /// Is the battle a team battle
	    /// </summary>
	    bool IsTeamBattle {
	        get;
	        set;
	    }

		/// <summary>
		/// Messages a player generates during a play. This container is supposed to 
		/// be empty except when a battleinfo is loaded to make a move
		/// </summary>
		List<BattleMessage> TurnMessages {
			get;
		}

		/// <summary>
		/// Object that represents the battle in the Database
		/// </summary>
		Battle Battle {
			get;
		}

		/// <summary>
		/// Get's the element in the sector src
		/// </summary>
		/// <param name="src">Sector where to get the unit</param>
		/// <returns>IElement with the information</returns>
		IElement SectorGetElement(IBattleCoordinate src);

		/// <summary>
		/// Get's the element in the sector src WITHOUT coordinate tranlation
		/// </summary>
		/// <param name="src">Sector where to get the unit</param>
		/// <returns>IElement with the information</returns>
		IElement SectorRawGetElement(IBattleCoordinate src);

		/// <summary>
		/// Removes the element in the sector src
		/// </summary>
		/// <param name="src">Sector where to remove the unit</param>
		void SectorRemoveElement( IBattleCoordinate src );

		/// <summary>
		/// Get's the element in the sector src
		/// </summary>
		/// <param name="coord">Sector to test</param>
		/// <returns>True if a element from the enemy exists</returns>
		bool SectorHasElement( IBattleCoordinate coord );

		/// <summary>
		/// Get's the element in the sector src WITHOUT coordinate translation
		/// </summary>
		/// <param name="coord">Sector to test</param>
		/// <returns>True if a element from the enemy exists</returns>
		bool SectorRawHasElement( IBattleCoordinate coord );

		/// <summary>
		/// Moves a unit from the source into a coordinate
		/// </summary>
		/// <param name="element">Element that represents the unit in the source</param>
		/// <param name="quantity">Quanity to move</param>
		void SectorSrcMove(IElement element, int quantity);

		/// <summary>
		/// Moves the quantity passed of a unit from sector src to sector dst
		/// </summary>
		/// <param name="src">Source sector</param>
		/// <param name="dst">Destiny sector</param>
		/// <param name="quantity">Quantity to move</param>
		void SectorMove(IBattleCoordinate src, IBattleCoordinate dst, int quantity);

		/// <summary>
		/// Inserts a new element into the board
		/// </summary>
		/// <param name="element">Element to insert</param>
		void SectorInsertElement(IElement element);

		/// <summary>
		/// Resolves all the effects in each unit
		/// </summary>
		void ResolveEffects();

		/// <summary>
		/// Verifies if the battle has ended
		/// </summary>
		bool HasEnded();

		/// <summary>
		/// Updates the movements made and the next player to play
		/// </summary>
		/// <param name="movements"></param>
		void BattleFinalUpdate( string movements );

		/// <summary>
		/// Updates the initial container state, the state of the board
		/// </summary>
		/// <returns>Updated Battle Object</returns>
		Battle GetUpdatedBattle();

		/// <summary>
		/// Ends the battle
		/// </summary>
		void EndBattle();

		/// <summary>
		/// Terminate the player participation in the current battle
		/// </summary>
		void GiveUp( IBattleOwner battleOwner );

		/// <summary>
		/// Erases all units from the board that are owned by the passed player
		/// </summary>
		/// <param name="player">Player that has lost</param>
		void RemovePlayerUnits( IBattlePlayer player );

		/// <summary>
		/// Get's the board for the passed player
		/// </summary>
		/// <param name="player">Player to get the board from</param>
		/// <returns>Dictionar with the board</returns>
		Dictionary<string, IElement> GetBoard(IBattlePlayer player);

		/// <summary>
		/// Get's the board for the passed player
		/// </summary>
		/// <param name="currPlayer">Current Player</param>
		/// <param name="player">Player to get the board from</param>
		/// <returns>Dictionar with the board</returns>
		IElement GetUltimateUnit(IBattlePlayer currPlayer, IBattlePlayer player);

		/// <summary>
		/// Get's the board
		/// </summary>
		/// <returns>Dictionar with the board</returns>
		Dictionary<IBattleCoordinate, IElement> GetBoard();

		/// <summary>
		/// Get the player that correspond to the passed IBattleOwner
		/// </summary>
		/// <param name="battleOwner">Object that represents the user</param>
		/// <returns></returns>
		IBattlePlayer GetPlayer( IBattleOwner battleOwner );

		/// <summary>
		/// Get the player that correspond to the passed IBattleOwner
		/// </summary>
		/// <param name="ownerId">id of the user</param>
		/// <returns></returns>
		IBattlePlayer GetPlayer(int ownerId);

		/// <summary>
		/// Get the player that correspond to the passed IBattleOwner
		/// </summary>
		/// <param name="battleOwner">Object that represents the bot user</param>
		/// <returns></returns>
		IBattlePlayer GetPlayerByBotId(IBattleOwner battleOwner);

		/// <summary>
		/// Get the player that correspond to the passed IBattleOwner
		/// </summary>
		/// <param name="ownerId">id of the bot</param>
		/// <returns></returns>
		IBattlePlayer GetPlayerByBotId(int ownerId);

		/// <summary>
		/// Loads the initial state of the board into the container
		/// </summary>
		void LoadInitialState();

		/// <summary>
		/// Gets the all the final states of the battle
		/// </summary>
		/// <returns>A string array with all the final states</returns>
		string[] GetFinalStates( IBattlePlayer player );

		/// <summary>
		/// Gets the all the moves of the battle
		/// </summary>
		/// <returns>A string array with all the moves of the battle</returns>
		string[] GetMovesList( IBattlePlayer player );

		/// <summary>
		/// Sets the next player to play
		/// </summary>
		void SetNextPlayer();

		/// <summary>
		/// Updates the current player when it's position time
		/// </summary>
		/// <param name="battleOwner">Player that is positioning</param>
		void UpdateCurrentPlayer(IBattleOwner battleOwner);

		/// <summary>
		/// Final timeout of the current player
		/// </summary>
		void Timeout();

	    /// <summary>
	    /// Get's the winners
	    /// </summary>
	    /// <returns>List with the winners of the Battle</returns>
	    List<IBattlePlayer> GetBattlePlayerWinners();

		/// <summary>
		/// Get's the winners
		/// </summary>
		/// <returns>List with the winners of the Battle</returns>
		List<IBattleOwner> GetBattleOwnerWinners();

		/// <summary>
		/// Get's the losers
		/// </summary>
		/// <returns>List with the losers of the Battle</returns>
		List<IBattleOwner> GetBattleOwnerLosers();

		/// <summary>
		/// Clears all the messages
		/// </summary>
		void RemoveAllMessages();

		/// <summary>
		/// Adds a message related to the current play
		/// </summary>
		/// <param name="message">Message to add</param>
		void AddTurnMessage( BattleMessage message );

		/// <summary>
		/// Gets the number of units of the passed player
		/// </summary>
		/// <param name="player">Player to count the units</param>
		/// <returns>Number of units of the passed player</returns>
		int GetTotalUnitQuantity(IBattlePlayer player);


	}
}
