using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class InteractionPersistanceStateless : 
			NHibernatePersistanceStateless<Interaction>, IInteractionPersistance {
	
		#region Static Access
		
		internal static InteractionPersistanceStateless CreateSession()
		{
			return new InteractionPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedInteraction) );
		}
				
		internal static InteractionPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			InteractionPersistanceStateless persistance = new InteractionPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedInteraction) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static InteractionPersistanceStateless globalSession = null;
        internal static InteractionPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static InteractionPersistanceStateless GetSession()
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
		
		internal static InteractionPersistanceStateless GetValidatedSession()
        {
            InteractionPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private InteractionPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Interaction Create()
		{	
			SpecializedInteraction entity = new SpecializedInteraction ();
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
		
 		public IList<Interaction> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.Id = '{0}'", id);
		}

		public IList<Interaction> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectBySource ( int source )
		{
			return SelectBySource (-1, -1, source );
		}
		
		public long CountBySource ( int source )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.Source = '{0}'", source);
		}

		public IList<Interaction> SelectBySource ( int start, int count, int source )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.Source = {0}", source);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectByTarget ( int target )
		{
			return SelectByTarget (-1, -1, target );
		}
		
		public long CountByTarget ( int target )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.Target = '{0}'", target);
		}

		public IList<Interaction> SelectByTarget ( int start, int count, int target )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.Target = {0}", target);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.Type = '{0}'", type);
		}

		public IList<Interaction> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectByResponse ( bool response )
		{
			return SelectByResponse (-1, -1, response );
		}
		
		public long CountByResponse ( bool response )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.Response = '{0}'", response);
		}

		public IList<Interaction> SelectByResponse ( int start, int count, bool response )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.Response = {0}", response);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectByResponseExtension ( string responseExtension )
		{
			return SelectByResponseExtension (-1, -1, responseExtension );
		}
		
		public long CountByResponseExtension ( string responseExtension )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.ResponseExtension = '{0}'", responseExtension);
		}

		public IList<Interaction> SelectByResponseExtension ( int start, int count, string responseExtension )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.ResponseExtension like '{0}'", responseExtension);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectByInteractionContext ( string interactionContext )
		{
			return SelectByInteractionContext (-1, -1, interactionContext );
		}
		
		public long CountByInteractionContext ( string interactionContext )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.InteractionContext = '{0}'", interactionContext);
		}

		public IList<Interaction> SelectByInteractionContext ( int start, int count, string interactionContext )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.InteractionContext like '{0}'", interactionContext);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectByResolved ( bool resolved )
		{
			return SelectByResolved (-1, -1, resolved );
		}
		
		public long CountByResolved ( bool resolved )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.Resolved = '{0}'", resolved);
		}

		public IList<Interaction> SelectByResolved ( int start, int count, bool resolved )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.Resolved = {0}", resolved);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectBySourceAditionalData ( string sourceAditionalData )
		{
			return SelectBySourceAditionalData (-1, -1, sourceAditionalData );
		}
		
		public long CountBySourceAditionalData ( string sourceAditionalData )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.SourceAditionalData = '{0}'", sourceAditionalData);
		}

		public IList<Interaction> SelectBySourceAditionalData ( int start, int count, string sourceAditionalData )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.SourceAditionalData like '{0}'", sourceAditionalData);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectByTargetAditionalData ( string targetAditionalData )
		{
			return SelectByTargetAditionalData (-1, -1, targetAditionalData );
		}
		
		public long CountByTargetAditionalData ( string targetAditionalData )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.TargetAditionalData = '{0}'", targetAditionalData);
		}

		public IList<Interaction> SelectByTargetAditionalData ( int start, int count, string targetAditionalData )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.TargetAditionalData like '{0}'", targetAditionalData);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectBySourceType ( string sourceType )
		{
			return SelectBySourceType (-1, -1, sourceType );
		}
		
		public long CountBySourceType ( string sourceType )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.SourceType = '{0}'", sourceType);
		}

		public IList<Interaction> SelectBySourceType ( int start, int count, string sourceType )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.SourceType like '{0}'", sourceType);
			return ToTypedCollection(list);
		}
		
 		public IList<Interaction> SelectByTargetType ( string targetType )
		{
			return SelectByTargetType (-1, -1, targetType );
		}
		
		public long CountByTargetType ( string targetType )
		{
			return ExecuteScalar("select count(*) from SpecializedInteraction e where e.TargetType = '{0}'", targetType);
		}

		public IList<Interaction> SelectByTargetType ( int start, int count, string targetType )
		{
			IList list = Query(start, count, "from SpecializedInteraction e where e.TargetType like '{0}'", targetType);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Interaction
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfResponseExtension );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfInteractionContext );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfSourceAditionalData );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTargetAditionalData );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfSourceType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTargetType );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( Interaction e ) 
        {
			return ValidateStringMaxSize( "Interaction", "Type", e.Type, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfResponseExtension ( Interaction e ) 
        {
			return ValidateStringMaxSize( "Interaction", "ResponseExtension", e.ResponseExtension, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfInteractionContext ( Interaction e ) 
        {
			return ValidateStringMaxSize( "Interaction", "InteractionContext", e.InteractionContext, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfSourceAditionalData ( Interaction e ) 
        {
			return ValidateStringMaxSize( "Interaction", "SourceAditionalData", e.SourceAditionalData, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTargetAditionalData ( Interaction e ) 
        {
			return ValidateStringMaxSize( "Interaction", "TargetAditionalData", e.TargetAditionalData, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfSourceType ( Interaction e ) 
        {
			return ValidateStringMaxSize( "Interaction", "SourceType", e.SourceType, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTargetType ( Interaction e ) 
        {
			return ValidateStringMaxSize( "Interaction", "TargetType", e.TargetType, 100 );
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
