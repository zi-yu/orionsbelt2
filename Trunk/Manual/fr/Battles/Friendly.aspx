<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Amical
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zone de Guerre</h2><ul><li><a href='/fr/Battles/Tournaments.aspx'>Tournois</a></li><li><a href='/fr/Battles/Ladder.aspx'>Échelle</a></li><li><a href='/fr/Battles/Friendly.aspx'>Amical</a></li><li><a href='/fr/Battles/ELO.aspx'>Classification ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Amical</h1>
	<div class="content">
    Un combat <a href='/fr/Battles/Friendly.aspx'>Amical</a> se joue sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a> mais vous pouvez faire ces combats seulement pour le plaisir ou pratiquer. Vous pouvez choisir l’<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> et votre adversaire. 
    Ces batailles n’ont aucune conséquence sur votre <a href='/fr/Battles/ELO.aspx'>Classification ELO</a>.
    <p />
    Ce type de combat est très utile pour tester de nouvelles <a href='/fr/Battles/BattleTactics.aspx'>Tactiques de Combat</a>, vous familiariser avec certaines <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> ou pratiquer pour les <a href='/fr/Battles/Tournaments.aspx'>Tournois</a>.
  </div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Eagle.png" />
	
</asp:Content>