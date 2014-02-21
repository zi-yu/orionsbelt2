﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Hangar de Domínio
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edificios</h2><ul><li><a href='/es/Facility/Silo.aspx'>Bodega</a></li><li><a href='/es/Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a></li><li><a href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a></li><li><a href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/es/Facility/Devastation.aspx'>Devastación</a></li><li><a href='/es/Facility/Incubator.aspx'>Encubadora</a></li><li><a href='/es/Facility/QueenHatchery.aspx'>Encubadora de Reinas</a></li><li><a href='/es/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/es/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/es/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/es/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/es/Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a></li><li><a href='/es/Facility/NuclearFacility.aspx'>Extractor de Uranio</a></li><li><a href='/es/Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a></li><li><a href='/es/Facility/BlinkerAssembler.aspx'>Fábrica de Parpadeantes</a></li><li><a href='/es/Facility/WormHoleCreator.aspx'>Generador de Pasajes</a></li><li><a href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a></li><li><a href='/es/Facility/Nest.aspx'>Nido</a></li><li><a href='/es/Facility/SolarPanel.aspx'>Panel Solar</a></li><li><a href='/es/Facility/UnitYard.aspx'>Puerto Espacial</a></li><li><a href='/es/Facility/DeepSpaceScanner.aspx'>Radar de Largo Alcance</a></li><li><a href='/es/Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Hangar de Domínio" runat="server" /></h1>

	<div class="description">
		A <a class='dominationyard' href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a> es el edifício de los <a href='/es/Race/DarkHumans.aspx'>Renegados</a> que les permite crear <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>. Dependiendo de su nivel,
  la <a class='dominationyard' href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a> puede permitir crear: <a class='darkrain' href='/es/Unit/DarkRain.aspx'>Lluvia Sombría</a>, <a class='toxic' href='/es/Unit/Toxic.aspx'>Toxico</a>, <a class='anubis' href='/es/Unit/Anubis.aspx'>Anubis</a>, <a class='driller' href='/es/Unit/Driller.aspx'>Perforador</a>, <a class='panther' href='/es/Unit/Panther.aspx'>Pantera</a>,
  <a class='scarab' href='/es/Unit/Scarab.aspx'>Escarabajo</a>, <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a>, <a class='vector' href='/es/Unit/Vector.aspx'>Vector</a>, <a class='darkcrusader' href='/es/Unit/DarkCrusader.aspx'>Cruzador Sombrio</a>, <a class='doomer' href='/es/Unit/Doomer.aspx'>Aniquiladora</a>, <a class='bozer' href='/es/Unit/Bozer.aspx'>Bozer</a> y <a class='darktaurus' href='/es/Unit/DarkTaurus.aspx'>Toro Oscuro</a>.
		<div class='baseDarkHumansPreview DarkHumansDominationYardPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Hangar de Domínio Nivel 1</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 1</li></ul></td><td><ul><li>380 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>350 <a href='../Intrinsic/Gold.aspx'>Oro</a></li></ul></td><td class='duration'>10 Minutos </td><td><ul><li>+6 De pontuación</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 2</li><li><a href='../Unit/DarkRain.aspx'>Lluvia Sombría</a></li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Hangar de Domínio Nivel 2</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 2</li></ul></td><td><ul><li>1520 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>1400 <a href='../Intrinsic/Gold.aspx'>Oro</a></li></ul></td><td class='duration'>40 Minutos </td><td><ul><li>+48 De pontuación</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 3</li><li><a href='../Unit/Toxic.aspx'>Toxico</a></li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Hangar de Domínio Nivel 3</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 3</li></ul></td><td><ul><li>3420 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>3150 <a href='../Intrinsic/Gold.aspx'>Oro</a></li></ul></td><td class='duration'>2 Horas 10 Minutos </td><td><ul><li>+162 De pontuación</li></ul></td><td><ul><li><a href='../Unit/Driller.aspx'>Perforador</a></li><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 4</li><li><a href='../Unit/Anubis.aspx'>Anubis</a></li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Hangar de Domínio Nivel 4</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 4</li></ul></td><td><ul><li>1340 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>6080 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>5600 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>830 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>4 Horas 50 Minutos </td><td><ul><li>+384 De pontuación</li></ul></td><td><ul><li><a href='../Unit/Panther.aspx'>Pantera</a></li><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 5</li><li><a href='../Unit/Scarab.aspx'>Escarabajo</a></li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Hangar de Domínio Nivel 5</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 5</li></ul></td><td><ul><li>5000 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>9500 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>8750 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>2000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>422 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>9 Horas 30 Minutos </td><td><ul><li>+750 De pontuación</li></ul></td><td><ul><li><a href='../Unit/Kamikaze.aspx'>Suicida</a></li><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 6</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Hangar de Domínio Nivel 6</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 6</li></ul></td><td><ul><li>10460 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>13680 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>12600 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>3430 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1275 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>16 Horas 20 Minutos </td><td><ul><li>+1296 De pontuación</li></ul></td><td><ul><li><a href='../Unit/Vector.aspx'>Vector</a></li><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 7</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Hangar de Domínio Nivel 7</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 7</li></ul></td><td><ul><li>18080 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>18620 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>17150 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>5120 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2466 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>930 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>1 Día 1 Hora 50 Minutos </td><td><ul><li>+2058 De pontuación</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 8</li><li><a href='../Unit/DarkCrusader.aspx'>Cruzador Sombrio</a></li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Hangar de Domínio Nivel 8</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 8</li></ul></td><td><ul><li>28220 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>24320 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>22400 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>7070 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>4050 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2620 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>620 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Día 14 Horas 30 Minutos </td><td><ul><li>+3072 De pontuación</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 9</li><li><a href='../Unit/Doomer.aspx'>Aniquiladora</a></li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Hangar de Domínio Nivel 9</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 9</li></ul></td><td><ul><li>41240 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>30780 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>28350 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>9280 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>6084 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>4790 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2790 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>468 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Días 6 Horas 50 Minutos </td><td><ul><li>+4374 De pontuación</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 10</li><li><a href='../Unit/Bozer.aspx'>Bozer</a></li><li><a href='../Facility/Devastation.aspx'>Devastación</a> Nivel 2</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Hangar de Domínio Nivel 10</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> Nivel 10</li></ul></td><td><ul><li>57500 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>38000 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>35000 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>11750 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>8625 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>7500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>5500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>2500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>3 Días 3 Horas </td><td><ul><li>+6000 De pontuación</li></ul></td><td><ul><li><a href='../Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a> Nivel 2</li><li><a href='../Unit/DarkTaurus.aspx'>Toro Oscuro</a></li></ul></td></tr></table>
	
</asp:Content>