
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PrincipalStats editor control
    /// </summary>
	public partial class PrincipalStatsEditor : BaseEntityEditor<PrincipalStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalStatsEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalStatsPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MaxElo</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsMaxEloEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MinElo</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsMinEloEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberPlayedBattles</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsNumberPlayedBattlesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MaxLadder</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsMaxLadderEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MinLadder</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsMinLadderEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStatsLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PrincipalStats> Implementation
		
	};

}