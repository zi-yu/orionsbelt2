<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Königin Brutstätte Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Königin Brutstätte" runat="server" /></h1>

	<div class="description">
		Die <a class='queenhatchery' href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a> ist ein <a href='/de/Race/Bugs.aspx'>Levyr</a> Gebäude das es ihnen erlaubt die ultimative Einheit zu bauen: Die <a class='queen' href='/de/Unit/Queen.aspx'>Königin</a>.
		<div class='baseBugsPreview BugsQueenHatcheryPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Königin Brutstätte Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 8</li></ul></td><td><ul><li>32000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>24000 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>10500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>8500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Tag 18 Stunden </td><td><ul><li>+3000 Spielstand</li></ul></td><td><ul><li><a href='../Unit/Queen.aspx'>Königin</a></li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Königin Brutstätte Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 10</li></ul></td><td><ul><li>64000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>48000 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>21000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>19000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>18000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>17000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Tage 12 Stunden </td><td><ul><li>+6000 Spielstand</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>