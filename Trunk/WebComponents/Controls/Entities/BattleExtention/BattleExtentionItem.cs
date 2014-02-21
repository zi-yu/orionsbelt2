
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// BattleExtention control renderer
    /// </summary>
	public class BattleExtentionItem : BaseEntityItem<BattleExtention> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BattleExtentionItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBattleExtentionPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<BattleExtention> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleExtentionId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BattleFinalStates</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleExtentionBattleFinalStates () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BattleMovements</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleExtentionBattleMovements () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Battle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleExtentionBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleExtentionCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleExtentionUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new BattleExtentionLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<BattleExtention> Implementation
		
	};

}
