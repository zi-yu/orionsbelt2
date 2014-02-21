<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Planètes
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Planets</h1>
<div class="content">
    The planets are the heart and soul of your empire. They provide you with <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a> resources, you can build
    <a href='/fr/FacilityIndex.aspx'>Constructions</a> on them, and they also allow you to build <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>. The more planets you have, the more
    powerfull you will be. You can have two types of planets: planets on your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> and planets on the
    <a href='/fr/Universe/HotZone.aspx'>Zone publique</a>.
    
    <h2>Private Zone Planets</h2>
    The planets on your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> are the most important. They have all the major facilities and you'll
    never be able to lose them, so be sure to improve them. These planets are also the only ones that
    allow you to build <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>.
    <p />
    The only problem with <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> planets is that they can't generate rare <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a>. You'll need
    to get to the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> to get them.
    
    <h2>Hot Zone Planets</h2>
    Planets on the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> are similar to mines. They are very simple, you can only build a few facility types
    on them (for example, the <a class='extractor' href='/fr/Facility/Extractor.aspx'>Extracteur</a>) and they can be attacked (see <a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a>) and raided 
    (see <a href='/fr/Universe/Raids.aspx'>Pillage</a>) by other players.
    <p />
    However the risks, these planets are essential, because they provide you with rare resources: <a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a>,
    <a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a>, <a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a>, <a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> and <a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a>. You can get them via the <a class='extractor' href='/fr/Facility/Extractor.aspx'>Extracteur</a> facility. Without these
    rare resources you won't be able to upgrade facilities or build powerful <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>.
    <p />
    You can have a maximum of eight planets on the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a>. Each planet on the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> has a <a href='/fr/Universe/HotZone.aspx#levels'>Niveau de zone</a>. 
    The higher the zone level, the more resources you'll be able to gather via the <a class='extractor' href='/fr/Facility/Extractor.aspx'>Extracteur</a>.

    <a name="Capacity" id="Capacity"></a><h2>Resource Limit</h2>
    Each planet has its own modifiers that increase your resource income every ten minutes. All those resources
    are global to all your planets, but you have a limit. Your resources won't grow beyong your current
    resource limit. To increase your resource limit you can:
    <ul><li>If your your race is <a href='/fr/Race/LightHumans.aspx'>Utopians</a>, you must build the <a class='silo' href='/fr/Facility/Silo.aspx'>Silo</a> and the <a class='commandcenter' href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li>If your race is <a href='/fr/Race/DarkHumans.aspx'>Renegades</a>, you must build the <a class='slavewarehouse' href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a> and the <a class='darknesshall' href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li><li>If your race is <a href='/fr/Race/Bugs.aspx'>Levyr</a>, you must build the <a class='nest' href='/fr/Facility/Nest.aspx'>Nid</a></li></ul></div>
	
</asp:Content>