using System;
using DesignPatterns;
using OrionsBelt.BattleCore.Translate;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public abstract class BattleInfo : IBattleInfo, IFactory {

		#region Fields

		protected static Dictionary<int, List<IPositionConversion>> positionConverters = new Dictionary<int, List<IPositionConversion>>();
		private readonly static int GiveUpLoseDivider = 2;

		protected IBattle battle;
		protected BattleType battleType;
		protected BattleMode battleMode;
		protected TournamentMode tournamentMode;
		protected Dictionary<IBattleCoordinate, IElement> board = new Dictionary<IBattleCoordinate, IElement>();
		private readonly List<BattleMessage> turnMessages = new List<BattleMessage>();
		private List<IBattlePlayer> players = new List<IBattlePlayer>();
		protected IBattlePlayer currentPlayer;
		protected Terrain terrain;
		private readonly BattleUtils battleUtils;
		private readonly IBattleStatistics battleStatistics = new BattleStatistics();
		private readonly IScore score;
		private bool allPlayersPositioned = false;
        private bool isTeamBattle = false;
        private bool isDeployTime = false;
        private bool hasGiveUp = false;
		protected static readonly char[] separator = new char[] {'|'};

		#endregion Fields

		#region Properties

		/// <summary>
		/// Id of the battle
		/// </summary>
		public int Id {
			get { return Battle.Id; }
		}

		/// <summary>
		/// Current Turn
		/// </summary>
		public int CurrentTurn {
			get { return Battle.CurrentTurn; }
		}

	    public bool HasGiveUp
	    {
            get { return hasGiveUp; }
            set { hasGiveUp = value; }
	    }

	    /// <summary>
		/// Terrain information
		/// </summary>
		public Terrain Terrain {
			get { return terrain; }
			set { terrain = value; }
		}

		/// <summary>
		/// Object that represents the battle in the Database
		/// </summary>
		public Battle Battle {
			get { return battle.Storage; }
		}

		/// <summary>
		/// Type of the battle
		/// </summary>
		public BattleType BattleType {
			get { return battleType; }
			set { battleType = value; }
		}

		/// <summary>
		/// Mode of the battle
		/// </summary>
		public BattleMode BattleMode {
			get { return battleMode; }
			set { battleMode = value; }
		}

		/// <summary>
		/// Mode of the Tournament
		/// </summary>
		public TournamentMode TournamentMode {
			get { return tournamentMode; }
			set { tournamentMode = value; }
		}

		/// <summary>
		/// Current player
		/// </summary>
		public IBattlePlayer CurrentBattlePlayer {
			get { return currentPlayer; }
			set { currentPlayer = value; }
		}

		/// <summary>
		/// Timeouts Allowed
		/// </summary>
		public int TimeoutsAllowed {
			get { return Battle.TimeoutsAllowed; }
		}

		/// <summary>
		/// Object that converts the positions for the current player
		/// </summary>
		public IPositionConversion PositionConverter {
			get { return currentPlayer.PositionConverter; }
		}

		/// <summary>
		/// Gets the initial container from the Player to play
		/// </summary>
		public IInitialContainer InitialContainer {
			get { return currentPlayer.InitialContainer; }
		}

		/// <summary>
		/// Gets or sets the dictionary with the Game Board information
		/// </summary>
		public Dictionary<IBattleCoordinate, IElement> Board {
			get { return board; }
			set { board = value; }
		}

		/// <summary>
		/// Discovers the current player and returns true if it 
		/// is it's time to position his units
		/// </summary>
		public bool IsDeployTime {
            get { return isDeployTime; }
            set { isDeployTime = value; }
		}

		/// <summary>
		/// returns true if all players have positioned their units
		/// </summary>
		public bool AllPlayersPositioned {
			get {
				if( allPlayersPositioned ) {
					return true;
				}

				foreach (IBattlePlayer player in players ) {
					if( !player.HasPositioned ) {
						return false;
					}
				}

				allPlayersPositioned = true;
				return true;
			}
		}

		/// <summary>
		/// List of the Players of this battle
		/// </summary>
		public List<IBattlePlayer> Players {
			get { return players; }
			set { players = value; }
		}

		/// <summary>
		/// Unit Statistics
		/// </summary>
		public IBattleStatistics BattleStatistics {
			get { return battleStatistics; }
		}

		/// <summary>
		/// Object that handles the score
		/// </summary>
		public IScore Score {
			get { return score; }
		}

		/// <summary>
		/// Checks if the fleets need to be updated
		/// </summary>
		public bool UpdateFleets {
			get { return players[0].UpdateFleet; }
		}

		/// <summary>
		/// Checks if the players already positioned and the battle hasn't ended
		/// </summary>
		public bool IsInBattle {
			get { return !IsDeployTime && !Battle.HasEnded; }
		}

        /// <summary>
        /// Is the battle a team battle
        /// </summary>
        public bool IsTeamBattle {
            get { return isTeamBattle; }
            set { isTeamBattle = value; }
        }
		
		/// <summary>
		/// Messages a player generates during a play. This container is supposed to 
		/// be empty except when a battleinfo is loaded to make a move
		/// </summary>
		public List<BattleMessage> TurnMessages {
			get { return turnMessages; }
		}

        /// <summary>
        /// True if this battle was placed on a planet
        /// </summary>
        public bool IsBattleInPlanet {
            get { return Battle.IsInPlanet;  }
        }

        /// <summary>
        /// True if this battle was placed on a planet and was meatn for pillage
        /// </summary>
        public bool IsPlanetPillage {
			get { return Battle.IsInPlanet && !Battle.IsToConquer; }
        }
		
		#endregion Properties

		#region Private and Internal

		#region Utilities

		internal IPositionConversion GetPositionConverters( int playerNumber ) {
			if( NumberOfPlayers == 2 ) {
				return positionConverters[2][playerNumber];
			}
			return positionConverters[4][playerNumber];
		}

		/// <summary>
		/// Obtains a player battleInfo based on a player battle Information
		/// </summary>
		internal IBattleOwner GetBattleOwner(PlayerBattleInformation p) {
			return battle.GetBattleOwner(p);
		}

		private List<IBattleCoordinate> ClonedCoordinates() {
			List<IBattleCoordinate> coords = new List<IBattleCoordinate>();
			foreach (IBattleCoordinate coordinate in board.Keys) {
				coords.Add(coordinate.Clone());
			}
			return coords;
		}

		private IElement GetUltimateUnit( IBattleCoordinate coordinate ) {
			IBattleCoordinate coord = PositionConverter.ConvertCoordinateToBase(coordinate);
			return GetRawUltimateUnit(coord);
		}

		private IElement GetRawUltimateUnit( IBattleCoordinate coordinate ) {
			foreach (IBattlePlayer player in Players) {
				if (player.UltimateUnit != null && player.UltimateUnit.Element.Coordinate.Equals(coordinate) ) {
					return player.UltimateUnit.Element;
				}
			}
			return null;
		}

	    
        
		#endregion Utilities

		#region Movement Utils

		private static void MoveToTop( IElement e, IElement d ) {
			d.Quantity += e.Quantity;
			d.RemainingDefense = e.RemainingDefense;
		}

		private void MoveAllSrc( IElement e ) {
			InitialContainer.InitialUnits.Remove(e);
			
			if( Board.ContainsKey(e.Coordinate) ) {
				IElement d = Board[e.Coordinate];
				MoveToTop(e, d);
			} else {
				Board[e.Coordinate] = e;
			}
		}

		private void MoveAll( IBattleCoordinate src, IBattleCoordinate dst ) {
			IElement s = Board[src];
			
			Board.Remove(src);
			if( !Board.ContainsKey(dst) ) {
				s.Coordinate = dst;
				Board[dst] = s;
			} else {
				IElement d = Board[dst];
				MoveToTop(s, d);
			}
		}

		#endregion Movement Utils

		#endregion Private

		#region Public

		#region Board Manipulation

		/// <summary>
		/// Get's the element in the sector src
		/// </summary>
		/// <param name="src">Sector where to get the unit</param>
		/// <returns>IElement with the information</returns>
		public IElement SectorGetElement( IBattleCoordinate src ) {
			IElement e = GetUltimateUnit(src);
			if (e != null) {
				return e;
			}

			IBattleCoordinate newSrc = PositionConverter.ConvertCoordinateToBase(src);

			if( board.ContainsKey(newSrc) ) {
				return board[newSrc];
			}
			return null;
		}
		
		/// <summary>
		/// Get's the element in the sector src
		/// </summary>
		/// <param name="src">Sector where to get the unit</param>
		/// <returns>IElement with the information</returns>
		public IElement SectorRawGetElement( IBattleCoordinate src ) {
			IElement e = GetRawUltimateUnit(src);
			if (e != null) {
				return e;
			}
			
			if( board.ContainsKey(src) ) {
				return board[src];
			}
			return null;
		}

		/// <summary>
		/// Removes the element in the sector src
		/// </summary>
		/// <param name="src">Sector where to remove the unit</param>
		public void SectorRemoveElement( IBattleCoordinate src ) {
			IElement e = GetRawUltimateUnit(src);
			if (e != null) {
				e.Owner.UltimateUnit = null;
			}

			if( board.ContainsKey(src) ) {
				board.Remove(src);
			}
		}

		/// <summary>
		/// Get's the element in the sector src
		/// </summary>
		/// <param name="coord">Sector to test</param>
		/// <returns>True if a element from the enemy exists</returns>
		public bool SectorHasElement( IBattleCoordinate coord ) {
			IElement e = GetUltimateUnit(coord);
			if (e != null){
				return true;
			}

			IBattleCoordinate newCoord = PositionConverter.ConvertCoordinateToBase(coord);
			return board.ContainsKey(newCoord);
		}

		/// <summary>
		/// Get's the element in the sector src WITHOUT coordinate translation
		/// </summary>
		/// <param name="coord">Sector to test</param>
		/// <returns>True if a element from the enemy exists</returns>
		public bool SectorRawHasElement( IBattleCoordinate coord ) {
			IElement e = GetRawUltimateUnit(coord);
			if (e != null){
				return true;
			}
			return board.ContainsKey(coord);
		}

		/// <summary>
		/// Moves a unit from the source into a coordinate
		/// </summary>
		/// <param name="element">Element that represents the unit in the source</param>
		/// <param name="quantity">Quanity to move</param>
		public void SectorSrcMove( IElement element, int quantity ) {
			element.Coordinate = PositionConverter.ConvertCoordinateToBase(element.Coordinate);

			if( element.Quantity == quantity ) {
				element.Position = PositionConverter.ConvertPositionToBase(element.Position);
				MoveAllSrc(element);
			} else {
				IElement d = element.Clone();
				d.Position = PositionConverter.ConvertPositionToBase(element.Position);
				d.Quantity = quantity;
				Board[element.Coordinate] = d;
				element.Quantity -= quantity;
			}
		}

		/// <summary>
		/// Moves a unit from the source into a coordinate
		/// </summary>
		/// <param name="element">Element that represents the unit in the source</param>
		/// <param name="quantity">Quanity to move</param>
		public void SectorRawSrcMove( IElement element, int quantity ) {
			if( element.Quantity == quantity ) {
				MoveAllSrc(element);
			} else {
				IElement d = element.Clone();
				d.Quantity = quantity;
				Board[element.Coordinate] = d;
				element.Quantity -= quantity;
			}
		}

		/// <summary>
		/// Moves the quantity passed of a unit from sector src to sector dst
		/// </summary>
		/// <param name="src">Source sector</param>
		/// <param name="dst">Destiny sector</param>
		/// <param name="quantity">Quantity to move</param>
		public void SectorMove( IBattleCoordinate src, IBattleCoordinate dst, int quantity ) {
			IBattleCoordinate newSrc = PositionConverter.ConvertCoordinateToBase(src);
			IBattleCoordinate newDst = PositionConverter.ConvertCoordinateToBase(dst);

			IElement element = Board[newSrc];

			if( element.Quantity == quantity ) {
				MoveAll(newSrc, newDst);
			} else {
				element.Quantity -= quantity;
				if( Board.ContainsKey(newDst) ) {
					IElement existingElement = Board[newDst];
					existingElement.Quantity += quantity;
					existingElement.AddEffects(element);
				} else {
					element = element.Clone();
					element.Coordinate = newDst;
					element.Quantity = quantity;
					element.RemainingDefense = element.Unit.Defense;
					Board[newDst] = element;
				}
			}
		}

		/// <summary>
		/// Inserts a new element into the board
		/// </summary>
		/// <param name="element">Element to insert</param>
		public void SectorInsertElement(IElement element) {
			element.Coordinate = PositionConverter.ConvertCoordinateToBase(element.Coordinate);
			element.Position = PositionConverter.ConvertPositionToBase(element.Position);

			Board[element.Coordinate] = element;
		}

		#endregion Board Manipulation

		#region Get Methods

		/// <summary>
		/// Resolves all the effects in each unit
		/// </summary>
		public void ResolveEffects() {
			List<IBattleCoordinate> coords = ClonedCoordinates();
			foreach( IBattleCoordinate coord in coords ) {
				IElement element = board[coord];
				element.ResolveEffects(this);
			}

			foreach (IBattlePlayer player in players) {
				if( player.HasUltimateUnit ) {
					player.UltimateUnit.Element.ResolveEffects(this);	
				}
			}
		}

		/// <summary>
		/// Updates the initial container state, the state of the board
		/// </summary>
		/// <returns>Updated Battle Object</returns>
		public Battle GetUpdatedBattle() {
			Battle.IsDeployTime = !AllPlayersPositioned;
			battleUtils.UpdatePlayerBattleInformation();
			battleUtils.UpdateBattleBoard();
			return Battle;
		}

		/// <summary>
		/// Get's the board for the passed player
		/// </summary>
		/// <param name="player">Player to get the board from</param>
		/// <returns>Dictionar with the board</returns>
		public Dictionary<string, IElement> GetBoard( IBattlePlayer player ) {
			Dictionary<string, IElement> newBoard = new Dictionary<string, IElement>();
			IPositionConversion pc = player.PositionConverter;

			foreach( KeyValuePair<IBattleCoordinate, IElement> pair in board ) {
				IElement e = pair.Value.Clone();

				e.Coordinate = pc.ConvertCoordinateToSpecific(pair.Key);
				e.Position = pc.ConvertPositionToSpecific(e.Position);

				newBoard.Add(e.Coordinate.ToString(), e);
			}

			return newBoard;
		}

		/// <summary>
		/// Get's the board for the passed player
		/// </summary>
		/// <param name="currPlayer">Current Player</param>
		/// <param name="player">Player to get the board from</param>
		/// <returns>Dictionar with the board</returns>
		public IElement GetUltimateUnit(IBattlePlayer currPlayer, IBattlePlayer player) {
			IUltimateUnit unit = player.UltimateUnit;
			IElement e = unit.Element.Clone();
			IPositionConversion pc = currPlayer.PositionConverter;

			e.Coordinate = pc.ConvertCoordinateToSpecific(e.Coordinate);
			e.Position = pc.ConvertPositionToSpecific(e.Position);

			return e;
		}

		/// <summary>
		/// Get's the board
		/// </summary>
		/// <returns>Dictionar with the board</returns>
		public Dictionary<IBattleCoordinate, IElement> GetBoard() {
			return board;
		}

        /// <summary>
        /// Get's the winners
        /// </summary>
        /// <returns>Dictionar with the board</returns>
		public List<IBattlePlayer> GetBattlePlayerWinners() {
            if( HasEnded() ) {
				List<IBattlePlayer> winners = new List<IBattlePlayer>();
                foreach (IBattlePlayer player in Players) {
                    if( !player.HasLost ) {
						winners.Add(player);
                    }
                }
                return winners;
            }
            return null;
        }

		// <summary>
		/// Get's the winners
		/// </summary>
		/// <returns>Dictionar with the board</returns>
		public List<IBattleOwner> GetBattleOwnerWinners() {
			if( HasEnded() ) {
				List<IBattleOwner> winners = new List<IBattleOwner>();
				foreach( IBattlePlayer player in Players ) {
					if( !player.HasLost ) {
						winners.Add(player.Owner);
					}
				}
				return winners;
			}
			return null;
		}

		/// <summary>
		/// Get's the losers
		/// </summary>
		/// <returns>List with the losers of the Battle</returns>
		public List<IBattleOwner> GetBattleOwnerLosers() {
			if (HasEnded()) {
				List<IBattleOwner> losers = new List<IBattleOwner>();
				foreach (IBattlePlayer player in Players) {
					if (player.HasLost) {
						losers.Add(player.Owner);
					}
				}
				return losers;
			}
			return null;
		}

		public IBattlePlayer GetPlayer( IBattleOwner battleOwner ) {
			return Players.Find(delegate( IBattlePlayer p ) { return p.Owner.Id == battleOwner.Id; });
		}

		public IBattlePlayer GetPlayer(int ownerId) {
			return Players.Find(delegate(IBattlePlayer p) { return p.Owner.Id == ownerId; });
		}

		public IBattlePlayer GetPlayerByBotId(IBattleOwner battleOwner) {
			return Players.Find(delegate(IBattlePlayer p) { return p.Owner.BotId == battleOwner.Id; });
		}

		public IBattlePlayer GetPlayerByBotId(int ownerId) {
			return Players.Find(delegate(IBattlePlayer p) { return p.Owner.BotId == ownerId; });
		}

		/// <summary>
		/// Gets the all the moves of the battle
		/// </summary>
		/// <returns>A string array with all the moves of the battle</returns>
		public string[] GetMovesList( IBattlePlayer player ) {
			Translater translater = new Translater(player);
			string[] moves = Battle.BattleExtension[0].BattleMovements.Split(separator);
			return translater.TranslateAllMovements(moves);
		}

		/// <summary>
		/// Gets the all the final states of the battle
		/// </summary>
		/// <returns>A string array with all the final states</returns>
		public string[] GetFinalStates( IBattlePlayer player ) {
			Translater translater = new Translater(player);
			string[] fs = Battle.BattleExtension[0].BattleFinalStates.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			return translater.TranslateFinalState(fs);
		}

		#endregion Get Methods

		/// <summary>
		/// Adds a message related to the current play
		/// </summary>
		/// <param name="message">Message to add</param>
		public void AddTurnMessage( BattleMessage message ) {
			turnMessages.Add(message);
		}

		/// <summary>
		/// Clears all the messages
		/// </summary>
		public void RemoveAllMessages() {
			turnMessages.Clear();
		}

		/// <summary>
		/// Loads the initial state of the board into the container
		/// </summary>
		public void LoadInitialState() {
			board.Clear();
			string[] battleFinalStates = Battle.BattleExtension[0].BattleFinalStates.Split(separator);
			if( battleFinalStates.Length > 0 ) {
				string finalState = battleFinalStates[NumberOfPlayers - 1];
				if( finalState.Length > 0 ) {
					battleUtils.LoadFinalState(finalState);
				}
			}
		}

		/// <summary>
		/// Updates the movements made, the next player to play and the victory percentage
		/// </summary>
		/// <param name="movements"></param>
		public virtual void BattleFinalUpdate( string movements ) {
			Translater translater = new Translater(CurrentBattlePlayer);

			string newMoves = translater.TranslateMovementsToStore(movements);
			if (Battle.BattleExtension[0].BattleMovements.Length == 0) {
				if (newMoves.Length == 0) {
					Battle.BattleExtension[0].BattleMovements = "|";
				}else {
					Battle.BattleExtension[0].BattleMovements = newMoves;
				}
			}else {
				Battle.BattleExtension[0].BattleMovements += "|" + newMoves;	
			}

		    UpdateUltimateUnit();
			UpdateSpecialUnits();
            Battle.UnitsDestroyed = BattleStatistics.ToString();

			++Battle.CurrentTurn;
			
			battleUtils.CalculatePercentage();
			battleUtils.CalculateScore();
		}

		protected virtual void UpdateSpecialUnits() {}

        /// <summary>
		/// Sets the next player to play
		/// </summary>
		public void SetNextPlayer() {
			CurrentBattlePlayer.IsTurn = false;
			IBattlePlayer nextPlayer = GetNextPlayer();
			nextPlayer.IsTurn = true;
		    CurrentBattlePlayer = nextPlayer;
			Battle.CurrentPlayer = nextPlayer.Owner.Id;
            if (nextPlayer.Owner.IsBot){
				Battle.CurrentBot = nextPlayer.Owner.BotId;
			}else {
				Battle.CurrentBot = 0;
			}
		}

		/// <summary>
		/// Final timeout of the current player
		/// </summary>
		public void Timeout() {
			RemovePlayerUnits(CurrentBattlePlayer);
			CurrentBattlePlayer.HasLost = true;
			SetNextPlayer();
			battleUtils.CalculatePercentage();
			battleUtils.CalculateScore();
		}

		/// <summary>
		/// Terminate the player participation in the current battle
		/// </summary>
		public void GiveUp( IBattleOwner battleOwner ) {
            IBattlePlayer player = GetPlayer(battleOwner);
			player.HasLost = true;
			player.HasGaveUp = true;
			
			RemovePlayerUnits(player);
		    
			if( player.Owner.Id == battleOwner.Id ) {
				SetNextPlayer();
			}

			battleUtils.CalculatePercentage();
			battleUtils.CalculateScore();
			if( player.LoseScore != 0 ) {
				player.LoseScore /= GiveUpLoseDivider;
			}

			AddTurnMessage(new GiveUpMessage(Id, CurrentTurn, player.Name));
		}

		/// <summary>
		/// Ends the battle
		/// </summary>
		public void EndBattle() {
			Battle.HasEnded = true;
		}

		/// <summary>
		/// Gets the number of units of the passed player
		/// </summary>
		/// <param name="player">Player to count the units</param>
		/// <returns>Number of units of the passed player</returns>
		public int GetTotalUnitQuantity(IBattlePlayer player) {
			int count = 0;
			foreach (KeyValuePair<IBattleCoordinate, IElement> pair in board) {
				IElement e = pair.Value;
				if( e.Owner.PlayerNumber == player.PlayerNumber ) {
					count += e.Quantity;
				}
			}
			return count;
		}

		#endregion Public

		#region Abstract Methods

		#region IFactory Members

		public abstract object create(object args);

		#endregion

		#region Abstract Internal Methods

		/// <summary>
		/// Updates the current player when it's position time
		/// </summary>
		/// <param name="IBattleOwner">Player that is positioning</param>
		public abstract void UpdateCurrentPlayer(IBattleOwner IBattleOwner);

		/// <summary>
		/// Get's the next player to play
		/// </summary>
		internal abstract IBattlePlayer GetNextPlayer();

        /// <summary>
        /// Updates the ultimate unit
        /// </summary>
	    protected abstract void UpdateUltimateUnit();

		#endregion Abstract Internal Methods

		#region Abstract Public Methods

		/// <summary>
		/// Verifies if the battle has ended
		/// </summary>
		public abstract bool HasEnded();

		/// <summary>
		/// Erases all units from the board that are owned by the passed player
		/// </summary>
		/// <param name="player">Player that has lost</param>
		public abstract void RemovePlayerUnits(IBattlePlayer player);

		#endregion Abstract Public Methods

		#region Abstract Properties

		/// <summary>
		/// Number of players in battle
		/// </summary>
		public abstract int NumberOfPlayers { get; }

		#endregion Abstract Properties



	    #endregion Abstract Methods

		#region Constructor

		static BattleInfo() {
			positionConverters[2] = new List<IPositionConversion>();
			positionConverters[2].Add( new ConvertToPlayer1(2));
			positionConverters[2].Add( new ConvertToPlayer2(2));

			positionConverters[4] = new List<IPositionConversion>();
			positionConverters[4].Add( new ConvertToPlayer1(4));
			positionConverters[4].Add( new ConvertToPlayer2(4));
			positionConverters[4].Add( new ConvertToPlayer3(4));
			positionConverters[4].Add( new ConvertToPlayer4(4));
		}

		public BattleInfo() 
			{}

		public BattleInfo( IBattle battle ){
			this.battle = battle;
			battleUtils = new BattleUtils(this);
			battleUtils.LoadPlayerInformation();
			battleUtils.LoadBoard();
			battleUtils.LoadTerrain();
			battleUtils.LoadMisc();
			score = ScoreUtils.GetScore(this);
			battleStatistics.Parse(Battle.UnitsDestroyed);
		}

		#endregion Constructor

	}
}
