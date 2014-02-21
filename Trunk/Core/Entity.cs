
using System;
using System.Collections.Generic;
using Loki.DataRepresentation;
using Loki;

namespace OrionsBelt.Core {

    /// <summary>
    /// Represents a logic entity
    /// </summary>
	public abstract class Entity : IEntity {

        #region Fields

        private int id;
        private DateTime created;
        private DateTime updated;
        private int lastUser;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the entity's Id
        /// </summary>
        public virtual int Id {
            get { return id; }
            set { id = value; }
        }
        
        /// <summary>
        /// True if this object has not been persisted to the repository
        /// </summary>
        public virtual bool Transient {
            get { return Id == 0; }
        }
        
        /// <summary>
        /// Gets the entity's type name
        /// </summary>
        public abstract string TypeName {get;}
        
        /// <summary>
        /// The date when the entity was created
        /// </summary>
        public virtual DateTime CreatedDate {
            get { return created; }
            set { created = value; }
        }

        /// <summary>
        /// The date when the entity was last updated
        /// </summary>
        public virtual DateTime UpdatedDate {
            get { return updated; }
            set { updated = value; }
        }

        /// <summary>
        /// The identifier of the laste user that accessed the entity
        /// </summary>
        public virtual int LastActionUserId {
            get { return lastUser; }
            set { lastUser = value; }
        }

        #endregion Properties
        
		#region Metadata
		
		protected object metadata = null;
		
		protected virtual string MetadataContent {
			get {
				throw new Exception("This entity doesn't support Metadata");
			}
		}
		
		/// <summary>
        /// Gets the metadatab object for this entity
        /// </summary>
        /// <typeparam name="T">The metadata type</typeparam>
        /// <returns>The metadata objectt</returns>
		public T GetMetadata<T>()
		{
			if( string.IsNullOrEmpty(MetadataContent) ) {
				return default(T);
			}
			if( metadata != null ) {
				return (T) metadata;
			}
			T data = Loki.Generic.SerializerUtils.Import<T>(MetadataContent);
			metadata = data;
			return data;
		}
		
		/// <summary>
        /// Sets the metadata
        /// </summary>
        /// <typeparam name="T">The metadata type</typeparam>
        /// <param name="data">The metadata object</param>
		public void SetMetadata<T>(T data)
        {
            metadata = data;
            UpdateMetadata<T>();
        }
        
        /// <summary>
        /// Updates the RawMetadata with changes on the metadata object
        /// </summary>
        /// <typeparam name="T">The Metadata object</typeparam>
        public virtual void UpdateMetadata<T>()
        {
        }
		
		#endregion Metadata
		
    };
    
}