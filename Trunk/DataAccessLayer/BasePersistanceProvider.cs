using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {

	/// <summary>
    /// Provides persistance objects
    /// </summary>
    public abstract class BasePersistanceProvider : IPersistanceProvider {

        #region Generic

        /// <summary>
        /// Gets a generic persistance object
        /// </summary>
        /// <returns>The persistance object</returns>
        public virtual IPersistanceSession GetGenericPersistance()
        {
			return GetPrincipalPersistance();
        }

        /// <summary>
        /// Gets a generic persistance object
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The persistance object</returns>
        public IPersistanceSession GetGenericPersistance( IPersistanceSession owner )
        {
			return GetPrincipalPersistance(owner);
        }
        
        /// <summary>
        /// Gets a persistance for the given type
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <returns>The persistance implementation</returns>
        public IPersistanceSession GetPersistance(Type type)
        {
            try {
                string methodName = string.Format("Get{0}Persistance", type.Name);
                MethodInfo method = GetType().GetMethod(methodName, new Type[0]);
                return (IPersistanceSession)method.Invoke(this, null);
            } catch( Exception ex ) {
                throw new DALException("Error getting IPersistance<{0}>", ex, type.Name);
            }
        }
        
        /// <summary>
        /// Gets a typed IPersistance
        /// </summary>
        /// <typeparam name="T">The target entity type</typeparam>
        /// <returns>The persistance</returns>
        public IPersistance<T> GetPersistance<T>()
        {
            return (IPersistance<T>)GetPersistance(typeof(T));
        }

        /// <summary>
        /// Gets a persistance implementation for the given type
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <param name="owner">The owner session</param>
        /// <returns>The persistance session</returns>
        public IPersistanceSession GetPersistance(Type type, IPersistanceSession owner)
        {
            try {
                string methodName = string.Format("Get{0}Persistance", type.Name);
                MethodInfo method = GetType().GetMethod(methodName, new Type[] { typeof(IPersistanceSession) });
                return (IPersistanceSession)method.Invoke(this, new object[] { owner });
            } catch( Exception ex ) {
                throw new DALException("Error getting IPersistance<{0}>", ex, type.Name);
            }
        }

        /// <summary>
        /// Gets a typed IPersistance
        /// </summary>
        /// <typeparam name="T">The target entity type</typeparam>
        /// <param name="owner">The owner</param>
        /// <returns>The persistance</returns>
        public IPersistance<T> GetPersistance<T>(IPersistanceSession owner)
        {
            return (IPersistance<T>) GetPersistance(typeof(T), owner);
        }
        
        #endregion Generic

        #region BotCredential Persistance

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        public abstract IBotCredentialPersistance GetBotCredentialPersistance ();
        
        /// <summary>
        /// Gets a fresh BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        public abstract IBotCredentialPersistance OpenBotCredentialPersistance ();

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotCredential persistance</returns>
        public abstract IBotCredentialPersistance GetBotCredentialPersistance ( IPersistanceSession owner );

        #endregion BotCredential Persistance
        
        #region PendingBotRequest Persistance

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        public abstract IPendingBotRequestPersistance GetPendingBotRequestPersistance ();
        
        /// <summary>
        /// Gets a fresh PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        public abstract IPendingBotRequestPersistance OpenPendingBotRequestPersistance ();

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PendingBotRequest persistance</returns>
        public abstract IPendingBotRequestPersistance GetPendingBotRequestPersistance ( IPersistanceSession owner );

        #endregion PendingBotRequest Persistance
        
        #region Country Persistance

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        public abstract ICountryPersistance GetCountryPersistance ();
        
        /// <summary>
        /// Gets a fresh Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        public abstract ICountryPersistance OpenCountryPersistance ();

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Country persistance</returns>
        public abstract ICountryPersistance GetCountryPersistance ( IPersistanceSession owner );

        #endregion Country Persistance
        
        #region BotHandler Persistance

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        public abstract IBotHandlerPersistance GetBotHandlerPersistance ();
        
        /// <summary>
        /// Gets a fresh BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        public abstract IBotHandlerPersistance OpenBotHandlerPersistance ();

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotHandler persistance</returns>
        public abstract IBotHandlerPersistance GetBotHandlerPersistance ( IPersistanceSession owner );

        #endregion BotHandler Persistance
        
        #region TeamStorage Persistance

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        public abstract ITeamStoragePersistance GetTeamStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        public abstract ITeamStoragePersistance OpenTeamStoragePersistance ();

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TeamStorage persistance</returns>
        public abstract ITeamStoragePersistance GetTeamStoragePersistance ( IPersistanceSession owner );

        #endregion TeamStorage Persistance
        
        #region AllianceStorage Persistance

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        public abstract IAllianceStoragePersistance GetAllianceStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        public abstract IAllianceStoragePersistance OpenAllianceStoragePersistance ();

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceStorage persistance</returns>
        public abstract IAllianceStoragePersistance GetAllianceStoragePersistance ( IPersistanceSession owner );

        #endregion AllianceStorage Persistance
        
        #region ServerProperties Persistance

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        public abstract IServerPropertiesPersistance GetServerPropertiesPersistance ();
        
        /// <summary>
        /// Gets a fresh ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        public abstract IServerPropertiesPersistance OpenServerPropertiesPersistance ();

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ServerProperties persistance</returns>
        public abstract IServerPropertiesPersistance GetServerPropertiesPersistance ( IPersistanceSession owner );

        #endregion ServerProperties Persistance
        
        #region PlayerStats Persistance

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        public abstract IPlayerStatsPersistance GetPlayerStatsPersistance ();
        
        /// <summary>
        /// Gets a fresh PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        public abstract IPlayerStatsPersistance OpenPlayerStatsPersistance ();

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStats persistance</returns>
        public abstract IPlayerStatsPersistance GetPlayerStatsPersistance ( IPersistanceSession owner );

        #endregion PlayerStats Persistance
        
        #region Interaction Persistance

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        public abstract IInteractionPersistance GetInteractionPersistance ();
        
        /// <summary>
        /// Gets a fresh Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        public abstract IInteractionPersistance OpenInteractionPersistance ();

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Interaction persistance</returns>
        public abstract IInteractionPersistance GetInteractionPersistance ( IPersistanceSession owner );

        #endregion Interaction Persistance
        
        #region Transaction Persistance

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        public abstract ITransactionPersistance GetTransactionPersistance ();
        
        /// <summary>
        /// Gets a fresh Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        public abstract ITransactionPersistance OpenTransactionPersistance ();

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Transaction persistance</returns>
        public abstract ITransactionPersistance GetTransactionPersistance ( IPersistanceSession owner );

        #endregion Transaction Persistance
        
        #region DuplicateDetection Persistance

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        public abstract IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ();
        
        /// <summary>
        /// Gets a fresh DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        public abstract IDuplicateDetectionPersistance OpenDuplicateDetectionPersistance ();

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The DuplicateDetection persistance</returns>
        public abstract IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ( IPersistanceSession owner );

        #endregion DuplicateDetection Persistance
        
        #region PaymentDescription Persistance

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        public abstract IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ();
        
        /// <summary>
        /// Gets a fresh PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        public abstract IPaymentDescriptionPersistance OpenPaymentDescriptionPersistance ();

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PaymentDescription persistance</returns>
        public abstract IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ( IPersistanceSession owner );

        #endregion PaymentDescription Persistance
        
        #region Payment Persistance

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        public abstract IPaymentPersistance GetPaymentPersistance ();
        
        /// <summary>
        /// Gets a fresh Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        public abstract IPaymentPersistance OpenPaymentPersistance ();

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Payment persistance</returns>
        public abstract IPaymentPersistance GetPaymentPersistance ( IPersistanceSession owner );

        #endregion Payment Persistance
        
        #region WormHolePlayers Persistance

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        public abstract IWormHolePlayersPersistance GetWormHolePlayersPersistance ();
        
        /// <summary>
        /// Gets a fresh WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        public abstract IWormHolePlayersPersistance OpenWormHolePlayersPersistance ();

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The WormHolePlayers persistance</returns>
        public abstract IWormHolePlayersPersistance GetWormHolePlayersPersistance ( IPersistanceSession owner );

        #endregion WormHolePlayers Persistance
        
        #region GlobalStats Persistance

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        public abstract IGlobalStatsPersistance GetGlobalStatsPersistance ();
        
        /// <summary>
        /// Gets a fresh GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        public abstract IGlobalStatsPersistance OpenGlobalStatsPersistance ();

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GlobalStats persistance</returns>
        public abstract IGlobalStatsPersistance GetGlobalStatsPersistance ( IPersistanceSession owner );

        #endregion GlobalStats Persistance
        
        #region ForumTopic Persistance

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        public abstract IForumTopicPersistance GetForumTopicPersistance ();
        
        /// <summary>
        /// Gets a fresh ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        public abstract IForumTopicPersistance OpenForumTopicPersistance ();

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumTopic persistance</returns>
        public abstract IForumTopicPersistance GetForumTopicPersistance ( IPersistanceSession owner );

        #endregion ForumTopic Persistance
        
        #region Message Persistance

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        public abstract IMessagePersistance GetMessagePersistance ();
        
        /// <summary>
        /// Gets a fresh Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        public abstract IMessagePersistance OpenMessagePersistance ();

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Message persistance</returns>
        public abstract IMessagePersistance GetMessagePersistance ( IPersistanceSession owner );

        #endregion Message Persistance
        
        #region Tournament Persistance

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        public abstract ITournamentPersistance GetTournamentPersistance ();
        
        /// <summary>
        /// Gets a fresh Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        public abstract ITournamentPersistance OpenTournamentPersistance ();

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Tournament persistance</returns>
        public abstract ITournamentPersistance GetTournamentPersistance ( IPersistanceSession owner );

        #endregion Tournament Persistance
        
        #region SpecialEvent Persistance

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        public abstract ISpecialEventPersistance GetSpecialEventPersistance ();
        
        /// <summary>
        /// Gets a fresh SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        public abstract ISpecialEventPersistance OpenSpecialEventPersistance ();

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SpecialEvent persistance</returns>
        public abstract ISpecialEventPersistance GetSpecialEventPersistance ( IPersistanceSession owner );

        #endregion SpecialEvent Persistance
        
        #region LogStorage Persistance

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        public abstract ILogStoragePersistance GetLogStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        public abstract ILogStoragePersistance OpenLogStoragePersistance ();

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The LogStorage persistance</returns>
        public abstract ILogStoragePersistance GetLogStoragePersistance ( IPersistanceSession owner );

        #endregion LogStorage Persistance
        
        #region PrincipalStats Persistance

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        public abstract IPrincipalStatsPersistance GetPrincipalStatsPersistance ();
        
        /// <summary>
        /// Gets a fresh PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        public abstract IPrincipalStatsPersistance OpenPrincipalStatsPersistance ();

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalStats persistance</returns>
        public abstract IPrincipalStatsPersistance GetPrincipalStatsPersistance ( IPersistanceSession owner );

        #endregion PrincipalStats Persistance
        
        #region VoteStorage Persistance

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        public abstract IVoteStoragePersistance GetVoteStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        public abstract IVoteStoragePersistance OpenVoteStoragePersistance ();

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteStorage persistance</returns>
        public abstract IVoteStoragePersistance GetVoteStoragePersistance ( IPersistanceSession owner );

        #endregion VoteStorage Persistance
        
        #region VoteReferral Persistance

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        public abstract IVoteReferralPersistance GetVoteReferralPersistance ();
        
        /// <summary>
        /// Gets a fresh VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        public abstract IVoteReferralPersistance OpenVoteReferralPersistance ();

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteReferral persistance</returns>
        public abstract IVoteReferralPersistance GetVoteReferralPersistance ( IPersistanceSession owner );

        #endregion VoteReferral Persistance
        
        #region Product Persistance

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        public abstract IProductPersistance GetProductPersistance ();
        
        /// <summary>
        /// Gets a fresh Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        public abstract IProductPersistance OpenProductPersistance ();

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Product persistance</returns>
        public abstract IProductPersistance GetProductPersistance ( IPersistanceSession owner );

        #endregion Product Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public abstract IExceptionInfoPersistance GetExceptionInfoPersistance ();
        
        /// <summary>
        /// Gets a fresh ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        public abstract IExceptionInfoPersistance OpenExceptionInfoPersistance ();

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        public abstract IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner );

        #endregion ExceptionInfo Persistance
        
        #region Promotion Persistance

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        public abstract IPromotionPersistance GetPromotionPersistance ();
        
        /// <summary>
        /// Gets a fresh Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        public abstract IPromotionPersistance OpenPromotionPersistance ();

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Promotion persistance</returns>
        public abstract IPromotionPersistance GetPromotionPersistance ( IPersistanceSession owner );

        #endregion Promotion Persistance
        
        #region Campaign Persistance

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        public abstract ICampaignPersistance GetCampaignPersistance ();
        
        /// <summary>
        /// Gets a fresh Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        public abstract ICampaignPersistance OpenCampaignPersistance ();

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Campaign persistance</returns>
        public abstract ICampaignPersistance GetCampaignPersistance ( IPersistanceSession owner );

        #endregion Campaign Persistance
        
        #region PrivateBoard Persistance

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        public abstract IPrivateBoardPersistance GetPrivateBoardPersistance ();
        
        /// <summary>
        /// Gets a fresh PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        public abstract IPrivateBoardPersistance OpenPrivateBoardPersistance ();

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrivateBoard persistance</returns>
        public abstract IPrivateBoardPersistance GetPrivateBoardPersistance ( IPersistanceSession owner );

        #endregion PrivateBoard Persistance
        
        #region CampaignLevel Persistance

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        public abstract ICampaignLevelPersistance GetCampaignLevelPersistance ();
        
        /// <summary>
        /// Gets a fresh CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        public abstract ICampaignLevelPersistance OpenCampaignLevelPersistance ();

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignLevel persistance</returns>
        public abstract ICampaignLevelPersistance GetCampaignLevelPersistance ( IPersistanceSession owner );

        #endregion CampaignLevel Persistance
        
        #region Task Persistance

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        public abstract ITaskPersistance GetTaskPersistance ();
        
        /// <summary>
        /// Gets a fresh Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        public abstract ITaskPersistance OpenTaskPersistance ();

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Task persistance</returns>
        public abstract ITaskPersistance GetTaskPersistance ( IPersistanceSession owner );

        #endregion Task Persistance
        
        #region BonusCard Persistance

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        public abstract IBonusCardPersistance GetBonusCardPersistance ();
        
        /// <summary>
        /// Gets a fresh BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        public abstract IBonusCardPersistance OpenBonusCardPersistance ();

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BonusCard persistance</returns>
        public abstract IBonusCardPersistance GetBonusCardPersistance ( IPersistanceSession owner );

        #endregion BonusCard Persistance
        
        #region ArenaHistorical Persistance

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        public abstract IArenaHistoricalPersistance GetArenaHistoricalPersistance ();
        
        /// <summary>
        /// Gets a fresh ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        public abstract IArenaHistoricalPersistance OpenArenaHistoricalPersistance ();

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaHistorical persistance</returns>
        public abstract IArenaHistoricalPersistance GetArenaHistoricalPersistance ( IPersistanceSession owner );

        #endregion ArenaHistorical Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public abstract IPrincipalPersistance GetPrincipalPersistance ();
        
        /// <summary>
        /// Gets a fresh Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        public abstract IPrincipalPersistance OpenPrincipalPersistance ();

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        public abstract IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner );

        #endregion Principal Persistance
        
        #region FogOfWarStorage Persistance

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        public abstract IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        public abstract IFogOfWarStoragePersistance OpenFogOfWarStoragePersistance ();

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FogOfWarStorage persistance</returns>
        public abstract IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ( IPersistanceSession owner );

        #endregion FogOfWarStorage Persistance
        
        #region BattleExtention Persistance

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        public abstract IBattleExtentionPersistance GetBattleExtentionPersistance ();
        
        /// <summary>
        /// Gets a fresh BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        public abstract IBattleExtentionPersistance OpenBattleExtentionPersistance ();

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleExtention persistance</returns>
        public abstract IBattleExtentionPersistance GetBattleExtentionPersistance ( IPersistanceSession owner );

        #endregion BattleExtention Persistance
        
        #region GroupPointsStorage Persistance

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        public abstract IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        public abstract IGroupPointsStoragePersistance OpenGroupPointsStoragePersistance ();

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GroupPointsStorage persistance</returns>
        public abstract IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ( IPersistanceSession owner );

        #endregion GroupPointsStorage Persistance
        
        #region PlayersGroupStorage Persistance

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public abstract IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public abstract IPlayersGroupStoragePersistance OpenPlayersGroupStoragePersistance ();

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayersGroupStorage persistance</returns>
        public abstract IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ( IPersistanceSession owner );

        #endregion PlayersGroupStorage Persistance
        
        #region AuctionHouse Persistance

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        public abstract IAuctionHousePersistance GetAuctionHousePersistance ();
        
        /// <summary>
        /// Gets a fresh AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        public abstract IAuctionHousePersistance OpenAuctionHousePersistance ();

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AuctionHouse persistance</returns>
        public abstract IAuctionHousePersistance GetAuctionHousePersistance ( IPersistanceSession owner );

        #endregion AuctionHouse Persistance
        
        #region Market Persistance

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        public abstract IMarketPersistance GetMarketPersistance ();
        
        /// <summary>
        /// Gets a fresh Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        public abstract IMarketPersistance OpenMarketPersistance ();

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Market persistance</returns>
        public abstract IMarketPersistance GetMarketPersistance ( IPersistanceSession owner );

        #endregion Market Persistance
        
        #region QuestStorage Persistance

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        public abstract IQuestStoragePersistance GetQuestStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        public abstract IQuestStoragePersistance OpenQuestStoragePersistance ();

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The QuestStorage persistance</returns>
        public abstract IQuestStoragePersistance GetQuestStoragePersistance ( IPersistanceSession owner );

        #endregion QuestStorage Persistance
        
        #region PlayerBattleInformation Persistance

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public abstract IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ();
        
        /// <summary>
        /// Gets a fresh PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public abstract IPlayerBattleInformationPersistance OpenPlayerBattleInformationPersistance ();

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerBattleInformation persistance</returns>
        public abstract IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ( IPersistanceSession owner );

        #endregion PlayerBattleInformation Persistance
        
        #region Battle Persistance

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        public abstract IBattlePersistance GetBattlePersistance ();
        
        /// <summary>
        /// Gets a fresh Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        public abstract IBattlePersistance OpenBattlePersistance ();

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Battle persistance</returns>
        public abstract IBattlePersistance GetBattlePersistance ( IPersistanceSession owner );

        #endregion Battle Persistance
        
        #region TimedActionStorage Persistance

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        public abstract ITimedActionStoragePersistance GetTimedActionStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        public abstract ITimedActionStoragePersistance OpenTimedActionStoragePersistance ();

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TimedActionStorage persistance</returns>
        public abstract ITimedActionStoragePersistance GetTimedActionStoragePersistance ( IPersistanceSession owner );

        #endregion TimedActionStorage Persistance
        
        #region Necessity Persistance

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        public abstract INecessityPersistance GetNecessityPersistance ();
        
        /// <summary>
        /// Gets a fresh Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        public abstract INecessityPersistance OpenNecessityPersistance ();

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Necessity persistance</returns>
        public abstract INecessityPersistance GetNecessityPersistance ( IPersistanceSession owner );

        #endregion Necessity Persistance
        
        #region ForumPost Persistance

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        public abstract IForumPostPersistance GetForumPostPersistance ();
        
        /// <summary>
        /// Gets a fresh ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        public abstract IForumPostPersistance OpenForumPostPersistance ();

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumPost persistance</returns>
        public abstract IForumPostPersistance GetForumPostPersistance ( IPersistanceSession owner );

        #endregion ForumPost Persistance
        
        #region ForumReadMarking Persistance

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        public abstract IForumReadMarkingPersistance GetForumReadMarkingPersistance ();
        
        /// <summary>
        /// Gets a fresh ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        public abstract IForumReadMarkingPersistance OpenForumReadMarkingPersistance ();

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumReadMarking persistance</returns>
        public abstract IForumReadMarkingPersistance GetForumReadMarkingPersistance ( IPersistanceSession owner );

        #endregion ForumReadMarking Persistance
        
        #region ActivatedPromotion Persistance

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        public abstract IActivatedPromotionPersistance GetActivatedPromotionPersistance ();
        
        /// <summary>
        /// Gets a fresh ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        public abstract IActivatedPromotionPersistance OpenActivatedPromotionPersistance ();

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ActivatedPromotion persistance</returns>
        public abstract IActivatedPromotionPersistance GetActivatedPromotionPersistance ( IPersistanceSession owner );

        #endregion ActivatedPromotion Persistance
        
        #region ForumThread Persistance

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        public abstract IForumThreadPersistance GetForumThreadPersistance ();
        
        /// <summary>
        /// Gets a fresh ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        public abstract IForumThreadPersistance OpenForumThreadPersistance ();

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumThread persistance</returns>
        public abstract IForumThreadPersistance GetForumThreadPersistance ( IPersistanceSession owner );

        #endregion ForumThread Persistance
        
        #region SectorStorage Persistance

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        public abstract ISectorStoragePersistance GetSectorStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        public abstract ISectorStoragePersistance OpenSectorStoragePersistance ();

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SectorStorage persistance</returns>
        public abstract ISectorStoragePersistance GetSectorStoragePersistance ( IPersistanceSession owner );

        #endregion SectorStorage Persistance
        
        #region AllianceDiplomacy Persistance

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public abstract IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ();
        
        /// <summary>
        /// Gets a fresh AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public abstract IAllianceDiplomacyPersistance OpenAllianceDiplomacyPersistance ();

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceDiplomacy persistance</returns>
        public abstract IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ( IPersistanceSession owner );

        #endregion AllianceDiplomacy Persistance
        
        #region UniverseSpecialSector Persistance

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public abstract IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ();
        
        /// <summary>
        /// Gets a fresh UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public abstract IUniverseSpecialSectorPersistance OpenUniverseSpecialSectorPersistance ();

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The UniverseSpecialSector persistance</returns>
        public abstract IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ( IPersistanceSession owner );

        #endregion UniverseSpecialSector Persistance
        
        #region Medal Persistance

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        public abstract IMedalPersistance GetMedalPersistance ();
        
        /// <summary>
        /// Gets a fresh Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        public abstract IMedalPersistance OpenMedalPersistance ();

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Medal persistance</returns>
        public abstract IMedalPersistance GetMedalPersistance ( IPersistanceSession owner );

        #endregion Medal Persistance
        
        #region FriendOrFoe Persistance

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        public abstract IFriendOrFoePersistance GetFriendOrFoePersistance ();
        
        /// <summary>
        /// Gets a fresh FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        public abstract IFriendOrFoePersistance OpenFriendOrFoePersistance ();

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FriendOrFoe persistance</returns>
        public abstract IFriendOrFoePersistance GetFriendOrFoePersistance ( IPersistanceSession owner );

        #endregion FriendOrFoe Persistance
        
        #region PlanetStorage Persistance

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        public abstract IPlanetStoragePersistance GetPlanetStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        public abstract IPlanetStoragePersistance OpenPlanetStoragePersistance ();

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetStorage persistance</returns>
        public abstract IPlanetStoragePersistance GetPlanetStoragePersistance ( IPersistanceSession owner );

        #endregion PlanetStorage Persistance
        
        #region Invoice Persistance

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        public abstract IInvoicePersistance GetInvoicePersistance ();
        
        /// <summary>
        /// Gets a fresh Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        public abstract IInvoicePersistance OpenInvoicePersistance ();

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Invoice persistance</returns>
        public abstract IInvoicePersistance GetInvoicePersistance ( IPersistanceSession owner );

        #endregion Invoice Persistance
        
        #region BidHistorical Persistance

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        public abstract IBidHistoricalPersistance GetBidHistoricalPersistance ();
        
        /// <summary>
        /// Gets a fresh BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        public abstract IBidHistoricalPersistance OpenBidHistoricalPersistance ();

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BidHistorical persistance</returns>
        public abstract IBidHistoricalPersistance GetBidHistoricalPersistance ( IPersistanceSession owner );

        #endregion BidHistorical Persistance
        
        #region PlanetResourceStorage Persistance

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public abstract IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public abstract IPlanetResourceStoragePersistance OpenPlanetResourceStoragePersistance ();

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetResourceStorage persistance</returns>
        public abstract IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ( IPersistanceSession owner );

        #endregion PlanetResourceStorage Persistance
        
        #region BattleStats Persistance

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        public abstract IBattleStatsPersistance GetBattleStatsPersistance ();
        
        /// <summary>
        /// Gets a fresh BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        public abstract IBattleStatsPersistance OpenBattleStatsPersistance ();

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleStats persistance</returns>
        public abstract IBattleStatsPersistance GetBattleStatsPersistance ( IPersistanceSession owner );

        #endregion BattleStats Persistance
        
        #region Offering Persistance

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        public abstract IOfferingPersistance GetOfferingPersistance ();
        
        /// <summary>
        /// Gets a fresh Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        public abstract IOfferingPersistance OpenOfferingPersistance ();

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Offering persistance</returns>
        public abstract IOfferingPersistance GetOfferingPersistance ( IPersistanceSession owner );

        #endregion Offering Persistance
        
        #region PrincipalTournament Persistance

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        public abstract IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ();
        
        /// <summary>
        /// Gets a fresh PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        public abstract IPrincipalTournamentPersistance OpenPrincipalTournamentPersistance ();

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalTournament persistance</returns>
        public abstract IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ( IPersistanceSession owner );

        #endregion PrincipalTournament Persistance
        
        #region PlayerStorage Persistance

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        public abstract IPlayerStoragePersistance GetPlayerStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        public abstract IPlayerStoragePersistance OpenPlayerStoragePersistance ();

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStorage persistance</returns>
        public abstract IPlayerStoragePersistance GetPlayerStoragePersistance ( IPersistanceSession owner );

        #endregion PlayerStorage Persistance
        
        #region ArenaStorage Persistance

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        public abstract IArenaStoragePersistance GetArenaStoragePersistance ();
        
        /// <summary>
        /// Gets a fresh ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        public abstract IArenaStoragePersistance OpenArenaStoragePersistance ();

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaStorage persistance</returns>
        public abstract IArenaStoragePersistance GetArenaStoragePersistance ( IPersistanceSession owner );

        #endregion ArenaStorage Persistance
        
        #region Asset Persistance

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        public abstract IAssetPersistance GetAssetPersistance ();
        
        /// <summary>
        /// Gets a fresh Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        public abstract IAssetPersistance OpenAssetPersistance ();

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Asset persistance</returns>
        public abstract IAssetPersistance GetAssetPersistance ( IPersistanceSession owner );

        #endregion Asset Persistance
        
        #region Fleet Persistance

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        public abstract IFleetPersistance GetFleetPersistance ();
        
        /// <summary>
        /// Gets a fresh Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        public abstract IFleetPersistance OpenFleetPersistance ();

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Fleet persistance</returns>
        public abstract IFleetPersistance GetFleetPersistance ( IPersistanceSession owner );

        #endregion Fleet Persistance
        
        #region CampaignStatus Persistance

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        public abstract ICampaignStatusPersistance GetCampaignStatusPersistance ();
        
        /// <summary>
        /// Gets a fresh CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        public abstract ICampaignStatusPersistance OpenCampaignStatusPersistance ();

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignStatus persistance</returns>
        public abstract ICampaignStatusPersistance GetCampaignStatusPersistance ( IPersistanceSession owner );

        #endregion CampaignStatus Persistance
        
    };
}

