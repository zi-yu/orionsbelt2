<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Prijateljski
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Ratna Zona</h2><ul><li><a href='/hr/Battles/Tournaments.aspx'>Turniri</a></li><li><a href='/hr/Battles/Ladder.aspx'>Ljestvica</a></li><li><a href='/hr/Battles/Friendly.aspx'>Prijateljski</a></li><li><a href='/hr/Battles/ELO.aspx'>ELO Ranking</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Prijateljski</h1>
	<div class="content">
<a href='/hr/Battles/Friendly.aspx'>Prijateljski</a> je meč na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> kojega možete voditi samo za zabavu i vježbu. Možete izabrati <a href='/hr/Universe/Fleet.aspx'>Flota</a> bitke i vašeg protivnika. Ove bitke se ne uzimaju u obzir za vaš <a href='/hr/Battles/ELO.aspx'>ELO Ranking</a>.
<p />
Možete se koristiti ovim bitkama da provate nove <a href='/hr/Battles/BattleTactics.aspx'>Taktike Bitke</a>, da bolje upoznate neke <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> ili da vježbate za <a href='/hr/Battles/Tournaments.aspx'>Turniri</a>.
</div>
	<img class="block" src="http://resources.orionsbelt.eu/Images/Common/Units/Perspective/Eagle.png" />
	
</asp:Content>