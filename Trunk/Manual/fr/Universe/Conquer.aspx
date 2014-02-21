<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Conquérir
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Conquérir</h1>
	
	<div class="content">
    <a href='/fr/Universe/Conquer.aspx'>Conquérir</a> is the act of conquering a planet that already has an owner. To <a href='/fr/Universe/Conquer.aspx'>Conquérir</a> a <a href='/fr/Universe/Planets.aspx'>Planète</a> you must move a <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> to the target <a href='/fr/Universe/Planets.aspx'>Planète</a>.
    <p />
    When you try to colonize a <a href='/fr/Universe/Conquer.aspx'>Conquérir</a> two things can happen:
    <ul><li>The <a href='/fr/Universe/Planets.aspx'>Planète</a> has an owner but hasn't any defenses. In this case the <a href='/fr/Universe/Planets.aspx'>Planète</a> is automatically conquered.</li><li>The <a href='/fr/Universe/Planets.aspx'>Planète</a> has an owner and has defenses. In this case a battle will start with the owner of the <a href='/fr/Universe/Planets.aspx'>Planète</a>.</li></ul><p />
    In both cases, the menu below will appear:
    <p /><img src="/Resources/Images/en/Conquer2.png" alt="Conquer a planet" /><p />
    Notice that in the above menu an option "Raid Planet" appeared. You can find more information about this option in the <a href='/fr/Universe/Raids.aspx'>Pillage</a> page.
   </div>
	
</asp:Content>