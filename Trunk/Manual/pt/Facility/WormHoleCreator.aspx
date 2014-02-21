<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Gerador de Túneis Espaciais
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edifícios</h2><ul><li><a href='/pt/Facility/Silo.aspx'>Armazém</a></li><li><a href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a></li><li><a href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/pt/Facility/Devastation.aspx'>Devastação</a></li><li><a href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/pt/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/pt/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/pt/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/pt/Facility/TitaniumExtractor.aspx'>Extractor de Titânio</a></li><li><a href='/pt/Facility/NuclearFacility.aspx'>Extractor de Urânio</a></li><li><a href='/pt/Facility/BattleMoonAssembler.aspx'>Fábrica de Luas de Combate</a></li><li><a href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a></li><li><a href='/pt/Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a></li><li><a href='/pt/Facility/DominationYard.aspx'>Hangar do Domínio</a></li><li><a href='/pt/Facility/Incubator.aspx'>Incubadora</a></li><li><a href='/pt/Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a></li><li><a href='/pt/Facility/Nest.aspx'>Ninho</a></li><li><a href='/pt/Facility/SolarPanel.aspx'>Painel Solar</a></li><li><a href='/pt/Facility/SlaveWarehouse.aspx'>Poço da Escravatura</a></li><li><a href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a></li><li><a href='/pt/Facility/DeepSpaceScanner.aspx'>Radar de Longo Alcance</a></li><li><a href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Gerador de Túneis Espaciais" runat="server" /></h1>

	<div class="description">
		O <a class='wormholecreator' href='/pt/Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a> é o edifício supremo dos <a href='/pt/Race/Bugs.aspx'>Levyr</a>. Permite-lhes gerar um <a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a> temporário no
  <a href='/pt/Universe/Default.aspx'>Universo</a>.
		<div class='baseBugsPreview BugsWormHoleCreatorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Gerador de Túneis Espaciais Nível 1</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Ninho</a> Nível 7</li></ul></td><td><ul><li>25000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>28000 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>11000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>9000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Dia 21 Horas </td><td><ul><li>+2500 De pontuação</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Gerador de Túneis Espaciais Nível 2</a></h2><table class='table'><tr><th>Dependências</th><th>Custo</th><th>Duração</th><th>Quando Completar</th><th>Desbloqueia</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubadora</a> Nível 9</li></ul></td><td><ul><li>50000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>56000 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>22000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>19000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>18000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>16500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Dias 18 Horas </td><td><ul><li>+5000 De pontuação</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>