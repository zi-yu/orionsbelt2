<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Linija Vidika
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Linija Vidika</h1>
	<div class="content">
<a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a> je vidljivo područje oko nečega što pripada vama (<a href='/hr/Universe/Fleet.aspx'>Flota</a>, <a href='/hr/Universe/Planets.aspx'>Planet</a>, itd). Unutar ovoga područja možete vidjeti sve što se miče, uključujući neprijateljske jedinice.
<p />
Postoje tri tipa <a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a>:
<p /><ul><li>
<a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a> jedan kvadrat oko <a href='/hr/Universe/Fleet.aspx'>Flota</a>. Ovaj <a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a> je prisutan u flotama sa samo <a href='/hr/Battles/Light.aspx'>Lagani</a> jedinicama <p /><img src="/Resources/Images/LineOfSight.png" alt="Line of Sight 1 Square Around" /></li><li>
<a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a> dva kvadrata oko nekog elementa u Svemiru. Ovaj <a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a> je prisutan u <a href='/hr/Universe/Fleet.aspx'>Flota</a> sa barem jednom <a href='/hr/Battles/Medium.aspx'>Srednji</a> ili <a href='/hr/Battles/Heavy.aspx'>Teški</a> jednicom i na <a href='/hr/Universe/Planets.aspx'>Planet</a>.<p /><img src="/Resources/Images/LineOfSight2.png" alt="Line of Sight 2 Square Around" /></li><li>
<a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a> tri kvadrata oko <a href='/hr/Universe/Beacon.aspx'>Zraka</a>:<p /><img src="/Resources/Images/LineOfSight3.png" alt="Line of Sight 3 Squares Around" /></li></ul><p /></div>
</asp:Content>