<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<h1>Ataque</h1>
	<div class="content">
    In order to attack something in the <a href='/es/Universe/Default.aspx'>Universo</a>, you must have a <a href='/es/Universe/Fleet.aspx'>Flota</a> with units inside.
    <p />
    To attack another player simply select your <a href='/es/Universe/Fleet.aspx'>Flota</a> and click above the other player <a href='/es/Universe/Fleet.aspx'>Flota</a> or <a href='/es/Universe/Planets.aspx'>Planeta</a>.
    <p />
    If you click over a <a href='/es/Universe/Fleet.aspx'>Flota</a>, the following menu will appear:
    <p /><img src="/Resources/Images/en/AttackFleet.png" alt="Attack a Fleet" /><p />
    After you click in the option 'Attack', the <a href='/es/Universe/Fleet.aspx'>Flota</a> will start moving and engage the enemy <a href='/es/Universe/Fleet.aspx'>Flota</a>.
    <p />
    If the target <a href='/es/Universe/Fleet.aspx'>Flota</a> is moving, a diferent option will appear:
    <p /><img src="/Resources/Images/en/AttackPursuit.png" alt="Pursuit a Fleet" /><p />
    This means that your <a href='/es/Universe/Fleet.aspx'>Flota</a> will pursuit the target <a href='/es/Universe/Fleet.aspx'>Flota</a> until it is attacked.
    <p />
    When your <a href='/es/Universe/Fleet.aspx'>Flota</a> attacks a <a href='/es/Universe/Planets.aspx'>Planeta</a>, the following options will appear:
    <img src="/Resources/Images/en/Conquer2.png" alt="Attack a Planet" /><p />
    These options mean:
    <ul><li>Attack <a href='/es/Universe/Planets.aspx'>Planeta</a> and <a href='/es/Universe/Conquer.aspx'>Conquistar</a>: If there is no defense you <a href='/es/Universe/Conquer.aspx'>Conquistar</a> the <a href='/es/Universe/Planets.aspx'>Planeta</a> immediattly. Otherside, a [Battle] is started</li><li>Raid <a href='/es/Universe/Planets.aspx'>Planeta</a>: If there is no defense units, you steal the resources without a [Battle]. Otherside, a [Battle] is started and you only steal the resources if you win it. In this case, the <a href='/es/Universe/Planets.aspx'>Planeta</a> isn't conquered.</li></ul></div>
</asp:Content>