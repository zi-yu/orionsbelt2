using System;
using System.Web;
using System.Web.UI;
using Loki.DataRepresentation;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Control that renders an Entity's field
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
	public abstract class BaseFieldControl<T> : Control where T : IDescriptable {
		
		#region Fields

		private string cssClass;
		private string question = string.Empty;

		#endregion Fields

		#region Properties

		public string CssClass {
			get { return cssClass; }
			set {
				if( string.IsNullOrEmpty(cssClass) ) {
					cssClass = value;
				} else {
					if( cssClass.IndexOf(value) == -1 ) {
						cssClass += string.Format(" {0}", value);
					}
				}
			}
		}
		
		public T Current {
            get {
                return GetParent().Current;
            }
        }
        
        public string Question
        {
            get
            {
                return question == string.Empty ? question : "<span class='inQuestion'>" + question + "</span>";
            }
            set { question = value; }
        }
        
        #endregion Properties
		
		#region Control Rendering & Events
		
		/// <summary>
        /// Utility Render... gets the current object and delegates the render to the derived class
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
		protected override void Render( HtmlTextWriter writer )
		{
			BaseEntityItem<T> item = GetParent();
			HttpContext.Current.Items[ string.Format("__Current__{0}", typeof(T).Name) ] = item.Current;
			
			Render( writer, item.Current, item.RenderCount, item.FlipFlop );
		}
		
		/// <summary>
        /// Occurs when the Current object is updated
        /// </summary>
        /// <param name="current">The new object</param>
        public virtual void OnCurrentUpdated(T current)
        {
        }
		
		#endregion Control Rendering & Events
		
		#region Abstract Members

		/// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="t">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected virtual void Render(HtmlTextWriter writer, T t, int renderCount, bool flipFlop)
        {
        }
		
		#endregion Abstract Members
		
		#region Utilities
		
		/// <summary>
        /// Gets this object parent
        /// </summary>
        /// <returns>The parent</returns>
		protected virtual BaseEntityItem<T> GetParent()
		{
			Control current = Parent;
            BaseEntityItem<T> parent = current as BaseEntityItem<T>;
			while( parent == null ) {
                if (current is Page) {
                    throw new Exception("Parent it's not BaseEntityItem<" + typeof(T).Name + ">");
                }
                current = current.Parent;
                parent = current as BaseEntityItem<T>;
			}
			parent.FetchCurrent();
			return parent;
		}
		
		#endregion
		
	};

}
