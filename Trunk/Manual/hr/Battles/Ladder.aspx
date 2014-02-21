<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ljestvica
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Ratna Zona</h2><ul><li><a href='/hr/Battles/Tournaments.aspx'>Turniri</a></li><li><a href='/hr/Battles/Ladder.aspx'>Ljestvica</a></li><li><a href='/hr/Battles/Friendly.aspx'>Prijateljski</a></li><li><a href='/hr/Battles/ELO.aspx'>ELO Ranking</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ljestvica</h1>
<div class="content">

<a href='/hr/Battles/Ladder.aspx'>Ljestvica</a> predstavlja najvještije aktivne igrače na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>. Kada počnete igru, idete na zadnju <a href='/hr/Battles/Ladder.aspx'>Ljestvica</a> poziciju. Tada, morate izazvati igrača na jačoj poziciji. Ako dobijete meč, zamijeneti ćete mjesta s njim. Ultimativni cilj je doseći prvu poziciju i zadržati je.
</div>
	
</asp:Content>