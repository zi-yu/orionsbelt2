<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Devastation Facility
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Facilities</h2><ul><li><a href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a></li><li><a href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a></li><li><a href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li><a href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li><a href='/en/Facility/DeepSpaceScanner.aspx'>Deep Space Scanner</a></li><li><a href='/en/Facility/Devastation.aspx'>Devastation</a></li><li><a href='/en/Facility/DevotionSanctuary.aspx'>Devotion Sanctuary</a></li><li><a href='/en/Facility/DominationYard.aspx'>Domination Yard</a></li><li><a href='/en/Facility/ElkExtractor.aspx'>Elk Extractor</a></li><li><a href='/en/Facility/Extractor.aspx'>Extractor</a></li><li><a href='/en/Facility/Incubator.aspx'>Incubator</a></li><li><a href='/en/Facility/MithrilExtractor.aspx'>Mithril Extractor</a></li><li><a href='/en/Facility/Nest.aspx'>Nest</a></li><li><a href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a></li><li><a href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a></li><li><a href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a></li><li><a href='/en/Facility/Silo.aspx'>Silo</a></li><li><a href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a></li><li><a href='/en/Facility/SolarPanel.aspx'>Solar Panel</a></li><li><a href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a></li><li><a href='/en/Facility/UnitYard.aspx'>Unit Yard</a></li><li><a href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a></li><li><a href='/en/Facility/WormHoleCreator.aspx'>Worm Hole Creator</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Devastation" runat="server" /></h1>

	<div class="description">
		The <a class='devastation' href='/en/Facility/Devastation.aspx'>Devastation</a> is the <a href='/en/Race/DarkHumans.aspx'>Renegades</a> ultimate facility. It allows <a href='/en/Race/DarkHumans.aspx'>Renegades</a> to target and damage fleets on the <a href='/en/Universe/Default.aspx'>Universe</a>, 
  the more <a class='devastation' href='/en/Facility/Devastation.aspx'>Devastation</a> facilities you have and more advanced their are, greater is the damage caused.
  <p />
  The ultimate power of the <a class='devastation' href='/en/Facility/Devastation.aspx'>Devastation</a> facility is to fire the <a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a>.
		<div class='baseDarkHumansPreview DarkHumansDevastationPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Devastation Level 1</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 7</li></ul></td><td><ul><li>24000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>26000 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>28000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>3000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Day 14 Hours </td><td><ul><li>+3000 To score</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Devastation Level 2</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Domination Yard</a> Level 9</li></ul></td><td><ul><li>48000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>52000 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>56000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>6000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>6000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Days 4 Hours </td><td><ul><li>+6000 To score</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>