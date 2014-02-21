﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Ninho
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edifícios</h2><ul><li><a href='/pt/Facility/Silo.aspx'>Armazém</a></li><li><a href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a></li><li><a href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/pt/Facility/Devastation.aspx'>Devastação</a></li><li><a href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/pt/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/pt/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/pt/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/pt/Facility/TitaniumExtractor.aspx'>Extractor de Titânio</a></li><li><a href='/pt/Facility/NuclearFacility.aspx'>Extractor de Urânio</a></li><li><a href='/pt/Facility/BattleMoonAssembler.aspx'>Fábrica de Luas de Combate</a></li><li><a href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a></li><li><a href='/pt/Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a></li><li><a href='/pt/Facility/DominationYard.aspx'>Hangar do Domínio</a></li><li><a href='/pt/Facility/Incubator.aspx'>Incubadora</a></li><li><a href='/pt/Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a></li><li><a href='/pt/Facility/Nest.aspx'>Ninho</a></li><li><a href='/pt/Facility/SolarPanel.aspx'>Painel Solar</a></li><li><a href='/pt/Facility/SlaveWarehouse.aspx'>Poço da Escravatura</a></li><li><a href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a></li><li><a href='/pt/Facility/DeepSpaceScanner.aspx'>Radar de Longo Alcance</a></li><li><a href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Ninho" runat="server" /></h1>

	<div class="description">
		O <a class='nest' href='/pt/Facility/Nest.aspx'>Ninho</a> é o edifício mãe dos <a href='/pt/Race/Bugs.aspx'>Levyr</a>. Todos os outros edifícios de <a href='/pt/Race/Bugs.aspx'>Levyr</a> dependem do <a class='nest' href='/pt/Facility/Nest.aspx'>Ninho</a>. Cada nível do <a class='nest' href='/pt/Facility/Nest.aspx'>Ninho</a>
  aumenta a produção de <a class='elk' href='/pt/Intrinsic/Elk.aspx'>Comida</a> e <a class='protol' href='/pt/Intrinsic/Protol.aspx'>Protol</a>, além de aumentar o <a href='/pt/Universe/Planets.aspx#Capacity'>Limite de Recursos</a>.
		<div class='baseBugsPreview BugsNestPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Ninho Nível 1</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li>Sem Dependências</li></td><td><ul><li>Sem Custo</li></td><td class='duration'>Começa já Construído</td><td><ul><li>+9 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 1</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 1</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 1</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Ninho Nível 2</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 1</li></ul></td><td><ul><li>385 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>490 <a href='../Intrinsic/Protol.aspx'>Protol</a></li></ul></td><td class='duration'>30 Minutos </td><td><ul><li>+72 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 2</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 2</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 2</li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Ninho Nível 3</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 2</li></ul></td><td><ul><li>1430 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>1820 <a href='../Intrinsic/Protol.aspx'>Protol</a></li></ul></td><td class='duration'>1 Hora 40 Minutos </td><td><ul><li>+243 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 3</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 3</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 3</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Ninho Nível 4</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 3</li></ul></td><td><ul><li>3465 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>4410 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>530 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>4 Horas </td><td><ul><li>+576 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 4</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 4</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 4</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Ninho Nível 5</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 4</li></ul></td><td><ul><li>6820 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>8680 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1750 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>7 Horas 50 Minutos </td><td><ul><li>+1125 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 5</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 5</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 5</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Ninho Nível 6</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 5</li></ul></td><td><ul><li>11825 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>15050 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>3570 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1240 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>13 Horas 20 Minutos </td><td><ul><li>+1944 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 6</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 6</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 6</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Ninho Nível 7</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 6</li></ul></td><td><ul><li>18810 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>23940 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>6110 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2360 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>3145 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>21 Horas 20 Minutos </td><td><ul><li>+3087 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 7</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 7</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 7</li><li><a href='../Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a> Nível 1</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Ninho Nível 8</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 7</li></ul></td><td><ul><li>28105 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>35770 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>9490 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>5740 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>5680 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Dia 7 Horas 50 Minutos </td><td><ul><li>+4608 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 8</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 8</li><li><a href='../Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a> Nível 1</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 8</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Ninho Nível 9</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 8</li></ul></td><td><ul><li>40040 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>50960 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>13830 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>10080 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>8935 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5225 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Dia 21 Horas 10 Minutos </td><td><ul><li>+6561 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 9</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 9</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 9</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Ninho Nível 10</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 9</li></ul></td><td><ul><li>54945 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>69930 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>19250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>15500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>13000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>12000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>2000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>2 Dias 14 Horas </td><td><ul><li>+9000 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Por Tick</li><li>+2000 Capacidade</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Extractor de Protol</a> Nível 10</li><li><a href='../Facility/ElkExtractor.aspx'>Extractor de Comida</a> Nível 10</li><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 10</li></ul></td></tr></table>
	
</asp:Content>