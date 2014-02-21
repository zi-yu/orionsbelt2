<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	ELO Ranking
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Ratna Zona</h2><ul><li><a href='/hr/Battles/Tournaments.aspx'>Turniri</a></li><li><a href='/hr/Battles/Ladder.aspx'>Ljestvica</a></li><li><a href='/hr/Battles/Friendly.aspx'>Prijateljski</a></li><li><a href='/hr/Battles/ELO.aspx'>ELO Ranking</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>ELO Ranking Sustav</h1>
<div class="content">
<a href='http://www.orionsbelt.eu'>Orioniv Pojas</a> ELO  je ranking sustav koji mjeri nivo vještine igrača. Što više ELO igrač ima, vještiji je na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>. Igračev ELO je updatean iza svakog <a href='/hr/Battles/Tournaments.aspx'>Turnir</a> i <a href='/hr/Battles/Ladder.aspx'>Ljestvica</a> meča.
<p />
<a href='http://www.orionsbelt.eu'>Orioniv Pojas</a> ELO implementacija je bazirana na <a href="http://en.wikipedia.org/wiki/Elo_rating_system">ELO Rating System</a>
koji se koristi u šahu.
</div>
	
</asp:Content>