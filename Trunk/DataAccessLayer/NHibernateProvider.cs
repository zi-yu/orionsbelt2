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
    public class NHibernateProvider : BasePersistanceProvider {

        #region BotCredential Persistance

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance GetBotCredentialPersistance ()
        {
			return BotCredentialPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance OpenBotCredentialPersistance ()
        {
			return BotCredentialPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance GetBotCredentialPersistance ( IPersistanceSession owner )
        {
			return BotCredentialPersistance.AttachSession (owner);
        }

        #endregion BotCredential Persistance
        
        #region PendingBotRequest Persistance

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance GetPendingBotRequestPersistance ()
        {
			return PendingBotRequestPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance OpenPendingBotRequestPersistance ()
        {
			return PendingBotRequestPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance GetPendingBotRequestPersistance ( IPersistanceSession owner )
        {
			return PendingBotRequestPersistance.AttachSession (owner);
        }

        #endregion PendingBotRequest Persistance
        
        #region Country Persistance

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance GetCountryPersistance ()
        {
			return CountryPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance OpenCountryPersistance ()
        {
			return CountryPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance GetCountryPersistance ( IPersistanceSession owner )
        {
			return CountryPersistance.AttachSession (owner);
        }

        #endregion Country Persistance
        
        #region BotHandler Persistance

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance GetBotHandlerPersistance ()
        {
			return BotHandlerPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance OpenBotHandlerPersistance ()
        {
			return BotHandlerPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance GetBotHandlerPersistance ( IPersistanceSession owner )
        {
			return BotHandlerPersistance.AttachSession (owner);
        }

        #endregion BotHandler Persistance
        
        #region TeamStorage Persistance

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance GetTeamStoragePersistance ()
        {
			return TeamStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance OpenTeamStoragePersistance ()
        {
			return TeamStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance GetTeamStoragePersistance ( IPersistanceSession owner )
        {
			return TeamStoragePersistance.AttachSession (owner);
        }

        #endregion TeamStorage Persistance
        
        #region AllianceStorage Persistance

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance GetAllianceStoragePersistance ()
        {
			return AllianceStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance OpenAllianceStoragePersistance ()
        {
			return AllianceStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance GetAllianceStoragePersistance ( IPersistanceSession owner )
        {
			return AllianceStoragePersistance.AttachSession (owner);
        }

        #endregion AllianceStorage Persistance
        
        #region ServerProperties Persistance

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance GetServerPropertiesPersistance ()
        {
			return ServerPropertiesPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance OpenServerPropertiesPersistance ()
        {
			return ServerPropertiesPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance GetServerPropertiesPersistance ( IPersistanceSession owner )
        {
			return ServerPropertiesPersistance.AttachSession (owner);
        }

        #endregion ServerProperties Persistance
        
        #region PlayerStats Persistance

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance GetPlayerStatsPersistance ()
        {
			return PlayerStatsPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance OpenPlayerStatsPersistance ()
        {
			return PlayerStatsPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance GetPlayerStatsPersistance ( IPersistanceSession owner )
        {
			return PlayerStatsPersistance.AttachSession (owner);
        }

        #endregion PlayerStats Persistance
        
        #region Interaction Persistance

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance GetInteractionPersistance ()
        {
			return InteractionPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance OpenInteractionPersistance ()
        {
			return InteractionPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance GetInteractionPersistance ( IPersistanceSession owner )
        {
			return InteractionPersistance.AttachSession (owner);
        }

        #endregion Interaction Persistance
        
        #region Transaction Persistance

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance GetTransactionPersistance ()
        {
			return TransactionPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance OpenTransactionPersistance ()
        {
			return TransactionPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance GetTransactionPersistance ( IPersistanceSession owner )
        {
			return TransactionPersistance.AttachSession (owner);
        }

        #endregion Transaction Persistance
        
        #region DuplicateDetection Persistance

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ()
        {
			return DuplicateDetectionPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance OpenDuplicateDetectionPersistance ()
        {
			return DuplicateDetectionPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ( IPersistanceSession owner )
        {
			return DuplicateDetectionPersistance.AttachSession (owner);
        }

        #endregion DuplicateDetection Persistance
        
        #region PaymentDescription Persistance

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ()
        {
			return PaymentDescriptionPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance OpenPaymentDescriptionPersistance ()
        {
			return PaymentDescriptionPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ( IPersistanceSession owner )
        {
			return PaymentDescriptionPersistance.AttachSession (owner);
        }

        #endregion PaymentDescription Persistance
        
        #region Payment Persistance

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance GetPaymentPersistance ()
        {
			return PaymentPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance OpenPaymentPersistance ()
        {
			return PaymentPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance GetPaymentPersistance ( IPersistanceSession owner )
        {
			return PaymentPersistance.AttachSession (owner);
        }

        #endregion Payment Persistance
        
        #region WormHolePlayers Persistance

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance GetWormHolePlayersPersistance ()
        {
			return WormHolePlayersPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance OpenWormHolePlayersPersistance ()
        {
			return WormHolePlayersPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance GetWormHolePlayersPersistance ( IPersistanceSession owner )
        {
			return WormHolePlayersPersistance.AttachSession (owner);
        }

        #endregion WormHolePlayers Persistance
        
        #region GlobalStats Persistance

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance GetGlobalStatsPersistance ()
        {
			return GlobalStatsPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance OpenGlobalStatsPersistance ()
        {
			return GlobalStatsPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance GetGlobalStatsPersistance ( IPersistanceSession owner )
        {
			return GlobalStatsPersistance.AttachSession (owner);
        }

        #endregion GlobalStats Persistance
        
        #region ForumTopic Persistance

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance GetForumTopicPersistance ()
        {
			return ForumTopicPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance OpenForumTopicPersistance ()
        {
			return ForumTopicPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance GetForumTopicPersistance ( IPersistanceSession owner )
        {
			return ForumTopicPersistance.AttachSession (owner);
        }

        #endregion ForumTopic Persistance
        
        #region Message Persistance

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance GetMessagePersistance ()
        {
			return MessagePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance OpenMessagePersistance ()
        {
			return MessagePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance GetMessagePersistance ( IPersistanceSession owner )
        {
			return MessagePersistance.AttachSession (owner);
        }

        #endregion Message Persistance
        
        #region Tournament Persistance

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance GetTournamentPersistance ()
        {
			return TournamentPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance OpenTournamentPersistance ()
        {
			return TournamentPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance GetTournamentPersistance ( IPersistanceSession owner )
        {
			return TournamentPersistance.AttachSession (owner);
        }

        #endregion Tournament Persistance
        
        #region SpecialEvent Persistance

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance GetSpecialEventPersistance ()
        {
			return SpecialEventPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance OpenSpecialEventPersistance ()
        {
			return SpecialEventPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance GetSpecialEventPersistance ( IPersistanceSession owner )
        {
			return SpecialEventPersistance.AttachSession (owner);
        }

        #endregion SpecialEvent Persistance
        
        #region LogStorage Persistance

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance GetLogStoragePersistance ()
        {
			return LogStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance OpenLogStoragePersistance ()
        {
			return LogStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance GetLogStoragePersistance ( IPersistanceSession owner )
        {
			return LogStoragePersistance.AttachSession (owner);
        }

        #endregion LogStorage Persistance
        
        #region PrincipalStats Persistance

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance GetPrincipalStatsPersistance ()
        {
			return PrincipalStatsPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance OpenPrincipalStatsPersistance ()
        {
			return PrincipalStatsPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance GetPrincipalStatsPersistance ( IPersistanceSession owner )
        {
			return PrincipalStatsPersistance.AttachSession (owner);
        }

        #endregion PrincipalStats Persistance
        
        #region VoteStorage Persistance

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance GetVoteStoragePersistance ()
        {
			return VoteStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance OpenVoteStoragePersistance ()
        {
			return VoteStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance GetVoteStoragePersistance ( IPersistanceSession owner )
        {
			return VoteStoragePersistance.AttachSession (owner);
        }

        #endregion VoteStorage Persistance
        
        #region VoteReferral Persistance

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance GetVoteReferralPersistance ()
        {
			return VoteReferralPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance OpenVoteReferralPersistance ()
        {
			return VoteReferralPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance GetVoteReferralPersistance ( IPersistanceSession owner )
        {
			return VoteReferralPersistance.AttachSession (owner);
        }

        #endregion VoteReferral Persistance
        
        #region Product Persistance

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance GetProductPersistance ()
        {
			return ProductPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance OpenProductPersistance ()
        {
			return ProductPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance GetProductPersistance ( IPersistanceSession owner )
        {
			return ProductPersistance.AttachSession (owner);
        }

        #endregion Product Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ()
        {
			return ExceptionInfoPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance OpenExceptionInfoPersistance ()
        {
			return ExceptionInfoPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner )
        {
			return ExceptionInfoPersistance.AttachSession (owner);
        }

        #endregion ExceptionInfo Persistance
        
        #region Promotion Persistance

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance GetPromotionPersistance ()
        {
			return PromotionPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance OpenPromotionPersistance ()
        {
			return PromotionPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance GetPromotionPersistance ( IPersistanceSession owner )
        {
			return PromotionPersistance.AttachSession (owner);
        }

        #endregion Promotion Persistance
        
        #region Campaign Persistance

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance GetCampaignPersistance ()
        {
			return CampaignPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance OpenCampaignPersistance ()
        {
			return CampaignPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance GetCampaignPersistance ( IPersistanceSession owner )
        {
			return CampaignPersistance.AttachSession (owner);
        }

        #endregion Campaign Persistance
        
        #region PrivateBoard Persistance

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance GetPrivateBoardPersistance ()
        {
			return PrivateBoardPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance OpenPrivateBoardPersistance ()
        {
			return PrivateBoardPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance GetPrivateBoardPersistance ( IPersistanceSession owner )
        {
			return PrivateBoardPersistance.AttachSession (owner);
        }

        #endregion PrivateBoard Persistance
        
        #region CampaignLevel Persistance

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance GetCampaignLevelPersistance ()
        {
			return CampaignLevelPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance OpenCampaignLevelPersistance ()
        {
			return CampaignLevelPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance GetCampaignLevelPersistance ( IPersistanceSession owner )
        {
			return CampaignLevelPersistance.AttachSession (owner);
        }

        #endregion CampaignLevel Persistance
        
        #region Task Persistance

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance GetTaskPersistance ()
        {
			return TaskPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance OpenTaskPersistance ()
        {
			return TaskPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance GetTaskPersistance ( IPersistanceSession owner )
        {
			return TaskPersistance.AttachSession (owner);
        }

        #endregion Task Persistance
        
        #region BonusCard Persistance

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance GetBonusCardPersistance ()
        {
			return BonusCardPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance OpenBonusCardPersistance ()
        {
			return BonusCardPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance GetBonusCardPersistance ( IPersistanceSession owner )
        {
			return BonusCardPersistance.AttachSession (owner);
        }

        #endregion BonusCard Persistance
        
        #region ArenaHistorical Persistance

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance GetArenaHistoricalPersistance ()
        {
			return ArenaHistoricalPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance OpenArenaHistoricalPersistance ()
        {
			return ArenaHistoricalPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance GetArenaHistoricalPersistance ( IPersistanceSession owner )
        {
			return ArenaHistoricalPersistance.AttachSession (owner);
        }

        #endregion ArenaHistorical Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ()
        {
			return PrincipalPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance OpenPrincipalPersistance ()
        {
			return PrincipalPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner )
        {
			return PrincipalPersistance.AttachSession (owner);
        }

        #endregion Principal Persistance
        
        #region FogOfWarStorage Persistance

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ()
        {
			return FogOfWarStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance OpenFogOfWarStoragePersistance ()
        {
			return FogOfWarStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ( IPersistanceSession owner )
        {
			return FogOfWarStoragePersistance.AttachSession (owner);
        }

        #endregion FogOfWarStorage Persistance
        
        #region BattleExtention Persistance

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance GetBattleExtentionPersistance ()
        {
			return BattleExtentionPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance OpenBattleExtentionPersistance ()
        {
			return BattleExtentionPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance GetBattleExtentionPersistance ( IPersistanceSession owner )
        {
			return BattleExtentionPersistance.AttachSession (owner);
        }

        #endregion BattleExtention Persistance
        
        #region GroupPointsStorage Persistance

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ()
        {
			return GroupPointsStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance OpenGroupPointsStoragePersistance ()
        {
			return GroupPointsStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ( IPersistanceSession owner )
        {
			return GroupPointsStoragePersistance.AttachSession (owner);
        }

        #endregion GroupPointsStorage Persistance
        
        #region PlayersGroupStorage Persistance

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ()
        {
			return PlayersGroupStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance OpenPlayersGroupStoragePersistance ()
        {
			return PlayersGroupStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ( IPersistanceSession owner )
        {
			return PlayersGroupStoragePersistance.AttachSession (owner);
        }

        #endregion PlayersGroupStorage Persistance
        
        #region AuctionHouse Persistance

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance GetAuctionHousePersistance ()
        {
			return AuctionHousePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance OpenAuctionHousePersistance ()
        {
			return AuctionHousePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance GetAuctionHousePersistance ( IPersistanceSession owner )
        {
			return AuctionHousePersistance.AttachSession (owner);
        }

        #endregion AuctionHouse Persistance
        
        #region Market Persistance

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance GetMarketPersistance ()
        {
			return MarketPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance OpenMarketPersistance ()
        {
			return MarketPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance GetMarketPersistance ( IPersistanceSession owner )
        {
			return MarketPersistance.AttachSession (owner);
        }

        #endregion Market Persistance
        
        #region QuestStorage Persistance

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance GetQuestStoragePersistance ()
        {
			return QuestStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance OpenQuestStoragePersistance ()
        {
			return QuestStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance GetQuestStoragePersistance ( IPersistanceSession owner )
        {
			return QuestStoragePersistance.AttachSession (owner);
        }

        #endregion QuestStorage Persistance
        
        #region PlayerBattleInformation Persistance

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ()
        {
			return PlayerBattleInformationPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance OpenPlayerBattleInformationPersistance ()
        {
			return PlayerBattleInformationPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ( IPersistanceSession owner )
        {
			return PlayerBattleInformationPersistance.AttachSession (owner);
        }

        #endregion PlayerBattleInformation Persistance
        
        #region Battle Persistance

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance GetBattlePersistance ()
        {
			return BattlePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance OpenBattlePersistance ()
        {
			return BattlePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance GetBattlePersistance ( IPersistanceSession owner )
        {
			return BattlePersistance.AttachSession (owner);
        }

        #endregion Battle Persistance
        
        #region TimedActionStorage Persistance

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance GetTimedActionStoragePersistance ()
        {
			return TimedActionStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance OpenTimedActionStoragePersistance ()
        {
			return TimedActionStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance GetTimedActionStoragePersistance ( IPersistanceSession owner )
        {
			return TimedActionStoragePersistance.AttachSession (owner);
        }

        #endregion TimedActionStorage Persistance
        
        #region Necessity Persistance

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance GetNecessityPersistance ()
        {
			return NecessityPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance OpenNecessityPersistance ()
        {
			return NecessityPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance GetNecessityPersistance ( IPersistanceSession owner )
        {
			return NecessityPersistance.AttachSession (owner);
        }

        #endregion Necessity Persistance
        
        #region ForumPost Persistance

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance GetForumPostPersistance ()
        {
			return ForumPostPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance OpenForumPostPersistance ()
        {
			return ForumPostPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance GetForumPostPersistance ( IPersistanceSession owner )
        {
			return ForumPostPersistance.AttachSession (owner);
        }

        #endregion ForumPost Persistance
        
        #region ForumReadMarking Persistance

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance GetForumReadMarkingPersistance ()
        {
			return ForumReadMarkingPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance OpenForumReadMarkingPersistance ()
        {
			return ForumReadMarkingPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance GetForumReadMarkingPersistance ( IPersistanceSession owner )
        {
			return ForumReadMarkingPersistance.AttachSession (owner);
        }

        #endregion ForumReadMarking Persistance
        
        #region ActivatedPromotion Persistance

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance GetActivatedPromotionPersistance ()
        {
			return ActivatedPromotionPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance OpenActivatedPromotionPersistance ()
        {
			return ActivatedPromotionPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance GetActivatedPromotionPersistance ( IPersistanceSession owner )
        {
			return ActivatedPromotionPersistance.AttachSession (owner);
        }

        #endregion ActivatedPromotion Persistance
        
        #region ForumThread Persistance

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance GetForumThreadPersistance ()
        {
			return ForumThreadPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance OpenForumThreadPersistance ()
        {
			return ForumThreadPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance GetForumThreadPersistance ( IPersistanceSession owner )
        {
			return ForumThreadPersistance.AttachSession (owner);
        }

        #endregion ForumThread Persistance
        
        #region SectorStorage Persistance

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance GetSectorStoragePersistance ()
        {
			return SectorStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance OpenSectorStoragePersistance ()
        {
			return SectorStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance GetSectorStoragePersistance ( IPersistanceSession owner )
        {
			return SectorStoragePersistance.AttachSession (owner);
        }

        #endregion SectorStorage Persistance
        
        #region AllianceDiplomacy Persistance

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ()
        {
			return AllianceDiplomacyPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance OpenAllianceDiplomacyPersistance ()
        {
			return AllianceDiplomacyPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ( IPersistanceSession owner )
        {
			return AllianceDiplomacyPersistance.AttachSession (owner);
        }

        #endregion AllianceDiplomacy Persistance
        
        #region UniverseSpecialSector Persistance

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ()
        {
			return UniverseSpecialSectorPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance OpenUniverseSpecialSectorPersistance ()
        {
			return UniverseSpecialSectorPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ( IPersistanceSession owner )
        {
			return UniverseSpecialSectorPersistance.AttachSession (owner);
        }

        #endregion UniverseSpecialSector Persistance
        
        #region Medal Persistance

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance GetMedalPersistance ()
        {
			return MedalPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance OpenMedalPersistance ()
        {
			return MedalPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance GetMedalPersistance ( IPersistanceSession owner )
        {
			return MedalPersistance.AttachSession (owner);
        }

        #endregion Medal Persistance
        
        #region FriendOrFoe Persistance

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance GetFriendOrFoePersistance ()
        {
			return FriendOrFoePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance OpenFriendOrFoePersistance ()
        {
			return FriendOrFoePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance GetFriendOrFoePersistance ( IPersistanceSession owner )
        {
			return FriendOrFoePersistance.AttachSession (owner);
        }

        #endregion FriendOrFoe Persistance
        
        #region PlanetStorage Persistance

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance GetPlanetStoragePersistance ()
        {
			return PlanetStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance OpenPlanetStoragePersistance ()
        {
			return PlanetStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance GetPlanetStoragePersistance ( IPersistanceSession owner )
        {
			return PlanetStoragePersistance.AttachSession (owner);
        }

        #endregion PlanetStorage Persistance
        
        #region Invoice Persistance

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance GetInvoicePersistance ()
        {
			return InvoicePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance OpenInvoicePersistance ()
        {
			return InvoicePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance GetInvoicePersistance ( IPersistanceSession owner )
        {
			return InvoicePersistance.AttachSession (owner);
        }

        #endregion Invoice Persistance
        
        #region BidHistorical Persistance

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance GetBidHistoricalPersistance ()
        {
			return BidHistoricalPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance OpenBidHistoricalPersistance ()
        {
			return BidHistoricalPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance GetBidHistoricalPersistance ( IPersistanceSession owner )
        {
			return BidHistoricalPersistance.AttachSession (owner);
        }

        #endregion BidHistorical Persistance
        
        #region PlanetResourceStorage Persistance

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ()
        {
			return PlanetResourceStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance OpenPlanetResourceStoragePersistance ()
        {
			return PlanetResourceStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ( IPersistanceSession owner )
        {
			return PlanetResourceStoragePersistance.AttachSession (owner);
        }

        #endregion PlanetResourceStorage Persistance
        
        #region BattleStats Persistance

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance GetBattleStatsPersistance ()
        {
			return BattleStatsPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance OpenBattleStatsPersistance ()
        {
			return BattleStatsPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance GetBattleStatsPersistance ( IPersistanceSession owner )
        {
			return BattleStatsPersistance.AttachSession (owner);
        }

        #endregion BattleStats Persistance
        
        #region Offering Persistance

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance GetOfferingPersistance ()
        {
			return OfferingPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance OpenOfferingPersistance ()
        {
			return OfferingPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance GetOfferingPersistance ( IPersistanceSession owner )
        {
			return OfferingPersistance.AttachSession (owner);
        }

        #endregion Offering Persistance
        
        #region PrincipalTournament Persistance

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ()
        {
			return PrincipalTournamentPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance OpenPrincipalTournamentPersistance ()
        {
			return PrincipalTournamentPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ( IPersistanceSession owner )
        {
			return PrincipalTournamentPersistance.AttachSession (owner);
        }

        #endregion PrincipalTournament Persistance
        
        #region PlayerStorage Persistance

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance GetPlayerStoragePersistance ()
        {
			return PlayerStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance OpenPlayerStoragePersistance ()
        {
			return PlayerStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance GetPlayerStoragePersistance ( IPersistanceSession owner )
        {
			return PlayerStoragePersistance.AttachSession (owner);
        }

        #endregion PlayerStorage Persistance
        
        #region ArenaStorage Persistance

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance GetArenaStoragePersistance ()
        {
			return ArenaStoragePersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance OpenArenaStoragePersistance ()
        {
			return ArenaStoragePersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance GetArenaStoragePersistance ( IPersistanceSession owner )
        {
			return ArenaStoragePersistance.AttachSession (owner);
        }

        #endregion ArenaStorage Persistance
        
        #region Asset Persistance

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance GetAssetPersistance ()
        {
			return AssetPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance OpenAssetPersistance ()
        {
			return AssetPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance GetAssetPersistance ( IPersistanceSession owner )
        {
			return AssetPersistance.AttachSession (owner);
        }

        #endregion Asset Persistance
        
        #region Fleet Persistance

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance GetFleetPersistance ()
        {
			return FleetPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance OpenFleetPersistance ()
        {
			return FleetPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance GetFleetPersistance ( IPersistanceSession owner )
        {
			return FleetPersistance.AttachSession (owner);
        }

        #endregion Fleet Persistance
        
        #region CampaignStatus Persistance

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance GetCampaignStatusPersistance ()
        {
			return CampaignStatusPersistance.GetSession ();
        }
        
        /// <summary>
        /// Opens a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance OpenCampaignStatusPersistance ()
        {
			return CampaignStatusPersistance.CreateSession ();
        }

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance GetCampaignStatusPersistance ( IPersistanceSession owner )
        {
			return CampaignStatusPersistance.AttachSession (owner);
        }

        #endregion CampaignStatus Persistance
        
    };
}

