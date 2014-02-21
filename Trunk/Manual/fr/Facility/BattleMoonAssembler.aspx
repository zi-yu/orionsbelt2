﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Assembleur de lune de bataille Bâtiment
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Constructions</h2><ul><li><a href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a></li><li><a href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a></li><li><a href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li><a href='/fr/Facility/Devastation.aspx'>Dévastation</a></li><li><a href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a></li><li><a href='/fr/Facility/Extractor.aspx'>Extracteur</a></li><li><a href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a></li><li><a href='/fr/Facility/ProtolExtractor.aspx'>Extracteur de Protol</a></li><li><a href='/fr/Facility/SeriumExtractor.aspx'>Extracteur de Serium</a></li><li><a href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a></li><li><a href='/fr/Facility/ElkExtractor.aspx'>Extracteur d'Elk</a></li><li><a href='/fr/Facility/NuclearFacility.aspx'>Extracteur d'Uranium</a></li><li><a href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a></li><li><a href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a></li><li><a href='/fr/Facility/Incubator.aspx'>Incubateur</a></li><li><a href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a></li><li><a href='/fr/Facility/Nest.aspx'>Nid</a></li><li><a href='/fr/Facility/SolarPanel.aspx'>Panneau solaire</a></li><li><a href='/fr/Facility/DevotionSanctuary.aspx'>Sancutaire de dévôts</a></li><li><a href='/fr/Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a></li><li><a href='/fr/Facility/Silo.aspx'>Silo</a></li><li><a href='/fr/Facility/WormHoleCreator.aspx'>Synthétiseur à trou stellaire</a></li><li><a href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Assembleur de lune de bataille" runat="server" /></h1>

	<div class="description">
		Le <a class='battlemoonassembler' href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a> est la construction des <a href='/fr/Race/DarkHumans.aspx'>Renegades</a> qui leur permet de construire leur unité  <a href='/fr/Battles/Ultimate.aspx'>Ultime</a> la: <a class='battlemoon' href='/fr/Unit/BattleMoon.aspx'>Lune de Combat</a>.
		<div class='baseDarkHumansPreview DarkHumansBattleMoonAssemblerPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Assembleur de lune de bataille Niveau 1</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 8</li></ul></td><td><ul><li>33000 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>28000 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>36000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>4000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>3500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>3250 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Jour 21 Heures </td><td><ul><li>+2500 Au score</li></ul></td><td><ul><li><a href='../Unit/BattleMoon.aspx'>Lune de Combat</a></li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Assembleur de lune de bataille Niveau 2</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domination</a> Niveau 10</li></ul></td><td><ul><li>66000 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>56000 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>72000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>8000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>7000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>6500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Jours 18 Heures </td><td><ul><li>+5000 Au score</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>