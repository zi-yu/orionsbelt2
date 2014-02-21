using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Common;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using Loki.DataRepresentation;
using OrionsBelt.Engine.Exceptions;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {

    public class InteractionsControl : Control {

        #region Fields

        private IList<Interaction> interactions = null;

        private IEntity state;

        public IEntity State
        {
            get { return state; }
            set { state = value; }
        }
	

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            WebUtilities.PreparePostBackActions(this.Page);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                WebUtilities.ProcessPostBackAction(this.Page, ProcessInteraction, "Interaction");
            }catch(TeamException)
            {
                ErrorBoard.AddLocalizedMessage("InvalidAlliance");
                Persistance.Flush();
            }
        }

        public void ProcessInteraction(string type, string action, string data)
        {
            Interaction interaction = GetInteraction(int.Parse(data));
            IInteractionType interactionType = InteractionType.Get(interaction);

            if (action == "Accept") {
                InteractionType.ResolveSuccess(interaction, State);
            } else {
                InteractionType.ResolveFail(interaction, State);
            }
            
        }

        private Interaction GetInteraction(int id)
        {
            foreach (Interaction interaction in interactions) {
                if (interaction.Id == id) {
                    return interaction;
                }
            }
            throw new UIException("Can't find interaction with id {0}", id);
        }

        protected override void Render(HtmlTextWriter mainwriter)
        {
            if (interactions == null || interactions.Count == 0) {
                return;
            }

            StringWriter writer = new StringWriter();

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("Interactions"));

            writer.Write("<ul class='interactions'>");

            foreach (Interaction interaction in interactions) {
                IInteractionType type = InteractionType.Get(interaction.Type);
                if (type.IsTarget(interaction, State) || type is TeamInvitation)
                {
                    WriteForTarget(writer, type, interaction);
                } else {
                    WriteForSource(writer, type, interaction);
                }
            }

            writer.Write("</ul>");

            Border.RenderMedium(mainwriter, title, writer.ToString());
        }

        private void WriteForTarget(TextWriter writer, IInteractionType type, Interaction interaction)
        {
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

        private void WriteForSource(TextWriter writer, IInteractionType type, Interaction interaction)
        {
            string label = type.TranslateForSource(interaction);

            writer.Write("<li>");
            WriteLabel(writer, interaction, label);

            if (!interaction.Resolved){                
                writer.Write("<a href='{0}'>{1}</a>", WebUtilities.GetActionJs("Interaction", "Cancel", interaction.Id), LanguageManager.Instance.Get("Cancel"));
            }
            writer.Write("</li>");
        }

        private static void WriteLabel(TextWriter writer, Interaction interaction, string label)
        {
            writer.Write(label);
        }

        #endregion Events

        #region Utils

        internal void SetInteractions(IList<Interaction> interactionList)
        {
            interactions = interactionList;
        }

        #endregion Utils

    };

}
