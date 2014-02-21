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
    public interface IPersistanceProvider {

        #region Generic

        /// <summary>
        /// Gets a generic persistance object
        /// </summary>
        /// <returns>The persistance object</returns>
        IPersistanceSession GetGenericPersistance();

        /// <summary>
        /// Gets a generic persistance object
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The persistance object</returns>
        IPersistanceSession GetGenericPersistance( IPersistanceSession owner );
        
        /// <summary>
        /// Gets a typed IPersistance
        /// </summary>
        /// <typeparam name="T">The target entity type</typeparam>
        /// <returns>The persistance</returns>
        IPersistance<T> GetPersistance<T>();

        /// <summary>
        /// Gets a typed IPersistance
        /// </summary>
        /// <typeparam name="T">The target entity type</typeparam>
        /// <param name="owner">The owner</param>
        /// <returns>The persistance</returns>
        IPersistance<T> GetPersistance<T>(IPersistanceSession owner);
        
        /// <summary>
        /// Gets a persistance implementation for the given type
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <param name="owner">The owner session</param>
        /// <returns>The persistance session</returns>
        IPersistanceSession GetPersistance(Type type, IPersistanceSession owner);
        
        /// <summary>
        /// Gets a persistance for the given type
        /// </summary>
        /// <param name="type">The entity type</param>
        /// <returns>The persistance implementation</returns>
        IPersistanceSession GetPersistance(Type type);
        
        #endregion Generic

        #region BotCredential Persistance

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        IBotCredentialPersistance GetBotCredentialPersistance ();
        
        /// <summary>
        /// Opens a BotCredential persistance
        /// </summary>
        /// <returns>The BotCredential persistance</returns>
        IBotCredentialPersistance OpenBotCredentialPersistance ();

        /// <summary>
        /// Gets a BotCredential persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotCredential persistance</returns>
        IBotCredentialPersistance GetBotCredentialPersistance ( IPersistanceSession owner );

        #endregion BotCredential Persistance
        
        #region PendingBotRequest Persistance

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        IPendingBotRequestPersistance GetPendingBotRequestPersistance ();
        
        /// <summary>
        /// Opens a PendingBotRequest persistance
        /// </summary>
        /// <returns>The PendingBotRequest persistance</returns>
        IPendingBotRequestPersistance OpenPendingBotRequestPersistance ();

        /// <summary>
        /// Gets a PendingBotRequest persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PendingBotRequest persistance</returns>
        IPendingBotRequestPersistance GetPendingBotRequestPersistance ( IPersistanceSession owner );

        #endregion PendingBotRequest Persistance
        
        #region Country Persistance

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        ICountryPersistance GetCountryPersistance ();
        
        /// <summary>
        /// Opens a Country persistance
        /// </summary>
        /// <returns>The Country persistance</returns>
        ICountryPersistance OpenCountryPersistance ();

        /// <summary>
        /// Gets a Country persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Country persistance</returns>
        ICountryPersistance GetCountryPersistance ( IPersistanceSession owner );

        #endregion Country Persistance
        
        #region BotHandler Persistance

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        IBotHandlerPersistance GetBotHandlerPersistance ();
        
        /// <summary>
        /// Opens a BotHandler persistance
        /// </summary>
        /// <returns>The BotHandler persistance</returns>
        IBotHandlerPersistance OpenBotHandlerPersistance ();

        /// <summary>
        /// Gets a BotHandler persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BotHandler persistance</returns>
        IBotHandlerPersistance GetBotHandlerPersistance ( IPersistanceSession owner );

        #endregion BotHandler Persistance
        
        #region TeamStorage Persistance

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        ITeamStoragePersistance GetTeamStoragePersistance ();
        
        /// <summary>
        /// Opens a TeamStorage persistance
        /// </summary>
        /// <returns>The TeamStorage persistance</returns>
        ITeamStoragePersistance OpenTeamStoragePersistance ();

        /// <summary>
        /// Gets a TeamStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TeamStorage persistance</returns>
        ITeamStoragePersistance GetTeamStoragePersistance ( IPersistanceSession owner );

        #endregion TeamStorage Persistance
        
        #region AllianceStorage Persistance

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        IAllianceStoragePersistance GetAllianceStoragePersistance ();
        
        /// <summary>
        /// Opens a AllianceStorage persistance
        /// </summary>
        /// <returns>The AllianceStorage persistance</returns>
        IAllianceStoragePersistance OpenAllianceStoragePersistance ();

        /// <summary>
        /// Gets a AllianceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceStorage persistance</returns>
        IAllianceStoragePersistance GetAllianceStoragePersistance ( IPersistanceSession owner );

        #endregion AllianceStorage Persistance
        
        #region ServerProperties Persistance

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        IServerPropertiesPersistance GetServerPropertiesPersistance ();
        
        /// <summary>
        /// Opens a ServerProperties persistance
        /// </summary>
        /// <returns>The ServerProperties persistance</returns>
        IServerPropertiesPersistance OpenServerPropertiesPersistance ();

        /// <summary>
        /// Gets a ServerProperties persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ServerProperties persistance</returns>
        IServerPropertiesPersistance GetServerPropertiesPersistance ( IPersistanceSession owner );

        #endregion ServerProperties Persistance
        
        #region PlayerStats Persistance

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        IPlayerStatsPersistance GetPlayerStatsPersistance ();
        
        /// <summary>
        /// Opens a PlayerStats persistance
        /// </summary>
        /// <returns>The PlayerStats persistance</returns>
        IPlayerStatsPersistance OpenPlayerStatsPersistance ();

        /// <summary>
        /// Gets a PlayerStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStats persistance</returns>
        IPlayerStatsPersistance GetPlayerStatsPersistance ( IPersistanceSession owner );

        #endregion PlayerStats Persistance
        
        #region Interaction Persistance

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        IInteractionPersistance GetInteractionPersistance ();
        
        /// <summary>
        /// Opens a Interaction persistance
        /// </summary>
        /// <returns>The Interaction persistance</returns>
        IInteractionPersistance OpenInteractionPersistance ();

        /// <summary>
        /// Gets a Interaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Interaction persistance</returns>
        IInteractionPersistance GetInteractionPersistance ( IPersistanceSession owner );

        #endregion Interaction Persistance
        
        #region Transaction Persistance

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        ITransactionPersistance GetTransactionPersistance ();
        
        /// <summary>
        /// Opens a Transaction persistance
        /// </summary>
        /// <returns>The Transaction persistance</returns>
        ITransactionPersistance OpenTransactionPersistance ();

        /// <summary>
        /// Gets a Transaction persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Transaction persistance</returns>
        ITransactionPersistance GetTransactionPersistance ( IPersistanceSession owner );

        #endregion Transaction Persistance
        
        #region DuplicateDetection Persistance

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ();
        
        /// <summary>
        /// Opens a DuplicateDetection persistance
        /// </summary>
        /// <returns>The DuplicateDetection persistance</returns>
        IDuplicateDetectionPersistance OpenDuplicateDetectionPersistance ();

        /// <summary>
        /// Gets a DuplicateDetection persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The DuplicateDetection persistance</returns>
        IDuplicateDetectionPersistance GetDuplicateDetectionPersistance ( IPersistanceSession owner );

        #endregion DuplicateDetection Persistance
        
        #region PaymentDescription Persistance

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ();
        
        /// <summary>
        /// Opens a PaymentDescription persistance
        /// </summary>
        /// <returns>The PaymentDescription persistance</returns>
        IPaymentDescriptionPersistance OpenPaymentDescriptionPersistance ();

        /// <summary>
        /// Gets a PaymentDescription persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PaymentDescription persistance</returns>
        IPaymentDescriptionPersistance GetPaymentDescriptionPersistance ( IPersistanceSession owner );

        #endregion PaymentDescription Persistance
        
        #region Payment Persistance

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        IPaymentPersistance GetPaymentPersistance ();
        
        /// <summary>
        /// Opens a Payment persistance
        /// </summary>
        /// <returns>The Payment persistance</returns>
        IPaymentPersistance OpenPaymentPersistance ();

        /// <summary>
        /// Gets a Payment persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Payment persistance</returns>
        IPaymentPersistance GetPaymentPersistance ( IPersistanceSession owner );

        #endregion Payment Persistance
        
        #region WormHolePlayers Persistance

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        IWormHolePlayersPersistance GetWormHolePlayersPersistance ();
        
        /// <summary>
        /// Opens a WormHolePlayers persistance
        /// </summary>
        /// <returns>The WormHolePlayers persistance</returns>
        IWormHolePlayersPersistance OpenWormHolePlayersPersistance ();

        /// <summary>
        /// Gets a WormHolePlayers persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The WormHolePlayers persistance</returns>
        IWormHolePlayersPersistance GetWormHolePlayersPersistance ( IPersistanceSession owner );

        #endregion WormHolePlayers Persistance
        
        #region GlobalStats Persistance

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        IGlobalStatsPersistance GetGlobalStatsPersistance ();
        
        /// <summary>
        /// Opens a GlobalStats persistance
        /// </summary>
        /// <returns>The GlobalStats persistance</returns>
        IGlobalStatsPersistance OpenGlobalStatsPersistance ();

        /// <summary>
        /// Gets a GlobalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GlobalStats persistance</returns>
        IGlobalStatsPersistance GetGlobalStatsPersistance ( IPersistanceSession owner );

        #endregion GlobalStats Persistance
        
        #region ForumTopic Persistance

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        IForumTopicPersistance GetForumTopicPersistance ();
        
        /// <summary>
        /// Opens a ForumTopic persistance
        /// </summary>
        /// <returns>The ForumTopic persistance</returns>
        IForumTopicPersistance OpenForumTopicPersistance ();

        /// <summary>
        /// Gets a ForumTopic persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumTopic persistance</returns>
        IForumTopicPersistance GetForumTopicPersistance ( IPersistanceSession owner );

        #endregion ForumTopic Persistance
        
        #region Message Persistance

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        IMessagePersistance GetMessagePersistance ();
        
        /// <summary>
        /// Opens a Message persistance
        /// </summary>
        /// <returns>The Message persistance</returns>
        IMessagePersistance OpenMessagePersistance ();

        /// <summary>
        /// Gets a Message persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Message persistance</returns>
        IMessagePersistance GetMessagePersistance ( IPersistanceSession owner );

        #endregion Message Persistance
        
        #region Tournament Persistance

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        ITournamentPersistance GetTournamentPersistance ();
        
        /// <summary>
        /// Opens a Tournament persistance
        /// </summary>
        /// <returns>The Tournament persistance</returns>
        ITournamentPersistance OpenTournamentPersistance ();

        /// <summary>
        /// Gets a Tournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Tournament persistance</returns>
        ITournamentPersistance GetTournamentPersistance ( IPersistanceSession owner );

        #endregion Tournament Persistance
        
        #region SpecialEvent Persistance

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        ISpecialEventPersistance GetSpecialEventPersistance ();
        
        /// <summary>
        /// Opens a SpecialEvent persistance
        /// </summary>
        /// <returns>The SpecialEvent persistance</returns>
        ISpecialEventPersistance OpenSpecialEventPersistance ();

        /// <summary>
        /// Gets a SpecialEvent persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SpecialEvent persistance</returns>
        ISpecialEventPersistance GetSpecialEventPersistance ( IPersistanceSession owner );

        #endregion SpecialEvent Persistance
        
        #region LogStorage Persistance

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        ILogStoragePersistance GetLogStoragePersistance ();
        
        /// <summary>
        /// Opens a LogStorage persistance
        /// </summary>
        /// <returns>The LogStorage persistance</returns>
        ILogStoragePersistance OpenLogStoragePersistance ();

        /// <summary>
        /// Gets a LogStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The LogStorage persistance</returns>
        ILogStoragePersistance GetLogStoragePersistance ( IPersistanceSession owner );

        #endregion LogStorage Persistance
        
        #region PrincipalStats Persistance

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        IPrincipalStatsPersistance GetPrincipalStatsPersistance ();
        
        /// <summary>
        /// Opens a PrincipalStats persistance
        /// </summary>
        /// <returns>The PrincipalStats persistance</returns>
        IPrincipalStatsPersistance OpenPrincipalStatsPersistance ();

        /// <summary>
        /// Gets a PrincipalStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalStats persistance</returns>
        IPrincipalStatsPersistance GetPrincipalStatsPersistance ( IPersistanceSession owner );

        #endregion PrincipalStats Persistance
        
        #region VoteStorage Persistance

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        IVoteStoragePersistance GetVoteStoragePersistance ();
        
        /// <summary>
        /// Opens a VoteStorage persistance
        /// </summary>
        /// <returns>The VoteStorage persistance</returns>
        IVoteStoragePersistance OpenVoteStoragePersistance ();

        /// <summary>
        /// Gets a VoteStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteStorage persistance</returns>
        IVoteStoragePersistance GetVoteStoragePersistance ( IPersistanceSession owner );

        #endregion VoteStorage Persistance
        
        #region VoteReferral Persistance

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        IVoteReferralPersistance GetVoteReferralPersistance ();
        
        /// <summary>
        /// Opens a VoteReferral persistance
        /// </summary>
        /// <returns>The VoteReferral persistance</returns>
        IVoteReferralPersistance OpenVoteReferralPersistance ();

        /// <summary>
        /// Gets a VoteReferral persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The VoteReferral persistance</returns>
        IVoteReferralPersistance GetVoteReferralPersistance ( IPersistanceSession owner );

        #endregion VoteReferral Persistance
        
        #region Product Persistance

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        IProductPersistance GetProductPersistance ();
        
        /// <summary>
        /// Opens a Product persistance
        /// </summary>
        /// <returns>The Product persistance</returns>
        IProductPersistance OpenProductPersistance ();

        /// <summary>
        /// Gets a Product persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Product persistance</returns>
        IProductPersistance GetProductPersistance ( IPersistanceSession owner );

        #endregion Product Persistance
        
        #region ExceptionInfo Persistance

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        IExceptionInfoPersistance GetExceptionInfoPersistance ();
        
        /// <summary>
        /// Opens a ExceptionInfo persistance
        /// </summary>
        /// <returns>The ExceptionInfo persistance</returns>
        IExceptionInfoPersistance OpenExceptionInfoPersistance ();

        /// <summary>
        /// Gets a ExceptionInfo persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ExceptionInfo persistance</returns>
        IExceptionInfoPersistance GetExceptionInfoPersistance ( IPersistanceSession owner );

        #endregion ExceptionInfo Persistance
        
        #region Promotion Persistance

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        IPromotionPersistance GetPromotionPersistance ();
        
        /// <summary>
        /// Opens a Promotion persistance
        /// </summary>
        /// <returns>The Promotion persistance</returns>
        IPromotionPersistance OpenPromotionPersistance ();

        /// <summary>
        /// Gets a Promotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Promotion persistance</returns>
        IPromotionPersistance GetPromotionPersistance ( IPersistanceSession owner );

        #endregion Promotion Persistance
        
        #region Campaign Persistance

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        ICampaignPersistance GetCampaignPersistance ();
        
        /// <summary>
        /// Opens a Campaign persistance
        /// </summary>
        /// <returns>The Campaign persistance</returns>
        ICampaignPersistance OpenCampaignPersistance ();

        /// <summary>
        /// Gets a Campaign persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Campaign persistance</returns>
        ICampaignPersistance GetCampaignPersistance ( IPersistanceSession owner );

        #endregion Campaign Persistance
        
        #region PrivateBoard Persistance

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        IPrivateBoardPersistance GetPrivateBoardPersistance ();
        
        /// <summary>
        /// Opens a PrivateBoard persistance
        /// </summary>
        /// <returns>The PrivateBoard persistance</returns>
        IPrivateBoardPersistance OpenPrivateBoardPersistance ();

        /// <summary>
        /// Gets a PrivateBoard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrivateBoard persistance</returns>
        IPrivateBoardPersistance GetPrivateBoardPersistance ( IPersistanceSession owner );

        #endregion PrivateBoard Persistance
        
        #region CampaignLevel Persistance

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        ICampaignLevelPersistance GetCampaignLevelPersistance ();
        
        /// <summary>
        /// Opens a CampaignLevel persistance
        /// </summary>
        /// <returns>The CampaignLevel persistance</returns>
        ICampaignLevelPersistance OpenCampaignLevelPersistance ();

        /// <summary>
        /// Gets a CampaignLevel persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignLevel persistance</returns>
        ICampaignLevelPersistance GetCampaignLevelPersistance ( IPersistanceSession owner );

        #endregion CampaignLevel Persistance
        
        #region Task Persistance

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        ITaskPersistance GetTaskPersistance ();
        
        /// <summary>
        /// Opens a Task persistance
        /// </summary>
        /// <returns>The Task persistance</returns>
        ITaskPersistance OpenTaskPersistance ();

        /// <summary>
        /// Gets a Task persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Task persistance</returns>
        ITaskPersistance GetTaskPersistance ( IPersistanceSession owner );

        #endregion Task Persistance
        
        #region BonusCard Persistance

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        IBonusCardPersistance GetBonusCardPersistance ();
        
        /// <summary>
        /// Opens a BonusCard persistance
        /// </summary>
        /// <returns>The BonusCard persistance</returns>
        IBonusCardPersistance OpenBonusCardPersistance ();

        /// <summary>
        /// Gets a BonusCard persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BonusCard persistance</returns>
        IBonusCardPersistance GetBonusCardPersistance ( IPersistanceSession owner );

        #endregion BonusCard Persistance
        
        #region ArenaHistorical Persistance

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        IArenaHistoricalPersistance GetArenaHistoricalPersistance ();
        
        /// <summary>
        /// Opens a ArenaHistorical persistance
        /// </summary>
        /// <returns>The ArenaHistorical persistance</returns>
        IArenaHistoricalPersistance OpenArenaHistoricalPersistance ();

        /// <summary>
        /// Gets a ArenaHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaHistorical persistance</returns>
        IArenaHistoricalPersistance GetArenaHistoricalPersistance ( IPersistanceSession owner );

        #endregion ArenaHistorical Persistance
        
        #region Principal Persistance

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        IPrincipalPersistance GetPrincipalPersistance ();
        
        /// <summary>
        /// Opens a Principal persistance
        /// </summary>
        /// <returns>The Principal persistance</returns>
        IPrincipalPersistance OpenPrincipalPersistance ();

        /// <summary>
        /// Gets a Principal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Principal persistance</returns>
        IPrincipalPersistance GetPrincipalPersistance ( IPersistanceSession owner );

        #endregion Principal Persistance
        
        #region FogOfWarStorage Persistance

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ();
        
        /// <summary>
        /// Opens a FogOfWarStorage persistance
        /// </summary>
        /// <returns>The FogOfWarStorage persistance</returns>
        IFogOfWarStoragePersistance OpenFogOfWarStoragePersistance ();

        /// <summary>
        /// Gets a FogOfWarStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FogOfWarStorage persistance</returns>
        IFogOfWarStoragePersistance GetFogOfWarStoragePersistance ( IPersistanceSession owner );

        #endregion FogOfWarStorage Persistance
        
        #region BattleExtention Persistance

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        IBattleExtentionPersistance GetBattleExtentionPersistance ();
        
        /// <summary>
        /// Opens a BattleExtention persistance
        /// </summary>
        /// <returns>The BattleExtention persistance</returns>
        IBattleExtentionPersistance OpenBattleExtentionPersistance ();

        /// <summary>
        /// Gets a BattleExtention persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleExtention persistance</returns>
        IBattleExtentionPersistance GetBattleExtentionPersistance ( IPersistanceSession owner );

        #endregion BattleExtention Persistance
        
        #region GroupPointsStorage Persistance

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ();
        
        /// <summary>
        /// Opens a GroupPointsStorage persistance
        /// </summary>
        /// <returns>The GroupPointsStorage persistance</returns>
        IGroupPointsStoragePersistance OpenGroupPointsStoragePersistance ();

        /// <summary>
        /// Gets a GroupPointsStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The GroupPointsStorage persistance</returns>
        IGroupPointsStoragePersistance GetGroupPointsStoragePersistance ( IPersistanceSession owner );

        #endregion GroupPointsStorage Persistance
        
        #region PlayersGroupStorage Persistance

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ();
        
        /// <summary>
        /// Opens a PlayersGroupStorage persistance
        /// </summary>
        /// <returns>The PlayersGroupStorage persistance</returns>
        IPlayersGroupStoragePersistance OpenPlayersGroupStoragePersistance ();

        /// <summary>
        /// Gets a PlayersGroupStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayersGroupStorage persistance</returns>
        IPlayersGroupStoragePersistance GetPlayersGroupStoragePersistance ( IPersistanceSession owner );

        #endregion PlayersGroupStorage Persistance
        
        #region AuctionHouse Persistance

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        IAuctionHousePersistance GetAuctionHousePersistance ();
        
        /// <summary>
        /// Opens a AuctionHouse persistance
        /// </summary>
        /// <returns>The AuctionHouse persistance</returns>
        IAuctionHousePersistance OpenAuctionHousePersistance ();

        /// <summary>
        /// Gets a AuctionHouse persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AuctionHouse persistance</returns>
        IAuctionHousePersistance GetAuctionHousePersistance ( IPersistanceSession owner );

        #endregion AuctionHouse Persistance
        
        #region Market Persistance

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        IMarketPersistance GetMarketPersistance ();
        
        /// <summary>
        /// Opens a Market persistance
        /// </summary>
        /// <returns>The Market persistance</returns>
        IMarketPersistance OpenMarketPersistance ();

        /// <summary>
        /// Gets a Market persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Market persistance</returns>
        IMarketPersistance GetMarketPersistance ( IPersistanceSession owner );

        #endregion Market Persistance
        
        #region QuestStorage Persistance

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        IQuestStoragePersistance GetQuestStoragePersistance ();
        
        /// <summary>
        /// Opens a QuestStorage persistance
        /// </summary>
        /// <returns>The QuestStorage persistance</returns>
        IQuestStoragePersistance OpenQuestStoragePersistance ();

        /// <summary>
        /// Gets a QuestStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The QuestStorage persistance</returns>
        IQuestStoragePersistance GetQuestStoragePersistance ( IPersistanceSession owner );

        #endregion QuestStorage Persistance
        
        #region PlayerBattleInformation Persistance

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ();
        
        /// <summary>
        /// Opens a PlayerBattleInformation persistance
        /// </summary>
        /// <returns>The PlayerBattleInformation persistance</returns>
        IPlayerBattleInformationPersistance OpenPlayerBattleInformationPersistance ();

        /// <summary>
        /// Gets a PlayerBattleInformation persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerBattleInformation persistance</returns>
        IPlayerBattleInformationPersistance GetPlayerBattleInformationPersistance ( IPersistanceSession owner );

        #endregion PlayerBattleInformation Persistance
        
        #region Battle Persistance

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        IBattlePersistance GetBattlePersistance ();
        
        /// <summary>
        /// Opens a Battle persistance
        /// </summary>
        /// <returns>The Battle persistance</returns>
        IBattlePersistance OpenBattlePersistance ();

        /// <summary>
        /// Gets a Battle persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Battle persistance</returns>
        IBattlePersistance GetBattlePersistance ( IPersistanceSession owner );

        #endregion Battle Persistance
        
        #region TimedActionStorage Persistance

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        ITimedActionStoragePersistance GetTimedActionStoragePersistance ();
        
        /// <summary>
        /// Opens a TimedActionStorage persistance
        /// </summary>
        /// <returns>The TimedActionStorage persistance</returns>
        ITimedActionStoragePersistance OpenTimedActionStoragePersistance ();

        /// <summary>
        /// Gets a TimedActionStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The TimedActionStorage persistance</returns>
        ITimedActionStoragePersistance GetTimedActionStoragePersistance ( IPersistanceSession owner );

        #endregion TimedActionStorage Persistance
        
        #region Necessity Persistance

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        INecessityPersistance GetNecessityPersistance ();
        
        /// <summary>
        /// Opens a Necessity persistance
        /// </summary>
        /// <returns>The Necessity persistance</returns>
        INecessityPersistance OpenNecessityPersistance ();

        /// <summary>
        /// Gets a Necessity persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Necessity persistance</returns>
        INecessityPersistance GetNecessityPersistance ( IPersistanceSession owner );

        #endregion Necessity Persistance
        
        #region ForumPost Persistance

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        IForumPostPersistance GetForumPostPersistance ();
        
        /// <summary>
        /// Opens a ForumPost persistance
        /// </summary>
        /// <returns>The ForumPost persistance</returns>
        IForumPostPersistance OpenForumPostPersistance ();

        /// <summary>
        /// Gets a ForumPost persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumPost persistance</returns>
        IForumPostPersistance GetForumPostPersistance ( IPersistanceSession owner );

        #endregion ForumPost Persistance
        
        #region ForumReadMarking Persistance

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        IForumReadMarkingPersistance GetForumReadMarkingPersistance ();
        
        /// <summary>
        /// Opens a ForumReadMarking persistance
        /// </summary>
        /// <returns>The ForumReadMarking persistance</returns>
        IForumReadMarkingPersistance OpenForumReadMarkingPersistance ();

        /// <summary>
        /// Gets a ForumReadMarking persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumReadMarking persistance</returns>
        IForumReadMarkingPersistance GetForumReadMarkingPersistance ( IPersistanceSession owner );

        #endregion ForumReadMarking Persistance
        
        #region ActivatedPromotion Persistance

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        IActivatedPromotionPersistance GetActivatedPromotionPersistance ();
        
        /// <summary>
        /// Opens a ActivatedPromotion persistance
        /// </summary>
        /// <returns>The ActivatedPromotion persistance</returns>
        IActivatedPromotionPersistance OpenActivatedPromotionPersistance ();

        /// <summary>
        /// Gets a ActivatedPromotion persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ActivatedPromotion persistance</returns>
        IActivatedPromotionPersistance GetActivatedPromotionPersistance ( IPersistanceSession owner );

        #endregion ActivatedPromotion Persistance
        
        #region ForumThread Persistance

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        IForumThreadPersistance GetForumThreadPersistance ();
        
        /// <summary>
        /// Opens a ForumThread persistance
        /// </summary>
        /// <returns>The ForumThread persistance</returns>
        IForumThreadPersistance OpenForumThreadPersistance ();

        /// <summary>
        /// Gets a ForumThread persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ForumThread persistance</returns>
        IForumThreadPersistance GetForumThreadPersistance ( IPersistanceSession owner );

        #endregion ForumThread Persistance
        
        #region SectorStorage Persistance

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        ISectorStoragePersistance GetSectorStoragePersistance ();
        
        /// <summary>
        /// Opens a SectorStorage persistance
        /// </summary>
        /// <returns>The SectorStorage persistance</returns>
        ISectorStoragePersistance OpenSectorStoragePersistance ();

        /// <summary>
        /// Gets a SectorStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The SectorStorage persistance</returns>
        ISectorStoragePersistance GetSectorStoragePersistance ( IPersistanceSession owner );

        #endregion SectorStorage Persistance
        
        #region AllianceDiplomacy Persistance

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ();
        
        /// <summary>
        /// Opens a AllianceDiplomacy persistance
        /// </summary>
        /// <returns>The AllianceDiplomacy persistance</returns>
        IAllianceDiplomacyPersistance OpenAllianceDiplomacyPersistance ();

        /// <summary>
        /// Gets a AllianceDiplomacy persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The AllianceDiplomacy persistance</returns>
        IAllianceDiplomacyPersistance GetAllianceDiplomacyPersistance ( IPersistanceSession owner );

        #endregion AllianceDiplomacy Persistance
        
        #region UniverseSpecialSector Persistance

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ();
        
        /// <summary>
        /// Opens a UniverseSpecialSector persistance
        /// </summary>
        /// <returns>The UniverseSpecialSector persistance</returns>
        IUniverseSpecialSectorPersistance OpenUniverseSpecialSectorPersistance ();

        /// <summary>
        /// Gets a UniverseSpecialSector persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The UniverseSpecialSector persistance</returns>
        IUniverseSpecialSectorPersistance GetUniverseSpecialSectorPersistance ( IPersistanceSession owner );

        #endregion UniverseSpecialSector Persistance
        
        #region Medal Persistance

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        IMedalPersistance GetMedalPersistance ();
        
        /// <summary>
        /// Opens a Medal persistance
        /// </summary>
        /// <returns>The Medal persistance</returns>
        IMedalPersistance OpenMedalPersistance ();

        /// <summary>
        /// Gets a Medal persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Medal persistance</returns>
        IMedalPersistance GetMedalPersistance ( IPersistanceSession owner );

        #endregion Medal Persistance
        
        #region FriendOrFoe Persistance

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        IFriendOrFoePersistance GetFriendOrFoePersistance ();
        
        /// <summary>
        /// Opens a FriendOrFoe persistance
        /// </summary>
        /// <returns>The FriendOrFoe persistance</returns>
        IFriendOrFoePersistance OpenFriendOrFoePersistance ();

        /// <summary>
        /// Gets a FriendOrFoe persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The FriendOrFoe persistance</returns>
        IFriendOrFoePersistance GetFriendOrFoePersistance ( IPersistanceSession owner );

        #endregion FriendOrFoe Persistance
        
        #region PlanetStorage Persistance

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        IPlanetStoragePersistance GetPlanetStoragePersistance ();
        
        /// <summary>
        /// Opens a PlanetStorage persistance
        /// </summary>
        /// <returns>The PlanetStorage persistance</returns>
        IPlanetStoragePersistance OpenPlanetStoragePersistance ();

        /// <summary>
        /// Gets a PlanetStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetStorage persistance</returns>
        IPlanetStoragePersistance GetPlanetStoragePersistance ( IPersistanceSession owner );

        #endregion PlanetStorage Persistance
        
        #region Invoice Persistance

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        IInvoicePersistance GetInvoicePersistance ();
        
        /// <summary>
        /// Opens a Invoice persistance
        /// </summary>
        /// <returns>The Invoice persistance</returns>
        IInvoicePersistance OpenInvoicePersistance ();

        /// <summary>
        /// Gets a Invoice persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Invoice persistance</returns>
        IInvoicePersistance GetInvoicePersistance ( IPersistanceSession owner );

        #endregion Invoice Persistance
        
        #region BidHistorical Persistance

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        IBidHistoricalPersistance GetBidHistoricalPersistance ();
        
        /// <summary>
        /// Opens a BidHistorical persistance
        /// </summary>
        /// <returns>The BidHistorical persistance</returns>
        IBidHistoricalPersistance OpenBidHistoricalPersistance ();

        /// <summary>
        /// Gets a BidHistorical persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BidHistorical persistance</returns>
        IBidHistoricalPersistance GetBidHistoricalPersistance ( IPersistanceSession owner );

        #endregion BidHistorical Persistance
        
        #region PlanetResourceStorage Persistance

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ();
        
        /// <summary>
        /// Opens a PlanetResourceStorage persistance
        /// </summary>
        /// <returns>The PlanetResourceStorage persistance</returns>
        IPlanetResourceStoragePersistance OpenPlanetResourceStoragePersistance ();

        /// <summary>
        /// Gets a PlanetResourceStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlanetResourceStorage persistance</returns>
        IPlanetResourceStoragePersistance GetPlanetResourceStoragePersistance ( IPersistanceSession owner );

        #endregion PlanetResourceStorage Persistance
        
        #region BattleStats Persistance

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        IBattleStatsPersistance GetBattleStatsPersistance ();
        
        /// <summary>
        /// Opens a BattleStats persistance
        /// </summary>
        /// <returns>The BattleStats persistance</returns>
        IBattleStatsPersistance OpenBattleStatsPersistance ();

        /// <summary>
        /// Gets a BattleStats persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The BattleStats persistance</returns>
        IBattleStatsPersistance GetBattleStatsPersistance ( IPersistanceSession owner );

        #endregion BattleStats Persistance
        
        #region Offering Persistance

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        IOfferingPersistance GetOfferingPersistance ();
        
        /// <summary>
        /// Opens a Offering persistance
        /// </summary>
        /// <returns>The Offering persistance</returns>
        IOfferingPersistance OpenOfferingPersistance ();

        /// <summary>
        /// Gets a Offering persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Offering persistance</returns>
        IOfferingPersistance GetOfferingPersistance ( IPersistanceSession owner );

        #endregion Offering Persistance
        
        #region PrincipalTournament Persistance

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ();
        
        /// <summary>
        /// Opens a PrincipalTournament persistance
        /// </summary>
        /// <returns>The PrincipalTournament persistance</returns>
        IPrincipalTournamentPersistance OpenPrincipalTournamentPersistance ();

        /// <summary>
        /// Gets a PrincipalTournament persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PrincipalTournament persistance</returns>
        IPrincipalTournamentPersistance GetPrincipalTournamentPersistance ( IPersistanceSession owner );

        #endregion PrincipalTournament Persistance
        
        #region PlayerStorage Persistance

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        IPlayerStoragePersistance GetPlayerStoragePersistance ();
        
        /// <summary>
        /// Opens a PlayerStorage persistance
        /// </summary>
        /// <returns>The PlayerStorage persistance</returns>
        IPlayerStoragePersistance OpenPlayerStoragePersistance ();

        /// <summary>
        /// Gets a PlayerStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The PlayerStorage persistance</returns>
        IPlayerStoragePersistance GetPlayerStoragePersistance ( IPersistanceSession owner );

        #endregion PlayerStorage Persistance
        
        #region ArenaStorage Persistance

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        IArenaStoragePersistance GetArenaStoragePersistance ();
        
        /// <summary>
        /// Opens a ArenaStorage persistance
        /// </summary>
        /// <returns>The ArenaStorage persistance</returns>
        IArenaStoragePersistance OpenArenaStoragePersistance ();

        /// <summary>
        /// Gets a ArenaStorage persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The ArenaStorage persistance</returns>
        IArenaStoragePersistance GetArenaStoragePersistance ( IPersistanceSession owner );

        #endregion ArenaStorage Persistance
        
        #region Asset Persistance

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        IAssetPersistance GetAssetPersistance ();
        
        /// <summary>
        /// Opens a Asset persistance
        /// </summary>
        /// <returns>The Asset persistance</returns>
        IAssetPersistance OpenAssetPersistance ();

        /// <summary>
        /// Gets a Asset persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Asset persistance</returns>
        IAssetPersistance GetAssetPersistance ( IPersistanceSession owner );

        #endregion Asset Persistance
        
        #region Fleet Persistance

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        IFleetPersistance GetFleetPersistance ();
        
        /// <summary>
        /// Opens a Fleet persistance
        /// </summary>
        /// <returns>The Fleet persistance</returns>
        IFleetPersistance OpenFleetPersistance ();

        /// <summary>
        /// Gets a Fleet persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The Fleet persistance</returns>
        IFleetPersistance GetFleetPersistance ( IPersistanceSession owner );

        #endregion Fleet Persistance
        
        #region CampaignStatus Persistance

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        ICampaignStatusPersistance GetCampaignStatusPersistance ();
        
        /// <summary>
        /// Opens a CampaignStatus persistance
        /// </summary>
        /// <returns>The CampaignStatus persistance</returns>
        ICampaignStatusPersistance OpenCampaignStatusPersistance ();

        /// <summary>
        /// Gets a CampaignStatus persistance
        /// </summary>
        /// <param name="owner">The owner session</param>
        /// <returns>The CampaignStatus persistance</returns>
        ICampaignStatusPersistance GetCampaignStatusPersistance ( IPersistanceSession owner );

        #endregion CampaignStatus Persistance
        
    };
}

