﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Extractor de Comida
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edifícios</h2><ul><li><a href='/pt/Facility/Silo.aspx'>Armazém</a></li><li><a href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a></li><li><a href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/pt/Facility/Devastation.aspx'>Devastação</a></li><li><a href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/pt/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/pt/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/pt/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/pt/Facility/TitaniumExtractor.aspx'>Extractor de Titânio</a></li><li><a href='/pt/Facility/NuclearFacility.aspx'>Extractor de Urânio</a></li><li><a href='/pt/Facility/BattleMoonAssembler.aspx'>Fábrica de Luas de Combate</a></li><li><a href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a></li><li><a href='/pt/Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a></li><li><a href='/pt/Facility/DominationYard.aspx'>Hangar do Domínio</a></li><li><a href='/pt/Facility/Incubator.aspx'>Incubadora</a></li><li><a href='/pt/Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a></li><li><a href='/pt/Facility/Nest.aspx'>Ninho</a></li><li><a href='/pt/Facility/SolarPanel.aspx'>Painel Solar</a></li><li><a href='/pt/Facility/SlaveWarehouse.aspx'>Poço da Escravatura</a></li><li><a href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a></li><li><a href='/pt/Facility/DeepSpaceScanner.aspx'>Radar de Longo Alcance</a></li><li><a href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Extractor de Comida" runat="server" /></h1>

	<div class="description">
		O <a class='elkextractor' href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a> é um edifício dos <a href='/pt/Race/Bugs.aspx'>Levyr</a> que extrai <a class='elk' href='/pt/Intrinsic/Elk.aspx'>Comida</a>. Cada nível dá +1 de <a class='elk' href='/pt/Intrinsic/Elk.aspx'>Comida</a> a cada dez minutos.
  O <a class='elkextractor' href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a> só pode ser construido nos planetas da <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> dos <a href='/pt/Race/Bugs.aspx'>Levyr</a>.
		<div class='baseBugsPreview BugsElkExtractorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Extractor de Comida Nível 1</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 1</li></ul></td><td><ul><li>250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>38 <a href='../Intrinsic/Elk.aspx'>Comida</a></li></ul></td><td class='duration'>10 Minutos </td><td><ul><li>+6 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Extractor de Comida Nível 2</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 2</li></ul></td><td><ul><li>1000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>152 <a href='../Intrinsic/Elk.aspx'>Comida</a></li></ul></td><td class='duration'>30 Minutos </td><td><ul><li>+48 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Extractor de Comida Nível 3</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 3</li></ul></td><td><ul><li>2250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>342 <a href='../Intrinsic/Elk.aspx'>Comida</a></li></ul></td><td class='duration'>1 Hora 30 Minutos </td><td><ul><li>+162 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Extractor de Comida Nível 4</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 4</li></ul></td><td><ul><li>4000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>608 <a href='../Intrinsic/Elk.aspx'>Comida</a></li></ul></td><td class='duration'>3 Horas 30 Minutos </td><td><ul><li>+384 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Extractor de Comida Nível 5</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 5</li></ul></td><td><ul><li>6250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>950 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>6 Horas 50 Minutos </td><td><ul><li>+750 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Extractor de Comida Nível 6</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 6</li></ul></td><td><ul><li>9000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1368 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>800 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>370 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>11 Horas 40 Minutos </td><td><ul><li>+1296 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Extractor de Comida Nível 7</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 7</li></ul></td><td><ul><li>12250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1862 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>1450 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>286 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>955 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>18 Horas 40 Minutos </td><td><ul><li>+2058 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Extractor de Comida Nível 8</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 8</li></ul></td><td><ul><li>16000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>2432 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>2200 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>920 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1630 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>90 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Dia 3 Horas 40 Minutos </td><td><ul><li>+3072 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Extractor de Comida Nível 9</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 9</li></ul></td><td><ul><li>20250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>3078 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>3050 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1734 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2395 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1110 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>145 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>1 Dia 15 Horas 30 Minutos </td><td><ul><li>+4374 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Extractor de Comida Nível 10</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 10</li></ul></td><td><ul><li>25000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>3800 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>4000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2750 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>3250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2250 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>2 Dias 6 Horas </td><td><ul><li>+6000 De pontuação</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Comida</a> Por Tick</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>