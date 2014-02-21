using System.Collections;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Exceptions;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine.MarketPlace;
using Loki.DataRepresentation;

namespace OrionsBelt.Engine.Alliances {
    
    /// <summary>
    /// Manages alliances
    /// </summary>
    public class AllianceManager {

        #region Subscriptions

        public static void RegisterSubscription(IAlliance alliance, IPlayer player, IPersistanceSession session)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance()) {
                Interaction interaction = persistance.Create();
                IInteractionType type = InteractionType.Get("AllianceSubscription");
                type.Prepare(interaction, player.Storage, alliance.Storage);
                persistance.Update(interaction);
            }
        }
        public static void RegisterSubscription(IAlliance alliance, IPlayer player)
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                session.StartTransaction();
                RegisterSubscription(alliance, player, session);
                session.CommitTransaction();
            }
        }

        public static Result CanCreateAlliance(IPlayer player)
        {
            return Result.Success;
        }

        #endregion Subscriptions

        #region Adding Members

        public static void AddPlayerToAlliance(IAlliance alliance, IPlayer player)
        {
            player.Alliance = alliance;
            player.AllianceRank = AllianceRank.Member;

            Messenger.Add(Category.Alliance, typeof(JoinedAllianceMessage), alliance.Storage.Id, alliance.Storage.Name, player.Name);
            Messenger.Add(Category.Player, typeof(JoinedAllianceMessage), player.Id, alliance.Storage.Name, player.Name);

            GameEngine.Persist(player);
        }

        #endregion Adding Members

        #region Creation

        public static int CreateAllianceCost {
            get { return 350; }
        }

        public static void CreateAlliance(IPlayer player, string name, string tag, string description)
        {
            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance())
            {
                AllianceStorage storage = persistance.Create();

                storage.Name = name;
                storage.Tag = tag;
                storage.Description = description;

                CreateAlliance(player, storage);
            }
        }

        public static void CreateAlliance(IPlayer player, AllianceStorage allianceStorage)
        {
            player.PrepareStorage();
            IAlliance alliance = PrepareAlliance(allianceStorage);
            player.Alliance = alliance;
            player.AllianceRank = AllianceRank.Admiral;

            Messenger.Add(Category.Alliance, typeof(AllianceCreatedMessage), alliance.Storage.Id, alliance.Storage.Name, player.Name);
            GameEngine.Persist(player);
            RemovePrincipalOrions(player.Principal, player, alliance);
        }

        private static void RemovePrincipalOrions(Principal principal, IPlayer player, IAlliance alliance)
        {
            if (principal == null) {
                return;
            }
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                principal.Credits -= CreateAllianceCost;
                TransactionManager.AllianceCreationTransaction(player, CreateAllianceCost, alliance.Storage.Id, persistance);
                persistance.Update(principal);
            }
        }

        #endregion Creation

        #region Removal

        private static void RemovePlayer(IAlliance alliance, IPlayer player)
        {
            player.Alliance = null;
            player.AllianceRank = AllianceRank.None;
            GameEngine.Persist(player);
        }

        private static void RemovePlayer(IPlayer iPlayer)
        {
            RemovePlayer(iPlayer.Alliance, iPlayer);
        }

        public static void LeaveAlliance(IPlayer iPlayer)
        {
            IAlliance alliance = iPlayer.Alliance;
            Messenger.Add(Category.Alliance, typeof(LeaveAllianceMessage), alliance.Storage.Id, iPlayer.Name, alliance.Storage.Name);
            RemovePlayer(alliance, iPlayer);
            CheckAllianceMembers(alliance);
        }

        private static void CheckAllianceMembers(IAlliance alliance)
        {
            if (alliance.Storage.Players.Count == 0) {
                Delete(alliance);
            }
        }

        private static void Delete(IAlliance alliance)
        {
            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance()) {
                persistance.StartTransaction();
                using (IAllianceDiplomacyPersistance dippersistance = Persistance.Instance.GetAllianceDiplomacyPersistance(persistance))
                {
                    foreach (AllianceDiplomacy dip in alliance.Storage.DiplomacyA) {
                        dippersistance.Delete(dip);
                    }
                    foreach (AllianceDiplomacy dip in alliance.Storage.DiplomacyB) {
                        dippersistance.Delete(dip);
                    }
                }
                persistance.Delete(alliance.Storage);
                persistance.CommitTransaction();
            }
        }
        
        public static void KickPlayer(IAlliance alliance, IPlayer player, IPlayer kicker)
        {
            Messenger.Add(Category.Alliance, typeof(KickPlayerMessage), alliance.Storage.Id, player.Name, kicker.Name, alliance.Storage.Name);
            Messenger.Add(Category.Alliance, typeof(KickPlayerMessage), player.Storage.Id, player.Name, kicker.Name, alliance.Storage.Name);

            RemovePlayer(alliance, player);
        }

        #endregion Removal

        #region Utils

        public static int GetAllianceScore(IAlliance alliance)
        {
            int toReturn = 0;
            foreach(PlayerStorage player in alliance.Storage.Players)
            {
                toReturn += player.Score;
            }
            return toReturn;
        }

        public static int GetAllianceAverageScore(IAlliance alliance)
        {
            return GetAllianceScore(alliance)/alliance.Storage.Players.Count;
        }

        public static Interaction GetInteractionWith(IAlliance source, IAlliance other)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance())
            {
                IList<Interaction> list = persistance.TypedQuery("select i from SpecializedInteraction i where i.Resolved = false and i.TargetType = 'AllianceStorage' and i.SourceType = 'AllianceStorage' and ( (i.Target = {0} and i.Source = {1}) or (i.Target = {1} and i.Source = {0}) )", source.Storage.Id, other.Storage.Id);
                if (list.Count > 0) {
                    return list[0];
                }
                return null;
            }
        }

        public static IList<Interaction> GetImportantInteractions(IAlliance alliance, Principal principal)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance())
            {
                return persistance.TypedQuery("select i from SpecializedInteraction i where (i.Target = {0} and i.TargetType = 'AllianceStorage'  and i.Resolved = 0) or (i.Target = {1} and i.Type = 'TeamInvitation'  and i.Resolved = 0) order by i.UpdatedDate desc", 
                    alliance != null ? alliance.Storage.Id : -1 ,principal.Id);
            }
        }

        public static IList<Interaction> GetImportantInteractionsForHome(IAlliance alliance, Principal principal) {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance()) {
                return persistance.TypedQuery(0,3,"select i from SpecializedInteraction i where (i.Target = {0} and i.TargetType = 'AllianceStorage'  and i.Resolved = 0) or (i.Target = {1} and i.Type = 'TeamInvitation'  and i.Resolved = 0) order by i.UpdatedDate asc",
                    alliance != null ? alliance.Storage.Id : -1, principal.Id);
            }
        }

        public static IList<Interaction> GetInteractions(IAlliance alliance)
        {
            if (Server.IsInTests) {
                return GetInteractionsForTests(alliance);
            } else {
                return GetInteractionsFromDB(alliance);
            }
        }

        private static IList<Interaction> GetInteractionsForTests(IAlliance alliance)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance())
            {
                IList<Interaction> interactions = persistance.Select();
                List<Interaction> list = new List<Interaction>();
                foreach (Interaction interaction in interactions) {
                    if ((interaction.TargetType == "AllianceStorage" && interaction.Target == alliance.Storage.Id)
                        ||
                        (interaction.SourceType == "AllianceStorage" && interaction.Source == alliance.Storage.Id)
                        )
                        list.Add(interaction);
                }
                return list;
            }
        }

        private static IList<Interaction> GetInteractionsFromDB(IAlliance alliance)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance())
            {
                return persistance.TypedQuery(0, 8, "select i from SpecializedInteraction i where (i.Target = {0} and i.TargetType = 'AllianceStorage') or (i.Source = {0} and i.SourceType = 'AllianceStorage') order by i.Response asc, i.UpdatedDate desc", alliance.Storage.Id);
            }
        }

        public static IAlliance PrepareAlliance(AllianceStorage allianceStorage)
        {
            Alliance alliance = new Alliance();
            alliance.Storage = allianceStorage;
            return alliance;
        }

        public static void ChangePlayerRank(IPlayer player, AllianceRank newRank)
        {
            if (newRank == player.AllianceRank) {
                return;
            }

            player.AllianceRank = newRank;

            Messenger.Add(Category.Alliance, typeof(AllianceRankChangedMessage), player.Alliance.Storage.Id, player.Name, player.Alliance.Storage.Name, newRank.ToString());
            GameEngine.Persist(player);
        }

        public static IAlliance GetAllianceById(int id)
        {
            AllianceStorage storage = GetAllianceFromDB(id);
            return PrepareAlliance(storage);
        }

        public static AllianceStorage GetAllianceFromDB(int id)
        {
            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance()) {
                return persistance.Select(id);
            }
        }

        #endregion Utils

        #region Diplomacy

        public static void AddDiplomaticRelation(IAlliance alliance1, IAlliance alliance2, AllianceDiplomacyLevel level, IPersistanceSession session)
        {
            using (IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance(session))
            {
                AllianceDiplomacy dip = persistance.Create();

                dip.Level = level.ToString();
                dip.AllianceA = alliance1.Storage;
                dip.AllianceB = alliance2.Storage;

                persistance.Update(dip);
            }
        }

        public static void AddDiplomaticRelation(IAlliance alliance1, IAlliance alliance2, AllianceDiplomacyLevel level)
        {
            using (IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance())
            {
                persistance.StartTransaction();
                AddDiplomaticRelation(alliance1, alliance2, level, persistance);
                persistance.CommitTransaction();
            }
        }

        public static IList<AllianceDiplomacy> GetDiplomaticRelations(IAlliance alliance)
        {
            using (IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance())
            {
                if (Server.IsInTests) {
                    return GetDiplomaticRelationTests(persistance, alliance);
                } else {
                    return GetDiplomaticRelationHQL(persistance, alliance);
                }
            }
        }

        private static IList<AllianceDiplomacy> GetDiplomaticRelationTests(IAllianceDiplomacyPersistance persistance, IAlliance alliance)
        {
            List<AllianceDiplomacy> list = new List<AllianceDiplomacy>();

            list.AddRange(persistance.SelectByAllianceA(alliance.Storage));
            list.AddRange(persistance.SelectByAllianceB(alliance.Storage));

            return list;
        }

        private static IList<AllianceDiplomacy> GetDiplomaticRelationHQL(IAllianceDiplomacyPersistance persistance, IAlliance alliance)
        {
            string query = string.Format("select dip from SpecializedAllianceDiplomacy dip where dip.AllianceANHibernate.Id = {0} or dip.AllianceBNHibernate.Id = {0}", alliance.Storage.Id);
            return persistance.TypedQuery(query);
        }

        public static AllianceDiplomacy GetDiplomaticRelation(IAlliance alliance1, IAlliance alliance2)
        {
            using (IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance())
            {
                if (Server.IsInTests){
                    return GetDiplomaticRelationTests(persistance, alliance1, alliance2);
                } else {
                    return GetDiplomaticRelationHQL(persistance, alliance1, alliance2);
                }
            }
        }

		public static AllianceDiplomacy SearchAllianceDiplomacy( List<AllianceDiplomacy> list, IAlliance alliance1, IAlliance alliance2) {
			foreach (AllianceDiplomacy dip in list) {
				if ((dip.AllianceA.Id == alliance1.Storage.Id || dip.AllianceA.Id == alliance2.Storage.Id) &&
					(dip.AllianceB.Id == alliance1.Storage.Id || dip.AllianceB.Id == alliance2.Storage.Id)
						) {
					return dip;
				}
			}

			return null;
		}

		public static AllianceDiplomacy GetDiplomaticRelationLazy(IAlliance alliance1, IAlliance alliance2) {
			List<AllianceDiplomacy> list = new List<AllianceDiplomacy>();
			list.AddRange(alliance1.Storage.DiplomacyA);
			list.AddRange(alliance1.Storage.DiplomacyB);

			return SearchAllianceDiplomacy(list, alliance1, alliance2);
		}

        private static AllianceDiplomacy GetDiplomaticRelationTests(IAllianceDiplomacyPersistance persistance, IAlliance alliance1, IAlliance alliance2)
        {
            List<AllianceDiplomacy> list = new List<AllianceDiplomacy>();

            list.AddRange(persistance.SelectByAllianceA(alliance1.Storage));
            list.AddRange(persistance.SelectByAllianceB(alliance1.Storage));

			return SearchAllianceDiplomacy(list, alliance1, alliance2);
        }

        private static AllianceDiplomacy GetDiplomaticRelationHQL(IAllianceDiplomacyPersistance persistance, IAlliance alliance1, IAlliance alliance2)
        {
            string query = string.Format("select dip from SpecializedAllianceDiplomacy dip where (dip.AllianceANHibernate.Id = {0} and dip.AllianceBNHibernate.Id = {1}) or (dip.AllianceANHibernate.Id = {1} and dip.AllianceBNHibernate.Id = {0})", alliance1.Storage.Id, alliance2.Storage.Id);
            IList<AllianceDiplomacy> dip = persistance.TypedQuery(query);
            if (dip.Count == 0) {
                return null;
            }
            return dip[0];
        }

        public static AllianceDiplomacyLevel GetDiplomaticRelationLevel(IAlliance alliance1, IAlliance alliance2)
        {
            if ( SameAlliance(alliance1,alliance2) ){
                return AllianceDiplomacyLevel.SameAlliance;
            }
            AllianceDiplomacy dip = GetDiplomaticRelation(alliance1, alliance2);
            if (dip != null) {
                return (AllianceDiplomacyLevel)Enum.Parse(typeof(AllianceDiplomacyLevel), dip.Level);
            }
            return AllianceDiplomacyLevel.Neutral;
        }

		public static AllianceDiplomacyLevel GetDiplomaticRelationLevelLazy(IAlliance alliance1, IAlliance alliance2) {
			if (SameAlliance(alliance1, alliance2)) {
				return AllianceDiplomacyLevel.SameAlliance;
			}
			AllianceDiplomacy dip = GetDiplomaticRelationLazy(alliance1, alliance2);
			if (dip != null) {
				return (AllianceDiplomacyLevel)Enum.Parse(typeof(AllianceDiplomacyLevel), dip.Level);
			}
			return AllianceDiplomacyLevel.Neutral;
		}

        private static bool SameAlliance(IAlliance alliance1, IAlliance alliance2) {
            return alliance1 != null && alliance2 != null && alliance1.Storage.Id == alliance2.Storage.Id;
        }

        public static void ChangeDiplomaticRelation(IAlliance alliance1, IAlliance alliance2, AllianceDiplomacyLevel level, IPersistanceSession session)
        { 
            AllianceDiplomacy dip = GetDiplomaticRelation(alliance1, alliance2);
            if (dip == null) {
                AddDiplomaticRelation(alliance1, alliance2, level, session);
            } else {
                ChangeDiplomaticRelation(dip, level, session);
            }
        }

        public static void ChangeDiplomaticRelation(IAlliance alliance1, IAlliance alliance2, AllianceDiplomacyLevel level)
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                ChangeDiplomaticRelation(alliance1, alliance2, level, session);
            }
        }

        public static void ChangeDiplomaticRelation(AllianceDiplomacy dip, AllianceDiplomacyLevel level, IPersistanceSession session)
        {
            dip.Level = level.ToString();
            using (IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance(session))  {
                if (level == AllianceDiplomacyLevel.Neutral) {
                    persistance.Delete(dip);
                } else {
                    persistance.Update(dip);
                }
            }
        }

        public static void ChangeDiplomaticRelation(AllianceDiplomacy dip, AllianceDiplomacyLevel level)
        {
            using (IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance())  {
                persistance.StartTransaction();
                ChangeDiplomaticRelation(dip, level, persistance);
                persistance.CommitTransaction();
            }
        }

        public static void DeclareWar(IAlliance curr, IAlliance other)
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                session.StartTransaction();
                ChangeDiplomaticRelation(curr, other, AllianceDiplomacyLevel.War, session);
                Messenger.Add(Category.Alliance, typeof(AllianceDeclaredWarMessage), other.Storage.Id, curr.Storage.Id.ToString(), curr.Storage.Name, other.Storage.Id.ToString(), other.Storage.Name);
                session.CommitTransaction();
            }
        }

        public static void GoNeutral(IAlliance curr, IAlliance other)
        {
            ChangeDiplomaticRelation(curr, other, AllianceDiplomacyLevel.Neutral);
            Messenger.Add(Category.Alliance, typeof(AllianceGoNeutralMessage), other.Storage.Id, curr.Storage.Id.ToString(), curr.Storage.Name, other.Storage.Id.ToString(), other.Storage.Name);
        }

        public static void OfterConfederation(IAlliance curr, IAlliance other)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance()) {
                persistance.StartTransaction();
                Interaction interaction = persistance.Create();
                IInteractionType type = InteractionType.Get("AllianceOfterConfederation");
                type.Prepare(interaction, curr.Storage, other.Storage);
                persistance.Update(interaction);
                persistance.CommitTransaction();
            }
        }

        internal static void AcceptOfterConfederation(IAlliance curr, IAlliance other)
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance())
            {
                session.StartTransaction();
                Messenger.Add(Category.Alliance, typeof(AllianceNewConfederationMessage), other.Storage.Id, curr.Storage.Id.ToString(), curr.Storage.Name, other.Storage.Id.ToString(), other.Storage.Name);
                ChangeDiplomaticRelation(curr, other, AllianceDiplomacyLevel.Confederation, session);
                session.CommitTransaction();
            }
        }

        public static void OfterEndWar(IAlliance curr, IAlliance other)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance()) {
                persistance.StartTransaction();
                Interaction interaction = persistance.Create();
                IInteractionType type = InteractionType.Get("AllianceOfterEndWar");
                type.Prepare(interaction, curr.Storage, other.Storage);
                persistance.Update(interaction);
                persistance.CommitTransaction();
            }
        }

        internal static void AcceptEndWar(IAlliance curr, IAlliance other)
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance())
            {
                session.StartTransaction();
                Messenger.Add(Category.Alliance, typeof(AllianceEndWarMessage), other.Storage.Id, curr.Storage.Id.ToString(), curr.Storage.Name, other.Storage.Id.ToString(), other.Storage.Name);
                ChangeDiplomaticRelation(curr, other, AllianceDiplomacyLevel.Neutral, session);
                session.CommitTransaction();
            }
        }

        public static void OfterNonAggressionPact(IAlliance curr, IAlliance other)
        {
            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance()) {
                persistance.StartTransaction();
                Interaction interaction = persistance.Create();
                IInteractionType type = InteractionType.Get("AllianceOfterNAP");
                type.Prepare(interaction, curr.Storage, other.Storage);
                persistance.Update(interaction);
                persistance.CommitTransaction();
            }
        }

        public static void AcceptOfterNAP(IAlliance curr, IAlliance other)
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance())
            {
                session.StartTransaction();
                Messenger.Add(Category.Alliance, typeof(AllianceNewNAPMessage), other.Storage.Id, curr.Storage.Id.ToString(), curr.Storage.Name, other.Storage.Id.ToString(), other.Storage.Name);
                ChangeDiplomaticRelation(curr, other, AllianceDiplomacyLevel.NonAgressionPact, session);
                session.CommitTransaction();
            }
        }

        #endregion Diplomacy

        #region Roles

        public static bool CanManageAlliance(IPlayer player)
        {
            return player.HasAlliance && (player.AllianceRank == AllianceRank.Admiral || player.AllianceRank == AllianceRank.ViceAdmiral);
        }

        public static bool CanManageAlliance(IPlayer player, IAlliance alliance)
        {
            return CanManageAlliance(player) && player.Alliance.Storage.Id == alliance.Storage.Id;
        }

        #endregion Roles

        #region Offerings
        public static void MakeDonation(int offeringId, int playerId)
        {
            PlayerStorage player;
            Offering offer;
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                IList<PlayerStorage> players = persistance.SelectById(playerId);

                if(players.Count != 1)
                {
                    throw new InvalidPlayerException(string.Format("Count = {0}", players.Count));
                }

                player = players[0];

                using (IOfferingPersistance persistance2 = Persistance.Instance.GetOfferingPersistance(persistance))
                {
                    IList<Offering> offerings = persistance2.SelectById(offeringId);

                    if (offerings.Count != 1)
                    {
                        throw new InvalidOfferException(string.Format("Count = {0}", players.Count));
                    }

                    offer = offerings[0];

                    if(offer.Alliance.Id != player.Alliance.Id)
                    {
                        throw new InvalidAllianceException(string.Format("Player alliance = {0}; Offering alliance = {1}",
                            player.Alliance.Id, offer.Alliance.Id));
                    }

                    IPlayer iPlayer = PlayerUtils.LoadPlayer(player);
                    IResourceInfo info = RulesUtils.GetResource(offer.Product);
                    iPlayer.AddQuantity(info, offer.CurrentValue);

                    Messenger.Add(Category.Task, typeof(DonationMessage),offer.Alliance.Id, offer.CurrentValue.ToString(),
                                        LanguageManager.Instance.Get(offer.Product),
                                        string.Format("<a href='PlayerInfo.aspx?PlayerStorage={0}'>{1}</a>",
                                        player.Id, player.Name), 
                                        string.Format("<a href='PlayerInfo.aspx?PlayerStorage={0}'>{1}</a>",
                                        offer.Donor.Id, offer.Donor.Name));

                    offer.CurrentValue = 0;
                    offer.Receiver = player;
                    persistance2.Update(offer);

                    GameEngine.Persist(iPlayer);

                }
            }
        }
        #endregion Offerings
    };
}
