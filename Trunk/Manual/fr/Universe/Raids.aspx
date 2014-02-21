<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pillage
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1><h1>Raids</h1>
<div class="content">
    A raid consists on attacking another player's <a href='/fr/Universe/Planets.aspx'>Planète</a> with the sole purpose of stealing <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a>
    resources. This action is usually performed by <a href='/fr/PirateQuests.aspx'>Pirate</a> players on their <a href='/fr/Quests.aspx'>Quêtes</a>, but can also be done
    by anyone else.
    <p />
    When you raid a planet, two things can occur:
    <ul><li>The planet's defense <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> is empty and the raid is performed</li><li>
  The planet has some defenses and a battle will be started on the <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>; only if you win
  the raid is performed
 </li></ul>
    Even if the raid is performed, you may not get any resources at all. There is a raid timeout to prevent
    abuse, so it's only possible to raid a planet every ~14 hours.
    <p />
    If the raid is successufully performed, you will get some resources stolen and your <a href='/fr/PirateQuests.aspx'>Pirate</a> ranking
    increased. You will steal two types of resources. One resource picked randomly and the other ressource
    is the one that the target planet's player has the most. And that varies by <a href='/fr/Race/Races.aspx'>Race</a>:
    <ul><li>If you're targeting a <a href='/fr/Race/LightHumans.aspx'>Utopians</a> planet, you'll get <a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a></li><li>If you're targeting a <a href='/fr/Race/DarkHumans.aspx'>Renegades</a> planet, you'll get <a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>If you're targeting a <a href='/fr/Race/Bugs.aspx'>Levyr</a> planet, you'll get <a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a></li></ul>
    The stolen quantity is a small percentage of the target player's total amount, and higher level planets
    provide better percentages.
   </div></h1>
	
</asp:Content>