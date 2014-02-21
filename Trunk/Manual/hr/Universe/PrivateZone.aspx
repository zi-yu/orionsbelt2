<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Privatna Zona
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Private Zone</h1>
<div class="content">
<a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> je mjsesto gdje počinjete igru. To je zona koja je dostpna samo vama, niti jedan drugi igrač ne može ući u vašu <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a>. U vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> imate pet <a href='/hr/Universe/Planets.aspx'>Planeti</a>. Ovo su vaši glavni planeti gdje možete dobiti <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a> resurse i izgradti <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>.
<p />
Ovdje  je slika privatne zone kada igra počne:
<img class="block" src="/Resources/Images/PZ1.png" alt="Private Zone Image" />

A ovdje je slika potpuno otkrivene privatne zone:
<img class="block" src="/Resources/Images/PZ2.png" alt="Private Zone Image" />

U vašoj privatnoj zoni (i čitavom otkrivenom) svemiru moći ćete pronaći nekoliko <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a> resursa, koje možete prikipiti pokretanjem <a href='/hr/Universe/Fleet.aspx'>Flota</a> na tu poziciju. Kada počnete igru, budite sigurni da ih ugrabite sve jer ih trebate.
<p />
Kada ste spremni za napustiti vašu privatnu zonu, možete se poslužiti sa <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> sa putujete u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> i ineraktirate s drugim igračima, kolonizirate još planeta, i puno toga više.
<p />
Dok ste u privatnoj zoni, budite sigurni da slijedite sljedeće <a href='/hr/Quests.aspx'>Misije</a>:
<ul><li><a href='/hr/Quest/GetAllPrivateZoneResources.aspx'>Uhvati sve resurse unutar tvoje privatne zone</a></li><li><a href='/hr/Quest/ColonizeOnePlanetQuest.aspx'>Koloniziraj jedan dodatni planet u svojoj privatnoj zoni</a></li><li><a href='/hr/Quest/ColonizeAllPrivateZonePlanetsQuest.aspx'>Koloniziraj svih pet planeta u svojoj privatnoj zoni</a></li><li><a href='/hr/Quest/FindPrivateWormHoleQuest.aspx'>Pronađi crvotočinu u svojoj privatnoj zoni i upotrijebi je da putuješ u hot zonu</a></li></ul></div>
	
</asp:Content>