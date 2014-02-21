<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attack
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<h1>Attack</h1>
	<div class="content">
    In order to attack something in the <a href='/en/Universe/Default.aspx'>Universe</a>, you must have a <a href='/en/Universe/Fleet.aspx'>Fleet</a> with units inside.
    <p />
    To attack another player simply select your <a href='/en/Universe/Fleet.aspx'>Fleet</a> and click above the other player <a href='/en/Universe/Fleet.aspx'>Fleet</a> or <a href='/en/Universe/Planets.aspx'>Planet</a>.
    <p />
    If you click over a <a href='/en/Universe/Fleet.aspx'>Fleet</a>, the following menu will appear:
    <p /><img src="/Resources/Images/en/AttackFleet.png" alt="Attack a Fleet" /><p />
    After you click in the option 'Attack', the <a href='/en/Universe/Fleet.aspx'>Fleet</a> will start moving and engage the enemy <a href='/en/Universe/Fleet.aspx'>Fleet</a>.
    <p />
    If the target <a href='/en/Universe/Fleet.aspx'>Fleet</a> is moving, a diferent option will appear:
    <p /><img src="/Resources/Images/en/AttackPursuit.png" alt="Pursuit a Fleet" /><p />
    This means that your <a href='/en/Universe/Fleet.aspx'>Fleet</a> will pursuit the target <a href='/en/Universe/Fleet.aspx'>Fleet</a> until it is attacked.
    <p />
    When your <a href='/en/Universe/Fleet.aspx'>Fleet</a> attacks a <a href='/en/Universe/Planets.aspx'>Planet</a>, the following options will appear:
    <img src="/Resources/Images/en/Conquer2.png" alt="Attack a Planet" /><p />
    These options mean:
    <ul><li>Attack <a href='/en/Universe/Planets.aspx'>Planet</a> and <a href='/en/Universe/Conquer.aspx'>Conquer</a>: If there is no defense you <a href='/en/Universe/Conquer.aspx'>Conquer</a> the <a href='/en/Universe/Planets.aspx'>Planet</a> immediattly. Otherside, a [Battle] is started</li><li>Raid <a href='/en/Universe/Planets.aspx'>Planet</a>: If there is no defense units, you steal the resources without a [Battle]. Otherside, a [Battle] is started and you only steal the resources if you win it. In this case, the <a href='/en/Universe/Planets.aspx'>Planet</a> isn't conquered.</li></ul></div>
</asp:Content>