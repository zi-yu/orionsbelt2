
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// UniverseSpecialSector editor control
    /// </summary>
	public partial class UniverseSpecialSectorEditor : BaseEntityEditor<UniverseSpecialSector> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public UniverseSpecialSectorEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetUniverseSpecialSectorPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<UniverseSpecialSector> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSystemXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSystemYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SectorX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSectorXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SectorY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSectorYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Type</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Sector</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSectorEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<UniverseSpecialSector> Implementation
		
	};

}