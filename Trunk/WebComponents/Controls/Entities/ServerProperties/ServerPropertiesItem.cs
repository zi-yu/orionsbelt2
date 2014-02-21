
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ServerProperties control renderer
    /// </summary>
	public class ServerPropertiesItem : BaseEntityItem<ServerProperties> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ServerPropertiesItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetServerPropertiesPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ServerProperties> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CurrentTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesCurrentTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastTickDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesLastTickDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Running</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesRunning () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MillisPerTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesMillisPerTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UseWebClock</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesUseWebClock () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MaxPlayers</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesMaxPlayers () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>VacationTicksPerWeek</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesVacationTicksPerWeek () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BaseUrl</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesBaseUrl () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ServerProperties> Implementation
		
	};

}
