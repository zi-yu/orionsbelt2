using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	internal class TestimonialPersistanceStateless : 
			NHibernatePersistanceStateless<Testimonial>, ITestimonialPersistance {
	
		#region Static Access
		
		internal static TestimonialPersistanceStateless CreateSession()
		{
			return new TestimonialPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedTestimonial) );
		}
				
		internal static TestimonialPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			TestimonialPersistanceStateless persistance = new TestimonialPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedTestimonial) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static TestimonialPersistanceStateless globalSession = null;
        internal static TestimonialPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static TestimonialPersistanceStateless GetSession()
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
		
		internal static TestimonialPersistanceStateless GetValidatedSession()
        {
            TestimonialPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private TestimonialPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Testimonial Create()
		{	
			SpecializedTestimonial entity = new SpecializedTestimonial ();
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
		
 		public IList<Testimonial> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedTestimonial e where e.Id = '{0}'", id);
		}

		public IList<Testimonial> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedTestimonial e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Testimonial> SelectByLocale ( string locale )
		{
			return SelectByLocale (-1, -1, locale );
		}
		
		public long CountByLocale ( string locale )
		{
			return ExecuteScalar("select count(*) from SpecializedTestimonial e where e.Locale = '{0}'", locale);
		}

		public IList<Testimonial> SelectByLocale ( int start, int count, string locale )
		{
			IList list = Query(start, count, "from SpecializedTestimonial e where e.Locale like '{0}'", locale);
			return ToTypedCollection(list);
		}
		
 		public IList<Testimonial> SelectByContent ( string content )
		{
			return SelectByContent (-1, -1, content );
		}
		
		public long CountByContent ( string content )
		{
			return ExecuteScalar("select count(*) from SpecializedTestimonial e where e.Content = '{0}'", content);
		}

		public IList<Testimonial> SelectByContent ( int start, int count, string content )
		{
			IList list = Query(start, count, "from SpecializedTestimonial e where e.Content like '{0}'", content);
			return ToTypedCollection(list);
		}
		
 		public IList<Testimonial> SelectByAuthor ( string author )
		{
			return SelectByAuthor (-1, -1, author );
		}
		
		public long CountByAuthor ( string author )
		{
			return ExecuteScalar("select count(*) from SpecializedTestimonial e where e.Author = '{0}'", author);
		}

		public IList<Testimonial> SelectByAuthor ( int start, int count, string author )
		{
			IList list = Query(start, count, "from SpecializedTestimonial e where e.Author like '{0}'", author);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Testimonial
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfLocale );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfContent );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfAuthor );
        }
		public static LifecyleVeto ValidateMaxSizeOfLocale ( Testimonial e ) 
        {
			return ValidateStringMaxSize( "Testimonial", "Locale", e.Locale, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfContent ( Testimonial e ) 
        {
			return ValidateStringMaxSize( "Testimonial", "Content", e.Content, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfAuthor ( Testimonial e ) 
        {
			return ValidateStringMaxSize( "Testimonial", "Author", e.Author, 100 );
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
