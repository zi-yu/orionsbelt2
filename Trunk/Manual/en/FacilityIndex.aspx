<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Facilities
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Facilities</h1><table class='table'><tr><th><a href='/en/Race/LightHumans.aspx'>Utopians</a></td><th><a href='/en/Race/DarkHumans.aspx'>Renegades</a></td><th><a href='/en/Race/Bugs.aspx'>Levyr</a></td></tr><tr><td><ul><li><a href='/en/Facility/DeepSpaceScanner.aspx'>Deep Space Scanner</a></li><li><a href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a></li><li><a href='/en/Facility/CommandCenter.aspx'>Command Center</a></li><li><a href='/en/Facility/SolarPanel.aspx'>Solar Panel</a></li><li><a href='/en/Facility/MithrilExtractor.aspx'>Mithril Extractor</a></li><li><a href='/en/Facility/Silo.aspx'>Silo</a></li><li><a href='/en/Facility/SeriumExtractor.aspx'>Serium Extractor</a></li><li><a href='/en/Facility/UnitYard.aspx'>Unit Yard</a></li></td></ul><td><ul><li><a href='/en/Facility/SlaveWarehouse.aspx'>Slave Warehouse</a></li><li><a href='/en/Facility/DominationYard.aspx'>Domination Yard</a></li><li><a href='/en/Facility/TitaniumExtractor.aspx'>Titanium Extractor</a></li><li><a href='/en/Facility/DevotionSanctuary.aspx'>Devotion Sanctuary</a></li><li><a href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a></li><li><a href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a></li><li><a href='/en/Facility/Devastation.aspx'>Devastation</a></li><li><a href='/en/Facility/NuclearFacility.aspx'>Uranium Extractor</a></li></td></ul><td><ul><li><a href='/en/Facility/ProtolExtractor.aspx'>Protol Extractor</a></li><li><a href='/en/Facility/ElkExtractor.aspx'>Elk Extractor</a></li><li><a href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a></li><li><a href='/en/Facility/Incubator.aspx'>Incubator</a></li><li><a href='/en/Facility/Nest.aspx'>Nest</a></li><li><a href='/en/Facility/WormHoleCreator.aspx'>Worm Hole Creator</a></li></td></ul></tr></table>
	
	<div class="content">
		<h2>Main Facility</h2>
<p>
    Each race has its own main facility, that's used to define the player's level. The main facilities are:
    <ul><li>The <a class='commandcenter' href='/en/Facility/CommandCenter.aspx'>Command Center</a> for <a href='/en/Race/LightHumans.aspx'>Utopians</a></li><li>The <a class='darknesshall' href='/en/Facility/DarknessHall.aspx'>Darkness Hall</a> for <a href='/en/Race/DarkHumans.aspx'>Renegades</a></li><li>The <a class='nest' href='/en/Facility/Nest.aspx'>Nest</a> for <a href='/en/Race/Bugs.aspx'>Levyr</a></li></ul></p>
<h2>Resource Gathering</h2>
<p>
    To upgrade your <a href='/en/FacilityIndex.aspx'>Facilities</a> and build <a href='/en/UnitIndex.aspx'>Combat Units</a> you'll need <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a> resources. These resources
    can be obtained on your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets using the extractor facilities.
  </p>
<h2>Building Units</h2>
<p>
    You need a special facility to build <a href='/en/UnitIndex.aspx'>Combat Units</a>. Each race has its own unit building facility, and these
    facilities have 10 levels. Each level unlocks different <a href='/en/UnitIndex.aspx'>Combat Units</a>. The unit building facilities are:
    <ul><li>The <a class='unityard' href='/en/Facility/UnitYard.aspx'>Unit Yard</a> for <a href='/en/Race/LightHumans.aspx'>Utopians</a></li><li>The <a class='dominationyard' href='/en/Facility/DominationYard.aspx'>Domination Yard</a> for <a href='/en/Race/DarkHumans.aspx'>Renegades</a></li><li>The <a class='incubator' href='/en/Facility/Incubator.aspx'>Incubator</a> for <a href='/en/Race/Bugs.aspx'>Levyr</a></li></ul>
    Note that you nedd to have this facility up and running to be abe to build units.
  </p>
<h3>Ultimate Unit Construction</h3>
<p>
    We have available for each race an ultimate unit. These units are very expensive and can only be obtained
    on advanced levels. What distinguishes these units is that they're positioned outside of the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>,
    and have very unique abilities:
    <ul><li>
    The <a href='/en/Race/LightHumans.aspx'>Utopians</a> can build the <a class='blinker' href='/en/Unit/Blinker.aspx'>Blinker</a> on the <a class='blinkerassembler' href='/en/Facility/BlinkerAssembler.aspx'>Blinker Assembler</a>. The <a class='blinker' href='/en/Unit/Blinker.aspx'>Blinker</a> can easilly
    move every unit (your's or your opponent's) on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>.
  </li><li>
    The <a href='/en/Race/DarkHumans.aspx'>Renegades</a> can build the <a class='battlemoon' href='/en/Unit/BattleMoon.aspx'>Battle Moon</a> on the <a class='battlemoonassembler' href='/en/Facility/BattleMoonAssembler.aspx'>BattleMoon Assembler</a>. The <a class='battlemoon' href='/en/Unit/BattleMoon.aspx'>Battle Moon</a> can attack
    any adversary unit within range.
  </li><li>
    The <a href='/en/Race/Bugs.aspx'>Levyr</a> can build the <a class='queen' href='/en/Unit/Queen.aspx'>Queen</a> on the <a class='queenhatchery' href='/en/Facility/QueenHatchery.aspx'>Queen Hatchery</a>. The <a class='queen' href='/en/Unit/Queen.aspx'>Queen</a> can lay down eggs on the
    <a href='/en/Battles/GameBoard.aspx'>Game Board</a> from the <a class='maggot' href='/en/Unit/Maggot.aspx'>Maggot</a>'s board.
  </li></ul></p>
<h2>Planet Level and Facility Level</h2>
<p>
    Each planet has two distinct associated levels that determine the <a href='/en/FacilityIndex.aspx'>Facilities</a> that can be build.
    The <u>Planet Level</u> indicates the <a href='/en/Universe/HotZone.aspx#levels'>Zone Level</a> on the universe where the planet's located.
    The <u>Facility Level</u> indicates the evolution level of your planet. On your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> planets
    we use the main facility to get the planet level. On the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> however, we use the <a class='extractor' href='/en/Facility/Extractor.aspx'>Extractor</a>
    level.
  </p>
	</div>
	
</asp:Content>