<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Clasificación ELO
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zona de Batallas</h2><ul><li><a href='/es/Battles/Tournaments.aspx'>Torneos</a></li><li><a href='/es/Battles/Ladder.aspx'>Escala</a></li><li><a href='/es/Battles/Friendly.aspx'>Amistoso</a></li><li><a href='/es/Battles/ELO.aspx'>Clasificación ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>ELO Ranking System</h1>
<div class="content">
    The <a href='http://www.orionsbelt.eu'>Orion's Belt</a> ELO is a ranking system that measures the skill level of players. The more ELO a player has, the 
    more proficient he is on the <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>. A player's elo is updated on every <a href='/es/Battles/Tournaments.aspx'>Torneo</a> and <a href='/es/Battles/Ladder.aspx'>Escala</a> match.
    <p />
    The <a href='http://www.orionsbelt.eu'>Orion's Belt</a> ELO implementation is based on the <a href="http://en.wikipedia.org/wiki/Elo_rating_system">ELO Rating System</a>
    used on chess.
  </div>
	
</asp:Content>