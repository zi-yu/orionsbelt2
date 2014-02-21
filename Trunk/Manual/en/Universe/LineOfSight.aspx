<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Line of Sight
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Line of Sight</h1>
	<div class="content">
   <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a> is the visible area around something that belongs to you (a <a href='/en/Universe/Fleet.aspx'>Fleet</a>, a <a href='/en/Universe/Planets.aspx'>Planet</a>, etc). In this area you can see everything that is moving 
   including enemy units.
   <p />
   There are 3 types of <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a>:
   <p /><ul><li>
 <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a> one square arround the <a href='/en/Universe/Fleet.aspx'>Fleet</a>. This <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a> is present in <a href='/en/Universe/Fleet.aspx'>Fleets</a> with only <a href='/en/Battles/Light.aspx'>Light</a> units.<p /><img src="/Resources/Images/LineOfSight.png" alt="Line of Sight 1 Square Around" /></li><li>
 <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a> two squares arround the some element in the Universe. This <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a> is present in <a href='/en/Universe/Fleet.aspx'>Fleet</a>s with, at least, one <a href='/en/Battles/Medium.aspx'>Medium</a> or <a href='/en/Battles/Heavy.aspx'>Heavy</a> unit and in <a href='/en/Universe/Planets.aspx'>Planet</a>.<p /><img src="/Resources/Images/LineOfSight2.png" alt="Line of Sight 2 Square Around" /></li><li>
 <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a> three squares arround the <a href='/en/Universe/Beacon.aspx'>Beacon</a>:<p /><img src="/Resources/Images/LineOfSight3.png" alt="Line of Sight 3 Squares Around" /></li></ul><p /></div>
</asp:Content>