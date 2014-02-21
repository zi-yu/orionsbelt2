using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents.Controls;
using System.IO;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Alliances;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Diplomacy : System.Web.UI.Page {

        #region Fields

        protected AllianceStoragePagedList allianceNeutralList;
        protected AllianceStoragePagedList allianceDiplomacyList;

        #endregion Fields

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AllianceWebUtils.AssertCurrentPlayerBelongsToCurrentAlliance();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            allianceNeutralList.Collection = GetNeutralCollection();
            allianceDiplomacyList.Collection = GetDiplomaticCollection();
        }

        private System.Collections.Generic.IList<OrionsBelt.Core.AllianceStorage> GetDiplomaticCollection()
        {
            IAlliance curr = AllianceWebUtils.Current;
            IList<AllianceDiplomacy> list = AllianceManager.GetDiplomaticRelations(curr);

            return ConvertToAllianceList(list, curr);
        }

        private IList<AllianceStorage> ConvertToAllianceList(IList<AllianceDiplomacy> list, IAlliance curr)
        {
            List<AllianceStorage> toReturn = new List<AllianceStorage>();

            foreach (AllianceDiplomacy dip in list) {
                AllianceStorage other = null;
                if (dip.AllianceA.Id != curr.Storage.Id) {
                    other = dip.AllianceA;
                } else if (dip.AllianceB.Id != curr.Storage.Id) {
                    other = dip.AllianceB;
                }
                if (other != null) {
                    toReturn.Add(other);
                    State.SetItems(string.Format("Diplomacy{0}_{1}", curr.Storage.Id, other.Id), dip.Level);
                }
            }

            return toReturn;
        }

        private System.Collections.Generic.IList<OrionsBelt.Core.AllianceStorage> GetNeutralCollection()
        {
            TextWriter writer = new StringWriter();

            int id = AllianceWebUtils.Current.Storage.Id;

            writer.Write(" select b from SpecializedAllianceStorage b ");
            writer.Write(" where b.Id not in( ");

            writer.Write(" select a.AllianceANHibernate.Id from SpecializedAllianceDiplomacy a ");
            writer.Write(" where a.AllianceBNHibernate={0}) ", id);

            writer.Write(" and b.Id not in( ");

            writer.Write(" select a.AllianceBNHibernate.Id from SpecializedAllianceDiplomacy a ");
            writer.Write(" where a.AllianceANHibernate={0}) ", id);

            writer.Write(" and b.Id <> {0} ", id);

            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance()) {
                return persistance.TypedQuery(writer.ToString());
            }
        }

        #endregion Events

    };
}
