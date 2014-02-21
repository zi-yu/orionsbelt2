<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Alliance
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Alliances</h1>
<div class="content">
    An <a href='/en/Universe/Alliance.aspx'>Alliance</a> is a group of players that share a common goal: protection, richeness or maybe domination. You need <a href='/en/Commerce/Orions.aspx'>Orions</a> to create an alliance.
    After that, you may invite and accept players, and give them an aproprieate rank. The available ranks are:
    <ul><li>Admiral - master in command, the admirals are the alliance's leaders</li><li>Vice Admiral - second in command, the vice admirals are to be seen has almost leaders</li><li>Corporal - an alliance member that is proving to be valuable</li><li>Member - rookie member</li></ul>
    Every <a href='/en/Universe/Alliance.aspx'>Alliance</a> should try to get as much <a href='/en/Universe/Relics.aspx'>Relics</a> as possible. <a href='/en/Universe/Relics.aspx'>Relics</a> provide alliances with several rare resources per day.
    <p /><h2>Alliance Diplomacy</h2>
    Alliances may engage in war on the struggle for power, but they can also help each other. There are several diplomatic levels
    that an admiral may set to each know alliance:
    <ul><li>Confederation - These alliances act has one</li><li>Non Aggression Pact - You shouln't attack players of these alliance</li><li>Neutral - The default diplomatic level</li><li>War! - Let the games begin!</li></ul>
    Note that while you may be in pease with another alliance, the game won't prevent them from attacking you. These diplomatic states
    are just an agreement that may be broken without notice.
  </div>
	
</asp:Content>