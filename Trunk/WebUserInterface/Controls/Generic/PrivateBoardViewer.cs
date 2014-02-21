using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PrivateBoardViewer: Control {

        #region Properties

        private int receiverId;
        private string receiverType;

        public int ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }

        public string ReceiverType
        {
            get { return receiverType; }
            set { receiverType = value; }
        }

        #endregion Properties

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            IList<PrivateBoard> messages = GetMessages(75);

            writer.Write("<table class='newtable'>");
            int playerAllianceId = 0;
            if (null != PlayerUtils.Current.Alliance)
            {
                playerAllianceId = PlayerUtils.Current.Alliance.Storage.Id;
            }
            foreach (PrivateBoard board in messages)
            {
                string alliance = string.Empty;
                if(null != board.Sender.AllianceRank)
                {
                    alliance = LanguageManager.Instance.Get(board.Sender.AllianceRank);
                }
                writer.Write("<tr>");
                writer.Write("<td class='boardAuthor'><div>{0}</div><div>{2}</div><div>{1}</div></td>", WebUtilities.WritePlayerWithAvatar(board.Sender), string.Format(LanguageManager.Instance.Get("TimeAgo"), TimeFormatter.GetFormattedTime(DateTime.Now - board.CreatedDate)), alliance);

                writer.Write("<td class='boardMessage'>");
                EditFunctions(writer, board, playerAllianceId);
                writer.Write("<p>{0}</p>", board.Message.Replace("\n", "<p/>"));
                writer.Write("</td>");
                
                writer.Write("</tr>");
            }

            writer.Write("</table>");

        }

        #endregion Events

        #region Utils

        protected virtual void EditFunctions(HtmlTextWriter writer, PrivateBoard board, int playerAllianceId)
        {
            if (board.Sender.Id == PlayerUtils.Current.Id ||
                (PlayerUtils.Current.AllianceRank == AllianceRank.Admiral && playerAllianceId == receiverId))
            {
                writer.Write("<a href='MessageEdit.aspx?PrivateBoard={2}'><img src='{0}' alt='edit' title='edit'></a>&nbsp;<a href='javascript:DeletePM({2})'><img src='{1}' alt='delete' title='delete'></a>",
                             ResourcesManager.GetForumImage("Edit.gif"), ResourcesManager.GetForumImage("Delete.gif"),board.Id);
            }            
        }

        protected virtual IList<PrivateBoard> GetMessages(int total)
        {
            IList<PrivateBoard> messages = Hql.StatelessQuery<PrivateBoard>(0, total,
                "select e from SpecializedPrivateBoard e inner join fetch e.SenderNHibernate where e.Receiver = :receiver and e.Type = :type order by e.CreatedDate desc",
                new KeyValuePair<string, object>[] { Hql.Param("receiver", receiverId), Hql.Param("type", receiverType) });
            return messages;
        }

        #endregion Utils

    };
}
