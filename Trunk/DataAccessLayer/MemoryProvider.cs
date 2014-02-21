using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {

	/// <summary>
    /// Provides persistance objects
    /// </summary>
    public class MemoryProvider : BasePersistanceProvider {

        #region ForumTopic Persistance

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance GetForumTopicPersistance ()
        {
			return new MemoryForumTopicPersistance ();
        }
        
        /// <summary>
        /// Opens a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance OpenForumTopicPersistance ()
        {
			return new MemoryForumTopicPersistance ();
        }

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance GetForumTopicPersistance ( IPersistanceSession owner )
        {
			return new MemoryForumTopicPersistance ();
        }

        #endregion ForumTopic Persistance
        
        #region Message Persistance

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance GetMessagePersistance ()
        {
			return new MemoryMessagePersistance ();
        }
        
        /// <summary>
        /// Opens a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance OpenMessagePersistance ()
        {
			return new MemoryMessagePersistance ();
        }

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance GetMessagePersistance ( IPersistanceSession owner )
        {
			return new MemoryMessagePersistance ();
        }

        #endregion Message Persistance
        
        #region GlobalStats Persistance

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance GetGlobalStatsPersistance ()
        {
			return new MemoryGlobalStatsPersistance ();
        }
        
        /// <summary>
        /// Opens a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance OpenGlobalStatsPersistance ()
        {
			return new MemoryGlobalStatsPersistance ();
        }

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance GetGlobalStatsPersistance ( IPersistanceSession owner )
        {
			return new MemoryGlobalStatsPersistance ();
        }

        #endregion GlobalStats Persistance
        
        #region Payment Persistance

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance GetPaymentPersistance ()
        {
			return new MemoryPaymentPersistance ();
        }
        
        /// <summary>
        /// Opens a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance OpenPaymentPersistance ()
        {
			return new MemoryPaymentPersistance ();
        }

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance GetPaymentPersistance ( IPersistanceSession owner )
        {
			return new MemoryPaymentPersistance ();
        }

        #endregion Payment Persistance
        
        #region WormHolePlayers Persistance

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance GetWormHolePlayersPersistance ()
        {
			return new MemoryWormHolePlayersPersistance ();
        }
        
        /// <summary>
        /// Opens a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance OpenWormHolePlayersPersistance ()
        {
			return new MemoryWormHolePlayersPersistance ();
        }

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance GetWormHolePlayersPersistance ( IPersistanceSession owner )
        {
			return new MemoryWormHolePlayersPersistance ();
        }

        #endregion WormHolePlayers Persistance
        
        #region Tournament Persistance

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance GetTournamentPersistance ()
        {
			return new MemoryTournamentPersistance ();
        }
        
        /// <summary>
        /// Opens a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance OpenTournamentPersistance ()
        {
			return new MemoryTournamentPersistance ();
        }

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance GetTournamentPersistance ( IPersistanceSession owner )
        {
			return new MemoryTournamentPersistance ();
        }

        #endregion Tournament Persistance
        
        #region VoteStorage Persistance

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance GetVoteStoragePersistance ()
        {
			return new MemoryVoteStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance OpenVoteStoragePersistance ()
        {
			return new MemoryVoteStoragePersistance ();
        }

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance GetVoteStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryVoteStoragePersistance ();
        }

        #endregion VoteStorage Persistance
        
        #region VoteReferral Persistance

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance GetVoteReferralPersistance ()
        {
			return new MemoryVoteReferralPersistance ();
        }
        
        /// <summary>
        /// Opens a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance OpenVoteReferralPersistance ()
        {
			return new MemoryVoteReferralPersistance ();
        }

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance GetVoteReferralPersistance ( IPersistanceSession owner )
        {
			return new MemoryVoteReferralPersistance ();
        }

        #endregion VoteReferral Persistance
        
        #region PrincipalStats Persistance

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance GetPrincipalStatsPersistance ()
        {
			return new MemoryPrincipalStatsPersistance ();
        }
        
        /// <summary>
        /// Opens a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance OpenPrincipalStatsPersistance ()
        {
			return new MemoryPrincipalStatsPersistance ();
        }

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance GetPrincipalStatsPersistance ( IPersistanceSession owner )
        {
			return new MemoryPrincipalStatsPersistance ();
        }

        #endregion PrincipalStats Persistance
        
        #region SpecialEvent Persistance

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance GetSpecialEventPersistance ()
        {
			return new MemorySpecialEventPersistance ();
        }
        
        /// <summary>
        /// Opens a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance OpenSpecialEventPersistance ()
        {
			return new MemorySpecialEventPersistance ();
        }

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance GetSpecialEventPersistance ( IPersistanceSession owner )
        {
			return new MemorySpecialEventPersistance ();
        }

        #endregion SpecialEvent Persistance
        
        #region LogStorage Persistance

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance GetLogStoragePersistance ()
        {
			return new MemoryLogStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance OpenLogStoragePersistance ()
        {
			return new MemoryLogStoragePersistance ();
        }

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance GetLogStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryLogStoragePersistance ();
        }

        #endregion LogStorage Persistance
        
        #region PaymentDescription Persistance

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ()
        {
			return new MemoryPaymentDescriptionPersistance ();
        }
        
        /// <summary>
        /// Opens a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance OpenPaymentDescriptionPersistance ()
        {
			return new MemoryPaymentDescriptionPersistance ();
        }

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ( IPersistanceSession owner )
        {
			return new MemoryPaymentDescriptionPersistance ();
        }

        #endregion PaymentDescription Persistance
        
        #region BotHandler Persistance

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance GetBotHandlerPersistance ()
        {
			return new MemoryBotHandlerPersistance ();
        }
        
        /// <summary>
        /// Opens a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance OpenBotHandlerPersistance ()
        {
			return new MemoryBotHandlerPersistance ();
        }

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance GetBotHandlerPersistance ( IPersistanceSession owner )
        {
			return new MemoryBotHandlerPersistance ();
        }

        #endregion BotHandler Persistance
        
        #region TeamStorage Persistance

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance GetTeamStoragePersistance ()
        {
			return new MemoryTeamStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance OpenTeamStoragePersistance ()
        {
			return new MemoryTeamStoragePersistance ();
        }

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance GetTeamStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryTeamStoragePersistance ();
        }

        #endregion TeamStorage Persistance
        
        #region Country Persistance

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance GetCountryPersistance ()
        {
			return new MemoryCountryPersistance ();
        }
        
        /// <summary>
        /// Opens a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance OpenCountryPersistance ()
        {
			return new MemoryCountryPersistance ();
        }

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance GetCountryPersistance ( IPersistanceSession owner )
        {
			return new MemoryCountryPersistance ();
        }

        #endregion Country Persistance
        
        #region BotCredential Persistance

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance GetBotCredentialPersistance ()
        {
			return new MemoryBotCredentialPersistance ();
        }
        
        /// <summary>
        /// Opens a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance OpenBotCredentialPersistance ()
        {
			return new MemoryBotCredentialPersistance ();
        }

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance GetBotCredentialPersistance ( IPersistanceSession owner )
        {
			return new MemoryBotCredentialPersistance ();
        }

        #endregion BotCredential Persistance
        
        #region PendingBotRequest Persistance

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance GetPendingBotRequestPersistance ()
        {
			return new MemoryPendingBotRequestPersistance ();
        }
        
        /// <summary>
        /// Opens a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance OpenPendingBotRequestPersistance ()
        {
			return new MemoryPendingBotRequestPersistance ();
        }

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance GetPendingBotRequestPersistance ( IPersistanceSession owner )
        {
			return new MemoryPendingBotRequestPersistance ();
        }

        #endregion PendingBotRequest Persistance
        
        #region AllianceStorage Persistance

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance GetAllianceStoragePersistance ()
        {
			return new MemoryAllianceStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance OpenAllianceStoragePersistance ()
        {
			return new MemoryAllianceStoragePersistance ();
        }

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance GetAllianceStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryAllianceStoragePersistance ();
        }

        #endregion AllianceStorage Persistance
        
        #region Transaction Persistance

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance GetTransactionPersistance ()
        {
			return new MemoryTransactionPersistance ();
        }
        
        /// <summary>
        /// Opens a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance OpenTransactionPersistance ()
        {
			return new MemoryTransactionPersistance ();
        }

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance GetTransactionPersistance ( IPersistanceSession owner )
        {
			return new MemoryTransactionPersistance ();
        }

        #endregion Transaction Persistance
        
        #region DuplicateDetection Persistance

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ()
        {
			return new MemoryDuplicateDetectionPersistance ();
        }
        
        /// <summary>
        /// Opens a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance OpenDuplicateDetectionPersistance ()
        {
			return new MemoryDuplicateDetectionPersistance ();
        }

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ( IPersistanceSession owner )
        {
			return new MemoryDuplicateDetectionPersistance ();
        }

        #endregion DuplicateDetection Persistance
        
        #region Interaction Persistance

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance GetInteractionPersistance ()
        {
			return new MemoryInteractionPersistance ();
        }
        
        /// <summary>
        /// Opens a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance OpenInteractionPersistance ()
        {
			return new MemoryInteractionPersistance ();
        }

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance GetInteractionPersistance ( IPersistanceSession owner )
        {
			return new MemoryInteractionPersistance ();
        }

        #endregion Interaction Persistance
        
        #region ServerProperties Persistance

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance GetServerPropertiesPersistance ()
        {
			return new MemoryServerPropertiesPersistance ();
        }
        
        /// <summary>
        /// Opens a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance OpenServerPropertiesPersistance ()
        {
			return new MemoryServerPropertiesPersistance ();
        }

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance GetServerPropertiesPersistance ( IPersistanceSession owner )
        {
			return new MemoryServerPropertiesPersistance ();
        }

        #endregion ServerProperties Persistance
        
        #region PlayerStats Persistance

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance GetPlayerStatsPersistance ()
        {
			return new MemoryPlayerStatsPersistance ();
        }
        
        /// <summary>
        /// Opens a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance OpenPlayerStatsPersistance ()
        {
			return new MemoryPlayerStatsPersistance ();
        }

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance GetPlayerStatsPersistance ( IPersistanceSession owner )
        {
			return new MemoryPlayerStatsPersistance ();
        }

        #endregion PlayerStats Persistance
        
        #region BattleExtention Persistance

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance GetBattleExtentionPersistance ()
        {
			return new MemoryBattleExtentionPersistance ();
        }
        
        /// <summary>
        /// Opens a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance OpenBattleExtentionPersistance ()
        {
			return new MemoryBattleExtentionPersistance ();
        }

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance GetBattleExtentionPersistance ( IPersistanceSession owner )
        {
			return new MemoryBattleExtentionPersistance ();
        }

        #endregion BattleExtention Persistance
        
        #region GroupPointsStorage Persistance

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ()
        {
			return new MemoryGroupPointsStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance OpenGroupPointsStoragePersistance ()
        {
			return new MemoryGroupPointsStoragePersistance ();
        }

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryGroupPointsStoragePersistance ();
        }

        #endregion GroupPointsStorage Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ()
        {
			return new MemoryPrincipalPersistance ();
        }
        
        /// <summary>
        /// Opens a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance OpenPrincipalPersistance ()
        {
			return new MemoryPrincipalPersistance ();
        }

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner )
        {
			return new MemoryPrincipalPersistance ();
        }

        #endregion Principal Persistance
        
        #region FogOfWarStorage Persistance

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ()
        {
			return new MemoryFogOfWarStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance OpenFogOfWarStoragePersistance ()
        {
			return new MemoryFogOfWarStoragePersistance ();
        }

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryFogOfWarStoragePersistance ();
        }

        #endregion FogOfWarStorage Persistance
        
        #region PlayersGroupStorage Persistance

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ()
        {
			return new MemoryPlayersGroupStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance OpenPlayersGroupStoragePersistance ()
        {
			return new MemoryPlayersGroupStoragePersistance ();
        }

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryPlayersGroupStoragePersistance ();
        }

        #endregion PlayersGroupStorage Persistance
        
        #region QuestStorage Persistance

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance GetQuestStoragePersistance ()
        {
			return new MemoryQuestStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance OpenQuestStoragePersistance ()
        {
			return new MemoryQuestStoragePersistance ();
        }

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance GetQuestStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryQuestStoragePersistance ();
        }

        #endregion QuestStorage Persistance
        
        #region PlayerBattleInformation Persistance

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ()
        {
			return new MemoryPlayerBattleInformationPersistance ();
        }
        
        /// <summary>
        /// Opens a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance OpenPlayerBattleInformationPersistance ()
        {
			return new MemoryPlayerBattleInformationPersistance ();
        }

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ( IPersistanceSession owner )
        {
			return new MemoryPlayerBattleInformationPersistance ();
        }

        #endregion PlayerBattleInformation Persistance
        
        #region AuctionHouse Persistance

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance GetAuctionHousePersistance ()
        {
			return new MemoryAuctionHousePersistance ();
        }
        
        /// <summary>
        /// Opens a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance OpenAuctionHousePersistance ()
        {
			return new MemoryAuctionHousePersistance ();
        }

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance GetAuctionHousePersistance ( IPersistanceSession owner )
        {
			return new MemoryAuctionHousePersistance ();
        }

        #endregion AuctionHouse Persistance
        
        #region Market Persistance

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance GetMarketPersistance ()
        {
			return new MemoryMarketPersistance ();
        }
        
        /// <summary>
        /// Opens a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance OpenMarketPersistance ()
        {
			return new MemoryMarketPersistance ();
        }

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance GetMarketPersistance ( IPersistanceSession owner )
        {
			return new MemoryMarketPersistance ();
        }

        #endregion Market Persistance
        
        #region Promotion Persistance

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance GetPromotionPersistance ()
        {
			return new MemoryPromotionPersistance ();
        }
        
        /// <summary>
        /// Opens a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance OpenPromotionPersistance ()
        {
			return new MemoryPromotionPersistance ();
        }

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance GetPromotionPersistance ( IPersistanceSession owner )
        {
			return new MemoryPromotionPersistance ();
        }

        #endregion Promotion Persistance
        
        #region Campaign Persistance

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance GetCampaignPersistance ()
        {
			return new MemoryCampaignPersistance ();
        }
        
        /// <summary>
        /// Opens a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance OpenCampaignPersistance ()
        {
			return new MemoryCampaignPersistance ();
        }

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance GetCampaignPersistance ( IPersistanceSession owner )
        {
			return new MemoryCampaignPersistance ();
        }

        #endregion Campaign Persistance
        
        #region Product Persistance

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance GetProductPersistance ()
        {
			return new MemoryProductPersistance ();
        }
        
        /// <summary>
        /// Opens a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance OpenProductPersistance ()
        {
			return new MemoryProductPersistance ();
        }

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance GetProductPersistance ( IPersistanceSession owner )
        {
			return new MemoryProductPersistance ();
        }

        #endregion Product Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ()
        {
			return new MemoryExceptionInfoPersistance ();
        }
        
        /// <summary>
        /// Opens a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance OpenExceptionInfoPersistance ()
        {
			return new MemoryExceptionInfoPersistance ();
        }

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner )
        {
			return new MemoryExceptionInfoPersistance ();
        }

        #endregion ExceptionInfo Persistance
        
        #region PrivateBoard Persistance

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance GetPrivateBoardPersistance ()
        {
			return new MemoryPrivateBoardPersistance ();
        }
        
        /// <summary>
        /// Opens a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance OpenPrivateBoardPersistance ()
        {
			return new MemoryPrivateBoardPersistance ();
        }

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance GetPrivateBoardPersistance ( IPersistanceSession owner )
        {
			return new MemoryPrivateBoardPersistance ();
        }

        #endregion PrivateBoard Persistance
        
        #region BonusCard Persistance

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance GetBonusCardPersistance ()
        {
			return new MemoryBonusCardPersistance ();
        }
        
        /// <summary>
        /// Opens a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance OpenBonusCardPersistance ()
        {
			return new MemoryBonusCardPersistance ();
        }

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance GetBonusCardPersistance ( IPersistanceSession owner )
        {
			return new MemoryBonusCardPersistance ();
        }

        #endregion BonusCard Persistance
        
        #region ArenaHistorical Persistance

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance GetArenaHistoricalPersistance ()
        {
			return new MemoryArenaHistoricalPersistance ();
        }
        
        /// <summary>
        /// Opens a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance OpenArenaHistoricalPersistance ()
        {
			return new MemoryArenaHistoricalPersistance ();
        }

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance GetArenaHistoricalPersistance ( IPersistanceSession owner )
        {
			return new MemoryArenaHistoricalPersistance ();
        }

        #endregion ArenaHistorical Persistance
        
        #region CampaignLevel Persistance

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance GetCampaignLevelPersistance ()
        {
			return new MemoryCampaignLevelPersistance ();
        }
        
        /// <summary>
        /// Opens a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance OpenCampaignLevelPersistance ()
        {
			return new MemoryCampaignLevelPersistance ();
        }

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance GetCampaignLevelPersistance ( IPersistanceSession owner )
        {
			return new MemoryCampaignLevelPersistance ();
        }

        #endregion CampaignLevel Persistance
        
        #region Task Persistance

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance GetTaskPersistance ()
        {
			return new MemoryTaskPersistance ();
        }
        
        /// <summary>
        /// Opens a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance OpenTaskPersistance ()
        {
			return new MemoryTaskPersistance ();
        }

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance GetTaskPersistance ( IPersistanceSession owner )
        {
			return new MemoryTaskPersistance ();
        }

        #endregion Task Persistance
        
        #region FriendOrFoe Persistance

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance GetFriendOrFoePersistance ()
        {
			return new MemoryFriendOrFoePersistance ();
        }
        
        /// <summary>
        /// Opens a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance OpenFriendOrFoePersistance ()
        {
			return new MemoryFriendOrFoePersistance ();
        }

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance GetFriendOrFoePersistance ( IPersistanceSession owner )
        {
			return new MemoryFriendOrFoePersistance ();
        }

        #endregion FriendOrFoe Persistance
        
        #region PlanetStorage Persistance

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance GetPlanetStoragePersistance ()
        {
			return new MemoryPlanetStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance OpenPlanetStoragePersistance ()
        {
			return new MemoryPlanetStoragePersistance ();
        }

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance GetPlanetStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryPlanetStoragePersistance ();
        }

        #endregion PlanetStorage Persistance
        
        #region UniverseSpecialSector Persistance

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ()
        {
			return new MemoryUniverseSpecialSectorPersistance ();
        }
        
        /// <summary>
        /// Opens a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance OpenUniverseSpecialSectorPersistance ()
        {
			return new MemoryUniverseSpecialSectorPersistance ();
        }

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ( IPersistanceSession owner )
        {
			return new MemoryUniverseSpecialSectorPersistance ();
        }

        #endregion UniverseSpecialSector Persistance
        
        #region Medal Persistance

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance GetMedalPersistance ()
        {
			return new MemoryMedalPersistance ();
        }
        
        /// <summary>
        /// Opens a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance OpenMedalPersistance ()
        {
			return new MemoryMedalPersistance ();
        }

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance GetMedalPersistance ( IPersistanceSession owner )
        {
			return new MemoryMedalPersistance ();
        }

        #endregion Medal Persistance
        
        #region PlanetResourceStorage Persistance

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ()
        {
			return new MemoryPlanetResourceStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance OpenPlanetResourceStoragePersistance ()
        {
			return new MemoryPlanetResourceStoragePersistance ();
        }

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryPlanetResourceStoragePersistance ();
        }

        #endregion PlanetResourceStorage Persistance
        
        #region BattleStats Persistance

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance GetBattleStatsPersistance ()
        {
			return new MemoryBattleStatsPersistance ();
        }
        
        /// <summary>
        /// Opens a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance OpenBattleStatsPersistance ()
        {
			return new MemoryBattleStatsPersistance ();
        }

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance GetBattleStatsPersistance ( IPersistanceSession owner )
        {
			return new MemoryBattleStatsPersistance ();
        }

        #endregion BattleStats Persistance
        
        #region Invoice Persistance

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance GetInvoicePersistance ()
        {
			return new MemoryInvoicePersistance ();
        }
        
        /// <summary>
        /// Opens a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance OpenInvoicePersistance ()
        {
			return new MemoryInvoicePersistance ();
        }

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance GetInvoicePersistance ( IPersistanceSession owner )
        {
			return new MemoryInvoicePersistance ();
        }

        #endregion Invoice Persistance
        
        #region BidHistorical Persistance

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance GetBidHistoricalPersistance ()
        {
			return new MemoryBidHistoricalPersistance ();
        }
        
        /// <summary>
        /// Opens a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance OpenBidHistoricalPersistance ()
        {
			return new MemoryBidHistoricalPersistance ();
        }

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance GetBidHistoricalPersistance ( IPersistanceSession owner )
        {
			return new MemoryBidHistoricalPersistance ();
        }

        #endregion BidHistorical Persistance
        
        #region AllianceDiplomacy Persistance

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ()
        {
			return new MemoryAllianceDiplomacyPersistance ();
        }
        
        /// <summary>
        /// Opens a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance OpenAllianceDiplomacyPersistance ()
        {
			return new MemoryAllianceDiplomacyPersistance ();
        }

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ( IPersistanceSession owner )
        {
			return new MemoryAllianceDiplomacyPersistance ();
        }

        #endregion AllianceDiplomacy Persistance
        
        #region Necessity Persistance

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance GetNecessityPersistance ()
        {
			return new MemoryNecessityPersistance ();
        }
        
        /// <summary>
        /// Opens a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance OpenNecessityPersistance ()
        {
			return new MemoryNecessityPersistance ();
        }

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance GetNecessityPersistance ( IPersistanceSession owner )
        {
			return new MemoryNecessityPersistance ();
        }

        #endregion Necessity Persistance
        
        #region ForumPost Persistance

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance GetForumPostPersistance ()
        {
			return new MemoryForumPostPersistance ();
        }
        
        /// <summary>
        /// Opens a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance OpenForumPostPersistance ()
        {
			return new MemoryForumPostPersistance ();
        }

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance GetForumPostPersistance ( IPersistanceSession owner )
        {
			return new MemoryForumPostPersistance ();
        }

        #endregion ForumPost Persistance
        
        #region Battle Persistance

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance GetBattlePersistance ()
        {
			return new MemoryBattlePersistance ();
        }
        
        /// <summary>
        /// Opens a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance OpenBattlePersistance ()
        {
			return new MemoryBattlePersistance ();
        }

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance GetBattlePersistance ( IPersistanceSession owner )
        {
			return new MemoryBattlePersistance ();
        }

        #endregion Battle Persistance
        
        #region TimedActionStorage Persistance

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance GetTimedActionStoragePersistance ()
        {
			return new MemoryTimedActionStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance OpenTimedActionStoragePersistance ()
        {
			return new MemoryTimedActionStoragePersistance ();
        }

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance GetTimedActionStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryTimedActionStoragePersistance ();
        }

        #endregion TimedActionStorage Persistance
        
        #region ForumThread Persistance

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance GetForumThreadPersistance ()
        {
			return new MemoryForumThreadPersistance ();
        }
        
        /// <summary>
        /// Opens a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance OpenForumThreadPersistance ()
        {
			return new MemoryForumThreadPersistance ();
        }

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance GetForumThreadPersistance ( IPersistanceSession owner )
        {
			return new MemoryForumThreadPersistance ();
        }

        #endregion ForumThread Persistance
        
        #region SectorStorage Persistance

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance GetSectorStoragePersistance ()
        {
			return new MemorySectorStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance OpenSectorStoragePersistance ()
        {
			return new MemorySectorStoragePersistance ();
        }

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance GetSectorStoragePersistance ( IPersistanceSession owner )
        {
			return new MemorySectorStoragePersistance ();
        }

        #endregion SectorStorage Persistance
        
        #region ForumReadMarking Persistance

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance GetForumReadMarkingPersistance ()
        {
			return new MemoryForumReadMarkingPersistance ();
        }
        
        /// <summary>
        /// Opens a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance OpenForumReadMarkingPersistance ()
        {
			return new MemoryForumReadMarkingPersistance ();
        }

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance GetForumReadMarkingPersistance ( IPersistanceSession owner )
        {
			return new MemoryForumReadMarkingPersistance ();
        }

        #endregion ForumReadMarking Persistance
        
        #region ActivatedPromotion Persistance

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance GetActivatedPromotionPersistance ()
        {
			return new MemoryActivatedPromotionPersistance ();
        }
        
        /// <summary>
        /// Opens a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance OpenActivatedPromotionPersistance ()
        {
			return new MemoryActivatedPromotionPersistance ();
        }

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance GetActivatedPromotionPersistance ( IPersistanceSession owner )
        {
			return new MemoryActivatedPromotionPersistance ();
        }

        #endregion ActivatedPromotion Persistance
        
        #region ArenaStorage Persistance

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance GetArenaStoragePersistance ()
        {
			return new MemoryArenaStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance OpenArenaStoragePersistance ()
        {
			return new MemoryArenaStoragePersistance ();
        }

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance GetArenaStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryArenaStoragePersistance ();
        }

        #endregion ArenaStorage Persistance
        
        #region Asset Persistance

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance GetAssetPersistance ()
        {
			return new MemoryAssetPersistance ();
        }
        
        /// <summary>
        /// Opens a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance OpenAssetPersistance ()
        {
			return new MemoryAssetPersistance ();
        }

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance GetAssetPersistance ( IPersistanceSession owner )
        {
			return new MemoryAssetPersistance ();
        }

        #endregion Asset Persistance
        
        #region PlayerStorage Persistance

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance GetPlayerStoragePersistance ()
        {
			return new MemoryPlayerStoragePersistance ();
        }
        
        /// <summary>
        /// Opens a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance OpenPlayerStoragePersistance ()
        {
			return new MemoryPlayerStoragePersistance ();
        }

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance GetPlayerStoragePersistance ( IPersistanceSession owner )
        {
			return new MemoryPlayerStoragePersistance ();
        }

        #endregion PlayerStorage Persistance
        
        #region Offering Persistance

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance GetOfferingPersistance ()
        {
			return new MemoryOfferingPersistance ();
        }
        
        /// <summary>
        /// Opens a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance OpenOfferingPersistance ()
        {
			return new MemoryOfferingPersistance ();
        }

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance GetOfferingPersistance ( IPersistanceSession owner )
        {
			return new MemoryOfferingPersistance ();
        }

        #endregion Offering Persistance
        
        #region PrincipalTournament Persistance

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ()
        {
			return new MemoryPrincipalTournamentPersistance ();
        }
        
        /// <summary>
        /// Opens a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance OpenPrincipalTournamentPersistance ()
        {
			return new MemoryPrincipalTournamentPersistance ();
        }

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ( IPersistanceSession owner )
        {
			return new MemoryPrincipalTournamentPersistance ();
        }

        #endregion PrincipalTournament Persistance
        
        #region CampaignStatus Persistance

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance GetCampaignStatusPersistance ()
        {
			return new MemoryCampaignStatusPersistance ();
        }
        
        /// <summary>
        /// Opens a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance OpenCampaignStatusPersistance ()
        {
			return new MemoryCampaignStatusPersistance ();
        }

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance GetCampaignStatusPersistance ( IPersistanceSession owner )
        {
			return new MemoryCampaignStatusPersistance ();
        }

        #endregion CampaignStatus Persistance
        
        #region Fleet Persistance

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance GetFleetPersistance ()
        {
			return new MemoryFleetPersistance ();
        }
        
        /// <summary>
        /// Opens a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance OpenFleetPersistance ()
        {
			return new MemoryFleetPersistance ();
        }

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance GetFleetPersistance ( IPersistanceSession owner )
        {
			return new MemoryFleetPersistance ();
        }

        #endregion Fleet Persistance
        
    };
}

