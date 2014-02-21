using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore.TournamentCreators;
using OrionsBelt.WebComponents;
using System;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.Engine.Tournament;
using Loki.DataRepresentation;
using System.Web.Security;
using System.IO;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface {

    public class CreateTournament : Page 
    {
        private readonly Dictionary<string, CreatorHandler> mapper = new Dictionary<string, CreatorHandler>(6);
        private delegate Core.Tournament CreatorHandler(string name, string prize, int credits, int fleetId, bool isPublic,
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo, bool isCustom);
		protected DisplayUnits displayUnits;
        protected DropDownList tournamentType;
        protected HtmlInputSubmit create;
        protected Button Button1;
        //        <asp:Button CausesValidation="true" UseSubmitBehavior="true" ID="create" OnClick="CreateClick" runat="server" />
        protected TextBox tournamentName, prize, credits, turnTime, registTime, registPlayers, minRegistPlayers, playoffNum, maxElo, minElo;
        protected CheckBox isPublic, isSurvival;
        protected RegularExpressionValidator creditsValidator, registPlayersValidator,
            turnTimeValidator, registTimeValidator, playoffNumValidator, maxEloValidator, minEloValidator, registMinPlayersValidator;
        protected CustomValidator invalidQuantity,minMaxValidator;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            tournamentType.Items.Add(LanguageManager.Instance.Get("Annihalation"));
            tournamentType.Items.Add(LanguageManager.Instance.Get("Regicide"));
            tournamentType.Items.Add(LanguageManager.Instance.Get("Domination"));
            tournamentType.Items.Add(LanguageManager.Instance.Get("Annihalation4"));
            tournamentType.Items.Add(LanguageManager.Instance.Get("Regicide4"));
            tournamentType.Items.Add(LanguageManager.Instance.Get("Domination4"));

            create.Value = LanguageManager.Instance.Get("Create");
			create.ServerClick += new EventHandler(CreateClick);

            mapper.Add(LanguageManager.Instance.Get("Annihalation"), TournamentManager.CreateAnnihalationTournament);
            mapper.Add(LanguageManager.Instance.Get("Regicide"), TournamentManager.CreateRegicideTournament);
            mapper.Add(LanguageManager.Instance.Get("Domination"), TournamentManager.CreateDominationTournament);
            mapper.Add(LanguageManager.Instance.Get("Annihalation4"), TournamentManager.CreateAnnihalation4Tournament);
            mapper.Add(LanguageManager.Instance.Get("Regicide4"), TournamentManager.CreateRegicide4Tournament);
            mapper.Add(LanguageManager.Instance.Get("Domination4"), TournamentManager.CreateDomination4Tournament);

            creditsValidator.Text = LanguageManager.Instance.Get("NumericValue");
            turnTimeValidator.Text = LanguageManager.Instance.Get("NumericValue");
            registTimeValidator.Text = LanguageManager.Instance.Get("Default30Days");
            registPlayersValidator.Text = LanguageManager.Instance.Get("NumericValue");
            playoffNumValidator.Text = LanguageManager.Instance.Get("NumericValue");
            maxEloValidator.Text = LanguageManager.Instance.Get("NumericValue");
            minEloValidator.Text = LanguageManager.Instance.Get("NumericValue");
            minMaxValidator.Text = LanguageManager.Instance.Get("MinGreaterValidator");
            invalidQuantity.Text = LanguageManager.Instance.Get("InvalidNumber");
            registMinPlayersValidator.Text = LanguageManager.Instance.Get("NumericValue");
        }

		protected void CreateClick( object sender, EventArgs e )
        {
            if (!Page.IsValid)
            {
                return;
            }

            int cred, turn, regTime, regPlayer, playoff, maxiElo, miniElo, minReg;

            cred = GetValue(credits);
            turn = GetValuePerHour(turnTime);
            regTime = GetValuePerDay(registTime);
            regPlayer = GetValue(registPlayers);
            minReg = GetValue(minRegistPlayers);
            playoff = GetValue(playoffNum);
		    maxiElo = GetValue(maxElo);
            miniElo = GetValue(minElo);
			IFleetInfo units = displayUnits.GetUnits();
            units.TournamentFleet = true;
            GameEngine.Persist(units);
		    Fleet fleet = units.Storage;
            if (regTime > 0)
            {
                regTime += TickClock.Instance.Tick;
            }
            mapper[tournamentType.SelectedItem.Text](tournamentName.Text, prize.Text, cred, fleet.Id,
                                                isPublic.Checked, isSurvival.Checked, turn,
                                                regTime, regPlayer, minReg, playoff, maxiElo, miniElo,true);
        }

        protected void ValidateQuantity(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(playoffNum.Text))
            {
                args.IsValid = false;
                return;
            }
            for (int limit = 4; limit <= 64; )
            {
                if (limit == Convert.ToInt32(playoffNum.Text))
                {
                    args.IsValid = true;
                    return;
                }
                limit *= 2;
            }
            args.IsValid = false;

        } 
        
        protected void ValidateMinMax(object source, ServerValidateEventArgs args)
        {
            int max, min;
            if (string.IsNullOrEmpty(registPlayers.Text) || string.IsNullOrEmpty(minRegistPlayers.Text))
            {
                args.IsValid = true;
                return;
            }
            if (!int.TryParse(registPlayers.Text, out max) || !int.TryParse(minRegistPlayers.Text, out min))
            {
                return;
            }

            args.IsValid = (Convert.ToInt32(max) >= Convert.ToInt32(min));
        }

        #region Private Methods

       

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

        private int GetValuePerHour(TextBox input)
        {
            int toReturn;
            if (string.IsNullOrEmpty(input.Text))
            {
                toReturn = Clock.Instance.ConvertToTicks(TimeSpan.FromDays(1));
            }
            else
            {
                toReturn = Clock.Instance.ConvertToTicks(TimeSpan.FromHours(Convert.ToDouble(input.Text)));
            }
            return toReturn;
        }
        private int GetValuePerDay(TextBox input)
        {
            int toReturn;
            if (string.IsNullOrEmpty(input.Text))
            {
                return 0;
            }
            else
            {
                toReturn = Clock.Instance.ConvertToTicks(TimeSpan.FromDays(Convert.ToInt32(input.Text)));
            }
            return toReturn;
        }

        #endregion Private Methods
    }
}
