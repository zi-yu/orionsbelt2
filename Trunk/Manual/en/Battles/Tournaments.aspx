<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Tournaments
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>War Zone</h2><ul><li><a href='/en/Battles/Tournaments.aspx'>Tournaments</a></li><li><a href='/en/Battles/Ladder.aspx'>Ladder</a></li><li><a href='/en/Battles/Friendly.aspx'>Friendly</a></li><li><a href='/en/Battles/ELO.aspx'>ELO Ranking</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Tournaments</h1>
	<div class="content">
    The <a href='/en/Battles/Tournaments.aspx'>Tournaments</a> are the ultimate battle grounds for <a href='http://www.orionsbelt.eu'>Orion's Belt</a> players. Here you'll face head to head the best players
    and you will have to prove yourself to win. You can participate on <a href='/en/Battles/Regicide.aspx'>Regicide</a> and <a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a> tournaments.
    Being good at tournaments also increases your <a href='/en/Commerce/Orions.aspx'>Orions</a>.
    
    <h2>Tournaments Structure</h2>
    There are several phases on a tournament. First the tournament is opened for subscriptions. If you met the requirements
    you'll be able to enter and you will be placed on one of ten pots. When the tournament begins, a groups phase will start.
    <p />
    On the groups phase, the first 3 players will go to the next round. We might also fetch other players if we need them
    for the playoffs.
    <p />
    After the groups you'll have the playoffs. If you loose, you're out!
  </div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Toxic.png" />
	
</asp:Content>