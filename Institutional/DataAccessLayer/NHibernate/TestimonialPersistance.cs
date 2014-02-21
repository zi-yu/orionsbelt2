using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	internal class TestimonialPersistance : 
			NHibernatePersistance<Testimonial>, ITestimonialPersistance {
	
		#region Static Access
		
		internal static TestimonialPersistance CreateSession()
		{
			return new TestimonialPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedTestimonial) );
		}
				
		internal static TestimonialPersistance AttachSession( IPersistanceSession owner )
		{
			TestimonialPersistance persistance = new TestimonialPersistance ( owner.Session as ISession, typeof(SpecializedTestimonial) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static TestimonialPersistance globalSession = null;
        internal static TestimonialPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static TestimonialPersistance GetSession()
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
		
		internal static TestimonialPersistance GetValidatedSession()
        {
            TestimonialPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private TestimonialPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Testimonial Create()
		{	
			SpecializedTestimonial entity = new SpecializedTestimonial ();
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
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Testimonial
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
