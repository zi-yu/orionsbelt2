<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Coloniser
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Coloniser</h1>
	
	<div class="content">
    <a href='/fr/Universe/Colonize.aspx'>Coloniser</a> is the act of conquer an empty planet. 
    <p />
    When you try to <a href='/fr/Universe/Colonize.aspx'>Coloniser</a> an empty <a href='/fr/Universe/Planets.aspx'>Planète</a> the following menu will appear:
    <img src="/Resources/Images/en/Conquer1.png" alt="Colonize a planet" /><p />
    If you click in the option 'conquer', the fleet will start moving to the target <a href='/fr/Universe/Planets.aspx'>Planète</a>. When it arrives, the <a href='/fr/Universe/Planets.aspx'>Planète</a> will be automatically colonized.
   </div>
	
</asp:Content>