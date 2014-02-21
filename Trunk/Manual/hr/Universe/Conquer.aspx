<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pokori
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Pokori</h1>
	
	<div class="content">
<a href='/hr/Universe/Conquer.aspx'>Pokori</a> je čin pokorovanja planeta koji već ima vlasnika. Da  <a href='/hr/Universe/Conquer.aspx'>Pokori</a>  <a href='/hr/Universe/Planets.aspx'>Planet</a> morate pokrenuti <a href='/hr/Universe/Fleet.aspx'>Flota</a> prema ciljanom <a href='/hr/Universe/Planets.aspx'>Planet</a>.
<p />
Kada pokušate koloniziarati <a href='/hr/Universe/Conquer.aspx'>Pokori</a> dvije stvari se mogu desiti:
<ul><li><a href='/hr/Universe/Planets.aspx'>Planet</a> ima vlasnika, ali nema nikakve obrane.U ovome slučaju <a href='/hr/Universe/Planets.aspx'>Planet</a> je automatski pokoren.</li><li><a href='/hr/Universe/Planets.aspx'>Planet</a> ima vlasnika i ima obranu. U ovom slučaju bitka će započeti sa vlasnikom <a href='/hr/Universe/Planets.aspx'>Planet</a>.</li></ul><p />
U oba slučaja, izbornik ispod će se pojaviti:
<p /><img src="/Resources/Images/en/Conquer2.png" alt="Pokoro planet" /><p />
Uzmite u obzir kako se u gornjem izborniku "Opljačkaj Planet" pojavilo. Možete pronaći više informacija o ovoj mogućnosti na <a href='/hr/Universe/Raids.aspx'>Pljačka</a> stranici.
</div>
	
</asp:Content>