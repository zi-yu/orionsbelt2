<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Flota
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Fleets</h1>
<div class="content">
    A <a href='/es/Universe/Fleet.aspx'>Flota</a> is a group of <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> that can <a href='/es/Universe/Travel.aspx'>Viajar</a> on the <a href='/es/Universe/Default.aspx'>Universo</a>. There are several types of
    fleets:
    <ul><li>Defense Fleets: every <a href='/es/Universe/Planets.aspx'>Planeta</a> has a defense fleet. This fleet isn't movable and it's only used
  when the planet is attacked</li><li>Movable Fleets: on your <a href='/es/Universe/Planets.aspx'>Planetas</a> you can create fleets and use them to <a href='/es/Universe/Travel.aspx'>Viajar</a> on the <a href='/es/Universe/Default.aspx'>Universo</a></li><li>Ultimate Fleets: if a fleet has a <a href='/es/Battles/Ultimate.aspx'>Suprema</a> unit, it's called a ultimate fleet</li></ul><h2>How to Create a Fleet?</h2>
    First of all, you need to build <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> on one of your <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> planets. When they're finished,
    they will be placed on the planet's defense fleet. Then you can go the the
    <i>Fleets</i> section of that planet and create a new one. After that you may move <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> from the 
    planet's defense fleet info your new fleet.
    <p />
    A <a href='/es/Universe/Fleet.aspx'>Flota</a> can only move if it has <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> and it's idle at the moment.
    
    <h2>What can Fleets do?</h2>
    The first usage of a fleet is just to <a href='/es/Universe/Travel.aspx'>Viajar</a> on your <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a>. You'll be able to discover each
    zone because of the fleet's <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a>. You'll also be able to grab <a href='/es/IntrinsicIndex.aspx'>Intrínseco</a> resources and colonize
    other <a href='/es/Universe/Planets.aspx'>Planetas</a>. When you're up for it, you may use the <a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a> to <a href='/es/Universe/Travel.aspx'>Viajar</a> to the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a>.
    <p />
    On the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> you'll be abble to attack other fleets, <a href='/es/Universe/Raids.aspx'>Saqueo</a> planets, perform <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> and much more. 
    
    <h2>Fleet's Cargo</h2>
    Each fleet has a cargo hole that can store <a href='/es/IntrinsicIndex.aspx'>Intrínseco</a> resources. When your fleet has something on the cargo,
    you can go to one of your planets to unload that cargo into your resources. Note that if you're attacked
    and lose, your opponent will earn your cargo as loot.
    <p />
    Your home planet's defense fleet is also used to store resources you buy at the <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a>.

    <h2>Fleet's Colors</h2>
    On the <a href='/es/Universe/Default.aspx'>Universo</a> view you'll see several <a href='/es/Universe/Fleet.aspx'>Flotas</a> with different colors. Each color has it's own meaning, and
    depends on your diplomatic status with the fleet's owner <a href='/es/Universe/Alliance.aspx'>Alianza</a>:
    <ul><li>Color Gray: you are neutral to that player</li><li>Color Yellow: you are on a non aggression pact with that player's alliance</li><li>Color Blue: you are allied with that player</li><li>Color Red: That fleet is your enemy!</li></ul></div>
	
</asp:Content>