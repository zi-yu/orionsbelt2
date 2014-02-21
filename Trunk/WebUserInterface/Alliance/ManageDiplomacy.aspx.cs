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
using OrionsBelt.WebComponents;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.RulesCore.Enum;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class ManageDiplomacy : System.Web.UI.Page {

        #region Fields

        protected Literal currentStatus;
        protected PlaceHolder options;
        protected InteractionsControl interactions;
        protected Button declareWar;
        protected Button ofterConfederation;
        protected Button ofterNonAggressionPact;
        protected Button setNeutral;
        protected Button endWar;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Interaction interaction = AllianceManager.GetInteractionWith(AllianceWebUtils.Current, GetOtherAlliance());
            bool withInteraction = interaction != null;

            options.Visible = !withInteraction;
            interactions.Visible = withInteraction;

            PrepareInteractions(interaction);
            PrepareOptions();

            AllianceMenu.CurrentPage = "Diplomacy";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AllianceWebUtils.AssertCurrentPlayerOwnsCurrentAlliance();
        }

        private void PrepareInteractions(Interaction interaction)
        {
            if (!interactions.Visible) {
                return;
            }

            List<Interaction> list = new List<Interaction>();
            list.Add(interaction);
            interactions.SetInteractions(list);
            interactions.State = AllianceWebUtils.Current.Storage;
        }

        private void PrepareOptions()
        {
            if (options.Visible)
            {
                declareWar.Text = LanguageManager.Instance.Get("AllianceDeclareWar");
                declareWar.Click += new EventHandler(declareWar_Click);

                ofterConfederation.Text = LanguageManager.Instance.Get("OfterConfederation");
                ofterConfederation.Click += new EventHandler(ofterConfederation_Click);

                ofterNonAggressionPact.Text = LanguageManager.Instance.Get("OfterNonAggressionPact");
                ofterNonAggressionPact.Click += new EventHandler(ofterNonAggressionPact_Click);

                setNeutral.Text = LanguageManager.Instance.Get("SetNeutral");
                setNeutral.Click += new EventHandler(setNeutral_Click);

                endWar.Text = LanguageManager.Instance.Get("EndWar");
                endWar.Click += new EventHandler(endWar_Click);
            }
        }

        void endWar_Click(object sender, EventArgs e)
        {
            IAlliance curr = AllianceWebUtils.Current;
            IAlliance other = GetOtherAlliance();

            AllianceManager.OfterEndWar(curr, other);
        }

        void setNeutral_Click(object sender, EventArgs e)
        {
            IAlliance curr = AllianceWebUtils.Current;
            IAlliance other = GetOtherAlliance();

            AllianceManager.GoNeutral(curr, other);
        }

        void ofterNonAggressionPact_Click(object sender, EventArgs e)
        {
            IAlliance curr = AllianceWebUtils.Current;
            IAlliance other = GetOtherAlliance();

            AllianceManager.OfterNonAggressionPact(curr, other);
        }

        void ofterConfederation_Click(object sender, EventArgs e)
        {
            IAlliance curr = AllianceWebUtils.Current;
            IAlliance other = GetOtherAlliance();

            AllianceManager.OfterConfederation(curr, other);
        }

        void declareWar_Click(object sender, EventArgs e)
        {
            IAlliance curr = AllianceWebUtils.Current;
            IAlliance other = GetOtherAlliance();

            AllianceManager.DeclareWar(curr, other);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            IAlliance curr = AllianceWebUtils.Current;
            IAlliance other = GetOtherAlliance();
            AllianceDiplomacyLevel diplomacy = AllianceManager.GetDiplomaticRelationLevel(curr, other);

            string token = LanguageManager.Instance.Get("AllianceCurrentDiplomacyRelationship");
            string status = diplomacy.ToString();
            currentStatus.Text = string.Format(token, other.Storage.Name, LanguageManager.Instance.Get(status),status.ToLower());

            PrepareLinks(curr, other, diplomacy);
        }

        private void PrepareLinks(IAlliance curr, IAlliance other, AllianceDiplomacyLevel diplomacy)
        {
            declareWar.Visible = diplomacy != AllianceDiplomacyLevel.War;
            endWar.Visible = diplomacy == AllianceDiplomacyLevel.War;

            ofterConfederation.Visible = diplomacy == AllianceDiplomacyLevel.Neutral || diplomacy == AllianceDiplomacyLevel.NonAgressionPact;
            ofterNonAggressionPact.Visible = diplomacy == AllianceDiplomacyLevel.Neutral;

            setNeutral.Visible = diplomacy == AllianceDiplomacyLevel.Confederation || diplomacy == AllianceDiplomacyLevel.NonAgressionPact;

            SetEnabled();
        }

        private void SetEnabled()
        {
            declareWar.Enabled = declareWar.Visible;
            endWar.Visible = endWar.Visible;

            ofterConfederation.Visible = ofterConfederation.Visible;
            ofterNonAggressionPact.Visible = ofterNonAggressionPact.Visible;

            setNeutral.Visible = setNeutral.Visible;

        }

        private IAlliance GetOtherAlliance()
        {
            const string key = "ManageDiplomacyOtherAllinace";
            if (State.HasItems(key)) {
                return (IAlliance)State.GetItems(key);
            }

            AllianceStorage storage = EntityUtils.GetFromQueryString<AllianceStorage>("Other");
            IAlliance alliance = AllianceManager.PrepareAlliance(storage);
            State.SetItems(key, alliance);
            return alliance;

        }

        #endregion Events

    };
}
