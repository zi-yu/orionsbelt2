
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// ServerProperties editor control
    /// </summary>
	public partial class ServerPropertiesEditor : BaseEntityEditor<ServerProperties> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ServerPropertiesEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetServerPropertiesPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CurrentTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesCurrentTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastTickDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesLastTickDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Running</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesRunningEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MillisPerTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesMillisPerTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UseWebClock</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesUseWebClockEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MaxPlayers</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesMaxPlayersEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>VacationTicksPerWeek</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesVacationTicksPerWeekEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BaseUrl</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesBaseUrlEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ServerPropertiesLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ServerProperties> Implementation
		
	};

}