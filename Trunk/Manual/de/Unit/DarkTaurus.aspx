<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Dunkler Taurus Einheit
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Einheiten</h2><ul><li><a href='/de/Unit/Interceptor.aspx' class='interceptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Abfangjäger' /> Abfangjäger</a></li><li><a href='/de/Unit/Eagle.aspx' class='eagle'><img src='http://resources.orionsbelt.eu/Images/Common/Units/eagle.png' alt='Adler' /> Adler</a></li><li><a href='/de/Unit/Anubis.aspx' class='anubis'><img src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /> Anubis</a></li><li><a href='/de/Unit/HiveProtector.aspx' class='hiveprotector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveprotector.png' alt='Bienenstock Beschützer' /> Bienenstock Beschützer</a></li><li><a href='/de/Unit/HiveKing.aspx' class='hiveking'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Bienenstock König' /> Bienenstock König</a></li><li><a href='/de/Unit/Blinker.aspx' class='blinker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Blinker' /> Blinker</a></li><li><a href='/de/Unit/Driller.aspx' class='driller'><img src='http://resources.orionsbelt.eu/Images/Common/Units/driller.png' alt='Bohrer' /> Bohrer</a></li><li><a href='/de/Unit/Bozer.aspx' class='bozer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /> Bozer</a></li><li><a href='/de/Unit/Cypher.aspx' class='cypher'><img src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /> Cypher</a></li><li><a href='/de/Unit/Doomer.aspx' class='doomer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Doomer' /> Doomer</a></li><li><a href='/de/Unit/DarkCrusader.aspx' class='darkcrusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Dunkler Kreuzfahrer' /> Dunkler Kreuzfahrer</a></li><li><a href='/de/Unit/DarkRain.aspx' class='darkrain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Dunkler Regen' /> Dunkler Regen</a></li><li><a href='/de/Unit/DarkTaurus.aspx' class='darktaurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Dunkler Taurus' /> Dunkler Taurus</a></li><li><a href='/de/Unit/Egg.aspx' class='egg'><img src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Ei' /> Ei</a></li><li><a href='/de/Unit/Fist.aspx' class='fist'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Faust' /> Faust</a></li><li><a href='/de/Unit/Fenix.aspx' class='fenix'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Fenix' /> Fenix</a></li><li><a href='/de/Unit/Flag.aspx' class='flag'><img src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Flagge' /> Flagge</a></li><li><a href='/de/Unit/Kahuna.aspx' class='kahuna'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' /> Kahuna</a></li><li><a href='/de/Unit/Kamikaze.aspx' class='kamikaze'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kamikaze.png' alt='Kamikaze' /> Kamikaze</a></li><li><a href='/de/Unit/CaptainWolf.aspx' class='captainwolf'><img src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='Kapitän Wolf' /> Kapitän Wolf</a></li><li><a href='/de/Unit/CommanderFox.aspx' class='commanderfox'><img src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Kommander Fox' /> Kommander Fox</a></li><li><a href='/de/Unit/Queen.aspx' class='queen'><img src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Königin' /> Königin</a></li><li><a href='/de/Unit/Crusader.aspx' class='crusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Kreuzfahrer' /> Kreuzfahrer</a></li><li><a href='/de/Unit/Crawler.aspx' class='crawler'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crawler.png' alt='Kriecher' /> Kriecher</a></li><li><a href='/de/Unit/Krill.aspx' class='krill'><img src='http://resources.orionsbelt.eu/Images/Common/Units/krill.png' alt='Krill' /> Krill</a></li><li><a href='/de/Unit/Maggot.aspx' class='maggot'><img src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Made' /> Made</a></li><li><a href='/de/Unit/HeavySeeker.aspx' class='heavyseeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Mega Sucher' /> Mega Sucher</a></li><li><a href='/de/Unit/MetallicBeard.aspx' class='metallicbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Metallischer Bart' /> Metallischer Bart</a></li><li><a href='/de/Unit/BattleMoon.aspx' class='battlemoon'><img src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Mond-Schlacht' /> Mond-Schlacht</a></li><li><a href='/de/Unit/Myst.aspx' class='myst'><img src='http://resources.orionsbelt.eu/Images/Common/Units/myst.png' alt='Myst' /> Myst</a></li><li><a href='/de/Unit/Nova.aspx' class='nova'><img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /> Nova</a></li><li><a href='/de/Unit/Panther.aspx' class='panther'><img src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Panther' /> Panther</a></li><li><a href='/de/Unit/Pretorian.aspx' class='pretorian'><img src='http://resources.orionsbelt.eu/Images/Common/Units/pretorian.png' alt='Praetorian' /> Praetorian</a></li><li><a href='/de/Unit/Raptor.aspx' class='raptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /> Raptor</a></li><li><a href='/de/Unit/Reaper.aspx' class='reaper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /> Reaper</a></li><li><a href='/de/Unit/Rain.aspx' class='rain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Regen' /> Regen</a></li><li><a href='/de/Unit/Samurai.aspx' class='samurai'><img src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /> Samurai</a></li><li><a href='/de/Unit/BlackWidow.aspx' class='blackwidow'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Schwarze Witwe' /> Schwarze Witwe</a></li><li><a href='/de/Unit/Scourge.aspx' class='scourge'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scourge.png' alt='Scourge' /> Scourge</a></li><li><a href='/de/Unit/Sentry.aspx' class='sentry'><img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /> Sentry</a></li><li><a href='/de/Unit/SilverBeard.aspx' class='silverbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Silberbart' /> Silberbart</a></li><li><a href='/de/Unit/Scarab.aspx' class='scarab'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scarab.png' alt='Skarabäus' /> Skarabäus</a></li><li><a href='/de/Unit/Spider.aspx' class='spider'><img src='http://resources.orionsbelt.eu/Images/Common/Units/spider.png' alt='Spinne' /> Spinne</a></li><li><a href='/de/Unit/Jumper.aspx' class='jumper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Springer' /> Springer</a></li><li><a href='/de/Unit/Stinger.aspx' class='stinger'><img src='http://resources.orionsbelt.eu/Images/Common/Units/stinger.png' alt='Stachel' /> Stachel</a></li><li><a href='/de/Unit/Seeker.aspx' class='seeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Sucher' /> Sucher</a></li><li><a href='/de/Unit/Taurus.aspx' class='taurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Taurus' /> Taurus</a></li><li><a href='/de/Unit/Titan.aspx' class='titan'><img src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /> Titan</a></li><li><a href='/de/Unit/Toxic.aspx' class='toxic'><img src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxisch' /> Toxisch</a></li><li><a href='/de/Unit/Vector.aspx' class='vector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/vector.png' alt='Vektor' /> Vektor</a></li><li><a href='/de/Unit/Walker.aspx' class='walker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/walker.png' alt='Walker' /> Walker</a></li><li><a href='/de/Unit/Worm.aspx' class='worm'><img src='http://resources.orionsbelt.eu/Images/Common/Units/worm.png' alt='Wurm' /> Wurm</a></li><li><a href='/de/Unit/Destroyer.aspx' class='destroyer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/destroyer.png' alt='Zerstörer' /> Zerstörer</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<div class='smallerContent'>

	<h1><asp:Literal Text="Dunkler Taurus" runat="server" /></h1>

	<div class="description">
		<img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Dunkler Taurus' />
		Diese Einheit ist wie eine kleine Festung die sich auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> bewegt, praktisch nahezu unzerstörbar und mit einer immensen Angriffskraft. <p>
   Die Schwäche der <a class='darktaurus' href='/de/Unit/DarkTaurus.aspx'>Dunkler Taurus</a> ist die kurze <a href='/de/Battles/Range.aspx'>Reichweite</a> für eine <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheit und die Tatsache dass es nur <a href='/de/Battles/Movement.aspx#MovFront'>Frontal-Bewegung</a> hat. Aber, wenn es in der Mitte der Schlacht platziert wird, ist es eine extrem nützliche Einheit. </p><p>
   Zusammen mit ihrer enormen Macht, hat sie zwei spezielle Fähigkeiten die ihre destruktive Kraft 
   illustrieren: Der <a href='/de/Battles/Rebound.aspx'>Rückprall</a> und
   <a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a>. Diese zwei Fähigkeiten können in Kombination feindliche <a href='/de/UnitIndex.aspx'>Einheiten</a> in 4 verschiedenen 
   Vierecken mit nur einem einzigen Schuss komplett zertören.</p>
	</div>
	
	<h2>Schlacht Informationen</h2>
	
	<table class='table'>
		<tr>
			<td>Angriff</td>
			<td>6800</td>
		</tr>
		<tr>
			<td>Verteidigung</td>
			<td>3500</td>
		</tr>
		<tr>
			<td>Reichweite</td>
			<td>3</td>
		</tr>
		<tr>
			<td>Bewegungskosten</td>
			<td>4</td>
		</tr>
		<tr>
			<td>Rassen</td>
			<td><a href='/de/Race/DarkHumans.aspx'>Renegades</a></td>
		</tr>
		<tr>
			<td>Kategorie</td>
			<td><a href='/de/Battles/Heavy.aspx'>Schwer</a></td>
		</tr>
		<tr>
			<td>Position</td>
			<td>Terrestrisch</td>
		</tr>
		<tr>
			<td>Bewegung</td>
			<td><a href='/de/Battles/Movement.aspx#MovFront'>Frontal-Bewegung</a></td>
		</tr>
	</table>
	
	<h3>Spezielle Fähigkeiten</h3><table class='table'><tr><th>Typ</th><th>Spezielle Fähigkeiten</th></tr><tr><td>Fähigkeiten nach dem Angriff</td><td><ul><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li></ul></td></tr></table>
	
	
	<h2>Information über die Konstruktion</h2>
	<table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 10</li></ul></td><td><ul><li>750 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>700 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>1125 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>375 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>125 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Stunde 30 Minuten </td><td><ul><li>Einheiten bewegen zur Verteidigungsflotte</li></ul></td><td><ul></ul></td></tr></table>
	
	</div>
	
</asp:Content>