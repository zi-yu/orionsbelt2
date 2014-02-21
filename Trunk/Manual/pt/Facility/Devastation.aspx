﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Devastação
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edifícios</h2><ul><li><a href='/pt/Facility/Silo.aspx'>Armazém</a></li><li><a href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a></li><li><a href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/pt/Facility/Devastation.aspx'>Devastação</a></li><li><a href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/pt/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/pt/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/pt/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/pt/Facility/TitaniumExtractor.aspx'>Extractor de Titânio</a></li><li><a href='/pt/Facility/NuclearFacility.aspx'>Extractor de Urânio</a></li><li><a href='/pt/Facility/BattleMoonAssembler.aspx'>Fábrica de Luas de Combate</a></li><li><a href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a></li><li><a href='/pt/Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a></li><li><a href='/pt/Facility/DominationYard.aspx'>Hangar do Domínio</a></li><li><a href='/pt/Facility/Incubator.aspx'>Incubadora</a></li><li><a href='/pt/Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a></li><li><a href='/pt/Facility/Nest.aspx'>Ninho</a></li><li><a href='/pt/Facility/SolarPanel.aspx'>Painel Solar</a></li><li><a href='/pt/Facility/SlaveWarehouse.aspx'>Poço da Escravatura</a></li><li><a href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a></li><li><a href='/pt/Facility/DeepSpaceScanner.aspx'>Radar de Longo Alcance</a></li><li><a href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Devastação" runat="server" /></h1>

	<div class="description">
		O <a class='devastation' href='/pt/Facility/Devastation.aspx'>Devastação</a> é o edifício supremo dos <a href='/pt/Race/DarkHumans.aspx'>Renegados</a>. Permite-lhes disparar sobre armadas no <a href='/pt/Universe/Default.aspx'>Universo</a>, quanto mais edifícios
  <a class='devastation' href='/pt/Facility/Devastation.aspx'>Devastação</a> tiver e mais evoluidos estiverem, maior é o dano provocado.
  <p />
  O poder supremo do <a class='devastation' href='/pt/Facility/Devastation.aspx'>Devastação</a> é o poderoso <a href='/pt/Universe/DevastationAttack.aspx'>Ataque Devastação</a>.
		<div class='baseDarkHumansPreview DarkHumansDevastationPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Devastação Nível 1</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Capital da Escuridão</a> Nível 7</li></ul></td><td><ul><li>24000 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li><li>26000 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>28000 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>3000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Dia 14 Horas </td><td><ul><li>+3000 De pontuação</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Devastação Nível 2</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar do Domínio</a> Nível 9</li></ul></td><td><ul><li>48000 <a href='../Intrinsic/Gold.aspx'>Ouro</a></li><li>52000 <a href='../Intrinsic/Titanium.aspx'>Titânio</a></li><li>56000 <a href='../Intrinsic/Uranium.aspx'>Urânio</a></li><li>6000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>6000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Dias 4 Horas </td><td><ul><li>+6000 De pontuação</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>