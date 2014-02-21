﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Santuário de Devoção
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edifícios</h2><ul><li><a href='/pt/Facility/Silo.aspx'>Armazém</a></li><li><a href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a></li><li><a href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/pt/Facility/Devastation.aspx'>Devastação</a></li><li><a href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/pt/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/pt/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/pt/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/pt/Facility/TitaniumExtractor.aspx'>Extractor de Titânio</a></li><li><a href='/pt/Facility/NuclearFacility.aspx'>Extractor de Urânio</a></li><li><a href='/pt/Facility/BattleMoonAssembler.aspx'>Fábrica de Luas de Combate</a></li><li><a href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a></li><li><a href='/pt/Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a></li><li><a href='/pt/Facility/DominationYard.aspx'>Hangar do Domínio</a></li><li><a href='/pt/Facility/Incubator.aspx'>Incubadora</a></li><li><a href='/pt/Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a></li><li><a href='/pt/Facility/Nest.aspx'>Ninho</a></li><li><a href='/pt/Facility/SolarPanel.aspx'>Painel Solar</a></li><li><a href='/pt/Facility/SlaveWarehouse.aspx'>Poço da Escravatura</a></li><li><a href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a></li><li><a href='/pt/Facility/DeepSpaceScanner.aspx'>Radar de Longo Alcance</a></li><li><a href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Santuário de Devoção" runat="server" /></h1>

	<div class="description">
		O <a class='devotionsanctuary' href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a> é um edifício dos <a href='/pt/Race/DarkHumans.aspx'>Renegados</a> que produz <a class='gold' href='/pt/Intrinsic/Gold.aspx'>Ouro</a>. Cada nível dá +1 de <a class='gold' href='/pt/Intrinsic/Gold.aspx'>Ouro</a> a cada dez minutos.
  O <a class='devotionsanctuary' href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a> só pode ser construido nos planetas da <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> dos <a href='/pt/Race/DarkHumans.aspx'>Renegados</a>.
		<div class='baseDarkHumansPreview DarkHumansDevotionSanctuaryPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Santuário de Devoção Nível 1</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 1</li></ul></td><td><ul><li>160 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>25 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li></ul></td><td class='duration'>10 Minutos </td><td><ul><li>+3 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Santuário de Devoção Nível 2</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 2</li></ul></td><td><ul><li>640 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>100 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li></ul></td><td class='duration'>30 Minutos </td><td><ul><li>+24 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Santuário de Devoção Nível 3</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 3</li></ul></td><td><ul><li>1440 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>225 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li></ul></td><td class='duration'>1 Hora 30 Minutos </td><td><ul><li>+81 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Santuário de Devoção Nível 4</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 4</li></ul></td><td><ul><li>1520 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>2560 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>400 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li></ul></td><td class='duration'>3 Horas 20 Minutos </td><td><ul><li>+192 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Santuário de Devoção Nível 5</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 5</li></ul></td><td><ul><li>3500 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>4000 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>625 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li><li>250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>6 Horas 30 Minutos </td><td><ul><li>+375 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Santuário de Devoção Nível 6</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 6</li></ul></td><td><ul><li>5920 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>5760 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>900 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li><li>800 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>370 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>11 Horas 20 Minutos </td><td><ul><li>+648 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Santuário de Devoção Nível 7</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 7</li></ul></td><td><ul><li>8780 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>7840 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>1225 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li><li>1450 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>286 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>955 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>18 Horas </td><td><ul><li>+1029 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Santuário de Devoção Nível 8</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 8</li></ul></td><td><ul><li>12080 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>10240 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>1600 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li><li>2200 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>920 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1630 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>90 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Dia 2 Horas 40 Minutos </td><td><ul><li>+1536 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Santuário de Devoção Nível 9</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 9</li></ul></td><td><ul><li>15820 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>12960 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>2025 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li><li>3050 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1734 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2395 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1110 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>145 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Dia 14 Horas </td><td><ul><li>+2187 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Santuário de Devoção Nível 10</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 10</li></ul></td><td><ul><li>20000 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>16000 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>2500 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li><li>4000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2750 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3250 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2250 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Dias 4 Horas </td><td><ul><li>+3000 De pontuação</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Ouro</a> Por Tick</li><li>+0,5 Factor de Produção</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>