<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Private Zone
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Private Zone</h1>
<div class="content">
    The <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> is the place where you start the game. It's a zone that is only available to you,
    no other players may enter your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a>. On your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> you have five <a href='/en/Universe/Planets.aspx'>Planets</a>. These are
    your main planets where you'll be able to get <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a> resources and build <a href='/en/UnitIndex.aspx'>Combat Units</a>.
    <p />
    Here's a picture of a private zone when the game starts:
    <img class="block" src="/Resources/Images/PZ1.png" alt="Private Zone Image" />

    And here's a picture of a full discovered private zone:
    <img class="block" src="/Resources/Images/PZ2.png" alt="Private Zone Image" />
    
    On your private zone (and all over the universe) you'll be able to find several <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a> resources,
    that you'll be able to gather just my moving a <a href='/en/Universe/Fleet.aspx'>Fleet</a> to that position. When you start the game,
    be sure to grab them all, because you'll need them.
    <p />
    When you're ready to leave your private zone, you can use the <a href='/en/Universe/WormHole.aspx'>WormHole</a> to travel to the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> and
    interact with other players, colonize more planets, and much more.
    <p />
    While you're on the private zone, be sure to follow the following <a href='/en/Quests.aspx'>Quests</a>:
    <ul><li><a href='/en/Quest/GetAllPrivateZoneResources.aspx'>Catch all the resources in your private zone</a></li><li><a href='/en/Quest/ColonizeOnePlanetQuest.aspx'>Colonize one additional planet on your private zone</a></li><li><a href='/en/Quest/ColonizeAllPrivateZonePlanetsQuest.aspx'>Colonize all five planets on your private zone</a></li><li><a href='/en/Quest/FindPrivateWormHoleQuest.aspx'>Find a Worm Hole on your private zone and use it to travel to the hot zone</a></li></ul></div>
	
</asp:Content>