<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Dévastation Bâtiment
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Constructions</h2><ul><li><a href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a></li><li><a href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a></li><li><a href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li><a href='/fr/Facility/Devastation.aspx'>Dévastation</a></li><li><a href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a></li><li><a href='/fr/Facility/Extractor.aspx'>Extracteur</a></li><li><a href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a></li><li><a href='/fr/Facility/ProtolExtractor.aspx'>Extracteur de Protol</a></li><li><a href='/fr/Facility/SeriumExtractor.aspx'>Extracteur de Serium</a></li><li><a href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a></li><li><a href='/fr/Facility/ElkExtractor.aspx'>Extracteur d'Elk</a></li><li><a href='/fr/Facility/NuclearFacility.aspx'>Extracteur d'Uranium</a></li><li><a href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a></li><li><a href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a></li><li><a href='/fr/Facility/Incubator.aspx'>Incubateur</a></li><li><a href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a></li><li><a href='/fr/Facility/Nest.aspx'>Nid</a></li><li><a href='/fr/Facility/SolarPanel.aspx'>Panneau solaire</a></li><li><a href='/fr/Facility/DevotionSanctuary.aspx'>Sancutaire de dévôts</a></li><li><a href='/fr/Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a></li><li><a href='/fr/Facility/Silo.aspx'>Silo</a></li><li><a href='/fr/Facility/WormHoleCreator.aspx'>Synthétiseur à trou stellaire</a></li><li><a href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Dévastation" runat="server" /></h1>

	<div class="description">
		<a class='devastation' href='/fr/Facility/Devastation.aspx'>Dévastation</a> est la construction ultime des <a href='/fr/Race/DarkHumans.aspx'>Renegades</a> ultimate facility. Elle permet aux <a href='/fr/Race/DarkHumans.aspx'>Renegades</a> de cibler et détruire une partie de plusieurs escadrilles sur l'<a href='/fr/Universe/Default.aspx'>Univers</a>, 
  plus le joueur possède de construction <a class='devastation' href='/fr/Facility/Devastation.aspx'>Dévastation</a> plus l'attaque est puissante et les dégâts sont grands.
  <p />
 Le pouvoir ultime acuis avec <a class='devastation' href='/fr/Facility/Devastation.aspx'>Dévastation</a> est la capacité d'utiliser <a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a>.
		<div class='baseDarkHumansPreview DarkHumansDevastationPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Dévastation Niveau 1</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 7</li></ul></td><td><ul><li>24000 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>26000 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>28000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>3000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Jour 14 Heures </td><td><ul><li>+3000 Au score</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Dévastation Niveau 2</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Hangar de Domination</a> Niveau 9</li></ul></td><td><ul><li>48000 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>52000 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>56000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>6000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>6000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Jours 4 Heures </td><td><ul><li>+6000 Au score</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>