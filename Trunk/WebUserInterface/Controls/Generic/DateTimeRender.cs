using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    /// <summary>
    /// Edits the UpdatedDate of the Invoice entity
    /// </summary>
	public class DateTimeRender: Control {
		
		#region Fields
		
		protected DropDownList year = new DropDownList();
		protected DropDownList month = new DropDownList();
		protected DropDownList day = new DropDownList();
        private string cssClass;
			    
		#endregion Fields
		
		#region Private Methods

        public DateTime GetDate()
        {
            return new DateTime(Convert.ToInt32(year.SelectedValue),month.SelectedIndex+1,day.SelectedIndex+1);
        }

        public void SetDate(DateTime date)
        {
            year.SelectedIndex = date.Year - 1900;
            month.SelectedIndex = date.Month - 1;
            day.SelectedIndex = date.Day - 1;
        }
		
		protected virtual void InitYears()
		{
			year.Items.Clear();
			for( int years = 1900; years < (DateTime.Now.Year + 50); ++years )
					year.Items.Add(years.ToString());
		}
		
		protected virtual void InitDays()
		{
			day.Items.Clear();
			for( int days = 1; days <= 31; ++days )
					day.Items.Add(days.ToString());
		}
		
		protected virtual void InitMonths()
		{
			month.Items.Clear();

			month.Items.Add("January");
			month.Items.Add("February");
			month.Items.Add("March");
			month.Items.Add("April");
			month.Items.Add("May");
			month.Items.Add("June");
			month.Items.Add("July");
			month.Items.Add("August");
			month.Items.Add("September");
			month.Items.Add("Octuber");
			month.Items.Add("November");
			month.Items.Add("December");

		}
		
		protected static int FindIndex (DropDownList list, string value)
		{
			for( int iter = 0; iter < list.Items.Count; ++iter)
			{
				if( value == list.Items[iter].ToString())
					return iter;
			}
			return 0;
		}
		#endregion Private Methods
		
		#region Events
		
		protected override void OnInit( EventArgs args )
		{
			InitYears();
			InitMonths();
			InitDays();
			base.OnInit(args);
			Controls.Add(day);
			Controls.Add(month);
			Controls.Add(year);
			
			month.Attributes.Add( "onchange", "alterdropdown()" );
			year.Attributes.Add( "onchange", "alterdropdown()" );
			day.Attributes.Add( "onload", "alterdropdown()" );
		}

		protected override void OnLoad( EventArgs e ) {	
			string cod = @"<script type='text/javascript'>
						var monthdays = new Array(13);
						   monthdays[0]= 31;
						   monthdays[1]= 28;
						   monthdays[2]= 31;
						   monthdays[3]= 30;
						   monthdays[4]= 31;
						   monthdays[5]= 30;
						   monthdays[6]= 31;
						   monthdays[7]= 31;
						   monthdays[8]= 30;
						   monthdays[9]= 31;
						   monthdays[10]= 30;
						   monthdays[11]= 31;
						   monthdays[12]= 29;

						function alterdropdown(){
							var monthIndex;
							
							if(document.getElementById('" + month.ClientID + @"').selectedIndex == 1 && document.getElementById('" + year.ClientID + @"').value % 4 == 0)
								monthIndex = 12;
							else
								monthIndex = document.getElementById('" + month.ClientID + @"').selectedIndex;
							document.getElementById('" + day.ClientID + @"').options.length = 0;
							for(var i = 0; i < monthdays[monthIndex]; ++i)
								document.getElementById('" + day.ClientID + @"').options.add(new Option(i+1));
							document.getElementById('" + day.ClientID + @"').selectedIndex = 0;
							
						}
						</script>";

			Page.ClientScript.RegisterClientScriptBlock( GetType(), "script", cod );
		}
        protected override void  Render(HtmlTextWriter writer)
        {
 	        base.Render(writer);
            Utils.SetCssClass(year, CssClass);
            Utils.SetCssClass(month, CssClass);
            Utils.SetCssClass(day, CssClass);
		
			//year.RenderControl( writer );
			//month.RenderControl( writer );
			//day.RenderControl( writer );
        }

        public string CssClass
        {
            get { return cssClass; }
            set
            {
                if (string.IsNullOrEmpty(cssClass))
                {
                    cssClass = value;
                }
                else
                {
                    if (cssClass.IndexOf(value) == -1)
                    {
                        cssClass += string.Format(" {0}", value);
                    }
                }
            }
        }

		#endregion Events
		


    };

}