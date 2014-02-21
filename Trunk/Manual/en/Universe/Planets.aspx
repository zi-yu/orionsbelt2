<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Planets
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Planets</h1>
<div class="content">
    The planets are the heart and soul of your empire. They provide you with <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a> resources, you can build
    <a href='/en/FacilityIndex.aspx'>Facilities</a> on them, and they also allow you to build <a href='/en/UnitIndex.aspx'>Combat Units</a>. The more planets you have, the more
    powerfull you will be. You can have two types of planets: planets on your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> and planets on the
    <a href='/en/Universe/HotZone.aspx'>Hot Zone</a>.
    
    <h2>Private Zone Planets</h2>
    The planets on your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> are the most important. They have all the major facilities and you'll
    never be able to lose them, so be sure to improve them. These planets are also the only ones that
    allow you to build <a href='/en/UnitIndex.aspx'>Combat Units</a>.
    <p />
    The only problem with <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets is that they can't generate rare <a href='/en/IntrinsicIndex.aspx'>Intrinsics</a>. You'll need
    to get to the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> to get them.
    
    <h2>Hot Zone Planets</h2>
    Planets on the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> are similar to mines. They are very simple, you can only build a few facility types
    on them (for example, the <a class='extractor' href='/en/Facility/Extractor.aspx'>Extractor</a>) and they can be attacked (see <a href='/en/Universe/UniverseAttack.aspx'>Attack</a>) and raided 
    (see <a href='/en/Universe/Raids.aspx'>Raid</a>) by other players.
    <p />
    However the risks, these planets are essential, because they provide you with rare resources: <a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a>,
    <a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a>, <a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a>, <a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a> and <a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a>. You can get them via the <a class='extractor' href='/en/Facility/Extractor.aspx'>Extractor</a> facility. Without these
    rare resources you won't be able to upgrade facilities or build powerful <a href='/en/UnitIndex.aspx'>Combat Units</a>.
    <p />
    You can have a maximum of eight planets on the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a>. Each planet on the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> has a <a href='/en/Universe/HotZone.aspx#levels'>Zone Level</a>. 
    The higher the zone level, the more resources you'll be able to gather via the <a class='extractor' href='/en/Facility/Extractor.aspx'>Extractor</a>.

    <a name="Capacity" id="Capacity"></a><h2>Resource Limit</h2>
    Each planet has its own modifiers that increase your resource income every ten minutes. All those resources
    are global to all your planets, but you have a limit. Your resources won't grow beyong your current
    resource limit. To increase your resource limit you can:
    <ul><li>If your your race is <a href='/en/Race/LightHumans.aspx'>Utopians</a>, you must build the <a class='silo' href='/en/Facility/Silo.aspx'>Silo</a> and the <a class='commandcenter' href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li>If your race is <a href='/en/Race/DarkHumans.aspx'>Renegades</a>, you must build the <a class='slavewarehouse' href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a> and the <a class='darknesshall' href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li>If your race is <a href='/en/Race/Bugs.aspx'>Levyr</a>, you must build the <a class='nest' href='/en/Facility/Nest.aspx'>Nest</a></li></ul></div>
	
</asp:Content>