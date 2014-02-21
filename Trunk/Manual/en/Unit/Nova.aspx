<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Nova Unit
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Units</h2><ul><li><a href='/en/Unit/Anubis.aspx' class='anubis'><img src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /> Anubis</a></li><li><a href='/en/Unit/BattleMoon.aspx' class='battlemoon'><img src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Battle Moon' /> Battle Moon</a></li><li><a href='/en/Unit/BlackWidow.aspx' class='blackwidow'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Black Widow' /> Black Widow</a></li><li><a href='/en/Unit/Blinker.aspx' class='blinker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Blinker' /> Blinker</a></li><li><a href='/en/Unit/Bozer.aspx' class='bozer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /> Bozer</a></li><li><a href='/en/Unit/CaptainWolf.aspx' class='captainwolf'><img src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='CaptainWolf' /> CaptainWolf</a></li><li><a href='/en/Unit/CommanderFox.aspx' class='commanderfox'><img src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Commander Fox' /> Commander Fox</a></li><li><a href='/en/Unit/Crawler.aspx' class='crawler'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crawler.png' alt='Crawler' /> Crawler</a></li><li><a href='/en/Unit/Crusader.aspx' class='crusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Crusader' /> Crusader</a></li><li><a href='/en/Unit/Cypher.aspx' class='cypher'><img src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /> Cypher</a></li><li><a href='/en/Unit/DarkCrusader.aspx' class='darkcrusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Dark Crusader' /> Dark Crusader</a></li><li><a href='/en/Unit/DarkRain.aspx' class='darkrain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Dark Rain' /> Dark Rain</a></li><li><a href='/en/Unit/DarkTaurus.aspx' class='darktaurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Dark Taurus' /> Dark Taurus</a></li><li><a href='/en/Unit/Destroyer.aspx' class='destroyer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/destroyer.png' alt='Destroyer' /> Destroyer</a></li><li><a href='/en/Unit/Doomer.aspx' class='doomer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Doomer' /> Doomer</a></li><li><a href='/en/Unit/Driller.aspx' class='driller'><img src='http://resources.orionsbelt.eu/Images/Common/Units/driller.png' alt='Driller' /> Driller</a></li><li><a href='/en/Unit/Eagle.aspx' class='eagle'><img src='http://resources.orionsbelt.eu/Images/Common/Units/eagle.png' alt='Eagle' /> Eagle</a></li><li><a href='/en/Unit/Egg.aspx' class='egg'><img src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Egg' /> Egg</a></li><li><a href='/en/Unit/Fenix.aspx' class='fenix'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Fenix' /> Fenix</a></li><li><a href='/en/Unit/Fist.aspx' class='fist'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Fist' /> Fist</a></li><li><a href='/en/Unit/Flag.aspx' class='flag'><img src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Flag' /> Flag</a></li><li><a href='/en/Unit/HeavySeeker.aspx' class='heavyseeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Heavy Seeker' /> Heavy Seeker</a></li><li><a href='/en/Unit/HiveKing.aspx' class='hiveking'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Hive King' /> Hive King</a></li><li><a href='/en/Unit/HiveProtector.aspx' class='hiveprotector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveprotector.png' alt='Hive Protector' /> Hive Protector</a></li><li><a href='/en/Unit/Interceptor.aspx' class='interceptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Interceptor' /> Interceptor</a></li><li><a href='/en/Unit/Jumper.aspx' class='jumper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /> Jumper</a></li><li><a href='/en/Unit/Kahuna.aspx' class='kahuna'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' /> Kahuna</a></li><li><a href='/en/Unit/Kamikaze.aspx' class='kamikaze'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kamikaze.png' alt='Kamikaze' /> Kamikaze</a></li><li><a href='/en/Unit/Krill.aspx' class='krill'><img src='http://resources.orionsbelt.eu/Images/Common/Units/krill.png' alt='Krill' /> Krill</a></li><li><a href='/en/Unit/Maggot.aspx' class='maggot'><img src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Maggot' /> Maggot</a></li><li><a href='/en/Unit/MetallicBeard.aspx' class='metallicbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Metallic Beard' /> Metallic Beard</a></li><li><a href='/en/Unit/Myst.aspx' class='myst'><img src='http://resources.orionsbelt.eu/Images/Common/Units/myst.png' alt='Myst' /> Myst</a></li><li><a href='/en/Unit/Nova.aspx' class='nova'><img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /> Nova</a></li><li><a href='/en/Unit/Panther.aspx' class='panther'><img src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Panther' /> Panther</a></li><li><a href='/en/Unit/Pretorian.aspx' class='pretorian'><img src='http://resources.orionsbelt.eu/Images/Common/Units/pretorian.png' alt='Praetorian' /> Praetorian</a></li><li><a href='/en/Unit/Queen.aspx' class='queen'><img src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Queen' /> Queen</a></li><li><a href='/en/Unit/Rain.aspx' class='rain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Rain' /> Rain</a></li><li><a href='/en/Unit/Raptor.aspx' class='raptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /> Raptor</a></li><li><a href='/en/Unit/Reaper.aspx' class='reaper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /> Reaper</a></li><li><a href='/en/Unit/Samurai.aspx' class='samurai'><img src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /> Samurai</a></li><li><a href='/en/Unit/Scarab.aspx' class='scarab'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scarab.png' alt='Scarab' /> Scarab</a></li><li><a href='/en/Unit/Scourge.aspx' class='scourge'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scourge.png' alt='Scourge' /> Scourge</a></li><li><a href='/en/Unit/Seeker.aspx' class='seeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Seeker' /> Seeker</a></li><li><a href='/en/Unit/Sentry.aspx' class='sentry'><img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /> Sentry</a></li><li><a href='/en/Unit/SilverBeard.aspx' class='silverbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Silver Beard' /> Silver Beard</a></li><li><a href='/en/Unit/Spider.aspx' class='spider'><img src='http://resources.orionsbelt.eu/Images/Common/Units/spider.png' alt='Spider' /> Spider</a></li><li><a href='/en/Unit/Stinger.aspx' class='stinger'><img src='http://resources.orionsbelt.eu/Images/Common/Units/stinger.png' alt='Stinger' /> Stinger</a></li><li><a href='/en/Unit/Taurus.aspx' class='taurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Taurus' /> Taurus</a></li><li><a href='/en/Unit/Titan.aspx' class='titan'><img src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /> Titan</a></li><li><a href='/en/Unit/Toxic.aspx' class='toxic'><img src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxic' /> Toxic</a></li><li><a href='/en/Unit/Vector.aspx' class='vector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/vector.png' alt='Vector' /> Vector</a></li><li><a href='/en/Unit/Walker.aspx' class='walker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/walker.png' alt='Walker' /> Walker</a></li><li><a href='/en/Unit/Worm.aspx' class='worm'><img src='http://resources.orionsbelt.eu/Images/Common/Units/worm.png' alt='Worm' /> Worm</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<div class='smallerContent'>

	<h1><asp:Literal Text="Nova" runat="server" /></h1>

	<div class="description">
		<img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' />
		<a class='nova' href='/en/Unit/Nova.aspx'>Nova</a> it's THE <a href='/en/Battles/Heavy.aspx'>Heavy</a> unit against <a href='/en/Battles/Organic.aspx'>Organic</a> type units. It has an attack of 2700 which is increased by 4000 when it attack <a href='/en/Battles/Organic.aspx'>Organic</a> units (total of 6700
   of attack power).
   <p />
   It has <a href='/en/Battles/Movement.aspx#MovNormal'>Normal Movement</a> and <a href='/en/Battles/Range.aspx'>Range</a> 5 which gives to this units great control over the <a href='/en/Battles/GameBoard.aspx'>Game Board</a> because, in most cases, it can attack from a distance were any of the enemy units can't
   easily reach.
   <p />
   It has a good cost because it only depends of common resources. A must have unit when you fight against races with <a href='/en/Battles/Organic.aspx'>Organic</a> unit types (like the <a href='/en/Race/Bugs.aspx'>Levyr</a>).
	</div>
	
	<h2>Battle Information</h2>
	
	<table class='table'>
		<tr>
			<td>Attack</td>
			<td>2700</td>
		</tr>
		<tr>
			<td>Defense</td>
			<td>1900</td>
		</tr>
		<tr>
			<td>Range</td>
			<td>5</td>
		</tr>
		<tr>
			<td>Movement Cost</td>
			<td>4</td>
		</tr>
		<tr>
			<td>Races</td>
			<td><a href='/en/Race/LightHumans.aspx'>Utopians</a></td>
		</tr>
		<tr>
			<td>Category</td>
			<td><a href='/en/Battles/Heavy.aspx'>Heavy</a></td>
		</tr>
		<tr>
			<td>Displacement</td>
			<td>Air</td>
		</tr>
		<tr>
			<td>Movement</td>
			<td><a href='/en/Battles/Movement.aspx#MovNormal'>Normal Movement</a></td>
		</tr>
	</table>
	
	
	<h3>Unit Bonus</h3><table class='table'><tr><th>Target</th><th>Attack</th><th>Defense</th><th>Range</th></tr><tr><td>Organic</td><td>4000</td><td>0</td><td>0</td></tr></table>
	
	<h2>Build Information</h2>
	<table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Unit Yard</a> Level 8</li></ul></td><td><ul><li>400 <a href='../Intrinsic/Energy.aspx'>Energy</a></li><li>375 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>500 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>175 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>50 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Hour 10 Minutes </td><td><ul><li>Move Units To Defense Fleet</li></ul></td><td><ul></ul></td></tr></table>
	
	</div>
	
</asp:Content>