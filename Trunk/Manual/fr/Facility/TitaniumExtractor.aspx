﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Extracteur de Titane Bâtiment
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Constructions</h2><ul><li><a href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a></li><li><a href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a></li><li><a href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li><a href='/fr/Facility/Devastation.aspx'>Dévastation</a></li><li><a href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a></li><li><a href='/fr/Facility/Extractor.aspx'>Extracteur</a></li><li><a href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a></li><li><a href='/fr/Facility/ProtolExtractor.aspx'>Extracteur de Protol</a></li><li><a href='/fr/Facility/SeriumExtractor.aspx'>Extracteur de Serium</a></li><li><a href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a></li><li><a href='/fr/Facility/ElkExtractor.aspx'>Extracteur d'Elk</a></li><li><a href='/fr/Facility/NuclearFacility.aspx'>Extracteur d'Uranium</a></li><li><a href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a></li><li><a href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a></li><li><a href='/fr/Facility/Incubator.aspx'>Incubateur</a></li><li><a href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a></li><li><a href='/fr/Facility/Nest.aspx'>Nid</a></li><li><a href='/fr/Facility/SolarPanel.aspx'>Panneau solaire</a></li><li><a href='/fr/Facility/DevotionSanctuary.aspx'>Sancutaire de dévôts</a></li><li><a href='/fr/Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a></li><li><a href='/fr/Facility/Silo.aspx'>Silo</a></li><li><a href='/fr/Facility/WormHoleCreator.aspx'>Synthétiseur à trou stellaire</a></li><li><a href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Extracteur de Titane" runat="server" /></h1>

	<div class="description">
		Le <a class='titaniumextractor' href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a>est une construction <a href='/fr/Race/DarkHumans.aspx'>Renegades</a> permettant d'extraire le <a class='titanium' href='/fr/Intrinsic/Titanium.aspx'>Titane</a> des planètes de la <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>. Chaque niveau du <a class='titaniumextractor' href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a> augmente de +1 la quantité de <a class='titanium' href='/fr/Intrinsic/Titanium.aspx'>Titane</a> acquise.
		<div class='baseDarkHumansPreview DarkHumansTitaniumExtractorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Extracteur de Titane Niveau 1</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 1</li></ul></td><td><ul><li>23 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>40 <a href='../Intrinsic/Gold.aspx'>Or</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+3 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Extracteur de Titane Niveau 2</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 2</li></ul></td><td><ul><li>92 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>320 <a href='../Intrinsic/Gold.aspx'>Or</a></li></ul></td><td class='duration'>30 Minutes </td><td><ul><li>+24 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Extracteur de Titane Niveau 3</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 3</li></ul></td><td><ul><li>207 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>1080 <a href='../Intrinsic/Gold.aspx'>Or</a></li></ul></td><td class='duration'>1 Heure 30 Minutes </td><td><ul><li>+81 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Extracteur de Titane Niveau 4</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 4</li></ul></td><td><ul><li>480 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>368 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>2560 <a href='../Intrinsic/Gold.aspx'>Or</a></li></ul></td><td class='duration'>3 Heures 30 Minutes </td><td><ul><li>+192 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Extracteur de Titane Niveau 5</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 5</li></ul></td><td><ul><li>3225 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>575 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>5000 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>125 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>6 Heures 50 Minutes </td><td><ul><li>+375 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Extracteur de Titane Niveau 6</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 6</li></ul></td><td><ul><li>7320 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>828 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>8640 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>620 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>148 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>11 Heures 40 Minutes </td><td><ul><li>+648 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Extracteur de Titane Niveau 7</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 7</li></ul></td><td><ul><li>13035 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1127 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>13720 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>1205 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>529 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>60 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>18 Heures 40 Minutes </td><td><ul><li>+1029 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Extracteur de Titane Niveau 8</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 8</li></ul></td><td><ul><li>20640 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1472 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>20480 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>1880 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1036 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>130 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>660 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Jour 3 Heures 40 Minutes </td><td><ul><li>+1536 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Extracteur de Titane Niveau 9</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 9</li></ul></td><td><ul><li>30405 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1863 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>29160 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>2645 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1687 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>895 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1340 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>180 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Jour 15 Heures 30 Minutes </td><td><ul><li>+2187 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Extracteur de Titane Niveau 10</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 10</li></ul></td><td><ul><li>42600 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>2300 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>40000 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>3500 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1750 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2100 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1084 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Jours 6 Heures </td><td><ul><li>+3000 Au score</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titane</a> Par tick</li><li>+0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>