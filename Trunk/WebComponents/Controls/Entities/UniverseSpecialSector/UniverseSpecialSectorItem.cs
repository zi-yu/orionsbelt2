
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// UniverseSpecialSector control renderer
    /// </summary>
	public class UniverseSpecialSectorItem : BaseEntityItem<UniverseSpecialSector> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public UniverseSpecialSectorItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetUniverseSpecialSectorPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSystemX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSystemY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SectorX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSectorX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SectorY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSectorY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Owner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Sector</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorSector () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new UniverseSpecialSectorLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<UniverseSpecialSector> Implementation
		
	};

}
