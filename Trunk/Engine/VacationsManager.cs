using System.Collections;
using System.Collections.Generic;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using System.Web;
using OrionsBelt.WebComponents;
using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Engine.Alliances;
using System.IO;
using OrionsBelt.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Vacations utilities
    /// </summary>
    public static class VacationsManager {

        #region Vacations

        public static bool BuyVacationDays(Principal principal, int days, int orions)
        {
            if (principal.Credits < orions)
            {
                return false;
            }
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                persistance.StartTransaction();
                principal.AvailableVacationTicks += Clock.Instance.ConvertToTicks(TimeSpan.FromDays(days));
                principal.Credits -= orions;
                persistance.Update(principal);
                TransactionManager.VacationTransaction(principal, orions, days, persistance);
                persistance.CommitTransaction();
            }
            return true;
        }

        internal static void ProcessVacationTimeout(IList<Principal> principals)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                persistance.StartTransaction();
                foreach (Principal principal in principals) {
                    Console.WriteLine("\tProcessing... {0}", principal.Name);
                    VacationsManager.ProcessVacationTimeout(persistance, principal);
                }
                persistance.CommitTransaction();
            }
        }

        internal static void ProcessVacationTimeout(IPrincipalPersistance persistance, Principal principal)
        {
            if (principal.AvailableVacationTicks > 0) {
                principal.VacationEndtick += principal.AvailableVacationTicks;
                principal.AvailableVacationTicks = 0;
                persistance.Update(principal);
                return;
            }
            ForceEndVacations(persistance, principal);
        }

        public static void ToogleVacations(Principal principal)
        {
            if (principal.VacationStartTick > 0) {
                EndVacations(principal);
            } else {
                StartVacations(principal);
            }
        }

        public static bool StartVacations(Principal principal)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {

                persistance.StartTransaction();
                if (StartVacations(persistance, principal)) {
                    persistance.CommitTransaction();
                    return true;
                } else {
                    persistance.RollbackTransaction();
                    return false;
                }
            }
        }

        public static bool StartVacations(IPersistanceSession session, Principal principal)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance(session))
            {
                if (principal.AvailableVacationTicks == 0) {
                    return false;
                }
                principal.VacationStartTick = Clock.Instance.Tick;
                principal.VacationEndtick = Clock.Instance.Tick + principal.AvailableVacationTicks;
                principal.AvailableVacationTicks = 0;
                principal.IsOnVacations = true;
                UpdatePlayersVacation(persistance, principal, true);

                ProcessPlayers(persistance, principal);
                ProcessFreezeBattleTimeouts(persistance, principal, 0);

                persistance.Update(principal);

                return true;
            }
        }

		private static string GetWhere(Principal principal) {
            using (StringWriter writer = new StringWriter()) {
                IList<PlayerStorage> players = Hql.Query<PlayerStorage>("select p from SpecializedPlayerStorage p where p.PrincipalNHibernate.Id = :id", Hql.Param("id", principal.Id));
                foreach (PlayerStorage player in players) {
                    writer.Write(" or ( b.BattleMode = 'Battle' and pi.Owner = {0} ) or ( b.BattleMode = 'Arena' and pi.Owner = {0} ) ", player.Id);
                }
                return writer.ToString();
            }
		}

		private static string GetWhereBattleIds(IList<Battle> battles) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("Data = '{0}'", battles[0].Id);
                for (int i = 1; i < battles.Count; ++i) {
                    writer.Write("or Data = '{0}'", battles[i].Id);
                }
                return writer.ToString();
            }
		}

		private static IList<Battle> GetBattles(IPrincipalPersistance session, Principal principal ) {
			string query = @"select b from SpecializedBattle b inner join fetch b.PlayerInformationNHibernate pi where b.HasEnded = 0 and ( ( b.BattleMode = 'Friendly' and pi.Owner = {0} ) or ( b.BattleMode = 'Tournament' and pi.Owner = {0} ) {1})";
			string hql = string.Format(query, principal.Id, GetWhere(principal));

			using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance(session)) {
				IList<Battle> battles = persistance.TypedQuery(hql);
				return battles;
			}	
		}

		private static IList<TimedActionStorage> GetActions(IList<Battle> battles) {
			string query = string.Format(@"select a from SpecializedTimedActionStorage a inner join a.BattleNHibernate where {0}", GetWhereBattleIds(battles));
			return Hql.Query<TimedActionStorage>(query);
		}

        private static void ProcessFreezeBattleTimeouts(IPrincipalPersistance session, Principal principal, int vacationTicks)
        {
			IList<Battle> battles = GetBattles(session,principal);
            if (battles == null || battles.Count == 0) {
                return;
            }
        	IList<TimedActionStorage> actions = GetActions(battles);
            ToggleEndTick(session, actions, principal, 0, true);
        }

        private static void ToggleEndTick(IPrincipalPersistance session, IList<TimedActionStorage> actions, Principal principal, int delta, bool start){
            IList<PlayerStorage> players = Hql.Query<PlayerStorage>("select p from SpecializedPlayerStorage p where p.PrincipalNHibernate.Id = :id", Hql.Param("id", principal.Id));
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance(session)){
                foreach (TimedActionStorage action in actions) {
                    if (EvalIsCurrentPlayer(action.Battle, principal, players)) {
                        action.EndTick = Math.Abs(action.EndTick);
                        if (start) {
                            action.EndTick *= -1;
                        }
                        action.EndTick = action.EndTick + delta;
                        if (action.EndTick > (Clock.Instance.Tick + 144) ) {
                            action.EndTick = Clock.Instance.Tick + 144;
                        }
                        persistance.Update(action);    
                    }
                }
            }
        }

        private static bool EvalIsCurrentPlayer(Battle battle, Principal principal, IList<PlayerStorage> players) {
            if (battle.IsDeployTime){
            	return !battle.PlayerInformation[0].HasPositioned;
            }
            if( battle.CurrentPlayer == principal.Id) {
                return true;
            }
            foreach (PlayerStorage p in players) {
                if (battle.CurrentPlayer == p.Id){
                    return true;
                }   
            }
            return false;
        }

		private static void ProcessUnfreezeBattleTimeouts(IPrincipalPersistance session, Principal principal, int vacationTicks)
        {
			IList<Battle> battles = GetBattles(session, principal);
            if (battles == null || battles.Count == 0)  {
                return;
            }
			IList<TimedActionStorage> actions = GetActions(battles);
            ToggleEndTick(session, actions, principal, vacationTicks, false);
        }

        public static void ForceEndVacations(IPersistanceSession session, Principal principal)
        {
            EndVacations(session, principal);
        }

        public static void EndVacations(Principal principal)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())  {
                persistance.StartTransaction();
                EndVacations(persistance, principal);
                persistance.CommitTransaction();
            }
        }

        public static void EndVacations(IPersistanceSession session, Principal principal)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance(session)) {

                int vacationTicks = Clock.Instance.Tick - principal.VacationStartTick;
                principal.AvailableVacationTicks += 
                    (principal.VacationEndtick - principal.VacationStartTick) - vacationTicks;

                principal.VacationStartTick = 0;
                principal.VacationEndtick = 0;
                principal.IsOnVacations = false;
                NormalizeVacationValues(principal);

                UpdatePlayersVacation(persistance, principal,false);
                UpdatePlayersProcessedTick(persistance, principal);
                ProcessUnfreezeBattleTimeouts(persistance, principal, vacationTicks);

                persistance.Update(principal);
            }
        }

        private static void UpdatePlayersVacation(IPrincipalPersistance session, Principal principal, bool state)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance(session))
            {
                IList<PlayerStorage> storages = persistance.TypedQuery("select player from SpecializedPlayerStorage player where player.PrincipalNHibernate.Id = {0}", principal.Id);
                foreach (PlayerStorage storage in storages)
                {
                    storage.IsOnVacations = state;
                    persistance.Update(storage);
                }
            }
        }

        public static void NormalizeVacationValues(Principal principal)
        {
            if (principal.AvailableVacationTicks < 0) {
                principal.AvailableVacationTicks = 0;
            }

            if (principal.AvailableVacationTicks > MaxAvailableVacations) {
                principal.AvailableVacationTicks = MaxAvailableVacations;
            }
        }

        private static void ProcessPlayers(IPersistanceSession session, Principal principal)
        {
            using(IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance(session)) {
                IList<PlayerStorage> storages = persistance.TypedQuery("select player from SpecializedPlayerStorage player where player.PrincipalNHibernate.Id = {0}", principal.Id);
                foreach(PlayerStorage storage in storages ) {
                    IPlayer player = PlayerUtils.LoadPlayer(storage);
                    PlayerUtils.Current = player;
                    GameEngine.ProcessPlayer(player);
                    GameEngine.Persist(player, false, false);
                }
            }
        }

        private static void UpdatePlayersProcessedTick(IPersistanceSession session, Principal principal)
        {
            using(IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance(session)) {
                IList<PlayerStorage> storages = persistance.TypedQuery("select player from SpecializedPlayerStorage player inner join fetch player.PlanetsNHibernate where player.PrincipalNHibernate.Id = {0}", principal.Id);
                foreach(PlayerStorage storage in storages ) {
                    storage.LastProcessedTick = Clock.Instance.Tick;
                    persistance.Update(storage);
                }
            }
        }

        public static int MaxAvailableVacations {
            get { return 144 * 7 * 2; }
        }

        public static int AutoStartVacationsTicks {
            get { return 5; }
        }

        internal static void CheckAutoStartVacations()
        {
            IList<Battle> battles = Hql.StatelessQuery<Battle>("select battle from SpecializedBattle battle inner join battle.TimedActionNHibernate action where action.EndTick = :tick and battle.HasEnded = 0 and battle.BattleMode != 'Friendly'", Hql.Param("tick", Clock.Instance.Tick + AutoStartVacationsTicks));
            Console.WriteLine("\t. Found {0} battles ending on tick {1}", battles.Count, Clock.Instance.Tick + AutoStartVacationsTicks);
            if (battles.Count == 0) {
                return;
            }

            using (TextWriter principalsQuery = new StringWriter()) {
                using (TextWriter playersQuery = new StringWriter()) {

                    WriteQueries(battles, principalsQuery, playersQuery);

                    BulkStartVacations(principalsQuery.ToString());
                    BulkStartVacations(playersQuery.ToString());
                }
            }
        }

        private static void BulkStartVacations(string query)
        {
            IList<Principal> principals = Hql.Query<Principal>(query, Hql.Param("date", DateTime.Now.AddHours(-2)));
            foreach (Principal principal in principals) {
                Console.WriteLine("\t\t. Starting vacations for player {0}...", principal.Name);
                BulkStartVacations(principal);
            }
        }

        private static void BulkStartVacations(Principal principal)
        {
            if (principal.Credits < AutoStartVacationsCost) {
                return;
            }
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                persistance.StartTransaction();
                if (StartVacations(persistance, principal)) {
                    principal.Credits -= AutoStartVacationsCost;
                    persistance.Update(principal);
                    Messenger.Add(new AutoVacationsStarted(principal.Id), persistance);
                    TransactionManager.AutoVacationTransaction(principal, AutoStartVacationsCost, persistance);
                    persistance.CommitTransaction();
                } else {
                    persistance.RollbackTransaction();
                }
            }
        }

        public static int AutoStartVacationsCost {
            get { return 50; }
        }

        private static void WriteQueries(IList<Battle> battles, TextWriter principalsQuery, TextWriter playersQuery)
        {
            principalsQuery.Write("select principal from SpecializedPrincipal principal where principal.AutoStartVacations = 1 and principal.VacationStartTick = 0 and principal.LastLogin < :date and (");
            playersQuery.Write("select principal from SpecializedPrincipal principal inner join principal.PlayerNHibernate player where principal.AutoStartVacations = 1 and principal.VacationStartTick = 0 and principal.LastLogin < :date and (");

            foreach (Battle battle in battles) {
                Console.WriteLine("\t\tBattle #{0}", battle.Id);
                if (battle.BattleMode == BattleMode.Arena.ToString() || battle.BattleMode == BattleMode.Battle.ToString()) {
                    Console.WriteLine("\t\t\tMode: Player");
                    WritePlayers(playersQuery, battle);
                } else {
                    Console.WriteLine("\t\t\tMode: Principal");
                    WritePrincipals(principalsQuery, battle);
                }
            }

            principalsQuery.Write(" 0=1)");
            playersQuery.Write(" 0=1)");

            Console.WriteLine("\tPrincipals Query: {0}", principalsQuery.ToString());
            Console.WriteLine("\tPlayers Query: {0}", playersQuery.ToString());
        }

        private static void WritePrincipals(TextWriter writer, Battle battle)
        {
            Console.WriteLine("\t\t\tIsDeployTime: {0}", battle.IsDeployTime);
            if (battle.IsDeployTime) {
                foreach (PlayerBattleInformation info in battle.PlayerInformation) {
                    Console.WriteLine("\t\t\tPrincipal {1} HasPositioned: {0}", info.HasPositioned, info.Name);
                    if (!info.HasPositioned) {
                        Console.WriteLine("\t\t\tAdding {0}:{1}...", info.Name, info.Owner);
                        writer.Write(" principal.Id = {0} or ", info.Owner);
                    }
                }
            } else {
                Console.WriteLine("\t\t\tAdding Current Player {0}...", battle.CurrentPlayer);
                writer.Write(" principal.Id = {0} or ", battle.CurrentPlayer);
            }
        }

        private static void WritePlayers(TextWriter writer, Battle battle)
        {
            Console.WriteLine("\t\t\tIsDeployTime: {0}", battle.IsDeployTime);
            if (battle.IsDeployTime) {
                foreach (PlayerBattleInformation info in battle.PlayerInformation) {
                    Console.WriteLine("\t\t\tPrincipal {1} HasPositioned: {0}", info.HasPositioned, info.Name);
                    if (!info.HasPositioned) {
                        Console.WriteLine("\t\t\tAdding {0}:{1}...", info.Name, info.Owner);
                        writer.Write(" player.Id = {0} or ", info.Owner);
                    }
                }
            } else {
                Console.WriteLine("\t\t\tAdding Current Player {0}...", battle.CurrentPlayer);
                writer.Write(" player.Id = {0} or ", battle.CurrentPlayer);
            }
        }

        public static void ToogleAutoStartVacations(Principal principal)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                persistance.StartTransaction();
                principal.AutoStartVacations = !principal.AutoStartVacations;
                persistance.Update(principal);
                persistance.CommitTransaction();
            }
        }

        #endregion Vacations

    };
}
