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
    /// Memory persistance for entity.Name
    /// </summary>
	internal class MemoryPrincipalPersistance : 
			MemoryPersistance<Principal>, IPrincipalPersistance {
		
		#region IPersistance
		
		public override Principal Create()
		{
			return new SpecializedMemoryPrincipal ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Principal> SelectById ( int id )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountById ( int id )
		{
			return (long) SelectById ( id ).Count;
		}

		public IList<Principal> SelectById ( int start, int count, int id )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByIsBot ( bool isBot )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsBot == isBot ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsBot ( bool isBot )
		{
			return (long) SelectByIsBot ( isBot ).Count;
		}

		public IList<Principal> SelectByIsBot ( int start, int count, bool isBot )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsBot == isBot ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByMyStatsId ( int myStatsId )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.MyStatsId == myStatsId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMyStatsId ( int myStatsId )
		{
			return (long) SelectByMyStatsId ( myStatsId ).Count;
		}

		public IList<Principal> SelectByMyStatsId ( int start, int count, int myStatsId )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.MyStatsId == myStatsId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByEloRanking ( int eloRanking )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.EloRanking == eloRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEloRanking ( int eloRanking )
		{
			return (long) SelectByEloRanking ( eloRanking ).Count;
		}

		public IList<Principal> SelectByEloRanking ( int start, int count, int eloRanking )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.EloRanking == eloRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByReceiveMail ( bool receiveMail )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ReceiveMail == receiveMail ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByReceiveMail ( bool receiveMail )
		{
			return (long) SelectByReceiveMail ( receiveMail ).Count;
		}

		public IList<Principal> SelectByReceiveMail ( int start, int count, bool receiveMail )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ReceiveMail == receiveMail ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByCredits ( int credits )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Credits == credits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCredits ( int credits )
		{
			return (long) SelectByCredits ( credits ).Count;
		}

		public IList<Principal> SelectByCredits ( int start, int count, int credits )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Credits == credits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLadderActive ( bool ladderActive )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LadderActive == ladderActive ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLadderActive ( bool ladderActive )
		{
			return (long) SelectByLadderActive ( ladderActive ).Count;
		}

		public IList<Principal> SelectByLadderActive ( int start, int count, bool ladderActive )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LadderActive == ladderActive ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLadderPosition ( int ladderPosition )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LadderPosition == ladderPosition ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLadderPosition ( int ladderPosition )
		{
			return (long) SelectByLadderPosition ( ladderPosition ).Count;
		}

		public IList<Principal> SelectByLadderPosition ( int start, int count, int ladderPosition )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LadderPosition == ladderPosition ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByIsInBattle ( int isInBattle )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsInBattle ( int isInBattle )
		{
			return (long) SelectByIsInBattle ( isInBattle ).Count;
		}

		public IList<Principal> SelectByIsInBattle ( int start, int count, int isInBattle )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByRestUntil ( int restUntil )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RestUntil == restUntil ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRestUntil ( int restUntil )
		{
			return (long) SelectByRestUntil ( restUntil ).Count;
		}

		public IList<Principal> SelectByRestUntil ( int start, int count, int restUntil )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RestUntil == restUntil ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByStoppedUntil ( int stoppedUntil )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.StoppedUntil == stoppedUntil ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStoppedUntil ( int stoppedUntil )
		{
			return (long) SelectByStoppedUntil ( stoppedUntil ).Count;
		}

		public IList<Principal> SelectByStoppedUntil ( int start, int count, int stoppedUntil )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.StoppedUntil == stoppedUntil ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByAvailableVacationTicks ( int availableVacationTicks )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.AvailableVacationTicks == availableVacationTicks ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAvailableVacationTicks ( int availableVacationTicks )
		{
			return (long) SelectByAvailableVacationTicks ( availableVacationTicks ).Count;
		}

		public IList<Principal> SelectByAvailableVacationTicks ( int start, int count, int availableVacationTicks )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.AvailableVacationTicks == availableVacationTicks ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByVacationStartTick ( int vacationStartTick )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.VacationStartTick == vacationStartTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByVacationStartTick ( int vacationStartTick )
		{
			return (long) SelectByVacationStartTick ( vacationStartTick ).Count;
		}

		public IList<Principal> SelectByVacationStartTick ( int start, int count, int vacationStartTick )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.VacationStartTick == vacationStartTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByVacationEndtick ( int vacationEndtick )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.VacationEndtick == vacationEndtick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByVacationEndtick ( int vacationEndtick )
		{
			return (long) SelectByVacationEndtick ( vacationEndtick ).Count;
		}

		public IList<Principal> SelectByVacationEndtick ( int start, int count, int vacationEndtick )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.VacationEndtick == vacationEndtick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByAutoStartVacations ( bool autoStartVacations )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.AutoStartVacations == autoStartVacations ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAutoStartVacations ( bool autoStartVacations )
		{
			return (long) SelectByAutoStartVacations ( autoStartVacations ).Count;
		}

		public IList<Principal> SelectByAutoStartVacations ( int start, int count, bool autoStartVacations )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.AutoStartVacations == autoStartVacations ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByReferrerId ( int referrerId )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ReferrerId == referrerId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByReferrerId ( int referrerId )
		{
			return (long) SelectByReferrerId ( referrerId ).Count;
		}

		public IList<Principal> SelectByReferrerId ( int start, int count, int referrerId )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ReferrerId == referrerId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByCanChangeName ( bool canChangeName )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.CanChangeName == canChangeName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCanChangeName ( bool canChangeName )
		{
			return (long) SelectByCanChangeName ( canChangeName ).Count;
		}

		public IList<Principal> SelectByCanChangeName ( int start, int count, bool canChangeName )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.CanChangeName == canChangeName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByAvatar ( string avatar )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Avatar == avatar ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAvatar ( string avatar )
		{
			return (long) SelectByAvatar ( avatar ).Count;
		}

		public IList<Principal> SelectByAvatar ( int start, int count, string avatar )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Avatar == avatar ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByWebSite ( string webSite )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.WebSite == webSite ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWebSite ( string webSite )
		{
			return (long) SelectByWebSite ( webSite ).Count;
		}

		public IList<Principal> SelectByWebSite ( int start, int count, string webSite )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.WebSite == webSite ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByTutorialState ( int tutorialState )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.TutorialState == tutorialState ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTutorialState ( int tutorialState )
		{
			return (long) SelectByTutorialState ( tutorialState ).Count;
		}

		public IList<Principal> SelectByTutorialState ( int start, int count, int tutorialState )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.TutorialState == tutorialState ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByDuplicatedIds ( string duplicatedIds )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.DuplicatedIds == duplicatedIds ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDuplicatedIds ( string duplicatedIds )
		{
			return (long) SelectByDuplicatedIds ( duplicatedIds ).Count;
		}

		public IList<Principal> SelectByDuplicatedIds ( int start, int count, string duplicatedIds )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.DuplicatedIds == duplicatedIds ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByNumberOfWarnings ( int numberOfWarnings )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.NumberOfWarnings == numberOfWarnings ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberOfWarnings ( int numberOfWarnings )
		{
			return (long) SelectByNumberOfWarnings ( numberOfWarnings ).Count;
		}

		public IList<Principal> SelectByNumberOfWarnings ( int start, int count, int numberOfWarnings )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.NumberOfWarnings == numberOfWarnings ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByAcceptedTerms ( bool acceptedTerms )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.AcceptedTerms == acceptedTerms ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAcceptedTerms ( bool acceptedTerms )
		{
			return (long) SelectByAcceptedTerms ( acceptedTerms ).Count;
		}

		public IList<Principal> SelectByAcceptedTerms ( int start, int count, bool acceptedTerms )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.AcceptedTerms == acceptedTerms ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByWarningPoints ( int warningPoints )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.WarningPoints == warningPoints ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWarningPoints ( int warningPoints )
		{
			return (long) SelectByWarningPoints ( warningPoints ).Count;
		}

		public IList<Principal> SelectByWarningPoints ( int start, int count, int warningPoints )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.WarningPoints == warningPoints ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLastWarningDate ( DateTime lastWarningDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastWarningDate == lastWarningDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastWarningDate ( DateTime lastWarningDate )
		{
			return (long) SelectByLastWarningDate ( lastWarningDate ).Count;
		}

		public IList<Principal> SelectByLastWarningDate ( int start, int count, DateTime lastWarningDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastWarningDate == lastWarningDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByBotUrl ( string botUrl )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.BotUrl == botUrl ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBotUrl ( string botUrl )
		{
			return (long) SelectByBotUrl ( botUrl ).Count;
		}

		public IList<Principal> SelectByBotUrl ( int start, int count, string botUrl )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.BotUrl == botUrl ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByReferrerPriceCount ( int referrerPriceCount )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ReferrerPriceCount == referrerPriceCount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByReferrerPriceCount ( int referrerPriceCount )
		{
			return (long) SelectByReferrerPriceCount ( referrerPriceCount ).Count;
		}

		public IList<Principal> SelectByReferrerPriceCount ( int start, int count, int referrerPriceCount )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ReferrerPriceCount == referrerPriceCount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByIsOnVacations ( bool isOnVacations )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsOnVacations == isOnVacations ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsOnVacations ( bool isOnVacations )
		{
			return (long) SelectByIsOnVacations ( isOnVacations ).Count;
		}

		public IList<Principal> SelectByIsOnVacations ( int start, int count, bool isOnVacations )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsOnVacations == isOnVacations ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByTeam ( TeamStorage team )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Team == team ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTeam ( TeamStorage team )
		{
			return (long) SelectByTeam ( team ).Count;
		}

		public IList<Principal> SelectByTeam ( int start, int count, TeamStorage team )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Team == team ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByName ( string name )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByName ( string name )
		{
			return (long) SelectByName ( name ).Count;
		}

		public IList<Principal> SelectByName ( int start, int count, string name )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByPassword ( string password )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Password == password ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPassword ( string password )
		{
			return (long) SelectByPassword ( password ).Count;
		}

		public IList<Principal> SelectByPassword ( int start, int count, string password )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Password == password ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByEmail ( string email )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Email == email ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEmail ( string email )
		{
			return (long) SelectByEmail ( email ).Count;
		}

		public IList<Principal> SelectByEmail ( int start, int count, string email )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Email == email ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByIp ( string ip )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Ip == ip ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIp ( string ip )
		{
			return (long) SelectByIp ( ip ).Count;
		}

		public IList<Principal> SelectByIp ( int start, int count, string ip )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Ip == ip ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByRegistDate ( DateTime registDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RegistDate == registDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRegistDate ( DateTime registDate )
		{
			return (long) SelectByRegistDate ( registDate ).Count;
		}

		public IList<Principal> SelectByRegistDate ( int start, int count, DateTime registDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RegistDate == registDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLastLogin ( DateTime lastLogin )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastLogin == lastLogin ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastLogin ( DateTime lastLogin )
		{
			return (long) SelectByLastLogin ( lastLogin ).Count;
		}

		public IList<Principal> SelectByLastLogin ( int start, int count, DateTime lastLogin )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastLogin == lastLogin ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByApproved ( bool approved )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Approved == approved ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByApproved ( bool approved )
		{
			return (long) SelectByApproved ( approved ).Count;
		}

		public IList<Principal> SelectByApproved ( int start, int count, bool approved )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Approved == approved ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByIsOnline ( bool isOnline )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsOnline == isOnline ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsOnline ( bool isOnline )
		{
			return (long) SelectByIsOnline ( isOnline ).Count;
		}

		public IList<Principal> SelectByIsOnline ( int start, int count, bool isOnline )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsOnline == isOnline ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLocked ( bool locked )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Locked == locked ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLocked ( bool locked )
		{
			return (long) SelectByLocked ( locked ).Count;
		}

		public IList<Principal> SelectByLocked ( int start, int count, bool locked )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Locked == locked ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLocale ( string locale )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Locale == locale ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLocale ( string locale )
		{
			return (long) SelectByLocale ( locale ).Count;
		}

		public IList<Principal> SelectByLocale ( int start, int count, string locale )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Locale == locale ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByConfirmationCode ( string confirmationCode )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ConfirmationCode == confirmationCode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByConfirmationCode ( string confirmationCode )
		{
			return (long) SelectByConfirmationCode ( confirmationCode ).Count;
		}

		public IList<Principal> SelectByConfirmationCode ( int start, int count, string confirmationCode )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ConfirmationCode == confirmationCode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByRawRoles ( string rawRoles )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RawRoles == rawRoles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRawRoles ( string rawRoles )
		{
			return (long) SelectByRawRoles ( rawRoles ).Count;
		}

		public IList<Principal> SelectByRawRoles ( int start, int count, string rawRoles )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RawRoles == rawRoles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCreatedDate ( DateTime createdDate )
		{
			return (long) SelectByCreatedDate ( createdDate ).Count;
		}

		public IList<Principal> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUpdatedDate ( DateTime updatedDate )
		{
			return (long) SelectByUpdatedDate ( updatedDate ).Count;
		}

		public IList<Principal> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastActionUserId ( int lastActionUserId )
		{
			return (long) SelectByLastActionUserId ( lastActionUserId ).Count;
		}

		public IList<Principal> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
