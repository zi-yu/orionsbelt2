
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using System;
using OrionsBelt.Engine.MarketPlace;

namespace OrionsBelt.WebUserInterface.Controls {
	public class GivePrizeControl : ChooseOpponent {

		#region Fields

		private readonly TextBox orions = new TextBox();
		private readonly RegularExpressionValidator validator = new RegularExpressionValidator();
        private readonly Button givePrize = new Button();

		#endregion Fields

		#region Public

		public int GetOrions() {
			return int.Parse(orions.Text);
		}

		#endregion Public

		protected override void OnInit(System.EventArgs e) {
			validator.Text = "Must be a number";
			validator.Display = ValidatorDisplay.Dynamic;
			validator.ValidationExpression = @"^\d+";
            givePrize.Click += new System.EventHandler(Give);
            givePrize.Text = LanguageManager.Localize("GivePrize");
            givePrize.CssClass = "button";
			base.OnInit(e);
		}

		protected override void WriteExtendedContent() {
			orions.ID = "orions";
			validator.ControlToValidate = "orions";
			
			Write("<div id='givePrize' class='smallBorder'>");
            Write("<div class='top'><h2>{0}</h2></div><div class='center'>", LanguageManager.Instance.Get("GivePrize"));

            Write("<p>");
            Controls.Add(orions);
            Write("</p><p>");
            Controls.Add(validator);
            Write("</p></div>");    

            Write("<div class='bottom'>");
            Controls.Add(givePrize);
            Write("</div></div>");

		}

        
        protected void Give(object sender, EventArgs e){
            if(Page.IsValid){
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    persistance.StartTransaction();
					Principal pri = persistance.SelectById(GetSelectedPlayerId())[0];
                	int orions = GetOrions();
					pri.Credits += orions;
                    persistance.Update(pri);
					TransactionManager.PrizeTransaction(pri, orions, persistance);
                    persistance.CommitTransaction();

					InformationBoard.AddLocalizedMessage("PrizeGiven", orions.ToString(), pri.Name);
                }
            }
        }
	};

}
