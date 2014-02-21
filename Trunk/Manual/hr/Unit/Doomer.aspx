﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Anihilator Jedinica
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Jedinice</h2><ul><li><a href='/hr/Unit/Doomer.aspx' class='doomer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Anihilator' /> Anihilator</a></li><li><a href='/hr/Unit/Anubis.aspx' class='anubis'><img src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /> Anubis</a></li><li><a href='/hr/Unit/Scourge.aspx' class='scourge'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scourge.png' alt='Bič' /> Bič</a></li><li><a href='/hr/Unit/Taurus.aspx' class='taurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Bik' /> Bik</a></li><li><a href='/hr/Unit/Blinker.aspx' class='blinker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Bljeskalica' /> Bljeskalica</a></li><li><a href='/hr/Unit/BattleMoon.aspx' class='battlemoon'><img src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Borbeni Mjesec' /> Borbeni Mjesec</a></li><li><a href='/hr/Unit/Bozer.aspx' class='bozer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /> Bozer</a></li><li><a href='/hr/Unit/Driller.aspx' class='driller'><img src='http://resources.orionsbelt.eu/Images/Common/Units/driller.png' alt='Bušitelj' /> Bušitelj</a></li><li><a href='/hr/Unit/CaptainWolf.aspx' class='captainwolf'><img src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='CaptainWolf' /> CaptainWolf</a></li><li><a href='/hr/Unit/CommanderFox.aspx' class='commanderfox'><img src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Commander Fox' /> Commander Fox</a></li><li><a href='/hr/Unit/Crawler.aspx' class='crawler'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crawler.png' alt='Crawler' /> Crawler</a></li><li><a href='/hr/Unit/DarkRain.aspx' class='darkrain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Crna Kiša' /> Crna Kiša</a></li><li><a href='/hr/Unit/BlackWidow.aspx' class='blackwidow'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Crna Udovica' /> Crna Udovica</a></li><li><a href='/hr/Unit/DarkCrusader.aspx' class='darkcrusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Crni Crusader' /> Crni Crusader</a></li><li><a href='/hr/Unit/Crusader.aspx' class='crusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Crusader' /> Crusader</a></li><li><a href='/hr/Unit/Maggot.aspx' class='maggot'><img src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Crv' /> Crv</a></li><li><a href='/hr/Unit/Cypher.aspx' class='cypher'><img src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /> Cypher</a></li><li><a href='/hr/Unit/Fenix.aspx' class='fenix'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Feniks' /> Feniks</a></li><li><a href='/hr/Unit/Fist.aspx' class='fist'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Fist' /> Fist</a></li><li><a href='/hr/Unit/Worm.aspx' class='worm'><img src='http://resources.orionsbelt.eu/Images/Common/Units/worm.png' alt='Glista' /> Glista</a></li><li><a href='/hr/Unit/Egg.aspx' class='egg'><img src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Jaje' /> Jaje</a></li><li><a href='/hr/Unit/Jumper.aspx' class='jumper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /> Jumper</a></li><li><a href='/hr/Unit/Kahuna.aspx' class='kahuna'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' /> Kahuna</a></li><li><a href='/hr/Unit/Kamikaze.aspx' class='kamikaze'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kamikaze.png' alt='Kamikaza' /> Kamikaza</a></li><li><a href='/hr/Unit/Rain.aspx' class='rain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Kiša' /> Kiša</a></li><li><a href='/hr/Unit/Scarab.aspx' class='scarab'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scarab.png' alt='Kornjaš' /> Kornjaš</a></li><li><a href='/hr/Unit/HiveKing.aspx' class='hiveking'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Kralj Košnice' /> Kralj Košnice</a></li><li><a href='/hr/Unit/Queen.aspx' class='queen'><img src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Kraljica' /> Kraljica</a></li><li><a href='/hr/Unit/Krill.aspx' class='krill'><img src='http://resources.orionsbelt.eu/Images/Common/Units/krill.png' alt='Krill' /> Krill</a></li><li><a href='/hr/Unit/MetallicBeard.aspx' class='metallicbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Metalna Brada' /> Metalna Brada</a></li><li><a href='/hr/Unit/Myst.aspx' class='myst'><img src='http://resources.orionsbelt.eu/Images/Common/Units/myst.png' alt='Myst' /> Myst</a></li><li><a href='/hr/Unit/Nova.aspx' class='nova'><img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /> Nova</a></li><li><a href='/hr/Unit/Eagle.aspx' class='eagle'><img src='http://resources.orionsbelt.eu/Images/Common/Units/eagle.png' alt='Orao' /> Orao</a></li><li><a href='/hr/Unit/Toxic.aspx' class='toxic'><img src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Otrovni' /> Otrovni</a></li><li><a href='/hr/Unit/Panther.aspx' class='panther'><img src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Pantera' /> Pantera</a></li><li><a href='/hr/Unit/Spider.aspx' class='spider'><img src='http://resources.orionsbelt.eu/Images/Common/Units/spider.png' alt='Pauk' /> Pauk</a></li><li><a href='/hr/Unit/Interceptor.aspx' class='interceptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Presretač' /> Presretač</a></li><li><a href='/hr/Unit/Pretorian.aspx' class='pretorian'><img src='http://resources.orionsbelt.eu/Images/Common/Units/pretorian.png' alt='Pretorijanac' /> Pretorijanac</a></li><li><a href='/hr/Unit/Raptor.aspx' class='raptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /> Raptor</a></li><li><a href='/hr/Unit/Destroyer.aspx' class='destroyer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/destroyer.png' alt='Razarač' /> Razarač</a></li><li><a href='/hr/Unit/Samurai.aspx' class='samurai'><img src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samuraj' /> Samuraj</a></li><li><a href='/hr/Unit/SilverBeard.aspx' class='silverbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Srebrena Brada' /> Srebrena Brada</a></li><li><a href='/hr/Unit/Sentry.aspx' class='sentry'><img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Stražar' /> Stražar</a></li><li><a href='/hr/Unit/DarkTaurus.aspx' class='darktaurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Tamni Bik' /> Tamni Bik</a></li><li><a href='/hr/Unit/HeavySeeker.aspx' class='heavyseeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Teški Tražilac' /> Teški Tražilac</a></li><li><a href='/hr/Unit/Titan.aspx' class='titan'><img src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /> Titan</a></li><li><a href='/hr/Unit/Seeker.aspx' class='seeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Tražilac' /> Tražilac</a></li><li><a href='/hr/Unit/Vector.aspx' class='vector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/vector.png' alt='Vector' /> Vector</a></li><li><a href='/hr/Unit/Walker.aspx' class='walker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/walker.png' alt='Walker' /> Walker</a></li><li><a href='/hr/Unit/Stinger.aspx' class='stinger'><img src='http://resources.orionsbelt.eu/Images/Common/Units/stinger.png' alt='Žalac' /> Žalac</a></li><li><a href='/hr/Unit/Flag.aspx' class='flag'><img src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Zastava' /> Zastava</a></li><li><a href='/hr/Unit/HiveProtector.aspx' class='hiveprotector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveprotector.png' alt='Zaštitnik Košnice' /> Zaštitnik Košnice</a></li><li><a href='/hr/Unit/Reaper.aspx' class='reaper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Žetalica' /> Žetalica</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<div class='smallerContent'>

	<h1><asp:Literal Text="Anihilator" runat="server" /></h1>

	<div class="description">
		<img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Anihilator' />
		<a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a> je ekstremno zanimljiva jedinica jer ima enormnu napadačku snagu i njihove specijalne moći, dobar igrač na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> koji zna kako upotrijebiti <a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a> moći će razoriti neprijateljsku <a href='/hr/Universe/Fleet.aspx'>Flota</a> u nekoliko napada. <p />
<a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a> napad je jako teško za blokirati jer ima <a href='/hr/Battles/Catapult.aspx'>Katapult</a>. I na vrh toga još ima <a href='/hr/Battles/Rebound.aspx'>Povratni</a> i ogtomnu napadčku moć što od njega čini razarujuću jedinicu.<p />
Ali <a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a> ima 2 problema, <a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a> koji otežava pozicioniranje i lošu obranu, koja ga čini krhkim čak i slabijim <a href='/hr/UnitIndex.aspx'>Jedinice</a>, pa zbog toga motate biti dobar igrač da uzmete punu prednost ove jedinice.
	</div>
	
	<h2>Informacije o Bitci</h2>
	
	<table class='table'>
		<tr>
			<td>Napad</td>
			<td>6000</td>
		</tr>
		<tr>
			<td>Obrana</td>
			<td>500</td>
		</tr>
		<tr>
			<td>Domet</td>
			<td>3</td>
		</tr>
		<tr>
			<td>Cijena Pokreta</td>
			<td>3</td>
		</tr>
		<tr>
			<td>Rase</td>
			<td><a href='/hr/Race/DarkHumans.aspx'>Renegades</a></td>
		</tr>
		<tr>
			<td>Kategorija</td>
			<td><a href='/hr/Battles/Heavy.aspx'>Teški</a></td>
		</tr>
		<tr>
			<td>Pomak</td>
			<td>Zrak</td>
		</tr>
		<tr>
			<td>Pokret</td>
			<td><a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a></td>
		</tr>
	</table>
	
	<h3>Specijalne Sposobnosti</h3><table class='table'><tr><th>Tip</th><th>Specijalne Sposobnosti</th></tr><tr><td>Napadački Pokereti</td><td><a href='/hr/Battles/Catapult.aspx'>Katapult</a></td></tr><tr><td>Nakon Napadačkih Poteza</td><td><ul><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul></td></tr></table>
	
	
	<h2>Informacije o Gradnji</h2>
	<table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 8</li></ul></td><td><ul><li>400 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>625 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>750 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>125 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>1 Sat 10 Minute </td><td><ul><li>Pomakni Jedinice U Obranbenu Flotu</li></ul></td><td><ul></ul></td></tr></table>
	
	</div>
	
</asp:Content>