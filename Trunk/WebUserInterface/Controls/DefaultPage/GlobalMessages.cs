using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Caching;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Exceptions;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Common;
using Loki.DataRepresentation;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Shows entity messages
    /// </summary>
	public class GlobalMessages : Control {

        #region Fields

		private static readonly char[] separator = new char[]{ ';'};

        private IList<Interaction> interactions = null;

        private IEntity state;

        public IEntity InteractionsState {
            get { return state; }
            set { state = value; }
        }

		#endregion Fields

		#region Private

		private static IList<Message> GetGlobalMessages() {
			if (State.HasCache("GlobalMessages")) {
				return (IList<Message>)State.GetCache("GlobalMessages");
			}

			IList<Message> messages = Hql.StatelessQuery<Message>(0,5,"from SpecializedMessage m where m.Category = :category and (m.TickDeadline = 0 or m.TickDeadline = null or m.TickDeadline >= :tick) order by m.CreatedDate desc", Hql.Param("category", Category.Global.ToString()), Hql.Param("tick", Clock.Instance.Tick));
			State.Cache.Add("GlobalMessages", messages, null, DateTime.Now.AddMinutes(40), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

			return messages;
		}

		private static string GetMessages() {
			StringWriter writer = new StringWriter();
			foreach (Message msg in GetGlobalMessages()) {
				string[] parameters = msg.Parameters.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				string s;
                if (msg.SubCategory == "TournamentWarning")
                {
                    parameters[1] = TimeFormatter.GetFormattedTicksTo(Convert.ToInt32(parameters[1]));
                }
                
                s = string.Format(LanguageManager.Localize(msg.SubCategory), parameters);
                
			    writer.Write("<p>{0}</p>",s);
			}
			return writer.ToString();
		}
		
		#endregion Private

        #region Control Events

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            WebUtilities.PreparePostBackActions(this.Page);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            try {
                WebUtilities.ProcessPostBackAction(this.Page, ProcessInteraction, "Interaction");
            } catch (TeamException) {
                ErrorBoard.AddLocalizedMessage("InvalidAlliance");
                Persistance.Flush();
            }
        }

        protected override void Render(HtmlTextWriter mainwriter){
            StringWriter writer = new StringWriter();

        	string s = GetMessages();
            if (!string.IsNullOrEmpty(s) || interactions.Count > 0) {

                StringWriter title = new StringWriter();
                WriteInteractions(title);

                StringWriter content = new StringWriter();
                WriteMessages(content, s);

                Border.RenderByRace(writer, title.ToString(), content.ToString());
			}
            mainwriter.Write(writer.ToString());
        }

        private void WriteMessages(StringWriter writer, string s) {
            if (!string.IsNullOrEmpty(s)) {
                writer.Write("<div class='globalMessages'>{0}</div>", s);
            }
        }
        
        private void WriteInteractions(TextWriter writer) {
            if (interactions != null && interactions.Count > 0) {

                writer.Write("<ul>");

                foreach (Interaction interaction in interactions) {
                    IInteractionType type = InteractionType.Get(interaction.Type);
                    if (type.IsTarget(interaction, InteractionsState) || type is TeamInvitation) {
                        WriteForTarget(writer, type, interaction);
                    } else {
                        WriteForSource(writer, type, interaction);
                    }
                }
                writer.Write("</ul>");
            }
        }

        #endregion Control Events

        #region private

        public void ProcessInteraction(string type, string action, string data) {
            Interaction interaction = GetInteraction(int.Parse(data));
            IInteractionType interactionType = InteractionType.Get(interaction);

            if (action == "Accept") {
                OrionsBelt.Engine.Common.InteractionType.ResolveSuccess(interaction, InteractionsState);
            } else {
                InteractionType.ResolveFail(interaction, InteractionsState);
            }

        }

        private Interaction GetInteraction(int id) {
            foreach (Interaction interaction in interactions) {
                if (interaction.Id == id) {
                    return interaction;
                }
            }
            throw new UIException("Can't find interaction with id {0}", id);
        }

        private void WriteForTarget(TextWriter writer, IInteractionType type, Interaction interaction) {
            string label = type.TranslateForTarget(interaction);

            writer.Write("<li class='Resolved{0}'>", interaction.Resolved);
            WriteLabel(writer, interaction, label);

            if (!interaction.Resolved) {
                writer.Write("<span class='actions'>");
                writer.Write("<a href='{0}'>{1}</a>", WebUtilities.GetActionJs("Interaction", "Accept", interaction.Id), LanguageManager.Instance.Get("Accept"));
                writer.Write("<a href='{0}'>{1}</a>", WebUtilities.GetActionJs("Interaction", "Reject", interaction.Id), LanguageManager.Instance.Get("Reject"));
                writer.Write("</span>");
            }

            writer.Write("</li>");
        }

        private void WriteForSource(TextWriter writer, IInteractionType type, Interaction interaction) {
            string label = type.TranslateForSource(interaction);

            writer.Write("<li>");
            WriteLabel(writer, interaction, label);

            if (!interaction.Resolved) {
                writer.Write("<a href='{0}'>{1}</a>", WebUtilities.GetActionJs("Interaction", "Cancel", interaction.Id), LanguageManager.Instance.Get("Cancel"));
            }
            writer.Write("</li>");
        }

        private static void WriteLabel(TextWriter writer, Interaction interaction, string label) {
            writer.Write(label);
        }

        #endregion Events

        #region Utils

        internal void SetInteractions(IList<Interaction> interactionList) {
            interactions = interactionList;
        }

        #endregion Utils



    };
}

