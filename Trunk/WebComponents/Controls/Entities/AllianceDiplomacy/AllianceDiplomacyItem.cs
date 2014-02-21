
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// AllianceDiplomacy control renderer
    /// </summary>
	public class AllianceDiplomacyItem : BaseEntityItem<AllianceDiplomacy> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AllianceDiplomacyItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAllianceDiplomacyPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<AllianceDiplomacy> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceDiplomacyId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Level</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceDiplomacyLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>AllianceA</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceDiplomacyAllianceA () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>AllianceB</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceDiplomacyAllianceB () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceDiplomacyCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceDiplomacyUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AllianceDiplomacyLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<AllianceDiplomacy> Implementation
		
	};

}
