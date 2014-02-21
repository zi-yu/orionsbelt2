using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class DisplayUnits: ControlBase {

        #region Fields

        private static readonly BattleType[] types = new BattleType[]{ BattleType.TotalAnnihalation, BattleType.Regicide/*, BattleType.Domination*/};

        #endregion Fields

        #region Private

        private void WriteTitle(string type) {
			Write("<tr>");
			Write("<th>#</th>");
			Write("<th>{0}</th>", LanguageManager.Instance.Get(type));
			Write("<th>{0}</th>", LanguageManager.Instance.Get("YourQuantity"));
            Write("<th>{0}</th>", LanguageManager.Instance.Get("OpponentQuantity"));
			Write("</tr>");
		}

		#region Normal Units

		private void WriteTable(string type, List<BaseUnit> units) {
			Write("<table class='newtable'>");
			WriteTitle(type);
			WriteUnits(units);
			Write("</table>");
		}

		private void WriteUnits(List<BaseUnit> units) {
			foreach (BaseUnit unit in units) {
				if (unit.IsShowable) {
					Write("<tr>");
					WriterUnit(unit);
					Write("</tr>");
				}
			}
		}

		private void WriterUnit(BaseUnit unit) {
			Write("<td><img class='smallImage' src='{0}' alt='{1}' title='{1}'</td>", ResourcesManager.GetUnitImage(unit.Name), unit.Name);
			Write("<td>{0}</td>", unit.Name);
			Write("<td>");
			TextBox box = new TextBox();
			box.Attributes.Add("unit", unit.Name);
			Controls.Add(box);
			Write("</td>");
            Write("<td>");
            TextBox box2 = new TextBox();
            box2.Attributes.Add("opponent", unit.Name);
            Controls.Add(box2);
            Write("</td>");
		} 

		#endregion Normal units

		#region Ultimate Units

		private void WriteUltimateTable(string type, List<BaseUnit> units) {
            Write("<table class='newtable'>");
			WriteTitle(type);
			WriteUltimateUnits(units);
			Write("</table>");
		}

		private void WriteUltimateUnits(List<BaseUnit> units) {
		    IList<string> opponentCB = new List<string>();
			StringWriter writer = new StringWriter();
            writer.Write("<script type='text/javascript'>var selectedCheckBox = ['{0}'", WriterUltimateUnit(units[0], opponentCB));
			for (int i = 1; i < units.Count; ++i ) {
				BaseUnit unit = units[i];
                writer.Write(",'{0}'", WriterUltimateUnit(unit, opponentCB));
			}
            writer.Write("];var selectedOpponentCheckBox = ['{0}'", opponentCB[0]);
            for (int i = 1; i < units.Count; ++i)
            {
                writer.Write(",'{0}'", opponentCB[i]);
            }

            writer.Write("];</script>");
			Controls.Add(new LiteralControl(writer.ToString()));

			writer.ToString();
		}

        private string WriterUltimateUnit(BaseUnit unit, IList<string> opponentCB)
        {
			Write("<tr>");
			Write("<td><img class='smallImage' src='{0}' alt='{1}' title='{1}'</td>", ResourcesManager.GetUnitImage(unit.Name), unit.Name);
			Write("<td>{0}</td>", unit.Name);
			Write("<td>");
			CheckBox box = new CheckBox();
			box.Attributes.Add("onclick","Site.onUltimateChange(this);");
			box.Attributes.Add("unit", unit.Name);
			Controls.Add(box);
			Write("</td>");

            Write("<td>");
            CheckBox box2 = new CheckBox();
            box2.Attributes.Add("onclick", "Site.onOpponentUltimateChange(this);");
            box2.Attributes.Add("opponent", unit.Name);
            Controls.Add(box2);
            Write("</td>");

			Write("</tr>");
            opponentCB.Add(box2.ClientID);
			return box.ClientID;
		}

		#endregion Ultimate Units

        #region Battle types

        private void WriteBattleTypeTitle(){
            Write("<tr>");
            Write("<th colspan='2'>{0}</th>", LanguageManager.Instance.Get("BattleType"));
            Write("</tr>");
        }

        private void WriteBattleTypesTable(){
            Write("<table class='newtable'>");
            WriteBattleTypeTitle();
            WriteBattleTypes();
            Write("</table>");
        }

        private void WriteBattleTypes(){
            StringWriter writer = new StringWriter();
            writer.Write("<script type='text/javascript'>var selectedBattleTypeCheckBox = ['{0}'", WriterBattleType(types[0],true));
            for (int i = 1; i < types.Length; ++i){
                BattleType type = types[i];
                writer.Write(",'{0}'", WriterBattleType(type,false) );
            }
            writer.Write("];</script>");
            Controls.Add(new LiteralControl(writer.ToString()));

            writer.ToString();
        }

        private string WriterBattleType(BattleType type, bool isChecked){
            Write("<tr>");
            Write("<td>{0}</td>", LanguageManager.Instance.Get(type.ToString()));
            Write("<td>");
            CheckBox box = new CheckBox();
            box.Checked = isChecked;
            box.Attributes.Add("onclick", "Site.onBattleTypeChange(this);");
            box.Attributes.Add("type", type.ToString());
            Controls.Add(box);
            Write("</td>");
            Write("</tr>");
            return box.ClientID;
        }

        #endregion Battle types

		private static void GetUnits(FleetInfo fleetInfo, ControlCollection controls, string player) {
			foreach (Control control in controls) {
				if (control is TextBox) {
                    GetTextBox(control, fleetInfo, player);
					continue;
				}
				if (control is CheckBox) {
                    GetCheckBox(control, fleetInfo, player);
					continue;
				}

				if (control.Controls.Count > 0) {
                    GetUnits(fleetInfo, control.Controls, player);
				}
			}
		}

        private static void GetTextBox(Control control, FleetInfo fleetInfo, string player)
        {
			TextBox t = (TextBox)control;
			string text = t.Text;
			if (!string.IsNullOrEmpty(text)) {
				int value;
				if (int.TryParse(text, out value) && value > 0) {
                    if (t.Attributes[player] != null)
                    {
                        fleetInfo.Add(t.Attributes[player], value);
                    }
				} else {
                    ErrorBoard.AddLocalizedMessage("InvalidUnitValue", t.Attributes[player]);
					throw new OrionsBeltException("InvalidUnitValue");
				}
			}
		}

        private static void GetCheckBox(Control control, FleetInfo fleetInfo, string player)
        {
			CheckBox t = (CheckBox)control;
			if (t.Checked) {
                if (t.Attributes[player] != null)
                {
                    fleetInfo.AddUltimate(t.Attributes[player]);
				}
			}
		}

		public static string GetBattleType(ControlCollection controls) {
			foreach (Control control in controls) {
				if (control is CheckBox) {
					CheckBox t = (CheckBox)control;
					if (t.Checked) {
						if (t.Attributes["type"] != null) {
							return t.Attributes["type"];
						}
					}
					continue;
				}
				if (control.Controls.Count > 0) {
					GetBattleType(control.Controls);
				}
			}
			return null;
		}

        #endregion Private

        #region Public

        public IFleetInfo GetUnits() {
			FleetInfo fleetInfo = new FleetInfo("Fleet");
			GetUnits(fleetInfo, Controls, "unit");

			if( !fleetInfo.HasUnits ) {
				ErrorBoard.AddLocalizedMessage("ChooseAtLeastOneUnit");
				throw new OrionsBeltException("ChooseAtLeastOneUnit");
			}
			if( fleetInfo.Units.Count > 8 ) {
				ErrorBoard.AddLocalizedMessage("Maximum8Units");
				throw new OrionsBeltException("Maximum8Units");
			}

			return fleetInfo;
		}

        public IFleetInfo GetOpponentUnits()
        {
            FleetInfo fleetInfo = new FleetInfo("Fleet");
            GetUnits(fleetInfo, Controls, "opponent");

            if (!fleetInfo.HasUnits)
            {
                ErrorBoard.AddLocalizedMessage("ChooseAtLeastOneUnit");
                throw new OrionsBeltException("ChooseAtLeastOneUnit");
            }
            if (fleetInfo.Units.Count > 8)
            {
                ErrorBoard.AddLocalizedMessage("Maximum8Units");
                throw new OrionsBeltException("Maximum8Units");
            }

            return fleetInfo;
        }

		public string GetBattleType() {
			return GetBattleType(Controls);
		}

		#endregion

		#region Control Events

		protected override void OnInit( EventArgs e ) {
			WriteTable("LightUnits", Units.Light);
			WriteTable("MediumUnits", Units.Medium);
			WriteTable("HeavyUnits", Units.Heavy);
			WriteUltimateTable("UltimateUnit", Units.Ultimate);
            WriteBattleTypesTable();
		}

		#endregion Control Events

	}
}
