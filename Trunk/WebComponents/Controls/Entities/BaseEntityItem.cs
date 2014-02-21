
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// This interface specifies an object that handles an Entity
    /// </summary>
    /// <remarks>
    /// All Midgard generated Entities implement IDescriptable and IDescriptableHandler interface
    /// indicates an object that performs some actions on a IDescriptable
    /// </remarks>
    public interface IDescriptableHandler {
        IDescriptable Descriptable { get;}
    };

	/// <summary>
    /// This is the base class for the controls that know how to render an Entity to XHTML
    /// </summary>
    /// <typeparam name="T">The Entity Type</typeparam>
	public abstract class BaseEntityItem<T> : Control, IDescriptableHandler where T : IDescriptable {
	
		#region Ctor & Control Fields
		
		private SourceType source = SourceType.None;
		private IPersistance<T> persistance = null;
		private T current = default(T);
		private int renderCount = 0;
		private bool flipFlop = false;
		private int maxChoiceItems = 50;
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="per">The persistance object</param>
		protected BaseEntityItem( IPersistance<T> per )
		{
			Persistance = per;
		}
		
		#endregion Control Fields
		
		#region Control Properties
		
		/// <summary>
        /// Indicates where the control will obtain the object to show
        /// </summary>
		public SourceType Source {
			get { return source; }
			set { source = value; }
		}
		
		/// <summary>
        /// The current object to render
        /// </summary>
		public T Current {
			get { return current; }
			set { 
				current = value;
                OnCurrentUpdated(current); 
            }
		}
		
		/// <summary>
        /// The current persistance object
        /// </summary>
		public IPersistance<T> Persistance {
			get { return persistance; }
			set { persistance = value; }
		}
		
		/// <summary>
        /// How many objects this control has rendered
        /// </summary>
		public int RenderCount {
			get { return renderCount; }
			set { renderCount = value; }
		}
		
		/// <summary>
        /// The threshold to show a drop or an input
        /// </summary>
		public int MaxChoiceItems {
			get { return maxChoiceItems; }
			set { maxChoiceItems = value; }
		}
		
		/// <summary>
        /// Utility when this control is used to render a collection of objects
        /// </summary>
        /// <remarks>
        /// This property is true on RenderCount odd and false otherwise
        /// </remarks>
		public bool FlipFlop {
			get { return flipFlop; }
			set { flipFlop = value; }
		}
		
		#endregion Control Properties
		
		#region Control Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			if( Source == SourceType.None ) {
				Source = SourceType.Parent;
			}
			if( Controls.Count == 0 ) {
				AddDefaultControlTree();
			}
		}
		
		/// <summary>
        /// Renders the current object to XHTML
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
		protected override void Render( HtmlTextWriter writer )
		{
			FetchCurrent();
			if( Source == SourceType.Choice ) {
				if( Current == null ) {
					RenderChoice( writer, GetDefaultChoice() );
				} else {
					RenderChoice( writer, Current.Id );
				}
				return;
			}
			++RenderCount;
			FlipFlop = (RenderCount & 1) == 0;
			base.Render(writer);
			ResetCurrent();
		}
		
		/// <summary>
        /// Gets the selectedId based on the QueryString filter
        /// </summary>
        /// <returns>The selected Id</returns>
        private int GetDefaultChoice()
        {
            string queryStringKey = string.Format("{0}Filter", GetType().Name);
            string raw = HttpContext.Current.Request.QueryString[queryStringKey];
            if (string.IsNullOrEmpty(raw)) {
                return 0;
            }

            return int.Parse(raw);
        }
		
		/// <summary>
        /// Render's a combo that selects the current object to render
        /// </summary>
        /// <remarks>
        /// This is used the SourceType is Choice: on first request the combo is shown, on postback
        /// the selected object will be shown
        /// </remarks>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="selected">The Id to render has selected</param>
		protected virtual void RenderChoice( HtmlTextWriter writer, int selected ) {
			IList<T> list = GetChoiceCollection();
			
			if (list.Count >= MaxChoiceItems) {
                writer.Write("Id: <input type='text' name='{0}Text' id='{0}Text' value='{1}' />", GetKey(), selected);
                return;
            }

			writer.Write( "<select name='{0}List' id='{0}List'>", GetKey() );
			writer.Write( "<option value='-1'> </option>" );

			foreach( T e in list ) {
				string selectedString = " selected";
				if( e.Id != selected ) {
					selectedString = string.Empty;
				}
				writer.Write( "<option value='{0}'{2}>{1}</option>", e.Id, e.ToString(), selectedString );
			}
			writer.Write( "</select>" );
		}
		
		/// <summary>
        /// Occurs when the Current object is updated
        /// </summary>
        /// <param name="current">The new object</param>
        protected virtual void OnCurrentUpdated(T current)
        {
            if (current == null) {
                return;
            }
            foreach (Control control in Controls) {
                BaseFieldControl<T> baseFieldControl = control as BaseFieldControl<T>;
                if( baseFieldControl != null ) {
                    baseFieldControl.OnCurrentUpdated(current);
                }
            }
        }
		
		#endregion Control Events
		
		#region Abstract/Virtual Members
		
		/// <summary>
        /// Adds a default control tree to this control
        /// </summary>
        /// <remarks>
        /// This is only called when the control has no sons
        /// </remarks>
		protected abstract void AddDefaultControlTree();

		/// <summary>
        /// Obtains the entity collection to render when SourceType is Choice
        /// </summary>
        /// <returns>The entity collection</returns>
		protected virtual IList<T> GetChoiceCollection()
		{
			return Persistance.Select(0, MaxChoiceItems);
		}
		
		#endregion Abstract Members
		
		#region Utilities
		
		/// <summary>
        /// Find and obtain the current object
        /// </summary>
        /// <returns>The current object</returns>
		protected virtual T GetSourceObject()
		{
			switch( Source ) {
				case SourceType.Parent:
					return GetSourceFromParent();
				case SourceType.QueryString:
					return GetSourceFromQueryString();
				case SourceType.Form:
					return GetSourceFromForm();
				case SourceType.Items:
					return GetSourceFromItems();
				case SourceType.Session:
					return GetSourceFromSession();
				case SourceType.Cache:
					return GetSourceFromCache();
				case SourceType.Application:
					return GetSourceFromApplication();
				case SourceType.New:
					return persistance.Create();
				case SourceType.Choice:
					return GetChoice();
				case SourceType.Random:
					return GetRandom();
				case SourceType.ByTheDay:
					return GetByTheDay();
				default:
					throw new Exception("Don't know how to handle "+Source.ToString()+"");
			}
		}
		
		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected virtual string GetKey()
		{
			return typeof(T).Name;
		}
		
		/// <summary>
        /// Given a string, return the parsed integer
        /// </summary>
        /// <param name="stringId">string representation of an integer</param>
        /// <param name="error">The error to throw when stringId is not integer</param>
        /// <returns>The parsed integer</returns>
		private int ToId( string stringId, string error )
		{
			if( string.IsNullOrEmpty(stringId) ) {
				throw new Exception("No '" + GetKey() + "' found at the " + error);
			}
			
			int id = 0;
			if( !int.TryParse( stringId, out id ) ) {
				throw new Exception("String '" + stringId + "' it's not integer at " + error);
			}
			
			return id;
		}
		
		/// <summary>
        /// Obtains the current object via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		private T GetSourceFromParent()
		{
			BaseList<T> parent = Parent as BaseList<T>;
			if( parent == null ) {
				throw new Exception("Parent it's not EntityItem<" + typeof(T).Name + ">");
			}
			parent.FetchCollection();
			return parent.Current;
		}
		
		/// <summary>
        /// Obtains the current object via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected virtual T GetSourceFromParent( IDescriptable descriptable )
		{
            return default(T);
		}
		
		/// <summary>
        /// Obtains the current object via the request Query String
        /// </summary>
        /// <returns>The current object</returns>
		private T GetSourceFromQueryString()
		{
			string key = GetKey();
			string stringId = Page.Request.QueryString[key];
			return persistance.Select( ToId(stringId, "QueryString") );
		}
		
		/// <summary>
        /// Obtains the current object via the request Form data
        /// </summary>
        /// <returns>The current object</returns>
		private T GetSourceFromForm()
		{
			string key = GetKey();
			string stringId = Page.Request.Form[key];
			return persistance.Select( ToId(stringId, "Form") );
		}
		
		/// <summary>
        /// Obtains the current object via the Items container
        /// </summary>
        /// <returns>The current object</returns>
		private T GetSourceFromItems()
		{
			string key = GetKey();
			T entity = (T) HttpContext.Current.Items[key];
			if( entity == null ) {
				throw new Exception("No '"+key+"' found at Items");
			}
			return entity;
		}
		
		/// <summary>
        /// Obtains the current object via the Session container
        /// </summary>
        /// <returns>The current object</returns>
		private T GetSourceFromSession()
		{
			string key = GetKey();
			T entity = (T) Page.Session[key];
			if( entity == null ) {
				throw new Exception("No '"+key+"' found at Session");
			}
			return entity;
		}
		
		/// <summary>
        /// Obtains the current object via the Cache container
        /// </summary>
        /// <returns>The current object</returns>
		private T GetSourceFromCache()
		{
			string key = GetKey();
			T entity = (T) Page.Cache[key];
			if( entity == null ) {
				throw new Exception("No '"+key+"' found at Cache");
			}
			return entity;
		}
		
		/// <summary>
        /// Obtains the current object via the Application container
        /// </summary>
        /// <returns>The current object</returns>
		private T GetSourceFromApplication()
		{
			string key = GetKey();
			T entity = (T) Page.Application[key];
			if( entity == null ) {
				throw new Exception("No '"+key+"' found at Application");
			}
			return entity;
		}
		
		/// <summary>
        /// Obtains the current object via a Combo Box
        /// </summary>
        /// <returns>The current object</returns>
		private T GetChoice()
		{
			if( Page.IsPostBack ) {
				string strId = Page.Request.Form[GetKey()+"List"];
				if( !string.IsNullOrEmpty(strId) ) {
					int id = int.Parse(strId);
					if( id == -1 ) {
						return default(T);
					}
					return Persistance.Select( id );
				}
				string strId2 = Page.Request.Form[GetKey() + "Text"];
                if (!string.IsNullOrEmpty(strId2)) {
                    int id = int.Parse(strId2);
					if( id <= 0 ) {
						return default(T);
					}
					return Persistance.Select( id );
                }
			} else {
                IDescriptableHandler parent = Parent as IDescriptableHandler;
                if (parent == null) {
                    return default(T);
                } 
                return GetSourceFromParent(parent.Descriptable);
            }

            return default(T);
		}
		
		/// <summary>
        /// Obtains a random object
        /// </summary>
        /// <returns>The current object</returns>
		private T GetRandom()
		{
			return persistance.GetRandom();
		}
		
		/// <summary>
        /// Obtains the current object based on the entity records quantity and the current day
        /// </summary>
        /// <returns>The current object</returns>
		private T GetByTheDay()
		{
			int day = DateTime.Now.DayOfYear;
			long count = persistance.GetCount();
			
			return persistance.Select( (int)(day % count), 1 )[0];
		}		
		
		/// <summary>
        /// Gets the current object
        /// </summary>
		public void FetchCurrent()
		{
			if( Current == null ) {
				Current = GetSourceObject();
			}
		}
		
		/// <summary>
        /// Clears the current object
        /// </summary>
		protected void ResetCurrent()
		{
			Current = default(T);
		}
		
		#endregion
		
		#region IDescriptableHandler Members

		/// <summary>
        /// The current Entity object
        /// </summary>
        public IDescriptable Descriptable {
            get { return Current; }
        }

        #endregion
		
	};

}
