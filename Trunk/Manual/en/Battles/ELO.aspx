<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	ELO Ranking
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>War Zone</h2><ul><li><a href='/en/Battles/Tournaments.aspx'>Tournaments</a></li><li><a href='/en/Battles/Ladder.aspx'>Ladder</a></li><li><a href='/en/Battles/Friendly.aspx'>Friendly</a></li><li><a href='/en/Battles/ELO.aspx'>ELO Ranking</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>ELO Ranking System</h1>
<div class="content">
    The <a href='http://www.orionsbelt.eu'>Orion's Belt</a> ELO is a ranking system that measures the skill level of players. The more ELO a player has, the 
    more proficient he is on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>. A player's elo is updated on every <a href='/en/Battles/Tournaments.aspx'>Tournament</a> and <a href='/en/Battles/Ladder.aspx'>Ladder</a> match.
    <p />
    The <a href='http://www.orionsbelt.eu'>Orion's Belt</a> ELO implementation is based on the <a href="http://en.wikipedia.org/wiki/Elo_rating_system">ELO Rating System</a>
    used on chess.
  </div>
	
</asp:Content>