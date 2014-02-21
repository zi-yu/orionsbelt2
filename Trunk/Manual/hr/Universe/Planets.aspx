<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Planeti
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Planeti</h1>
<div class="content">
Planeti su srce i duša vašega carstva. Oni vam daju <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a> resurse, možete graditi <a href='/hr/FacilityIndex.aspx'>Postrojenja</a> na njima, i oni također dopuštaju gradnju <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>. Što više planeta imate, to ćete biti jači. Možete imati dva tipa planeta: planete u vašoj  <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> i planete u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>.
<h2> Planeti Privatne Zone </h2>
Planeti u vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> su najvažniji. Oni svi imaju glavna postrojenja i nikada ih ne možete izgubiti, zato se pobrinite da ih unaprijedite. Ovi planeti su također jedini koju dopuštaju izgradnju <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>.
<p />
Jedini problem sa <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> planetima je da oni ne mogu generirati rijetke <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a>. Trebate doći na <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> da ih dobijete.

<h2>Hot Zone Planeti</h2>
Planeti u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> su slični rudnicima. Oni su jako jednostavni, možete graditi nekoliko tipova postrojenja na njima (na primjer, <a class='extractor' href='/hr/Facility/Extractor.aspx'>Ekstraktor</a>) i oni mogu biti napadnuti (vidi <a href='/hr/Universe/UniverseAttack.aspx'>Napad</a>) i opljačkani  (vidi <a href='/hr/Universe/Raids.aspx'>Pljačka</a>) od strne drugih igrača.
<p />
No unatoč riziku, ovi planeti su esencijalni, zato jer vam daju rijetke resurse: <a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a>,
    <a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a>, <a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a>, <a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> and <a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a>. Možete ih dobiti preko <a class='extractor' href='/hr/Facility/Extractor.aspx'>Ekstraktor</a> postrojenja. Bez ovih rijetkih resursa nećete moći unaprijediti postrojenja ili graditi moćne <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>.
<p />
Možete imati maksimalno osam planeta na <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>. Svaki planet na <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> ima <a href='/hr/Universe/HotZone.aspx#levels'>Nivo Zone</a>.
Što je veći nivo zone, više resursa ćete moći prikupiti preko <a class='extractor' href='/hr/Facility/Extractor.aspx'>Ekstraktor</a>.
<a name="Capacity" id="Capacity"></a><h2> Limit Resursa</h2>
Svaki planet ima svoje vlastite modifikatore koji povećavaju prihod resursa svakih 10 minuta. Svi ti resursi su globalni svim vašim planetima, ali imate limit. Resursi neće rasti preko vašeg trenutačnog limita. Da povećate limit vaših resursa  možete:
<ul><li>Ako je vaša rasa <a href='/hr/Race/LightHumans.aspx'>Utopians</a>, morate izgraditi <a class='silo' href='/hr/Facility/Silo.aspx'>Silos</a> i <a class='commandcenter' href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li><li>Ako je vaša rasa <a href='/hr/Race/DarkHumans.aspx'>Renegades</a>, morate izgraditi <a class='slavewarehouse' href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a> i <a class='darknesshall' href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li>Ako je vaša rasa <a href='/hr/Race/Bugs.aspx'>Levyr</a>, morate izgraditi <a class='nest' href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li></ul></div>
	
</asp:Content>