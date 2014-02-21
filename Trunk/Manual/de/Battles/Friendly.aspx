<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Freundliches Match
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kriegs-Zone</h2><ul><li><a href='/de/Battles/Tournaments.aspx'>Turniere</a></li><li><a href='/de/Battles/Ladder.aspx'>Rangliste</a></li><li><a href='/de/Battles/Friendly.aspx'>Freundliches Match</a></li><li><a href='/de/Battles/ELO.aspx'>ELO Rangliste</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Freundliches Match</h1>
	<div class="content">
    Ein <a href='/de/Battles/Friendly.aspx'>Freundliches Match</a> ist ein Match auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> nur so zum Spass oder zum Üben benutzen kannst. 
    Du kannst die Kampf- <a href='/de/Universe/Fleet.aspx'>Flotte</a> auswählen und dein Gegner. Diese Schlachten werden nicht in dein <a href='/de/Battles/ELO.aspx'>ELO Rangliste</a> 
    miteinkalkuliert.
    <p>
    Du kannst diese Schlachten benutzen um neue <a href='/de/Battles/BattleTactics.aspx'>Kampf-Taktiken</a> auszuprobieren, Lerne einige 
    <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> kennen oder übe für <a href='/de/Battles/Tournaments.aspx'>Turniere</a>.
  </p></div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Eagle.png" />
	
</asp:Content>