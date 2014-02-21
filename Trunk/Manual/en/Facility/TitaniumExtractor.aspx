﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Titanium Extractor Facility
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Facilities</h2><ul><li><a href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a></li><li><a href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a></li><li><a href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li><a href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li><a href='/en/Facility/DeepSpaceScanner.aspx'>Deep Space Scanner</a></li><li><a href='/en/Facility/Devastation.aspx'>Devastation</a></li><li><a href='/en/Facility/DevotionSanctuary.aspx'>Devotion Sanctuary</a></li><li><a href='/en/Facility/DominationYard.aspx'>Domination Yard</a></li><li><a href='/en/Facility/ElkExtractor.aspx'>Elk Extractor</a></li><li><a href='/en/Facility/Extractor.aspx'>Extractor</a></li><li><a href='/en/Facility/Incubator.aspx'>Incubator</a></li><li><a href='/en/Facility/MithrilExtractor.aspx'>Mithril Extractor</a></li><li><a href='/en/Facility/Nest.aspx'>Nest</a></li><li><a href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a></li><li><a href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a></li><li><a href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a></li><li><a href='/en/Facility/Silo.aspx'>Silo</a></li><li><a href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a></li><li><a href='/en/Facility/SolarPanel.aspx'>Solar Panel</a></li><li><a href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a></li><li><a href='/en/Facility/UnitYard.aspx'>Unit Yard</a></li><li><a href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a></li><li><a href='/en/Facility/WormHoleCreator.aspx'>Worm Hole Creator</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Titanium Extractor" runat="server" /></h1>

	<div class="description">
		The <a class='titaniumextractor' href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a> is a <a href='/en/Race/DarkHumans.aspx'>Renegades</a> facility that extracts <a class='titanium' href='/en/Intrinsic/Titanium.aspx'>Titanium</a> from <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets. Each <a class='titaniumextractor' href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a>'s
  level increases +1 on the planet's <a class='titanium' href='/en/Intrinsic/Titanium.aspx'>Titanium</a> income.
		<div class='baseDarkHumansPreview DarkHumansTitaniumExtractorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Titanium Extractor Level 1</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 1</li></ul></td><td><ul><li>23 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>40 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+3 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Titanium Extractor Level 2</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 2</li></ul></td><td><ul><li>92 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>320 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>30 Minutes </td><td><ul><li>+24 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Titanium Extractor Level 3</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 3</li></ul></td><td><ul><li>207 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>1080 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>1 Hour 30 Minutes </td><td><ul><li>+81 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Titanium Extractor Level 4</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 4</li></ul></td><td><ul><li>480 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>368 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>2560 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>3 Hours 30 Minutes </td><td><ul><li>+192 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Titanium Extractor Level 5</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 5</li></ul></td><td><ul><li>3225 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>575 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>5000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>125 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>6 Hours 50 Minutes </td><td><ul><li>+375 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Titanium Extractor Level 6</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 6</li></ul></td><td><ul><li>7320 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>828 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>8640 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>620 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>148 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>11 Hours 40 Minutes </td><td><ul><li>+648 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Titanium Extractor Level 7</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 7</li></ul></td><td><ul><li>13035 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1127 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>13720 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>1205 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>529 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>60 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>18 Hours 40 Minutes </td><td><ul><li>+1029 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Titanium Extractor Level 8</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 8</li></ul></td><td><ul><li>20640 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1472 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>20480 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>1880 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1036 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>130 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>660 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Day 3 Hours 40 Minutes </td><td><ul><li>+1536 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Titanium Extractor Level 9</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 9</li></ul></td><td><ul><li>30405 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1863 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>29160 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>2645 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1687 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>895 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1340 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>180 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Day 15 Hours 30 Minutes </td><td><ul><li>+2187 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Titanium Extractor Level 10</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 10</li></ul></td><td><ul><li>42600 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>2300 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>40000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>3500 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1750 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2100 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1084 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Days 6 Hours </td><td><ul><li>+3000 To score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Per Tick</li><li>+0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>