
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// QuestStorage control renderer
    /// </summary>
	public class QuestStorageItem : BaseEntityItem<QuestStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public QuestStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetQuestStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<QuestStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Percentage</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStoragePercentage () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsTemplate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageIsTemplate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>DeadlineTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageDeadlineTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>StartTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageStartTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Reward</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageReward () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>QuestStringConfig</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageQuestStringConfig () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>QuestIntConfig</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageQuestIntConfig () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>QuestIntProgress</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageQuestIntProgress () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>QuestStringProgress</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageQuestStringProgress () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Completed</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageCompleted () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsProgressive</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageIsProgressive () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Player</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStoragePlayer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<QuestStorage> Implementation
		
	};

}
