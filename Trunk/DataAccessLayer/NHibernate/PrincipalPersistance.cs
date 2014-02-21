using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PrincipalPersistance : 
			NHibernatePersistance<Principal>, IPrincipalPersistance {
	
		#region Static Access
		
		internal static PrincipalPersistance CreateSession()
		{
			return new PrincipalPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPrincipal) );
		}
				
		internal static PrincipalPersistance AttachSession( IPersistanceSession owner )
		{
			PrincipalPersistance persistance = new PrincipalPersistance ( owner.Session as ISession, typeof(SpecializedPrincipal) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PrincipalPersistance globalSession = null;
        internal static PrincipalPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PrincipalPersistance GetSession()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			
			if (context == null) {
                return CreateSession();
            }

			if( context.Items == null ) {
				return CreateSession();
			}

            object persistance = context.Items["Persistance"];
			NHibernatePersistance<Principal> session = null;
			
			if( persistance != null ) {
				session = (NHibernatePersistance<Principal>) persistance;
			} else {
                session = PrincipalPersistance.CreateSession();
				context.Items["Persistance"] = session;
			}
			
			ISession nhSession = session.Session as ISession;
            if (nhSession != null && !NHibernateUtilities.IsSessionOpen(nhSession) ) {
				nhSession.Dispose();
                session.NHibernateSession = NHibernateUtilities.OpenSession;
            }
			
			return AttachSession( session );
		}
		
		internal static PrincipalPersistance GetValidatedSession()
        {
            PrincipalPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PrincipalPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Principal Create()
		{	
			SpecializedPrincipal entity = new SpecializedPrincipal ();
            entity.NHibernateSession = NHibernateSession;
            return entity;
		}

		/// <summary>
        /// Adds logic validation to the entities
        /// </summary>
        public override void AddValidators()
        {
			AddValidation(this);
        }
        
		#endregion IPersistance
		
		#region ExtendedMethods		
		
 		public IList<Principal> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Id = '{0}'", id);
		}

		public IList<Principal> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByIsBot ( bool isBot )
		{
			return SelectByIsBot (-1, -1, isBot );
		}
		
		public long CountByIsBot ( bool isBot )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.IsBot = '{0}'", isBot);
		}

		public IList<Principal> SelectByIsBot ( int start, int count, bool isBot )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.IsBot = {0}", isBot);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByMyStatsId ( int myStatsId )
		{
			return SelectByMyStatsId (-1, -1, myStatsId );
		}
		
		public long CountByMyStatsId ( int myStatsId )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.MyStatsId = '{0}'", myStatsId);
		}

		public IList<Principal> SelectByMyStatsId ( int start, int count, int myStatsId )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.MyStatsId = {0}", myStatsId);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByEloRanking ( int eloRanking )
		{
			return SelectByEloRanking (-1, -1, eloRanking );
		}
		
		public long CountByEloRanking ( int eloRanking )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.EloRanking = '{0}'", eloRanking);
		}

		public IList<Principal> SelectByEloRanking ( int start, int count, int eloRanking )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.EloRanking = {0}", eloRanking);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByReceiveMail ( bool receiveMail )
		{
			return SelectByReceiveMail (-1, -1, receiveMail );
		}
		
		public long CountByReceiveMail ( bool receiveMail )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.ReceiveMail = '{0}'", receiveMail);
		}

		public IList<Principal> SelectByReceiveMail ( int start, int count, bool receiveMail )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.ReceiveMail = {0}", receiveMail);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByCredits ( int credits )
		{
			return SelectByCredits (-1, -1, credits );
		}
		
		public long CountByCredits ( int credits )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Credits = '{0}'", credits);
		}

		public IList<Principal> SelectByCredits ( int start, int count, int credits )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Credits = {0}", credits);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByLadderActive ( bool ladderActive )
		{
			return SelectByLadderActive (-1, -1, ladderActive );
		}
		
		public long CountByLadderActive ( bool ladderActive )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.LadderActive = '{0}'", ladderActive);
		}

		public IList<Principal> SelectByLadderActive ( int start, int count, bool ladderActive )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.LadderActive = {0}", ladderActive);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByLadderPosition ( int ladderPosition )
		{
			return SelectByLadderPosition (-1, -1, ladderPosition );
		}
		
		public long CountByLadderPosition ( int ladderPosition )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.LadderPosition = '{0}'", ladderPosition);
		}

		public IList<Principal> SelectByLadderPosition ( int start, int count, int ladderPosition )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.LadderPosition = {0}", ladderPosition);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByIsInBattle ( int isInBattle )
		{
			return SelectByIsInBattle (-1, -1, isInBattle );
		}
		
		public long CountByIsInBattle ( int isInBattle )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.IsInBattle = '{0}'", isInBattle);
		}

		public IList<Principal> SelectByIsInBattle ( int start, int count, int isInBattle )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.IsInBattle = {0}", isInBattle);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByRestUntil ( int restUntil )
		{
			return SelectByRestUntil (-1, -1, restUntil );
		}
		
		public long CountByRestUntil ( int restUntil )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.RestUntil = '{0}'", restUntil);
		}

		public IList<Principal> SelectByRestUntil ( int start, int count, int restUntil )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.RestUntil = {0}", restUntil);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByStoppedUntil ( int stoppedUntil )
		{
			return SelectByStoppedUntil (-1, -1, stoppedUntil );
		}
		
		public long CountByStoppedUntil ( int stoppedUntil )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.StoppedUntil = '{0}'", stoppedUntil);
		}

		public IList<Principal> SelectByStoppedUntil ( int start, int count, int stoppedUntil )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.StoppedUntil = {0}", stoppedUntil);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByAvailableVacationTicks ( int availableVacationTicks )
		{
			return SelectByAvailableVacationTicks (-1, -1, availableVacationTicks );
		}
		
		public long CountByAvailableVacationTicks ( int availableVacationTicks )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.AvailableVacationTicks = '{0}'", availableVacationTicks);
		}

		public IList<Principal> SelectByAvailableVacationTicks ( int start, int count, int availableVacationTicks )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.AvailableVacationTicks = {0}", availableVacationTicks);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByVacationStartTick ( int vacationStartTick )
		{
			return SelectByVacationStartTick (-1, -1, vacationStartTick );
		}
		
		public long CountByVacationStartTick ( int vacationStartTick )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.VacationStartTick = '{0}'", vacationStartTick);
		}

		public IList<Principal> SelectByVacationStartTick ( int start, int count, int vacationStartTick )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.VacationStartTick = {0}", vacationStartTick);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByVacationEndtick ( int vacationEndtick )
		{
			return SelectByVacationEndtick (-1, -1, vacationEndtick );
		}
		
		public long CountByVacationEndtick ( int vacationEndtick )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.VacationEndtick = '{0}'", vacationEndtick);
		}

		public IList<Principal> SelectByVacationEndtick ( int start, int count, int vacationEndtick )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.VacationEndtick = {0}", vacationEndtick);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByAutoStartVacations ( bool autoStartVacations )
		{
			return SelectByAutoStartVacations (-1, -1, autoStartVacations );
		}
		
		public long CountByAutoStartVacations ( bool autoStartVacations )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.AutoStartVacations = '{0}'", autoStartVacations);
		}

		public IList<Principal> SelectByAutoStartVacations ( int start, int count, bool autoStartVacations )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.AutoStartVacations = {0}", autoStartVacations);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByReferrerId ( int referrerId )
		{
			return SelectByReferrerId (-1, -1, referrerId );
		}
		
		public long CountByReferrerId ( int referrerId )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.ReferrerId = '{0}'", referrerId);
		}

		public IList<Principal> SelectByReferrerId ( int start, int count, int referrerId )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.ReferrerId = {0}", referrerId);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByCanChangeName ( bool canChangeName )
		{
			return SelectByCanChangeName (-1, -1, canChangeName );
		}
		
		public long CountByCanChangeName ( bool canChangeName )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.CanChangeName = '{0}'", canChangeName);
		}

		public IList<Principal> SelectByCanChangeName ( int start, int count, bool canChangeName )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.CanChangeName = {0}", canChangeName);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByAvatar ( string avatar )
		{
			return SelectByAvatar (-1, -1, avatar );
		}
		
		public long CountByAvatar ( string avatar )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Avatar = '{0}'", avatar);
		}

		public IList<Principal> SelectByAvatar ( int start, int count, string avatar )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Avatar like '{0}'", avatar);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByWebSite ( string webSite )
		{
			return SelectByWebSite (-1, -1, webSite );
		}
		
		public long CountByWebSite ( string webSite )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.WebSite = '{0}'", webSite);
		}

		public IList<Principal> SelectByWebSite ( int start, int count, string webSite )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.WebSite like '{0}'", webSite);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByTutorialState ( int tutorialState )
		{
			return SelectByTutorialState (-1, -1, tutorialState );
		}
		
		public long CountByTutorialState ( int tutorialState )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.TutorialState = '{0}'", tutorialState);
		}

		public IList<Principal> SelectByTutorialState ( int start, int count, int tutorialState )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.TutorialState = {0}", tutorialState);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByDuplicatedIds ( string duplicatedIds )
		{
			return SelectByDuplicatedIds (-1, -1, duplicatedIds );
		}
		
		public long CountByDuplicatedIds ( string duplicatedIds )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.DuplicatedIds = '{0}'", duplicatedIds);
		}

		public IList<Principal> SelectByDuplicatedIds ( int start, int count, string duplicatedIds )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.DuplicatedIds like '{0}'", duplicatedIds);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByNumberOfWarnings ( int numberOfWarnings )
		{
			return SelectByNumberOfWarnings (-1, -1, numberOfWarnings );
		}
		
		public long CountByNumberOfWarnings ( int numberOfWarnings )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.NumberOfWarnings = '{0}'", numberOfWarnings);
		}

		public IList<Principal> SelectByNumberOfWarnings ( int start, int count, int numberOfWarnings )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.NumberOfWarnings = {0}", numberOfWarnings);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByAcceptedTerms ( bool acceptedTerms )
		{
			return SelectByAcceptedTerms (-1, -1, acceptedTerms );
		}
		
		public long CountByAcceptedTerms ( bool acceptedTerms )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.AcceptedTerms = '{0}'", acceptedTerms);
		}

		public IList<Principal> SelectByAcceptedTerms ( int start, int count, bool acceptedTerms )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.AcceptedTerms = {0}", acceptedTerms);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByWarningPoints ( int warningPoints )
		{
			return SelectByWarningPoints (-1, -1, warningPoints );
		}
		
		public long CountByWarningPoints ( int warningPoints )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.WarningPoints = '{0}'", warningPoints);
		}

		public IList<Principal> SelectByWarningPoints ( int start, int count, int warningPoints )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.WarningPoints = {0}", warningPoints);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByLastWarningDate ( DateTime lastWarningDate )
		{
			return SelectByLastWarningDate (-1, -1, lastWarningDate );
		}
		
		public long CountByLastWarningDate ( DateTime lastWarningDate )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.LastWarningDate = '{0}'", lastWarningDate);
		}

		public IList<Principal> SelectByLastWarningDate ( int start, int count, DateTime lastWarningDate )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Principal> SelectByBotUrl ( string botUrl )
		{
			return SelectByBotUrl (-1, -1, botUrl );
		}
		
		public long CountByBotUrl ( string botUrl )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.BotUrl = '{0}'", botUrl);
		}

		public IList<Principal> SelectByBotUrl ( int start, int count, string botUrl )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.BotUrl like '{0}'", botUrl);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByReferrerPriceCount ( int referrerPriceCount )
		{
			return SelectByReferrerPriceCount (-1, -1, referrerPriceCount );
		}
		
		public long CountByReferrerPriceCount ( int referrerPriceCount )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.ReferrerPriceCount = '{0}'", referrerPriceCount);
		}

		public IList<Principal> SelectByReferrerPriceCount ( int start, int count, int referrerPriceCount )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.ReferrerPriceCount = {0}", referrerPriceCount);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByIsOnVacations ( bool isOnVacations )
		{
			return SelectByIsOnVacations (-1, -1, isOnVacations );
		}
		
		public long CountByIsOnVacations ( bool isOnVacations )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.IsOnVacations = '{0}'", isOnVacations);
		}

		public IList<Principal> SelectByIsOnVacations ( int start, int count, bool isOnVacations )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.IsOnVacations = {0}", isOnVacations);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByTeam ( TeamStorage team )
		{
			return SelectByTeam (-1, -1, team );
		}
		
		public long CountByTeam ( TeamStorage team )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Team = '{0}'", team);
		}

		public IList<Principal> SelectByTeam ( int start, int count, TeamStorage team )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.TeamNHibernate.Id = {0}", team.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Name = '{0}'", name);
		}

		public IList<Principal> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByPassword ( string password )
		{
			return SelectByPassword (-1, -1, password );
		}
		
		public long CountByPassword ( string password )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Password = '{0}'", password);
		}

		public IList<Principal> SelectByPassword ( int start, int count, string password )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Password like '{0}'", password);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByEmail ( string email )
		{
			return SelectByEmail (-1, -1, email );
		}
		
		public long CountByEmail ( string email )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Email = '{0}'", email);
		}

		public IList<Principal> SelectByEmail ( int start, int count, string email )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Email like '{0}'", email);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByIp ( string ip )
		{
			return SelectByIp (-1, -1, ip );
		}
		
		public long CountByIp ( string ip )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Ip = '{0}'", ip);
		}

		public IList<Principal> SelectByIp ( int start, int count, string ip )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Ip like '{0}'", ip);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByRegistDate ( DateTime registDate )
		{
			return SelectByRegistDate (-1, -1, registDate );
		}
		
		public long CountByRegistDate ( DateTime registDate )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.RegistDate = '{0}'", registDate);
		}

		public IList<Principal> SelectByRegistDate ( int start, int count, DateTime registDate )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Principal> SelectByLastLogin ( DateTime lastLogin )
		{
			return SelectByLastLogin (-1, -1, lastLogin );
		}
		
		public long CountByLastLogin ( DateTime lastLogin )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.LastLogin = '{0}'", lastLogin);
		}

		public IList<Principal> SelectByLastLogin ( int start, int count, DateTime lastLogin )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Principal> SelectByApproved ( bool approved )
		{
			return SelectByApproved (-1, -1, approved );
		}
		
		public long CountByApproved ( bool approved )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Approved = '{0}'", approved);
		}

		public IList<Principal> SelectByApproved ( int start, int count, bool approved )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Approved = {0}", approved);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByIsOnline ( bool isOnline )
		{
			return SelectByIsOnline (-1, -1, isOnline );
		}
		
		public long CountByIsOnline ( bool isOnline )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.IsOnline = '{0}'", isOnline);
		}

		public IList<Principal> SelectByIsOnline ( int start, int count, bool isOnline )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.IsOnline = {0}", isOnline);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByLocked ( bool locked )
		{
			return SelectByLocked (-1, -1, locked );
		}
		
		public long CountByLocked ( bool locked )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Locked = '{0}'", locked);
		}

		public IList<Principal> SelectByLocked ( int start, int count, bool locked )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Locked = {0}", locked);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByLocale ( string locale )
		{
			return SelectByLocale (-1, -1, locale );
		}
		
		public long CountByLocale ( string locale )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Locale = '{0}'", locale);
		}

		public IList<Principal> SelectByLocale ( int start, int count, string locale )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Locale like '{0}'", locale);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByConfirmationCode ( string confirmationCode )
		{
			return SelectByConfirmationCode (-1, -1, confirmationCode );
		}
		
		public long CountByConfirmationCode ( string confirmationCode )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.ConfirmationCode = '{0}'", confirmationCode);
		}

		public IList<Principal> SelectByConfirmationCode ( int start, int count, string confirmationCode )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.ConfirmationCode like '{0}'", confirmationCode);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByRawRoles ( string rawRoles )
		{
			return SelectByRawRoles (-1, -1, rawRoles );
		}
		
		public long CountByRawRoles ( string rawRoles )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.RawRoles = '{0}'", rawRoles);
		}

		public IList<Principal> SelectByRawRoles ( int start, int count, string rawRoles )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.RawRoles like '{0}'", rawRoles);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Principal
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfPassword );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfEmail );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfRegistDate );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfLastLogin );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfApproved );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfLocale );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfConfirmationCode );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfAvatar );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfWebSite );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDuplicatedIds );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBotUrl );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfPassword );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfEmail );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfIp );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfLocale );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfConfirmationCode );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfRawRoles );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateUniquenessOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateUniquenessOfEmail );
        }
		public static LifecyleVeto ValidateExistenceOfName ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.Name ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Name'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfPassword ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.Password ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Password'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfEmail ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.Email ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Email'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfRegistDate ( Principal e ) 
        {
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfLastLogin ( Principal e ) 
        {
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfApproved ( Principal e ) 
        {
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfLocale ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.Locale ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Locale'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfConfirmationCode ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.ConfirmationCode ) ) {
				throw new DALException("Entity `{0}' must have a value for property `ConfirmationCode'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateMaxSizeOfAvatar ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Avatar", e.Avatar, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfWebSite ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "WebSite", e.WebSite, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfDuplicatedIds ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "DuplicatedIds", e.DuplicatedIds, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfBotUrl ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "BotUrl", e.BotUrl, 5000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfName ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Name", e.Name, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfPassword ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Password", e.Password, 50 );
		}
		public static LifecyleVeto ValidateMaxSizeOfEmail ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Email", e.Email, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfIp ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Ip", e.Ip, 15 );
		}
		public static LifecyleVeto ValidateMaxSizeOfLocale ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Locale", e.Locale, 6 );
		}
		public static LifecyleVeto ValidateMaxSizeOfConfirmationCode ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "ConfirmationCode", e.ConfirmationCode, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfRawRoles ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "RawRoles", e.RawRoles, 250 );
		}
		public static LifecyleVeto ValidateUniquenessOfName ( Principal e ) 
        {
			PrincipalPersistance persistance = GetSession();
			if( persistance.SelectByName ( e.Name ).Count == 0 ) {
				return LifecyleVeto.Continue;
			}
			throw new DALException("There's already and entity `{0}' with property `Name' with the value `{1}' on the database (this property is marked as unique)", e.TypeName, e.Name);
		}
		public static LifecyleVeto ValidateUniquenessOfEmail ( Principal e ) 
        {
			PrincipalPersistance persistance = GetSession();
			if( persistance.SelectByEmail ( e.Email ).Count == 0 ) {
				return LifecyleVeto.Continue;
			}
			throw new DALException("There's already and entity `{0}' with property `Email' with the value `{1}' on the database (this property is marked as unique)", e.TypeName, e.Email);
		}

		public static LifecyleVeto ValidateStringMaxSize( string entityName, string propertyName, string val, int maxSize ) 
        {
			if( string.IsNullOrEmpty( val ) ) {
				return LifecyleVeto.Continue;
			}
			
			if( val.Length > maxSize ) {
				throw new DALException("The `{4}' property of `{0}' has too many chars (max: {1}, found:{2}, text:{3})", entityName, maxSize, val.Length, val, propertyName);
			}
			
			return LifecyleVeto.Continue;
		}

		#endregion Validation
		
	};
}
