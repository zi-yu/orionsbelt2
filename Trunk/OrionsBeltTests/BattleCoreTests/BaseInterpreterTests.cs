using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBeltTests.BattleCoreTests {

	public class BaseInterpreterTests : BaseTests {

		#region Fields

		protected readonly List<Principal> principals = new List<Principal>();

		#endregion Fields

		#region Principals

		private void CreatePrincipal( int id, string name, int rank, IPersistance<Principal> persistance) {
			Principal p = persistance.Create();
			p.Id = id;
			p.Name = name;
			p.EloRanking = rank;
			principals.Add(p);

			persistance.Update(p);
		}

		private void CreatePrincipals() {
			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				CreatePrincipal(1, "Pyro", 1, persistance);
				CreatePrincipal(2, "Pre", 20, persistance);
				CreatePrincipal(3, "Shadow", 40, persistance);
				CreatePrincipal(4, "Anfernius", 9, persistance);
			}
		}

		#endregion Principals

		#region Battle

		private static Fleet CreateFleet( int id, string name, Principal owner) {
			using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance() ) {
				Fleet fleet = persistance.Create();
				fleet.Id = id;
				fleet.Name = name;
				fleet.IsMovable = true;
				fleet.TournamentFleet = false;
				fleet.Units = "r-100";
				fleet.PrincipalOwner = owner;

				persistance.Update(fleet);

				return fleet;
			}
		}

		private static void FillBattleInformation( Battle battle, Principal principal, Fleet fleet, int teamNumber ) {
			using( IPlayerBattleInformationPersistance persistance = Persistance.Instance.GetPlayerBattleInformationPersistance() ) {
				PlayerBattleInformation playerBattleInformation = persistance.Create();
				playerBattleInformation.InitialContainer = "r-100";
				playerBattleInformation.Battle = battle;
				playerBattleInformation.HasPositioned = false;
				playerBattleInformation.HasLost = false;
				playerBattleInformation.HasGaveUp = false;
				playerBattleInformation.TeamNumber = teamNumber;
				playerBattleInformation.Owner = principal.Id;
				playerBattleInformation.UpdateFleet = true;
				playerBattleInformation.FleetId = fleet.Id;
				playerBattleInformation.Name = principal.Name; 

				battle.PlayerInformation.Add(playerBattleInformation);
			}
		}

		private static void FillBattleExtension( Battle battle ) {
			using( IBattleExtentionPersistance persistance = Persistance.Instance.GetBattleExtentionPersistance() ) {
				BattleExtention extension = persistance.Create();
				extension.BattleFinalStates = string.Empty;
				extension.BattleMovements = string.Empty;

				battle.BattleExtension.Add(extension);
			}
		}

		private Battle CreateBattle1vs1( BattleType type ) {
			return CreateBattle1vs1(type, BattleMode.Friendly);
		}

		private Battle CreateBattle1vs1( BattleType type, BattleMode mode ) {
			Battle battle;
			using( IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance() ) {
				battle = persistance.Create();
			}

			Fleet f1 = CreateFleet(1, "Fleet1", principals[0]);
			Fleet f2 = CreateFleet(2, "Fleet2", principals[1]);

			battle.PlayerInformation = new List<PlayerBattleInformation>();
			
			battle.CurrentPlayer = principals[0].Id;
			battle.CurrentTurn = 1;
			battle.HasEnded = false;
			battle.BattleType = type.ToString();
			battle.BattleMode = mode.ToString();
			battle.Terrain = Terrain.Rock.ToString();
			battle.TimeoutsAllowed = 3;
		    battle.IsDeployTime = true;

			FillBattleInformation(battle, principals[0], f1, 1);
			FillBattleInformation(battle, principals[1], f2, 2);
			FillBattleExtension(battle);

			return battle;
		}
		private Battle CreateBattle2vs2( BattleType type ) {
			return CreateBattle2vs2(type, BattleMode.Friendly);
		}

		private Battle CreateBattle2vs2( BattleType type, BattleMode mode ) {
			Battle battle;
			using( IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance() ) {
				battle = persistance.Create();
			}

			Fleet f1 = CreateFleet(1, "Fleet1", principals[0]);
			Fleet f2 = CreateFleet(2, "Fleet2", principals[1]);
			Fleet f3 = CreateFleet(3, "Fleet3", principals[2]);
			Fleet f4 = CreateFleet(4, "Fleet4", principals[3]);

			battle.PlayerInformation = new List<PlayerBattleInformation>();
			battle.CurrentPlayer = principals[0].Id;
			battle.CurrentTurn = 1;
			battle.HasEnded = false;
			battle.BattleType = type.ToString();
			battle.BattleMode = mode.ToString();
			battle.Terrain = Terrain.Rock.ToString();
			battle.TimeoutsAllowed = 3;
		    battle.IsDeployTime = true;

			FillBattleInformation(battle, principals[0], f1, 1);
			FillBattleInformation(battle, principals[1], f2, 2);
			FillBattleInformation(battle, principals[2], f3, 3);
			FillBattleInformation(battle, principals[3], f4, 4);
			FillBattleExtension(battle);

			return battle;
		}

		#endregion

		#region Utils
		
		#region Create Battles

		protected Battle GetBattle() {
			CreatePrincipals();
			return CreateBattle1vs1(BattleType.TotalAnnihalation);
		}

		protected Battle GetBattle( BattleType type ) {
			CreatePrincipals();
			return CreateBattle1vs1(type);
		}

		protected Battle GetBattle( BattleType type, BattleMode mode ) {
			CreatePrincipals();
			return CreateBattle1vs1(type, mode);
		}

		protected Battle GetBattle4Players() {
			CreatePrincipals();
			return CreateBattle2vs2(BattleType.TotalAnnihalation4);
		}

		protected Battle GetBattle4Players( BattleType type ) {
			CreatePrincipals();
			return CreateBattle2vs2(type);
		}

		protected Battle GetBattle4Players( BattleType type, BattleMode mode ) {
			CreatePrincipals();
			return CreateBattle2vs2(type,mode);
		}

		#endregion Create Battles

		protected static string GetFailedMessages( Result result ) {
			StringBuilder builder = new StringBuilder();
			foreach( ResultItem item in result.Failed) {
				builder.AppendFormat("{0}; ", item.Log());
			}
			return builder.ToString();
		}

		protected static void ValidateFinalState( Battle battle, string expectedFinalState ) {
			string[] finalState = battle.BattleExtension[0].BattleFinalStates.Split('|');
			string final = finalState[finalState.Length - 1];

			final = Sort(final);
			expectedFinalState = Sort(expectedFinalState);
			
			Assert.AreEqual(expectedFinalState, final);
		}

		private static string Sort( string final ) {
			string[] c = final.Split(';');
			List<string> finalList = new List<string>(c);
			finalList.Sort();
			StringBuilder builder = new StringBuilder();
			foreach( string s in finalList ) {
				builder.AppendFormat("{0};",s);
			}
			return builder.ToString();
		}

		#endregion Utils

	}
}