<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Regen Einheit
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Einheiten</h2><ul><li><a href='/de/Unit/Interceptor.aspx' class='interceptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Abfangjäger' /> Abfangjäger</a></li><li><a href='/de/Unit/Eagle.aspx' class='eagle'><img src='http://resources.orionsbelt.eu/Images/Common/Units/eagle.png' alt='Adler' /> Adler</a></li><li><a href='/de/Unit/Anubis.aspx' class='anubis'><img src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /> Anubis</a></li><li><a href='/de/Unit/HiveProtector.aspx' class='hiveprotector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveprotector.png' alt='Bienenstock Beschützer' /> Bienenstock Beschützer</a></li><li><a href='/de/Unit/HiveKing.aspx' class='hiveking'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Bienenstock König' /> Bienenstock König</a></li><li><a href='/de/Unit/Blinker.aspx' class='blinker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Blinker' /> Blinker</a></li><li><a href='/de/Unit/Driller.aspx' class='driller'><img src='http://resources.orionsbelt.eu/Images/Common/Units/driller.png' alt='Bohrer' /> Bohrer</a></li><li><a href='/de/Unit/Bozer.aspx' class='bozer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /> Bozer</a></li><li><a href='/de/Unit/Cypher.aspx' class='cypher'><img src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /> Cypher</a></li><li><a href='/de/Unit/Doomer.aspx' class='doomer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Doomer' /> Doomer</a></li><li><a href='/de/Unit/DarkCrusader.aspx' class='darkcrusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Dunkler Kreuzfahrer' /> Dunkler Kreuzfahrer</a></li><li><a href='/de/Unit/DarkRain.aspx' class='darkrain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Dunkler Regen' /> Dunkler Regen</a></li><li><a href='/de/Unit/DarkTaurus.aspx' class='darktaurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Dunkler Taurus' /> Dunkler Taurus</a></li><li><a href='/de/Unit/Egg.aspx' class='egg'><img src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Ei' /> Ei</a></li><li><a href='/de/Unit/Fist.aspx' class='fist'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Faust' /> Faust</a></li><li><a href='/de/Unit/Fenix.aspx' class='fenix'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Fenix' /> Fenix</a></li><li><a href='/de/Unit/Flag.aspx' class='flag'><img src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Flagge' /> Flagge</a></li><li><a href='/de/Unit/Kahuna.aspx' class='kahuna'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' /> Kahuna</a></li><li><a href='/de/Unit/Kamikaze.aspx' class='kamikaze'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kamikaze.png' alt='Kamikaze' /> Kamikaze</a></li><li><a href='/de/Unit/CaptainWolf.aspx' class='captainwolf'><img src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='Kapitän Wolf' /> Kapitän Wolf</a></li><li><a href='/de/Unit/CommanderFox.aspx' class='commanderfox'><img src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Kommander Fox' /> Kommander Fox</a></li><li><a href='/de/Unit/Queen.aspx' class='queen'><img src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Königin' /> Königin</a></li><li><a href='/de/Unit/Crusader.aspx' class='crusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Kreuzfahrer' /> Kreuzfahrer</a></li><li><a href='/de/Unit/Crawler.aspx' class='crawler'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crawler.png' alt='Kriecher' /> Kriecher</a></li><li><a href='/de/Unit/Krill.aspx' class='krill'><img src='http://resources.orionsbelt.eu/Images/Common/Units/krill.png' alt='Krill' /> Krill</a></li><li><a href='/de/Unit/Maggot.aspx' class='maggot'><img src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Made' /> Made</a></li><li><a href='/de/Unit/HeavySeeker.aspx' class='heavyseeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Mega Sucher' /> Mega Sucher</a></li><li><a href='/de/Unit/MetallicBeard.aspx' class='metallicbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Metallischer Bart' /> Metallischer Bart</a></li><li><a href='/de/Unit/BattleMoon.aspx' class='battlemoon'><img src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Mond-Schlacht' /> Mond-Schlacht</a></li><li><a href='/de/Unit/Myst.aspx' class='myst'><img src='http://resources.orionsbelt.eu/Images/Common/Units/myst.png' alt='Myst' /> Myst</a></li><li><a href='/de/Unit/Nova.aspx' class='nova'><img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /> Nova</a></li><li><a href='/de/Unit/Panther.aspx' class='panther'><img src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Panther' /> Panther</a></li><li><a href='/de/Unit/Pretorian.aspx' class='pretorian'><img src='http://resources.orionsbelt.eu/Images/Common/Units/pretorian.png' alt='Praetorian' /> Praetorian</a></li><li><a href='/de/Unit/Raptor.aspx' class='raptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /> Raptor</a></li><li><a href='/de/Unit/Reaper.aspx' class='reaper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /> Reaper</a></li><li><a href='/de/Unit/Rain.aspx' class='rain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Regen' /> Regen</a></li><li><a href='/de/Unit/Samurai.aspx' class='samurai'><img src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /> Samurai</a></li><li><a href='/de/Unit/BlackWidow.aspx' class='blackwidow'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Schwarze Witwe' /> Schwarze Witwe</a></li><li><a href='/de/Unit/Scourge.aspx' class='scourge'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scourge.png' alt='Scourge' /> Scourge</a></li><li><a href='/de/Unit/Sentry.aspx' class='sentry'><img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /> Sentry</a></li><li><a href='/de/Unit/SilverBeard.aspx' class='silverbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Silberbart' /> Silberbart</a></li><li><a href='/de/Unit/Scarab.aspx' class='scarab'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scarab.png' alt='Skarabäus' /> Skarabäus</a></li><li><a href='/de/Unit/Spider.aspx' class='spider'><img src='http://resources.orionsbelt.eu/Images/Common/Units/spider.png' alt='Spinne' /> Spinne</a></li><li><a href='/de/Unit/Jumper.aspx' class='jumper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Springer' /> Springer</a></li><li><a href='/de/Unit/Stinger.aspx' class='stinger'><img src='http://resources.orionsbelt.eu/Images/Common/Units/stinger.png' alt='Stachel' /> Stachel</a></li><li><a href='/de/Unit/Seeker.aspx' class='seeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Sucher' /> Sucher</a></li><li><a href='/de/Unit/Taurus.aspx' class='taurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Taurus' /> Taurus</a></li><li><a href='/de/Unit/Titan.aspx' class='titan'><img src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /> Titan</a></li><li><a href='/de/Unit/Toxic.aspx' class='toxic'><img src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxisch' /> Toxisch</a></li><li><a href='/de/Unit/Vector.aspx' class='vector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/vector.png' alt='Vektor' /> Vektor</a></li><li><a href='/de/Unit/Walker.aspx' class='walker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/walker.png' alt='Walker' /> Walker</a></li><li><a href='/de/Unit/Worm.aspx' class='worm'><img src='http://resources.orionsbelt.eu/Images/Common/Units/worm.png' alt='Wurm' /> Wurm</a></li><li><a href='/de/Unit/Destroyer.aspx' class='destroyer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/destroyer.png' alt='Zerstörer' /> Zerstörer</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<div class='smallerContent'>

	<h1><asp:Literal Text="Regen" runat="server" /></h1>

	<div class="description">
		<img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Regen' />
		Klein, schnell und günstig, der <a class='rain' href='/de/Unit/Rain.aspx'>Regen</a> ist einer der wichtigsten Einheit der <a href='/de/Race/LightHumans.aspx'>Utopians</a> Armee. Es ist ideal um Angriffe von anderen Einheiten zu blocken um eine weitaus wichtigere Einheit schützen (siehe <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a>).
  <p>
  Und auch der Bonus gegen <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten macht es zur perfekten Addition einer jeden Flotte.
  </p><p>
 Seine <a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a> ist 1, wie die meisten der <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten, und hat <a href='/de/Battles/Movement.aspx#MovAll'>Totale Beweglichkeit</a>.</p>
	</div>
	
	<h2>Schlacht Informationen</h2>
	
	<table class='table'>
		<tr>
			<td>Angriff</td>
			<td>120</td>
		</tr>
		<tr>
			<td>Verteidigung</td>
			<td>70</td>
		</tr>
		<tr>
			<td>Reichweite</td>
			<td>1</td>
		</tr>
		<tr>
			<td>Bewegungskosten</td>
			<td>1</td>
		</tr>
		<tr>
			<td>Rassen</td>
			<td><a href='/de/Race/LightHumans.aspx'>Utopians</a></td>
		</tr>
		<tr>
			<td>Kategorie</td>
			<td><a href='/de/Battles/Light.aspx'>Licht</a></td>
		</tr>
		<tr>
			<td>Position</td>
			<td>Luft</td>
		</tr>
		<tr>
			<td>Bewegung</td>
			<td><a href='/de/Battles/Movement.aspx#MovAll'>Totale Beweglichkeit</a></td>
		</tr>
	</table>
	
	
	<h3>Einheiten Bonus</h3><table class='table'><tr><th>Ziel</th><th>Angriff</th><th>Verteidigung</th><th>Reichweite</th></tr><tr><td>Schwer</td><td>1200</td><td>0</td><td>0</td></tr></table>
	
	<h2>Information über die Konstruktion</h2>
	<table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Weltraumhafen</a> Level 1</li></ul></td><td><ul><li>250 <a href='../Intrinsic/Energy.aspx'>Energie</a></li><li>175 <a href='../Intrinsic/Serium.aspx'>Serium</a></li></ul></td><td class='duration'>10 Minuten </td><td><ul><li>Einheiten bewegen zur Verteidigungsflotte</li></ul></td><td><ul></ul></td></tr></table>
	
	</div>
	
</asp:Content>