﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Capital de la Oscuridad
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edificios</h2><ul><li><a href='/es/Facility/Silo.aspx'>Bodega</a></li><li><a href='/es/Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a></li><li><a href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a></li><li><a href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/es/Facility/Devastation.aspx'>Devastación</a></li><li><a href='/es/Facility/Incubator.aspx'>Encubadora</a></li><li><a href='/es/Facility/QueenHatchery.aspx'>Encubadora de Reinas</a></li><li><a href='/es/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/es/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/es/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/es/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/es/Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a></li><li><a href='/es/Facility/NuclearFacility.aspx'>Extractor de Uranio</a></li><li><a href='/es/Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a></li><li><a href='/es/Facility/BlinkerAssembler.aspx'>Fábrica de Parpadeantes</a></li><li><a href='/es/Facility/WormHoleCreator.aspx'>Generador de Pasajes</a></li><li><a href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a></li><li><a href='/es/Facility/Nest.aspx'>Nido</a></li><li><a href='/es/Facility/SolarPanel.aspx'>Panel Solar</a></li><li><a href='/es/Facility/UnitYard.aspx'>Puerto Espacial</a></li><li><a href='/es/Facility/DeepSpaceScanner.aspx'>Radar de Largo Alcance</a></li><li><a href='/es/Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Capital de la Oscuridad" runat="server" /></h1>

	<div class="description">
		El <a class='darknesshall' href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> es el edifício madre de los <a href='/es/Race/DarkHumans.aspx'>Renegados</a>. Todos los otros edifícios de <a href='/es/Race/DarkHumans.aspx'>Renegados</a> dependen del <a class='darknesshall' href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a>. Cada nivel de <a class='commandcenter' href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a>
  aumenta la producción de <a class='titanium' href='/es/Intrinsic/Titanium.aspx'>Titanio</a>, <a class='gold' href='/es/Intrinsic/Gold.aspx'>Oro</a> e <a class='uranium' href='/es/Intrinsic/Uranium.aspx'>Uranio</a>, más alla de aumentar el <a href='/es/Universe/Planets.aspx#Capacity'>Límite de Recursos</a>.
		<div class='baseDarkHumansPreview DarkHumansDarknessHallPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Capital de la Oscuridad Nivel 1</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li>Sin Dependencias</li></td><td><ul><li>Sin Costo</li></td><td class='duration'>Comienzo ya Construido</td><td><ul><li>+9 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li><li>+1000 Capacidad</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 1</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 1</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 1</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 1</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Capital de la Oscuridad Nivel 2</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 1</li></ul></td><td><ul><li>263 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>420 <a href='../Intrinsic/Gold.aspx'>Oro</a></li></ul></td><td class='duration'>30 Minutos </td><td><ul><li>+72 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 2</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 2</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 2</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 2</li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Capital de la Oscuridad Nivel 3</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 2</li></ul></td><td><ul><li>975 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>1560 <a href='../Intrinsic/Gold.aspx'>Oro</a></li></ul></td><td class='duration'>1 Hora 40 Minutos </td><td><ul><li>+243 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 3</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 3</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 3</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 3</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Capital de la Oscuridad Nivel 4</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 3</li></ul></td><td><ul><li>2363 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>3780 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>380 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>4 Horas </td><td><ul><li>+576 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 4</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 4</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 4</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 4</li><li><a href='../Facility/NuclearFacility.aspx'>Extractor de Uranio</a> Nivel 1</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Capital de la Oscuridad Nivel 5</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 4</li></ul></td><td><ul><li>4650 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>7440 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>1219 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>250 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>7 Horas 50 Minutos </td><td><ul><li>+1125 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranio</a> Por Tick</li><li>+1000 Capacidad</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 5</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 5</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 5</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 5</li><li><a href='../Facility/NuclearFacility.aspx'>Extractor de Uranio</a> Nivel 5</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Capital de la Oscuridad Nivel 6</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 5</li></ul></td><td><ul><li>4075 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>8063 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>12900 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>2470 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>160 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1160 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>13 Horas 20 Minutos </td><td><ul><li>+1944 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranio</a> Por Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 6</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 6</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 6</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 6</li><li><a href='../Facility/NuclearFacility.aspx'>Extractor de Uranio</a> Nivel 6</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Capital de la Oscuridad Nivel 7</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 6</li></ul></td><td><ul><li>9790 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>12825 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>20520 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>4216 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1430 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2430 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>21 Horas 20 Minutos </td><td><ul><li>+3087 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranio</a> Por Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 7</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 7</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 7</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 7</li><li><a href='../Facility/Devastation.aspx'>Devastación</a> Nivel 1</li><li><a href='../Facility/NuclearFacility.aspx'>Extractor de Uranio</a> Nivel 7</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Capital de la Oscuridad Nivel 8</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 7</li></ul></td><td><ul><li>17395 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>19163 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>30660 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>6540 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>3120 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>4120 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1180 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Día 7 Horas 50 Minutos </td><td><ul><li>+4608 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranio</a> Por Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 8</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 8</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 8</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 8</li><li><a href='../Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a> Nivel 1</li><li><a href='../Facility/NuclearFacility.aspx'>Extractor de Uranio</a> Nivel 8</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Capital de la Oscuridad Nivel 9</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 8</li></ul></td><td><ul><li>27160 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>27300 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>43680 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>9524 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5290 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>6290 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>4435 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>968 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Día 21 Horas 10 Minutos </td><td><ul><li>+6561 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranio</a> Por Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 9</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 9</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 9</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 9</li><li><a href='../Facility/NuclearFacility.aspx'>Extractor de Uranio</a> Nivel 9</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Capital de la Oscuridad Nivel 10</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 9</li></ul></td><td><ul><li>39355 <a href='../Intrinsic/Uranium.aspx'>Uranio</a></li><li>37463 <a href='../Intrinsic/Titanium.aspx'>Titanio</a></li><li>59940 <a href='../Intrinsic/Gold.aspx'>Oro</a></li><li>13250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>8000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>9000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>8500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>3000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Días 14 Horas </td><td><ul><li>+9000 De pontuación</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Oro</a> Por Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanio</a> Por Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranio</a> Por Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a> Nivel 10</li><li><a href='../Facility/DominationYard.aspx'>Hangar de Domínio</a> Nivel 10</li><li><a href='../Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a> Nivel 10</li><li><a href='../Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a> Nivel 10</li><li><a href='../Facility/NuclearFacility.aspx'>Extractor de Uranio</a> Nivel 10</li></ul></td></tr></table>
	
</asp:Content>