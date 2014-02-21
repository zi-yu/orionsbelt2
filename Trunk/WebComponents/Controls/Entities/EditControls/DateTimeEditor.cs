using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits a Date field
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
	public abstract class DateTimeEditor<T> : BaseEntityFieldEditor<T> where T : IDescriptable {
	
		#region Fields
		
		protected DropDownList year = new DropDownList();
		protected DropDownList month = new DropDownList();
		protected DropDownList day = new DropDownList();
		private bool setUsed = false;
			    
		#endregion Fields
		
		#region Properties
		
		public DropDownList Year
	    {
	        get { return year; }
	        set { year = value; }
	    }

	    public DropDownList Month
	    {
	        get { return month; }
	        set { month = value; }
	    }

	    public DropDownList Day
	    {
	        get { return day; }
	        set { day = value; }
	    }
		
		#endregion Properties

		
		#region Private Methods
		
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

			month.Items.Add(LanguageManager.Localize("January"));
			month.Items.Add(LanguageManager.Localize("February"));
			month.Items.Add(LanguageManager.Localize("March"));
			month.Items.Add(LanguageManager.Localize("April"));
			month.Items.Add(LanguageManager.Localize("May"));
			month.Items.Add(LanguageManager.Localize("June"));
			month.Items.Add(LanguageManager.Localize("July"));
			month.Items.Add(LanguageManager.Localize("August"));
			month.Items.Add(LanguageManager.Localize("September"));
			month.Items.Add(LanguageManager.Localize("October"));
			month.Items.Add(LanguageManager.Localize("November"));
			month.Items.Add(LanguageManager.Localize("December"));

		}
		
		protected int FindIndex (DropDownList list, string value)
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

            string eventStr = string.Format("alterdropdown(document.getElementById('{0}'),document.getElementById('{1}'),document.getElementById('{2}'))", year.ClientID, month.ClientID, day.ClientID);
			
			month.Attributes.Add( "onchange", eventStr );
			year.Attributes.Add( "onchange", eventStr );
			day.Attributes.Add( "onload", eventStr );
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

						function alterdropdown(year,month,day){
							var monthIndex;
							
							if(year.selectedIndex == 1 && year.value % 4 == 0){
								monthIndex = 12;
							}else{
								monthIndex = month.selectedIndex;
                            }
							day.options.length = 0;
							for(var i = 0; i < monthdays[monthIndex]; ++i){
								day.options.add(new Option(i+1));
                            }
							day.selectedIndex = 0;
						}
						</script>";

            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "script", cod);
		}
		
		protected override void Render( HtmlTextWriter writer, T t, int renderCount, bool flipFlop )
		{
			Utils.SetCssClass(year, CssClass);
            Utils.SetCssClass(month, CssClass);
            Utils.SetCssClass(day, CssClass);
			
			if (!setUsed)
            {
                year.SelectedIndex = FindIndex(year, GetDateTime(t).Year.ToString());
                month.SelectedIndex = GetDateTime(t).Month - 1;
                day.SelectedIndex = FindIndex(day, GetDateTime(t).Day.ToString());
            }
            			
			year.RenderControl( writer );
			month.RenderControl( writer );
			day.RenderControl( writer );
		}
		
		#endregion Events
		
		#region Abstract Members
		
		protected abstract DateTime GetDateTime( T t );
		
		#endregion
		
		#region Public Methods

        public DateTime GetSelectedDate()
        {
            return new DateTime(Convert.ToInt32(year.SelectedValue),month.SelectedIndex + 1,Convert.ToInt32(day.SelectedValue));
        }
        
        public void SetSelectedDate(DateTime date)
        {
            year.SelectedValue = date.Year.ToString();
            month.SelectedIndex = date.Month - 1;
            day.SelectedValue = date.Day.ToString();
            setUsed = true;
        }

        #endregion Public Methods
		
	};

}