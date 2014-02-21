<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Constructions
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Constructions</h1><table class='table'><tr><th><a href='/fr/Race/LightHumans.aspx'>Utopians</a></td><th><a href='/fr/Race/DarkHumans.aspx'>Renegades</a></td><th><a href='/fr/Race/Bugs.aspx'>Levyr</a></td></tr><tr><td><ul><li><a href='/fr/Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a></li><li><a href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a></li><li><a href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li><a href='/fr/Facility/SolarPanel.aspx'>Panneau solaire</a></li><li><a href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a></li><li><a href='/fr/Facility/Silo.aspx'>Silo</a></li><li><a href='/fr/Facility/SeriumExtractor.aspx'>Extracteur de Serium</a></li><li><a href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a></li></td></ul><td><ul><li><a href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a></li><li><a href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a></li><li><a href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a></li><li><a href='/fr/Facility/DevotionSanctuary.aspx'>Sancutaire de dévôts</a></li><li><a href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li><li><a href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a></li><li><a href='/fr/Facility/Devastation.aspx'>Dévastation</a></li><li><a href='/fr/Facility/NuclearFacility.aspx'>Extracteur d'Uranium</a></li></td></ul><td><ul><li><a href='/fr/Facility/ProtolExtractor.aspx'>Extracteur de Protol</a></li><li><a href='/fr/Facility/ElkExtractor.aspx'>Extracteur d'Elk</a></li><li><a href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a></li><li><a href='/fr/Facility/Incubator.aspx'>Incubateur</a></li><li><a href='/fr/Facility/Nest.aspx'>Nid</a></li><li><a href='/fr/Facility/WormHoleCreator.aspx'>Synthétiseur à trou stellaire</a></li></td></ul></tr></table>
	
	<div class="content">
		<h2>Main Facility</h2>
<p>
    Chaque race possède sa propre construction principale, et cette dernièere est l'indice permettant de définir le niveau du joueur. les constructions principales sont:
    <ul><li>Le <a class='commandcenter' href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a> pour les <a href='/fr/Race/LightHumans.aspx'>Utopians</a></li><li>Le <a class='darknesshall' href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a> pour les <a href='/fr/Race/DarkHumans.aspx'>Renegades</a></li><li>Le <a class='nest' href='/fr/Facility/Nest.aspx'>Nid</a> pour les <a href='/fr/Race/Bugs.aspx'>Levyr</a></li></ul></p>
<h2>Ramasser des ressources</h2>
<p>
    Pour améliorer vos <a href='/fr/FacilityIndex.aspx'>Constructions</a> et construire des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> vous devrez obtenir des ressources<a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a>. Ces ressources peuvent être obtenues à partir des planètes de votre<a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> en utilisant des extracteurs.
  </p>
<h2>Construire des unités</h2>
<p>
    Vous avez besoin d'un bâtiment particulier pour construire des <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>. Chaque race possède un bâtiment unique pouvant être améliorer de 10 niveaux.. Chaque niveau permet de construire une nouvelle sorte de <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>. Les bâtiments permettant de construire des unités sont:
    <ul><li>Le <a class='unityard' href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a> pour les <a href='/fr/Race/LightHumans.aspx'>Utopians</a></li><li>Le <a class='dominationyard' href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a> pour les <a href='/fr/Race/DarkHumans.aspx'>Renegades</a></li><li>l' <a class='incubator' href='/fr/Facility/Incubator.aspx'>Incubateur</a> pour les <a href='/fr/Race/Bugs.aspx'>Levyr</a></li></ul>
    Notez que votre bâtiment respectif foit être complètement construit et disonble pour pouvoir construire de nouvelles unités..
  </p>
<h3>Construction de l'unité ultime</h3>
<p>
    Il existe une unité ultime pour chaque race. Ces unités coûtent très chères et peuvent seulement être obtenus à un niveau élevé. Ces unités distincts des autres sont positionnés à l'extérieur du <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>,
    et possèdent des capacités uniques:
    <ul><li>
    Les <a href='/fr/Race/LightHumans.aspx'>Utopians</a> peuvent construire le <a class='blinker' href='/fr/Unit/Blinker.aspx'>Téléporteur</a> avec le <a class='blinkerassembler' href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a>. Le <a class='blinker' href='/fr/Unit/Blinker.aspx'>Téléporteur</a> Peut facilement bouger n'importqe quel unité (appartennant à vous ou l'adversaire) sur le <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>.
  </li><li>
    Les <a href='/fr/Race/DarkHumans.aspx'>Renegades</a> peuvent construire le <a class='battlemoon' href='/fr/Unit/BattleMoon.aspx'>Lune de Combat</a> avec le <a class='battlemoonassembler' href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a>. Le <a class='battlemoon' href='/fr/Unit/BattleMoon.aspx'>Lune de Combat</a> peut attaquer n'importe quel unité qui se trouve à portée de tir.
  </li><li>
    Les <a href='/fr/Race/Bugs.aspx'>Levyr</a> peuvent construire une <a class='queen' href='/fr/Unit/Queen.aspx'>Reine</a> avec la <a class='queenhatchery' href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a>. La <a class='queen' href='/fr/Unit/Queen.aspx'>Reine</a> peut pondre des oeufs sur le
    <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a> qui vont devenir des <a class='maggot' href='/fr/Unit/Maggot.aspx'>Asticot</a>'s sur le plateau.
  </li></ul></p>
<h2>Planet Level and Facility Level</h2>
<p>
    Chaque planète possède 2 types de niveaux qui y sont associés qui permet de déterminer les <a href='/fr/FacilityIndex.aspx'>Constructions</a> qu'on peut y construire.
    Le <u>niveau d'une planète</u> indique le <a href='/fr/Universe/HotZone.aspx#levels'>Niveau de zone</a> de l'univers où est situés cete planète.
    le <u>niveau des constructions</u> indique à quel point votre planète est évolué. Sur votre <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> c'est les constructions princiaples qui déterminent les niveaux. Dans la <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> hc'est plutôt les niveaux des <a class='extractor' href='/fr/Facility/Extractor.aspx'>Extracteur</a>
    qui le détermine.
  </p>
	</div>
	
</asp:Content>