using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;
using Loki.DataRepresentation;
using Loki.Generic;
using Loki.Generic.Metrics;
using Mono.GetOptions;
using OrionsBelt.BattleCore;
using OrionsBelt.Chronos.Bots;
using OrionsBelt.Chronos.Manual;
using OrionsBelt.Config;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.TournamentCore.TournamentCreators;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.PaymentSystems;

[assembly: Mono.UsageComplement("")]
[assembly: Mono.About("Orion's Belt Runner")]
[assembly: Mono.Author("ZI-YU.com")]

[assembly: AssemblyTitle("OrionsBelt.Chronos application")]
[assembly: AssemblyCopyright("(c) 2006 ZI-YU.com")]
[assembly: AssemblyDescription("Runner aplication for the OrionsBelt project")]

namespace OrionsBelt.Chronos {

    public class MainClass : Options {

        #region Main

        private static bool writeElapsed = true;
        public static void Main(string[] args)
        {
            try
            {
                SetLocalizationDirectory();
                DateTime start = DateTime.Now;
                MainClass options = new MainClass();
                if (args.Length == 0)
                {
                    args = new string[] {"-help"};
                }
                options.ProcessArgs(args);
                TimeSpan elapsed = DateTime.Now - start;
                if (writeElapsed) {
                    Console.WriteLine("#Elapsed: {0} seconds", elapsed.TotalSeconds);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void SetLocalizationDirectory()
        {
            LanguageManager.LanguageDirectory = Globals.AppendDirectory(AppDomain.CurrentDomain.BaseDirectory, "..", "Localization");
        }

        #endregion Main

        #region Static

        static MainClass()
        {
            Server.UsingInProcClock = true;
            Server.IsChronos = true;
        }

        public static string OutputDir {
            get {
                string path = typeof(MainClass).Assembly.CodeBase;
                path = new Uri(path).AbsolutePath;
                path = Path.GetDirectoryName(path);
                path = Path.Combine(path, "..");
                path = Path.Combine(path, "Data");
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                
                return path;
            }
        }

        public static string MetricsOutputDir {
            get {
                string path = Path.Combine(OutputDir, "Metrics");
                if(!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        #endregion Static

        #region Utils

        private static System.Threading.Timer timer = null;

        [Option("Sets the max execution time", "timeout")]
        public WhatToDoNext SetTimeout(int seconds)
        {
            Console.WriteLine("Setting the max execution time to: {0} seconds at {1}", seconds, DateTime.Now);

            timer = new System.Threading.Timer(delegate(object state) {
                Console.WriteLine("*** Max execution Time reached at {0}! Shutting down...", DateTime.Now);
                Environment.Exit(1);
            }, null, seconds * 1000, System.Threading.Timeout.Infinite);

            return WhatToDoNext.GoAhead;
        }

        #endregion Utils

        #region Tick

        [Option("Advances a tick on the server", "tick")]
        public WhatToDoNext RunTick()
        {
            Console.WriteLine("Running Orion's Belt Tick...");
            Console.WriteLine("- InProcClock: {0}", Server.UsingInProcClock);
            Console.WriteLine("- Clock: {0}", Clock.Instance.GetType().Name);

            Console.Write("» Initializing GameEngine... ");
            GameEngine.Init();
            Console.WriteLine("Done");

            Console.WriteLine("» Incrementing Tick, Current is: {0}... ", Clock.Instance.Tick);
            Clock.Instance.Advance();
            
            Console.WriteLine("» Orion's Belt Tick processing complete, new Tick: {0} ", Clock.Instance.Tick);

            Console.Write("» Disposing session... ");
            Persistance.CloseCurrentSession();
            Console.WriteLine("Done");

            return WhatToDoNext.GoAhead;
        }

        [Option("Advances a tick in the private zone on the server", "privatetick")]
        public WhatToDoNext RunPrivateTick()
        {
            Console.WriteLine("Running Orion's Belt Private Zone Tick...");

            PrivateFleetMovement movement = new PrivateFleetMovement();
            movement.Process();
            
            Persistance.CloseCurrentSession();
            Console.WriteLine("Done");

            return WhatToDoNext.GoAhead;
        }

        #endregion Tick

        #region Metrics

        [Option("Advances a tick on the server", "metrics")]
        public WhatToDoNext RunMetrics()
        {
            GameEngine.Init();
            Metrics.Log(typeof(GameEngine).Assembly, typeof(Persistance).Assembly);

            return WhatToDoNext.GoAhead;
        }

        #endregion Tick

		#region Script Generation Util Methods

		private static string HasSpecialMove(ICollection<ISpecialMove> moves, ISpecialMove move) {
			bool exists = moves.Contains(move);
			return exists ? "true" : "false";
		}

		public string HasStrikeBack(BaseUnit unit) {
			return HasSpecialMove(unit.DefenseMoves, StrikeBack.Instance);
		}

		public string HasTriple(BaseUnit unit) {
			return HasSpecialMove(unit.PosAttackMoves, Triple.Instance);
		}

		public string HasReplicator(BaseUnit unit) {
			return HasSpecialMove(unit.PosDefenseMoves, Replicator.Instance);
		}

		public string HasRemoveAbility(BaseUnit unit) {
			return HasSpecialMove(unit.PosAttackMoves, RemoveAbilityAttack.Instance);
		}

		public string HasBomb(BaseUnit unit) {
			return HasSpecialMove(unit.PosAttackMoves, BombAttack.Instance);
		}

		public string HasRebound(BaseUnit unit) {
			return HasSpecialMove(unit.PosAttackMoves, Rebound.Instance);
		}

		public string HasInfestation(BaseUnit unit) {
			return HasSpecialMove(unit.PosAttackMoves, InfestationAttack.Instance);
		}

		public string HasParalyse(BaseUnit unit) {
			return HasSpecialMove(unit.PosAttackMoves, ParalyseAttack.Instance);
		}

		public string GetAttackTargets(BaseUnit unit) {
			StringBuilder builder = new StringBuilder();
			Dictionary<string, IBonus> allBonus = unit.Bonus;
			int i = 0;
			foreach (KeyValuePair<string, IBonus> bonus in allBonus) {
				int attack = bonus.Value.GetAttack();
				if (attack != 0) {
					if (i != 0) {
						builder.AppendFormat(",'{0}':{1}\n", bonus.Key, attack);
					} else {
						builder.AppendFormat("'{0}':{1}\n", bonus.Key, attack);
					}
					++i;
				}
			}
			return builder.ToString();
		}

		public string GetDefenseTargets(BaseUnit unit) {
			StringBuilder builder = new StringBuilder();
			Dictionary<string, IBonus> allBonus = unit.Bonus;
			int i = 0;
			foreach (KeyValuePair<string, IBonus> bonus in allBonus) {
				int defense = bonus.Value.GetDefense();
				if (defense != 0) {
					if (i != 0) {
						builder.AppendFormat(",'{0}':{1}\n", bonus.Key, defense);
					} else {
						builder.AppendFormat("'{0}':{1}\n", bonus.Key, defense);
					}
					++i;
				}
			}
			return builder.ToString();
		}

		public string GetRangeTargets(BaseUnit unit) {
			StringBuilder builder = new StringBuilder();
			Dictionary<string, IBonus> allBonus = unit.Bonus;
			int i = 0;
			foreach (KeyValuePair<string, IBonus> bonus in allBonus) {
				int range = bonus.Value.GetRange();
				if (range != 0) {
					if (i != 0) {
						builder.AppendFormat(",'{0}':{1}\n", bonus.Key, range);
					} else {
						builder.AppendFormat("'{0}':{1}\n", bonus.Key, range);
					}
					++i;
				}
			}
			return builder.ToString();
		}

		#endregion Script Generation Util Methods

		#region Script Generation

		[Option("Generates Units Javascript file", "unitjs")]
		public WhatToDoNext UnitJS() {
			string path = "../../WebResources/Scripts";
            
			GenerateJsonUnits(path);
            GenerateUnitsXml(path);

			return WhatToDoNext.GoAhead;
		}

        private void GenerateUnitsXml(string path)
        {
            string file = Path.Combine(path, "Units.xml");
            using (TextWriter writer = new StreamWriter(file)) {
                writer.WriteLine("<Units Date='{0}'>", DateTime.Now.ToString("r"));
                foreach (IUnitInfo unit in Unit.Units) {
                    WriteUnitXml(writer, unit);
                }
                writer.WriteLine("</Units>");
            }
        }

        private void WriteUnitXml(TextWriter writer, IUnitInfo unit)
        {
            writer.WriteLine("\t<Unit Name='{0}' Code='{1}' Category='{2}' Attack='{3}' Defense='{4}' MovType='{5}' MovCost='{6}' AttackCost='{7}' Range='{8}' Level='{9}' Type='{10}' Cooldown='{11}'>", 
                    unit.Name, unit.Code, unit.UnitCategory, unit.Attack, unit.Defense, unit.MovementType, unit.MovementCost, unit.AttackCost, unit.Range, unit.UnitDisplacement, unit.UnitType, unit.CoolDown
                );

            WriteUnitBonus(writer, unit);
            WriteMoves(writer, unit, unit.DefenseMoves, "DefenseMoves");
            WriteMoves(writer, unit, unit.PosAttackMoves, "PosAttackMoves");
            WriteMoves(writer, unit, unit.PosDefenseMoves, "PosDefenseMoves");
            WriteAttackMoves(writer, unit);

            writer.WriteLine("\t</Unit>");
        }

        private void WriteAttackMoves(TextWriter writer, IUnitInfo unit)
        {
            if (unit.Catapult) {
                writer.WriteLine("\t\t<AttackMoves>");
                writer.WriteLine("\t\t\t<Move Type='Catapult'/>");
                writer.WriteLine("\t\t</AttackMoves>");
            }
        }

        private void WriteMoves(TextWriter writer, IUnitInfo unit, IList<ISpecialMove> moves, string label)
        {
            if (moves == null || moves.Count == 0) {
                return;
            }
            writer.WriteLine("\t\t<{0}>", label);
            WriteSpecialMoves(writer, unit, moves);
            writer.WriteLine("\t\t</{0}>", label);
        }

        private static void WriteSpecialMoves(TextWriter writer, IUnitInfo unit, IList<ISpecialMove> moves)
        {
            foreach (ISpecialMove move in moves) {
                writer.WriteLine("\t\t\t<Move Type='{0}'/>", move.GetType().Name);
            }
        }

        private void WriteUnitBonus(TextWriter writer, IUnitInfo unit)
        {
            if (unit.Bonus == null || unit.Bonus.Count == 0) {
                return;
            }
            writer.WriteLine("\t\t<Bonus>");
            foreach (KeyValuePair<string, IBonus> pair in unit.Bonus) {
                writer.WriteLine("\t\t\t<Bonus Target='{0}' Type='{1}' Attack='{2}' Defense='{3}' Range='{4}'/>", pair.Key, pair.Value.GetType().Name, pair.Value.GetAttack(), pair.Value.GetDefense(), pair.Value.GetRange());
            }
            writer.WriteLine("\t\t</Bonus>");
        }

		private void GenerateJsonUnits(string path) {
			Dictionary<string, object> args = new Dictionary<string, object>();
			args["units"] = Unit.Units;
			args["obj"] = this;

			string template = Path.Combine(path, "Units.vtl");
			string output = Path.Combine(path, "Units.js");

			Templates.Generate(null, template, output, true, args);
			Console.WriteLine("- Generated '{0}'", output);
		}

		#endregion Script Generation

		#region Universe Generation

		[Option("Creates a wormhole count", "wc")]
		public WhatToDoNext WormHoleCount() {
			UniverseCreation.CreateWormHoleCount();

			return WhatToDoNext.GoAhead;
		}

    	[Option("Generates the Universe", "gu")]
		public WhatToDoNext GenerateUniverse() {
			DateTime start = DateTime.Now;
			Server.UsingInProcClock = false;
			int x = 38, y = 38;
			for (int i = 1; i < x; ++i ) {
				UniverseCreation.CreateUniverse(i, y);
			}

			UniverseCreation.CreateWormHoleCount();

			Console.WriteLine("» Universe created in : {0}ms", (DateTime.Now - start).TotalMilliseconds);
			return WhatToDoNext.GoAhead;
		}

		[Option("Generates the Universe", "gf")]
		public WhatToDoNext GenerateDummyFLeets() {
			UniverseCreation.GenerateDummyFleets();
			
			Console.WriteLine("DONE");

			return WhatToDoNext.GoAhead;
		}

        [Option("Remove inactive fleets from the universe", "rif")]
        public WhatToDoNext RemoveInactiveFleets() {
            UniverseMaid.RemoveInactiveFleets();
            Console.ReadLine();
            return WhatToDoNext.GoAhead;
        }

		#endregion Universe Generation

        #region Manual

        [Option("Generates the Documentation", "docs")]
        public WhatToDoNext GenerateManul(string output)
        {
            if (string.IsNullOrEmpty(output)) {
                throw new Exception("Please provide the documentation output directory");
            }
            GameManual.Generate(output);
            return WhatToDoNext.GoAhead;
        }

        #endregion Manual

        #region Tournament Test

        [Option("Create fleet", "cf")]
        public WhatToDoNext CreateFleet(string number)
        {

            Fleet fleet;

            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                fleet = persistance.Create();
                fleet.TournamentFleet = true;
                fleet.Name = "Test Fleet";
                fleet.Units = "r-100;dr-1003;kr-50;d-300;t-40;b-40;f-50";
                persistance.Update(fleet);
                persistance.Flush();
                FileLogger.WriteLine("Fleet ID:{0}", fleet.Id);
            }
            return WhatToDoNext.GoAhead;
        }

        [Option("Create tournament", "ct")]
        public WhatToDoNext CreateTournament(string number)
        {
            
            int playersNumbers = 100;
            if (!string.IsNullOrEmpty(number))
            {
                playersNumbers = Convert.ToInt32(number);
            }
            FileLogger.WriteLine("Simulating tournament...");

            List<Principal> prins = new List<Principal>();
            List<PrincipalTournament> regists = new List<PrincipalTournament>();

            FileLogger.WriteLine("Creating Players...");

            CreatePrincipals(prins, playersNumbers);

            FileLogger.WriteLine("Flushing principals");
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                persistance.Flush();
            }
            FileLogger.WriteLine("Creating Tournament...");

            Fleet fleet;
            Tournament tournament;

            CreateTournament(out fleet, out tournament);

            FileLogger.WriteLine("Tournament ID:{0}", tournament.Id);
            FileLogger.WriteLine("Registering players in tournament...");

            RegistPlayers(prins, regists, tournament);
            
            FileLogger.WriteLine("Players registered.");
            /*
            Fleet fleet;
            IList<PrincipalTournament> regists;
            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                fleet = persistance.SelectById(1)[0];
            }
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                regists = persistance.Select();
            }
            */         
            //FleetInfo fi = new FleetInfo(fleet);
            TournamentManager.BeginTournament(tournament.Id);
            FileLogger.WriteLine("Groups created.");

            return WhatToDoNext.GoAhead;
        }

        [Option("Create team tournament", "ctt")]
        public WhatToDoNext CreateTeamTournament(string number)
        {
            int playersNumbers = 100;
            if (!string.IsNullOrEmpty(number))
            {
                playersNumbers = Convert.ToInt32(number);
            }
            FileLogger.WriteLine("Simulating tournament...");

            List<Principal> prins = new List<Principal>();
            List<PrincipalTournament> regists = new List<PrincipalTournament>();

            FileLogger.WriteLine("Creating Players...");

            CreatePrincipals(prins, playersNumbers);

            FileLogger.WriteLine("Flushing principals");
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                persistance.Flush();
            }

            FileLogger.WriteLine("Creating Teams...");
            List<TeamStorage> teams = CreateTeams(prins);

            
            FileLogger.WriteLine("Creating Tournament...");

            Fleet fleet;
            Tournament tournament;

            CreateTournament(out fleet, out tournament);

            FileLogger.WriteLine("Tournament ID:{0}", tournament.Id);

            FileLogger.WriteLine("Registering teams in tournament...");

            RegistTeams(teams, regists, tournament);

            FileLogger.WriteLine("Players registered.");
            /*
            Fleet fleet;
            IList<PrincipalTournament> regists;
            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                fleet = persistance.SelectById(1)[0];
            }
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                regists = persistance.Select();
            }
            */

            
            FleetInfo fi = new FleetInfo(fleet);
            TournamentManager.BeginTeamTournament(regists, 0, fi, BattleType.TotalAnnihalation4, tournament);
            FileLogger.WriteLine("Groups created.");
            

            return WhatToDoNext.GoAhead;
        }

        [Option("Simulate Battles", "sb")]
        public WhatToDoNext SimulateBattles(string tourId)
        {
            int stage;
            int tournamentId = 1;
            if (!string.IsNullOrEmpty(tourId))
            {
                tournamentId = Convert.ToInt32(tourId);
            }

            FileLogger.WriteLine("Writing groups...");

            IList<PlayersGroupStorage> groups;
            using (IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance())
            {
                IList ret = persistance.Query("select max(g.EliminatoryNumber) from SpecializedPlayersGroupStorage g where g.TournamentNHibernate.Id = {0}", tournamentId);
                stage =  Convert.ToInt32(ret[0]); 
                
                groups =
                    persistance.TypedQuery(
                        "from SpecializedPlayersGroupStorage g where g.TournamentNHibernate.Id = {0} and g.EliminatoryNumber={1}",
                        tournamentId, stage);
            }

            foreach (PlayersGroupStorage group in groups)
            {
                FileLogger.WriteLine("\t»»Group {0}««", group.GroupNumber);
                FileLogger.WriteLine("\t\t>>Players: {0}", group.PlayersIds);
                SimulateResults(group.Battles);
                WriteGroupClassification(group, stage);
            }

            return WhatToDoNext.GoAhead;
        }

        [Option("Simulate Team Battles", "sbt")]
        public WhatToDoNext SimulateTeamBattles(string tourId)
        {
            int stage;
            int tournamentId = 1;
            if (!string.IsNullOrEmpty(tourId))
            {
                tournamentId = Convert.ToInt32(tourId);
            }

            FileLogger.WriteLine("Writing groups...");

            IList<PlayersGroupStorage> groups;
            using (IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance())
            {
                IList ret = persistance.Query("select max(g.EliminatoryNumber) from SpecializedPlayersGroupStorage g where g.TournamentNHibernate.Id = {0}", tournamentId);
                stage = Convert.ToInt32(ret[0]);

                groups =
                    persistance.TypedQuery(
                        "from SpecializedPlayersGroupStorage g where g.TournamentNHibernate.Id = {0} and g.EliminatoryNumber={1}",
                        tournamentId, stage);
                persistance.Clear();
            }

            foreach (PlayersGroupStorage group in groups)
            {
                FileLogger.WriteLine("\t»»Group {0}««", group.GroupNumber);
                FileLogger.WriteLine("\t\t>>Teams: {0}", group.PlayersIds);
                SimulateTeamsResults(group.Battles);
                WriteGroupClassification(group, stage);
            }

            return WhatToDoNext.GoAhead;
        }

        [Option("Simulate Playoff fase", "sp")]
        public WhatToDoNext SimulatePlayoffBattles(string tourId)
        {
            FileLogger.WriteLine("Getting battles...");

            int tournamentId = 1;
            if (!string.IsNullOrEmpty(tourId))
            {
                tournamentId = Convert.ToInt32(tourId);
            }

            IList<Battle> battles;
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                battles =
                    persistance.TypedQuery(
                        "from SpecializedBattle g where g.TournamentNHibernate.Id = {0} and g.HasEnded=0", tournamentId);
            }

            SimulateResults(battles);

            return WhatToDoNext.GoAhead;
        }

        [Option("Simulate Playoff team fase", "spt")]
        public WhatToDoNext SimulatePlayoffTeamsBattles(string tourId)
        {
            FileLogger.WriteLine("Getting battles...");

            int tournamentId = 1;
            if (!string.IsNullOrEmpty(tourId))
            {
                tournamentId = Convert.ToInt32(tourId);
            }

            IList<Battle> battles;
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                battles =
                    persistance.TypedQuery(
                        "from SpecializedBattle g where g.TournamentNHibernate.Id = {0} and g.HasEnded=0", tournamentId);
            }

            SimulateTeamsResults(battles);

            return WhatToDoNext.GoAhead;
        }

        [Option("Advance Stage", "as")]
        public WhatToDoNext AdvanceStage(string tourId)
        {
            FileLogger.WriteLine("Process tournament...");

            int tournamentId = 1;
            if (!string.IsNullOrEmpty(tourId))
            {
                tournamentId = Convert.ToInt32(tourId);
            }
            TournamentManager.ProcessTournament(tournamentId);

            return WhatToDoNext.GoAhead;
        }

        private static void SimulateResults(IEnumerable<Battle> battles)
        {
            foreach (Battle battle in battles)
            {
                IList<Principal> principals = GetPlayers(battle);
                PositionUnits(battle, principals[0], principals[1]);
                int giveup = DateTime.Now.Millisecond % 2;
                FileLogger.WriteLine("Battle:{0}; Player1:{1}; Player2:{2}",
                                     battle.Id, principals[0].Id, principals[1].Id);
                BattleManager.GiveUp(principals[giveup], battle);
                FileLogger.WriteLine("Player {0} gave up", principals[giveup].Id);
            }
        }

        private static void WriteGroupClassification(PlayersGroupStorage list, int stage)
        {
            string[] ids = list.PlayersIds.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            IList<PrincipalTournament> players;
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                players = persistance.TypedQuery("select e from SpecializedPrincipalTournament e where {0}", BuildIdsOr(ids));
            }

            List<GroupPlayer> group = new List<GroupPlayer>(10);
            foreach (PrincipalTournament player in players)
            {
                group.Add(new GroupPlayer(player, stage, players.Count));
            }
            group.Sort();
            FileLogger.WriteLine("\t»»Classification:««");
            foreach (GroupPlayer player in group)
            {
                FileLogger.WriteLine("\tPrincipalTournament:{0} -> {1}", player.Player.Id, player.Points);
            }
        }

        private static void SimulateTeamsResults(IEnumerable<Battle> battles)
        {
            foreach (Battle battle in battles)
            {
                IList<Principal> principals = GetTeamPlayers(battle);
                PositionTeamUnits(battle, principals);

                int giveup = DateTime.Now.Millisecond % 2;
                FileLogger.WriteLine("Battle:{0}; Team1:{1}|{2}; Team2:{3}|{4}",
                                     battle.Id, principals[0].Id, principals[1].Id
                                     , principals[2].Id, principals[3].Id);
                int giveup1, giveup2;
                if (giveup == 0)
                {
                    giveup1 = 0;
                    giveup2 = 1;
                }
                else
                {
                    giveup1 = 2;
                    giveup2 = 3;
                }
                BattleManager.GiveUp(principals[giveup1], battle);
                BattleManager.GiveUp(principals[giveup2], battle);
                FileLogger.WriteLine("Player {0} and {1} gave up", principals[giveup1].Id, principals[giveup2].Id);
            }
        }

        private static string BuildIdsOr(string[] ids)
        {
            StringBuilder toReturn = new StringBuilder();
            for (int iter = 0; iter < ids.Length; ++iter)
            {
                toReturn.Append(" e.PrincipalNHibernate.Id=");
                toReturn.Append(ids[iter]);
                if (iter + 1 < ids.Length)
                    toReturn.Append(" or ");
            }
            return toReturn.ToString();
        }

        private static IList<Principal> GetPlayers(Battle battle)
        {
            IList<Principal> toReturn;
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                toReturn = persistance.TypedQuery("from SpecializedPrincipal g where g.Id = {0} or g.Id={1}", 
                    battle.PlayerInformation[0].Owner, battle.PlayerInformation[1].Owner);
            }
            return toReturn;
        }

        private static IList<Principal> GetTeamPlayers(Battle battle)
        {
            IList<Principal> toReturn;
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                toReturn = persistance.TypedQuery("from SpecializedPrincipal g where g.Id = {0} or g.Id={1} or g.Id={2} or g.Id={3}",
                    battle.PlayerInformation[0].Owner, battle.PlayerInformation[1].Owner, battle.PlayerInformation[2].Owner, battle.PlayerInformation[3].Owner);
            }
            return toReturn;
        }

        private static void PositionUnits(Battle battle, Principal p1, Principal p2)
        {
            string movements = "p:kr-7_1-50;p:t-7_3-40;p:f-7_4-50;";
            BattleManager.DeployUnits(p1, movements, battle);
            //movements = "p:r-7_7-100;p:fg-7_6-1;";
            BattleManager.DeployUnits(p2, movements, battle);

        }

        private static void PositionTeamUnits(Battle battle, IList<Principal> prins)
        {
            string movements = "p:r-11_3-100;";
            BattleManager.DeployUnits(prins[0], movements, battle);
            BattleManager.DeployUnits(prins[1], movements, battle);
            BattleManager.DeployUnits(prins[2], movements, battle);
            BattleManager.DeployUnits(prins[3], movements, battle);
        }

        private static void RegistPlayers(IList<Principal> prins, ICollection<PrincipalTournament> regists, IEntity tournament)
        {
            for (int iter = 0; iter < prins.Count; ++iter)
            {
                regists.Add(TournamentManager.RegistPlayer(prins[iter], tournament.Id));
                if (iter % 100 == 0)
                {
                    FileLogger.WriteLine("Date:{0}; Registered {1} principals", DateTime.Now, iter);
                    using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
                    {
                        persistance.Clear();
                    }
                }
            }
        }

        private static void RegistTeams(IList<TeamStorage> teams, ICollection<PrincipalTournament> regists, IEntity tournament)
        {
            for (int iter = 0; iter < teams.Count; ++iter)
            {
                regists.Add(TournamentManager.RegistTeam(teams[iter], tournament.Id));
                if (iter % 100 == 0)
                {
                    FileLogger.WriteLine("Date:{0}; Registered {1} principals", DateTime.Now, iter);
                    using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
                    {
                        persistance.Clear();
                    }
                }
            }
        }

        private static void CreateTournament(out Fleet fleet, out Tournament tournament)
        {

            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                fleet = persistance.Create();
                fleet.TournamentFleet = true;
                fleet.Name = "Test Fleet";
                fleet.Units = "kr-50;t-40;f-50";
                //fleet.Units = "r-100";//"dr-1003;kr-50;d-300;t-40;b-40;f-50";
                persistance.Update(fleet);
                persistance.Flush();
                FileLogger.WriteLine("Fleet ID:{0}", fleet.Id);
            }
            tournament = TournamentManager.CreateAnnihalationTournament("Generated Tournament","Unleash hell", 0, fleet.Id,
                                                             true, false, 144, 0, 0, 0, 64, 0,0,true);
        }

        private static void CreatePrincipals(ICollection<Principal> prins, int number)
        {
            for (int iter = 0; iter < number; ++iter)
            {
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    Principal p1 = persistance.Create();
                    p1.Name = "SLB___" + iter;
                    p1.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("spoon", "sha1");
                    p1.EloRanking = 30000 - iter;
                    persistance.Update(p1);
                    prins.Add(p1);
                    if (iter % 50 == 0)
                    {
                        FileLogger.WriteLine("Date:{0}; Processed {1} principals", DateTime.Now, iter);
                        using (IPersistanceSession save = Persistance.Instance.GetGenericPersistance())
                        {
                            save.Clear();
                        }
                    }
                }
            }
        }

        private static List<TeamStorage> CreateTeams(IList<Principal> prins)
        {
            List<TeamStorage> toReturn = new List<TeamStorage>(prins.Count/2);
            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
            {
                for (int iter = 0; iter < prins.Count;++iter)
                {
                    TeamStorage team = persistance.Create();
                    team.Name = "T" + iter;
                    team.EloRanking = 1000 - iter;
                    team.Principals.Add(prins[iter]);
                    team.Principals.Add(prins[++iter]);
                    persistance.Update(team);

                    toReturn.Add(team);

                    using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                    {
                        prins[iter].Team = team;
                        prins[iter-1].Team = team;
                        persistance2.Update(prins[iter]);
                        persistance2.Update(prins[iter-1]);
                    }
                }
                persistance.Flush();
            }
            return toReturn;
        }

        #endregion Tournament Test

        #region Tournament

        [Option("Create Tournament Bots", "ctb")]
        public WhatToDoNext CreateTournamentBots()
        {
            string [] names = new string[]{"amplif","andykhs","Aqualung","Baldvin","BassMan","belanna","Boyer_Coe",
                "Celestial_Avatar","Chuck-B","Commissioner","crash","cyberjester","Damian","Dick","dworaczek","fiesto",
                "Hannibal","htimda","Igge","inzmtns","jokerus","jwalsh","l.eldridge","LadyAmnesty","Lenin","lorddefile",
                "mac","Magictape","Mallorean","mars","Martin","Maverick","mcverry","MSphreak","musicman","Napoleon","ninel",
                "pdanny","Pgh.Joe","prasident","ramo","reaf1","S_John_M","sbain","SnowSong","stefan","The_Unknown_Soldier",
                "TheCo","theeagle","theleper","toenut","toma","Tommo","virtualdrummer","wind","xmatrix","Zaphod",
            	"bigdelicious","smokeyuk","sMull","snowcrash512","SnW","rennegadesnw","SocialDefect","Solidus_Snake",
                "Nellyvan","someonescop","spammy250","Splizxer","Sr8Fr4gging","ooghij123","SRCLINTON","Supertribe","TBUG",
                "tatianaw","Tidy_Sammy","ArilehnNhelira","Axis101a","Babinnes","Pyrelly","BandofBrothers","marty1213",
                "bd_braindead","bdrob","BennoUK","bigspoon","spoony77","bobadidlio","Bomberman","thebdaman","Boondock_Saint",
                "thespeckonyournose","Bucken77","chunkylover78","kingpins","bloodthrust","IeatNvidiots","legi0naire",
                "linnyloo","titanrocks" };

            IList<Principal> principals = CreatePrincipals(names);

            RegistInTournament(principals);

            return WhatToDoNext.GoAhead;
        }

        private void RegistInTournament(IList<Principal> principals)
        {
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                Tournament t;
                using (ITournamentPersistance persistance2 = Persistance.Instance.GetTournamentPersistance(persistance))
                {
                    t = persistance2.SelectByName("Intergalatic Tournament")[0];
                }
                foreach (Principal principal in principals)
                {
                    PrincipalTournament pt = persistance.Create();
                    pt.HasEliminated = false;
                    pt.Principal = principal;
                    pt.Tournament = t;

                    persistance.Update(pt);
                }
                
                persistance.Flush();
            }
        }

        private IList<Principal> CreatePrincipals(string[] names)
        {
            IList<Principal> toReturn = new List<Principal>(names.Length);
            string[] bots = new string[] { "FiringSquad", "Bot001", "FiringSquadBeta" };
            string[] codes = new string[] { "E8BD19CF9C5353ACA15D5DCB1EE4AA8E710F8CAE",
                                            "5F53F9E1D0BEEA2EBF4FB2779E422C7AA98B60D1",
                                            "A445F2CAE34AC46C29CA5E3F4A9CE2012B2D1EE6"};

            IList<string> avatars = new List<string>();
            avatars.Add("Avatar");

            foreach (IUnitInfo unit in RulesUtils.GetUnitResources())
            {
                avatars.Add("Units/"+unit.Name.ToLower());
            }
            foreach (IIntrinsicInfo resource in RulesUtils.GetIntrinsicNonConceptualResources())
            {
                avatars.Add("Resources/" + resource.Name);
            }
            using (IBotCredentialPersistance persistance2 = Persistance.Instance.GetBotCredentialPersistance())
            {
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance(persistance2))
                {
                    Random r = new Random();
                    foreach (string name in names)
                    {
                        Principal prin = persistance.Create();
                        prin.Name = name;
                        prin.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("spoon", "sha1");
                        prin.AcceptedTerms = true;
                        prin.Approved = true;
                        prin.Avatar = "http://pdm.velocix.orionsbelt.eu/Images/Common/"+avatars[r.Next(0,avatars.Count)]+".png";
                        prin.BotUrl = "http://localhost:2222/RegisterBattle.ashx";
                        //prin.BotUrl = "http://bots.orionsbelt.eu/RegisterBattle.ashx";
                        prin.CanChangeName = false;
                        prin.Credits = 0;
                        prin.EloRanking = 1000;
                        prin.IsBot = true;
                        prin.LadderActive = false;
                        prin.Locked = false;
                        prin.RegistDate = DateTime.Now.AddDays(-r.Next(0, 60));
                        prin.CreatedDate = prin.RegistDate;

                        persistance.Update(prin);
                        toReturn.Add(prin);

                        CreateBotCredencial(persistance2, prin, r, bots, codes);
                    }
                    persistance.Flush();
                }
            }

            return toReturn;
        }

        private void CreateBotCredencial(IBotCredentialPersistance persistance2, Principal prin, Random r, string[] bots, string[] codes)
        {
            BotCredential cred = persistance2.Create();
            cred.BotId = prin.Id;
            int rand = r.Next(0, 3);
            cred.Name = bots[rand];
            cred.VerificationCode = codes[rand];
            //cred.Server = "http://s1.orionsbelt.eu/";
            cred.Server = "http://localhost:2222/";
            persistance2.Update(cred);
        }

        [Option("Process Tournament", "pt")]
        public WhatToDoNext ProcessTournament()
        {
            //FileStream fs = GetFileToLog();
            //StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Date={0}; Tick={1}", DateTime.Now, Clock.Instance.Tick);

            IList<Tournament> tournaments = GetTournaments();

            foreach (Tournament tournament in tournaments)
            {
                if (tournament.Token == "XLPartyTournament" && DateTime.Now < (new DateTime(2010, 3, 26, 20, 0, 0)))
                {
                    continue;
                }
                if(tournament.StartTime == tournament.CreatedDate)
                {
                    ProcessNotStartedTournament(tournament);
                }
                else
                {
                    ProcessStartedTournament(tournament);
                }   
            }
            //sw.Close();
            //fs.Close();
            return WhatToDoNext.GoAhead;
        }

        [Option("Process Groups", "pgs")]
        public WhatToDoNext ProcessGroup(int idTour)
        {
            //FileStream fs = GetFileToLog();
            //StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Date={0}; Tick={1}", DateTime.Now, Clock.Instance.Tick);

            IList<PlayersGroupStorage> groups;
            using (IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance())
            {
                groups =
                    persistance.TypedQuery(
                        "select e from SpecializedPlayersGroupStorage e where e.TournamentNHibernate.Id={0}", idTour);
            }
            IList<List<Principal>> principals = new List<List<Principal>>(groups.Count);
            using (IPrincipalPersistance persistance1 = Persistance.Instance.GetPrincipalPersistance())
            {
                string ors="";
                foreach (PlayersGroupStorage group in groups)
                {
                    string[] ids = group.PlayersIds.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);

                     ors = BuidOrs(ids);
                     IList<Principal> principal = persistance1.TypedQuery("select e from SpecializedPrincipal e where {0}", ors);
                     principals.Add((List<Principal>)principal);
                }
                
            }
            Tournament tour;
            Fleet fleet;
            using (ITournamentPersistance persistance1 = Persistance.Instance.GetTournamentPersistance())
            {
                tour = persistance1.SelectById(idTour)[0];
                using (IFleetPersistance persistance2 = Persistance.Instance.GetFleetPersistance(persistance1))
                {
                    fleet = persistance2.SelectById(tour.FleetId)[0];
                }
            }

            IFleetInfo fInfo = new FleetInfo(fleet);

            TournamentManager.CreateGroupBattles(principals,groups,fInfo,BattleType.TotalAnnihalation,0,tour);
            
            return WhatToDoNext.GoAhead;
        }

        private string BuidOrs(string[] ids)
        {
            string toReturn="";

            for(int iter=0; iter < ids.Length; ++iter)
            {
                if(iter != 0)
                {
                    toReturn += string.Format(" or e.Id={0} ", ids[iter]);
                }
                else
                {
                    toReturn += string.Format(" e.Id={0} ", ids[iter]);
                }
            }
            return toReturn;
        }

        private static void ProcessStartedTournament(Tournament tournament)
        {
            Console.WriteLine("Tournament {0} already start", tournament.Id);
            ITournamentCreator creator = new AnnihalationCreator();
            if (creator.IsInGroupStage(tournament.Id))
            {
                Console.WriteLine("\tIs in group stage");
                int unfinish = creator.GetLastGroupStageUnfinishBatlleNum(tournament);
                Console.WriteLine("\tNumber of unfinish battles: {0}", unfinish);
                if (0 == unfinish)
                {
                    Console.WriteLine("\t\tStarting new stage in tournament {0}", tournament.Id);
                    TournamentManager.ProcessTournament(tournament.Id);
                }
            }
            else
            {
                Console.WriteLine("\tIs in playoff stage");
                int unfinish = creator.GetLastStageUnfinishBatlleNum(tournament);
                Console.WriteLine("\tNumber of unfinish battles: {0}", unfinish);
                if(0 == unfinish)
                {
                    Console.WriteLine("\t\tStarting new playoff stage in tournament {0}", tournament.Id);
                    TournamentManager.ProcessTournament(tournament.Id);
                }
            }
        }

        private static void ProcessNotStartedTournament(Tournament tournament)
        {
            Console.WriteLine("Tournament {0} didn't start", tournament.Id);
            if(tournament.WarningTick == 0)
            {
                using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
                {
                    Console.WriteLine("\tSending warning to players in tournament {0}", tournament.Id);
                    SendWarnings(tournament);

                    //arrancar o torneio em 3 dias (-10 ticks para garantir 
                    //que quando o processo correr passados 3 dias arranca o torneio)
                    tournament.WarningTick = Clock.Instance.EndTickByDelay(
                        Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)) - 10);
                    persistance.Update(tournament);
                    persistance.Flush();
                }
            }
            else
            {
                Console.WriteLine("\tCurr Tick={0}; EndWarnigPeriod={1}", Clock.Instance.Tick, tournament.WarningTick);
                if(Clock.Instance.Tick > tournament.WarningTick)
                {
                    Console.WriteLine("\tStarting tournament {0}", tournament.Id);
                    TournamentManager.BeginTournament(tournament.Id);
                }
            }
        }

        private static IList<Tournament> GetTournaments()
        {
            IList<Tournament> tournaments;
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tournaments =
                    persistance.TypedQuery(
                        "SELECT t FROM SpecializedTournament t where t.EndDate=t.CreatedDate and t.MinPlayers <= (SELECT count(pt) FROM SpecializedPrincipalTournament pt where pt.TournamentNHibernate.Id = t.Id) and t.SubscriptionTime < {0}",
                        Clock.Instance.Tick);
            }
            return tournaments;
        }

        private static FileStream GetFileToLog()
        {
            if (!Directory.Exists("TournamentProcessLog"))
            {
                Directory.CreateDirectory("TournamentProcessLog");
            }

            string filePath = string.Format("TournamentProcessLog/{0}{1}{2}_Log.log",
                                            DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);


        }

        private static void SendWarnings(Tournament tour)
        {
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                persistance.SelectByTournament(tour);
            }
            // TODO
            Messenger.Add(new TournamentWarning(tour.Name,Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)))),true);
        }

        #endregion Tournament

        #region Tournament Delete

        [Option("Deletes all Battles of all Tournaments", "delTour")]
        public WhatToDoNext DeletesAllTournaments(){
            IList<Battle> battlesToDelete = Hql.Query<Battle>("select b from SpecializedBattle b where b.BattleMode = 'Tournament' and b.TournamentMode = 'Normal'");
            foreach (Battle battle in battlesToDelete){
                BattlePersistance.DeleteBattle(battle);
            }
            Persistance.Flush();
            return WhatToDoNext.GoAhead; 
        }

		[Option("Deletes a Battle", "delBattle")]
		public WhatToDoNext DeleteBattle(string id) {
			IList<Battle> battlesToDelete = Hql.Query<Battle>("select b from SpecializedBattle b where b.Id = :id",Hql.Param("id",id));
			if (battlesToDelete.Count > 0 ) {
				BattlePersistance.DeleteBattle(battlesToDelete[0]);
			}
			Persistance.Flush();
			return WhatToDoNext.GoAhead;
		}

        #endregion Tournament Delete

        #region Stats

        [Option("Create Stats", "cs")]
        public WhatToDoNext CreateStats()
        {
            Console.WriteLine("Start time: {0}", DateTime.Now);
            string dirBin = AppDomain.CurrentDomain.BaseDirectory;
            string baseDir = string.Format("{0}Stats", dirBin);
            Console.WriteLine("Stats Path:{0}",baseDir);
            if (!Directory.Exists(baseDir))
            {
                Directory.CreateDirectory(baseDir);
            }

            string baseDelete = baseDir;
            string[] dirsDelete = Directory.GetDirectories(baseDelete, "*", SearchOption.TopDirectoryOnly);

            string baseWrite = string.Format("{0}HTMLs", dirBin);
            if (!Directory.Exists(baseDir))
            {
                Directory.CreateDirectory(baseDir);
            }

            baseDir = string.Format("{0}Stats/{1}", dirBin, Stats.GetDate());
            Console.WriteLine("Weekly Stats Path:{0}", baseDir);
            if (!Directory.Exists(baseDir))
            {
                Directory.CreateDirectory(baseDir);
            }

            Stats.CreateXMLs(string.Format("{0}Stats", dirBin));
            Console.WriteLine("HTML Path:{0}", baseWrite);
            Stats.CreateHTMLs(baseDir, baseWrite);
            Console.WriteLine("Deleting old directories");
            string lastSub = Stats.GetLastSub(baseDelete).Name;

            baseDir = baseDir.Substring(baseDir.Length - 8);
            foreach (string directory in dirsDelete)
            {
                string toTest = directory.Substring(directory.Length - 8);
                if (toTest != lastSub && toTest != baseDir)
                {
                    Directory.Delete(directory,true);
                }
            }
            Console.WriteLine("End time: {0}", DateTime.Now);
            return WhatToDoNext.GoAhead;
        }

        [Option("Force Stats", "fs")]
        public WhatToDoNext ForceStats()
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                IList<PlayerStorage> players =
                    persistance.TypedQuery("select e from SpecializedPlayerStorage e where e.StatsNHibernate is null");
                foreach (PlayerStorage player in players)
                {
                    using (IPlayerStatsPersistance persistance2 = Persistance.Instance.GetPlayerStatsPersistance())
                    {
                        PlayerStats stat = persistance2.Create();
                        stat = persistance2.Create();
                        stat.NumberBountyQuests = 0;
                        stat.NumberColonizerQuests = 0;
                        stat.NumberGladiatorQuests = 0;
                        stat.NumberMerchantQuests = 0;
                        stat.NumberOfPlayedBattles = 0;
                        stat.NumberPirateQuest = 0;
                        persistance2.Update(stat);
                        player.Stats = stat;
                    }
                    persistance.Update(player);
                }
                persistance.Flush();
            }
            return WhatToDoNext.GoAhead;
        }

        [Option("Create DB Stats", "dbs")]
        public WhatToDoNext CreateDBStats()
        {
            Console.WriteLine("Start time: {0}", DateTime.Now);
            Stats.GenerateDBStats();
            SetLadderActivity();
            Console.WriteLine("End time: {0}", DateTime.Now);
            return WhatToDoNext.GoAhead; 
        }

        private static void SetLadderActivity()
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList<Principal> prins = persistance.Select();
                    //("SELECT count(*) FROM SpecializedPrincipal t where t.CreatedDate < '{0}' and t.UpdatedDate > '{1}'",
                //(DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd hh:mm:ss"), (DateTime.Now.AddDays(-7)).ToString("yyyy-MM-dd hh:mm:ss"));
                foreach (Principal prin in prins)
                {
                    if (prin.LastLogin < (DateTime.Now.AddDays(-15)))
                    {
                        prin.LadderActive = false;
                        persistance.Update(prin);
                    }
                }
                persistance.Flush();
            }
        }

        #endregion Stats

        #region Prepare Scripts

        [Option("Adds localized tokens to the Engine.js", "scripts-I18N")]
        public WhatToDoNext LocalizeEngineJS(string engineFile)
        {
            Console.WriteLine("Joining localized files with engine...");
            foreach (string localized in GetLocalizationFiles(engineFile)) {
                JoinFiles(engineFile, localized);
            }
            return WhatToDoNext.GoAhead;
        }

        private void JoinFiles(string engineFile, string localized)
        {
            string language = ParseLanguage(localized);
            Console.WriteLine("Joining {0}...", language);
            string output = engineFile.Replace(".js", string.Format("-{0}.js", language));

            using (StreamWriter writer = new StreamWriter(output)) {
                writer.WriteLine("var Language={0};", File.ReadAllText(localized).Replace(Environment.NewLine,string.Empty).Replace("\t",string.Empty));
                writer.WriteLine(File.ReadAllText(engineFile));
            }

            Console.WriteLine("Joined {0}", output);
        }

        private string ParseLanguage(string localized)
        {
            localized = new FileInfo(localized).Name;
            localized = localized.Replace("I18N-", string.Empty);
            return localized.Replace(".json", string.Empty);
        }

        private IEnumerable<string> GetLocalizationFiles(string engineFile)
        {
            string basePath = Path.Combine(new FileInfo(engineFile).DirectoryName, "../../../WebUserInterface/Localization/Script/");
            return Directory.GetFiles(basePath, "*.json");
        }
      
        private string GetTempDir(string scriptsDir)
        {
            string tmpDir = Path.Combine(scriptsDir, "Temp");
            if (!Directory.Exists(tmpDir)) {
                Directory.CreateDirectory(tmpDir);
            }
            return tmpDir;
        }

        [Option("Prepares the scripts", "scripts-merge")]
        public WhatToDoNext PrepareScripts(string webResources)
        {
            DirectoryInfo dir = GetDir(webResources);
            PrepareJsScripts(dir);
            PrepareCssScripts(dir);

            return WhatToDoNext.GoAhead;
        }

        private static DirectoryInfo GetDir(string webResources)
        {
            if (string.IsNullOrEmpty(webResources)) {
                throw new Exception("Please provide the WebResources directory");
            }

            DirectoryInfo dir = new DirectoryInfo(webResources);
            if (!dir.Exists) {
                throw new Exception(string.Format("Dir `{0}´' does not exist"));
            }

            Console.WriteLine("WebResources Dir:");
            Console.WriteLine(" » {0}", dir.FullName);

            return dir;
        }

        private void PrepareJsScripts(DirectoryInfo dir)
        {
            Console.WriteLine("Merging JS Engine files...");

            string scriptsDir = Path.Combine(dir.FullName, "Scripts");
            string tmpDir = GetTempDir(scriptsDir);
            string outputFile = Path.Combine(tmpDir, "EngineStep1.temp.js");

            using(StreamWriter writer = new StreamWriter(outputFile)){

                foreach (string fileName in GetJsFiles(scriptsDir)) {
                    FileInfo fileInfo = new FileInfo(Path.Combine(scriptsDir,fileName));
                    Console.Write(" » {0} ", fileInfo.Name);
                    if (ToIgnore(fileInfo)) {
                        Console.WriteLine("Ignore");
                        continue;
                    }

                    writer.WriteLine();
                    writer.WriteLine("// {0}", fileInfo.Name);
                    string all = File.ReadAllText(fileInfo.FullName);
                    CheckForErrors(fileInfo.FullName, all);
                    writer.Write(all);

                    Console.WriteLine("Ok");
                }

            }
        }

        private static Regex regex = new Regex(",\\s*}", RegexOptions.Compiled);
        private void CheckForErrors(string file, string content)
        {
            if (regex.IsMatch(content)) {
                throw new Exception(string.Format("Detected invalid json sequence ',}}' on file {0}", file));
            }
        }

        private void PrepareCssScripts(DirectoryInfo dir)
        {
            Console.WriteLine("Merging CSS files...");

            string scriptsDir = Path.Combine(dir.FullName, "Styles");
            string tmpDir = GetTempDir(scriptsDir);
            scriptsDir = Path.Combine(scriptsDir, "Common");
            string outputFile = Path.Combine(tmpDir, "EngineStep1.temp.css");

            using(StreamWriter writer = new StreamWriter(outputFile)){

                foreach (string fileName in GetCssFiles(scriptsDir)) {
                    FileInfo fileInfo = new FileInfo(Path.Combine(scriptsDir,fileName));
                    Console.Write(" » {0} ", fileInfo.Name);
                    if (ToIgnore(fileInfo)) {
                        Console.WriteLine("Ignore");
                        continue;
                    }

                    writer.WriteLine();
                    writer.WriteLine("/* {0} */", fileInfo.Name);
                    writer.Write(File.ReadAllText(fileInfo.FullName));

                    Console.WriteLine("Ok");
                }

            }
        }

        private static IEnumerable<string> GetJsFiles(string scriptsDir)
        {
            foreach (string script in Script.ScriptList) {
                yield return string.Format("{0}.js", script);
            }
        }

        private static IEnumerable<string> GetCssFiles(string scriptsDir)
        {
            foreach (string script in Style.ScriptList)  {
                yield return string.Format("{0}.css", script);
            }
        }

        private bool ToIgnore(FileInfo fileInfo)
        {
            return fileInfo.Name.Contains("I18N");
        }

        #endregion Prepare Scripts

        #region Tests

        [Option("Sets the Debug Log Level", "verbose")]
        public WhatToDoNext SetDebugLevel()
        {
            Log.ToDebugLevel();
            Console.WriteLine("Log level set to: Debug");
            return WhatToDoNext.GoAhead;
        }

        [Option("Test Exception", "te")]
        public WhatToDoNext TestException()
        {
            using (IProductPersistance persistance = Persistance.Instance.GetProductPersistance())
            {
                for (int i = 0; i < 1000; ++i)
                {
                    ThrowMet();
                    if(i%100 == 0)
                        persistance.Flush();
                }
                persistance.Flush();
            }
            return WhatToDoNext.GoAhead;
        }

        private static void ThrowMet()
        {
            try
            {
                throw new Exception("The method or operation is not implemented.");
            }catch(Exception e)
                {
                    ExceptionLogger.Log(e);
                }
        }



        #endregion Tests

        #region Markets

        [Option("Put Products in Market", "ppm")]
        public WhatToDoNext PutProductsInMarket()
        {
            using (IMarketPersistance persistance = Persistance.Instance.GetMarketPersistance())
            {
                IList<Market> markets = persistance.Select();


                using (IProductPersistance persistance2 = Persistance.Instance.GetProductPersistance(persistance))
                {
                    foreach (Market market in markets)
                    {
                        CreateProduct(market, "Serium", 16, persistance2);
                        CreateProduct(market, "Energy", 14, persistance2);
                        CreateProduct(market, "Elk", 14, persistance2);
                        CreateProduct(market, "Protol", 14, persistance2);
                        CreateProduct(market, "Gold", 14, persistance2);
                        CreateProduct(market, "Titanium", 14, persistance2);
                        if (market.Level > 1)
                        {
                            CreateProduct(market, "Mithril", 12, persistance2);
                            CreateProduct(market, "Uranium", 12, persistance2);
                        }
                    }
                }

                persistance.Flush();
                return WhatToDoNext.GoAhead;
            }
        }

        private static void CreateProduct(Market market, string name, int price, IPersistance<Product> persistance2)
        {
            Product prod = persistance2.Create();
            prod.Market = market;
            prod.Quantity = 0;
            prod.Price = price;
            prod.Type = "Intrinsic";
            prod.Name = name;
            persistance2.Update(prod);
        }

		[Option("Updates the Market sector ids", "umi")]
		public WhatToDoNext UpdateMarketIds() {
			List<Market> markets = (List<Market>)Hql.Query<Market>("from SpecializedMarket");
			List<SectorStorage> sectors = (List<SectorStorage>)Hql.Query<SectorStorage>("select s from SpecializedSectorStorage s where s.Type = 'MarketSector'");

			foreach (Market market in markets) {
				SectorStorage sectorStorage = sectors.Find(delegate(SectorStorage ss) {
				    string coordinate = string.Format("{0}:{1}:{2}:{3}", ss.SystemX, ss.SystemY, ss.SectorX, ss.SectorY);
					return market.Coordinates.Equals(coordinate);
				});
				market.Sector = sectorStorage;
			}

			using (IMarketPersistance persistance = Persistance.Instance.GetMarketPersistance()) {
				persistance.StartTransaction();
				foreach (Market market in markets) {
					persistance.Update(market);
				}
				persistance.CommitTransaction();
			}
			return WhatToDoNext.GoAhead;
		}


        #endregion Markets

        #region Martelates

        [Option("Fixes modifiers", "sicBattles")]
        public WhatToDoNext SincronyzeBattles()
        {
            using (IPrincipalStatsPersistance persistance = Persistance.Instance.GetPrincipalStatsPersistance())
            {
                IList<PrincipalStats> stats = persistance.Select();

                foreach (PrincipalStats stat in stats)
                {
                    if(stat.BattleStats.Count > 0)
                    {
                        stat.NumberPlayedBattles = stat.BattleStats[0].Wins + stat.BattleStats[0].Defeats;
                        persistance.Update(stat);
                    }
                }
                persistance.Flush();
            }
            return WhatToDoNext.GoAhead;
        }

        [Option("Fixes modifiers", "fix-modifiers")]
        public WhatToDoNext FixPlanetModifiers(string player)
        {
            using (IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance()) {
                IList<PlanetStorage> planets = persistance.TypedQuery("select planet from SpecializedPlanetStorage planet where IsPrivate = 1 and planet.PlayerNHibernate.Id = {0}",player );

                foreach (PlanetStorage planetStorate in planets) {
                    Console.WriteLine("» {0}", planetStorate.Name);
                    IPlanet planet = PlanetConversion.ConvertToPlanet(planetStorate);
                    planet.Modifiers = new Dictionary<IResourceInfo,int>();
                    UpdateMods(planet, "CommandCenter");
                    UpdateMods(planet, "Resource1");
                    UpdateMods(planet, "Resource2");
                    UpdateMods(planet, "Resource3");
                    UpdateMods(planet, "Resource4");
                    UpdateMods(planet, "Resource5");
                    GameEngine.Persist(planet);
                }

                persistance.Flush();
            }
            return WhatToDoNext.GoAhead;
        }

        [Option("Removes trade route mods", "remove-trade-mods")]
        public WhatToDoNext FixPlanetModifiers()
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
                IList<PlayerStorage> storages = persistance.TypedQuery("from SpecializedPlayerStorage player where player.IntrinsicQuantities like '%Tools%'");
                foreach (PlayerStorage storage in storages) {
                    Console.WriteLine("- Fixing {0}...", storage.Name);
                    IPlayer player = new Player(storage);
                    foreach(KeyValuePair<IResourceInfo,int> pair in new Dictionary<IResourceInfo,int>( player.IntrinsicQuantities)) {
                        if (pair.Key.IsTradeRouteSpecific) {
                            player.IntrinsicQuantities.Remove(pair.Key);
                            player.Touch();
                        }
                    }
                    foreach (IPlanet planet in player.Planets) { 
                        foreach(KeyValuePair<IResourceInfo,int> pair in new Dictionary<IResourceInfo,int>( planet.Modifiers)) {
                            if (pair.Key.IsTradeRouteSpecific) {
                                planet.Modifiers.Remove(pair.Key);
                                planet.Touch();
                            }
                        }
                    }
                    GameEngine.Persist(player);
                }
            }
            return WhatToDoNext.GoAhead;
        }

		#region Fix defense Fleets

		private static void UpdateMods(IPlanet planet, string facility) {
			IPlanetResource cc = planet.GetFacility(planet.Info.GetSlot(facility));
			if (cc == null) {
				return;
			}
			Console.WriteLine("\t > {0} Level {1}", cc.Info.Name, cc.Level);
			if (cc.Info.Name == "CommandCenter" || cc.Info.Name == "SolarPanel") {
				planet.AddToModifier(Energy.Resource, cc.Level);
				Console.WriteLine("\t\t+{0} Energy", cc.Level);
			}
			if (cc.Info.Name == "CommandCenter" || cc.Info.Name == "SeriumExtractor") {
				planet.AddToModifier(Serium.Resource, cc.Level);
				Console.WriteLine("\t\t+{0} Serium", cc.Level);
			}
		}

		private static void DeleteRepeatedFleets(SectorStorage sector, IPlanetStoragePersistance persistance, PlanetStorage p) {
			bool deletedAny = false;
			for (int i = 0; i < sector.Fleets.Count; ++i) {
				using (IFleetPersistance fleetPersistance = Persistance.Instance.GetFleetPersistance(persistance)) {
					Fleet f = sector.Fleets[i];
					if (f.CurrentPlanet.Id != p.Id) {
						fleetPersistance.Delete(f);
						deletedAny = true;
						continue;
					}
					if (p.Player != null && f.PlayerOwner != null && p.Player.Id != f.PlayerOwner.Id) {
						deletedAny = true;
						fleetPersistance.Delete(f);
						continue;
					}
					if (!deletedAny && i > 0) {
						fleetPersistance.Delete(f);
					}
				}
			}
		}

		private static SectorStorage GetSector(IList elem) {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				Dictionary<string, object> args = new Dictionary<string, object>();
				args["s1"] = elem[0];
				args["s2"] = elem[1];
				args["s3"] = elem[2];
				args["s4"] = elem[3];
				string[] hql = new string[2];
				hql[0] = "select p from SpecializedSectorStorage p left join fetch p.PlanetsNHibernate where p.SystemX = :s1 and p.SystemY = :s2 and p.SectorX = :s3 and p.SectorY = :s4";
				hql[1] = "select p from SpecializedSectorStorage p left join fetch p.FleetsNHibernate where p.SystemX = :s1 and p.SystemY = :s2 and p.SectorX = :s3 and p.SectorY = :s4";
				ArrayList list = (ArrayList)persistance.MultiQuery(hql, args)[0];
				return (SectorStorage)list[0];
			}
		}

		private static IList<PlanetStorage> GetNukedPlanets(IPlanetStoragePersistance persistance, IList elements) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write(" p.Id = {0}", elements[0]);
                for (int i = 1; i < elements.Count; ++i) {
                    writer.Write(" or p.Id = {0}", elements[i]);

                }
                return persistance.TypedQuery("select p from SpecializedPlanetStorage p left join fetch p.PlayerNHibernate where {0}", writer.ToString());
            }
		}


		[Option("Fixes the Defense fleets", "fix-defensefleets")]
		public WhatToDoNext FixDefenseFleets() {
			using (IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance()) {
				IList elements = Sql.Query("select systemX,systemy,sectorx,sectory, c from (SELECT systemX,systemy,sectorx,sectory, count(*) as c FROM fleet where systemx != 0 and Name = 'DefenseFleet' group by systemx, systemy,sectorx, sectory) as h where h.c > 1");
				foreach (IList elem in elements) {
					SectorStorage sector = GetSector(elem);
					PlanetStorage p = sector.Planets[0];
					DeleteRepeatedFleets(sector, persistance, p);
				}
				elements = Sql.Query("SELECT planetstorageid FROM planetstorage as p WHERE planetstorageid not in (SELECT CurrentPlanetId FROM fleet as f WHERE p.planetstorageid = f.CurrentPlanetId )");
				if (elements.Count > 0) {
					IList<PlanetStorage> planets = GetNukedPlanets(persistance, elements);
					using (IFleetPersistance fleetPersistance = Persistance.Instance.GetFleetPersistance(persistance)) {
						foreach (PlanetStorage planet in planets) {
							IFleetInfo fleet = new FleetInfo("DefenseFleet", null, true, new SectorCoordinate(planet.SystemX, planet.SystemY, planet.SectorX, planet.SectorY));
							fleet.Movable = false;
							fleet.PrepareStorage();
							fleet.UpdateStorage();
							fleet.Storage.CurrentPlanet = planet;
							fleet.Storage.PlayerOwner = planet.Player;
							fleet.Storage.Sector = planet.Sector;
							fleetPersistance.Update(fleet.Storage);
						}
					}
				}

			}
			Persistance.Flush();
			return WhatToDoNext.GoAhead;
		}

		#endregion Fix defense Fleets

        [Option("Removes dropable resources from players", "remove-dropable-fix")]
        public WhatToDoNext RemoveDropableFix()
        {
            IList<PlayerStorage> players = Hql.Query<PlayerStorage>("select p from SpecializedPlayerStorage p ");
            
            int count = 0;
            foreach (PlayerStorage storage in players) {
                Player player = new Player(storage);
                Console.WriteLine("Checking player {0}...", player.Name);
                bool updated = false;
                foreach (KeyValuePair<IResourceInfo, int> resource in new Dictionary<IResourceInfo, int>(player.IntrinsicQuantities)) {
                    if (resource.Key.Races == RaceUtils.Mercs) {
                        player.IntrinsicQuantities.Remove(resource.Key);
                        player.Touch();
                        updated = true;
                        Console.WriteLine("\tRemoved Res {0} {1}", resource.Value, resource.Key);
                    }
                }
                foreach (IPlanet planet in player.Planets) {
                    foreach (KeyValuePair<IResourceInfo, int> mod in new Dictionary<IResourceInfo, int>(planet.Modifiers)) {
                        if (mod.Key.Races == RaceUtils.Mercs) {
                            planet.Modifiers.Remove(mod.Key);
                            planet.Touch();
                            Console.WriteLine("\tRemoved Mod {0} {1}", mod.Value, mod.Key);
                            updated = true;
                        }
                    }
                }
                if (updated) {
                    Console.WriteLine("\tUpdating...");
                    ++count;
                    GameEngine.Persist(player, false, true);
                }
            }

            Console.WriteLine("Fixed {0} players", count);

            return WhatToDoNext.GoAhead;
        }

		[Option("Fixes the repeted battles. DON'T USE", "fix-battles")]
		public WhatToDoNext FixBattles() {
			using( IBattlePersistance battlePersistance = Persistance.Instance.GetBattlePersistance() ) {
				IList<Battle> battles = battlePersistance.TypedQuery("select b from SpecializedBattle b inner join fetch b.PlayerInformationNHibernate pi where b.HasEnded = 0 and b.BattleMode = 'Battle' and pi.Owner = {0}", 839007);
				IList<Battle> battles1 = GetRepeatedBattles(battlePersistance, battles);

				foreach( Battle battle in battles1) {
					if (battle.Id != 1572166 && battle.Id != 1642866) {
						using (IPlayerBattleInformationPersistance p1 = Persistance.Instance.GetPlayerBattleInformationPersistance(battlePersistance)) {
							foreach (PlayerBattleInformation p in battle.PlayerInformation) {
								p1.Delete(p);
							}
						}
						using (IBattleExtentionPersistance p1 = Persistance.Instance.GetBattleExtentionPersistance(battlePersistance)) {
							p1.Delete(battle.BattleExtension[0]);
						}
						using (ITimedActionStoragePersistance p1 = Persistance.Instance.GetTimedActionStoragePersistance(battlePersistance)) {
							p1.Delete(battle.TimedAction[0]);
						}
						battlePersistance.Delete(battle);
					}
					
				}
			}
			Persistance.Flush();
			
			return WhatToDoNext.GoAhead;
		}

		private static IList<Battle> GetRepeatedBattles(IBattlePersistance battlePersistance, IList<Battle> battles) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write(" b.Id = {0}", battles[0].Id);
                for (int i = 1; i < battles.Count; ++i) {
                    writer.Write(" or b.Id = {0}", battles[i].Id);
                }
                Persistance.Clear();
                return Hql.StatelessQuery<Battle>("select b from SpecializedBattle b inner join fetch b.PlayerInformationNHibernate where " + writer.ToString());
            }
		}
		

		#endregion Martelates

		#region Vacations

		[Option("Gives vacation turns", "vacations")]
        public WhatToDoNext GiveVacations()
        {
            IList<Principal> principals = Hql.StatelessQuery<Principal>("from SpecializedPrincipal where AvailableVacationTicks < :max", Hql.Param("max", VacationsManager.MaxAvailableVacations));
            if (principals.Count == 0) {
                Console.WriteLine(" - No principals to update");
                return WhatToDoNext.GoAhead;
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                persistance.StartTransaction();
                foreach (Principal principal in principals) {
                    Console.WriteLine("\tUpdating {0}...", principal.Name);
                    if (principal.AvailableVacationTicks < VacationsManager.MaxAvailableVacations)
                    {
                        principal.AvailableVacationTicks += (Server.Properties.VacationTicksPerWeek*1);
                        VacationsManager.NormalizeVacationValues(principal);
                        persistance.Update(principal);
                    }
                }
                persistance.CommitTransaction();
            }

            return WhatToDoNext.GoAhead;
        }

        #endregion Vacations

        #region Duplicates

        [Option("Duplicate Finder", "df")]
        public WhatToDoNext DuplicateFinder()
        {
            Console.WriteLine("Start time: {0}", DateTime.Now);
            Console.WriteLine("Findind Duplicates...");
            IList<int> principalIds = Duplicates.FindDuplicates();
            if (principalIds != null && principalIds.Count > 0) { 
                Console.WriteLine("Notifing Duplicates...");
                //Duplicates.NotifyDuplicates(principalIds);
            }
            Console.WriteLine("End time: {0}", DateTime.Now);
            return WhatToDoNext.GoAhead;
        }

        #endregion Duplicates

        #region Arenas

        [Option("Change Arenas Fleets", "caf")]
        public WhatToDoNext ChangeArenasFleets()
        {
            Console.WriteLine("Start time: {0}", DateTime.Now);

            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                IList<ArenaStorage> arenas = persistance.Select();

                foreach (ArenaStorage arena in arenas)
                {
                    using (IFleetPersistance persistance2 = Persistance.Instance.GetFleetPersistance(persistance))
                    {
                        if (arena.Level == 10)
                        {
                            arena.Fleet.Units = TournamentManager.GetFleet(1000,true).ToString();
                        }
                        else
                        {
                            arena.Fleet.Units = TournamentManager.GetFleet(1000,false).ToString();
                        }
                        Console.WriteLine("Arena {0} ({1}) fleet: ", arena.Name, arena.Id);
                        Console.WriteLine("- {0}", WritePrettyFleet(arena));
                        persistance2.Update(arena.Fleet);
                    }
                }
                persistance.Flush();
            }

            Console.WriteLine("End time: {0}", DateTime.Now);
            return WhatToDoNext.GoAhead;
        }

        [Option("Arenas Month Reward / Ladder Medals", "amr")]
        public WhatToDoNext ArenasRewards()
        {
            Console.WriteLine("Start time: {0}", DateTime.Now);

            Console.WriteLine("Start Arena Rewards");
            ArenaMonthReward();
            Console.WriteLine("Start Giving Medals");
            //GiveMedals();
            Console.WriteLine("Start Seending Monthly Invoices");
            //SendInvoices();

            Console.WriteLine("End time: {0}", DateTime.Now);
            return WhatToDoNext.GoAhead;
        }

        private void SendInvoices()
        {
            try
            {
                using (IInvoicePersistance persistance = Persistance.Instance.GetInvoicePersistance())
                {
                    DateTime lastMonth = DateTime.Now.AddMonths(-1);
                    lastMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                    DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    IList<Invoice> invoices =
                        persistance.TypedQuery(
                            "select e from SpecializedInvoice e inner join fetch e.PaymentNHibernate where e.CreatedDate >='{0}' and e.CreatedDate <'{1}'",
                            lastMonth.ToString("yyyy-MM-dd"), now.ToString("yyyy-MM-dd"));

                    IList<Country> countries;
                    using (ICountryPersistance persistance2 = Persistance.Instance.GetCountryPersistance(persistance))
                    {
                        countries = persistance2.Select();
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append(
                        "<table border='1''><tr><td>Número</td><td>Data</td><td>Método</td><td>Nome</td><td>NIF</td><td>País</td><td>Quantia</td></tr>");
                    double total = 0;
                    foreach (Invoice invoice in invoices)
                    {
                        total += invoice.Money;
                        sb.Append(
                            string.Format(
                                "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{6}</td><td>{5}</td></tr>",
                                invoice.Identifier, invoice.CreatedDate, invoice.Payment.Method, invoice.Name,
                                invoice.Nif, invoice.Money,LanguageManager.Instance.Get(InvoiceUtils.GetCountry(countries,invoice.Country).Name)));
                    }
                    sb.Append("<tr><td colspan='6' align='right'>Total</td><td>");
                    sb.Append(total);
                    sb.Append("</td></tr></table>");
                    Console.WriteLine("End table generation");

                    

                    sb.Append(InvoiceUtils.GetCountriesHtml(
                                  string.Format("e.CreatedDate >='{0}' and e.CreatedDate <'{1}'",
                                                lastMonth.ToString("yyyy-MM-dd"), now.ToString("yyyy-MM-dd")),
                                  countries, 0.2));

                    Console.WriteLine("End country table generation");

                    MailSender.Send(new string[] { "tiago.sousa@pdmfc.com", "business@orionsbelt.eu" },
                                  "Monthly invoices <Invoices@orionsbelt.eu>", "Monthly Incommings", sb.ToString(),true);
                    Console.WriteLine("Mail sent");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private static void GiveMedals()
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList<Principal> prins = persistance.TypedQuery(0, 5,
                                                                "select e from SpecializedPrincipal e where e.LadderActive=1 order by e.LadderPosition");
                
                for(int iter = 0; iter < prins.Count; ++iter)
                {
                    MedalManager.Add(prins[iter],
                                     (MedalType)Enum.Parse(typeof(MedalType),
                                                           string.Format("Ladder_Pos{0}", iter + 1)));
                }
            }
        }

        private static void ArenaMonthReward()
        {
            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                IList<ArenaStorage> arenas = persistance.Select();
                persistance.StartTransaction();
                int testTick = Clock.Instance.Tick + Clock.Instance.ConvertToTicks(TimeSpan.FromDays(-30));
                foreach (ArenaStorage arena in arenas)
                {
                    if (arena.ConquestTick != 0 && 
                        arena.ConquestTick < testTick)
                    {
                        Console.WriteLine("Arena: {0}, level: {1}, reward to player:{2}", arena.Id,arena.Level, arena.Owner.Id);
                        using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                        {
                            int salary = arena.Level*10;
                            arena.Owner.Principal.Credits += salary;
                            persistance2.Update(arena.Owner.Principal);
                            TransactionManager.ArenaSalaryTransaction(arena, persistance);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Arena: {0}, level: {1}, no reward", arena.Id, arena.Level); 
                    }
                }
                persistance.CommitTransaction();
            }
        }

        private static string WritePrettyFleet(ArenaStorage arena)
        {
            using (TextWriter writer = new StringWriter()) {
                foreach (IFleetElement element in new FleetInfo(arena.Fleet).Units.Values) {
                    writer.Write("{0}:{1};", element.UnitInfo.Name, element.Quantity);
                }
                return writer.ToString();
            }
        }

        #endregion Arenas

        #region Auctioner

        [Option("Auctioner", "auc")]
        public WhatToDoNext Auctioner()
        {
            Console.WriteLine("Start time: {0}", DateTime.Now);

            long count, pCount;
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                count = persistance.ExecuteScalar("select count(*) from SpecializedAuctionHouse where (BuyedInTick=0)and((4&ComplexNumber)<>0 )");

                using (IPlayerStoragePersistance persistance2 = Persistance.Instance.GetPlayerStoragePersistance(persistance))
                {
                    pCount = persistance2.ExecuteScalar("select count(*) from SpecializedPlayerStorage");
                }
                int limit = 10 + Convert.ToInt32(pCount)/200;
                Console.WriteLine("Count={0}", count);
                if (count >= limit)
                {
                    Console.WriteLine("Enought units in the auction house");
                }

                PlayerStorage player;
                IList playerLevels;
                using (IPlayerStoragePersistance persistance2 = Persistance.Instance.GetPlayerStoragePersistance(persistance))
                {
                    IList<PlayerStorage> players = persistance2.SelectByName("auctioner");

                    if (players.Count == 0)
                    {
                        Console.WriteLine("Player 'auctioner' does not exist");
                        return WhatToDoNext.GoAhead;
                    }
                    player = players[0];

                    playerLevels = persistance.Query("SELECT e.PlanetLevel FROM SpecializedPlayerStorage e group by e.PlanetLevel");
                }

                IList<int> levels = new List<int>();
                foreach (int level in playerLevels)
                {
                    levels.Add(level);
                }

                IList<IUnitInfo> units = RulesUtils.GetUnitResources();
                IList<IUnitInfo> lights = new List<IUnitInfo>();
                IList<IUnitInfo> mediums = new List<IUnitInfo>();
                IList<IUnitInfo> heavies = new List<IUnitInfo>();
                IList<IUnitInfo> ultimates = new List<IUnitInfo>();

                GetListsByCategory(units, lights, mediums, heavies, ultimates);
                Random rad = new Random();
                IPlayer auctioner = new Player(player);
                IFleetInfo fleet = auctioner.GetHomePlanet().DefenseFleet;


                while (count < limit)
                {
                    PutShipInAuction(lights, mediums, heavies, ultimates, player, rad, fleet, levels);
                    ++count;
                }

                PutRaresInAuction(persistance, player, rad, fleet);
                persistance.Flush();
            }
            Console.WriteLine("End time: {0}", DateTime.Now);
            return WhatToDoNext.GoAhead;
        }

        private static void PutRaresInAuction(IPersistance<AuctionHouse> persistance, PlayerStorage player, Random rad, IFleetInfo fleet)
        {
            List<AuctionHouse> items = (List<AuctionHouse>)persistance.TypedQuery("from SpecializedAuctionHouse where (BuyedInTick=0)and((2&ComplexNumber)<>0 )");

            foreach (IResourceInfo info in RulesUtils.GetRareResourcesExcept())
            {
                AuctionHouse find = items.Find(delegate(AuctionHouse item1)
                               {
                                   return item1.Details == info.Name;
                               });
                
                if(null == find)
                {
                    int ticks1 = (Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
                    int ticks2 = (Clock.Instance.ConvertToTicks(TimeSpan.FromDays(4)));
                    int ticks = rad.Next(ticks1, ticks2);
                    int quantity = rad.Next(8, 15)*100;
                    IAuctionItem item = new AuctionItem(info, quantity, 10, 300, player, ticks);
                    AuctionHouseUtil.PutInAuction(item, fleet, true, true);
                }
            }
        }

        private static void PutShipInAuction(IList<IUnitInfo> lights, IList<IUnitInfo> mediums,
            IList<IUnitInfo> heavies, IList<IUnitInfo> ultimates, PlayerStorage player, Random rad, IFleetInfo fleet, IList<int> levels)
        {
            IResourceInfo info;
            int percentage = rad.Next(100);

            int ticks1 = (Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
            int ticks2 = (Clock.Instance.ConvertToTicks(TimeSpan.FromDays(4)));
            int ticks = rad.Next(ticks1, ticks2);
            if(percentage < 50 || !ListContainsGreaterThan(levels, 3))
            {
                Console.WriteLine("-Select a light");

                info = lights[rad.Next(lights.Count)];

                int quantity = rad.Next(50, 71);
                IAuctionItem item = new AuctionItem(info, quantity, 20, 500, player, ticks);
                AuctionHouseUtil.PutInAuction(item, fleet, true, true);
            }else
            {
                if (percentage < 85 || !ListContainsGreaterThan(levels, 6))
                {
                    Console.WriteLine("-Select a medium");
                    info = mediums[rad.Next(mediums.Count)];
                    int quantity = rad.Next(40, 51);
                    IAuctionItem item = new AuctionItem(info, quantity, 50, 700, player, ticks);
                    AuctionHouseUtil.PutInAuction(item, fleet, true, true);
                }
                else
                {
                    if (percentage < 96)
                    {
                        Console.WriteLine("-Select a heavy");
                        info = heavies[rad.Next(heavies.Count)];
                        int quantity = rad.Next(20, 31);
                        IAuctionItem item = new AuctionItem(info, quantity, 100, 1000, player, ticks);
                        AuctionHouseUtil.PutInAuction(item, fleet, true, true);
                    }
                    else
                    {
                        Console.WriteLine("-Select a ultimate");
                        info = ultimates[rad.Next(ultimates.Count)];
                        ticks1 = (Clock.Instance.ConvertToTicks(TimeSpan.FromDays(6)));
                        ticks2 = (Clock.Instance.ConvertToTicks(TimeSpan.FromDays(7)));
                        ticks = rad.Next(ticks1, ticks2);
                        IAuctionItem item;
                        if ((info.AuctionType & AuctionHouseType.Boss) != 0) {
                            item = new AuctionItem(info, 1, 5000, 0, player, ticks);
                        } else {
                            item = new AuctionItem(info, 1, 2000, 0, player, ticks);
                        }
                        AuctionHouseUtil.PutInAuction(item, fleet, true, false);
                    }
                }
            }
        }

        private static bool ListContainsGreaterThan(IEnumerable<int> levels, int p)
        {
            foreach (int i in levels)
            {
                if(i > p)
                    return true;
            }
            return false;
        }

        private static void GetListsByCategory(IEnumerable<IUnitInfo> units, ICollection<IUnitInfo> lights, 
            ICollection<IUnitInfo> mediums, ICollection<IUnitInfo> heavies, ICollection<IUnitInfo> ultimates)
        {
            foreach (IUnitInfo unit in units)
            {
				if(unit.AuctionType == AuctionHouseType.None) {
					continue;
				}

                if ((unit.AuctionType & AuctionHouseType.Light) != 0)
                {
                    lights.Add(unit);
                    continue;
                }

                if ((unit.AuctionType & AuctionHouseType.Medium) != 0)
                {
                    mediums.Add(unit);
                    continue;
                }

                if ((unit.AuctionType & AuctionHouseType.Heavy) != 0)
                {
                    heavies.Add(unit);
                    continue;
                }

                if ((unit.AuctionType & AuctionHouseType.Ultimate) != 0 || (unit.AuctionType & AuctionHouseType.Boss) != 0)
                {
                    ultimates.Add(unit);
                    continue;
                }
            }
        }


        #endregion Auctioner

        #region Payments

        [Option("Reprocess payments", "pay")]
        public WhatToDoNext VerifyPayments()
        {
            Console.WriteLine("Start time: {0}", DateTime.Now);
            IPayment payPal = new Paypal();
            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                IList<Payment> payments = persistance.SelectByVerifyState("NotVerified");

                foreach (Payment payment in payments)
                {
                    Console.WriteLine("Payment ID: {0}", payment.Id);
                    Dictionary<string, string> parameters = GetParameters(payment.Request);
                    if(payment.Method == PaymentMethodEnum.PayPal.ToString())
                    {
                        payPal.SendValidation(parameters, payment.Request, payment);
                    }
                }

            }
            Console.WriteLine("End time: {0}", DateTime.Now);
            return WhatToDoNext.GoAhead;
        }

        /*
        [Option("Test invoice", "invoice")]
        public WhatToDoNext Invoice()
        {
            Console.WriteLine("Start time: {0}", DateTime.Now);
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                persistance.StartTransaction();
                IList<Principal> prins = persistance.SelectById(204);
                if(prins.Count > 0)
                {
                    Console.WriteLine("Found principal");
                    TransactionManager.PaymentTransaction(prins[0],1200, 4.99,persistance);
                }
                Console.WriteLine("Commiting...");
                persistance.CommitTransaction();
            }
            Console.WriteLine("End time: {0}", DateTime.Now);
            return WhatToDoNext.GoAhead;
        }
        */

        private static Dictionary<string, string> GetParameters(string request)
        {
            string[] pars = request.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> toReturn = new Dictionary<string, string>(pars.Length);

            char[] separator = new char[] {'='};
            foreach (string par in pars)
            {
                string[] keyValue = par.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (keyValue.Length == 2)
                {
                    toReturn.Add(keyValue[0], keyValue[1]);
                }
                else
                {
                    toReturn.Add(keyValue[0], string.Empty); 
                }
            }
            return toReturn;
        }

        #endregion Payments

        #region Main Importer

        [Option("Invite Mails", "invite")]
        public WhatToDoNext ImportMails(string fileName)
        {
            Console.WriteLine(MailSender.MailClient.Host);
            string[] content = File.ReadAllLines(fileName);
            using( TextWriter writer = new StreamWriter(fileName)) {
                int count = 0 ;
                foreach (string line in content) {
                    string[] parts = line.Split(',');
                    Console.Write("» Line Length: {0}", parts.Length);
                    if (parts.Length > 3) {
                        Console.WriteLine(" Already Sent");
                        writer.WriteLine(line);
                        continue;
                    }

                    string mail = parts[0];
                    string nick = parts[1];
                    string lang = parts[2];

                    writer.Write(mail);
                    writer.Write(",");
                    writer.Write(nick);
                    writer.Write(",");
                    writer.Write(lang);

                    ProcessArgs(mail, nick, lang);
                    Console.Write(" Processing...");
                    writer.Write(",sent");
                    ++count;

                    writer.WriteLine();
                    Console.WriteLine();
                    //break;
                }
                Console.WriteLine("{0} invites sent", count);
                writer.Flush();
            }

            return WhatToDoNext.GoAhead;
        }

        private void ProcessArgs(string mail, string nick, string lang)
        {
            try
            {
                MailSender.Send(mail, "noreply@orionsbelt.eu", GetTile(nick, lang), GetBody(nick, lang));
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }

        private string GetBody(string nick, string lang)
        {
            if (lang == "pt") {
                return GetBodyPT(nick);
            }
            return GetBodyEN(nick);
        }

        private static string GetBodyPT(string nick)
        {
            using (TextWriter writer = new StringWriter()) {

                writer.Write("Olá <strong>{0}</strong>,<p/>", nick);

                writer.Write("É com prazer que te informamos que o <a href='http://www.orionsbelt.eu/'>Orion's Belt</a> está a lançar o <a href='http://www.orionsbelt.eu/torneio-intergalactico-premio-dinheiro/'>Torneio Intergaláctico</a>, um ");
                writer.Write("torneio com prémio monetário de <strong>2000€ (R$5000)</strong>. A campanha publicitária irá começar em força ");
                writer.Write("brevemente, e antes que o limite de jogadores seja atingido, gostariamos de te convidar a ");
                writer.Write("participar.");
                writer.Write("<p><a href='http://www.orionsbelt.eu/torneio-intergalactico-premio-dinheiro/'><img src='http://resources.orionsbelt.eu/Institutional/Images/IntergalacticTournament/PlayNow_pt.png' /></a></p>");
                writer.Write("Todos os jogadores registados antes de Setembro que entrem no torneio até dia 19 de Setembro, ");
                writer.Write("irão receber um <strong>bónus de 500 Orions</strong>! Para entrar no torneio é preciso fazer um pagamento de 2€. ");
                writer.Write("Esta módica quantia serve para garantir a motivação, compromisso e principalmente a actividade ");
                writer.Write("dos jogadores inscritos.");
                writer.Write("<p/>");
                writer.Write("Podes ler mais sobre o torneio, e como te preparares para ele na página:<br/>");
                writer.Write("<a href='http://www.orionsbelt.eu/torneio-intergalactico-premio-dinheiro/'>http://www.orionsbelt.eu/torneio-intergalactico-premio-dinheiro/</a>");
                writer.Write("<p/>");
                writer.Write("Ficamos à tua espera!");
                writer.Write("<p/>");
                writer.Write("--<br/>");
                writer.Write("Equipa Orion's Belt<br/>");
                writer.Write("<a href='http://www.orionsbelt.eu'>www.orionsbelt.eu</a>");

                return writer.ToString();
            }
        }

        private static string GetBodyEN(string nick)
        {
            using (TextWriter writer = new StringWriter()) {

                writer.Write("Hello <strong>{0}</strong>,<p/>", nick);

                writer.Write("It's with pleasure that we announce the first <a href='http://www.orionsbelt.eu/intergalactic-tournament-money-prize/'>Intergalactic Tournament</a> at <a href='http://www.orionsbelt.eu/'>Orion's Belt</a>. This is a tournament ");
                writer.Write("with a cash prize of <strong>2500$(2000€)</strong>. The marketing campaign will start shortly, and before the tournament fills up, ");
                writer.Write("we would like to invite you to participate. ");
                writer.Write("<p><a href='http://www.orionsbelt.eu/intergalactic-tournament-money-prize/'><img src='http://resources.orionsbelt.eu/Institutional/Images/IntergalacticTournament/PlayNow_en.png' /></a></p>");
                writer.Write("If you register on the tournament before the 19th of September, you'll won <strong>500 Orions</strong> as a reward. To enter ");
                writer.Write("on the tournament you'll need to make a symbolic payment of 2€. This payment ensures the motivation, commitment and activity of the registered players. ");
                writer.Write("<p/>");
                writer.Write("You can read more about the tournament at:<br/>");
                writer.Write("<a href='http://www.orionsbelt.eu/intergalactic-tournament-money-prize/'>http://intergalactic.orionsbelt.eu/</a>");
                writer.Write("<p/>");
                writer.Write("We'll be waiting for you!");
                writer.Write("<p/>");
                writer.Write("--<br/>");
                writer.Write("Orion's Belt Team<br/>");
                writer.Write("<a href='http://www.orionsbelt.eu'>www.orionsbelt.eu</a>");

                return writer.ToString();
            }
        }

        private string GetTile(string nick, string lang)
        {
            if (lang == "pt") {
                return GetTitlePT();
            }
            return GetTitleEN();
        }

        private static string GetTitlePT()
        {
            return string.Format("Orion's Belt : Torneio Intergaláctico com Prémio Monetário");
        }

        private static string GetTitleEN()
        {
            return string.Format("Orion's Belt : Intergalactic Tournament with Money Prize");
        }

        #endregion Main Importer

        #region Delete Account

        [Option("Deletes Innactive Accounts", "deleteAccount")]
        public WhatToDoNext DeleteAccounts(){
            DeleteAccount.DeleteAllInactiveAccounts();
            return WhatToDoNext.GoAhead;
        }

        #endregion Delete Account

        #region Export Game Rules

        [Option("Export Rules", "export-rules")]
        public WhatToDoNext ExportRules(string outputDir)
        {
            if (!Directory.Exists(outputDir)) {
                throw new Exception("Given directory does not exist");
            }

            using (StreamWriter js = new StreamWriter(Path.Combine(outputDir, "Rules.js"))) {
                using (StreamWriter xml = new StreamWriter(Path.Combine(outputDir, "Rules.xml"))) {
                    xml.WriteLine("<Rules Date='{0}'>", DateTime.Now);
                    js.WriteLine("var Rules = { ");
                    js.WriteLine("\tResources : [");
                    foreach (IResourceInfo info in RulesUtils.GetResources()) {
                        WriteResource(js, xml, info);
                    }
                    js.WriteLine("\t\t{ Name : 'End' }");
                    js.WriteLine("\t],");
                    js.WriteLine("\tDate : '{0}' \n}};", DateTime.Now);
                    xml.WriteLine("</Rules>", DateTime.Now);
                }
            }

            return WhatToDoNext.GoAhead;
        }

        private void WriteResource(StreamWriter js, StreamWriter xml, IResourceInfo info)
        {
            xml.Write("\t<Resource ");
            js.Write("\t\t{ ");
            foreach (PropertyInfo propertyInfo in info.GetType().GetProperties()) {
                if (IsToIgnore(propertyInfo)) {
                    continue;
                }
                xml.Write("{0}='{1}' ", propertyInfo.Name, PreparePropValue(propertyInfo, info));
                js.Write("{0} : {1}, ", propertyInfo.Name, PrepareJsPropValue(propertyInfo, info));
            }
            xml.WriteLine(">");
            xml.WriteLine("\t\t<Races>");
            js.WriteLine();
            js.Write("\t\t\tRaces : [");
            foreach (Race race in info.Races) {
                xml.WriteLine("\t\t\t<Race Name='{0}' />", race);
                js.Write("'{0}'", race);
            }
            js.WriteLine("]");
            xml.WriteLine("\t\t</Races>");

            //IResourceWithRulesInfo resWithRules = info as IResourceWithRulesInfo;
            //if (resWithRules != null) {
            //    xml.WriteLine("\t\t<Rules>");
            //    foreach(IRule rule in resWithRules.Rules.GetAll()) {
                    
            //        xml.WriteLine("\t\t\t<Rule />");
            //    }
            //    xml.WriteLine("\t\t</Rules>");
            //}

            js.WriteLine("\t\t},");
            xml.WriteLine("\t</Resource>");
        }

        private bool IsToIgnore(PropertyInfo propertyInfo)
        {
            foreach (string prop in RulesIgnoreProp) {
                if (prop == propertyInfo.Name) {
                    return true;
                }
            }
            return false;
        }

        private string[] RulesIgnoreProp = { "Resource", "Races" };

        private object PrepareJsPropValue(PropertyInfo propertyInfo, IResourceInfo info)
        {
            object value = PreparePropValue(propertyInfo, info);
            if (propertyInfo.PropertyType == typeof(int)) {
                return value;
            }
            if (propertyInfo.PropertyType == typeof(bool)) {
                return value.ToString().ToLower();
            }
            return string.Format("'{0}'", value);
        }

        private object PreparePropValue(PropertyInfo propertyInfo, IResourceInfo info)
        {
            object value = propertyInfo.GetValue(info, null);
            return value;
        }

        #endregion Export Game Rules

        #region API

        [Option("Dump Universe", "dump-universe")]
        public WhatToDoNext DumpUniverse(string fileName)
        {
            IList info = GetUniverseData();

            using (TextWriter writer = new StreamWriter(new GZipStream(new FileStream(fileName, FileMode.OpenOrCreate), CompressionMode.Compress))) {
                writer.WriteLine("<Universe Server='{0}' Date='{1}' Tick='{2}'>", Server.Properties.Name, DateTime.Now.ToString("r"), Clock.Instance.Tick);
                foreach (IList group in info) {
                    writer.WriteLine("\t<Sector Coordinate='{0}.{1}.{2}.{3}' Type='{4}' IsInBattle='{5}' Level='{6}' IsMoving='{7}' Alliance='{8}' HasPlayer='{9}' />",
                            group[0], group[1], group[2], group[3], group[4], group[5], group[6], group[7], ProtectNull(group[8]), HasPlayer(group[9]) 
                        );
                }
                writer.WriteLine("</Universe>");
                writer.Flush();
            }
            
            return WhatToDoNext.GoAhead;
        }

        private static IList GetUniverseData()
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance())
            {
                return session.Query("select sector.SystemX, sector.SystemY, sector.SectorX, sector.SectorY, sector.Type, sector.IsInBattle, sector.Level, sector.IsMoving, alliance.Name, owner.Name, fleet.Name, fleet.Cargo from SpecializedSectorStorage sector left join sector.OwnerNHibernate owner left join sector.FleetsNHibernate fleet left join owner.AllianceNHibernate alliance where sector.SystemX > 0");
            }
        }

        private object HasPlayer(object p)
        {
            return p != null;
        }

        private object ProtectNull(object p)
        {
            if (p != null) {
                return p;
            }
            return string.Empty;
        }

        [Option("Universe Views", "universe-views")]
        public WhatToDoNext UniverseViews(string dir)
        {
            IList rawall = GetUniverseData();
            Dictionary<string, IList> all = PrepareAll(rawall);

            int h = 37 * Coordinate.MaxCoordinate.X * 2;
            int w = 37 * Coordinate.MaxCoordinate.Y * 2;

            WritePlanets(Path.Combine(dir, "Planets.gif"), all, h, w);
            WriteFleets(Path.Combine(dir, "Fleets.gif"), all, h, w);
            WriteAlliances(Path.Combine(dir, "Alliances.gif"), all, h, w);
            WriteFleetsWithCargo(Path.Combine(dir, "FleetsWithCargo.gif"), all, h, w);
            return WhatToDoNext.GoAhead;
        }

        private void WritePlanets(string file, Dictionary<string, IList> all, int h, int w)
        {
            Bitmap image = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(image);
            Brush bbrush = new SolidBrush(Color.Black);
            Brush ownerbrush = new SolidBrush(Color.Yellow);
            Brush emptybrush = new SolidBrush(Color.Gray);
            Brush battlebrush = new SolidBrush(Color.Red);

            g.FillRectangle(bbrush, 0, 0, w, h);

            foreach (SectorCoordinate coordinate in SectorUtils.GetAllHotCoordinates())
            {
                int posx = ((coordinate.System.Y - 1) * 10 + coordinate.Sector.Y) * 2;
                int posy = ((coordinate.System.X - 1) * 7 + coordinate.Sector.X) * 2;
                IList info = GetInfo(all, coordinate);
                if (info != null && CheckType(info, "PlanetSector", "PlanetBattleSector")) {
                    if( IsInBattle(info) ) {
                        g.FillRectangle(battlebrush, posx, posy, 2, 2);
                    } else if (HasOwner(info)) {
                        g.FillRectangle(ownerbrush, posx, posy, 2, 2);
                    } else {
                        g.FillRectangle(emptybrush, posx, posy, 2, 2);
                    }
                }
            }

            image.Save(file, ImageFormat.Gif);
        }

        private bool IsInBattle(IList iList)
        {
            return (bool) iList[5];
        }

        private void WriteFleets(string file, Dictionary<string, IList> all, int h, int w)
        {
            Bitmap image = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(image);
            Brush bbrush = new SolidBrush(Color.Black);
            Brush ownerbrush = new SolidBrush(Color.Yellow);
            Brush emptybrush = new SolidBrush(Color.Gray);
            Brush battlebrush = new SolidBrush(Color.Red);

            g.FillRectangle(bbrush, 0, 0, w, h);

            foreach (SectorCoordinate coordinate in SectorUtils.GetAllHotCoordinates()) {
                int posx = ((coordinate.System.Y - 1) * 10 + coordinate.Sector.Y) * 2;
                int posy = ((coordinate.System.X - 1) * 7 + coordinate.Sector.X) * 2;
                IList info = GetInfo(all, coordinate);
                if (info != null && CheckType(info, "FleetSector", "PlanetBattleSector", "FleetBattleSector")) {
                    if (IsInBattle(info)) {
                        g.FillRectangle(battlebrush, posx, posy, 2, 2);
                    } else {
                        g.FillRectangle(ownerbrush, posx, posy, 2, 2);
                    }
                }
            }

            image.Save(file, ImageFormat.Gif);
        }

        private void WriteFleetsWithCargo(string file, Dictionary<string, IList> all, int h, int w)
        {
            Console.WriteLine("Writing fleets with cargo to {0}...", file);
            Bitmap image = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(image);
            Brush bbrush = new SolidBrush(Color.Black);
            Brush green = new SolidBrush(Color.GreenYellow);
            Brush orange = new SolidBrush(Color.Orange);
            Brush blue = new SolidBrush(Color.BlueViolet);

            g.FillRectangle(bbrush, 0, 0, w, h);

            foreach (SectorCoordinate coordinate in SectorUtils.GetAllHotCoordinates()) {
                int posx = ((coordinate.System.Y - 1) * 10 + coordinate.Sector.Y) * 2;
                int posy = ((coordinate.System.X - 1) * 7 + coordinate.Sector.X) * 2;
                IList info = GetInfo(all, coordinate);
                if (info != null && CheckType(info, "FleetSector", "FleetBattleSector", "MarketSector")) {
                    if (HasFleetWithCargo(info)) {
                        if (HasTradeRouteResources((string)info[11])) {
                            g.FillRectangle(orange, posx, posy, 2, 2);
                        } else {
                            g.FillRectangle(green, posx, posy, 2, 2);
                        }
                        Console.WriteLine("Cargo: {0}", info[11]);
                    }
                    if ((string)info[4] == "MarketSector") {
                        g.FillRectangle(blue, posx, posy, 2, 2);
                    }
                }
            }

            image.Save(file, ImageFormat.Gif);
        }

        private bool HasTradeRouteResources(string cargo)
        {
            foreach (IResourceInfo info in RulesUtils.GetTradeResources()) {
                if (cargo.Contains(info.Name)) {
                    return true;
                }
            }
            return false;
        }

        private bool HasFleetWithCargo(IList info)
        {
            return !string.IsNullOrEmpty((string)info[11]);
        }

        private void WriteAlliances(string file, Dictionary<string, IList> all, int h, int w)
        {
            Bitmap image = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(image);
            Brush bbrush = new SolidBrush(Color.Black);
            Brush noalliance = new SolidBrush(Color.Gray);
            Brush emptybrush = new SolidBrush(Color.Gray);

            g.FillRectangle(bbrush, 0, 0, w, h);

            foreach (SectorCoordinate coordinate in SectorUtils.GetAllHotCoordinates()) {
                int posx = ((coordinate.System.Y - 1) * 10 + coordinate.Sector.Y) *2;
                int posy = ((coordinate.System.X - 1) * 7 + coordinate.Sector.X ) *2;
                IList info = GetInfo(all, coordinate);
                if (info != null && HasOwner(info)) {
                    string alliance = (string)info[8];
                    if (alliance == null) {
                        g.FillRectangle(noalliance, posx, posy, 2, 2);
                    } else {
                        g.FillRectangle(GetAllianceBrush(alliance), posx, posy, 2, 2);
                    }
                }
            }

            image.Save(file, ImageFormat.Gif);
        }

        private Dictionary<string, Color> allianceColors = new Dictionary<string, Color>();
        private static Color[] colors = { Color.Pink, Color.Yellow, Color.Green, Color.Orange, Color.Blue, Color.Beige, Color.Aquamarine, Color.Azure, Color.Chocolate, Color.Cornsilk };
        private Brush GetAllianceBrush(string alliance)
        {
            if (allianceColors.ContainsKey(alliance)) {
                return new SolidBrush(allianceColors[alliance]);
            }
            Color color = colors[allianceColors.Count % colors.Length];
            allianceColors.Add(alliance, color);
            return new SolidBrush(color);
        }

        private bool CheckType(IList info, params string[] types)
        {
            foreach (string type in types) {
                if (info[4].ToString() == type) {
                    return true;
                }
            }
            return false;
        }

        private bool HasOwner(IList info)
        {
            return (bool) HasPlayer(info[9]);
        }

        private Dictionary<string, IList> PrepareAll(IList rawall)
        {
            Dictionary<string, IList> dic = new Dictionary<string, IList>();
            dic.Add("1.1.1.1", (IList)rawall[0]);
            foreach (IList list in rawall) {
                string raw = string.Format("{0}:{1}:{2}:{3}", list[0], list[1], list[2], list[3]);
                if (!dic.ContainsKey(raw)) {
                    dic.Add(raw, list);
                }
            }

            return dic;
        }

        private IList GetInfo(Dictionary<string, IList> all, SectorCoordinate coordinate)
        {
            if( all.ContainsKey(coordinate.ToString())) {
                return all[coordinate.ToString()];
            }
            return null;
        }

        #endregion API

		#region Mobs

		[Option("Create Mobs", "mobs")]
		public WhatToDoNext CreateMobs() {
            DateTime start = DateTime.Now;
			
            Mobs.CreateFactionMetallicBeard();
            Mobs.CreateFactionSpaceForce();

            Console.WriteLine("# Time Spent: {0} seconds", (DateTime.Now - start).TotalSeconds);

			return WhatToDoNext.GoAhead;
		}

		[Option("Respawn Mobs", "mobsresp")]
		public WhatToDoNext RespawnMobs() {
			Mobs.RespawnMercs();
            Mobs.RespawnSpaceForce();
			return WhatToDoNext.GoAhead;
		}

		#endregion Mobs

        #region Maintenance

        [Option("Gets mono pid from a file generated by ps", "get-mono-pid")]
        public WhatToDoNext GetMonoPid(string monoInfo)
        {
            writeElapsed = false;
            string[] lines = File.ReadAllLines(monoInfo);
            foreach (string line in lines) { 
                if( !line.Contains("grep" )) {
                    int idx = line.IndexOf('?');
                    Console.WriteLine(line.Substring(0, idx).Trim());
                }
            }

            return WhatToDoNext.GoAhead;
        }

        #endregion Maintenance

        #region Relic Processing

        [Option("Processes relics", "process-relics")]
        public WhatToDoNext ProcessRelics()
        {
            RelicsManager.ProcessIncome();
            return WhatToDoNext.GoAhead;
        }

        [Option("Adds relics to a zone level", "add-relics")]
        public WhatToDoNext ProcessRelics(int zoneLevel)
        {
            RelicsManager.AddRelics(zoneLevel);
            return WhatToDoNext.GoAhead;
        }

        #endregion Relic Processing

        #region Quests

        [Option("Processes finished custom bounties", "end-bounties")]
        public WhatToDoNext ProcessCustomBounties()
        {
            EndBounties.Resolve();
            return WhatToDoNext.GoAhead;
        }

        #endregion Quests

        #region Referrals

        [Option("Referrals prices", "referal-prizes")]
        public WhatToDoNext ReferralsPrizes()
        {
            IList<Principal> prins;
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                prins = persistance.Select();
                Console.WriteLine("Processing {0} principals...", prins.Count);

                foreach (Principal prin in prins)
                {
                    IList<Principal> referrals = GetReferrals(prin.Id, prins);
                    Console.WriteLine("Principal {2} have {0} referrals, {1} are already counted.", 
                        referrals.Count, prin.ReferrerPriceCount,prin.Name);
                    if (referrals.Count == 0 || referrals.Count == prin.ReferrerPriceCount)
                    {
                        continue;
                    }

                    int majorLevel5 = GetCountPrincipalHigherLevel5(referrals);

                    Console.WriteLine("Found {0} referrals with level equal or higher than 5", majorLevel5);

                    if (majorLevel5 == prin.ReferrerPriceCount)
                    {
                        continue;
                    }

                    int orions = 0;
                    for (int iter = prin.ReferrerPriceCount; iter < majorLevel5; ++iter)
                    {
                        Console.WriteLine("Giving 100 orions");
                        orions += 100;
                        TransactionManager.ReferalTransaction(prin, 100, persistance);
                        if (iter%10 == 9)
                        {
                            Console.WriteLine("Giving 1000 orions");
                            orions += 1000;
                            TransactionManager.ReferalTransaction(prin, 1000, persistance);
                        }
                    }

                    prin.Credits += orions;
                    prin.ReferrerPriceCount = majorLevel5;
                    persistance.Update(prin);
                    //dar os prémios porque majorLevel5 > prin.ReferrerPriceCount
                }
                persistance.Flush();
            }

            return WhatToDoNext.GoAhead;
        }

        private static int GetCountPrincipalHigherLevel5(IEnumerable<Principal> referrals)
        {
            int toReturn = 0;

            foreach (Principal referral in referrals)
            {
                foreach (PlayerStorage storage in referral.Player)
                {
                    if(storage.PlanetLevel >= 5)
                    {
                        ++toReturn;
                        break;
                    }
                }
            }
            return toReturn;
        }

        private static IList<Principal> GetReferrals(int id,IEnumerable<Principal> prins)
        {
            IList<Principal> toReturn = new List<Principal>();

            foreach (Principal prin in prins)
            {
                if(id == prin.ReferrerId)
                {
                    toReturn.Add(prin);
                }
            }
            return toReturn;
        }

        #endregion Referrals

        #region Fleets

        [Option("Advances a tick in the private zone on the server", "fleetResourceTrim")]
        public WhatToDoNext FleetResourceTrim() {
            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance()) {
                persistance.StartTransaction();

                IList<Fleet> fleets = persistance.TypedQuery("select f from SpecializedFleet f where f.Cargo <> '' ");

                foreach (Fleet fleet in fleets) {
                    //Console.WriteLine("» Parsing fleet {0}", fleet.Name);
                    Dictionary<IResourceInfo,int> resources = PlanetConversion.ParseModifiers(fleet.Cargo);
                    List<IResourceInfo> list = new List<IResourceInfo>(resources.Keys);
                    foreach (IResourceInfo r in list) {
                        int q = resources[r];
                        if (r.IsRare && q > 100000) {
                            Console.WriteLine("Fleet: {2}; Owner:{3}; Correcting Resource {0}; Value: {1}", r.Name, q, fleet.Name, fleet.PlayerOwner.Name);
                            resources[r] = 100000;
                        }
                        if (!r.IsRare && q > 250000) {
                            Console.WriteLine("Fleet: {2}; Owner:{3}; Correcting Resource {0}; Value: {1}", r.Name, q, fleet.Name, fleet.PlayerOwner.Name);
                            resources[r] = 250000;
                        }

                    }
                    fleet.Cargo = PlanetConversion.ModifiersRepresentation(resources);
                    persistance.Update(fleet);
                }
                persistance.CommitTransaction();
            }
            return WhatToDoNext.GoAhead;
        }


        #endregion


        [Option("Advances a tick in the private zone on the server", "test")]
        public WhatToDoNext Test() {
            IList<Principal> b = Hql.Query<Principal>("select p from SpecializedPrincipal p where p.Name = 'maw'");
            //IList<Battle> b = Hql.Query<Battle>("select p from SpecializedBattle p where p.Id = 1");


            DateTime start = DateTime.Now;
            IList<Principal> p = Hql.Query<Principal>("select p from SpecializedPrincipal p inner join fetch p.PlayerNHibernate where p.Name = 'tsousa'");
            PlayerStorage pl = p[0].Player[0];
            Console.WriteLine(pl.Name);
            Console.WriteLine("#Spent {0} ms", (DateTime.Now - start).TotalMilliseconds);
            
            start = DateTime.Now;
            IList<Principal> princpals = Hql.Query<Principal>("select p from SpecializedPrincipal p where p.Name = 'nunos'");
            Principal p1 = princpals[0];
            IList<PlayerStorage> playerStorage = Hql.Query<PlayerStorage>(string.Format("select p from SpecializedPlayerStorage p where p.PrincipalNHibernate.Id = {0}", p1.Id));
            PlayerStorage ps = playerStorage[0];
            Console.WriteLine(ps.Name);
            Console.WriteLine("#Spent {0} ms", (DateTime.Now - start).TotalMilliseconds);

            
            Console.ReadLine();

            return WhatToDoNext.GoAhead;

        }

    };
}

