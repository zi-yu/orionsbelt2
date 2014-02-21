<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zerstörung Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Zerstörung" runat="server" /></h1>

	<div class="description">
		<a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> ist das ultimative Gebäude der <a href='/de/Race/DarkHumans.aspx'>Renegades</a>. Es erlaubt den <a href='/de/Race/DarkHumans.aspx'>Renegades</a> Flotten anzuvisieren und zu schäigen im <a href='/de/Universe/Default.aspx'>Universum</a>, 
  je mehr <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> Gebäude du hast und je fortgeschrittener sie sind, umso grösser ist der verursachte Schaden.
  <p>
  Die ultimative Kraft des <a class='devastation' href='/de/Facility/Devastation.aspx'>Zerstörung</a> Gebäudes ist die <a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a> abzufeuern.</p>
		<div class='baseDarkHumansPreview DarkHumansDevastationPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Zerstörung Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 7</li></ul></td><td><ul><li>24000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>26000 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>28000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>3000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Tag 14 Stunden </td><td><ul><li>+3000 Spielstand</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Zerstörung Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 9</li></ul></td><td><ul><li>48000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>52000 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>56000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>6000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>6000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Tage 4 Stunden </td><td><ul><li>+6000 Spielstand</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>