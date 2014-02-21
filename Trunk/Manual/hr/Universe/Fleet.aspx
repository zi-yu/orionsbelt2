<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Flota
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Flote</h1>
<div class="content">
<a href='/hr/Universe/Fleet.aspx'>Flota</a> je grupa <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> koje mogu <a href='/hr/Universe/Travel.aspx'>Putovanje</a> u <a href='/hr/Universe/Default.aspx'>Svemir</a>.Postoji nekoliko tipova flota:
<ul><li>Obranbene flote: svaki <a href='/hr/Universe/Planets.aspx'>Planet</a> ima obranbenu flotu. Ova flota je statična i koristi se samo kada je planet napadnut.</li><li>Pokretne Flote: na vašim <a href='/hr/Universe/Planets.aspx'>Planeti</a> možete stvoriti flote i koristiti se s njima da  <a href='/hr/Universe/Travel.aspx'>Putovanje</a> u  <a href='/hr/Universe/Default.aspx'>Svemir</a></li><li>Ultimateivne Flote: ako flota ima (Ultimativnu jednicu), tada je zvana ultimativna flota </li></ul><h2>Kako Kreirati Flotu?</h2>
Najprije trebate izgraditi CombatUnits] na jednome od vaših <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> planeta.
Kada završite, one će biti smještene u obranbenu flotu planeta. Tada mižete ići na <i>Flote</i> sekciju planeta i krerati novu flotu. Nakon toga možete pomaknuti <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> iz obrane planeta u vašu novu flotu.
<p />
<a href='/hr/Universe/Fleet.aspx'>Flota</a> se može micati samo ako ima <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> i u ako miruje u trenutku izdavanja naredbe.

<h2>Što Flote mogu činiti?</h2>
Prva upotreba flote je samo da se <a href='/hr/Universe/Travel.aspx'>Putovanje</a> u vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a>. Možete otkiriti svaku zonu zbog <a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a> flote. Također možete zgrabiti <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a>  resurse i kolonizirati druge <a href='/hr/Universe/Planets.aspx'>Planeti</a>.
Kada ste spremni na to možete se koristiti <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> da <a href='/hr/Universe/Travel.aspx'>Putovanje</a> u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>.
<p />
U <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> možete napadati druge flote, <a href='/hr/Universe/Raids.aspx'>Pljačka</a> planete, izvoditi <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a> puno toga više. 

<h2>Teret Flote</h2>
Svaka flota ima teretetni dio koji može skladištiti <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a> resourse. Kada vaša flota ima nešo u treteu možete krenuti prema nekom od svojih planeta da istovarite taj teret u vaše resurse. Ako ste napadnuti i izgubite, protivnik će dobiti vaš teret kao plijen.
<p />
Obranbena flota vašega početnoga planeta također se služi kao mjesto za skladištnje resusrsa koje kupita u <a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a>.

<h2>Boje Flote</h2>
U <a href='/hr/Universe/Default.aspx'>Svemir</a> pogledu vidjeti ćete nekoliko  <a href='/hr/Universe/Fleet.aspx'>Flote</a> sa razlićitim bojama. Svaka boja ima svoje značanje i ovisi o vašem diplomatskom statusu sa vlasnikom flote <a href='/hr/Universe/Alliance.aspx'>Savez</a>:
<ul><li>Siva boja: neutralni ste sa tim igračom</li><li>Žuta Boja : imate pakt neneapdanja sa savezom toga igrača </li><li>Plava Boja: Vi ste saveznik tome igraču</li><li>Crvena boja: Ta flota je vaš neprijatelj!</li></ul></div>
	
</asp:Content>