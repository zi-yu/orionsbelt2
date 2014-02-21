<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Relics
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Relics</h1>
<div class="content">
    A <a href='/en/Universe/Relics.aspx'>Relic</a> is a special body on the <a href='/en/Universe/Default.aspx'>Universe</a>, specially designed for <a href='/en/Universe/Alliance.aspx'>Alliance</a> wars. When an <a href='/en/Universe/Alliance.aspx'>Alliance</a> has one or more <a href='/en/Universe/Relics.aspx'>Relics</a>,
    all alliance members will receive a rare resource per day. The income per player depends on how many relics the <a href='/en/Universe/Alliance.aspx'>Alliance</a> holds
    and his/her alliance rank.
    <p />
    The total income that the <a href='/en/Universe/Alliance.aspx'>Alliance</a> will receive is given by the following data:
    <ul><li>Each relic will contribute with K multiplied by it's <a href='/en/Universe/HotZone.aspx#levels'>Zone Level</a>; if the relic is at war, the income will be decreased up to eight times</li><li>The sum of the income from all relics is then multiplied by the percentage of relics on the universe that the alliance holds</li></ul>
    This means that more <a href='/en/Universe/Relics.aspx'>Relics</a> will give even more resources. K is an internal constant, subject to change. 
    <p />
    Each <a href='/en/Universe/Relics.aspx'>Relic</a> has its own protector: an alliance member that conquers the relic and then is responsible for defending it.
  </div>
	
</asp:Content>