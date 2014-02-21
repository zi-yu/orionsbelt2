<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Friendly
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>War Zone</h2><ul><li><a href='/en/Battles/Tournaments.aspx'>Tournaments</a></li><li><a href='/en/Battles/Ladder.aspx'>Ladder</a></li><li><a href='/en/Battles/Friendly.aspx'>Friendly</a></li><li><a href='/en/Battles/ELO.aspx'>ELO Ranking</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Friendly</h1>
	<div class="content">
    A <a href='/en/Battles/Friendly.aspx'>Friendly</a> is a match on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a> that you can do just for fun or practice. You can choose the battle <a href='/en/Universe/Fleet.aspx'>Fleet</a> and your opponent. 
    These battles aren't taken into account for your <a href='/en/Battles/ELO.aspx'>ELO Ranking</a>.
    <p />
    You can use these battles to try new <a href='/en/Battles/BattleTactics.aspx'>Battle Tactics</a>, get to know some <a href='/en/UnitIndex.aspx'>Combat Units</a> or practice for <a href='/en/Battles/Tournaments.aspx'>Tournaments</a>.
  </div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Eagle.png" />
	
</asp:Content>