﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Protol Extractor Facility
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Facilities</h2><ul><li><a href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a></li><li><a href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a></li><li><a href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li><a href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li><a href='/en/Facility/DeepSpaceScanner.aspx'>Deep Space Scanner</a></li><li><a href='/en/Facility/Devastation.aspx'>Devastation</a></li><li><a href='/en/Facility/DevotionSanctuary.aspx'>Devotion Sanctuary</a></li><li><a href='/en/Facility/DominationYard.aspx'>Domination Yard</a></li><li><a href='/en/Facility/ElkExtractor.aspx'>Elk Extractor</a></li><li><a href='/en/Facility/Extractor.aspx'>Extractor</a></li><li><a href='/en/Facility/Incubator.aspx'>Incubator</a></li><li><a href='/en/Facility/MithrilExtractor.aspx'>Mithril Extractor</a></li><li><a href='/en/Facility/Nest.aspx'>Nest</a></li><li><a href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a></li><li><a href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a></li><li><a href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a></li><li><a href='/en/Facility/Silo.aspx'>Silo</a></li><li><a href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a></li><li><a href='/en/Facility/SolarPanel.aspx'>Solar Panel</a></li><li><a href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a></li><li><a href='/en/Facility/UnitYard.aspx'>Unit Yard</a></li><li><a href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a></li><li><a href='/en/Facility/WormHoleCreator.aspx'>Worm Hole Creator</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Protol Extractor" runat="server" /></h1>

	<div class="description">
		The <a class='protolextractor' href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a> is a <a href='/en/Race/Bugs.aspx'>Levyr</a> facility that extracts <a class='protol' href='/en/Intrinsic/Protol.aspx'>Protol</a> from <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets. Each <a class='protolextractor' href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a>'s
  level increases +1 on the planet's <a class='protol' href='/en/Intrinsic/Protol.aspx'>Protol</a> income.
		<div class='baseBugsPreview BugsProtolExtractorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Protol Extractor Level 1</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 1</li></ul></td><td><ul><li>40 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>240 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+6 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Protol Extractor Level 2</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 2</li></ul></td><td><ul><li>160 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>960 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>30 Minutes </td><td><ul><li>+48 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Protol Extractor Level 3</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 3</li></ul></td><td><ul><li>360 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>2160 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>1 Hour 30 Minutes </td><td><ul><li>+162 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Protol Extractor Level 4</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 4</li></ul></td><td><ul><li>640 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>3840 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>3 Hours 20 Minutes </td><td><ul><li>+384 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Protol Extractor Level 5</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 5</li></ul></td><td><ul><li>1000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>6000 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>125 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>6 Hours 30 Minutes </td><td><ul><li>+750 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Protol Extractor Level 6</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 6</li></ul></td><td><ul><li>1440 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>8640 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>620 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>148 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>11 Hours 20 Minutes </td><td><ul><li>+1296 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Protol Extractor Level 7</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 7</li></ul></td><td><ul><li>1960 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>11760 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>1205 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>529 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>60 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>18 Hours </td><td><ul><li>+2058 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Protol Extractor Level 8</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 8</li></ul></td><td><ul><li>2560 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>15360 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>1880 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1036 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>130 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>660 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Day 2 Hours 40 Minutes </td><td><ul><li>+3072 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Protol Extractor Level 9</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 9</li></ul></td><td><ul><li>3240 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>19440 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>2645 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1687 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>895 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1340 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>180 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>1 Day 14 Hours </td><td><ul><li>+4374 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Protol Extractor Level 10</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 10</li></ul></td><td><ul><li>4000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>24000 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>3500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1750 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2100 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1084 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>2 Days 4 Hours </td><td><ul><li>+6000 To score</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Per Tick</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>