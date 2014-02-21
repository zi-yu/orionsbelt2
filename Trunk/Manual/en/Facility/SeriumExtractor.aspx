﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Serium Extractor Facility
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Facilities</h2><ul><li><a href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a></li><li><a href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a></li><li><a href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li><a href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li><a href='/en/Facility/DeepSpaceScanner.aspx'>Deep Space Scanner</a></li><li><a href='/en/Facility/Devastation.aspx'>Devastation</a></li><li><a href='/en/Facility/DevotionSanctuary.aspx'>Devotion Sanctuary</a></li><li><a href='/en/Facility/DominationYard.aspx'>Domination Yard</a></li><li><a href='/en/Facility/ElkExtractor.aspx'>Elk Extractor</a></li><li><a href='/en/Facility/Extractor.aspx'>Extractor</a></li><li><a href='/en/Facility/Incubator.aspx'>Incubator</a></li><li><a href='/en/Facility/MithrilExtractor.aspx'>Mithril Extractor</a></li><li><a href='/en/Facility/Nest.aspx'>Nest</a></li><li><a href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a></li><li><a href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a></li><li><a href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a></li><li><a href='/en/Facility/Silo.aspx'>Silo</a></li><li><a href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a></li><li><a href='/en/Facility/SolarPanel.aspx'>Solar Panel</a></li><li><a href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a></li><li><a href='/en/Facility/UnitYard.aspx'>Unit Yard</a></li><li><a href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a></li><li><a href='/en/Facility/WormHoleCreator.aspx'>Worm Hole Creator</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Serium Extractor" runat="server" /></h1>

	<div class="description">
		The <a class='seriumextractor' href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a> is a <a href='/en/Race/LightHumans.aspx'>Utopians</a> facility that extracts <a class='serium' href='/en/Intrinsic/Serium.aspx'>Serium</a> from <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets. Each <a class='seriumextractor' href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a>'s
  level increases +1 on the planet's <a class='serium' href='/en/Intrinsic/Serium.aspx'>Serium</a> income.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/SeriumExtractorR.png' alt='Serium Extractor' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Serium Extractor Level 1</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 1</li></ul></td><td><ul><li>20 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>220 <a href='../Intrinsic/Energy.aspx'>Energy</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+4 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 2</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Serium Extractor Level 2</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 2</li></ul></td><td><ul><li>80 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>880 <a href='../Intrinsic/Energy.aspx'>Energy</a></li></ul></td><td class='duration'>30 Minutes </td><td><ul><li>+32 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Serium Extractor Level 3</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 3</li></ul></td><td><ul><li>180 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>1980 <a href='../Intrinsic/Energy.aspx'>Energy</a></li></ul></td><td class='duration'>1 Hour 40 Minutes </td><td><ul><li>+108 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Serium Extractor Level 4</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 4</li></ul></td><td><ul><li>360 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>320 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>3520 <a href='../Intrinsic/Energy.aspx'>Energy</a></li></ul></td><td class='duration'>4 Hours </td><td><ul><li>+256 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Serium Extractor Level 5</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 5</li></ul></td><td><ul><li>2800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>500 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>5500 <a href='../Intrinsic/Energy.aspx'>Energy</a></li><li>125 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>7 Hours 30 Minutes </td><td><ul><li>+500 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Serium Extractor Level 6</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 6</li></ul></td><td><ul><li>6440 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>720 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>7920 <a href='../Intrinsic/Energy.aspx'>Energy</a></li><li>620 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>148 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>13 Hours </td><td><ul><li>+864 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Serium Extractor Level 7</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 7</li></ul></td><td><ul><li>11520 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>980 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>10780 <a href='../Intrinsic/Energy.aspx'>Energy</a></li><li>1205 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>529 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>60 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>20 Hours 40 Minutes </td><td><ul><li>+1372 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Serium Extractor Level 8</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 8</li></ul></td><td><ul><li>18280 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>1280 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>14080 <a href='../Intrinsic/Energy.aspx'>Energy</a></li><li>1880 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1036 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>130 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>660 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Day 6 Hours 50 Minutes </td><td><ul><li>+2048 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Serium Extractor Level 9</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 9</li></ul></td><td><ul><li>26960 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>1620 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>17820 <a href='../Intrinsic/Energy.aspx'>Energy</a></li><li>2645 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1687 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>895 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1340 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>180 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Day 19 Hours 50 Minutes </td><td><ul><li>+2916 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Serium Extractor Level 10</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Command Center</a> Level 10</li></ul></td><td><ul><li>37800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>2000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>22000 <a href='../Intrinsic/Energy.aspx'>Energy</a></li><li>3500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1750 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2100 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1084 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Days 12 Hours </td><td><ul><li>+4000 To score</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>