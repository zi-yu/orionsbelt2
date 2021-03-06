﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// This control renders a collection of entity objects
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
	public abstract class BaseList<T> : Control where T : IDescriptable {

		#region Ctor & Control Fields

		private T current = default(T);
		private IList<T> list = null;
	
		#endregion Control Fields
		
		#region Control Properties
		
		/// <summary>
        /// The current object to render
        /// </summary>
		public T Current {
			get { return current; }
			set { current = value; }
		}
		
		/// <summary>
        /// The collection to render
        /// </summary>
		public IList<T> Collection {
			get { return list; }
			set { list = value; }
		}
		
		#endregion Control Properties
	
		#region Control Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			if( Controls.Count == 0 ) {
				AddDefaultControlTree();
			}
			base.OnInit(args);
		}
		
		/// <summary>
        /// Renders the collection
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
		protected override void Render( HtmlTextWriter writer )
		{
			FetchCollection();
            foreach (Control control in Controls) {
                if ( control is BaseEntityItem<T> ) {
                    foreach (T t in Collection) {
                        Current = t;
                        control.RenderControl(writer);
                    }
                } else {
                    control.RenderControl(writer);
                }
            }
			ResetCollection();
		}
		
		#endregion Control Rendering
		
		#region Abstract Members
		
		/// <summary>
        /// Gets the collection to render
        /// </summary>
        /// <returns>The collection</returns>
		protected abstract IList<T> GetCollection();
		
		/// <summary>
        /// Adds a default control tree if the control has no sons
        /// </summary>
		protected abstract void AddDefaultControlTree();
		
		#endregion Abstract Members
		
		#region Utilities
		
		/// <summary>
        /// Safely obtains the current collection
        /// </summary>
		public void FetchCollection()
		{
			if( list == null ) {
				list = GetCollection();
			}
		}
		
		/// <summary>
        /// Clears the current collection
        /// </summary>
		public void ResetCollection()
		{
			list = null;
		}
		
		#endregion Utilities
		
	};

}