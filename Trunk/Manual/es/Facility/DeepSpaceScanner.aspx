<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Radar de Largo Alcance
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edificios</h2><ul><li><a href='/es/Facility/Silo.aspx'>Bodega</a></li><li><a href='/es/Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a></li><li><a href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a></li><li><a href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/es/Facility/Devastation.aspx'>Devastación</a></li><li><a href='/es/Facility/Incubator.aspx'>Encubadora</a></li><li><a href='/es/Facility/QueenHatchery.aspx'>Encubadora de Reinas</a></li><li><a href='/es/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/es/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/es/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/es/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/es/Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a></li><li><a href='/es/Facility/NuclearFacility.aspx'>Extractor de Uranio</a></li><li><a href='/es/Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a></li><li><a href='/es/Facility/BlinkerAssembler.aspx'>Fábrica de Parpadeantes</a></li><li><a href='/es/Facility/WormHoleCreator.aspx'>Generador de Pasajes</a></li><li><a href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a></li><li><a href='/es/Facility/Nest.aspx'>Nido</a></li><li><a href='/es/Facility/SolarPanel.aspx'>Panel Solar</a></li><li><a href='/es/Facility/UnitYard.aspx'>Puerto Espacial</a></li><li><a href='/es/Facility/DeepSpaceScanner.aspx'>Radar de Largo Alcance</a></li><li><a href='/es/Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Radar de Largo Alcance" runat="server" /></h1>

	<div class="description">
		El <a class='deepspacescanner' href='/es/Facility/DeepSpaceScanner.aspx'>Radar de Largo Alcance</a> es el  edifício supremo de los <a href='/es/Race/LightHumans.aspx'>Utopianos</a>. Les Permite generar un <a href='/es/Universe/Beacon.aspx'>Centinela</a> temporal en el
  <a href='/es/Universe/Default.aspx'>Universo</a>.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/DeepSpaceScannerR.png' alt='Radar de Largo Alcance' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Radar de Largo Alcance Nivel 1</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centro de Comando</a> Nivel 7</li></ul></td><td><ul><li>22000 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>26000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>28000 <a href='../Intrinsic/Energy.aspx'>Energía</a></li><li>3000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>3500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Día 16 Horas </td><td><ul><li>+3000 De pontuación</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Radar de Largo Alcance Nivel 2</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li>Sin Dependencias</li></td><td><ul><li>44000 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>52000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>56000 <a href='../Intrinsic/Energy.aspx'>Energía</a></li><li>6000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>5000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>3000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>7000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Días 8 Horas </td><td><ul><li>+6000 De pontuación</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>