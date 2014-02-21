using System;
using System.Collections;
using System.Web.UI;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface {

	public class Duplicates: Page 
    {
	    protected DuplicateDetectionCheaterSort cheater;
        protected DuplicateDetectionDuplicateSort clone;
        protected DuplicateDetectionFindTypeSort type;
        protected DuplicateDetectionExtraInfoSort info;
        protected DuplicateDetectionCreatedDateSort date;

	    protected DuplicateCheater customCheater;
        protected DuplicateClone customClone;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            cheater.InnerHTML = LanguageManager.Instance.Get("Cheater");
            clone.InnerHTML = LanguageManager.Instance.Get("Clone");
            type.InnerHTML = LanguageManager.Instance.Get("Type");
            info.InnerHTML = LanguageManager.Instance.Get("Information");
            date.InnerHTML = LanguageManager.Instance.Get("Date");

            IDictionary<int, string> data = new Dictionary<int, string>();
            GetPrincipalDictionary(data);

            customCheater.Principals = data;
            customClone.Principals = data;
        }

	    private static void GetPrincipalDictionary(IDictionary<int, string> data)
	    {
	        using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
	        {
	            IList principals = persistance.Query("SELECT e.Id,e.Name FROM SpecializedPrincipal e");
	            foreach (IList list in principals)
	            {
	                data.Add(Convert.ToInt32(list[0]),list[1].ToString());
	            }

	        }
	    }
    }
}
