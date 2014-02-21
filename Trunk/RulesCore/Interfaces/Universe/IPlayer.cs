using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Interfaces {
	/// <summary>
	/// Represents a player
	/// </summary>
	public interface IPlayer :
		IResourceOwner,
		IIntrinsicLimiter,
		IActionOwner,
		IBackToStorage<PlayerStorage> {

		#region Player Properties

		/// <summary>
		/// The Player's name
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// True if the player is on vacations
		/// </summary>
		bool InVacations { get; }

        /// <summary>
		/// True if the player is active
		/// </summary>
		bool Active { get; set; }

		/// <summary>
		/// If the alliance was loaded or not
		/// </summary>
		bool AllianceLoaded { get; }

		/// <summary>
		/// The player's alliance
		/// </summary>
		IAlliance Alliance { get; set; }

		/// <summary>
		/// True if the player is registered on some alliance
		/// </summary>
		bool HasAlliance { get; }

        /// <summary>
        /// True if the player is main player
        /// </summary>
        bool IsPrimary { get; set; }

		/// <summary>
		/// The alliance role of the player (if any)
		/// </summary>
		AllianceRank AllianceRank { get; set; }

		/// <summary>
		/// The player planets
		/// </summary>
		IList<IPlanet> Planets { get; }

		/// <summary>
		/// The planet level of the player
		/// </summary>
		int PlanetLevel { get; set; }

		/// <summary>
		/// The player quests
		/// </summary>
		IList<IQuestData> Quests { get; set; }

		/// <summary>
		/// Ranking of the current player
		/// </summary>
		int Ranking { get; }

		/// <summary>
		/// The last processed tick
		/// </summary>
		int LastProcessedTick { get; set; }

		/// <summary>
		/// Special sectors that the player had discovered
		/// </summary>
		List<UniverseSpecialSector> SpecialSectors { get; }

		/// <summary>
		/// Iof  layer
		/// </summary>
		int Id { get; }

		/// <summary>
		/// Score of the plar
		/// </summary>
		int Score { get; set; }

		/// <summary>
		/// List of the player's fleets
		/// </summary>
		List<IFleetInfo> Fleets { get; }

		/// <summary>
		/// The player race
		/// </summary>
		IRaceInfo RaceInfo { get; set; }

		/// <summary>
		/// The principal that owns the player
		/// </summary>
		Principal Principal { get; set; }

		/// <summary>
		/// id of the homeplanet
		/// </summary>
		int HomePlanetId { get; set; }

		/// <summary>
		/// The player resources
		/// </summary>
		Dictionary<IResourceInfo, int> IntrinsicQuantities { get; set; }

		/// <summary>
		/// The player resources
		/// </summary>
		string Avatar { get; set; }

        /// <summary>
        /// The player forum Roles
        /// </summary>
        string ForumRole { get; set; }

        /// <summary>
        /// The player forum Signature
        /// </summary>
        string ForumSignature { get; set; }

        /// <summary>
        /// The player forum Total Posts
        /// </summary>
        int TotalPosts { get; set; }

		#endregion Player Properties

		#region Profession Properties

		/// <summary>
		/// The player's main profession
		/// </summary>
		Profession MainProfession { get; }

		/// <summary>
		/// The player's colonizer ranking
		/// </summary>
		int ColonizerRanking { get; set; }

		/// <summary>
		/// The player's pirate ranking
		/// </summary>
		int PirateRanking { get; set; }

		/// <summary>
		/// The player's bounty hunter ranking
		/// </summary>
		int BountyRanking { get; set; }

		/// <summary>
		/// The player's gladiator ranking
		/// </summary>
		int GladiatorRanking { get; set; }

		/// <summary>
		/// The player's merchant ranking
		/// </summary>
		int MerchantRanking { get; set; }

		#endregion Profession Properties

		#region Player Methods

		/// <summary>
		/// Registers a planet with this player
		/// </summary>
		/// <param name="planet">The planet</param>
		void RegisterPlanet(IPlanet planet);

		/// <summary>
		/// Adds a quest to the player
		/// </summary>
		/// <param name="quest">The quest</param>
		void AddQuest(IQuestData quest);

		/// <summary>
		/// Adds a fleet to the player
		/// </summary>
		/// <param name="fleet">The fleet</param>
		void AddFleet(IFleetInfo fleet);

		/// <summary>
		/// Adds a  list of fleets to the player
		/// </summary>
		/// <param name="fleet">The fleet</param>
		void AddFleets(List<IFleetInfo> fleet);

		/// <summary>
		/// Gets the player's home planet
		/// </summary>
		/// <returns>The home planet</returns>
		IPlanet GetHomePlanet();

		/// <summary>
		/// Gets the player's home planet
		/// </summary>
		/// <returns>The home planet</returns>
		IPlanet GetPlanet(int id);

		/// <summary>
		/// If the player has planets loaded
		/// </summary>
		/// <returns>if the players have loaded planets</returns>
		bool HasLoadedPlanets();

		/// <summary>
		/// If the player has fleets loaded
		/// </summary>
		/// <returns>if the players have loaded fleets</returns>
		bool HasLoadedFleets();

		/// <summary>
		/// If the player has quests loaded
		/// </summary>
		/// <returns>if the players have loaded quests</returns>
		bool HasLoadedQuests();

		/// <summary>
		/// If the player has planets loaded
		/// </summary>
		/// <returns>if the players have loaded planets</returns>
		bool HasLoadedActions();

		/// <summary>
		/// If the player has sectors loaded
		/// </summary>
		/// <returns>if the players have loaded sectors</returns>
		bool HasLoadedSectors();

		/// <summary>
		/// Tests if the passed player is owned by the same Principal as the current
		/// </summary>
		/// <param name="player">Player to test</param>
		/// <returns>True if the current player and the passed player have the dsame Principal</returns>
		bool HasSamePrincipal(IPlayer player);

        /// <summary>
        /// Tests if the player can build a ultimate unit
        /// </summary>
        /// <param name="quantity">The quantity</param>
        /// <returns>The result</returns>
        Result CanBuildUltimateUnit(int quantity);

        /// <summary>
        /// Gets or sets the ultimate weapon level
        /// </summary>
        int UltimateWeaponLevel {get;set;}

        /// <summary>
        /// Gets or sets the ultimate weapon cooldown
        /// </summary>
        int UltimateWeaponCooldown { get;set;}

        /// <summary>
        /// Tests if the player is in the ultimate weapon cooldown
        /// </summary>
        bool HasUltimateCooldown { get;}

        /// <summary>
        /// Gets a json representation of the player's resources
        /// </summary>
        /// <returns>a json representation with the resources</returns>
	    string GetResourcesInJson();

		#endregion Player Methods

		#region Fleets

		bool HasMoveableFleets { get; }

		/// <summary>
		/// Get's the fleet with the passed id
		/// </summary>
		/// <param name="fleetId"></param>
		/// <returns></returns>
		IFleetInfo GetFleet(int fleetId);

		/// <summary>
		/// Get's a list of all fleets
		/// </summary>
		List<IFleetInfo> AllFleets { get; }

		#endregion Fleets

		#region Universe

		ISystem PrivateSystem { get; set; }

		bool HasPrivateSystem { get; }

		ISector GetSector(Coordinate sectorCoordinate);

		List<ISector> GetSectors(List<CoordinateDistance> coordinates);

		List<ISector> GetSectors(List<SectorCoordinate> coordinates);

		void ResolveHomePlanet();

		#endregion

		#region Quests

		/// <summary>
		/// The quest context level
		/// </summary>
		Dictionary<QuestContext, int> QuestContextLevel { get; set; }

		/// <summary>
		/// Checks if the player is on the given level on the given quest context
		/// </summary>
		/// <param name="Context">The quest context</param>
		/// <param name="TargetLevel">The target level</param>
		/// <returns>True if the player can do it</returns>
		bool ChekQuestLevel(QuestContext Context, int TargetLevel);

		/// <summary>
		/// Gets the level for the given context
		/// </summary>
		/// <param name="context">The quest context</param>
		/// <returns>The level</returns>
		int GetQuestContextLevel(QuestContext context);

		/// <summary>
		/// Updates the sequence on the given context
		/// </summary>
		/// <param name="Context">The context</param>
		/// <param name="p">The new level</param>
		void SetQuestContextLevel(QuestContext Context, int level);

		#endregion Quests

        #region Services

        /// <summary>
        /// List of services that this player owns at the moment
        /// </summary>
        List<ServiceType> Services { get; set;}

		bool IsUltimateWeaponReady {
			get;
		}

	    int ActivatedInTick { get; set; }

	    /// <summary>
        /// Adds a service to this principal
        /// </summary>
        /// <param name="type">The service</param>
        void AddService(ServiceType type);

        /// <summary>
        /// Removes a service from this principal
        /// </summary>
        /// <param name="type">The service</param>
        void RemoveService(ServiceType type);

        /// <summary>
        /// True if the player has the service
        /// </summary>
        /// <param name="type">The service</param>
        /// <returns></returns>
        bool HasService(ServiceType type);

        #endregion Services

		#region Generals

		/// <summary>
		/// if the player has a general
		/// </summary>
		bool IsGeneralActive { get; set; }

		/// <summary>
		/// General Id
		/// </summary>
		int GeneralId { get; set; }

		/// <summary>
		/// General Name
		/// </summary>
		string GeneralName { get; set; }

		/// <summary>
		/// General Friendly Name
		/// </summary>
		string GeneralFriendlyName { get; set; }

        /// <summary>
        /// List of relics
        /// </summary>
	    IList<SectorCoordinate> Relics{get;}

	    #endregion

    };
}
