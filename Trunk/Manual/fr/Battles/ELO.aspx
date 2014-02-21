<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Classification ELO
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zone de Guerre</h2><ul><li><a href='/fr/Battles/Tournaments.aspx'>Tournois</a></li><li><a href='/fr/Battles/Ladder.aspx'>Échelle</a></li><li><a href='/fr/Battles/Friendly.aspx'>Amical</a></li><li><a href='/fr/Battles/ELO.aspx'>Classification ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>ELO Ranking System</h1>
<div class="content">
 L’ <a href='http://www.orionsbelt.eu'>Orion's Belt</a> ELO est un système de rang mesurant la force de chacun des joueurs. Plus l’ELO d’un joueur est élevé, plus il est efficace sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>. L’ELO d’un joueur est mis à jour après chaque <a href='/fr/Battles/Tournaments.aspx'>Tournoi</a> et combat pour monter dans les  <a href='/fr/Battles/Ladder.aspx'>Échelle</a> .
    <p />
    L’’implantation de l’ELO d’ <a href='http://www.orionsbelt.eu'>Orion's Belt</a> se base sur <a href="http://en.wikipedia.org/wiki/Elo_rating_system">ELO Rating System</a>
    utilisé aux échecs.
  </div>
	
</asp:Content>