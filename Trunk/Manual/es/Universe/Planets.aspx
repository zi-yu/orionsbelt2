<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Planetas
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Planets</h1>
<div class="content">
    The planets are the heart and soul of your empire. They provide you with <a href='/es/IntrinsicIndex.aspx'>Intrínseco</a> resources, you can build
    <a href='/es/FacilityIndex.aspx'>Edificios</a> on them, and they also allow you to build <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>. The more planets you have, the more
    powerfull you will be. You can have two types of planets: planets on your <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> and planets on the
    <a href='/es/Universe/HotZone.aspx'>Zona Pública</a>.
    
    <h2>Private Zone Planets</h2>
    The planets on your <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> are the most important. They have all the major facilities and you'll
    never be able to lose them, so be sure to improve them. These planets are also the only ones that
    allow you to build <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>.
    <p />
    The only problem with <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> planets is that they can't generate rare <a href='/es/IntrinsicIndex.aspx'>Intrínsicos</a>. You'll need
    to get to the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> to get them.
    
    <h2>Hot Zone Planets</h2>
    Planets on the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> are similar to mines. They are very simple, you can only build a few facility types
    on them (for example, the <a class='extractor' href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a>) and they can be attacked (see <a href='/es/Universe/UniverseAttack.aspx'>Ataque</a>) and raided 
    (see <a href='/es/Universe/Raids.aspx'>Saqueo</a>) by other players.
    <p />
    However the risks, these planets are essential, because they provide you with rare resources: <a class='astatine' href='/es/Intrinsic/Astatine.aspx'>Astatine</a>,
    <a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a>, <a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a>, <a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> and <a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a>. You can get them via the <a class='extractor' href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a> facility. Without these
    rare resources you won't be able to upgrade facilities or build powerful <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>.
    <p />
    You can have a maximum of eight planets on the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a>. Each planet on the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> has a <a href='/es/Universe/HotZone.aspx#levels'>Nível de Zona</a>. 
    The higher the zone level, the more resources you'll be able to gather via the <a class='extractor' href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a>.

    <a name="Capacity" id="Capacity"></a><h2>Resource Limit</h2>
    Each planet has its own modifiers that increase your resource income every ten minutes. All those resources
    are global to all your planets, but you have a limit. Your resources won't grow beyong your current
    resource limit. To increase your resource limit you can:
    <ul><li>If your your race is <a href='/es/Race/LightHumans.aspx'>Utopianos</a>, you must build the <a class='silo' href='/es/Facility/Silo.aspx'>Bodega</a> and the <a class='commandcenter' href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li>If your race is <a href='/es/Race/DarkHumans.aspx'>Renegados</a>, you must build the <a class='slavewarehouse' href='/es/Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> and the <a class='darknesshall' href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a></li><li>If your race is <a href='/es/Race/Bugs.aspx'>Levyr</a>, you must build the <a class='nest' href='/es/Facility/Nest.aspx'>Nido</a></li></ul></div>
	
</asp:Content>