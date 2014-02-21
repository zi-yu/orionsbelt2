<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zona Privada
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Private Zone</h1>
<div class="content">
    The <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> is the place where you start the game. It's a zone that is only available to you,
    no other players may enter your <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a>. On your <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> you have five <a href='/es/Universe/Planets.aspx'>Planetas</a>. These are
    your main planets where you'll be able to get <a href='/es/IntrinsicIndex.aspx'>Intrínseco</a> resources and build <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>.
    <p />
    Here's a picture of a private zone when the game starts:
    <img class="block" src="/Resources/Images/PZ1.png" alt="Private Zone Image" />

    And here's a picture of a full discovered private zone:
    <img class="block" src="/Resources/Images/PZ2.png" alt="Private Zone Image" />
    
    On your private zone (and all over the universe) you'll be able to find several <a href='/es/IntrinsicIndex.aspx'>Intrínseco</a> resources,
    that you'll be able to gather just my moving a <a href='/es/Universe/Fleet.aspx'>Flota</a> to that position. When you start the game,
    be sure to grab them all, because you'll need them.
    <p />
    When you're ready to leave your private zone, you can use the <a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a> to travel to the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> and
    interact with other players, colonize more planets, and much more.
    <p />
    While you're on the private zone, be sure to follow the following <a href='/es/Quests.aspx'>Misiones</a>:
    <ul><li><a href='/es/Quest/GetAllPrivateZoneResources.aspx'>Tomar todos los recursos que tienes en la zona privada</a></li><li><a href='/es/Quest/ColonizeOnePlanetQuest.aspx'>Colonizar otro planeta en tu zona privada</a></li><li><a href='/es/Quest/ColonizeAllPrivateZonePlanetsQuest.aspx'>Colonizar los cinco planetas en tu zona privada</a></li><li><a href='/es/Quest/FindPrivateWormHoleQuest.aspx'>Encuentra el Túnel Espacial de tu zona privada y usalo para viajar hacia la zona pública</a></li></ul></div>
	
</asp:Content>