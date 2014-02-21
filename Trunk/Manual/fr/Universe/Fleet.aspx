<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Escadrile
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Fleets</h1>
<div class="content">
    A <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> is a group of <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> that can <a href='/fr/Universe/Travel.aspx'>Voyage</a> on the <a href='/fr/Universe/Default.aspx'>Univers</a>. There are several types of
    fleets:
    <ul><li>Defense Fleets: every <a href='/fr/Universe/Planets.aspx'>Planète</a> has a defense fleet. This fleet isn't movable and it's only used
  when the planet is attacked</li><li>Movable Fleets: on your <a href='/fr/Universe/Planets.aspx'>Planètes</a> you can create fleets and use them to <a href='/fr/Universe/Travel.aspx'>Voyage</a> on the <a href='/fr/Universe/Default.aspx'>Univers</a></li><li>Ultimate Fleets: if a fleet has a <a href='/fr/Battles/Ultimate.aspx'>Ultime</a> unit, it's called a ultimate fleet</li></ul><h2>How to Create a Fleet?</h2>
    First of all, you need to build <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> on one of your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> planets. When they're finished,
    they will be placed on the planet's defense fleet. Then you can go the the
    <i>Fleets</i> section of that planet and create a new one. After that you may move <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> from the 
    planet's defense fleet info your new fleet.
    <p />
    A <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> can only move if it has <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> and it's idle at the moment.
    
    <h2>What can Fleets do?</h2>
    The first usage of a fleet is just to <a href='/fr/Universe/Travel.aspx'>Voyage</a> on your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>. You'll be able to discover each
    zone because of the fleet's <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a>. You'll also be able to grab <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a> resources and colonize
    other <a href='/fr/Universe/Planets.aspx'>Planètes</a>. When you're up for it, you may use the <a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a> to <a href='/fr/Universe/Travel.aspx'>Voyage</a> to the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a>.
    <p />
    On the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> you'll be abble to attack other fleets, <a href='/fr/Universe/Raids.aspx'>Pillage</a> planets, perform <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> and much more. 
    
    <h2>Fleet's Cargo</h2>
    Each fleet has a cargo hole that can store <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a> resources. When your fleet has something on the cargo,
    you can go to one of your planets to unload that cargo into your resources. Note that if you're attacked
    and lose, your opponent will earn your cargo as loot.
    <p />
    Your home planet's defense fleet is also used to store resources you buy at the <a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a>.

    <h2>Fleet's Colors</h2>
    On the <a href='/fr/Universe/Default.aspx'>Univers</a> view you'll see several <a href='/fr/Universe/Fleet.aspx'>Escadrilles</a> with different colors. Each color has it's own meaning, and
    depends on your diplomatic status with the fleet's owner <a href='/fr/Universe/Alliance.aspx'>Alliance</a>:
    <ul><li>Color Gray: you are neutral to that player</li><li>Color Yellow: you are on a non aggression pact with that player's alliance</li><li>Color Blue: you are allied with that player</li><li>Color Red: That fleet is your enemy!</li></ul></div>
	
</asp:Content>