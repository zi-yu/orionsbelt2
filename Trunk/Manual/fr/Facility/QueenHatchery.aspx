<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Incubateur de la reine Bâtiment
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Constructions</h2><ul><li><a href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a></li><li><a href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a></li><li><a href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li><a href='/fr/Facility/Devastation.aspx'>Dévastation</a></li><li><a href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a></li><li><a href='/fr/Facility/Extractor.aspx'>Extracteur</a></li><li><a href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a></li><li><a href='/fr/Facility/ProtolExtractor.aspx'>Extracteur de Protol</a></li><li><a href='/fr/Facility/SeriumExtractor.aspx'>Extracteur de Serium</a></li><li><a href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a></li><li><a href='/fr/Facility/ElkExtractor.aspx'>Extracteur d'Elk</a></li><li><a href='/fr/Facility/NuclearFacility.aspx'>Extracteur d'Uranium</a></li><li><a href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a></li><li><a href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a></li><li><a href='/fr/Facility/Incubator.aspx'>Incubateur</a></li><li><a href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a></li><li><a href='/fr/Facility/Nest.aspx'>Nid</a></li><li><a href='/fr/Facility/SolarPanel.aspx'>Panneau solaire</a></li><li><a href='/fr/Facility/DevotionSanctuary.aspx'>Sancutaire de dévôts</a></li><li><a href='/fr/Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a></li><li><a href='/fr/Facility/Silo.aspx'>Silo</a></li><li><a href='/fr/Facility/WormHoleCreator.aspx'>Synthétiseur à trou stellaire</a></li><li><a href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Incubateur de la reine" runat="server" /></h1>

	<div class="description">
		La[ QueenHatchery] est la bâtiment <a href='/fr/Race/Bugs.aspx'>Levyr</a> leur permettant de construire leur unité ultime: la <a class='queen' href='/fr/Unit/Queen.aspx'>Reine</a>.
		<div class='baseBugsPreview BugsQueenHatcheryPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Incubateur de la reine Niveau 1</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nid</a> Niveau 8</li></ul></td><td><ul><li>32000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>24000 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>10500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>8500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Jour 18 Heures </td><td><ul><li>+3000 Au score</li></ul></td><td><ul><li><a href='../Unit/Queen.aspx'>Reine</a></li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Incubateur de la reine Niveau 2</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Incubateur</a> Niveau 10</li></ul></td><td><ul><li>64000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>48000 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>21000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>19000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>18000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>17000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Jours 12 Heures </td><td><ul><li>+6000 Au score</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>