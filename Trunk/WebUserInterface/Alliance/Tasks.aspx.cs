using System;
using System.Web;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Tasks : System.Web.UI.Page {

        protected NecessityTypeSort typeN;
        protected NecessityCreatorSort creator;
        protected NecessityCoordinateSort coordinateN;
        protected NecessityCreatedDateSort dateN;
        protected NecessityPagedList necessities;

        protected AssetTypeSort typeA;
        protected AssetOwnerSort owner;
        protected AssetCoordinateSort coordinateA;
        protected AssetCreatedDateSort dateA;
        protected AssetPagedList assets;

        protected TaskPagedList tasks;
        protected Literal taskLink;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            int id = AllianceWebUtils.Current.Storage.Id;

            typeN.InnerHTML = LanguageManager.Instance.Get("Type");
            coordinateN.InnerHTML = LanguageManager.Instance.Get("Coordinates");
            dateN.InnerHTML = LanguageManager.Instance.Get("CreatedAt");
            creator.InnerHTML = LanguageManager.Instance.Get("Owner");
            necessities.Where = string.Format("e.Status = 'NotAssigned' and e.AllianceNHibernate.Id={0}", id);

            typeA.InnerHTML = LanguageManager.Instance.Get("Type");
            coordinateA.InnerHTML = LanguageManager.Instance.Get("Coordinates");
            dateA.InnerHTML = LanguageManager.Instance.Get("CreatedAt");
            owner.InnerHTML = LanguageManager.Instance.Get("Owner");
            assets.Where = string.Format("e.TaskNHibernate is null and e.AllianceNHibernate.Id={0}", id);

            //title.InnerHTML = LanguageManager.Instance.Get("Title");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AllianceWebUtils.AssertCurrentPlayerBelongsToCurrentAlliance();

            if(PlayerUtils.Current.AllianceRank == AllianceRank.Admiral)
            {
                taskLink.Text = string.Format("<div class='button'><a href='CreateTask.aspx'>{0}</a></div>",
                    LanguageManager.Instance.Get("Create"));
            }

            if (Page.IsPostBack)
            {
                string toRemove = Page.Request.Form["toDelete"];
                string item = Page.Request.Form["item"];
                if (!string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["toDelete"] == null)
                {
                    HttpContext.Current.Items["toDelete"] = string.Empty;

                    if(item=="necessity")
                    {
                       WebUtilities.DeleteNecessity(int.Parse(toRemove)); 
                    }
                    if(item=="asset")
                    {
                        WebUtilities.DeleteAsset(int.Parse(toRemove));
                    }
                    if (item == "task")
                    {
                        WebUtilities.DeleteTask(int.Parse(toRemove));
                    }
                }
            }

            RegisterDeleteJS();
        }

        private void RegisterDeleteJS()
        {
            string script = @"<script type='text/javascript'>
	        var theForm = document.forms['" + Page.Form.ClientID + @"'];
            if (!theForm) {
                theForm = document.form;
            }
            function DeleteNecessity ( id )
            {
                if (Message.raiseConfirm('ReallyDelete')) {
		                theForm.toDelete.value = id;
                        theForm.item.value='necessity';
		                theForm.submit();
		            }
	        }

            function DeleteAsset ( id )
            {
                if (Message.raiseConfirm('ReallyDelete')) {
		                theForm.toDelete.value = id;
                        theForm.item.value='asset';
		                theForm.submit();
		            }
	        }

            function DeleteTask ( id )
            {
                if (Message.raiseConfirm('ReallyDelete')) {
		                theForm.toDelete.value = id;
                        theForm.item.value='task';
		                theForm.submit();
		            }
	        }
	        </script>";

            Page.ClientScript.RegisterClientScriptBlock(typeof(Necessity), "DeleteItem", script);
            Page.ClientScript.RegisterHiddenField("toDelete", "");
            Page.ClientScript.RegisterHiddenField("item", "");
        }

    }
}
