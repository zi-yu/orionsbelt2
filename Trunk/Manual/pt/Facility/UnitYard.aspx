﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Porto Espacial
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edifícios</h2><ul><li><a href='/pt/Facility/Silo.aspx'>Armazém</a></li><li><a href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a></li><li><a href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/pt/Facility/Devastation.aspx'>Devastação</a></li><li><a href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/pt/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/pt/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/pt/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/pt/Facility/TitaniumExtractor.aspx'>Extractor de Titânio</a></li><li><a href='/pt/Facility/NuclearFacility.aspx'>Extractor de Urânio</a></li><li><a href='/pt/Facility/BattleMoonAssembler.aspx'>Fábrica de Luas de Combate</a></li><li><a href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a></li><li><a href='/pt/Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a></li><li><a href='/pt/Facility/DominationYard.aspx'>Hangar do Domínio</a></li><li><a href='/pt/Facility/Incubator.aspx'>Incubadora</a></li><li><a href='/pt/Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a></li><li><a href='/pt/Facility/Nest.aspx'>Ninho</a></li><li><a href='/pt/Facility/SolarPanel.aspx'>Painel Solar</a></li><li><a href='/pt/Facility/SlaveWarehouse.aspx'>Poço da Escravatura</a></li><li><a href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a></li><li><a href='/pt/Facility/DeepSpaceScanner.aspx'>Radar de Longo Alcance</a></li><li><a href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Porto Espacial" runat="server" /></h1>

	<div class="description">
		A <a class='unityard' href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a> é o edifício dos <a href='/pt/Race/LightHumans.aspx'>Utopianos</a> que lhes permite criar <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>. Dependendo do seu nível,
  a <a class='unityard' href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a> pode permitir criar: <a class='rain' href='/pt/Unit/Rain.aspx'>Rain</a>, <a class='samurai' href='/pt/Unit/Samurai.aspx'>Samurai</a>, <a class='raptor' href='/pt/Unit/Raptor.aspx'>Raptor</a>, <a class='kahuna' href='/pt/Unit/Kahuna.aspx'>Kahuna</a>, <a class='krill' href='/pt/Unit/Krill.aspx'>Krill</a>,
  <a class='pretorian' href='/pt/Unit/Pretorian.aspx'>Pretoriana</a>, <a class='eagle' href='/pt/Unit/Eagle.aspx'>Águia</a>, <a class='fenix' href='/pt/Unit/Fenix.aspx'>Fénix</a>, <a class='crusader' href='/pt/Unit/Crusader.aspx'>Crusador</a> e <a class='taurus' href='/pt/Unit/Taurus.aspx'>Touro</a>.
  <p />
  Para criar a <a class='blinker' href='/pt/Unit/Blinker.aspx'>Pisca-pisca</a>, é necessária o <a class='blinkerassembler' href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a>.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/UnitYardR.png' alt='Porto Espacial' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Porto Espacial Nível 1</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 2</li></ul></td><td><ul><li>250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>320 <a href='../Intrinsic/Energy.aspx'>Energia</a></li></ul></td><td class='duration'>10 Minutos </td><td><ul><li>+7 De pontuação</li></ul></td><td><ul><li><a href='../Unit/Rain.aspx'>Rain</a></li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Porto Espacial Nível 2</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 2</li></ul></td><td><ul><li>1000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>1280 <a href='../Intrinsic/Energy.aspx'>Energia</a></li></ul></td><td class='duration'>40 Minutos </td><td><ul><li>+56 De pontuação</li></ul></td><td><ul><li><a href='../Unit/Raptor.aspx'>Raptor</a></li><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 3</li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Porto Espacial Nível 3</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 3</li></ul></td><td><ul><li>2250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>2880 <a href='../Intrinsic/Energy.aspx'>Energia</a></li></ul></td><td class='duration'>2 Horas </td><td><ul><li>+189 De pontuação</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 4</li><li><a href='../Unit/Krill.aspx'>Krill</a></li><li><a href='../Unit/Samurai.aspx'>Samurai</a></li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Porto Espacial Nível 4</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 4</li></ul></td><td><ul><li>2840 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>4000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>5120 <a href='../Intrinsic/Energy.aspx'>Energia</a></li><li>830 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>4 Horas 40 Minutos </td><td><ul><li>+448 De pontuação</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 5</li><li><a href='../Unit/Pretorian.aspx'>Pretoriana</a></li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Porto Espacial Nível 5</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 5</li></ul></td><td><ul><li>6800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>6250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>8000 <a href='../Intrinsic/Energy.aspx'>Energia</a></li><li>2000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>422 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>9 Horas </td><td><ul><li>+875 De pontuação</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 6</li><li><a href='../Unit/Kahuna.aspx'>Kahuna</a></li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Porto Espacial Nível 6</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 6</li></ul></td><td><ul><li>11640 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>9000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>11520 <a href='../Intrinsic/Energy.aspx'>Energia</a></li><li>3430 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1275 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>15 Horas 40 Minutos </td><td><ul><li>+1512 De pontuação</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 7</li><li><a href='../Unit/Eagle.aspx'>Águia</a></li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Porto Espacial Nível 7</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 7</li></ul></td><td><ul><li>17360 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>12250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>15680 <a href='../Intrinsic/Energy.aspx'>Energia</a></li><li>5120 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2466 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>930 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>1 Dia 50 Minutos </td><td><ul><li>+2401 De pontuação</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 8</li><li><a href='../Unit/Crusader.aspx'>Crusador</a></li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Porto Espacial Nível 8</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 8</li></ul></td><td><ul><li>23960 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>16000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>20480 <a href='../Intrinsic/Energy.aspx'>Energia</a></li><li>7070 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>4050 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2620 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>620 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Dia 13 Horas </td><td><ul><li>+3584 De pontuação</li></ul></td><td><ul><li><a href='../Unit/Nova.aspx'>Nova</a></li><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 9</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Porto Espacial Nível 9</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 9</li></ul></td><td><ul><li>31440 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>20250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>25920 <a href='../Intrinsic/Energy.aspx'>Energia</a></li><li>9280 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>6084 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>4790 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2790 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>468 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Dias 4 Horas 30 Minutos </td><td><ul><li>+5103 De pontuação</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 10</li><li><a href='../Unit/Fenix.aspx'>Fénix</a></li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Porto Espacial Nível 10</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nível 10</li></ul></td><td><ul><li>39800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>25000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>32000 <a href='../Intrinsic/Energy.aspx'>Energia</a></li><li>11750 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>8625 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>7500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>5500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>2500 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>3 Dias </td><td><ul><li>+7000 De pontuação</li></ul></td><td><ul><li><a href='../Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a> Nível 2</li><li><a href='../Unit/Taurus.aspx'>Touro</a></li></ul></td></tr></table>
	
</asp:Content>