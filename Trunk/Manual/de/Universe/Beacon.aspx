﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Wachposten
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Wachposten</h1>
	<div class="content">
  <img src="/Resources/Images/BeaconImg.png" style="float:right;" alt="Beacon" />
  <p>The <a href='/de/Universe/Beacon.aspx'>Wachposten</a> it's the <a href='/de/Race/LightHumans.aspx'>Utopians</a> Ultimate Weapon. Like the name suggests, it's something that is going to patrol a certain region of the universe. And it's exactly that.</p>
  <p>When you place a <a href='/de/Universe/Beacon.aspx'>Wachposten</a> it will, depending on its level, give information of the surrounding <a href='/de/Universe/Planets.aspx'>Planet</a>s and <a href='/de/Universe/Fleet.aspx'>Flotte</a>s. It also prevents <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a>s to the fired in the area covered by the <a href='/de/Universe/Beacon.aspx'>Wachposten</a>.</p>
  <p>Its level is given by the sum of the levels of your <a class='deepspacescanner' href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a>. Example: if you have 3 <a class='deepspacescanner' href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a> level 1 and 1 <a class='deepspacescanner' href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a> level 2, then your <a href='/de/Universe/Beacon.aspx'>Wachposten</a> level will be 5.</p>
  <h2>How to Create</h2>
  <p>A Beacon can be created by any fleet. If all conditions are met (necessary resources and, depending of the level, if you're near a planet that you own), the folowing option will appear in the
    fleet popup:</p>
  <img src="/Resources/Images/BeaconUsage.png" style="float:right;" alt="Beacon" />
  <h1>States</h1>
    You can check the state in the upper right corner of the screen. The Creation of a Beacon has 4 states:
    <ul><li><img src="/Resources/Images/en/BeaconNotAvailable.gif" alt="Beacon Not Available" title="Beacon Not Available" /><br />
  The <a class='deepspacescanner' href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a> is not built in any of your private planets.
 </li><li><img src="/Resources/Images/en/BeaconNotReady.gif" alt="Beacon Not Ready" title="Beacon Not Ready" /><br />
   The <a class='deepspacescanner' href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a> is built but you don't have enough resouces to create a <a href='/de/Universe/Beacon.aspx'>Wachposten</a>.
  </li><li><img src="/Resources/Images/en/BeaconReady.gif" alt="Beacon Ready" title="Beacon Ready" /><br />
   The <a class='deepspacescanner' href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a> is built and you can create a <a href='/de/Universe/Beacon.aspx'>Wachposten</a>.
  </li><li><img src="/Resources/Images/en/BeaconCooldown.gif" alt="Beacon Cooldown" title="Beacon Cooldown" /><br />
   The <a href='/de/Universe/Beacon.aspx'>Wachposten</a> was recently created and it is on a cooldown fase.
  </li></ul><h1>Levels</h1><ul><li>Level 1 - You can see how much <a href='/de/Battles/Light.aspx'>Licht</a> units a <a href='/de/Universe/Fleet.aspx'>Flotte</a> has. <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 2 sectors all around. Cooldown takes 10 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>300 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>300 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>300 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>60 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>60 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>60 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>60 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>60 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 2 - You can see how much <a href='/de/Battles/Light.aspx'>Licht</a> and <a href='/de/Battles/Medium.aspx'>Medium</a> units a <a href='/de/Universe/Fleet.aspx'>Flotte</a> has. <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 2 sectors all around. Cooldown takes 9 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>600 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>600 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>600 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>120 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>120 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>120 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>120 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>120 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 3 - You can see how much <a href='/de/Battles/Light.aspx'>Licht</a>, <a href='/de/Battles/Medium.aspx'>Medium</a> and <a href='/de/Battles/Heavy.aspx'>Schwer</a> units a <a href='/de/Universe/Fleet.aspx'>Flotte</a> has. <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 2 sectors all around. Cooldown takes 8 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>900 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>900 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>900 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>180 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>180 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>180 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>180 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>180 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 4 - You can see the type and quantity of each <a href='/de/Battles/Light.aspx'>Licht</a> in a <a href='/de/Universe/Fleet.aspx'>Flotte</a> (has well has the quantity of <a href='/de/Battles/Medium.aspx'>Medium</a> and <a href='/de/Battles/Heavy.aspx'>Schwer</a> units). <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 3 sectors all around. Cooldown takes 7 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>1200 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>1200 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>1200 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>240 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>240 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>240 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>240 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>240 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 5 - You can see the type and quantity of each <a href='/de/Battles/Light.aspx'>Licht</a> and <a href='/de/Battles/Medium.aspx'>Medium</a> in a <a href='/de/Universe/Fleet.aspx'>Flotte</a> (has well has the quantity of <a href='/de/Battles/Heavy.aspx'>Schwer</a> units). <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 3 sectors all around. Cooldown takes 6 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>1500 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>1500 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>1500 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>300 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>300 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>300 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>300 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>300 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 6 - You can see the type and quantity of each <a href='/de/Battles/Light.aspx'>Licht</a>, <a href='/de/Battles/Medium.aspx'>Medium</a> and <a href='/de/Battles/Heavy.aspx'>Schwer</a> in a <a href='/de/Universe/Fleet.aspx'>Flotte</a>. <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 3 sectors all around. Cooldown takes 5 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>1800 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>1800 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>1800 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>360 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>360 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>360 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>360 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>360 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 7 - You can see the level of the buildings in a <a href='/de/Universe/Planets.aspx'>Planet</a>. <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 4 sectors all around. Cooldown takes 4 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>2100 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>2100 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>2100 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>420 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>420 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>420 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>420 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>420 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 8 - You can see the income of the <a href='/de/Universe/Planets.aspx'>Planet</a>. <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 4 sectors all around. Cooldown takes 3 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>2400 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>2400 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>2400 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>480 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>480 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>480 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>480 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>480 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 9 - You can see the defense <a href='/de/Universe/Fleet.aspx'>Flotte</a> of a <a href='/de/Universe/Planets.aspx'>Planet</a>. <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> is 4 sectors all around. Cooldown takes 2 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>2700 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>2700 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>2700 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>540 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>540 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>540 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>540 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>540 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li><li>Level 10 - <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> of 5 sectors all around. Cooldown takes 1 turns.<br />
 Cost: <div id="resourcesCost"><ul><li>3000 <img title="Energy" alt="Energy" src="http://resources.orionsbelt.eu/Images/Common/Resources/EnergySmall.png" /></li><li>3000 <img title="Mithril" alt="Mithril" src="http://resources.orionsbelt.eu/Images/Common/Resources/MithrilSmall.png" /></li><li>3000 <img title="Serium" alt="Serium" src="http://resources.orionsbelt.eu/Images/Common/Resources/SeriumSmall.png" /></li><li>600 <img title="Astatine" alt="Astatine" src="http://resources.orionsbelt.eu/Images/Common/Resources/AstatineSmall.png" /></li><li>600 <img title="Prismal" alt="Prismal" src="http://resources.orionsbelt.eu/Images/Common/Resources/PrismalSmall.png" /></li><li>600 <img title="Argon" alt="Argon" src="http://resources.orionsbelt.eu/Images/Common/Resources/ArgonSmall.png" /></li><li>600 <img title="Cryptium" alt="Cryptium" src="http://resources.orionsbelt.eu/Images/Common/Resources/CryptiumSmall.png" /></li><li>600 <img title="Radon" alt="Radon" src="http://resources.orionsbelt.eu/Images/Common/Resources/RadonSmall.png" /></li></ul></div></li></ul><p>The picture below illustrates the information of all the levels:</p><img src="/Resources/Images/Beacon.png" alt="Beacon" title="Beacon" /></div>
</asp:Content>