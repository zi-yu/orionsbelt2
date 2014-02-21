using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	public class FleetSectorMoveArgs : IUniverseMoveArgs {

		#region Fields

		protected static readonly char[] separator = new char[] { ';' };
        protected static readonly char[] lastSeparator = new char[] { '|' };
		private SectorCoordinate source;
		private SectorCoordinate destiny;
		private bool pursuit = false;
		private bool attackWhenArrive = false;
		private bool follow = false;
		private bool teletransporting = false;
		private bool conquerWhenArrive = false;
		private bool useUltimateWeapon = false;
        private bool challengeWhenArrive = false;
		private bool unloadCargo = false;
		private SectorCoordinate wormHoleCoordinate = SectorCoordinate.Dummy;
        private List<SectorCoordinate> lastCoordinate = new List<SectorCoordinate>();
		private int fleetToPursuitId;
		private int ticksToMove = 1;
        private int totalTicksToMove = 1;
		private bool flush = true;

		#endregion Fields
		
		#region Properties

		public SectorCoordinate Source {
			get { return source; }
			set { source = value; }
		}

		public SectorCoordinate Destiny {
			get { return destiny; }
			set { destiny = value; }
		}

		public bool Pursuit {
			get { return pursuit; }
			set { pursuit = value; }
		}

		public bool AttackWhenArrive {
			get { return attackWhenArrive; }
			set { attackWhenArrive = value; }
		}

		public SectorCoordinate WormHoleCoordinate {
			get { return wormHoleCoordinate; }
			set { wormHoleCoordinate = value; }
		}

		public bool Teletransporting {
			get { return teletransporting; }
			set { teletransporting = value; }
		}

		public List<SectorCoordinate> LastCoordinate {
			get { return lastCoordinate; }
			set { lastCoordinate = value; }
		}

		public bool ConquerWhenArrive {
			get { return conquerWhenArrive; }
			set { conquerWhenArrive = value; }
		}

		public bool Follow {
			get { return follow; }
			set { follow = value; }
		}

		public int FleetToPursuitId {
			get { return fleetToPursuitId; }
			set { fleetToPursuitId = value; }
		}

		public bool UseUltimateWeapon {
			get { return useUltimateWeapon; }
			set { useUltimateWeapon = value; }
		}

		public int TicksToMove {
			get { return ticksToMove; }
			set { ticksToMove = value; }
		}

		public bool CanMove {
			get { return ticksToMove <= 0; }
		}

	    public int TotalTicksToMove{
            get { return totalTicksToMove; }
            set { totalTicksToMove = value; }
	    }

	    public bool ChallengeWhenArrive {
	        get { return challengeWhenArrive; }
	        set { challengeWhenArrive = value; }
	    }

		public bool UnloadCargo {
			get { return unloadCargo; }
			set { unloadCargo = value; }
		}

		public bool Flush {
			get { return flush; }
			set { flush = value; }
		}

		#endregion Properties

		#region Public

		public static FleetSectorMoveArgs Parse(string addictionalInformation) {
            string[] c = addictionalInformation.Split(lastSeparator, StringSplitOptions.RemoveEmptyEntries);
			string[] coords = c[0].Split(separator, StringSplitOptions.RemoveEmptyEntries);
			FleetSectorMoveArgs fleetArgs = new FleetSectorMoveArgs();
			fleetArgs.Source = new SectorCoordinate(new Coordinate(coords[0]), new Coordinate(coords[1]));
			fleetArgs.Destiny = new SectorCoordinate(new Coordinate(coords[2]), new Coordinate(coords[3]));
			fleetArgs.Pursuit = bool.Parse(coords[4]);
			fleetArgs.AttackWhenArrive = bool.Parse(coords[5]);
			fleetArgs.ConquerWhenArrive = bool.Parse(coords[6]);
			fleetArgs.Teletransporting = bool.Parse(coords[7]);
			fleetArgs.Follow = bool.Parse(coords[8]);
			fleetArgs.FleetToPursuitId = int.Parse(coords[9]);
			fleetArgs.WormHoleCoordinate = new SectorCoordinate(new Coordinate(coords[10]), new Coordinate(coords[11]));
			fleetArgs.UseUltimateWeapon = bool.Parse(coords[12]);	
			fleetArgs.TicksToMove = int.Parse(coords[13]);	
			fleetArgs.TotalTicksToMove = int.Parse(coords[14]);
			if (coords.Length > 15) {
				fleetArgs.ChallengeWhenArrive = bool.Parse(coords[15]);
			}
			if (coords.Length > 16) {
				fleetArgs.UnloadCargo = bool.Parse(coords[16]);
            }

		    if (c.Length > 1) {
                string[] lastCoords = c[1].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < lastCoords.Length; i+=2 ){
                    fleetArgs.LastCoordinate.Add(new SectorCoordinate(new Coordinate(lastCoords[i]), new Coordinate(lastCoords[i + 1])));
                }
			}
			return fleetArgs;
		}

		public override string ToString() {
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16}", Source.System, Source.Sector, Destiny.System, Destiny.Sector, Pursuit, AttackWhenArrive, ConquerWhenArrive, Teletransporting, Follow, FleetToPursuitId, WormHoleCoordinate.System, WormHoleCoordinate.Sector, UseUltimateWeapon, TicksToMove, TotalTicksToMove, ChallengeWhenArrive, UnloadCargo);
            if (LastCoordinate != null && LastCoordinate.Count > 0 ){
                builder.Append("|");
                foreach (SectorCoordinate c in LastCoordinate){
                    builder.AppendFormat("{0};{1};", c.System, c.Sector);    
                }
			}
			return builder.ToString();
		}

        public void AddLastCoordinate( SectorCoordinate coordinate){
            if( LastCoordinate.Count >= 8 ){
                LastCoordinate.RemoveAt(0);
            }
            LastCoordinate.Add(coordinate);
        }

		public void DecrementetTicksToMove() {
			--ticksToMove;
		}

		public void UpdateTicksToMove() {
            ticksToMove = TotalTicksToMove;
		}

		#endregion

		
	}
}
