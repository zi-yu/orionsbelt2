using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class VoteReferralPersistanceStateless : 
			NHibernatePersistanceStateless<VoteReferral>, IVoteReferralPersistance {
	
		#region Static Access
		
		internal static VoteReferralPersistanceStateless CreateSession()
		{
			return new VoteReferralPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedVoteReferral) );
		}
				
		internal static VoteReferralPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			VoteReferralPersistanceStateless persistance = new VoteReferralPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedVoteReferral) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static VoteReferralPersistanceStateless globalSession = null;
        internal static VoteReferralPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static VoteReferralPersistanceStateless GetSession()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			
			if (context == null) {
                return CreateSession();
            }

			if( context.Items == null ) {
				return CreateSession();
			}

            object persistance = context.Items["PersistanceStateless"];
			NHibernatePersistanceStateless<Principal> session = null;
			
			if( persistance != null ) {
				session = (NHibernatePersistanceStateless<Principal>) persistance;
			} else {
                session = PrincipalPersistanceStateless.CreateSession();
				context.Items["PersistanceStateless"] = session;
			}
			
			IStatelessSession nhSession = session.Session as IStatelessSession;
            if (nhSession != null && !NHibernateUtilities.IsSessionOpen(nhSession) ) {
				nhSession.Dispose();
                session.NHibernateSession = NHibernateUtilities.OpenStatelessSession;
            }
			
			return AttachSession( session );
		}
		
		internal static VoteReferralPersistanceStateless GetValidatedSession()
        {
            VoteReferralPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private VoteReferralPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override VoteReferral Create()
		{	
			SpecializedVoteReferral entity = new SpecializedVoteReferral ();
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
		
 		public IList<VoteReferral> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteReferral e where e.Id = '{0}'", id);
		}

		public IList<VoteReferral> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedVoteReferral e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteReferral> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteReferral e where e.Name = '{0}'", name);
		}

		public IList<VoteReferral> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedVoteReferral e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteReferral> SelectByShortName ( string shortName )
		{
			return SelectByShortName (-1, -1, shortName );
		}
		
		public long CountByShortName ( string shortName )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteReferral e where e.ShortName = '{0}'", shortName);
		}

		public IList<VoteReferral> SelectByShortName ( int start, int count, string shortName )
		{
			IList list = Query(start, count, "from SpecializedVoteReferral e where e.ShortName like '{0}'", shortName);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteReferral> SelectByUrl ( string url )
		{
			return SelectByUrl (-1, -1, url );
		}
		
		public long CountByUrl ( string url )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteReferral e where e.Url = '{0}'", url);
		}

		public IList<VoteReferral> SelectByUrl ( int start, int count, string url )
		{
			IList list = Query(start, count, "from SpecializedVoteReferral e where e.Url like '{0}'", url);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteReferral> SelectByImageUrl ( string imageUrl )
		{
			return SelectByImageUrl (-1, -1, imageUrl );
		}
		
		public long CountByImageUrl ( string imageUrl )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteReferral e where e.ImageUrl = '{0}'", imageUrl);
		}

		public IList<VoteReferral> SelectByImageUrl ( int start, int count, string imageUrl )
		{
			IList list = Query(start, count, "from SpecializedVoteReferral e where e.ImageUrl like '{0}'", imageUrl);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteReferral> SelectByReward ( string reward )
		{
			return SelectByReward (-1, -1, reward );
		}
		
		public long CountByReward ( string reward )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteReferral e where e.Reward = '{0}'", reward);
		}

		public IList<VoteReferral> SelectByReward ( int start, int count, string reward )
		{
			IList list = Query(start, count, "from SpecializedVoteReferral e where e.Reward like '{0}'", reward);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteReferral> SelectByClickCount ( int clickCount )
		{
			return SelectByClickCount (-1, -1, clickCount );
		}
		
		public long CountByClickCount ( int clickCount )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteReferral e where e.ClickCount = '{0}'", clickCount);
		}

		public IList<VoteReferral> SelectByClickCount ( int start, int count, int clickCount )
		{
			IList list = Query(start, count, "from SpecializedVoteReferral e where e.ClickCount = {0}", clickCount);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteReferral> SelectByVoteOrder ( int voteOrder )
		{
			return SelectByVoteOrder (-1, -1, voteOrder );
		}
		
		public long CountByVoteOrder ( int voteOrder )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteReferral e where e.VoteOrder = '{0}'", voteOrder);
		}

		public IList<VoteReferral> SelectByVoteOrder ( int start, int count, int voteOrder )
		{
			IList list = Query(start, count, "from SpecializedVoteReferral e where e.VoteOrder = {0}", voteOrder);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : VoteReferral
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfShortName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUrl );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfImageUrl );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfReward );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( VoteReferral e ) 
        {
			return ValidateStringMaxSize( "VoteReferral", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfShortName ( VoteReferral e ) 
        {
			return ValidateStringMaxSize( "VoteReferral", "ShortName", e.ShortName, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUrl ( VoteReferral e ) 
        {
			return ValidateStringMaxSize( "VoteReferral", "Url", e.Url, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfImageUrl ( VoteReferral e ) 
        {
			return ValidateStringMaxSize( "VoteReferral", "ImageUrl", e.ImageUrl, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfReward ( VoteReferral e ) 
        {
			return ValidateStringMaxSize( "VoteReferral", "Reward", e.Reward, 100 );
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
