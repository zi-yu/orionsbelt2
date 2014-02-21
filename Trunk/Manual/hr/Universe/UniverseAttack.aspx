<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Napad
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<h1>Napad</h1>
	<div class="content">
Kako biste napali nešto u <a href='/hr/Universe/Default.aspx'>Svemir</a>, morate imati <a href='/hr/Universe/Fleet.aspx'>Flota</a> koja sadrži jedinice.
<p />
Da napadnete drugog igrača jednostavno odaberite svoju Fleet] i kliknire iznad <a href='/hr/Universe/Fleet.aspx'>Flota</a> ili <a href='/hr/Universe/Planets.aspx'>Planet</a> drugog igrača
<p />
Ako kliknete preko <a href='/hr/Universe/Fleet.aspx'>Flota</a>, sljedeći izbornik će se pojaviti:
<p /><img src="/Resources/Images/en/AttackFleet.png" alt="Napadni Flotu" /><p />
Makon što kliknete na opciju "Napadni", <a href='/hr/Universe/Fleet.aspx'>Flota</a> će se početi micati i napasti neprijateljsku <a href='/hr/Universe/Fleet.aspx'>Flota</a>.
<p />
Kada vaša <a href='/hr/Universe/Fleet.aspx'>Flota</a> napadne <a href='/hr/Universe/Planets.aspx'>Planet</a>, sljedeće mogućnosti će se pojaviti:
<img src="/Resources/Images/en/Conquer2.png" alt="Napadni Planet" /><p />
Ove mogućnosti znače:
<ul><li>Napadni <a href='/hr/Universe/Planets.aspx'>Planet</a> i <a href='/hr/Universe/Conquer.aspx'>Pokori</a>: ako nema obrane vi <a href='/hr/Universe/Conquer.aspx'>Pokori</a>  <a href='/hr/Universe/Planets.aspx'>Planet</a> odmah. Ako je ima [Battle] se započinje</li><li>Opljačkaj <a href='/hr/Universe/Planets.aspx'>Planet</a>: Ako nema obranbenih jednica, vi kradete reusrse bez [Battle].Ako ima [Battle] se započinje i vi možete ukrasti reusrse samo ako je dobijete. U ovom slučaju  <a href='/hr/Universe/Planets.aspx'>Planet</a> nije pokoren.</li></ul></div>
</asp:Content>