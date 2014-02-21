<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Premium Usluge
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Promet</h2><ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a></li><li><a href='/hr/Commerce/AuctionHouse.aspx'>Aukcijska Kuća</a></li><li><a href='/hr/Commerce/Shop.aspx'>Premium Usluge</a></li><li><a href='/hr/Commerce/Markets.aspx'>Marketi</a></li><li><a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Premium Usluge</h1>
<div class="content">
U <a href='/hr/Commerce/Shop.aspx'>Premium Usluge</a> možete kupiti specijalne usluge koje će vam pomoći ili smanjiti težinu igre. Možete samo kupiti te usluge koristeći <a href='/hr/Commerce/Orions.aspx'>Orioni</a>.
<p />
Ovdje je lista dostupnih usluga:
<ul><li><a href='/hr/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Dobijte 30% smanjenja u osnovnim troškovima pri gradnji postrojenja i jedinica</a></li><li><a href='/hr/Commerce/Shop.aspx#BuyRareDeduction'>Dobij 30% smanjenja cijene rijetkih resursa pri gradnji Postrojenja i Jedinica</a></li><li><a href='/hr/Commerce/Shop.aspx#BuyQueueSpace'>Dodatna 3 mjesta na listi za čekanje. Ovo će vrijediti na listi za čekanje Postrojenja i Jedinica.</a></li><li><a href='/hr/Commerce/Shop.aspx#BuyFastSpeed'>Gradi sve 50% brže</a></li><li><a href='/hr/Commerce/Shop.aspx#BuyFullLineOfSight'>Bez magle rata (Fog Of War) u otkrivenom svemiru</a></li><li><a href='/hr/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Čitavi svemir vidljiv</a></li></ul><a name="BuyIntrinsicDeduction" id="BuyIntrinsicDeduction"></a><h2><a href='/hr/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Dobijte 30% smanjenja u osnovnim troškovima pri gradnji postrojenja i jedinica</a></h2>
Sa ovom uslugom aktiviranom <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a> trošak vaših <a href='/hr/FacilityIndex.aspx'>Postrojenja</a> i <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> će biti 30% manji.
Ovo važi samo za resurse vaše <a href='/hr/Race/Races.aspx'>Rasa</a>, neće utjecati na rijetke resurse.

<ul><li>Ako ste LightHumans], utječe na  <a class='energy' href='/hr/Intrinsic/Energy.aspx'>Energija</a>, <a class='serium' href='/hr/Intrinsic/Serium.aspx'>Serium</a> i <a class='mithril' href='/hr/Intrinsic/Mithril.aspx'>Mithril</a> trošak</li><li>Ako ste <a href='/hr/Race/DarkHumans.aspx'>Renegades</a>,  utječe na <a class='gold' href='/hr/Intrinsic/Gold.aspx'>Zlato</a>, <a class='titanium' href='/hr/Intrinsic/Titanium.aspx'>Titan</a> i <a class='uranium' href='/hr/Intrinsic/Uranium.aspx'>Uran</a>trošak</li><li>Ako ste <a href='/hr/Race/Bugs.aspx'>Levyr</a>, utječe na <a class='protol' href='/hr/Intrinsic/Protol.aspx'>Protol</a> i <a class='elk' href='/hr/Intrinsic/Elk.aspx'>Elk</a> trošak</li></ul><a name="BuyRareDeduction" id="BuyRareDeduction"></a><h2><a href='/hr/Commerce/Shop.aspx#BuyRareDeduction'>Dobij 30% smanjenja cijene rijetkih resursa pri gradnji Postrojenja i Jedinica</a></h2>
Sa ovom uslugom aktiviranom <a href='/hr/IntrinsicIndex.aspx'>Osnovni</a> trošak vaših <a href='/hr/FacilityIndex.aspx'>Postrojenja</a> i <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> će biti 30% manji.
Za razliku od prethodne usluge, ovo vrijedi samo za rijetke resurse:Astatine], <a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a>, <a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a>, <a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> i  <a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a>.

<a name="BuyQueueSpace" id="BuyQueueSpace"></a><h2><a href='/hr/Commerce/Shop.aspx#BuyQueueSpace'>Dodatna 3 mjesta na listi za čekanje. Ovo će vrijediti na listi za čekanje Postrojenja i Jedinica.</a></h2>
Lista za čekanje je količina <a href='/hr/FacilityIndex.aspx'>Postrojenja</a> ili <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> koje možete staviti na čekanje za konstrukciju u danom vremenu.  Vaš početni prostor na listi za čekanje ima samo jedno mjesto.  To znači ako već gradite nešto, ne možete staviti drugi predmet na listu za čekanje da počne čim se onaj u produkciji završi.
<p />
S ovom uslugom možete staviti još 3 predmeta na čekanje.

<a name="BuyFastSpeed" id="BuyFastSpeed"></a><h2><a href='/hr/Commerce/Shop.aspx#BuyFastSpeed'>Gradi sve 50% brže</a></h2>
Količina vremena koju gradnja uzima ovisi o vašem produkcijskom faktoru i o predmetu koji se gradi. Sa ovom uslugom vaš produkcijski faktor je smanjen za 50%, što znači da što god da gradite, će se se graditi pola puta kraće nego inače.

<a name="BuyFullLineOfSight" id="BuyFullLineOfSight"></a><h2><a href='/hr/Commerce/Shop.aspx#BuyFullLineOfSight'>Bez magle rata (Fog Of War) u otkrivenom svemiru</a></h2>
Druge igrače jedino možete vidjeti ako se miču unutar vaše <a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a>. Vaš <a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a> je određen <a href='/hr/Universe/Planets.aspx'>Planeti</a> i <a href='/hr/Universe/Fleet.aspx'>Flote</a> koje imate blizu. S ovom uslugom, moći ćete imati punu liniju vidljivosti u vašem otkrivenom svemiru, nećemo vam prikazati nikakav fog of war (maglu rata).

<a name="BuyNoUndiscoveredUniverse" id="BuyNoUndiscoveredUniverse"></a><h2><a href='/hr/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Čitavi svemir vidljiv</a></h2>
Crni kvadrati u <a href='/hr/Universe/Default.aspx'>Svemir</a> su neotkriveni prostor. Ne znate što je tamo, i trebate <a href='/hr/Universe/Travel.aspx'>Putovanje</a> sa <a href='/hr/Universe/Fleet.aspx'>Flota</a> na tu lokaciju da vidite što tamo ima. S ovom uslugom imati ćete <b>all</b> označen kao otkriven.
</div>
	
</asp:Content>