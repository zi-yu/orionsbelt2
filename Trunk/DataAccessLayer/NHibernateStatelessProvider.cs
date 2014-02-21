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
    public class NHibernateProviderStateless : BasePersistanceProvider {

        #region BotCredential Persistance

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance GetBotCredentialPersistance ()
        {
			return BotCredentialPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance OpenBotCredentialPersistance ()
        {
			return BotCredentialPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotCredential persistance</returns>
        public override IBotCredentialPersistance GetBotCredentialPersistance ( IPersistanceSession owner )
        {
			return BotCredentialPersistanceStateless.AttachSession (owner);
        }

        #endregion BotCredential Persistance
        
        #region PendingBotRequest Persistance

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance GetPendingBotRequestPersistance ()
        {
			return PendingBotRequestPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance OpenPendingBotRequestPersistance ()
        {
			return PendingBotRequestPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PendingBotRequest persistance</returns>
        public override IPendingBotRequestPersistance GetPendingBotRequestPersistance ( IPersistanceSession owner )
        {
			return PendingBotRequestPersistanceStateless.AttachSession (owner);
        }

        #endregion PendingBotRequest Persistance
        
        #region Country Persistance

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance GetCountryPersistance ()
        {
			return CountryPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance OpenCountryPersistance ()
        {
			return CountryPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Country persistance</returns>
        public override ICountryPersistance GetCountryPersistance ( IPersistanceSession owner )
        {
			return CountryPersistanceStateless.AttachSession (owner);
        }

        #endregion Country Persistance
        
        #region BotHandler Persistance

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance GetBotHandlerPersistance ()
        {
			return BotHandlerPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance OpenBotHandlerPersistance ()
        {
			return BotHandlerPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotHandler persistance</returns>
        public override IBotHandlerPersistance GetBotHandlerPersistance ( IPersistanceSession owner )
        {
			return BotHandlerPersistanceStateless.AttachSession (owner);
        }

        #endregion BotHandler Persistance
        
        #region TeamStorage Persistance

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance GetTeamStoragePersistance ()
        {
			return TeamStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance OpenTeamStoragePersistance ()
        {
			return TeamStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TeamStorage persistance</returns>
        public override ITeamStoragePersistance GetTeamStoragePersistance ( IPersistanceSession owner )
        {
			return TeamStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion TeamStorage Persistance
        
        #region AllianceStorage Persistance

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance GetAllianceStoragePersistance ()
        {
			return AllianceStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance OpenAllianceStoragePersistance ()
        {
			return AllianceStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceStorage persistance</returns>
        public override IAllianceStoragePersistance GetAllianceStoragePersistance ( IPersistanceSession owner )
        {
			return AllianceStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion AllianceStorage Persistance
        
        #region ServerProperties Persistance

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance GetServerPropertiesPersistance ()
        {
			return ServerPropertiesPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance OpenServerPropertiesPersistance ()
        {
			return ServerPropertiesPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ServerProperties persistance</returns>
        public override IServerPropertiesPersistance GetServerPropertiesPersistance ( IPersistanceSession owner )
        {
			return ServerPropertiesPersistanceStateless.AttachSession (owner);
        }

        #endregion ServerProperties Persistance
        
        #region PlayerStats Persistance

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance GetPlayerStatsPersistance ()
        {
			return PlayerStatsPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance OpenPlayerStatsPersistance ()
        {
			return PlayerStatsPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStats persistance</returns>
        public override IPlayerStatsPersistance GetPlayerStatsPersistance ( IPersistanceSession owner )
        {
			return PlayerStatsPersistanceStateless.AttachSession (owner);
        }

        #endregion PlayerStats Persistance
        
        #region Interaction Persistance

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance GetInteractionPersistance ()
        {
			return InteractionPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance OpenInteractionPersistance ()
        {
			return InteractionPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Interaction persistance</returns>
        public override IInteractionPersistance GetInteractionPersistance ( IPersistanceSession owner )
        {
			return InteractionPersistanceStateless.AttachSession (owner);
        }

        #endregion Interaction Persistance
        
        #region Transaction Persistance

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance GetTransactionPersistance ()
        {
			return TransactionPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance OpenTransactionPersistance ()
        {
			return TransactionPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Transaction persistance</returns>
        public override ITransactionPersistance GetTransactionPersistance ( IPersistanceSession owner )
        {
			return TransactionPersistanceStateless.AttachSession (owner);
        }

        #endregion Transaction Persistance
        
        #region DuplicateDetection Persistance

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ()
        {
			return DuplicateDetectionPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance OpenDuplicateDetectionPersistance ()
        {
			return DuplicateDetectionPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The DuplicateDetection persistance</returns>
        public override IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ( IPersistanceSession owner )
        {
			return DuplicateDetectionPersistanceStateless.AttachSession (owner);
        }

        #endregion DuplicateDetection Persistance
        
        #region PaymentDescription Persistance

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ()
        {
			return PaymentDescriptionPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance OpenPaymentDescriptionPersistance ()
        {
			return PaymentDescriptionPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PaymentDescription persistance</returns>
        public override IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ( IPersistanceSession owner )
        {
			return PaymentDescriptionPersistanceStateless.AttachSession (owner);
        }

        #endregion PaymentDescription Persistance
        
        #region Payment Persistance

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance GetPaymentPersistance ()
        {
			return PaymentPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance OpenPaymentPersistance ()
        {
			return PaymentPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Payment persistance</returns>
        public override IPaymentPersistance GetPaymentPersistance ( IPersistanceSession owner )
        {
			return PaymentPersistanceStateless.AttachSession (owner);
        }

        #endregion Payment Persistance
        
        #region WormHolePlayers Persistance

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance GetWormHolePlayersPersistance ()
        {
			return WormHolePlayersPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance OpenWormHolePlayersPersistance ()
        {
			return WormHolePlayersPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The WormHolePlayers persistance</returns>
        public override IWormHolePlayersPersistance GetWormHolePlayersPersistance ( IPersistanceSession owner )
        {
			return WormHolePlayersPersistanceStateless.AttachSession (owner);
        }

        #endregion WormHolePlayers Persistance
        
        #region GlobalStats Persistance

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance GetGlobalStatsPersistance ()
        {
			return GlobalStatsPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance OpenGlobalStatsPersistance ()
        {
			return GlobalStatsPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GlobalStats persistance</returns>
        public override IGlobalStatsPersistance GetGlobalStatsPersistance ( IPersistanceSession owner )
        {
			return GlobalStatsPersistanceStateless.AttachSession (owner);
        }

        #endregion GlobalStats Persistance
        
        #region ForumTopic Persistance

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance GetForumTopicPersistance ()
        {
			return ForumTopicPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance OpenForumTopicPersistance ()
        {
			return ForumTopicPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumTopic persistance</returns>
        public override IForumTopicPersistance GetForumTopicPersistance ( IPersistanceSession owner )
        {
			return ForumTopicPersistanceStateless.AttachSession (owner);
        }

        #endregion ForumTopic Persistance
        
        #region Message Persistance

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance GetMessagePersistance ()
        {
			return MessagePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance OpenMessagePersistance ()
        {
			return MessagePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Message persistance</returns>
        public override IMessagePersistance GetMessagePersistance ( IPersistanceSession owner )
        {
			return MessagePersistanceStateless.AttachSession (owner);
        }

        #endregion Message Persistance
        
        #region Tournament Persistance

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance GetTournamentPersistance ()
        {
			return TournamentPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance OpenTournamentPersistance ()
        {
			return TournamentPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Tournament persistance</returns>
        public override ITournamentPersistance GetTournamentPersistance ( IPersistanceSession owner )
        {
			return TournamentPersistanceStateless.AttachSession (owner);
        }

        #endregion Tournament Persistance
        
        #region SpecialEvent Persistance

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance GetSpecialEventPersistance ()
        {
			return SpecialEventPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance OpenSpecialEventPersistance ()
        {
			return SpecialEventPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SpecialEvent persistance</returns>
        public override ISpecialEventPersistance GetSpecialEventPersistance ( IPersistanceSession owner )
        {
			return SpecialEventPersistanceStateless.AttachSession (owner);
        }

        #endregion SpecialEvent Persistance
        
        #region LogStorage Persistance

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance GetLogStoragePersistance ()
        {
			return LogStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance OpenLogStoragePersistance ()
        {
			return LogStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The LogStorage persistance</returns>
        public override ILogStoragePersistance GetLogStoragePersistance ( IPersistanceSession owner )
        {
			return LogStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion LogStorage Persistance
        
        #region PrincipalStats Persistance

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance GetPrincipalStatsPersistance ()
        {
			return PrincipalStatsPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance OpenPrincipalStatsPersistance ()
        {
			return PrincipalStatsPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalStats persistance</returns>
        public override IPrincipalStatsPersistance GetPrincipalStatsPersistance ( IPersistanceSession owner )
        {
			return PrincipalStatsPersistanceStateless.AttachSession (owner);
        }

        #endregion PrincipalStats Persistance
        
        #region VoteStorage Persistance

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance GetVoteStoragePersistance ()
        {
			return VoteStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance OpenVoteStoragePersistance ()
        {
			return VoteStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteStorage persistance</returns>
        public override IVoteStoragePersistance GetVoteStoragePersistance ( IPersistanceSession owner )
        {
			return VoteStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion VoteStorage Persistance
        
        #region VoteReferral Persistance

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance GetVoteReferralPersistance ()
        {
			return VoteReferralPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance OpenVoteReferralPersistance ()
        {
			return VoteReferralPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteReferral persistance</returns>
        public override IVoteReferralPersistance GetVoteReferralPersistance ( IPersistanceSession owner )
        {
			return VoteReferralPersistanceStateless.AttachSession (owner);
        }

        #endregion VoteReferral Persistance
        
        #region Product Persistance

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance GetProductPersistance ()
        {
			return ProductPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance OpenProductPersistance ()
        {
			return ProductPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Product persistance</returns>
        public override IProductPersistance GetProductPersistance ( IPersistanceSession owner )
        {
			return ProductPersistanceStateless.AttachSession (owner);
        }

        #endregion Product Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ()
        {
			return ExceptionInfoPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance OpenExceptionInfoPersistance ()
        {
			return ExceptionInfoPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        public override IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner )
        {
			return ExceptionInfoPersistanceStateless.AttachSession (owner);
        }

        #endregion ExceptionInfo Persistance
        
        #region Promotion Persistance

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance GetPromotionPersistance ()
        {
			return PromotionPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance OpenPromotionPersistance ()
        {
			return PromotionPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Promotion persistance</returns>
        public override IPromotionPersistance GetPromotionPersistance ( IPersistanceSession owner )
        {
			return PromotionPersistanceStateless.AttachSession (owner);
        }

        #endregion Promotion Persistance
        
        #region Campaign Persistance

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance GetCampaignPersistance ()
        {
			return CampaignPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance OpenCampaignPersistance ()
        {
			return CampaignPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Campaign persistance</returns>
        public override ICampaignPersistance GetCampaignPersistance ( IPersistanceSession owner )
        {
			return CampaignPersistanceStateless.AttachSession (owner);
        }

        #endregion Campaign Persistance
        
        #region PrivateBoard Persistance

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance GetPrivateBoardPersistance ()
        {
			return PrivateBoardPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance OpenPrivateBoardPersistance ()
        {
			return PrivateBoardPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrivateBoard persistance</returns>
        public override IPrivateBoardPersistance GetPrivateBoardPersistance ( IPersistanceSession owner )
        {
			return PrivateBoardPersistanceStateless.AttachSession (owner);
        }

        #endregion PrivateBoard Persistance
        
        #region CampaignLevel Persistance

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance GetCampaignLevelPersistance ()
        {
			return CampaignLevelPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance OpenCampaignLevelPersistance ()
        {
			return CampaignLevelPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignLevel persistance</returns>
        public override ICampaignLevelPersistance GetCampaignLevelPersistance ( IPersistanceSession owner )
        {
			return CampaignLevelPersistanceStateless.AttachSession (owner);
        }

        #endregion CampaignLevel Persistance
        
        #region Task Persistance

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance GetTaskPersistance ()
        {
			return TaskPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance OpenTaskPersistance ()
        {
			return TaskPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Task persistance</returns>
        public override ITaskPersistance GetTaskPersistance ( IPersistanceSession owner )
        {
			return TaskPersistanceStateless.AttachSession (owner);
        }

        #endregion Task Persistance
        
        #region BonusCard Persistance

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance GetBonusCardPersistance ()
        {
			return BonusCardPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance OpenBonusCardPersistance ()
        {
			return BonusCardPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BonusCard persistance</returns>
        public override IBonusCardPersistance GetBonusCardPersistance ( IPersistanceSession owner )
        {
			return BonusCardPersistanceStateless.AttachSession (owner);
        }

        #endregion BonusCard Persistance
        
        #region ArenaHistorical Persistance

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance GetArenaHistoricalPersistance ()
        {
			return ArenaHistoricalPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance OpenArenaHistoricalPersistance ()
        {
			return ArenaHistoricalPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaHistorical persistance</returns>
        public override IArenaHistoricalPersistance GetArenaHistoricalPersistance ( IPersistanceSession owner )
        {
			return ArenaHistoricalPersistanceStateless.AttachSession (owner);
        }

        #endregion ArenaHistorical Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ()
        {
			return PrincipalPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance OpenPrincipalPersistance ()
        {
			return PrincipalPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        public override IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner )
        {
			return PrincipalPersistanceStateless.AttachSession (owner);
        }

        #endregion Principal Persistance
        
        #region FogOfWarStorage Persistance

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ()
        {
			return FogOfWarStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance OpenFogOfWarStoragePersistance ()
        {
			return FogOfWarStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FogOfWarStorage persistance</returns>
        public override IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ( IPersistanceSession owner )
        {
			return FogOfWarStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion FogOfWarStorage Persistance
        
        #region BattleExtention Persistance

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance GetBattleExtentionPersistance ()
        {
			return BattleExtentionPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance OpenBattleExtentionPersistance ()
        {
			return BattleExtentionPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleExtention persistance</returns>
        public override IBattleExtentionPersistance GetBattleExtentionPersistance ( IPersistanceSession owner )
        {
			return BattleExtentionPersistanceStateless.AttachSession (owner);
        }

        #endregion BattleExtention Persistance
        
        #region GroupPointsStorage Persistance

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ()
        {
			return GroupPointsStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance OpenGroupPointsStoragePersistance ()
        {
			return GroupPointsStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GroupPointsStorage persistance</returns>
        public override IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ( IPersistanceSession owner )
        {
			return GroupPointsStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion GroupPointsStorage Persistance
        
        #region PlayersGroupStorage Persistance

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ()
        {
			return PlayersGroupStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance OpenPlayersGroupStoragePersistance ()
        {
			return PlayersGroupStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public override IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ( IPersistanceSession owner )
        {
			return PlayersGroupStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion PlayersGroupStorage Persistance
        
        #region AuctionHouse Persistance

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance GetAuctionHousePersistance ()
        {
			return AuctionHousePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance OpenAuctionHousePersistance ()
        {
			return AuctionHousePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AuctionHouse persistance</returns>
        public override IAuctionHousePersistance GetAuctionHousePersistance ( IPersistanceSession owner )
        {
			return AuctionHousePersistanceStateless.AttachSession (owner);
        }

        #endregion AuctionHouse Persistance
        
        #region Market Persistance

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance GetMarketPersistance ()
        {
			return MarketPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance OpenMarketPersistance ()
        {
			return MarketPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Market persistance</returns>
        public override IMarketPersistance GetMarketPersistance ( IPersistanceSession owner )
        {
			return MarketPersistanceStateless.AttachSession (owner);
        }

        #endregion Market Persistance
        
        #region QuestStorage Persistance

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance GetQuestStoragePersistance ()
        {
			return QuestStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance OpenQuestStoragePersistance ()
        {
			return QuestStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The QuestStorage persistance</returns>
        public override IQuestStoragePersistance GetQuestStoragePersistance ( IPersistanceSession owner )
        {
			return QuestStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion QuestStorage Persistance
        
        #region PlayerBattleInformation Persistance

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ()
        {
			return PlayerBattleInformationPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance OpenPlayerBattleInformationPersistance ()
        {
			return PlayerBattleInformationPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public override IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ( IPersistanceSession owner )
        {
			return PlayerBattleInformationPersistanceStateless.AttachSession (owner);
        }

        #endregion PlayerBattleInformation Persistance
        
        #region Battle Persistance

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance GetBattlePersistance ()
        {
			return BattlePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance OpenBattlePersistance ()
        {
			return BattlePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Battle persistance</returns>
        public override IBattlePersistance GetBattlePersistance ( IPersistanceSession owner )
        {
			return BattlePersistanceStateless.AttachSession (owner);
        }

        #endregion Battle Persistance
        
        #region TimedActionStorage Persistance

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance GetTimedActionStoragePersistance ()
        {
			return TimedActionStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance OpenTimedActionStoragePersistance ()
        {
			return TimedActionStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TimedActionStorage persistance</returns>
        public override ITimedActionStoragePersistance GetTimedActionStoragePersistance ( IPersistanceSession owner )
        {
			return TimedActionStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion TimedActionStorage Persistance
        
        #region Necessity Persistance

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance GetNecessityPersistance ()
        {
			return NecessityPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance OpenNecessityPersistance ()
        {
			return NecessityPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Necessity persistance</returns>
        public override INecessityPersistance GetNecessityPersistance ( IPersistanceSession owner )
        {
			return NecessityPersistanceStateless.AttachSession (owner);
        }

        #endregion Necessity Persistance
        
        #region ForumPost Persistance

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance GetForumPostPersistance ()
        {
			return ForumPostPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance OpenForumPostPersistance ()
        {
			return ForumPostPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumPost persistance</returns>
        public override IForumPostPersistance GetForumPostPersistance ( IPersistanceSession owner )
        {
			return ForumPostPersistanceStateless.AttachSession (owner);
        }

        #endregion ForumPost Persistance
        
        #region ForumReadMarking Persistance

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance GetForumReadMarkingPersistance ()
        {
			return ForumReadMarkingPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance OpenForumReadMarkingPersistance ()
        {
			return ForumReadMarkingPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumReadMarking persistance</returns>
        public override IForumReadMarkingPersistance GetForumReadMarkingPersistance ( IPersistanceSession owner )
        {
			return ForumReadMarkingPersistanceStateless.AttachSession (owner);
        }

        #endregion ForumReadMarking Persistance
        
        #region ActivatedPromotion Persistance

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance GetActivatedPromotionPersistance ()
        {
			return ActivatedPromotionPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance OpenActivatedPromotionPersistance ()
        {
			return ActivatedPromotionPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ActivatedPromotion persistance</returns>
        public override IActivatedPromotionPersistance GetActivatedPromotionPersistance ( IPersistanceSession owner )
        {
			return ActivatedPromotionPersistanceStateless.AttachSession (owner);
        }

        #endregion ActivatedPromotion Persistance
        
        #region ForumThread Persistance

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance GetForumThreadPersistance ()
        {
			return ForumThreadPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance OpenForumThreadPersistance ()
        {
			return ForumThreadPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumThread persistance</returns>
        public override IForumThreadPersistance GetForumThreadPersistance ( IPersistanceSession owner )
        {
			return ForumThreadPersistanceStateless.AttachSession (owner);
        }

        #endregion ForumThread Persistance
        
        #region SectorStorage Persistance

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance GetSectorStoragePersistance ()
        {
			return SectorStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance OpenSectorStoragePersistance ()
        {
			return SectorStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SectorStorage persistance</returns>
        public override ISectorStoragePersistance GetSectorStoragePersistance ( IPersistanceSession owner )
        {
			return SectorStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion SectorStorage Persistance
        
        #region AllianceDiplomacy Persistance

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ()
        {
			return AllianceDiplomacyPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance OpenAllianceDiplomacyPersistance ()
        {
			return AllianceDiplomacyPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public override IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ( IPersistanceSession owner )
        {
			return AllianceDiplomacyPersistanceStateless.AttachSession (owner);
        }

        #endregion AllianceDiplomacy Persistance
        
        #region UniverseSpecialSector Persistance

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ()
        {
			return UniverseSpecialSectorPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance OpenUniverseSpecialSectorPersistance ()
        {
			return UniverseSpecialSectorPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public override IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ( IPersistanceSession owner )
        {
			return UniverseSpecialSectorPersistanceStateless.AttachSession (owner);
        }

        #endregion UniverseSpecialSector Persistance
        
        #region Medal Persistance

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance GetMedalPersistance ()
        {
			return MedalPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance OpenMedalPersistance ()
        {
			return MedalPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Medal persistance</returns>
        public override IMedalPersistance GetMedalPersistance ( IPersistanceSession owner )
        {
			return MedalPersistanceStateless.AttachSession (owner);
        }

        #endregion Medal Persistance
        
        #region FriendOrFoe Persistance

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance GetFriendOrFoePersistance ()
        {
			return FriendOrFoePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance OpenFriendOrFoePersistance ()
        {
			return FriendOrFoePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FriendOrFoe persistance</returns>
        public override IFriendOrFoePersistance GetFriendOrFoePersistance ( IPersistanceSession owner )
        {
			return FriendOrFoePersistanceStateless.AttachSession (owner);
        }

        #endregion FriendOrFoe Persistance
        
        #region PlanetStorage Persistance

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance GetPlanetStoragePersistance ()
        {
			return PlanetStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance OpenPlanetStoragePersistance ()
        {
			return PlanetStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetStorage persistance</returns>
        public override IPlanetStoragePersistance GetPlanetStoragePersistance ( IPersistanceSession owner )
        {
			return PlanetStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion PlanetStorage Persistance
        
        #region Invoice Persistance

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance GetInvoicePersistance ()
        {
			return InvoicePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance OpenInvoicePersistance ()
        {
			return InvoicePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Invoice persistance</returns>
        public override IInvoicePersistance GetInvoicePersistance ( IPersistanceSession owner )
        {
			return InvoicePersistanceStateless.AttachSession (owner);
        }

        #endregion Invoice Persistance
        
        #region BidHistorical Persistance

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance GetBidHistoricalPersistance ()
        {
			return BidHistoricalPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance OpenBidHistoricalPersistance ()
        {
			return BidHistoricalPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BidHistorical persistance</returns>
        public override IBidHistoricalPersistance GetBidHistoricalPersistance ( IPersistanceSession owner )
        {
			return BidHistoricalPersistanceStateless.AttachSession (owner);
        }

        #endregion BidHistorical Persistance
        
        #region PlanetResourceStorage Persistance

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ()
        {
			return PlanetResourceStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance OpenPlanetResourceStoragePersistance ()
        {
			return PlanetResourceStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public override IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ( IPersistanceSession owner )
        {
			return PlanetResourceStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion PlanetResourceStorage Persistance
        
        #region BattleStats Persistance

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance GetBattleStatsPersistance ()
        {
			return BattleStatsPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance OpenBattleStatsPersistance ()
        {
			return BattleStatsPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleStats persistance</returns>
        public override IBattleStatsPersistance GetBattleStatsPersistance ( IPersistanceSession owner )
        {
			return BattleStatsPersistanceStateless.AttachSession (owner);
        }

        #endregion BattleStats Persistance
        
        #region Offering Persistance

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance GetOfferingPersistance ()
        {
			return OfferingPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance OpenOfferingPersistance ()
        {
			return OfferingPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Offering persistance</returns>
        public override IOfferingPersistance GetOfferingPersistance ( IPersistanceSession owner )
        {
			return OfferingPersistanceStateless.AttachSession (owner);
        }

        #endregion Offering Persistance
        
        #region PrincipalTournament Persistance

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ()
        {
			return PrincipalTournamentPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance OpenPrincipalTournamentPersistance ()
        {
			return PrincipalTournamentPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalTournament persistance</returns>
        public override IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ( IPersistanceSession owner )
        {
			return PrincipalTournamentPersistanceStateless.AttachSession (owner);
        }

        #endregion PrincipalTournament Persistance
        
        #region PlayerStorage Persistance

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance GetPlayerStoragePersistance ()
        {
			return PlayerStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance OpenPlayerStoragePersistance ()
        {
			return PlayerStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStorage persistance</returns>
        public override IPlayerStoragePersistance GetPlayerStoragePersistance ( IPersistanceSession owner )
        {
			return PlayerStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion PlayerStorage Persistance
        
        #region ArenaStorage Persistance

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance GetArenaStoragePersistance ()
        {
			return ArenaStoragePersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance OpenArenaStoragePersistance ()
        {
			return ArenaStoragePersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaStorage persistance</returns>
        public override IArenaStoragePersistance GetArenaStoragePersistance ( IPersistanceSession owner )
        {
			return ArenaStoragePersistanceStateless.AttachSession (owner);
        }

        #endregion ArenaStorage Persistance
        
        #region Asset Persistance

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance GetAssetPersistance ()
        {
			return AssetPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance OpenAssetPersistance ()
        {
			return AssetPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Asset persistance</returns>
        public override IAssetPersistance GetAssetPersistance ( IPersistanceSession owner )
        {
			return AssetPersistanceStateless.AttachSession (owner);
        }

        #endregion Asset Persistance
        
        #region Fleet Persistance

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance GetFleetPersistance ()
        {
			return FleetPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance OpenFleetPersistance ()
        {
			return FleetPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Fleet persistance</returns>
        public override IFleetPersistance GetFleetPersistance ( IPersistanceSession owner )
        {
			return FleetPersistanceStateless.AttachSession (owner);
        }

        #endregion Fleet Persistance
        
        #region CampaignStatus Persistance

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance GetCampaignStatusPersistance ()
        {
			return CampaignStatusPersistanceStateless.GetSession ();
        }
        
        /// <summary>
        /// Opens a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance OpenCampaignStatusPersistance ()
        {
			return CampaignStatusPersistanceStateless.CreateSession ();
        }

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignStatus persistance</returns>
        public override ICampaignStatusPersistance GetCampaignStatusPersistance ( IPersistanceSession owner )
        {
			return CampaignStatusPersistanceStateless.AttachSession (owner);
        }

        #endregion CampaignStatus Persistance
        
    };
}

