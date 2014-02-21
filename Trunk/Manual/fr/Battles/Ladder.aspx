<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Échelle
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zone de Guerre</h2><ul><li><a href='/fr/Battles/Tournaments.aspx'>Tournois</a></li><li><a href='/fr/Battles/Ladder.aspx'>Échelle</a></li><li><a href='/fr/Battles/Friendly.aspx'>Amical</a></li><li><a href='/fr/Battles/ELO.aspx'>Classification ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ladder</h1>
<div class="content">
    L'<a href='/fr/Battles/Ladder.aspx'>Échelle</a> permet de représenter les joueurs actifs les plus efficace sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>. Vous débutez le jeu en dernière position de <a href='/fr/Battles/Ladder.aspx'>Échelle</a>. Ensuite, vous pouvez défier des joueurs en une position supérieur. Si vous gagnez le match, vous changez de position avec ce joueur. L'objectif ultime est d'attaindre la première position et d'y rester.
  </div>
	
</asp:Content>