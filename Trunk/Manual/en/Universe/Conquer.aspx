<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Conquer
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Conquer</h1>
	
	<div class="content">
    <a href='/en/Universe/Conquer.aspx'>Conquer</a> is the act of conquering a planet that already has an owner. To <a href='/en/Universe/Conquer.aspx'>Conquer</a> a <a href='/en/Universe/Planets.aspx'>Planet</a> you must move a <a href='/en/Universe/Fleet.aspx'>Fleet</a> to the target <a href='/en/Universe/Planets.aspx'>Planet</a>.
    <p />
    When you try to colonize a <a href='/en/Universe/Conquer.aspx'>Conquer</a> two things can happen:
    <ul><li>The <a href='/en/Universe/Planets.aspx'>Planet</a> has an owner but hasn't any defenses. In this case the <a href='/en/Universe/Planets.aspx'>Planet</a> is automatically conquered.</li><li>The <a href='/en/Universe/Planets.aspx'>Planet</a> has an owner and has defenses. In this case a battle will start with the owner of the <a href='/en/Universe/Planets.aspx'>Planet</a>.</li></ul><p />
    In both cases, the menu below will appear:
    <p /><img src="/Resources/Images/en/Conquer2.png" alt="Conquer a planet" /><p />
    Notice that in the above menu an option "Raid Planet" appeared. You can find more information about this option in the <a href='/en/Universe/Raids.aspx'>Raid</a> page.
   </div>
	
</asp:Content>