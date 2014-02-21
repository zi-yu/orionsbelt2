<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Hot Zone
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Hot Zone</h1>
<div class="content">
<a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> je mjesto gdje se dešava sva akcija. Tamo ćete pronći druge igrače, druge <a href='/hr/Race/Races.aspx'>Rase</a> i ogromni <a href='/hr/Universe/Default.aspx'>Svemir</a> za istražiti.U <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a> igra vas ne štiti do drugih igrača, prepušteni ste sami sebi.
Jedina zaštita koju igra pruža je da igrači višeg nivoa ne mogu napadati igrače niskog nivoa.
<p />
Ali ne trebate biti sami u svemiru, trebate nabaviti <a href='/hr/Universe/Alliance.aspx'>Savez</a> za zaštitu i vodstvo. Također trebate odabrati <a href='/hr/Quests.aspx#Professions'>Profesija</a> i slijediti njezine  <a href='/hr/Quests.aspx'>Misije</a>, zato jer ćete tako brže rasti.
<p />
Neke interesante točke koje možete promaći u <a href='/hr/Universe/HotZone.aspx'>Hot Zone</a>:
<ul><li>Druge <a href='/hr/Universe/Planets.aspx'>Planeti</a> za kolonitzirati, koji će vam dopoustiti da izgradite <a class='extractor' href='/hr/Facility/Extractor.aspx'>Ekstraktor</a> i zradite rijetke resurse</li><li>
<a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> - postoji velik broj crvotočina u svemiru, i one su jako korisne da efikasno  smanje vrijeme vašeg <a href='/hr/Universe/Travel.aspx'>Putovanje</a>
</li><li><a href='/hr/Commerce/Markets.aspx'>Marketi</a> - pronađite markete i slijedite  <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a> da budete bogati <a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a> - borite se u arenama da budete najjači Gladiator]</li></ul><a id="levels" name="levels"></a><h2>Zone Level</h2>
Svako svemirsko tijelo ima svoj nivo, što je veći nivo zone. <a href='/hr/Universe/Planets.aspx'>Planeti</a>, <a href='/hr/Universe/Arenas.aspx'>Arene</a>, <a href='/hr/Commerce/Markets.aspx'>Marketi</a>, <a href='/hr/Universe/Relics.aspx'>Relikvije</a>, itd. Centar se zove <i>Sirius</i>.
<p />
Ovi nivoi zona postoje da daju sljedeće tokove:
<ul><li>Kada igrač započne igru, ima privatnu <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> koja povezuje njegovu <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> sa
<a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> u vanjskom svemiru. Od tamo on se miče prema centru da dobije bolje <a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li>Ovo znači da taj igrač počinje na vanjskim <i>rings</i> i napreduje prema centru</li><li>Također da početnici se ne suočavaju odmah sa naprednijim igračima jer su napredniji igrači već otišli na bolje pozicije</li></ul>
Nivoi variraiju od 1 do 10, sa 10 koji su najbogatiji/najmoćniji. Sljedeća slika predstavlja <a href='http://www.orionsbelt.eu'>Orioniv Pojas</a> svemir:
</div>
	<img class="block" src="/Resources/Images/WormHoleMapPreview.png" />
	
</asp:Content>