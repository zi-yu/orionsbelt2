using System;
using System.Collections.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBelt.Chronos.Bots {
	static class Mobs {

		#region Fields

		private static readonly List<Principal> generals;
		private static readonly Principal Bot001;
		private static readonly Principal FiringSquad;
		private static readonly Random r = new Random((int)DateTime.Now.Ticks);
		private delegate void AddUnitsToFleet(IFleetInfo fleet);
		private static readonly Dictionary<string, AddUnitsToFleet> addUnitsContainer = new Dictionary<string, AddUnitsToFleet>();
		private delegate void AddResources(IFleetInfo fleet);
		private static readonly Dictionary<string, AddResources> addResourcesContainer = new Dictionary<string, AddResources>();
		private static readonly Dictionary<string, List<IResourceInfo>> resourcesContainer = new Dictionary<string, List<IResourceInfo>>();

        private static readonly Dictionary<int, List<SectorCoordinate>> systems = new Dictionary<int, List<SectorCoordinate>>();

		#endregion Fields

		#region Private

		public static Principal GetGeneralByName(string name) {
			return generals.Find(delegate(Principal p) { return p.Name == name; });
		}

		private static void GetOccupiedSectorCoordinate() {
            if (systems.Count == 0) {
                Console.Write("\t» Loading sectors....");
                List<object> sectors = (List<object>)Hql.StatelessQuery<object>("select s.SystemX, s.SystemY, s.SectorX, s.SectorY from SpecializedSectorStorage s");
                foreach (object sector in sectors) {
                    object[] s = (object[])sector;
                    SectorCoordinate sc = new SectorCoordinate((int)s[0], (int)s[1], (int)s[2], (int)s[3]);
                    int level = SectorUtils.GetLevel(sc.System);
                    if(!systems.ContainsKey(level)) {
                        systems[level] = new List<SectorCoordinate>();
                    }
                    systems[level].Add(sc);
                }
                Console.WriteLine("Done!");
            }
		}

		private static void AddFleet(string name, IPlayer player, int x, int y,int level) {
			Coordinate system = new Coordinate(x, y);
			int l = SectorUtils.GetLevel(system);
			if (level == l) {
				SectorCoordinate c = GetAvailableCoordinate(system, level);
				IFleetInfo fleet = SectorUtils.CreateFleetSectorForBot(c, player, name, level);
				addUnitsContainer[player.Name](fleet);
				Console.WriteLine("\t» Fleet created at coordinate {0}", c);
			}
		}

		private static void AddFleet(string name, IPlayer player, int x, int y, int level, string waypoints) {
			Coordinate system = new Coordinate(x, y);
			int l = SectorUtils.GetLevel(system);
			if (level == l) {
				SectorCoordinate c = GetAvailableCoordinate(system, level);
				IFleetInfo fleet = SectorUtils.CreateFleetSectorForBot(c, player, name, level);
				fleet.WayPoints = SectorUtils.ConvertWaypoints(waypoints);
				addUnitsContainer[player.Name](fleet);
				Console.WriteLine("\t» Fleet created at coordinate {0}", c);
			}
		}

		private static void RespawnFleet(IPlayer player, List<IFleetInfo> fleets, int level, int x, int y, IPersistanceSession persistance) {
			Coordinate system = new Coordinate(x, y);
			int l = SectorUtils.GetLevel(system);
			if (level == l) {
				IFleetInfo fleet = fleets.Find(delegate(IFleetInfo f) { return f.Location.System.X == system.X && f.Location.System.Y == system.Y; });
				if (fleet == null) {
					GetOccupiedSectorCoordinate();
					Console.Write("Creating Fleet at System {0}:{1}...", system.X, system.Y);
					AddFleet(player.Name, player, x, y, level);
					Console.WriteLine("DONE");
				}
			}
		}

		private static SectorCoordinate GetAvailableCoordinate(Coordinate c, int level) {
			SectorCoordinate sc = new SectorCoordinate(c, new Coordinate(0,0));
			while(true){
				sc.Sector.X = r.Next(1, 8);
				sc.Sector.Y = r.Next(1, 11);
				if(systems.ContainsKey(level) && !systems[level].Contains(sc)) {
					return sc;
				}
			}
		}

		private static void RespawnFactionFleets(IPersistanceSession persistance, IPlayer player, int startX1, int startX2) {
			List<IFleetInfo> fleets = player.Fleets;
			IFleetInfo levelFleet = fleets.Find(delegate(IFleetInfo f) { return f.Location.System.X != 0; });
			int level = SectorUtils.GetLevel(levelFleet.Location.System);
			for (int x = startX1; x < 37; x += 4) {
				for (int y = startX1; y < 37; y += 4) {
					RespawnFleet(player, fleets, level, x, y, persistance);
				}
			}

			for (int x = startX2; x < 37; x += 4) {
				for (int y = startX2; y < 37; y += 4) {
					RespawnFleet(player, fleets, level, x, y, persistance);
				}
			}

			GameEngine.Persist(player);
		}

		private static void AddCargo(IFleetInfo fleet, List<IResourceInfo> resources, int level) {
			int value = r.Next(0, 101);
			AddDroppableResource(fleet, resources);
			if( value <= 30 ) {
				AddDroppableResource(fleet, resources);
			}
			fleet.AddCargo(new ResourceQuantity(level));
			fleet.AddCargo(new ResourceQuantity(level));
		}

		private static void AddDroppableResource(IFleetInfo fleet, List<IResourceInfo> resources) {
			int value = r.Next(0, 101);
			int total = 0;
			foreach (IResourceInfo info in resources) {
				total += info.DropRate;
				if(total >= value ) {
					fleet.AddCargo(info, 1);
					break;
				}
			}
		}

		#endregion private
        	

		#region Delegates
		
		#region Add Units

		private static void AddUnitsMBLevel1Fleet(IFleetInfo fleet) {
			fleet.Add("Sentry", r.Next(3, 11));
			addResourcesContainer["Mercs"](fleet);
		}

		private static void AddUnitsMBLevel3Fleet(IFleetInfo fleet) {
			fleet.Add("Sentry", r.Next(10, 26));
			fleet.Add("Reaper", r.Next(3, 11));
            addResourcesContainer["Sentry Mercs"](fleet);
		}

		private static void AddUnitsMBLevel5Fleet(IFleetInfo fleet) {
			fleet.Add("Sentry", r.Next(26, 36));
			fleet.Add("Reaper", r.Next(15, 31));
			fleet.Add("Scourge", r.Next(5, 16));
            addResourcesContainer["Rogue Mercs"](fleet);
		}

		private static void AddUnitsMBLevel7Fleet(IFleetInfo fleet) {
			fleet.Add("Sentry", r.Next(76, 106));
			fleet.Add("Reaper", r.Next(30, 61));
			fleet.Add("Scourge", r.Next(15, 31));
            addResourcesContainer["Tech Mercs"](fleet);
		}

		private static void AddUnitsMBSilverBeardFleet(IFleetInfo fleet) {
			fleet.Add("Sentry", r.Next(100, 151));
			fleet.Add("Reaper", r.Next(60, 101));
			fleet.Add("Scourge", r.Next(30, 51));
			fleet.Add("Walker", r.Next(30, 51));
			fleet.Add("SilverBeard", 1);
            addResourcesContainer["Black Mercs"](fleet);
		} 

		private static void AddUnitsMBLevel9Fleet(IFleetInfo fleet) {
			fleet.Add("Sentry", r.Next(100, 151));
			fleet.Add("Reaper", r.Next(60, 101));
			fleet.Add("Scourge", r.Next(30, 51));
			fleet.Add("Walker", r.Next(30, 51));
		}

		private static void AddUnitsMBLevel10Fleet(IFleetInfo fleet) {
			fleet.Add("Sentry", r.Next(150, 250));
			fleet.Add("Reaper", r.Next(100, 130));
			fleet.Add("Scourge", r.Next(60, 81));
			fleet.Add("Walker", r.Next(60, 81));
			fleet.Add("Titan", r.Next(30, 51));
            addResourcesContainer["Dark Mercs"](fleet);
		}

		private static void AddUnitsMBMetallicBeardFleet(IFleetInfo fleet) {
			fleet.Add("Sentry", r.Next(150, 250));
			fleet.Add("Reaper", r.Next(100, 130));
			fleet.Add("Scourge", r.Next(60, 81));
			fleet.Add("Walker", r.Next(60, 81));
			fleet.Add("Titan", r.Next(30, 51));
			fleet.Add("MetallicBeard", 1);
		}

        private static void AddUnitsSFLevel1Fleet(IFleetInfo fleet) {
            fleet.Add("Jumper", r.Next(3, 11));
            addResourcesContainer["Alpha Force"](fleet);
        }

        private static void AddUnitsSFLevel3Fleet(IFleetInfo fleet) {
            fleet.Add("Jumper", r.Next(10, 26));
            fleet.Add("Myst", r.Next(3, 11));
            addResourcesContainer["Beta Force"](fleet);
        }

        private static void AddUnitsSFLevel5Fleet(IFleetInfo fleet) {
            fleet.Add("Jumper", r.Next(26, 36));
            fleet.Add("Myst", r.Next(15, 31));
            fleet.Add("Cypher", r.Next(5, 16));
            addResourcesContainer["Gamma Force"](fleet);
        }

        private static void AddUnitsSFLevel7Fleet(IFleetInfo fleet) {
            fleet.Add("Jumper", r.Next(76, 106));
            fleet.Add("Myst", r.Next(30, 61));
            fleet.Add("Cypher", r.Next(15, 31));
            addResourcesContainer["Delta Force"](fleet);
        }

        private static void AddUnitsSFCaptainWolfFleet(IFleetInfo fleet) {
            fleet.Add("Jumper", r.Next(100, 151));
            fleet.Add("Myst", r.Next(60, 101));
            fleet.Add("Cypher", r.Next(30, 51));
            fleet.Add("Crawler", r.Next(30, 51));
            fleet.Add("CommanderFox", 1);
        }

        private static void AddUnitsSFLevel9Fleet(IFleetInfo fleet) {
            fleet.Add("Jumper", r.Next(100, 151));
            fleet.Add("Myst", r.Next(60, 101));
            fleet.Add("Cypher", r.Next(30, 51));
            fleet.Add("Crawler", r.Next(30, 51));
            addResourcesContainer["Sigma Force"](fleet);
        }

        private static void AddUnitsSFLevel10Fleet(IFleetInfo fleet) {
            fleet.Add("Jumper", r.Next(150, 250));
            fleet.Add("Myst", r.Next(100, 130));
            fleet.Add("Cypher", r.Next(60, 81));
            fleet.Add("Crawler", r.Next(60, 81));
            fleet.Add("Fist", r.Next(30, 51));
            addResourcesContainer["Omega Force"](fleet);
        }

        private static void AddUnitsSFCommanderFoxFleet(IFleetInfo fleet) {
            fleet.Add("Jumper", r.Next(150, 250));
            fleet.Add("Myst", r.Next(100, 130));
            fleet.Add("Cypher", r.Next(60, 81));
            fleet.Add("Crawler", r.Next(60, 81));
            fleet.Add("Fist", r.Next(30, 51));
            fleet.Add("CaptainWolf", 1);
        } 

		#endregion Add Units

		#region Add Resources

		private static void AddResourcesMBLevel1Fleet(IFleetInfo fleet) {
			List<IResourceInfo> resources = resourcesContainer["Mercs"];
			AddCargo(fleet, resources,1);
		}

        private static void AddResourcesMBLevel3Fleet(IFleetInfo fleet) {
			List<IResourceInfo> resources = resourcesContainer["Sentry Mercs"];
			AddCargo(fleet, resources, 3);
		}

        private static void AddResourcesMBLevel5Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Rogue Mercs"];
            AddCargo(fleet, resources, 5);
        }

        private static void AddResourcesMBLevel7Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Tech Mercs"];
            AddCargo(fleet, resources, 7);
        }

        private static void AddResourcesMBLevel9Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Black Mercs"];
            AddCargo(fleet, resources, 9);
        }

        private static void AddResourcesMBLevel10Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Dark Mercs"];
            AddCargo(fleet, resources, 10);
        }

        private static void AddResourcesSFLevel1Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Alpha Force"];
            AddCargo(fleet, resources, 1);
        }

        private static void AddResourcesSFLevel3Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Beta Force"];
            AddCargo(fleet, resources, 3);
        }

        private static void AddResourcesSFLevel5Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Gamma Force"];
            AddCargo(fleet, resources, 5);
        }

        private static void AddResourcesSFLevel7Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Delta Force"];
            AddCargo(fleet, resources, 7);
        }

        private static void AddResourcesSFLevel9Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Sigma Force"];
            AddCargo(fleet, resources, 9);
        }

        private static void AddResourcesSFLevel10Fleet(IFleetInfo fleet) {
            List<IResourceInfo> resources = resourcesContainer["Omega Force"];
            AddCargo(fleet, resources, 10);
        }

		#endregion Add Resources

		#endregion Delegates

		#region Private

        private static AllianceStorage CreateMobAlliance(IPersistanceSession persistance, string description, string name) {
            using (IAllianceStoragePersistance alliancePersistance = Persistance.Instance.GetAllianceStoragePersistance(persistance)) {
                AllianceStorage alliance = alliancePersistance.Create();
                alliance.Description = description;
                alliance.Karma = 0;
                alliance.Language = "en";
                alliance.Name = name;
                alliance.TotalMembers = 6;
                alliance.OpenToNewMembers = false;
                alliancePersistance.Update(alliance);
                return alliance;
            }
        }

        private static Principal CreateMobPrincipal(IPersistanceSession persistance, string name) {
            using (IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance(persistance)) {
                Principal principal = principalPersistance.Create();
                principal.IsBot = true;
                principal.BotUrl = "http://localhost/Bots/RegisterBattle.ashx";
                principal.Name = name;
                principal.Password = "";
                principal.Email = "";
                principal.Approved = true;
                principal.ConfirmationCode = "";
                principal.RegistDate = DateTime.Now;
                principal.AvailableVacationTicks = 0;
                principal.EloRanking = 0;
                principal.AcceptedTerms = true;
                principal.IsInBattle = 0;
                principal.Credits = 0;
                principal.LadderActive = false;
                principalPersistance.Update(principal);
                return principal;
            }
        }

        #region Mercs

        private static AllianceStorage CreateMettalicBeardAlliance(IPersistanceSession persistance) {
            return CreateMobAlliance(persistance, "Prepare to be boarded!!!", "Metallic Beard");
		}

		private static Principal CreateMettalicBeardPrincipal(IPersistanceSession persistance) {
            return CreateMobPrincipal(persistance, "Metallic Beard");
		}

		private static void CreateMercs(string name, IPersistanceSession persistance, Principal principal, IAlliance alliance, int level) {
			Console.WriteLine("» Creating Mobs '{0}'", name);

			IPlayer player = GameEngine.CreatePlayer(principal, name, RaceInfo.Mercs);
			player.IsGeneralActive = true;
			player.GeneralId = Bot001.Id;
			player.GeneralName = Bot001.Name;
			player.GeneralFriendlyName = Bot001.Name;
			player.Alliance = alliance;
			player.PlanetLevel = 10;

            if( player.Fleets.Count > 1 ) {
                return;
            }
		
			for (int x = 1; x < 37; x += 4) {
				for (int y = 1; y < 37; y += 4) {
					AddFleet(name, player, x, y, level);
				}
			}

			for (int x = 3; x < 37; x += 4) {
				for (int y = 3; y < 37; y += 4) {
					AddFleet(name, player, x, y, level);
				}
			}

			GameEngine.Persist(player);
		}

		private static void CreateSilverBeard(IPersistanceSession persistance, Principal principal, IAlliance alliance) {
			string name = "Silver Beard";
			Console.WriteLine("» Creating Mob '{0}'", name);

			IPlayer player = GameEngine.CreatePlayer(principal, name, RaceInfo.Mercs);
			player.IsGeneralActive = true;
			player.GeneralId = Bot001.Id;
			player.GeneralName = Bot001.Name;
			player.GeneralFriendlyName = Bot001.Name;
			player.Alliance = alliance;
			player.PlanetLevel = 10;

			int x = r.Next(10,13);
			int y = r.Next(10,13);
            AddFleet(name, player, x, y, 7, "12_12;12_26;26_12;26_26;");
			
			GameEngine.Persist(player);
		}

		private static void CreateMetallicBeard(IPersistanceSession persistance, Principal principal, IAlliance alliance) {
			string name = "Metallic Beard";
			Console.WriteLine("» Creating Mob '{0}'", name);

			IPlayer player = GameEngine.CreatePlayer(principal, name, RaceInfo.Mercs);
			player.IsGeneralActive = true;
			player.GeneralId = Bot001.Id;
			player.GeneralName = Bot001.Name;
			player.GeneralFriendlyName = Bot001.Name;
			player.Alliance = alliance;
			player.PlanetLevel = 10;

			int x = r.Next(16,23);
			int y = r.Next(16,23);
            AddFleet(name, player, x, y, 10, "19_13;13_16;13_22;19_25;25_16;25_22;");
			
			GameEngine.Persist(player);
		}

		private static void RespawnMetallicBeardFleet(IPlayer player) {
			if (player.Fleets.Count == 0) {
				int x = r.Next(16, 23);
				int y = r.Next(16, 23);
				AddFleet("Metallic Beard", player, x, y, 10, "19_13;13_16;13_22;19_25;25_16;25_22;");
				GameEngine.Persist(player);
			}
        }
        
        #endregion Mercs

        #region Space Force

        private static AllianceStorage CreateSpaceForceAlliance(IPersistanceSession persistance) {
            return CreateMobAlliance(persistance, "To Protect and Defend", "Commander Fox");
        }

        private static Principal CreateCommanderFoxPrincipal(IPersistanceSession persistance) {
            return CreateMobPrincipal(persistance, "Captain Wolf");
        }

        private static void CreateSpaceForce(string name, IPersistanceSession persistance, Principal principal, IAlliance alliance, int level) {
            Console.WriteLine("» Creating Mobs '{0}'", name);

            IPlayer player = GameEngine.CreatePlayer(principal, name, RaceInfo.Mercs);
            player.IsGeneralActive = true;
            player.GeneralId = Bot001.Id;
            player.GeneralName = Bot001.Name;
            player.GeneralFriendlyName = Bot001.Name;
            player.Alliance = alliance;
            player.PlanetLevel = 10;

            if (player.Fleets.Count > 1) {
                return;
            }

            for (int x = 2; x < 37; x += 4) {
                for (int y = 2; y < 37; y += 4) {
                    AddFleet(name, player, x, y, level);
                }
            }

            for (int x = 4; x < 37; x += 4) {
                for (int y = 4; y < 37; y += 4) {
                    AddFleet(name, player, x, y, level);
                }
            }

            GameEngine.Persist(player);
        }

        private static void CreateCaptainWolf(IPersistanceSession persistance, Principal principal, IAlliance alliance) {
            string name = "Commander Fox";
            Console.WriteLine("» Creating Mob '{0}'", name);

            IPlayer player = GameEngine.CreatePlayer(principal, name, RaceInfo.SpaceForce);
            player.IsGeneralActive = true;
            player.GeneralId = Bot001.Id;
            player.GeneralName = Bot001.Name;
            player.GeneralFriendlyName = Bot001.Name;
            player.Alliance = alliance;
            player.PlanetLevel = 10;

            int x = r.Next(24, 28);
            int y = r.Next(24, 28);
            AddFleet(name, player, x, y, 7, "12_18;18_12;26_18;18_26;");

            GameEngine.Persist(player);
        }

        private static void CreateCommanderFox(IPersistanceSession persistance, Principal principal, IAlliance alliance) {
            string name = "Captain Wolf";
            Console.WriteLine("» Creating Mob '{0}'", name);

            IPlayer player = GameEngine.CreatePlayer(principal, name, RaceInfo.SpaceForce);
            player.IsGeneralActive = true;
            player.GeneralId = Bot001.Id;
            player.GeneralName = Bot001.Name;
            player.GeneralFriendlyName = Bot001.Name;
            player.Alliance = alliance;
            player.PlanetLevel = 10;

            int x = r.Next(16, 23);
            int y = r.Next(16, 23);
            AddFleet(name, player, x, y, 10, "13_13;16_16;16_22;13_25;25_13;19_16;19_22;25_25;");

            GameEngine.Persist(player);
        }

        private static void RespawnCaptainWolfFleet(IPlayer player) {
            if (player.Fleets.Count == 0) {
                int x = r.Next(16, 23);
                int y = r.Next(16, 23);
                AddFleet("Captain Wolf", player, x, y, 10, "13_13;16_16;16_22;13_25;25_13;19_16;19_22;25_25;");
                GameEngine.Persist(player);
            }
        }

        #endregion

        #endregion Private

        #region Public

        public static void CreateFactionMetallicBeard() {
			using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance()){
				persistance.StartTransaction();

				Principal principal = CreateMettalicBeardPrincipal(persistance);
				AllianceStorage a = CreateMettalicBeardAlliance(persistance);
				IAlliance alliance = AllianceManager.PrepareAlliance(a);

				persistance.CommitTransaction();

				CreateMercs("Mercs", persistance, principal, alliance,1);
				CreateMercs("Sentry Mercs", persistance, principal, alliance, 3);
				CreateMercs("Rogue Mercs", persistance, principal, alliance, 5);
				CreateMercs("Tech Mercs", persistance, principal, alliance, 7);
				CreateMercs("Black Mercs", persistance, principal, alliance, 9);
				CreateMercs("Dark Mercs", persistance, principal, alliance, 10);
				CreateSilverBeard(persistance, principal, alliance);
				CreateMetallicBeard(persistance, principal, alliance);

				persistance.Flush();
				
			}
		}

        public static void CreateFactionSpaceForce() {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance()) {
                persistance.StartTransaction();

                Principal principal = CreateCommanderFoxPrincipal(persistance);
                AllianceStorage a = CreateSpaceForceAlliance(persistance);
                IAlliance alliance = AllianceManager.PrepareAlliance(a);

                persistance.CommitTransaction();

                CreateSpaceForce("Alpha Force", persistance, principal, alliance, 1);
                CreateSpaceForce("Beta Force", persistance, principal, alliance, 3);
                CreateSpaceForce("Gamma Force", persistance, principal, alliance, 5);
                CreateSpaceForce("Delta Force", persistance, principal, alliance, 7);
                CreateSpaceForce("Sigma Force", persistance, principal, alliance, 9);
                CreateSpaceForce("Omega Force", persistance, principal, alliance, 10);
                CreateCaptainWolf(persistance, principal, alliance);
                CreateCommanderFox(persistance, principal, alliance);

                persistance.Flush();
            }
        }

		public static void RespawnMercs() {
			using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
				persistance.StartTransaction();
				IList<PlayerStorage> players = persistance.TypedQuery("select p from SpecializedPlayerStorage p inner join p.PrincipalNHibernate a where a.Name = 'Metallic Beard'");
				foreach (PlayerStorage playerStorage in players) {
					Console.WriteLine("Searching player '{0}' fleets...", playerStorage.Name);
					IPlayer player = PlayerUtils.LoadPlayer(playerStorage);
					if (player.Name == "Metallic Beard"){
						RespawnMetallicBeardFleet( player);
					}else {
						RespawnFactionFleets(persistance, player, 1, 3);
					}
					Console.WriteLine("Searching player '{0}' fleets Done!", playerStorage.Name);
				}
				persistance.CommitTransaction();
			}
		}

        public static void RespawnSpaceForce() {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
                persistance.StartTransaction();
                IList<PlayerStorage> players = persistance.TypedQuery("select p from SpecializedPlayerStorage p inner join p.PrincipalNHibernate a where a.Name = 'Commander Fox'");
                foreach (PlayerStorage playerStorage in players) {
                    Console.WriteLine("Searching player '{0}' fleets...", playerStorage.Name);
                    IPlayer player = PlayerUtils.LoadPlayer(playerStorage);
                    if (player.Name == "Commander Fox") {
                        RespawnCaptainWolfFleet(player);
                    } else {
                        RespawnFactionFleets(persistance, player, 2, 4);
                    }
                    Console.WriteLine("Searching player '{0}' fleets Done!", playerStorage.Name);
                }
                persistance.CommitTransaction();
            }
        }

		#endregion Public

		#region Constructor

		static Mobs() {
			generals = (List<Principal>)Hql.StatelessQuery<Principal>("select p from SpecializedPrincipal p where p.IsBot = 1 and p.BotUrl<>''");

			Bot001 = GetGeneralByName("Bot001");
			FiringSquad = GetGeneralByName("FiringSquad");

            GetOccupiedSectorCoordinate();

			addUnitsContainer.Add("Mercs", AddUnitsMBLevel1Fleet);
			addUnitsContainer.Add("Sentry Mercs", AddUnitsMBLevel3Fleet);
			addUnitsContainer.Add("Rogue Mercs", AddUnitsMBLevel5Fleet);
			addUnitsContainer.Add("Tech Mercs", AddUnitsMBLevel7Fleet);
			addUnitsContainer.Add("Black Mercs", AddUnitsMBLevel9Fleet);
			addUnitsContainer.Add("Dark Mercs", AddUnitsMBLevel10Fleet);
			addUnitsContainer.Add("Silver Beard", AddUnitsMBSilverBeardFleet);
			addUnitsContainer.Add("Metallic Beard", AddUnitsMBMetallicBeardFleet);

            resourcesContainer["Mercs"] = new List<IResourceInfo>(new IResourceInfo[] { PlasmaConduit.Resource, MercUniform.Resource, ElectricCircuit.Resource, PrimaryBoard.Resource, MercSpaceChart.Resource, Silicium.Resource });
            resourcesContainer["Sentry Mercs"] = new List<IResourceInfo>(new IResourceInfo[] { AirVent.Resource, Berilium.Resource, ExhaustionSystem.Resource, SentryMercSpaceChart.Resource, SentryMercUniform.Resource, SentryReactor.Resource });
            resourcesContainer["Rogue Mercs"] = new List<IResourceInfo>(new IResourceInfo[] { MedicalKit.Resource, NanoProbe.Resource, ReaperControlHelmet.Resource, ReaperPropulsionSystem.Resource, RogueMercSpaceChart.Resource, RogueMercUniform.Resource });
            resourcesContainer["Tech Mercs"] = new List<IResourceInfo>(new IResourceInfo[] { CarbonNanoTube.Resource, IonCannon.Resource, ReaperCoreSystem.Resource, ScourgeCoreSystem.Resource, TechMercSpaceChart.Resource, TechMercUniform.Resource });
            resourcesContainer["Black Mercs"] = new List<IResourceInfo>(new IResourceInfo[] { BlackMercSpaceChart.Resource, BlackMercUniform.Resource, DeutiriumEnergyCapsule.Resource, ScourgeControlPanel.Resource, ScourgePropulsionSystem.Resource, WalkerGiroBalancer.Resource });
            resourcesContainer["Dark Mercs"] = new List<IResourceInfo>(new IResourceInfo[] { DarkMercSpaceChart.Resource, DarkMercUniform.Resource, TitanControlHelmet.Resource, TitanTargetingSystem.Resource, TitanUnitronCannon.Resource, WalkerCore.Resource });

            addResourcesContainer["Mercs"] = AddResourcesMBLevel1Fleet;
            addResourcesContainer["Sentry Mercs"] = AddResourcesMBLevel3Fleet;
            addResourcesContainer["Rogue Mercs"] = AddResourcesMBLevel5Fleet;
            addResourcesContainer["Tech Mercs"] = AddResourcesMBLevel7Fleet;
            addResourcesContainer["Black Mercs"] = AddResourcesMBLevel9Fleet;
            addResourcesContainer["Dark Mercs"] = AddResourcesMBLevel10Fleet;

            //-----

            addUnitsContainer.Add("Alpha Force", AddUnitsSFLevel1Fleet);
            addUnitsContainer.Add("Beta Force", AddUnitsSFLevel3Fleet);
            addUnitsContainer.Add("Gamma Force", AddUnitsSFLevel5Fleet);
            addUnitsContainer.Add("Delta Force", AddUnitsSFLevel7Fleet);
            addUnitsContainer.Add("Sigma Force", AddUnitsSFLevel9Fleet);
            addUnitsContainer.Add("Omega Force", AddUnitsSFLevel10Fleet);
            addUnitsContainer.Add("Commander Fox", AddUnitsSFCommanderFoxFleet);
            addUnitsContainer.Add("Captain Wolf", AddUnitsSFCaptainWolfFleet);

            resourcesContainer["Alpha Force"] = new List<IResourceInfo>(new IResourceInfo[] { CriminalListAlpha.Resource, EscapePod.Resource, JumperReactor.Resource, JumperStabilizers.Resource, RedMatter.Resource, SpaceForceUniformAlpha.Resource });
            resourcesContainer["Beta Force"] = new List<IResourceInfo>(new IResourceInfo[] { CriminalListBeta.Resource, HolographicCube.Resource, MystPropulsionSystem.Resource, MystTargetingSystem.Resource, SpaceForceUniformBeta.Resource, SubSpaceSensors.Resource });
            resourcesContainer["Gamma Force"] = new List<IResourceInfo>(new IResourceInfo[] { CriminalListGamma.Resource, CommunicationsArray.Resource, SpaceForceUniformGamma.Resource, SubLightEngines.Resource, TacticalComputer.Resource});
            resourcesContainer["Delta Force"] = new List<IResourceInfo>(new IResourceInfo[] { CriminalListDelta.Resource, AntiMatterContainer.Resource, CommanderFoxShipSpecifications.Resource, GreyMatter.Resource, PositronContainer.Resource, SpaceForceUniformDelta.Resource, SpaceForceUniformDelta.Resource, TransportSystem.Resource });
            resourcesContainer["Sigma Force"] = new List<IResourceInfo>(new IResourceInfo[] { CriminalListSigma.Resource, BlueMatter.Resource, BlueMatterContainer.Resource, CrawlerGyroBalancer.Resource, CrawlerStaticPulse.Resource, CriminalListSigma.Resource, SpaceForceUniformSigma.Resource });
            resourcesContainer["Omega Force"] = new List<IResourceInfo>(new IResourceInfo[] { CriminalListOmega.Resource, DarkMatter.Resource, FistTargettingSystem.Resource, LightEngines.Resource, PositronCannon.Resource, SpaceForceUniformOmega.Resource });

            addResourcesContainer["Alpha Force"] = AddResourcesSFLevel1Fleet;
            addResourcesContainer["Beta Force"] = AddResourcesSFLevel3Fleet;
            addResourcesContainer["Gamma Force"] = AddResourcesSFLevel5Fleet;
            addResourcesContainer["Delta Force"] = AddResourcesSFLevel7Fleet;
            addResourcesContainer["Sigma Force"] = AddResourcesSFLevel9Fleet;
            addResourcesContainer["Omega Force"] = AddResourcesSFLevel10Fleet;
        }

        #endregion Constructor
    }
}
