<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Rangliste
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kriegs-Zone</h2><ul><li><a href='/de/Battles/Tournaments.aspx'>Turniere</a></li><li><a href='/de/Battles/Ladder.aspx'>Rangliste</a></li><li><a href='/de/Battles/Friendly.aspx'>Freundliches Match</a></li><li><a href='/de/Battles/ELO.aspx'>ELO Rangliste</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ladder</h1>
<div class="content">
    Die <a href='/de/Battles/Ladder.aspx'>Rangliste</a> represäntiert die fähigsten aktiven Spieler auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>. Wenn du das Spiel 
    anfängst, bist du auf der letzten <a href='/de/Battles/Ladder.aspx'>Rangliste</a> position. Danach, bist du in der Lage einen Spieler auf 
    einer höheren Position herauszufordern. Wenn du das Match gewinnst, wirst du die Plätze austauschen 
    mit ihm/ihr. Das ultimative Ziel ist die erste Position zu erreichen und zu halten.
  </div>
	
</asp:Content>