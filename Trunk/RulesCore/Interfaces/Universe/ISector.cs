
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface ISector : IBackToStorage<SectorStorage> {
		Coordinate SystemCoordinate {
			get;
			set;
		}

		Coordinate SectorCoordinate {
			get;
			set;
		}

		bool IsInBattle {
			get;
			set;
		}

		bool HasResource {
			get;
		}

		string SubType {
			get;
			set;
		}

		int Level {
			get;
			set;
		}

		bool IsStatic {
			get;
			set;
		}

		IPlayer Owner {
			get;
			set;
		}

		bool IsConstructing {
			get;
			set;
		}

		bool IsMoving {
			get;
			set;
		}

		bool IsPrivate {
			get;
			set;
		}

		List<ICelestialBody> CelestialBodies {
			get;
		}

		SectorCoordinate Coordinate {
			get;
			set;
		}

		/// <summary>
		/// Friendly Name to display
		/// </summary>
		string DisplayTypeShort {
			get;
		}

        IResourceQuantity Resource { get;set;}
		string Type { get; }

		/// <summary>
		/// Event that is called when a object is moved to this sector
		/// </summary>
		/// <param name="args">Arguments of the movement</param>
		void OnMove(IUniverseMoveArgs args);

		/// <summary>
		/// Method call when the turn is passed
		/// </summary>
		void Turn();

		/// <summary>
		/// Adds a new celestial body to this sector
		/// </summary>
		/// <param name="celestialBody"></param>
		void AddCelestialBody(ICelestialBody celestialBody);

		/// <summary>
		/// Adds the celestial bodies from the passed sector to the current sector
		/// </summary>
		/// <param name="sector"></param>
		void AddCelestialBodies(ISector sector);

		/// <summary>
		/// Gets the fleet to enter in the battle
		/// </summary>
		/// <returns>the object that represent the fleet that is going to enter in the battle</returns>
		IFleetInfo GetBattleFleet();

		/// <summary>
		/// Verifies if the passed player is owner
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		bool IsOwner(IPlayer player);

		/// <summary>
		/// Gets the list of fleets in this sector (if any)
		/// </summary>
		/// <returns></returns>
		IEnumerable<IFleetInfo> GetFleets();

		/// <summary>
		/// Gets the fleet with the passed id
		/// </summary>
		/// <returns></returns>
		IFleetInfo GetFleet(int id);

		/// <summary>
		/// Get's the planet associated with this sector (if any)
		/// </summary>
		/// <returns></returns>
		IPlanet GetPlanet();
	}
}
