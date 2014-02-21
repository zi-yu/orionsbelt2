using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Generic;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface {

    public class CreateArena : Page 
    {
        private readonly Dictionary<string, string> mapper = new Dictionary<string, string>(3);
		protected DisplayUnits displayUnits;
        protected DropDownList arenaType;
        protected HtmlInputSubmit create;
        protected TextBox arenaName, prize, level, sysX, sysY, secX, secY;
        protected RequiredFieldValidator arenaNameRequired, prizeRequired;
        protected RegularExpressionValidator prizeValidator;
        protected RangeValidator levelRange, sysXRange, sysYRange, secXRange, secYRange;
        protected CustomValidator coordinatesCustom;
        protected Literal message;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            arenaType.Items.Add(LanguageManager.Instance.Get("Annihalation"));
            arenaType.Items.Add(LanguageManager.Instance.Get("Regicide"));
            arenaType.Items.Add(LanguageManager.Instance.Get("Domination"));

            create.Value = LanguageManager.Instance.Get("Create");
			create.ServerClick += CreateClick;

            mapper.Add(LanguageManager.Instance.Get("Annihalation"), BattleType.TotalAnnihalation.ToString());
            mapper.Add(LanguageManager.Instance.Get("Regicide"), BattleType.Regicide.ToString());
            mapper.Add(LanguageManager.Instance.Get("Domination"), BattleType.Domination.ToString());

            arenaNameRequired.Text = LanguageManager.Instance.Get("NotEmpty");
            prizeRequired.Text = LanguageManager.Instance.Get("NotEmpty");
            prizeValidator.Text = LanguageManager.Instance.Get("NumericValue");
            levelRange.Text = string.Format(Resources.ValueBetweenToken, levelRange.MinimumValue, levelRange.MaximumValue);
            coordinatesCustom.Text = LanguageManager.Instance.Get("AnyNotEmpty");
            sysXRange.Text = string.Format(Resources.FieldValueBetweenToken, sysXRange.MinimumValue, sysXRange.MaximumValue, "1");
            sysYRange.Text = string.Format(Resources.FieldValueBetweenToken, sysYRange.MinimumValue, sysYRange.MaximumValue, "2");
            secXRange.Text = string.Format(Resources.FieldValueBetweenToken, secXRange.MinimumValue, secXRange.MaximumValue, "3");
            secYRange.Text = string.Format(Resources.FieldValueBetweenToken, secYRange.MinimumValue, secYRange.MaximumValue, "4");
        }

        protected void ValidateAnyEmpty(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !(string.IsNullOrEmpty(sysX.Text) ||
                            string.IsNullOrEmpty(sysY.Text) ||
                            string.IsNullOrEmpty(secX.Text) ||
                            string.IsNullOrEmpty(secY.Text));
        }

        protected void CreateClick( object sender, EventArgs e )
        {
            if (!Page.IsValid)
            {
                return;
            }


			IFleetInfo units = displayUnits.GetUnits();
            GameEngine.Persist(units);
            Fleet fleet = units.Storage;

            Result res = ArenaManager.CreateArena(arenaName.Text, mapper[arenaType.SelectedValue], level.Text, prize.Text, fleet,
                                                  new SectorCoordinate(sysX.Text, sysY.Text, secX.Text, secY.Text));
            if (res.Ok)
            {
                message.Text = LanguageManager.Instance.Get(res.Passed[0].Name);
            }
            else
            {
                message.Text = LanguageManager.Instance.Get(res.Failed[0].Name);
            }
        }

        private int GetValue(TextBox input)
        {
            int toReturn;
            if (string.IsNullOrEmpty(input.Text))
            {
                toReturn = 0;
            }
            else
            {
                toReturn = Convert.ToInt32(input.Text);
            }
            return toReturn;
        }
    }
}
