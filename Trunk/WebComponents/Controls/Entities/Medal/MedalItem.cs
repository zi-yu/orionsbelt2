
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Medal control renderer
    /// </summary>
	public class MedalItem : BaseEntityItem<Medal> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public MedalItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetMedalPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Medal> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MedalId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MedalName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsAuto</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MedalIsAuto () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Player</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MedalPlayer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Principal</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MedalPrincipal () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MedalCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MedalUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new MedalLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Medal> Implementation
		
	};

}
