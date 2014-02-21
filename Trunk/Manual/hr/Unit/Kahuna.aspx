﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Kahuna Jedinica
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Jedinice</h2><ul><li><a href='/hr/Unit/Doomer.aspx' class='doomer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Anihilator' /> Anihilator</a></li><li><a href='/hr/Unit/Anubis.aspx' class='anubis'><img src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /> Anubis</a></li><li><a href='/hr/Unit/Scourge.aspx' class='scourge'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scourge.png' alt='Bič' /> Bič</a></li><li><a href='/hr/Unit/Taurus.aspx' class='taurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Bik' /> Bik</a></li><li><a href='/hr/Unit/Blinker.aspx' class='blinker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Bljeskalica' /> Bljeskalica</a></li><li><a href='/hr/Unit/BattleMoon.aspx' class='battlemoon'><img src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Borbeni Mjesec' /> Borbeni Mjesec</a></li><li><a href='/hr/Unit/Bozer.aspx' class='bozer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /> Bozer</a></li><li><a href='/hr/Unit/Driller.aspx' class='driller'><img src='http://resources.orionsbelt.eu/Images/Common/Units/driller.png' alt='Bušitelj' /> Bušitelj</a></li><li><a href='/hr/Unit/CaptainWolf.aspx' class='captainwolf'><img src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='CaptainWolf' /> CaptainWolf</a></li><li><a href='/hr/Unit/CommanderFox.aspx' class='commanderfox'><img src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Commander Fox' /> Commander Fox</a></li><li><a href='/hr/Unit/Crawler.aspx' class='crawler'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crawler.png' alt='Crawler' /> Crawler</a></li><li><a href='/hr/Unit/DarkRain.aspx' class='darkrain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Crna Kiša' /> Crna Kiša</a></li><li><a href='/hr/Unit/BlackWidow.aspx' class='blackwidow'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Crna Udovica' /> Crna Udovica</a></li><li><a href='/hr/Unit/DarkCrusader.aspx' class='darkcrusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Crni Crusader' /> Crni Crusader</a></li><li><a href='/hr/Unit/Crusader.aspx' class='crusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Crusader' /> Crusader</a></li><li><a href='/hr/Unit/Maggot.aspx' class='maggot'><img src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Crv' /> Crv</a></li><li><a href='/hr/Unit/Cypher.aspx' class='cypher'><img src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /> Cypher</a></li><li><a href='/hr/Unit/Fenix.aspx' class='fenix'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Feniks' /> Feniks</a></li><li><a href='/hr/Unit/Fist.aspx' class='fist'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Fist' /> Fist</a></li><li><a href='/hr/Unit/Worm.aspx' class='worm'><img src='http://resources.orionsbelt.eu/Images/Common/Units/worm.png' alt='Glista' /> Glista</a></li><li><a href='/hr/Unit/Egg.aspx' class='egg'><img src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Jaje' /> Jaje</a></li><li><a href='/hr/Unit/Jumper.aspx' class='jumper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /> Jumper</a></li><li><a href='/hr/Unit/Kahuna.aspx' class='kahuna'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' /> Kahuna</a></li><li><a href='/hr/Unit/Kamikaze.aspx' class='kamikaze'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kamikaze.png' alt='Kamikaza' /> Kamikaza</a></li><li><a href='/hr/Unit/Rain.aspx' class='rain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Kiša' /> Kiša</a></li><li><a href='/hr/Unit/Scarab.aspx' class='scarab'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scarab.png' alt='Kornjaš' /> Kornjaš</a></li><li><a href='/hr/Unit/HiveKing.aspx' class='hiveking'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Kralj Košnice' /> Kralj Košnice</a></li><li><a href='/hr/Unit/Queen.aspx' class='queen'><img src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Kraljica' /> Kraljica</a></li><li><a href='/hr/Unit/Krill.aspx' class='krill'><img src='http://resources.orionsbelt.eu/Images/Common/Units/krill.png' alt='Krill' /> Krill</a></li><li><a href='/hr/Unit/MetallicBeard.aspx' class='metallicbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Metalna Brada' /> Metalna Brada</a></li><li><a href='/hr/Unit/Myst.aspx' class='myst'><img src='http://resources.orionsbelt.eu/Images/Common/Units/myst.png' alt='Myst' /> Myst</a></li><li><a href='/hr/Unit/Nova.aspx' class='nova'><img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /> Nova</a></li><li><a href='/hr/Unit/Eagle.aspx' class='eagle'><img src='http://resources.orionsbelt.eu/Images/Common/Units/eagle.png' alt='Orao' /> Orao</a></li><li><a href='/hr/Unit/Toxic.aspx' class='toxic'><img src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Otrovni' /> Otrovni</a></li><li><a href='/hr/Unit/Panther.aspx' class='panther'><img src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Pantera' /> Pantera</a></li><li><a href='/hr/Unit/Spider.aspx' class='spider'><img src='http://resources.orionsbelt.eu/Images/Common/Units/spider.png' alt='Pauk' /> Pauk</a></li><li><a href='/hr/Unit/Interceptor.aspx' class='interceptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Presretač' /> Presretač</a></li><li><a href='/hr/Unit/Pretorian.aspx' class='pretorian'><img src='http://resources.orionsbelt.eu/Images/Common/Units/pretorian.png' alt='Pretorijanac' /> Pretorijanac</a></li><li><a href='/hr/Unit/Raptor.aspx' class='raptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /> Raptor</a></li><li><a href='/hr/Unit/Destroyer.aspx' class='destroyer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/destroyer.png' alt='Razarač' /> Razarač</a></li><li><a href='/hr/Unit/Samurai.aspx' class='samurai'><img src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samuraj' /> Samuraj</a></li><li><a href='/hr/Unit/SilverBeard.aspx' class='silverbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Srebrena Brada' /> Srebrena Brada</a></li><li><a href='/hr/Unit/Sentry.aspx' class='sentry'><img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Stražar' /> Stražar</a></li><li><a href='/hr/Unit/DarkTaurus.aspx' class='darktaurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Tamni Bik' /> Tamni Bik</a></li><li><a href='/hr/Unit/HeavySeeker.aspx' class='heavyseeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Teški Tražilac' /> Teški Tražilac</a></li><li><a href='/hr/Unit/Titan.aspx' class='titan'><img src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /> Titan</a></li><li><a href='/hr/Unit/Seeker.aspx' class='seeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Tražilac' /> Tražilac</a></li><li><a href='/hr/Unit/Vector.aspx' class='vector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/vector.png' alt='Vector' /> Vector</a></li><li><a href='/hr/Unit/Walker.aspx' class='walker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/walker.png' alt='Walker' /> Walker</a></li><li><a href='/hr/Unit/Stinger.aspx' class='stinger'><img src='http://resources.orionsbelt.eu/Images/Common/Units/stinger.png' alt='Žalac' /> Žalac</a></li><li><a href='/hr/Unit/Flag.aspx' class='flag'><img src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Zastava' /> Zastava</a></li><li><a href='/hr/Unit/HiveProtector.aspx' class='hiveprotector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveprotector.png' alt='Zaštitnik Košnice' /> Zaštitnik Košnice</a></li><li><a href='/hr/Unit/Reaper.aspx' class='reaper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Žetalica' /> Žetalica</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<div class='smallerContent'>

	<h1><asp:Literal Text="Kahuna" runat="server" /></h1>

	<div class="description">
		<img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' />
		<a class='kahuna' href='/hr/Unit/Kahuna.aspx'>Kahuna</a> je izvrsna jedinica za čišćenje neprijateljske zaštite. Sposobnost za <a href='/hr/Battles/Rebound.aspx'>Povratni</a> može značiti razliku u većini slučajeva jer tjera neprijatelja da zaštiti još više njegovih jedinica (što znači trošenje više <a href='/hr/Battles/Movement.aspx#MovPoints'>Bodovi Pokreta</a> po turnu).
<p />
Ovisno o tipu Terena, obrana <a class='kahuna' href='/hr/Unit/Kahuna.aspx'>Kahuna</a> može ići od prosječne do odlične. Bazna obrana mu je 1300. Ako se bori protiv [Air] jedinica dobija dodatnih 400 bodova  i, ako je teren bitke Zemljani,  dobija još 400 bodova za total od 2100 (skoro kao prosječna <a href='/hr/Battles/Heavy.aspx'>Teški</a> jedinica)
	</div>
	
	<h2>Informacije o Bitci</h2>
	
	<table class='table'>
		<tr>
			<td>Napad</td>
			<td>1000</td>
		</tr>
		<tr>
			<td>Obrana</td>
			<td>1300</td>
		</tr>
		<tr>
			<td>Domet</td>
			<td>2</td>
		</tr>
		<tr>
			<td>Cijena Pokreta</td>
			<td>2</td>
		</tr>
		<tr>
			<td>Rase</td>
			<td><a href='/hr/Race/LightHumans.aspx'>Utopians</a></td>
		</tr>
		<tr>
			<td>Kategorija</td>
			<td><a href='/hr/Battles/Medium.aspx'>Srednji</a></td>
		</tr>
		<tr>
			<td>Pomak</td>
			<td>Zemlja</td>
		</tr>
		<tr>
			<td>Pokret</td>
			<td><a href='/hr/Battles/Movement.aspx#MovAll'>Totalni Pokret</a></td>
		</tr>
	</table>
	
	<h3>Specijalne Sposobnosti</h3><table class='table'><tr><th>Tip</th><th>Specijalne Sposobnosti</th></tr><tr><td>Nakon Napadačkih Poteza</td><td><ul><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul></td></tr></table>
	<h3>Bonus Jedinice</h3><table class='table'><tr><th>Meta</th><th>Napad</th><th>Obrana</th><th>Domet</th></tr><tr><td>Zemlja</td><td>0</td><td>400</td><td>0</td></tr><tr><td>Zrak</td><td>0</td><td>400</td><td>0</td></tr></table>
	
	<h2>Informacije o Gradnji</h2>
	<table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Brodogradilište Jedinica</a> Nivo 5</li></ul></td><td><ul><li>250 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>275 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>350 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>188 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>50 Minute </td><td><ul><li>Pomakni Jedinice U Obranbenu Flotu</li></ul></td><td><ul></ul></td></tr></table>
	
	</div>
	
</asp:Content>