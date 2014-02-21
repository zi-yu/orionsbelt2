<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Conquistar
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Conquistar</h1>
	
	<div class="content">
    <a href='/es/Universe/Conquer.aspx'>Conquistar</a> is the act of conquering a planet that already has an owner. To <a href='/es/Universe/Conquer.aspx'>Conquistar</a> a <a href='/es/Universe/Planets.aspx'>Planeta</a> you must move a <a href='/es/Universe/Fleet.aspx'>Flota</a> to the target <a href='/es/Universe/Planets.aspx'>Planeta</a>.
    <p />
    When you try to colonize a <a href='/es/Universe/Conquer.aspx'>Conquistar</a> two things can happen:
    <ul><li>The <a href='/es/Universe/Planets.aspx'>Planeta</a> has an owner but hasn't any defenses. In this case the <a href='/es/Universe/Planets.aspx'>Planeta</a> is automatically conquered.</li><li>The <a href='/es/Universe/Planets.aspx'>Planeta</a> has an owner and has defenses. In this case a battle will start with the owner of the <a href='/es/Universe/Planets.aspx'>Planeta</a>.</li></ul><p />
    In both cases, the menu below will appear:
    <p /><img src="/Resources/Images/en/Conquer2.png" alt="Conquer a planet" /><p />
    Notice that in the above menu an option "Raid Planet" appeared. You can find more information about this option in the <a href='/es/Universe/Raids.aspx'>Saqueo</a> page.
   </div>
	
</asp:Content>