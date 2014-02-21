
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// FriendOrFoe control renderer
    /// </summary>
	public class FriendOrFoeItem : BaseEntityItem<FriendOrFoe> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public FriendOrFoeItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetFriendOrFoePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<FriendOrFoe> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FriendOrFoeId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsFriend</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FriendOrFoeIsFriend () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Source</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FriendOrFoeSource () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Target</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FriendOrFoeTarget () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FriendOrFoeCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FriendOrFoeUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FriendOrFoeLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<FriendOrFoe> Implementation
		
	};

}
