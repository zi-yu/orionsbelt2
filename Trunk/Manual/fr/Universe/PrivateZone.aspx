<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zone privée
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Private Zone</h1>
<div class="content">
    The <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> is the place where you start the game. It's a zone that is only available to you,
    no other players may enter your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>. On your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> you have five <a href='/fr/Universe/Planets.aspx'>Planètes</a>. These are
    your main planets where you'll be able to get <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a> resources and build <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>.
    <p />
    Here's a picture of a private zone when the game starts:
    <img class="block" src="/Resources/Images/PZ1.png" alt="Private Zone Image" />

    And here's a picture of a full discovered private zone:
    <img class="block" src="/Resources/Images/PZ2.png" alt="Private Zone Image" />
    
    On your private zone (and all over the universe) you'll be able to find several <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a> resources,
    that you'll be able to gather just my moving a <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> to that position. When you start the game,
    be sure to grab them all, because you'll need them.
    <p />
    When you're ready to leave your private zone, you can use the <a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a> to travel to the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> and
    interact with other players, colonize more planets, and much more.
    <p />
    While you're on the private zone, be sure to follow the following <a href='/fr/Quests.aspx'>Quêtes</a>:
    <ul><li><a href='/fr/Quest/GetAllPrivateZoneResources.aspx'>Attraper toutes les ressources sur votre zone privée</a></li><li><a href='/fr/Quest/ColonizeOnePlanetQuest.aspx'>Colonisez une planète additionnel sur votre zone privée</a></li><li><a href='/fr/Quest/ColonizeAllPrivateZonePlanetsQuest.aspx'>Colonisez les 5 planètes sur votre zone privée</a></li><li><a href='/fr/Quest/FindPrivateWormHoleQuest.aspx'>Trouvez un trou stellaire sur votre zone privée en direction "zone publique"</a></li></ul></div>
	
</asp:Content>