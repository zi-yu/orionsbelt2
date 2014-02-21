<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Arene
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Arene</h1>
	<div class="description">
	<a href='/hr/Universe/Arenas.aspx'>Arena</a> je mjesto izbora za ratničke igrače, gdje imate šansu da se borite za slavu i prestiž.<p />
Postoji nekoliko <a href='/hr/Universe/Arenas.aspx'>Arene</a> s kraja na kraj <a href='/hr/Universe/Default.aspx'>Svemir</a>, što su bliže centru <a href='/hr/Universe/Default.aspx'>Svemir</a> to je veća nagrada za pobjedu.  <p />
Kada igrač pronađe praznu <a href='/hr/Universe/Arenas.aspx'>Arena</a> automatski postaje prvak te <a href='/hr/Universe/Arenas.aspx'>Arena</a>, ili pak mora izazvati trenutačnog prvaka, i <a href='/hr/Universe/Fleet.aspx'>Flota</a> bitke neće biti <a href='/hr/Universe/Fleet.aspx'>Flota</a> koja je izabrana od jednog od igrača, već će biti jednaka <a href='/hr/Universe/Fleet.aspx'>Flota</a> za oba igrača koja je dostupna od strane <a href='/hr/Universe/Arenas.aspx'>Arena</a> samo za jednu bitku. U slučaju pobjede prvak je skinut sa trona i novi prvak je okunjen za tu <a href='/hr/Universe/Arenas.aspx'>Arena</a>. <p />
Ali najveća motivacija je mogućnost da se dobiju <a href='/hr/Commerce/Orions.aspx'>Orioni</a>. Izazivač mora platiti <a href='/hr/Commerce/Orions.aspx'>Orioni</a> da izazove prvaka, ako prvak dobije bitku, on također dobija dio <a href='/hr/Commerce/Orions.aspx'>Orioni</a> plaćenih od strane izazivača. Što više bitaka <a href='/hr/Universe/Arenas.aspx'>Arena</a> igrač odigra to dobija više bodova za profesiju <a href='/hr/GladiatorQuests.aspx'>Gladijator</a>.
Jedino pitanje je - <i>Koliko <a href='/hr/Universe/Arenas.aspx'>Arene</a> možete držati kao prvak?</i>
	</div>
	
</asp:Content>