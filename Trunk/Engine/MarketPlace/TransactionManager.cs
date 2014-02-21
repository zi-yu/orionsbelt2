
using System;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.MarketPlace
{
    public class TransactionManager
    {
        #region Public Methods

        #region Vacations Service

        /// <summary>
        /// Regists a access to the auto vacation service
        /// </summary>
        /// <param name="buyer">Player</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="persistance">Persistance session</param>
        public static void AutoVacationTransaction(Principal buyer, int credits, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.VacationService.ToString();

                transaction.PrincipalIdSpend = buyer.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierSpend = buyer.Id;
                transaction.CreditsSpend = credits;
                transaction.SpendCurrentCredits = buyer.Credits;

                transaction.IdentityTypeGain = TransactionIdentifier.System.ToString();
                transaction.IdentifierGain = 0;
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a access to the auto vacation service
        /// </summary>
        /// <param name="buyer">Player</param>
        /// <param name="credits">Credits that were payed</param>
        public static void AutoVacationTransaction(Principal buyer, int credits)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                AutoVacationTransaction(buyer, credits, persistance);
                persistance.Flush();
            }
        }

        #endregion Vacations Service

        #region Vacations

        /// <summary>
        /// Regists a vacation transaction
        /// </summary>
        /// <param name="buyer">Player</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="days">Number of day buyed</param>
        /// <param name="persistance">Persistance session</param>
        public static void VacationTransaction(Principal buyer, int credits, int days, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Vacations.ToString();

                transaction.PrincipalIdSpend = buyer.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierSpend = buyer.Id;
                transaction.CreditsSpend = credits;
                transaction.SpendCurrentCredits = buyer.Credits;

                transaction.IdentityTypeGain = days.ToString();
                transaction.IdentifierGain = 0;
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists an auction house transaction
        /// </summary>
        /// <param name="buyer">Player</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="days">Number of day buyed</param>
        public static void VacationTransaction(Principal buyer, int credits, int days)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                VacationTransaction(buyer, credits, days, persistance);
                persistance.Flush();
            }
        }

        #endregion Vacations

        #region Auction House

        /// <summary>
        /// Regists an auction house transaction
        /// </summary>
        /// <param name="item">The item that is being transact</param>
        /// <param name="buyer">Item buyer</param>
        /// <param name="persistance">Persistance session</param>
        public static void AuctionHouseTransaction(AuctionHouse item, PlayerStorage buyer, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.AuctionHouse.ToString();

                transaction.PrincipalIdSpend = buyer.Principal.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
                transaction.IdentifierSpend = buyer.Id;
                transaction.CreditsSpend = item.CurrentBid;
                transaction.SpendCurrentCredits = buyer.Principal.Credits;

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = item.Owner.Principal.Id;
                transaction.CreditsGain = CreditsUtil.GetValueWithoutTax(item.CurrentBid);
                transaction.GainCurrentCredits = item.Owner.Principal.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
            
        }

        /// <summary>
        /// Regists an auction house transaction
        /// </summary>
        /// <param name="item">The item that is being transact</param>
        /// <param name="buyer">Item buyer</param>
        public static void AuctionHouseTransaction(AuctionHouse item, PlayerStorage buyer)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                AuctionHouseTransaction(item, buyer, persistance);
                persistance.Flush();
            }
        }

        #endregion Auction House

        #region Payment

        /// <summary>
        /// Regists a payment transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="payment">Payment regist</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="money">Money payed</param>
        /// <param name="persistance">Persistance session</param>
        public static void PaymentTransaction(Principal principal,Payment payment, int credits, double money, IPersistanceSession persistance)
        {
            Messenger.Add(Category.Principal, typeof(PaymentMessage), principal.Id, credits.ToString());

            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
				transaction.TransactionContext = TransactionContext.Payment.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = principal.Id;
                transaction.CreditsGain = credits;
                transaction.GainCurrentCredits = principal.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
                InvoiceUtils.GenerateInvoice(transaction,payment, money, persistance2);
            }

        }

        /// <summary>
        /// Regists a payment transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="payment">Payment regist</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="money">Money payed</param>
        public static void PaymentTransaction(Principal principal, Payment payment, int credits, double money)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                persistance.StartTransaction();
                PaymentTransaction(principal,payment, credits, money, persistance);
                persistance.CommitTransaction();
            }
        }

        /// <summary>
        /// Regists a payment transaction
        /// </summary>
        /// <param name="alliance">Alliance that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="persistance">Persistance session</param>
        public static void PaymentTransaction(AllianceStorage alliance, int credits, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
				transaction.TransactionContext = TransactionContext.Payment.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Alliance.ToString();
                transaction.IdentifierGain = alliance.Id;
                transaction.CreditsGain = credits;
                transaction.GainCurrentCredits = alliance.Orions;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a payment transaction
        /// </summary>
        /// <param name="alliance">Alliance that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        public static void PaymentTransaction(AllianceStorage alliance, int credits)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                PaymentTransaction(alliance, credits, persistance);
                persistance.Flush();
            }
        }

        #endregion Payment

        #region Market

        /// <summary>
        /// Regists an auction house transaction
        /// </summary>
        /// <param name="market">Market where the payment was made</param>
        /// <param name="buyer">Item buyer</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="product">Product sold</param>
        /// <param name="persistance">Persistance session</param>
        public static void MarketTransaction(Market market, PlayerStorage buyer, int credits,string product, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
				transaction.TransactionContext = TransactionContext.Market.ToString();

                transaction.PrincipalIdSpend = buyer.Principal.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
                transaction.IdentifierSpend = buyer.Id;
                transaction.CreditsSpend = credits;
                transaction.SpendCurrentCredits = buyer.Principal.Credits;

                transaction.IdentityTypeGain = product;
                transaction.IdentifierGain = market.Id;
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists an auction house transaction
        /// </summary>
        /// <param name="market">Market where the payment was made</param>
        /// <param name="buyer">Item buyer</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="product">Product sold</param>
        public static void MarketTransaction(Market market, PlayerStorage buyer, int credits, string product)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                MarketTransaction(market, buyer, credits,product, persistance);
                persistance.Flush();
            }
        }

        #endregion Market

        #region Tournament

        /// <summary>
        /// Regists a tournament transaction
        /// </summary>
        /// <param name="tournament">Tournament where the payment was made</param>
        /// <param name="principal">Tournament entry buyer</param>
        /// <param name="persistance">Persistance session</param>
        public static void TournamentTransaction(Core.Tournament tournament, Principal principal, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                PrincipalTournamentFillInfo(transaction, principal, tournament);
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a tournament transaction
        /// </summary>
        /// <param name="tournament">Tournament where the payment was made</param>
        /// <param name="principal">Tournament entry buyer</param>
        public static void TournamentTransaction(Core.Tournament tournament, Principal principal)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                TournamentTransaction(tournament, principal, persistance);
                persistance.Flush();
            }
        }

        /// <summary>
        /// Regists a tournament transaction
        /// </summary>
        /// <param name="tournament">Tournament where the payment was made</param>
        /// <param name="team">Tournament entry team</param>
        /// <param name="persistance">Persistance session</param>
        public static void TournamentTransaction(Core.Tournament tournament, TeamStorage team, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                PrincipalTournamentFillInfo(transaction, team.Principals[0], tournament);
                persistance2.Update(transaction);

                transaction = persistance2.Create();
                PrincipalTournamentFillInfo(transaction, team.Principals[1], tournament);
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a tournament transaction
        /// </summary>
        /// <param name="tournament">Tournament where the payment was made</param>
        /// <param name="team">Tournament entry team</param>
        public static void TournamentTransaction(Core.Tournament tournament, TeamStorage team)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                TournamentTransaction(tournament, team, persistance);
                persistance.Flush();
            }
        }

        /// <summary>
        /// Regists a tournament battle winning
        /// </summary>
        /// <param name="orions">Orions reward</param>
        /// <param name="player">Principal that won the battle</param>
        /// <param name="battleInfo">Battle information object</param>

        public static void TournamentBattleTransaction(int orions, Principal player, IBattleInfo battleInfo)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                TournamentBattleTransaction(orions, player, battleInfo,persistance);
                persistance.Flush();
            }
        }

        /// <summary>
        /// Regists a tournament battle winning
        /// </summary>
        /// <param name="orions">Orions reward</param>
        /// <param name="player">Principal that won the battle</param>
        /// <param name="battleInfo">Battle information object</param>
        /// <param name="persistance">Persistance session</param>
        public static void TournamentBattleTransaction(int orions, Principal player, IBattleInfo battleInfo, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.TournamentBattle.ToString();
                transaction.IdentityTypeSpend = string.Format("{0}_{1}", battleInfo.TournamentMode, battleInfo.BattleType);
                transaction.CreditsSpend = orions;

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = player.Id;
                transaction.GainCurrentCredits = player.Credits;
                transaction.CreditsGain = orions;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        /// <summary>
        /// Regists a tournament prize winning
        /// </summary>
        /// <param name="orions">Orions reward</param>
        /// <param name="player">Principal that won the battle</param>
        /// <param name="tournament">Tournament where the prize was win</param>
        public static void TournamentPrizeTransaction(int orions, Principal player, Core.Tournament tournament)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                TournamentPrizeTransaction(orions, player, tournament, persistance);
                persistance.Flush();
            }
        }

        /// <summary>
        /// Regists a tournament prize winning
        /// </summary>
        /// <param name="orions">Orions reward</param>
        /// <param name="player">Principal that won the battle</param>
        /// <param name="tournament">Tournament where the prize was win</param>
        /// <param name="persistance">Persistance session</param>
        public static void TournamentPrizeTransaction(int orions, Principal player, Core.Tournament tournament, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.TournamentPrize.ToString();
                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();
                transaction.CreditsSpend = orions;

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = player.Id;
                transaction.GainCurrentCredits = player.Credits;
                transaction.CreditsGain = orions;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        #endregion Tournament

        #region Arena

        /// <summary>
        /// Regists an arena challenge transaction
        /// </summary>
        /// <param name="arena">Arena where the payment was made</param>
        /// <param name="challenger">Player that made the challenge</param>
        /// <param name="persistance">Persistance session</param>
        public static void ArenaChallengeTransaction(ArenaStorage arena, PlayerStorage challenger, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                ArenaPayment(persistance2, challenger, arena);
            }
        }

        /// <summary>
        /// Regists an arena challenge transaction
        /// </summary>
        /// <param name="arena">Arena where the payment was made</param>
        /// <param name="player">Player that made the challenge</param>
        public static void ArenaChallengeTransaction(ArenaStorage arena, PlayerStorage player)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                ArenaChallengeTransaction(arena, player, persistance);
                persistance.Flush();
            }
        }

        /// <summary>
        /// Regists an arena end transaction
        /// </summary>
        /// <param name="arena">Arena where the payment was made</param>
        /// <param name="persistance">Persistance session</param>
        public static void ArenaEndTransaction(ArenaStorage arena, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                ArenaReward(persistance2, arena);
            }
        }

        /// <summary>
        /// Regists an arena end transaction
        /// </summary>
        /// <param name="arena">Arena where the payment was made</param>
        public static void ArenaEndTransaction(ArenaStorage arena)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                ArenaEndTransaction(arena, persistance);
                persistance.Flush();
            }
        }

        /// <summary>
        /// Regists an arena salary
        /// </summary>
        /// <param name="arena">Arena where the payment was made</param>
        /// <param name="persistance">Persistance session</param>
        public static void ArenaSalaryTransaction(ArenaStorage arena, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.ArenaSalary.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.Arena.ToString();
                transaction.IdentifierSpend = arena.Id;
                transaction.CreditsSpend = arena.Level * 10;

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = arena.Owner.Principal.Id;
                transaction.CreditsGain = arena.Level * 10;
                transaction.GainCurrentCredits = arena.Owner.Principal.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        /// <summary>
        /// Regists an arena salary
        /// </summary>
        /// <param name="arena">Arena where the payment was made</param>
        public static void ArenaSalaryTransaction(ArenaStorage arena)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                ArenaSalaryTransaction(arena, persistance);
                persistance.Flush();
            }
        }

        #endregion Arena

        #region Regist

        /// <summary>
        /// Regists a principal registration transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="persistance">Persistance session</param>
        public static void RegistTransaction(Principal principal, int credits, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Regist.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = principal.Id;
                transaction.CreditsGain = credits;
                transaction.GainCurrentCredits = principal.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a principal registration transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        public static void RegistTransaction(Principal principal, int credits)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                RegistTransaction(principal, credits, persistance);
                persistance.Flush();
            }
        }

        #endregion Regist

        #region Quests

        /// <summary>
        /// Regists a quest transaction
        /// </summary>
        /// <param name="questName">Quest completed</param>
        /// <param name="questId">Quest identifier if have it</param>
        /// <param name="orions">Orions reward</param>
        /// <param name="player">Player that made the quest</param>
        /// <param name="persistance">Persistance session</param>
        public static void QuestTransaction(string questName, int? questId, int orions, IPlayer player, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Quest.ToString();

                //transaction.PrincipalIdSpend = buyer.Principal.Id;
                transaction.IdentityTypeSpend = questName;
                if (questId != null)
                {
                    transaction.IdentifierSpend = Convert.ToInt32(questId);
                }
                transaction.CreditsSpend = orions;
                //transaction.SpendCurrentCredits = buyer.Principal.Credits;

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = player.Principal.Id;
                transaction.GainCurrentCredits = player.Principal.Credits;
                transaction.CreditsGain = orions;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction); 
            }
        }

        /// <summary>
        /// Regists a quest transaction
        /// </summary>
        /// <param name="questName">Quest completed</param>
        /// <param name="questId">Quest identifier if have it</param>
        /// <param name="orions">Orions reward</param>
        /// <param name="player">Player that made the quest</param>
        public static void QuestTransaction(string questName, int? questId, int orions, IPlayer player)

        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                QuestTransaction(questName, questId, orions, player, persistance);
                persistance.Flush();
            }
        }


        #endregion Quests

        #region Advertising

        /// <summary>
        /// Regists a tournament battle winning
        /// </summary>
        /// <param name="orions">Orions payed</param>
        /// <param name="item">Item put in advertising</param>
        public static void AdvertiseTransaction(int orions, AuctionHouse item)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                AdvertiseTransaction(orions, item, persistance);
                persistance.Flush();
            }
        }

        /// <summary>
        /// Regists a tournament battle winning
        /// </summary>
        /// <param name="orions">Orions reward</param>
        /// <param name="orions">Orions payed</param>
        /// <param name="item">Item put in advertising</param>
        /// <param name="persistance">Persistance session</param>
        public static void AdvertiseTransaction(int orions, AuctionHouse item, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Advertise.ToString();
                transaction.PrincipalIdSpend = item.Owner.Principal.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
                transaction.IdentifierSpend = item.Owner.Id;
                transaction.CreditsSpend = orions;
                transaction.SpendCurrentCredits = item.Owner.Principal.Credits;

                transaction.IdentityTypeGain = TransactionIdentifier.Advertise.ToString();
                transaction.IdentifierGain = item.Id;
                transaction.CreditsGain = orions;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        #endregion Advertising

        #region Alliance

        /// <summary>
        /// Regists an alliance creation
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="allianceId">Alliance identifier</param>
        /// <param name="persistance">Persistance session</param>
        public static void AllianceCreationTransaction(IPlayer player, int credits, int allianceId, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.AllianceCreation.ToString();

                transaction.PrincipalIdSpend = player.Principal.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
                transaction.IdentifierSpend = player.Id;
                transaction.CreditsSpend = credits;
                transaction.SpendCurrentCredits = player.Principal.Credits;

                transaction.IdentifierGain = allianceId;
                transaction.IdentityTypeGain = TransactionIdentifier.System.ToString();
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists an alliance creation
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="allianceId">Alliance identifier</param>
        public static void AllianceCreationTransaction(IPlayer player, int credits, int allianceId)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                AllianceCreationTransaction(player, credits, allianceId, persistance);
                persistance.Flush();
            }
        }

        #endregion Alliance

        #region Referal

        /// <summary>
        /// Regists a referal transaction
        /// </summary>
        /// <param name="buyer">Principal that did a payment</param>
        /// <param name="receiver">Principal that received the prize</param>
        /// <param name="orionsPayed">Gain orions by payment</param>
        /// <param name="orionsReceived">Credits received by the referal</param>
        /// <param name="persistance">Persistance session</param>
        public static void ReferalTransaction(Principal buyer, Principal receiver, int orionsPayed, int orionsReceived, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Referal.ToString();

                transaction.PrincipalIdSpend = buyer.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = receiver.Id;
                transaction.CreditsGain = orionsReceived;
                transaction.GainCurrentCredits = receiver.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        /// <summary>
        /// Regists a referal transaction
        /// </summary>
        /// <param name="buyer">Principal that did a payment</param>
        /// <param name="receiver">Principal that received the prize</param>
        /// <param name="orionsPayed">Gain orions by payment</param>
        /// <param name="orionsReceived">Credits received by the referal</param>
        public static void ReferalTransaction(Principal buyer, Principal receiver, int orionsPayed, int orionsReceived)

        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                ReferalTransaction(buyer, receiver, orionsPayed, orionsReceived, persistance);
                persistance.Flush();
            }
        }

        /// <summary>
        /// Regists a referal transaction
        /// </summary>
        /// <param name="receiver">Principal that received the prize</param>
        /// <param name="orionsReceived">Credits received by the referal</param>
        /// <param name="persistance">Persistance session</param>
        public static void ReferalTransaction(Principal receiver, int orionsReceived, IPersistanceSession persistance)
        {
            Messenger.Add(Category.Principal, typeof(ReferralPrizeMessage), receiver.Id, orionsReceived.ToString());
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Referal.ToString();


                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = receiver.Id;
                transaction.CreditsGain = orionsReceived;
                transaction.GainCurrentCredits = receiver.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        /// <summary>
        /// Regists a referal transaction
        /// </summary>
        /// <param name="receiver">Principal that received the prize</param>
        /// <param name="orionsReceived">Credits received by the referal</param>
        public static void ReferalTransaction(Principal receiver, int orionsReceived)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                ReferalTransaction(receiver, orionsReceived, persistance);
                persistance.Flush();
            }
        }

        #endregion Referal

        #region Services

        /// <summary>
        /// Regists a service payment
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="service">Service type</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="persistance">Persistance session</param>
        public static void ServiceTransaction(IPlayer player, ServiceType service, int credits, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = service.ToString();

                transaction.PrincipalIdSpend = player.Principal.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
                transaction.IdentifierSpend = player.Id;
                transaction.CreditsSpend = credits;
                transaction.SpendCurrentCredits = player.Principal.Credits;

                transaction.IdentityTypeGain = TransactionIdentifier.System.ToString();
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a service payment
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="service">Service type</param>
        /// <param name="credits">Credits that were payed</param>
        public static void ServiceTransaction(IPlayer player, ServiceType service, int credits)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                ServiceTransaction(player, service, credits, persistance);
                persistance.Flush();
            }
        }

        #endregion Services

        #region Prize

        /// <summary>
        /// Regists a prize transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="persistance">Persistance session</param>
        public static void PrizeTransaction(Principal principal, int credits, IPersistanceSession persistance)
        {
            Messenger.Add(Category.Principal, typeof(PrizeMessage), principal.Id, credits.ToString());

            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Prize.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = principal.Id;
                transaction.CreditsGain = credits;
                transaction.GainCurrentCredits = principal.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a payment transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        public static void PrizeTransaction(Principal principal, int credits)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                PrizeTransaction(principal, credits, persistance);
                persistance.Flush();
            }
        }

        #endregion Prize

        #region Bounties

        public static void CreateBountyTransaction(Principal principal, IPlayer target, int credits)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                CreateBountyTransaction(principal, target, credits, persistance);
                persistance.Flush();
            }
        }

        public static void CreateBountyTransaction(Principal principal, IPlayer target, int credits, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.CreateBounty.ToString();

                transaction.PrincipalIdSpend = principal.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
                transaction.IdentifierSpend = target.Id;
                transaction.CreditsSpend = credits;
                transaction.SpendCurrentCredits = principal.Credits;

                transaction.IdentityTypeGain = TransactionIdentifier.System.ToString();
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        public static void GiveBountyRewardTransaction(Principal principal, int credits, string targetName)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                GiveBountyRewardTransaction(principal, credits, targetName, persistance);
                persistance.Flush();
            }
        }

        public static void GiveBountyRewardTransaction(Principal principal, int credits, string targetName, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.BountyReward.ToString();

                transaction.IdentityTypeSpend = targetName;               
                transaction.CreditsSpend = credits;

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = principal.Id;
                transaction.GainCurrentCredits = principal.Credits;
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        #endregion Bounties

        #region Academy

        /// <summary>
        /// Regists an auction house transaction
        /// </summary>
        /// <param name="buyer">Player</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="target">player searched</param>
        public static void AcademyTransaction(IPlayer buyer, int credits, int target)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                AcademyTransaction(buyer, credits, target, persistance);
                persistance.Flush();
            }
        }

        public static void AcademyTransaction(IPlayer buyer, int credits, int target, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Academy.ToString();

                transaction.PrincipalIdSpend = buyer.Principal.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
                transaction.IdentifierSpend = buyer.Id;
                transaction.CreditsSpend = credits;
                transaction.SpendCurrentCredits = buyer.Principal.Credits;

                transaction.IdentityTypeGain = target.ToString();
                transaction.IdentifierGain = 0;
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        #endregion Academy

        #region Pirate Bay

        /// <summary>
        /// Regists an Pirate Bay transaction
        /// </summary>
        /// <param name="buyer">Player</param>
        /// <param name="credits">Credits that were payed</param>
        /// <param name="target">player searched</param>
        public static void PirateBayTransaction(IPlayer buyer, int credits, string target)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                PirateBayTransaction(buyer, credits, target, persistance);
                persistance.Flush();
            }
        }

        public static void PirateBayTransaction(IPlayer buyer, int credits, string target, IPersistanceSession persistance)
        {
            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.PirateBay.ToString();

                transaction.PrincipalIdSpend = buyer.Principal.Id;
                transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
                transaction.IdentifierSpend = buyer.Id;
                transaction.CreditsSpend = credits;
                transaction.SpendCurrentCredits = buyer.Principal.Credits;

                transaction.IdentityTypeGain = target.ToString();
                transaction.IdentifierGain = 0;
                transaction.CreditsGain = credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }
        }

        #endregion Pirate Bay

        #region Voting

        /// <summary>
        /// Regists a voting transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="persistance">Persistance session</param>
        public static void VotingTransaction(Principal principal, int credits, IPersistanceSession persistance)
        {
            Messenger.Add(Category.Principal, typeof(PrizeMessage), principal.Id, credits.ToString());

            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.VotingPrize.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = principal.Id;
                transaction.CreditsGain = credits;
                transaction.GainCurrentCredits = principal.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        public static void QuickReferralTransaction(Principal principal, int credits, IPersistanceSession persistance)
        {
            Messenger.Add(Category.Principal, typeof(PrizeMessage), principal.Id, credits.ToString());

            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.QuickReferral.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = principal.Id;
                transaction.CreditsGain = credits;
                transaction.GainCurrentCredits = principal.Credits;

                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a voting transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        public static void VotingTransaction(Principal principal, int credits)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                VotingTransaction(principal, credits, persistance);
                persistance.Flush();
            }
        }

        #endregion Voting

        #region Bonus Card

        /// <summary>
        /// Regists a prize transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="card">BonusCard identifier</param>
        /// <param name="persistance">Persistance session</param>
        public static void BonusCardTransaction(Principal principal, int credits, BonusCard card, IPersistanceSession persistance)
        {
            Messenger.Add(Category.Principal, typeof(BonusCodeMessage), principal.Id, credits.ToString(),card.Type);

            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.BonusCode.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = principal.Id;
                transaction.CreditsGain = credits;
                transaction.GainCurrentCredits = principal.Credits;
                transaction.IdentifierSpend = card.Id;
                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a payment transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="card">BonusCard identifier</param>
        public static void BonusCardTransaction(Principal principal, int credits, BonusCard card)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                BonusCardTransaction(principal, credits, card, persistance);
                persistance.Flush();
            }
        }

        #endregion Bonus Card

        #region Promotion

        /// <summary>
        /// Regists a prize transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="card">BonusCard identifier</param>
        /// <param name="persistance">Persistance session</param>
        public static void PromotionTransaction(Principal principal, int credits, Promotion card, IPersistanceSession persistance)
        {
            Messenger.Add(Category.Principal, typeof(PromotionMessage), principal.Id, credits.ToString(), card.Name);

            using (ITransactionPersistance persistance2 = Persistance.Instance.GetTransactionPersistance(persistance))
            {
                Transaction transaction = persistance2.Create();
                transaction.TransactionContext = TransactionContext.Promotion.ToString();

                transaction.IdentityTypeSpend = TransactionIdentifier.System.ToString();

                transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
                transaction.IdentifierGain = principal.Id;
                transaction.CreditsGain = credits;
                transaction.GainCurrentCredits = principal.Credits;
                transaction.IdentifierSpend = card.Id;
                transaction.Tick = Clock.Instance.Tick;
                persistance2.Update(transaction);
            }

        }

        /// <summary>
        /// Regists a payment transaction
        /// </summary>
        /// <param name="principal">Principal that will receive the credits</param>
        /// <param name="credits">Credits to be added</param>
        /// <param name="card">BonusCard identifier</param>
        public static void PromotionTransaction(Principal principal, int credits, Promotion card)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                PromotionTransaction(principal, credits, card, persistance);
                persistance.Flush();
            }
        }

        #endregion Promotion

        #endregion Public Methods

        #region Private Methods

        private static void ArenaPayment(IPersistance<Transaction> persistance2, PlayerStorage challenger, ArenaStorage arena)
        {
            Transaction transaction = persistance2.Create();
            transaction.TransactionContext = TransactionContext.Arena.ToString();

            transaction.PrincipalIdSpend = challenger.Principal.Id;
            transaction.IdentityTypeSpend = TransactionIdentifier.Player.ToString();
            transaction.IdentifierSpend = challenger.Id;
            transaction.CreditsSpend = arena.Payment;
            transaction.SpendCurrentCredits = challenger.Principal.Credits;

            transaction.IdentityTypeGain = TransactionIdentifier.Arena.ToString();
            transaction.IdentifierGain = arena.Id;
            transaction.CreditsGain = arena.Payment;

            transaction.Tick = Clock.Instance.Tick;
            persistance2.Update(transaction);
        }

        private static void ArenaReward(IPersistance<Transaction> persistance2, ArenaStorage arena)
        {
            Transaction transaction = persistance2.Create();
            transaction.TransactionContext = TransactionContext.Arena.ToString();

            transaction.IdentityTypeSpend = TransactionIdentifier.Arena.ToString();
            transaction.IdentifierSpend = arena.Id;
            transaction.CreditsSpend = arena.Payment / 2;

            transaction.IdentityTypeGain = TransactionIdentifier.Principal.ToString();
            transaction.IdentifierGain = arena.Owner.Principal.Id;
            transaction.CreditsGain = arena.Payment / 2;
            transaction.GainCurrentCredits = arena.Owner.Principal.Credits;

            transaction.Tick = Clock.Instance.Tick;
            persistance2.Update(transaction);
        }

        private static void PrincipalTournamentFillInfo(Transaction transaction, Principal principal, Core.Tournament tournament)
        {
            transaction.TransactionContext = TransactionContext.Tournament.ToString();

            transaction.PrincipalIdSpend = principal.Id;
            transaction.IdentityTypeSpend = TransactionIdentifier.Principal.ToString();
            transaction.IdentifierSpend = principal.Id;
            transaction.CreditsSpend = tournament.CostCredits;
            transaction.SpendCurrentCredits = principal.Credits;

            transaction.IdentityTypeGain = TransactionIdentifier.Tournament.ToString();
            transaction.IdentifierGain = tournament.Id;
            transaction.CreditsGain = tournament.CostCredits;

            transaction.Tick = Clock.Instance.Tick;
        }


        #endregion Private Methods


    }
}
