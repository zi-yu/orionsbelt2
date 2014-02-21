
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PrincipalStats control renderer
    /// </summary>
	public class PrincipalStatsItem : BaseEntityItem<PrincipalStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalStatsItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalStatsPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PrincipalStats> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MaxElo</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsMaxElo () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MinElo</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsMinElo () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberPlayedBattles</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsNumberPlayedBattles () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MaxLadder</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsMaxLadder () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MinLadder</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsMinLadder () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PrincipalStats> Implementation
		
	};

}
