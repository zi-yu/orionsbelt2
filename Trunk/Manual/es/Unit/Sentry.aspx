<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Unidad Sentry
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Unidades</h2><ul><li><a href='/es/Unit/Stinger.aspx' class='stinger'><img src='http://resources.orionsbelt.eu/Images/Common/Units/stinger.png' alt='Aguijón' /> Aguijón</a></li><li><a href='/es/Unit/Eagle.aspx' class='eagle'><img src='http://resources.orionsbelt.eu/Images/Common/Units/eagle.png' alt='Aguila' /> Aguila</a></li><li><a href='/es/Unit/Doomer.aspx' class='doomer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Aniquiladora' /> Aniquiladora</a></li><li><a href='/es/Unit/Anubis.aspx' class='anubis'><img src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /> Anubis</a></li><li><a href='/es/Unit/Spider.aspx' class='spider'><img src='http://resources.orionsbelt.eu/Images/Common/Units/spider.png' alt='Araña' /> Araña</a></li><li><a href='/es/Unit/Flag.aspx' class='flag'><img src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Bandera' /> Bandera</a></li><li><a href='/es/Unit/MetallicBeard.aspx' class='metallicbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Barba de Metal' /> Barba de Metal</a></li><li><a href='/es/Unit/Bozer.aspx' class='bozer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /> Bozer</a></li><li><a href='/es/Unit/Seeker.aspx' class='seeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Buscador' /> Buscador</a></li><li><a href='/es/Unit/CaptainWolf.aspx' class='captainwolf'><img src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='CaptainWolf' /> CaptainWolf</a></li><li><a href='/es/Unit/CommanderFox.aspx' class='commanderfox'><img src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Commander Fox' /> Commander Fox</a></li><li><a href='/es/Unit/Crawler.aspx' class='crawler'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crawler.png' alt='Crawler' /> Crawler</a></li><li><a href='/es/Unit/Crusader.aspx' class='crusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Cruzador' /> Cruzador</a></li><li><a href='/es/Unit/DarkCrusader.aspx' class='darkcrusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Cruzador Sombrio' /> Cruzador Sombrio</a></li><li><a href='/es/Unit/Cypher.aspx' class='cypher'><img src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /> Cypher</a></li><li><a href='/es/Unit/Destroyer.aspx' class='destroyer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/destroyer.png' alt='Destructor' /> Destructor</a></li><li><a href='/es/Unit/Scarab.aspx' class='scarab'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scarab.png' alt='Escarabajo' /> Escarabajo</a></li><li><a href='/es/Unit/Fenix.aspx' class='fenix'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Fénix' /> Fénix</a></li><li><a href='/es/Unit/Fist.aspx' class='fist'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Fist' /> Fist</a></li><li><a href='/es/Unit/Scourge.aspx' class='scourge'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scourge.png' alt='Flagelo' /> Flagelo</a></li><li><a href='/es/Unit/Worm.aspx' class='worm'><img src='http://resources.orionsbelt.eu/Images/Common/Units/worm.png' alt='Gusano' /> Gusano</a></li><li><a href='/es/Unit/Egg.aspx' class='egg'><img src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Huevo' /> Huevo</a></li><li><a href='/es/Unit/Interceptor.aspx' class='interceptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Interceptador' /> Interceptador</a></li><li><a href='/es/Unit/Jumper.aspx' class='jumper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /> Jumper</a></li><li><a href='/es/Unit/Kahuna.aspx' class='kahuna'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' /> Kahuna</a></li><li><a href='/es/Unit/Krill.aspx' class='krill'><img src='http://resources.orionsbelt.eu/Images/Common/Units/krill.png' alt='Krill' /> Krill</a></li><li><a href='/es/Unit/Maggot.aspx' class='maggot'><img src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Larva' /> Larva</a></li><li><a href='/es/Unit/Rain.aspx' class='rain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Lluvia' /> Lluvia</a></li><li><a href='/es/Unit/DarkRain.aspx' class='darkrain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Lluvia Sombría' /> Lluvia Sombría</a></li><li><a href='/es/Unit/BattleMoon.aspx' class='battlemoon'><img src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Luna de Batalla' /> Luna de Batalla</a></li><li><a href='/es/Unit/HeavySeeker.aspx' class='heavyseeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Mega Buscador' /> Mega Buscador</a></li><li><a href='/es/Unit/Myst.aspx' class='myst'><img src='http://resources.orionsbelt.eu/Images/Common/Units/myst.png' alt='Myst' /> Myst</a></li><li><a href='/es/Unit/Nova.aspx' class='nova'><img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /> Nova</a></li><li><a href='/es/Unit/Panther.aspx' class='panther'><img src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Pantera' /> Pantera</a></li><li><a href='/es/Unit/Blinker.aspx' class='blinker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Parpadeante' /> Parpadeante</a></li><li><a href='/es/Unit/Driller.aspx' class='driller'><img src='http://resources.orionsbelt.eu/Images/Common/Units/driller.png' alt='Perforador' /> Perforador</a></li><li><a href='/es/Unit/Pretorian.aspx' class='pretorian'><img src='http://resources.orionsbelt.eu/Images/Common/Units/pretorian.png' alt='Pretoriana' /> Pretoriana</a></li><li><a href='/es/Unit/HiveProtector.aspx' class='hiveprotector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveprotector.png' alt='Protector de la Colmena' /> Protector de la Colmena</a></li><li><a href='/es/Unit/Raptor.aspx' class='raptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /> Raptor</a></li><li><a href='/es/Unit/Reaper.aspx' class='reaper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /> Reaper</a></li><li><a href='/es/Unit/Queen.aspx' class='queen'><img src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Reina' /> Reina</a></li><li><a href='/es/Unit/HiveKing.aspx' class='hiveking'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Rey de la Colmena' /> Rey de la Colmena</a></li><li><a href='/es/Unit/Samurai.aspx' class='samurai'><img src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /> Samurai</a></li><li><a href='/es/Unit/Sentry.aspx' class='sentry'><img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /> Sentry</a></li><li><a href='/es/Unit/SilverBeard.aspx' class='silverbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Silver Beard' /> Silver Beard</a></li><li><a href='/es/Unit/Kamikaze.aspx' class='kamikaze'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kamikaze.png' alt='Suicida' /> Suicida</a></li><li><a href='/es/Unit/Titan.aspx' class='titan'><img src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /> Titan</a></li><li><a href='/es/Unit/Taurus.aspx' class='taurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Toro' /> Toro</a></li><li><a href='/es/Unit/DarkTaurus.aspx' class='darktaurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Toro Oscuro' /> Toro Oscuro</a></li><li><a href='/es/Unit/Toxic.aspx' class='toxic'><img src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxico' /> Toxico</a></li><li><a href='/es/Unit/Vector.aspx' class='vector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/vector.png' alt='Vector' /> Vector</a></li><li><a href='/es/Unit/BlackWidow.aspx' class='blackwidow'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Viuda Negra' /> Viuda Negra</a></li><li><a href='/es/Unit/Walker.aspx' class='walker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/walker.png' alt='Walker' /> Walker</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<div class='smallerContent'>

	<h1><asp:Literal Text="Sentry" runat="server" /></h1>

	<div class="description">
		<img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' />
		The <a class='sentry' href='/es/Unit/Sentry.aspx'>Sentry</a> is a <a href='/es/Race/Mercs.aspx'>Mercs</a> <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> unit. It's stronger than most light units and it has a very special power: 
  <a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a>. With this power, a single <a class='sentry' href='/es/Unit/Sentry.aspx'>Sentry</a> unit may make useless every powerful unit on the game.
  <p />
  And with total movement type, the <a class='sentry' href='/es/Unit/Sentry.aspx'>Sentry</a> can also be used as <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a>.
	</div>
	
	<h2>Información de Batalla</h2>
	
	<table class='table'>
		<tr>
			<td>Ataque</td>
			<td>200</td>
		</tr>
		<tr>
			<td>Defensa</td>
			<td>100</td>
		</tr>
		<tr>
			<td>Alcance</td>
			<td>1</td>
		</tr>
		<tr>
			<td>Costo de Movimiento</td>
			<td>1</td>
		</tr>
		<tr>
			<td>Razas</td>
			<td><a href='/es/Race/Mercs.aspx'>Mercs</a></td>
		</tr>
		<tr>
			<td>Categoría</td>
			<td><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></td>
		</tr>
		<tr>
			<td>Posición</td>
			<td>Aire</td>
		</tr>
		<tr>
			<td>Movimiento</td>
			<td><a href='/es/Battles/Movement.aspx#MovAll'>Movimiento Total</a></td>
		</tr>
	</table>
	
	<h3>Habilidades Especiales</h3><table class='table'><tr><th>Tipo</th><th>Habilidades Especiales</th></tr><tr><td>Habilidades Post-Ataque</td><td><ul><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li></ul></td></tr></table>
	
	
	
	</div>
	
</asp:Content>