<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Fleet
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Fleets</h1>
<div class="content">
    A <a href='/en/Universe/Fleet.aspx'>Fleet</a> is a group of <a href='/en/UnitIndex.aspx'>Combat Units</a> that can <a href='/en/Universe/Travel.aspx'>Travel</a> on the <a href='/en/Universe/Default.aspx'>Universe</a>. There are several types of
    fleets:
    <ul><li>Defense Fleets: every <a href='/en/Universe/Planets.aspx'>Planet</a> has a defense fleet. This fleet isn't movable and it's only used
  when the planet is attacked</li><li>Movable Fleets: on your <a href='/en/Universe/Planets.aspx'>Planets</a> you can create fleets and use them to <a href='/en/Universe/Travel.aspx'>Travel</a> on the <a href='/en/Universe/Default.aspx'>Universe</a></li><li>Ultimate Fleets: if a fleet has a <a href='/en/Battles/Ultimate.aspx'>Ultimate</a> unit, it's called a ultimate fleet</li></ul><h2>How to Create a Fleet?</h2>
    First of all, you need to build <a href='/en/UnitIndex.aspx'>Combat Units</a> on one of your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets. When they're finished,
    they will be placed on the planet's defense fleet. Then you can go the the
    <i>Fleets</i> section of that planet and create a new one. After that you may move <a href='/en/UnitIndex.aspx'>Combat Units</a> from the 
    planet's defense fleet info your new fleet.
    <p />
    A <a href='/en/Universe/Fleet.aspx'>Fleet</a> can only move if it has <a href='/en/UnitIndex.aspx'>Combat Units</a> and it's idle at the moment.
    
    <h2>What can Fleets do?</h2>
    The first usage of a fleet is just to <a href='/en/Universe/Travel.aspx'>Travel</a> on your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a>. You'll be able to discover each
    zone because of the fleet's <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a>. You'll also be able to grab <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a> resources and colonize
    other <a href='/en/Universe/Planets.aspx'>Planets</a>. When you're up for it, you may use the <a href='/en/Universe/WormHole.aspx'>WormHole</a> to <a href='/en/Universe/Travel.aspx'>Travel</a> to the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a>.
    <p />
    On the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> you'll be abble to attack other fleets, <a href='/en/Universe/Raids.aspx'>Raid</a> planets, perform <a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a> and much more. 
    
    <h2>Fleet's Cargo</h2>
    Each fleet has a cargo hole that can store <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a> resources. When your fleet has something on the cargo,
    you can go to one of your planets to unload that cargo into your resources. Note that if you're attacked
    and lose, your opponent will earn your cargo as loot.
    <p />
    Your home planet's defense fleet is also used to store resources you buy at the <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a>.

    <h2>Fleet's Colors</h2>
    On the <a href='/en/Universe/Default.aspx'>Universe</a> view you'll see several <a href='/en/Universe/Fleet.aspx'>Fleets</a> with different colors. Each color has it's own meaning, and
    depends on your diplomatic status with the fleet's owner <a href='/en/Universe/Alliance.aspx'>Alliance</a>:
    <ul><li>Color Gray: you are neutral to that player</li><li>Color Yellow: you are on a non aggression pact with that player's alliance</li><li>Color Blue: you are allied with that player</li><li>Color Red: That fleet is your enemy!</li></ul></div>
	
</asp:Content>