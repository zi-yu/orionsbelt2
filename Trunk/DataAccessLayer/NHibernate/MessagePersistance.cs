using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class MessagePersistance : 
			NHibernatePersistance<Message>, IMessagePersistance {
	
		#region Static Access
		
		internal static MessagePersistance CreateSession()
		{
			return new MessagePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedMessage) );
		}
				
		internal static MessagePersistance AttachSession( IPersistanceSession owner )
		{
			MessagePersistance persistance = new MessagePersistance ( owner.Session as ISession, typeof(SpecializedMessage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static MessagePersistance globalSession = null;
        internal static MessagePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static MessagePersistance GetSession()
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
		
		internal static MessagePersistance GetValidatedSession()
        {
            MessagePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private MessagePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Message Create()
		{	
			SpecializedMessage entity = new SpecializedMessage ();
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
		
 		public IList<Message> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedMessage e where e.Id = '{0}'", id);
		}

		public IList<Message> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedMessage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Message> SelectByParameters ( string parameters )
		{
			return SelectByParameters (-1, -1, parameters );
		}
		
		public long CountByParameters ( string parameters )
		{
			return ExecuteScalar("select count(*) from SpecializedMessage e where e.Parameters = '{0}'", parameters);
		}

		public IList<Message> SelectByParameters ( int start, int count, string parameters )
		{
			IList list = Query(start, count, "from SpecializedMessage e where e.Parameters like '{0}'", parameters);
			return ToTypedCollection(list);
		}
		
 		public IList<Message> SelectByCategory ( string category )
		{
			return SelectByCategory (-1, -1, category );
		}
		
		public long CountByCategory ( string category )
		{
			return ExecuteScalar("select count(*) from SpecializedMessage e where e.Category = '{0}'", category);
		}

		public IList<Message> SelectByCategory ( int start, int count, string category )
		{
			IList list = Query(start, count, "from SpecializedMessage e where e.Category like '{0}'", category);
			return ToTypedCollection(list);
		}
		
 		public IList<Message> SelectBySubCategory ( string subCategory )
		{
			return SelectBySubCategory (-1, -1, subCategory );
		}
		
		public long CountBySubCategory ( string subCategory )
		{
			return ExecuteScalar("select count(*) from SpecializedMessage e where e.SubCategory = '{0}'", subCategory);
		}

		public IList<Message> SelectBySubCategory ( int start, int count, string subCategory )
		{
			IList list = Query(start, count, "from SpecializedMessage e where e.SubCategory like '{0}'", subCategory);
			return ToTypedCollection(list);
		}
		
 		public IList<Message> SelectByOwnerId ( int ownerId )
		{
			return SelectByOwnerId (-1, -1, ownerId );
		}
		
		public long CountByOwnerId ( int ownerId )
		{
			return ExecuteScalar("select count(*) from SpecializedMessage e where e.OwnerId = '{0}'", ownerId);
		}

		public IList<Message> SelectByOwnerId ( int start, int count, int ownerId )
		{
			IList list = Query(start, count, "from SpecializedMessage e where e.OwnerId = {0}", ownerId);
			return ToTypedCollection(list);
		}
		
 		public IList<Message> SelectByDate ( DateTime date )
		{
			return SelectByDate (-1, -1, date );
		}
		
		public long CountByDate ( DateTime date )
		{
			return ExecuteScalar("select count(*) from SpecializedMessage e where e.Date = '{0}'", date);
		}

		public IList<Message> SelectByDate ( int start, int count, DateTime date )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Message> SelectByExtended ( string extended )
		{
			return SelectByExtended (-1, -1, extended );
		}
		
		public long CountByExtended ( string extended )
		{
			return ExecuteScalar("select count(*) from SpecializedMessage e where e.Extended = '{0}'", extended);
		}

		public IList<Message> SelectByExtended ( int start, int count, string extended )
		{
			IList list = Query(start, count, "from SpecializedMessage e where e.Extended like '{0}'", extended);
			return ToTypedCollection(list);
		}
		
 		public IList<Message> SelectByTickDeadline ( int tickDeadline )
		{
			return SelectByTickDeadline (-1, -1, tickDeadline );
		}
		
		public long CountByTickDeadline ( int tickDeadline )
		{
			return ExecuteScalar("select count(*) from SpecializedMessage e where e.TickDeadline = '{0}'", tickDeadline);
		}

		public IList<Message> SelectByTickDeadline ( int start, int count, int tickDeadline )
		{
			IList list = Query(start, count, "from SpecializedMessage e where e.TickDeadline = {0}", tickDeadline);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Message
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfParameters );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCategory );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfSubCategory );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfExtended );
        }
		public static LifecyleVeto ValidateMaxSizeOfParameters ( Message e ) 
        {
			return ValidateStringMaxSize( "Message", "Parameters", e.Parameters, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCategory ( Message e ) 
        {
			return ValidateStringMaxSize( "Message", "Category", e.Category, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfSubCategory ( Message e ) 
        {
			return ValidateStringMaxSize( "Message", "SubCategory", e.SubCategory, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfExtended ( Message e ) 
        {
			return ValidateStringMaxSize( "Message", "Extended", e.Extended, 100 );
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
