<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Savez
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Savezi</h1>
<div class="content">
<a href='/hr/Universe/Alliance.aspx'>Savez</a> je grupa igrača koji dijele zajednički cilj:zaštitu, bogatstvo i možda dominaciju. Trebate <a href='/hr/Commerce/Orions.aspx'>Orioni</a> da osnujete savez.
Nakon toga možete pozivati ili prihvaćati saveze, i dati im odgovarajući rank. Dosupni rankovi su:
 <ul><li>Admiral - majstor zapovijednanja, admirali su vođe saveza</li><li>Vice Admiral - zamjenik admirala, viceadmirali su viđeni skoro kao vođe</li><li>Narednik - član saveza koji se pokazao vrijednim</li><li>Član - novak</li></ul>
Svaki <a href='/hr/Universe/Alliance.aspx'>Savez</a> bi trebao uhvatiti što više <a href='/hr/Universe/Relics.aspx'>Relikvije</a>. <a href='/hr/Universe/Relics.aspx'>Relikvije</a> daju savezu nekoliko rijetkih reursa dnevno.
<p /><h2>Diplomacija Saveza</h2>
Savezi mogu početi rat u borbi za moć, ali također mogu pomagati jedan drugome. Postoji nekoliko diplomatskih nivoa koje admiral može postaviti sa drugim savezima:
<ul><li>Confederation - Ovi savezi djeluju kao jedan</li><li>Non Aggression Pact - Ne biste trebali napadati igrače ovih saveza</li><li>Neutral - Osnovna diplomatska razina</li><li>Rat! - Neka igre Počnu</li></ul>Primjetiti da mada možete biti u miru sa drugim savezom, igra ih neće spriječiti da vas napadaju. Ova diplomatska stanja su samo dogovori koji mogu biti prekršeni bez upozorenja.
</div>
	
</asp:Content>