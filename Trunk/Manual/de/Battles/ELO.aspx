<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	ELO Rangliste
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kriegs-Zone</h2><ul><li><a href='/de/Battles/Tournaments.aspx'>Turniere</a></li><li><a href='/de/Battles/Ladder.aspx'>Rangliste</a></li><li><a href='/de/Battles/Friendly.aspx'>Freundliches Match</a></li><li><a href='/de/Battles/ELO.aspx'>ELO Rangliste</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>ELO Ranglisten System</h1>
<div class="content">
    Das <a href='http://www.orionsbelt.eu'>Orion's Belt</a> ELO ist ein Ranglisten System das das Fähigkeitslevel der Spieler misst. Je mehr ELO ein Spieler hat, umso kompetenter wird er auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> sein. Das Spieler Elo wird in jedem <a href='/de/Battles/Tournaments.aspx'>Turnier</a> und <a href='/de/Battles/Ladder.aspx'>Rangliste</a> Match aktualisiert.
    <p>
    Die <a href='http://www.orionsbelt.eu'>Orion's Belt</a> ELO Implementation basiert auf <a href="http://en.wikipedia.org/wiki/Elo_rating_system">ELO Ranglisten System</a>
    wie beim Schachspiel.
  </p></div>
	
</asp:Content>