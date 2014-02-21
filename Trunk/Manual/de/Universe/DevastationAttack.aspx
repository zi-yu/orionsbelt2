﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zerstörungs-Attacke
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Zerstörungs-Attacke</h1>
	<div class="content">
  <p><a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> ist die ultimative Waffe der <a href='/de/Race/DarkHumans.aspx'>Renegades</a>. Es ist erhältlich sobald du das <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> Gebäude baust.</p>
  <p>Je mehr du von diesen Gebäuden hast, umso mächtiger wird die Waffe sein. Wenn du all die "Devastations"-Gebäude deiner privaten Zone auf Level 2 aufrüstest, wird die <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> auf volle Stärke sein.</p>
  <h2>States</h2>
    Du kannst den Status in der oberen rechten Ecke des Bildschirms checken. Die "Devastation" hat 4 
    Zustände:
    <ul><li><img src="/Resources/Images/en/DevastationNotAvailable.gif" alt="Devastation nicht &#xD;&#xA;    verfügbar" title="Devastation nicht verfügbar" /><br />
  Das <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> Gebäude ist auf keinen deiner privaten Planete gebaut.
 </li><li><img src="/Resources/Images/en/DevastationNotReady.gif" alt="Devastation nicht bereit" title="Devastation nicht bereit" /><br />
  Die <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> ist gebaut hat aber nicht genügend Ressourcen um es abzufeuern.
 </li><li><img src="/Resources/Images/en/DevastationReady.gif" alt="Devastation bereit" title="Devastation bereit" /><br />
  Die <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> ist gebaut und du kannst es abfeuern.
 </li><li><img src="/Resources/Images/en/DevastationCooldown.gif" alt="Devastation Abkühlungsphase" title="Devastation Abkühlungsphase" /><br />
  Die <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> wurde kürzlich abgefeuert und ist in der Abkühlungsphase.
 </li></ul><h2>Benutzung</h2><p>Du kannst die <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> von jeder <a href='/de/Universe/Fleet.aspx'>Flotte</a> aus benutzen die in der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> verfügbar ist. Klicke einfach auf die <a href='/de/Universe/Fleet.aspx'>Flotte</a>, dann klicke auf das Ziel (kann eine <a href='/de/Universe/Fleet.aspx'>Flotte</a> sein, ein <a href='/de/Universe/Planets.aspx'>Planet</a> oder eine leere Region im <a href='/de/Universe/Default.aspx'>Universum</a>) wie in dem unteren Bild:</p><img src="/Resources/Images/en/DevastationFire.gif" alt="Devastation Feuer" title="Devastation Feuer" /><p><a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> hat keine Reichweite. Solange dein Ziel in einem bereits erforschten Raum ist, kannst du es abfeuern. Ausserdem, halte die Augen auf!. Die <b><a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> fügt deinen <a href='/de/Universe/Fleet.aspx'>Flotte</a>s und den allierten <a href='/de/Universe/Fleet.aspx'>Flotte</a>s Schaden zu wenn sie in Reichweite sind</b></p><h1>Level</h1><ul><li>Level 1 - Zerstört 9% der Einheiten der anvisierten <a href='/de/Universe/Fleet.aspx'>Flotte</a> oder <a href='/de/Universe/Planets.aspx'>Planet</a>. Beeinträchtigt nur eine
Koordinate.<br />
 Kosten: <div id="resourcesCost"><ul><li>7000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>7000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>7000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>1000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>1000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>1000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>1000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>1000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 2 - Zerstört 18% der Einheiten der anvisierten <a href='/de/Universe/Fleet.aspx'>Flotte</a> oder <a href='/de/Universe/Planets.aspx'>Planet</a>. Beeinträchtigt nur eine Koordinate.<br />
 Kosten: <div id="resourcesCost"><ul><li>14000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>14000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>14000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>2000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>2000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>2000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>2000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>2000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 3 - Zerstört 27% der Einheiten der anvisierten <a href='/de/Universe/Fleet.aspx'>Flotte</a> oderr <a href='/de/Universe/Planets.aspx'>Planet</a>. Beeinträchtigt nur eine Koordinate.<br />
 Kosten: <div id="resourcesCost"><ul><li>21000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>21000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>21000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>3000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>3000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>3000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>3000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>3000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 4 - Zerstört 36% der Einheiten der anvisierten <a href='/de/Universe/Fleet.aspx'>Flotte</a> oder <a href='/de/Universe/Planets.aspx'>Planet</a>. Beeinträchtigt nur eine Koordinate.<br />
 Kosten: <div id="resourcesCost"><ul><li>28000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>28000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>28000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>4000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>4000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>4000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>4000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>4000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 5 - Zerstört 45% der Einheiten der anvisierten <a href='/de/Universe/Fleet.aspx'>Flotte</a> oder <a href='/de/Universe/Planets.aspx'>Planet</a>. Beeinträchtigt nur eine Koordinate.<br />
 Kosten: <div id="resourcesCost"><ul><li>35000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>35000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>35000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>5000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>5000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>5000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>5000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>5000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 6 - Destroys 54% of the units of the affected <a href='/de/Universe/Fleet.aspx'>Flotte</a> or <a href='/de/Universe/Planets.aspx'>Planet</a>. Affects the target coordinate and all the coordinates surrounding it (a total of 9 coordinates).<br />
 Custo: <div id="resourcesCost"><ul><li>42000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>42000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>42000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>6000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>6000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>6000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>6000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>6000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 7 - Zerstört 63% der Einheiten der anvisierten <a href='/de/Universe/Fleet.aspx'>Flotte</a> oder <a href='/de/Universe/Planets.aspx'>Planet</a>. Beeinträchtigt die Ziel-Koordinate und alle umgebenden (Gesamt von 9 coordinates).<br />
 Custo: <div id="resourcesCost"><ul><li>49000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>49000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>49000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>7000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>7000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>7000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>7000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>7000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 8 - Destroys 72% of the units of the affected <a href='/de/Universe/Fleet.aspx'>Flotte</a> or <a href='/de/Universe/Planets.aspx'>Planet</a>. Affects the target coordinate and all the coordinates surrounding it (a total of 9 coordinates).<br />
 Custo: <div id="resourcesCost"><ul><li>65000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>65000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>65000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>10000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>10000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>10000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>10000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>10000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 9 - Destroys 81% of the units of the affected <a href='/de/Universe/Fleet.aspx'>Flotte</a> or <a href='/de/Universe/Planets.aspx'>Planet</a>. Affects the target coordinate and all the coordinates surrounding it (a total of 9 coordinates).<br />
 Custo: <div id="resourcesCost"><ul><li>75000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>75000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>75000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>15000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>15000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>15000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>15000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>15000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 10 - Destroys 90% of the units of the affected <a href='/de/Universe/Fleet.aspx'>Flotte</a> or <a href='/de/Universe/Planets.aspx'>Planet</a>. Affects the target coordinate and all the coordinates in 2 a square distance (a total of 25 coordinates).<br />
 Custo: <div id="resourcesCost"><ul><li>90000 <img title="Gold" alt="Gold" src="http://resources.orionsbelt.eu/Images/Common/Resources/GoldSmall.png" /></li><li>90000 <img title="Titanium" alt="Titanium" src="http://resources.orionsbelt.eu/Images/Common/Resources/TitaniumSmall.png" /></li><li>90000 <img title="Uranium" alt="Uranium" src="http://resources.orionsbelt.eu/Images/Common/Resources/UraniumSmall.png" /></li><li>20000 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>20000 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>20000 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>20000 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>20000 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li></ul></div>
	
</asp:Content>