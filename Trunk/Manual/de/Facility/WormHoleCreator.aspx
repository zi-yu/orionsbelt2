<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Wurmloch Erzeuger Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Wurmloch Erzeuger" runat="server" /></h1>

	<div class="description">
		Der <a class='wormholecreator' href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a> ist das ultimative <a href='/de/Race/Bugs.aspx'>Levyr</a> Gebäude. Es erlaubt <a href='/de/Race/Bugs.aspx'>Levyr</a> ein temporäres
  <a href='/de/Universe/WormHole.aspx'>Wurmloch</a> im <a href='/de/Universe/Default.aspx'>Universum</a> zu erzeugen.
		<div class='baseBugsPreview BugsWormHoleCreatorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Wurmloch Erzeuger Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 7</li></ul></td><td><ul><li>25000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>28000 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>11000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>9000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Tag 21 Stunden </td><td><ul><li>+2500 Spielstand</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Wurmloch Erzeuger Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 9</li></ul></td><td><ul><li>50000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>56000 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>22000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>19000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>18000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>16500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Tage 18 Stunden </td><td><ul><li>+5000 Spielstand</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>