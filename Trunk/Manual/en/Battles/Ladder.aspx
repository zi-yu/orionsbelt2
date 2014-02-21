<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ladder
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>War Zone</h2><ul><li><a href='/en/Battles/Tournaments.aspx'>Tournaments</a></li><li><a href='/en/Battles/Ladder.aspx'>Ladder</a></li><li><a href='/en/Battles/Friendly.aspx'>Friendly</a></li><li><a href='/en/Battles/ELO.aspx'>ELO Ranking</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ladder</h1>
<div class="content">
    The <a href='/en/Battles/Ladder.aspx'>Ladder</a> represents the most proficient active players on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>. When you start the game, 
    you go to the last <a href='/en/Battles/Ladder.aspx'>Ladder</a> position. Then, you may challenge a player on a superior position. If you
    win the match, you'll exchange places with him/her. The ultimate objective is to reach the first position and
    mantain it.
  </div>
	
</asp:Content>