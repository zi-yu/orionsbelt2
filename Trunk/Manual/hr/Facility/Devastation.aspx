<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Devastacija Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Devastacija" runat="server" /></h1>

	<div class="description">
		<a class='devastation' href='/hr/Facility/Devastation.aspx'>Devastacija</a> je <a href='/hr/Race/DarkHumans.aspx'>Renegades</a> ultimativno postrojenje. Dopušta <a href='/hr/Race/DarkHumans.aspx'>Renegades</a> da ciljaju i oštete flote u <a href='/hr/Universe/Default.aspx'>Svemir</a>, što više <a class='devastation' href='/hr/Facility/Devastation.aspx'>Devastacija</a> postrojenja imate i što su ona naperdnija, veća je uzrokovana šteta.
<p />
Ultimativna moć <a class='devastation' href='/hr/Facility/Devastation.aspx'>Devastacija</a> postrojenja je da opali <a href='/hr/Universe/DevastationAttack.aspx'>Napad Devastacije</a>.
		<div class='baseDarkHumansPreview DarkHumansDevastationPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Devastacija Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 7</li></ul></td><td><ul><li>24000 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>26000 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>28000 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>3000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>1 Dan 14 Sati </td><td><ul><li>+3000 K bodovima</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Devastacija Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 9</li></ul></td><td><ul><li>48000 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>52000 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>56000 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>6000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>6000 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>3 Dani 4 Sati </td><td><ul><li>+6000 K bodovima</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>