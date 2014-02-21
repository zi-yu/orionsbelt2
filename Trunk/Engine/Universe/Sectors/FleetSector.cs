using System;
using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector with a fleet
	/// </summary>
	[FactoryKey("FleetSector")]
	public class FleetSector : Sector{

		#region Fields

		private static readonly string type = "FleetSector";
		private FleetSectorMoveArgs fleetArgs;

		#endregion Fields

		#region Properties

		public override string Type {
			get { return type; }
		}

		public override string DisplayTypeShort {
			get { return "f"; }
		}

		public string FleetName {
			get { return GetBattleFleet().Name;  }
			
		}

		public FleetSectorMoveArgs FleetSectorMoveArgs {
			get { return fleetArgs; }
		}

		public override SectorCoordinate Coordinate {
			set {
				Touch();
				currentCoordinate = value;
				GetBattleFleet().Location = currentCoordinate;
			}
		}

		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new FleetSector(sectorStorage);
		}

		protected void LoadFleet(SectorStorage sectorStorage) {
			if (sectorStorage.Fleets.Count > 0) {
				IFleetInfo fleet = new FleetInfo(sectorStorage.Fleets[0]);
				fleet.Sector = this;
				fleet.IsInBattle = false;
				CelestialBodies.Add(fleet);
			}
		}

		protected bool HasPenalty(ISector nextSector) {
			bool buyNoUndiscoveredUniverse = Owner.HasService(ServiceType.BuyNoUndiscoveredUniverse);
			if( buyNoUndiscoveredUniverse ) {
				return false;
			}

			IFleetInfo fleet = GetBattleFleet();
			for (int i = 0; i < fleet.VisibilityRange; ++i) {
				if (fleetArgs.Destiny.Equals(nextSector.Coordinate)) {
					break;
				}
				List<CoordinateDistance> coordinates = SectorUtils.GetPossibleCoordinates(nextSector.Coordinate, fleetArgs.Destiny);
				nextSector = SectorUtils.GetFirstAvailable(coordinates, fleetArgs.Destiny, fleetArgs.LastCoordinate, Owner);
				if (nextSector == null) {
					return false;
				}
			}
			FogOfWarContainer container = Universe.GetFogOfWar(Owner.Id);
			UniverseVisibility visibility = container.GetVisibility(nextSector.Coordinate);
			return visibility is Undiscovered;
		}

		#endregion Private

		#region Fleet Movement

		private void NormalFleetTurn() {
			//Console.WriteLine("======= START ==========");
			Console.WriteLine(" » Moving Fleet at coordinate {0}...",Coordinate);
			DateTime start = DateTime.Now;
			FleetSectorMoveArgs.DecrementetTicksToMove();
			if (FleetSectorMoveArgs.CanMove) {
				List<CoordinateDistance> coordinates = SectorUtils.GetPossibleCoordinates(currentCoordinate, fleetArgs.Destiny);
				ISector nextSector = SectorUtils.GetFirstAvailable(coordinates, fleetArgs.Destiny, fleetArgs.LastCoordinate, Owner);
				Console.WriteLine(" » Find Next Coordinate took {0}ms", (DateTime.Now - start).TotalMilliseconds);

				DateTime start2 = DateTime.Now;
				if (nextSector != null) {
					if (SectorUtils.HasArrived(nextSector.Coordinate, fleetArgs.Destiny)) {
						FleetMovement.ProcessFleetArrived(nextSector, this);
						Console.WriteLine(" » Process Arrival took {0}ms", (DateTime.Now - start2).TotalMilliseconds);
					} else {
						if (HasPenalty(nextSector)) {
							FleetSectorMoveArgs.TotalTicksToMove = 4;
						} else {
							FleetSectorMoveArgs.TotalTicksToMove = 1;
						}
						FleetSectorMoveArgs.UpdateTicksToMove();
						FleetMovement.ProcessFleetMovement(nextSector, this);
						Console.WriteLine(" » Process Movement took {0}ms", (DateTime.Now - start2).TotalMilliseconds);
					}
					DateTime start3 = DateTime.Now;
					FogOfWarUtils.SaveFogOfWar(this, nextSector);
					Console.WriteLine(" » Save Fog of War {0}ms", (DateTime.Now - start3).TotalMilliseconds);
				} else {
					//Console.WriteLine(" » Process stuck fleet"); 
					FleetMovement.ProcessStuckFleet(this);
				}
				Console.WriteLine(" » Done Moving Fleet '{1}'! Took {0}ms", (DateTime.Now - start).TotalMilliseconds, FleetName);
				//Console.WriteLine("======= END ==========");
			} else {
				Touch();
			}
		}

		private void BotFleetTurn() {
			DateTime start = DateTime.Now;
			FleetSectorMoveArgs.DecrementetTicksToMove();
			if (FleetSectorMoveArgs.CanMove) {
				List<CoordinateDistance> coordinates = SectorUtils.GetPossibleCoordinates(currentCoordinate, fleetArgs.Destiny);
				ISector nextSector = SectorUtils.GetFirstAvailable(coordinates, fleetArgs.Destiny, fleetArgs.LastCoordinate, Owner);

				if (nextSector != null) {
					if (nextSector.SystemCoordinate == Coordinate.System) {
						if (SectorUtils.HasArrived(nextSector.Coordinate, fleetArgs.Destiny)) {
							FleetMovement.ProcessFleetArrived(nextSector, this);
						} else {
							FleetSectorMoveArgs.TotalTicksToMove = 1;
							FleetSectorMoveArgs.UpdateTicksToMove();
							FleetMovement.ProcessFleetMovement(nextSector, this);
						}
					}else {
						IsMoving = false;
					}
				} else {
					FleetMovement.ProcessStuckFleet(this);
				}
				Console.WriteLine(" » Done Moving BOT Fleet '{1}'! Took {0}ms", (DateTime.Now - start).TotalMilliseconds, FleetName);
			} else {
				Touch();
			}
		}

		#endregion Fleet Movement

		#region Public

		/// <summary>
		/// Event that is called when this fleet starts moving
		/// </summary>
		/// <param name="args">Arguments of the movement</param>
		public override void OnMove(IUniverseMoveArgs args) {
			fleetArgs = (FleetSectorMoveArgs)args;
			IsMoving = true;
			IsInBattle = false;
			GetBattleFleet().IsInBattle = false;
			Messenger.Add(new FleetStartMovingMessage(Owner.Id, FleetName, fleetArgs.Destiny));
			GameEngine.Persist(this, fleetArgs.Flush);
		}

		/// <summary>
		/// Event that is called when the turn passes
		/// </summary>
		public override void Turn() {
			if(GetBattleFleet().IsBot) {
				BotFleetTurn();
			}else{
				NormalFleetTurn();
			}
		}

		public override IFleetInfo GetBattleFleet() {
            if (CelestialBodies == null || CelestialBodies.Count == 0){
                throw new EngineException("FleetSector at {0} is invalid. Id: {1}", Coordinate.ToString(), Storage.Id);
            }
			return (IFleetInfo)CelestialBodies[0];
		}

		public override void AddCelestialBody(ICelestialBody celestialBody) {
			if( CelestialBodies.Count != 0  ) {
				CelestialBodies.Clear();
			}
			celestialBody.Sector = this;
			CelestialBodies.Add(celestialBody);
			Touch();
		}

		#endregion Public

		#region IBackToStorage<SectorStorage> Members
		
		public override void UpdateStorage() {
			base.UpdateStorage();
			if( IsMoving ) {
                if (fleetArgs != null){
                    storage.AdditionalInformation = fleetArgs.ToString();
                }else {
                    storage.AdditionalInformation = string.Empty;
                    IsMoving = false;
                }
			}else {
				storage.AdditionalInformation = string.Empty;
			}
			
			IsDirty = false;
		}

		#endregion IBackToStorage<SectorStorage> Members

		#region Constructor

		public FleetSector() {}

		public FleetSector(Coordinate system, Coordinate sector, IFleetInfo fleetInfo, int level)
			: base(system, sector,level) {
			owner = fleetInfo.Owner;
			AddCelestialBody(fleetInfo);
		}

		public FleetSector(SectorStorage sectorStorage) 
			: base(sectorStorage) {
			LoadFleet(sectorStorage);
			if( isMoving ) {
                if( !string.IsNullOrEmpty(sectorStorage.AdditionalInformation)) {
				    fleetArgs = FleetSectorMoveArgs.Parse(sectorStorage.AdditionalInformation);
                    isDirty = false;
                }else{
                    IsMoving = false;
                }
			}else{
                isDirty = false;
            }
			
		}

		public FleetSector(SectorStorage sectorStorage, List<SectorStorage> fleets )
			: base(sectorStorage) {
			LoadFleet(sectorStorage);
			if( isMoving ) {
                if( !string.IsNullOrEmpty(sectorStorage.AdditionalInformation)) {
				    fleetArgs = FleetSectorMoveArgs.Parse(sectorStorage.AdditionalInformation);
                    isDirty = false;
                }else{
                    IsMoving = false;
                }
			}else{
                isDirty = false;
            }
		}

		#endregion Constructor

	}
}
