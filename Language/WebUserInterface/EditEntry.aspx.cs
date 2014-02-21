using System;
using Language.Core;
using Language.DataAccessLayer;
using Language.WebComponents;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Language.WebComponents.Controls;

namespace Language.WebUserInterface {
    public partial class EditEntry : System.Web.UI.Page {

        #region Events

        protected Literal title;
        protected Literal message;
        protected Literal errors;
        protected LanguageTranslationTextEditor textEditor;
        protected LanguageTranslationEditor entryEditor;
        protected UpdateButton updateButton;
        protected UpdateButton updateAndContinueButton;
        
        protected LanguageTranslationList otherLanguagesList;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ProjectFile.AssertCanEditLocale(Request.QueryString["Locale"]);

            LanguageEntry entry = Hql.Query<LanguageEntry>("select entry from SpecializedLanguageEntry entry inner join fetch entry.TranslationsNHibernate where entry.Id = :id ", Hql.Param("id", Page.Request.QueryString["Id"]))[0];
            State.SetItems("LanguageEntry", entry);

            title.Text = string.Format("Edit token <u>{0}</u> for language <u>{1}</u>", entry.Name, Page.Request.QueryString["Locale"] );

            textEditor.TextBox.Width = new Unit(600);
            textEditor.TextBox.Height = new Unit(250);

            entryEditor.Source = SourceType.New;
            List<LanguageTranslation> allOthers = new List<LanguageTranslation>();

            foreach (LanguageTranslation trans in entry.Translations) {
                if (trans.Locale == Page.Request.QueryString["Locale"]) {
                    entryEditor.Source = SourceType.None;
                    entryEditor.Current = trans;
                } else {
                    allOthers.Add(trans);
                }
            }

            entryEditor.FetchCurrent();
            entryEditor.Current.Locale = Page.Request.QueryString["Locale"];
            entryEditor.Current.LanguageEntry = entry;

            updateButton.Success += new EventHandler(updateButton_Success);
            updateButton.Failure += new EventHandler(updateButton_Failure);
            updateAndContinueButton.Success += new EventHandler(updateAndContinueButton_Success);
            updateAndContinueButton.Failure += new EventHandler(updateButton_Failure);

            if (string.IsNullOrEmpty(entryEditor.Current.Text)) {
                State.SetItems("MainContentEmpty", true);

            }

            otherLanguagesList.Collection = allOthers;

            RegisterJS(textEditor);
        }

        void updateAndContinueButton_Success(object sender, EventArgs e)
        {
            TouchEntry();
            int currId = int.Parse(Page.Request.QueryString["Id"]);
            int nextIndex = -1;

            if( State.HasSession("CurrentEntryList") ) {
                IList<LanguageEntry> list = (IList<LanguageEntry>)State.GetSession("CurrentEntryList");
                int i = 0;
                foreach (LanguageEntry entry in list) {
                    ++i;
                    if (entry.Id == currId) {
                        nextIndex = i;
                        break;
                    }
                }
                if (nextIndex >= 0 && nextIndex <= list.Count -1) {
                    Response.Redirect(string.Format("EditEntry.aspx?Id={0}&Locale={1}", list[nextIndex].Id, Page.Request.QueryString["Locale"]));
                }
            } 
        }

        private void TouchEntry()
        {
            LanguageEntry entry = (LanguageEntry)State.GetItems("LanguageEntry");
            using (ILanguageEntryPersistance persistance = Persistance.Instance.GetLanguageEntryPersistance()) {
                persistance.Update(entry);
                persistance.Flush();
            }
        }

        void updateButton_Success(object sender, EventArgs e)
        {
            TouchEntry();
            message.Text = "<span class='green'>Token updated</span>";
        }

        void updateButton_Failure(object sender, EventArgs e)
        {
            errors.Visible = true;
        }

        private void RegisterJS(LanguageTranslationTextEditor textEditor)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "AutoCopy", @"
                function updateContent(source) {
                    $('" + textEditor.TextBox.ClientID + @"').value = $(source).innerHTML;
                    window.location = window.location.href + '#translation';
                }
            ", true);
        }

        #endregion Events

    };
}