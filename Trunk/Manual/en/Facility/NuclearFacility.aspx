﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Uranium Extractor Facility
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Facilities</h2><ul><li><a href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a></li><li><a href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a></li><li><a href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li><a href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li><a href='/en/Facility/DeepSpaceScanner.aspx'>Deep Space Scanner</a></li><li><a href='/en/Facility/Devastation.aspx'>Devastation</a></li><li><a href='/en/Facility/DevotionSanctuary.aspx'>Devotion Sanctuary</a></li><li><a href='/en/Facility/DominationYard.aspx'>Domination Yard</a></li><li><a href='/en/Facility/ElkExtractor.aspx'>Elk Extractor</a></li><li><a href='/en/Facility/Extractor.aspx'>Extractor</a></li><li><a href='/en/Facility/Incubator.aspx'>Incubator</a></li><li><a href='/en/Facility/MithrilExtractor.aspx'>Mithril Extractor</a></li><li><a href='/en/Facility/Nest.aspx'>Nest</a></li><li><a href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a></li><li><a href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a></li><li><a href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a></li><li><a href='/en/Facility/Silo.aspx'>Silo</a></li><li><a href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a></li><li><a href='/en/Facility/SolarPanel.aspx'>Solar Panel</a></li><li><a href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a></li><li><a href='/en/Facility/UnitYard.aspx'>Unit Yard</a></li><li><a href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a></li><li><a href='/en/Facility/WormHoleCreator.aspx'>Worm Hole Creator</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Uranium Extractor" runat="server" /></h1>

	<div class="description">
		The <a class='nuclearfacility' href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a> is a <a href='/en/Race/DarkHumans.aspx'>Renegades</a> facility that extracts <a class='uranium' href='/en/Intrinsic/Uranium.aspx'>Uranium</a> from <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets. Each <a class='nuclearfacility' href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a>'s
  level increases +1 on the planet's <a class='uranium' href='/en/Intrinsic/Uranium.aspx'>Uranium</a> income.
		<div class='baseDarkHumansPreview DarkHumansNuclearFacilityPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Uranium Extractor Level 1</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 4</li></ul></td><td><ul><li>50 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>240 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+3 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Uranium Extractor Level 2</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li>No Dependencies</li></td><td><ul><li>120 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>400 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>960 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>100 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>30 Minutes </td><td><ul><li>+24 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Uranium Extractor Level 3</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li>No Dependencies</li></td><td><ul><li>320 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1350 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>2160 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>350 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Hour 20 Minutes </td><td><ul><li>+81 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Uranium Extractor Level 4</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li>No Dependencies</li></td><td><ul><li>600 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>3200 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>3840 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>700 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>140 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Hours 10 Minutes </td><td><ul><li>+192 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Uranium Extractor Level 5</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 5</li></ul></td><td><ul><li>960 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>6250 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>6000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>1150 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>6 Hours </td><td><ul><li>+375 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Uranium Extractor Level 6</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 6</li></ul></td><td><ul><li>1400 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>10800 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>8640 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>1700 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>260 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>940 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>10 Hours 30 Minutes </td><td><ul><li>+648 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Uranium Extractor Level 7</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 7</li></ul></td><td><ul><li>1920 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>17150 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>11760 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>2350 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>715 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1460 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>16 Hours 30 Minutes </td><td><ul><li>+1029 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Uranium Extractor Level 8</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 8</li></ul></td><td><ul><li>2520 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>25600 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>15360 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>3100 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>420 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1240 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2060 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Day 40 Minutes </td><td><ul><li>+1536 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Uranium Extractor Level 9</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 9</li></ul></td><td><ul><li>3200 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>36450 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>19440 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>3950 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>930 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1835 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2740 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>166 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Day 11 Hours </td><td><ul><li>+2187 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Uranium Extractor Level 10</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 10</li></ul></td><td><ul><li>3960 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>50000 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>24000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>4900 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>3500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Days </td><td><ul><li>+3000 To score</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>