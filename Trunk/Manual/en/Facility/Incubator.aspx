﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Incubator Facility
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Facilities</h2><ul><li><a href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a></li><li><a href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a></li><li><a href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li><a href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li><a href='/en/Facility/DeepSpaceScanner.aspx'>Deep Space Scanner</a></li><li><a href='/en/Facility/Devastation.aspx'>Devastation</a></li><li><a href='/en/Facility/DevotionSanctuary.aspx'>Devotion Sanctuary</a></li><li><a href='/en/Facility/DominationYard.aspx'>Domination Yard</a></li><li><a href='/en/Facility/ElkExtractor.aspx'>Elk Extractor</a></li><li><a href='/en/Facility/Extractor.aspx'>Extractor</a></li><li><a href='/en/Facility/Incubator.aspx'>Incubator</a></li><li><a href='/en/Facility/MithrilExtractor.aspx'>Mithril Extractor</a></li><li><a href='/en/Facility/Nest.aspx'>Nest</a></li><li><a href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a></li><li><a href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a></li><li><a href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a></li><li><a href='/en/Facility/Silo.aspx'>Silo</a></li><li><a href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a></li><li><a href='/en/Facility/SolarPanel.aspx'>Solar Panel</a></li><li><a href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a></li><li><a href='/en/Facility/UnitYard.aspx'>Unit Yard</a></li><li><a href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a></li><li><a href='/en/Facility/WormHoleCreator.aspx'>Worm Hole Creator</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Incubator" runat="server" /></h1>

	<div class="description">
		The <a class='incubator' href='/en/Facility/Incubator.aspx'>Incubator</a> is the <a href='/en/Race/Bugs.aspx'>Levyr</a> facility that allows them to hatch <a href='/en/UnitIndex.aspx'>Combat Units</a>. Depending on its level,
  the <a class='incubator' href='/en/Facility/Incubator.aspx'>Incubator</a> will be able to hatch: <a class='seeker' href='/en/Unit/Seeker.aspx'>Seeker</a>, <a class='interceptor' href='/en/Unit/Interceptor.aspx'>Interceptor</a>, <a class='worm' href='/en/Unit/Worm.aspx'>Worm</a>, <a class='stinger' href='/en/Unit/Stinger.aspx'>Stinger</a>, <a class='hiveprotector' href='/en/Unit/HiveProtector.aspx'>Hive Protector</a>,
  <a class='destroyer' href='/en/Unit/Destroyer.aspx'>Destroyer</a>, <a class='spider' href='/en/Unit/Spider.aspx'>Spider</a>, <a class='heavyseeker' href='/en/Unit/HeavySeeker.aspx'>Heavy Seeker</a>, <a class='hiveking' href='/en/Unit/HiveKing.aspx'>Hive King</a> and <a class='blackwidow' href='/en/Unit/BlackWidow.aspx'>Black Widow</a>.
  <p />
  To build the <a class='queen' href='/en/Unit/Queen.aspx'>Queen</a>, you'll need the <a class='queenhatchery' href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a>.
		<div class='baseBugsPreview BugsIncubatorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Incubator Level 1</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 1</li></ul></td><td><ul><li>320 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>450 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+6 To score</li></ul></td><td><ul><li><a href='../Unit/Seeker.aspx'>Seeker</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 2</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Incubator Level 2</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 2</li></ul></td><td><ul><li>1280 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1800 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>40 Minutes </td><td><ul><li>+48 To score</li></ul></td><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 3</li><li><a href='../Unit/Interceptor.aspx'>Interceptor</a></li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Incubator Level 3</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 3</li></ul></td><td><ul><li>2880 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>4050 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>2 Hours 10 Minutes </td><td><ul><li>+162 To score</li></ul></td><td><ul><li><a href='../Unit/Worm.aspx'>Worm</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 4</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Incubator Level 4</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 4</li></ul></td><td><ul><li>5120 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>7200 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>210 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>4 Hours 50 Minutes </td><td><ul><li>+384 To score</li></ul></td><td><ul><li><a href='../Unit/Stinger.aspx'>Stinger</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 5</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Incubator Level 5</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 5</li></ul></td><td><ul><li>8000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>11250 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>1125 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>9 Hours 30 Minutes </td><td><ul><li>+750 To score</li></ul></td><td><ul><li><a href='../Unit/HiveProtector.aspx'>Hive Protector</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 6</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Incubator Level 6</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 6</li></ul></td><td><ul><li>11520 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>16200 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>2490 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>160 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>16 Hours 20 Minutes </td><td><ul><li>+1296 To score</li></ul></td><td><ul><li><a href='../Unit/Destroyer.aspx'>Destroyer</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 7</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Incubator Level 7</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 7</li></ul></td><td><ul><li>15680 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>22050 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>4395 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>645 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1430 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Day 1 Hour 50 Minutes </td><td><ul><li>+2058 To score</li></ul></td><td><ul><li><a href='../Unit/Spider.aspx'>Spider</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 8</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Incubator Level 8</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 8</li></ul></td><td><ul><li>20480 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>28800 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>6930 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>3180 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>3120 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Day 14 Hours 30 Minutes </td><td><ul><li>+3072 To score</li></ul></td><td><ul><li><a href='../Unit/HeavySeeker.aspx'>Heavy Seeker</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 9</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Incubator Level 9</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 9</li></ul></td><td><ul><li>25920 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>36450 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>10185 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>6435 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>5290 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1580 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>2 Days 6 Hours 50 Minutes </td><td><ul><li>+4374 To score</li></ul></td><td><ul><li><a href='../Unit/HiveKing.aspx'>Hive King</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 10</li><li><a href='../Facility/WormHoleCreator.aspx'>Worm Hole Creator</a> Level 2</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Incubator Level 10</a></h2><table class='table'><tr><th>Dependencies</th><th>Cost</th><th>Duration</th><th>On Complete</th><th>Unlocks</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 10</li></ul></td><td><ul><li>32000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>45000 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>14250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>10500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>8000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>7000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>3 Days 3 Hours </td><td><ul><li>+6000 To score</li></ul></td><td><ul><li><a href='../Facility/QueenHatchery.aspx'>Queen Hatchery</a> Level 2</li><li><a href='../Unit/BlackWidow.aspx'>Black Widow</a></li></ul></td></tr></table>
	
</asp:Content>