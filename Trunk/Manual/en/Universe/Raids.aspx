<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Raid
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1><h1>Raids</h1>
<div class="content">
    A raid consists on attacking another player's <a href='/en/Universe/Planets.aspx'>Planet</a> with the sole purpose of stealing <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a>
    resources. This action is usually performed by <a href='/en/PirateQuests.aspx'>Pirate</a> players on their <a href='/en/Quests.aspx'>Quests</a>, but can also be done
    by anyone else.
    <p />
    When you raid a planet, two things can occur:
    <ul><li>The planet's defense <a href='/en/Universe/Fleet.aspx'>Fleet</a> is empty and the raid is performed</li><li>
  The planet has some defenses and a battle will be started on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>; only if you win
  the raid is performed
 </li></ul>
    Even if the raid is performed, you may not get any resources at all. There is a raid timeout to prevent
    abuse, so it's only possible to raid a planet every ~14 hours.
    <p />
    If the raid is successufully performed, you will get some resources stolen and your <a href='/en/PirateQuests.aspx'>Pirate</a> ranking
    increased. You will steal two types of resources. One resource picked randomly and the other ressource
    is the one that the target planet's player has the most. And that varies by <a href='/en/Race/Races.aspx'>Race</a>:
    <ul><li>If you're targeting a <a href='/en/Race/LightHumans.aspx'>Utopians</a> planet, you'll get <a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a></li><li>If you're targeting a <a href='/en/Race/DarkHumans.aspx'>Renegades</a> planet, you'll get <a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>If you're targeting a <a href='/en/Race/Bugs.aspx'>Levyr</a> planet, you'll get <a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a></li></ul>
    The stolen quantity is a small percentage of the target player's total amount, and higher level planets
    provide better percentages.
   </div></h1>
	
</asp:Content>