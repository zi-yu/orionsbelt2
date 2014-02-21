﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Crvotočina
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Svemir</h2><ul><li><a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a></li><li><a href='/hr/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/hr/Universe/Coordinates.aspx'>Koordinate</a></li></ul><h2>Akcije Svemira</h2><ul><li><a href='/hr/Universe/Travel.aspx'>Putovanje</a></li><li><a href='/hr/Universe/LineOfSight.aspx'>Linija Vidika</a></li><li><a href='/hr/Universe/Colonize.aspx'>Koloniziraj</a></li><li><a href='/hr/Universe/UniverseAttack.aspx'>Napad</a></li><li><a href='/hr/Universe/Conquer.aspx'>Pokori</a></li><li><a href='/hr/Universe/Raids.aspx'>Pljačka</a></li><li><a href='/hr/Universe/UnloadCargo.aspx'>Istovari Teret</a></li><li><a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a></li></ul><h2>Elementi Svemira</h2><ul><li><a href='/hr/Universe/Planets.aspx'>Planeti</a></li><li><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a></li><li><a href='/hr/Universe/Fleet.aspx'>Flota</a></li><li><a href='/hr/Universe/Arenas.aspx'>Arene</a></li><li><a href='/hr/Universe/Beacon.aspx'>Zraka</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Drugi</h2><ul><li><a href='/hr/Universe/Alliance.aspx'>Savez</a></li><li><a href='/hr/Universe/Relics.aspx'>Relikvije</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Crvotočina</h1>
	<div class="content">
  <div style="float:right">
    <img src="/Resources/Images/WormHole.png" alt="Worm Hole" title="Worm Hole" />
  </div>
  <p><a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> se rabi da instantno transportira <a href='/hr/Universe/Fleet.aspx'>Flota</a> s jedne točke <a href='/hr/Universe/Default.aspx'>Svemir</a> do druge.</p>
  <p> U svakoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> postoji <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> koja vas povezuje sa ostatkom <a href='/hr/Universe/Default.aspx'>Svemir</a>. Skrivena je pa zato trebate istrežiti kako biste je našli.
Ova <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> je također privatna. Ovo znači da je samo vi možete uportrijebiti. Ispod je slika neotkrivene <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> sa <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a>.</p>
  <img src="/Resources/Images/PrivateWormHole.png" alt="Private Worm Hole" title="Private Worm Hole" />
  <p>Da otkrijete novu crvotočinu trebate je samo upotrijebiti. Za to trebate kliknuti na <a href='/hr/Universe/Fleet.aspx'>Flota</a> i onda u  <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a>. 
Kada to učinite sljedeći popup će se pojaviti:</p>
  <img src="/Resources/Images/en/WormHole.png" alt="Worm Hole Popup" title="Worm Hole Popup" />
  <p>Kada kliknete transport, prozor sa svim dostupnim <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> će se pojaviti.</p>
  <p>Ovaj prozor ima dva taba:
<ul><li>Svemit <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> - svi javni <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> koje ste pronašli</li><li>Savezi <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> - sve <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> koje je vaš savez (ili vi) izgradio (Ove <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> mogu samo graditi <a href='/hr/Race/Bugs.aspx'>Levyr</a>. Pogledajte još informacija ispod).</li></ul></p>
  <h1><a href='/hr/Race/Bugs.aspx'>Levyr</a> Wormhole</h1>
  <p>Ova specijalna vrsta <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> je <a href='/hr/Race/Bugs.aspx'>Levyr</a> ultimativno oružje. Ova <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> može se koristiti od strane vas, i u kasnijoj fazi razovja, od strane članova vašega saveza.</p>
  <p>
Svaka izgrađena <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> ima nivo. Njezin  nivo je dan zbrojem nivoa vaših <a class='wormholecreator' href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a>. Naprimjer: ako imate 3 <a class='wormholecreator' href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a> nivo 1 i 1 <a class='wormholecreator' href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a> nivo 2,
tada će <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> nivo biti 5.
</p>
  <h1>States</h1>
Možete provjerit stanje u gornjem desnom kutu ekrana. <a class='wormholecreator' href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a> ima 4 stanja:
<ul><li><img src="/Resources/Images/en/WormHoleNotAvailable.gif" alt="WormHole Not Available" title="WormHole Not Available" /><br />
<a class='wormholecreator' href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a>  nije izgrađen ni na jednom od vaših privatnij planeta.
</li><li><img src="/Resources/Images/en/WormHoleNotReady.gif" alt="WormHole Not Ready" title="WormHole Not Ready" /><br />
<a class='wormholecreator' href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a> je izgređen ali nemate dovoljno resursa da ga upotrijebite
</li><li><img src="/Resources/Images/en/WormHoleReady.gif" alt="WormHole Ready" title="WormHole Ready" /><br />
<a class='wormholecreator' href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a> je izgrađen i možete kreirati <a href='/hr/Universe/WormHole.aspx'>Crvotočina</a>.
</li><li><img src="/Resources/Images/en/WormHoleCoolDown.gif" alt="WormHole Cooldown" title="WormHole Cooldown" /><br />
<a href='/hr/Universe/WormHole.aspx'>Crvotočina</a> je nedavno kreirana i sada je u fazi hlađenja
</li></ul><h1>Levels:</h1><ul><li>Level 1 - Duration 1 day. Construction cooldown of 10 days. Only the owner can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>200 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>200 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>50 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>50 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>50 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>50 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>50 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 2 - Duration 2 days. Construction cooldown of 9 days. Only the owner can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>400 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>400 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>100 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>100 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>100 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>100 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>100 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 3 - Duration 3 days. Construction cooldown of 8 days. Only the owner can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>600 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>600 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>150 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>150 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>150 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>150 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>150 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 4 - Duration 4 days. Construction cooldown of 7 days. Only the owner and players of the same alliance and from the <a href='/hr/Race/Bugs.aspx'>Levyr</a> (with level 6 or above) can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>800 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>800 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>200 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>200 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>200 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>200 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>200 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 5 - Duration 5 days. Construction cooldown of 6 days. Only the owner and players of the same alliance and from the <a href='/hr/Race/Bugs.aspx'>Levyr</a> (with level 6 or above) can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>100 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>100 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>250 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>250 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>250 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>250 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>250 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 6 - Duration 6 days. Construction cooldown of 5 days. Only the owner and players of the same alliance and from the <a href='/hr/Race/Bugs.aspx'>Levyr</a> (with level 6 or above) can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>1200 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>1200 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>300 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>300 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>300 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>300 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>300 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 7 - Duration 7 days. Construction cooldown of 4 days. Only the owner and players of the same alliance and from the <a href='/hr/Race/Bugs.aspx'>Levyr</a> (with level 6 or above) can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>1400 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>1400 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>350 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>350 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>350 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>350 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>350 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 8 - Duration 8 days. Construction cooldown of 3 days. Only the owner and players of the same alliance and from thee <a href='/hr/Race/Bugs.aspx'>Levyr</a> (with level 6 or above) can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>1600 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>1600 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>400 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>400 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>400 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>400 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>400 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 9 - Duration 9 days. Construction cooldown of 2 days. Only the owner and players of the same alliance (with Level 6 or above) can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>1800 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>1800 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>450 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>450 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>450 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>450 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>450 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 10 - Duration 10 days. Construction cooldown of 1 days. Only the owner and players of the same alliance (with Level 6 or above) can use it.<br />
 Cost: <div id="resourcesCost"><ul><li>2000 <img title="Protol" alt="Protol" src="http://resources.orionsbelt.eu/Images/Common/Resources/ProtolSmall.png" /></li><li>2000 <img title="Elk" alt="Elk" src="http://resources.orionsbelt.eu/Images/Common/Resources/ElkSmall.png" /></li><li>500 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>500 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>500 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>500 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>500 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li></ul></div>
	
</asp:Content>