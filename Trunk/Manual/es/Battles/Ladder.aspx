<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Escala
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Zona de Batallas</h2><ul><li><a href='/es/Battles/Tournaments.aspx'>Torneos</a></li><li><a href='/es/Battles/Ladder.aspx'>Escala</a></li><li><a href='/es/Battles/Friendly.aspx'>Amistoso</a></li><li><a href='/es/Battles/ELO.aspx'>Clasificación ELO</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ladder</h1>
<div class="content">
    The <a href='/es/Battles/Ladder.aspx'>Escala</a> represents the most proficient active players on the <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>. When you start the game, 
    you go to the last <a href='/es/Battles/Ladder.aspx'>Escala</a> position. Then, you may challenge a player on a superior position. If you
    win the match, you'll exchange places with him/her. The ultimate objective is to reach the first position and
    mantain it.
  </div>
	
</asp:Content>