
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// QuestStorage editor control
    /// </summary>
	public partial class QuestStorageEditor : BaseEntityEditor<QuestStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public QuestStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetQuestStoragePersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Percentage</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStoragePercentageEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsTemplate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageIsTemplateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Type</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>DeadlineTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageDeadlineTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>StartTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageStartTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Reward</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageRewardEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>QuestStringConfig</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageQuestStringConfigEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>QuestIntConfig</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageQuestIntConfigEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>QuestIntProgress</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageQuestIntProgressEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>QuestStringProgress</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageQuestStringProgressEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Completed</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageCompletedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsProgressive</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageIsProgressiveEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Player</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStoragePlayerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new QuestStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<QuestStorage> Implementation
		
	};

}