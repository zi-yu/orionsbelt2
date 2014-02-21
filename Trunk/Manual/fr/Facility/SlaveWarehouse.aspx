﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Entrepôt d'esclavage Bâtiment
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Constructions</h2><ul><li><a href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a></li><li><a href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a></li><li><a href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li><a href='/fr/Facility/Devastation.aspx'>Dévastation</a></li><li><a href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a></li><li><a href='/fr/Facility/Extractor.aspx'>Extracteur</a></li><li><a href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a></li><li><a href='/fr/Facility/ProtolExtractor.aspx'>Extracteur de Protol</a></li><li><a href='/fr/Facility/SeriumExtractor.aspx'>Extracteur de Serium</a></li><li><a href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a></li><li><a href='/fr/Facility/ElkExtractor.aspx'>Extracteur d'Elk</a></li><li><a href='/fr/Facility/NuclearFacility.aspx'>Extracteur d'Uranium</a></li><li><a href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a></li><li><a href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a></li><li><a href='/fr/Facility/Incubator.aspx'>Incubateur</a></li><li><a href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a></li><li><a href='/fr/Facility/Nest.aspx'>Nid</a></li><li><a href='/fr/Facility/SolarPanel.aspx'>Panneau solaire</a></li><li><a href='/fr/Facility/DevotionSanctuary.aspx'>Sancutaire de dévôts</a></li><li><a href='/fr/Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a></li><li><a href='/fr/Facility/Silo.aspx'>Silo</a></li><li><a href='/fr/Facility/WormHoleCreator.aspx'>Synthétiseur à trou stellaire</a></li><li><a href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Entrepôt d'esclavage" runat="server" /></h1>

	<div class="description">
		The <a class='slavewarehouse' href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a> is a <a href='/fr/Race/DarkHumans.aspx'>Renegades</a> facility that allows them to increse the <a href='/fr/Universe/Planets.aspx#Capacity'>Limite de ressource</a>.
		<div class='baseDarkHumansPreview DarkHumansSlaveWarehousePreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Entrepôt d'esclavage Niveau 1</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 1</li></ul></td><td><ul><li>300 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>47 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+3 Au score</li><li>+180 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Entrepôt d'esclavage Niveau 2</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 2</li></ul></td><td><ul><li>1200 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>374 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li></ul></td><td class='duration'>30 Minutes </td><td><ul><li>+24 Au score</li><li>+540 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Entrepôt d'esclavage Niveau 3</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 3</li></ul></td><td><ul><li>2700 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>1260 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>530 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>40 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Heure 10 Minutes </td><td><ul><li>+81 Au score</li><li>+900 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Entrepôt d'esclavage Niveau 4</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 4</li></ul></td><td><ul><li>4800 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>2987 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>1640 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>460 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Heures 50 Minutes </td><td><ul><li>+192 Au score</li><li>+1260 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Entrepôt d'esclavage Niveau 5</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 5</li></ul></td><td><ul><li>7500 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>5834 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>3470 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>350 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>5 Heures 20 Minutes </td><td><ul><li>+375 Au score</li><li>+1620 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Entrepôt d'esclavage Niveau 6</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 6</li></ul></td><td><ul><li>10800 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>10080 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>6200 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>1660 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>790 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>9 Heures 10 Minutes </td><td><ul><li>+648 Au score</li><li>+1980 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Entrepôt d'esclavage Niveau 7</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 7</li></ul></td><td><ul><li>14700 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>16007 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>10010 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>2440 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>215 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1310 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>14 Heures 30 Minutes </td><td><ul><li>+1029 Au score</li><li>+2340 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Entrepôt d'esclavage Niveau 8</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 8</li></ul></td><td><ul><li>19200 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>23894 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>15080 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>3340 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1060 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1910 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>340 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>21 Heures 40 Minutes </td><td><ul><li>+1536 Au score</li><li>+2700 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Entrepôt d'esclavage Niveau 9</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 9</li></ul></td><td><ul><li>24300 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>34020 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>21590 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>4360 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2145 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2590 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1968 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>56 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Jour 6 Heures 40 Minutes </td><td><ul><li>+2187 Au score</li><li>+3060 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Entrepôt d'esclavage Niveau 10</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Tour Obscure</a> Niveau 10</li></ul></td><td><ul><li>30000 <a href='../Intrinsic/Gold.aspx'>Or</a></li><li>46667 <a href='../Intrinsic/Titanium.aspx'>Titane</a></li><li>29720 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>5500 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>3500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3350 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>4000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1750 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Jour 18 Heures 10 Minutes </td><td><ul><li>+3000 Au score</li><li>+3420 Capacité</li><li>-0,5 Facteur de production</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>