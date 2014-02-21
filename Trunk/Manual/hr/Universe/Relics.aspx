<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Relikvije
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Relikvije</h1>
<div class="content">
<a href='/hr/Universe/Relics.aspx'>Relikvija</a> je specijalno tijelo u <a href='/hr/Universe/Default.aspx'>Svemir</a>, specijalno dizajnirano za ratove <a href='/hr/Universe/Alliance.aspx'>Savez</a>. Kada <a href='/hr/Universe/Alliance.aspx'>Savez</a> ima jednu ili više <a href='/hr/Universe/Relics.aspx'>Relikvije</a>, svi članovi saveza primaju jedan tip rijetkih resursa po danu. Prihod po igraču ovisi oo tome koliko relikvija <a href='/hr/Universe/Alliance.aspx'>Savez</a> drži i o igraču i njegov/njezin rank unutar saveza.
<p />
Totalni prihod kojega će <a href='/hr/Universe/Alliance.aspx'>Savez</a> primiti je određen sljedećim podatcima:
<ul><li>svaka relikvija će doprinijeti sa   K pomnožena sa <a href='/hr/Universe/HotZone.aspx#levels'>Nivo Zone</a>; ako je relikvija u ratu, prihod će biti smanjen osam puta</li><li>Zbroj prihoda od svih relikvija je onda pomnožen sa postotkom relikvija u svemiru koje savez drži</li></ul>
Ovo znači da će više <a href='/hr/Universe/Relics.aspx'>Relikvije</a> dati više resursa. K je internalna konstanta, podložna promjeni.
<p />
Svaka <a href='/hr/Universe/Relics.aspx'>Relikvija</a> ima svoga zaštitnika: člana saveza koji je pokorio relikviju i koji je odgovoran za njezinu obranu.
</div>
	
</asp:Content>