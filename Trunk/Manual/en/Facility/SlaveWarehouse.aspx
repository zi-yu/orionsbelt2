﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Slave Warehouse Facility
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Facilities</h2><ul><li><a href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a></li><li><a href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a></li><li><a href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li><a href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li><a href='/en/Facility/DeepSpaceScanner.aspx'>Deep Space Scanner</a></li><li><a href='/en/Facility/Devastation.aspx'>Devastation</a></li><li><a href='/en/Facility/DevotionSanctuary.aspx'>Devotion Sanctuary</a></li><li><a href='/en/Facility/DominationYard.aspx'>Domination Yard</a></li><li><a href='/en/Facility/ElkExtractor.aspx'>Elk Extractor</a></li><li><a href='/en/Facility/Extractor.aspx'>Extractor</a></li><li><a href='/en/Facility/Incubator.aspx'>Incubator</a></li><li><a href='/en/Facility/MithrilExtractor.aspx'>Mithril Extractor</a></li><li><a href='/en/Facility/Nest.aspx'>Nest</a></li><li><a href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a></li><li><a href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a></li><li><a href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a></li><li><a href='/en/Facility/Silo.aspx'>Silo</a></li><li><a href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a></li><li><a href='/en/Facility/SolarPanel.aspx'>Solar Panel</a></li><li><a href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a></li><li><a href='/en/Facility/UnitYard.aspx'>Unit Yard</a></li><li><a href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a></li><li><a href='/en/Facility/WormHoleCreator.aspx'>Worm Hole Creator</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Slave Warehouse" runat="server" /></h1>

	<div class="description">
		The <a class='slavewarehouse' href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a> is a <a href='/en/Race/DarkHumans.aspx'>Renegades</a> facility that allows them to increse the <a href='/en/Universe/Planets.aspx#Capacity'>Resource Limit</a>.
		<div class='baseDarkHumansPreview DarkHumansSlaveWarehousePreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Slave Warehouse Level 1</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 1</li></ul></td><td><ul><li>300 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>47 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+3 To score</li><li>+180 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Slave Warehouse Level 2</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 2</li></ul></td><td><ul><li>1200 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>374 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li></ul></td><td class='duration'>30 Minutes </td><td><ul><li>+24 To score</li><li>+540 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Slave Warehouse Level 3</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 3</li></ul></td><td><ul><li>2700 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>1260 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>530 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>40 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Hour 10 Minutes </td><td><ul><li>+81 To score</li><li>+900 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Slave Warehouse Level 4</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 4</li></ul></td><td><ul><li>4800 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>2987 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>1640 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>460 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Hours 50 Minutes </td><td><ul><li>+192 To score</li><li>+1260 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Slave Warehouse Level 5</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 5</li></ul></td><td><ul><li>7500 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>5834 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>3470 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>350 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>5 Hours 20 Minutes </td><td><ul><li>+375 To score</li><li>+1620 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Slave Warehouse Level 6</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 6</li></ul></td><td><ul><li>10800 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>10080 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>6200 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1660 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>790 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>9 Hours 10 Minutes </td><td><ul><li>+648 To score</li><li>+1980 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Slave Warehouse Level 7</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 7</li></ul></td><td><ul><li>14700 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>16007 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>10010 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>2440 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>215 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1310 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>14 Hours 30 Minutes </td><td><ul><li>+1029 To score</li><li>+2340 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Slave Warehouse Level 8</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 8</li></ul></td><td><ul><li>19200 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>23894 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>15080 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>3340 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1060 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1910 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>340 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>21 Hours 40 Minutes </td><td><ul><li>+1536 To score</li><li>+2700 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Slave Warehouse Level 9</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 9</li></ul></td><td><ul><li>24300 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>34020 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>21590 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>4360 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2145 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2590 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1968 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>56 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Day 6 Hours 40 Minutes </td><td><ul><li>+2187 To score</li><li>+3060 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Slave Warehouse Level 10</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Darkness Hall</a> Level 10</li></ul></td><td><ul><li>30000 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>46667 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>29720 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>5500 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>3500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3350 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>4000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1750 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Day 18 Hours 10 Minutes </td><td><ul><li>+3000 To score</li><li>+3420 Capacity</li><li>-0,5 Production Factor</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>