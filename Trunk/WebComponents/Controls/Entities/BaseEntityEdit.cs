using System;
using System.Web.UI;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// This interface specifies that an object is an Entity editor
    /// </summary>
	public interface IEntityEditor {
	
		/// <summary>
        /// Called by Midgard framework when to update an object
        /// </summary>
        /// <returns></returns>
		bool OnUpdate();
	};
	
	/// <summary>
    /// This interface specifies that and object is an Entity Field editor
    /// </summary>
    /// <typeparam name="T">The Entity type</typeparam>
	public interface IEntityFieldEditor<T> where T : IDescriptable {
	
		/// <summary>
        /// Updates an object
        /// </summary>
        /// <param name="t">An instance of the Entity type</param>
		void Update( T t );
	};

	/// <summary>
    /// Base class for all the Entity editing
    /// </summary>
    /// <typeparam name="T">The Entity type to edit</typeparam>
	public abstract class BaseEntityEditor<T> : BaseEntityItem<T>, IEntityEditor where T : IDescriptable {
	
		#region Fields

        public delegate void UpdateDelegate(BaseEntityEditor<T> sender);
        public delegate bool ValidateDelegate(BaseEntityEditor<T> sender);
        
        public event UpdateDelegate OnBeforeUpdate;
        public event UpdateDelegate OnAfterUpdate;

        public event ValidateDelegate ValidateData;

        #endregion Fields
	
		#region Ctor & Events
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="per">The Persistance object</param>
		public BaseEntityEditor( IPersistance<T> per ) : base(per)
		{
		}
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args ) 
		{
			if( Source == SourceType.None ) {
				Source = SourceType.New;
			}
			base.OnInit(args);
		}
		
		#endregion Ctor & Events
		
		#region Update Methods
		
		/// <summary>
        /// Responsible for the update of the current object
        /// </summary>
        /// <remarks>
        /// This method searches all sons for controls that implement <code>IEntityFieldEditor<T></code>
        /// and call it's Update method
        /// </remarks>
        /// <returns>True if the update succeded</returns>
		public virtual bool OnUpdate()
		{
			if( EnforcePageValidation  ) {
                if (!Page.IsValid) {
                    return false;
                }
			}
			try {
				using (Persistance) {
                    FetchCurrent();
					if (OnBeforeUpdate != null) {
                        OnBeforeUpdate(this);
                    }
                    UpdateFields(Current);
					if (OnAfterUpdate != null) {
                        OnAfterUpdate(this);
                    }
					if (ValidateData != null && !ValidateData(this)) {
                        return false;
                    }
                    PersistEntity();
                    if (AutoFlush) {
                        Persistance.Flush();
                    }
                    return true;
                }
			} catch( Exception ex ) {
				ExceptionLogger.Log(ex);
				return false;
			}
		}
		
		/// <summary>
        /// Persists the entity to the DB
        /// </summary>
        protected virtual void PersistEntity()
        {
            Persistance.Update(Current);
        }
        
		/// <summary>
        /// Updates the current object fields
        /// </summary>
        /// <param name="t">The object</param>
		protected void UpdateFields( T t )
		{
			foreach( Control control in Controls ) {
				UpdateFields( control, t );
			}
		}
		
		/// <summary>
        /// Updates the current object recursevely
        /// </summary>
        /// <param name="control">The current control</param>
        /// <param name="t">The object to update</param>
		protected void UpdateFields( Control control, T t )
		{
			if( control is IEntityFieldEditor<T> ) {
				((IEntityFieldEditor<T>) control).Update(t);
			} else if(control is IEntityEditor) {
                ((IEntityEditor)control).OnUpdate();
			} else {
				foreach( Control son in control.Controls ) {
					UpdateFields( son, t );
				}				
			}		
		}
		
		#endregion Update
		
		#region Properties

        private bool enforcePageValidation = true;

        /// <summary>
        /// True if the control should check Page.IsValid
        /// </summary>
        public bool EnforcePageValidation
        {
            get { return enforcePageValidation; }
            set { enforcePageValidation = value; }
        }

        private bool autoFlush = true;

        /// <summary>
        /// True if the control should flush after the update
        /// </summary>
        public bool AutoFlush
        {
            get { return autoFlush; }
            set { autoFlush = value; }
        }
	

        #endregion Properties
		
	};

}