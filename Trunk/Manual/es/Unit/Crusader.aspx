﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Unidad Cruzador
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Unidades</h2><ul><li><a href='/es/Unit/Stinger.aspx' class='stinger'><img src='http://resources.orionsbelt.eu/Images/Common/Units/stinger.png' alt='Aguijón' /> Aguijón</a></li><li><a href='/es/Unit/Eagle.aspx' class='eagle'><img src='http://resources.orionsbelt.eu/Images/Common/Units/eagle.png' alt='Aguila' /> Aguila</a></li><li><a href='/es/Unit/Doomer.aspx' class='doomer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Aniquiladora' /> Aniquiladora</a></li><li><a href='/es/Unit/Anubis.aspx' class='anubis'><img src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /> Anubis</a></li><li><a href='/es/Unit/Spider.aspx' class='spider'><img src='http://resources.orionsbelt.eu/Images/Common/Units/spider.png' alt='Araña' /> Araña</a></li><li><a href='/es/Unit/Flag.aspx' class='flag'><img src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Bandera' /> Bandera</a></li><li><a href='/es/Unit/MetallicBeard.aspx' class='metallicbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Barba de Metal' /> Barba de Metal</a></li><li><a href='/es/Unit/Bozer.aspx' class='bozer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /> Bozer</a></li><li><a href='/es/Unit/Seeker.aspx' class='seeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Buscador' /> Buscador</a></li><li><a href='/es/Unit/CaptainWolf.aspx' class='captainwolf'><img src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='CaptainWolf' /> CaptainWolf</a></li><li><a href='/es/Unit/CommanderFox.aspx' class='commanderfox'><img src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Commander Fox' /> Commander Fox</a></li><li><a href='/es/Unit/Crawler.aspx' class='crawler'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crawler.png' alt='Crawler' /> Crawler</a></li><li><a href='/es/Unit/Crusader.aspx' class='crusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Cruzador' /> Cruzador</a></li><li><a href='/es/Unit/DarkCrusader.aspx' class='darkcrusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Cruzador Sombrio' /> Cruzador Sombrio</a></li><li><a href='/es/Unit/Cypher.aspx' class='cypher'><img src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /> Cypher</a></li><li><a href='/es/Unit/Destroyer.aspx' class='destroyer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/destroyer.png' alt='Destructor' /> Destructor</a></li><li><a href='/es/Unit/Scarab.aspx' class='scarab'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scarab.png' alt='Escarabajo' /> Escarabajo</a></li><li><a href='/es/Unit/Fenix.aspx' class='fenix'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Fénix' /> Fénix</a></li><li><a href='/es/Unit/Fist.aspx' class='fist'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Fist' /> Fist</a></li><li><a href='/es/Unit/Scourge.aspx' class='scourge'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scourge.png' alt='Flagelo' /> Flagelo</a></li><li><a href='/es/Unit/Worm.aspx' class='worm'><img src='http://resources.orionsbelt.eu/Images/Common/Units/worm.png' alt='Gusano' /> Gusano</a></li><li><a href='/es/Unit/Egg.aspx' class='egg'><img src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Huevo' /> Huevo</a></li><li><a href='/es/Unit/Interceptor.aspx' class='interceptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Interceptador' /> Interceptador</a></li><li><a href='/es/Unit/Jumper.aspx' class='jumper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /> Jumper</a></li><li><a href='/es/Unit/Kahuna.aspx' class='kahuna'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' /> Kahuna</a></li><li><a href='/es/Unit/Krill.aspx' class='krill'><img src='http://resources.orionsbelt.eu/Images/Common/Units/krill.png' alt='Krill' /> Krill</a></li><li><a href='/es/Unit/Maggot.aspx' class='maggot'><img src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Larva' /> Larva</a></li><li><a href='/es/Unit/Rain.aspx' class='rain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Lluvia' /> Lluvia</a></li><li><a href='/es/Unit/DarkRain.aspx' class='darkrain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Lluvia Sombría' /> Lluvia Sombría</a></li><li><a href='/es/Unit/BattleMoon.aspx' class='battlemoon'><img src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Luna de Batalla' /> Luna de Batalla</a></li><li><a href='/es/Unit/HeavySeeker.aspx' class='heavyseeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Mega Buscador' /> Mega Buscador</a></li><li><a href='/es/Unit/Myst.aspx' class='myst'><img src='http://resources.orionsbelt.eu/Images/Common/Units/myst.png' alt='Myst' /> Myst</a></li><li><a href='/es/Unit/Nova.aspx' class='nova'><img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /> Nova</a></li><li><a href='/es/Unit/Panther.aspx' class='panther'><img src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Pantera' /> Pantera</a></li><li><a href='/es/Unit/Blinker.aspx' class='blinker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Parpadeante' /> Parpadeante</a></li><li><a href='/es/Unit/Driller.aspx' class='driller'><img src='http://resources.orionsbelt.eu/Images/Common/Units/driller.png' alt='Perforador' /> Perforador</a></li><li><a href='/es/Unit/Pretorian.aspx' class='pretorian'><img src='http://resources.orionsbelt.eu/Images/Common/Units/pretorian.png' alt='Pretoriana' /> Pretoriana</a></li><li><a href='/es/Unit/HiveProtector.aspx' class='hiveprotector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveprotector.png' alt='Protector de la Colmena' /> Protector de la Colmena</a></li><li><a href='/es/Unit/Raptor.aspx' class='raptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /> Raptor</a></li><li><a href='/es/Unit/Reaper.aspx' class='reaper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /> Reaper</a></li><li><a href='/es/Unit/Queen.aspx' class='queen'><img src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Reina' /> Reina</a></li><li><a href='/es/Unit/HiveKing.aspx' class='hiveking'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Rey de la Colmena' /> Rey de la Colmena</a></li><li><a href='/es/Unit/Samurai.aspx' class='samurai'><img src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /> Samurai</a></li><li><a href='/es/Unit/Sentry.aspx' class='sentry'><img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /> Sentry</a></li><li><a href='/es/Unit/SilverBeard.aspx' class='silverbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Silver Beard' /> Silver Beard</a></li><li><a href='/es/Unit/Kamikaze.aspx' class='kamikaze'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kamikaze.png' alt='Suicida' /> Suicida</a></li><li><a href='/es/Unit/Titan.aspx' class='titan'><img src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /> Titan</a></li><li><a href='/es/Unit/Taurus.aspx' class='taurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Toro' /> Toro</a></li><li><a href='/es/Unit/DarkTaurus.aspx' class='darktaurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Toro Oscuro' /> Toro Oscuro</a></li><li><a href='/es/Unit/Toxic.aspx' class='toxic'><img src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxico' /> Toxico</a></li><li><a href='/es/Unit/Vector.aspx' class='vector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/vector.png' alt='Vector' /> Vector</a></li><li><a href='/es/Unit/BlackWidow.aspx' class='blackwidow'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Viuda Negra' /> Viuda Negra</a></li><li><a href='/es/Unit/Walker.aspx' class='walker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/walker.png' alt='Walker' /> Walker</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<div class='smallerContent'>

	<h1><asp:Literal Text="Cruzador" runat="server" /></h1>

	<div class="description">
		<img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Cruzador' />
		Los <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a> tienen como característica mas importante un largo <a href='/es/Battles/Range.aspx'>Alcance</a> (<a href='/es/Battles/Range.aspx'>Alcance</a> de 6) lo que las destingue de las unidades restantes .<p />
  Esta es la unidad de <a href='/es/Battles/Heavy.aspx'>Gran Porte</a> mas básica de los <a href='/es/Race/LightHumans.aspx'>Utopianos</a> y no posee  cualquier tipo de poder especial. Tiene  <a href='/es/Battles/Movement.aspx#MovFront'>Movimiento Frontal</a> lo que la torna una
  unidad difícil de maniobrar lo cual es compensado por el largo alcance.
	</div>
	
	<h2>Información de Batalla</h2>
	
	<table class='table'>
		<tr>
			<td>Ataque</td>
			<td>2400</td>
		</tr>
		<tr>
			<td>Defensa</td>
			<td>2200</td>
		</tr>
		<tr>
			<td>Alcance</td>
			<td>6</td>
		</tr>
		<tr>
			<td>Costo de Movimiento</td>
			<td>4</td>
		</tr>
		<tr>
			<td>Razas</td>
			<td><a href='/es/Race/LightHumans.aspx'>Utopianos</a></td>
		</tr>
		<tr>
			<td>Categoría</td>
			<td><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></td>
		</tr>
		<tr>
			<td>Posición</td>
			<td>Aire</td>
		</tr>
		<tr>
			<td>Movimiento</td>
			<td><a href='/es/Battles/Movement.aspx#MovFront'>Movimiento Frontal</a></td>
		</tr>
	</table>
	
	
	
	
	<h2>Información de Construcción</h2>
	<table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Puerto Espacial</a> Nivel 7</li></ul></td><td><ul><li>675 <a href='../Intrinsic/Energy.aspx'>Energía</a></li><li>750 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>825 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li></ul></td><td class='duration'>1 Hora 10 Minutos </td><td><ul><li>Mover las Unidades para la Flota de Defensa</li></ul></td><td><ul></ul></td></tr></table>
	
	</div>
	
</asp:Content>