﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the Posts of the ForumThread entity
    /// </summary>
	public class ForumThreadPostsEditor : 
			ForumPostItem, IEntityFieldEditor<ForumThread>, INamingContainer {

		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit(EventArgs args)
        {
			if( Source == SourceType.None ) {
				Source = SourceType.Choice;
			}
            base.OnInit(args);
        }
		
		#endregion Events

		#region IEntityFieldEditor<ForumPost> Implementation
		
		/// <summary>
        /// Updates an ForumThread
        /// </summary>
        /// <param name="entity">An instance of ForumThread</param>
		public void Update( ForumThread entity )
		{
			// OneToMany
			System.Collections.Generic.IList<ForumPost> list = entity.Posts;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<ForumPost> Implementation
		
	};

}
