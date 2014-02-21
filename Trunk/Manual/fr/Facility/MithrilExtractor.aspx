﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Extracteur de Mithril Bâtiment
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Constructions</h2><ul><li><a href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a></li><li><a href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a></li><li><a href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li><a href='/fr/Facility/Devastation.aspx'>Dévastation</a></li><li><a href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a></li><li><a href='/fr/Facility/Extractor.aspx'>Extracteur</a></li><li><a href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a></li><li><a href='/fr/Facility/ProtolExtractor.aspx'>Extracteur de Protol</a></li><li><a href='/fr/Facility/SeriumExtractor.aspx'>Extracteur de Serium</a></li><li><a href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a></li><li><a href='/fr/Facility/ElkExtractor.aspx'>Extracteur d'Elk</a></li><li><a href='/fr/Facility/NuclearFacility.aspx'>Extracteur d'Uranium</a></li><li><a href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a></li><li><a href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a></li><li><a href='/fr/Facility/Incubator.aspx'>Incubateur</a></li><li><a href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a></li><li><a href='/fr/Facility/Nest.aspx'>Nid</a></li><li><a href='/fr/Facility/SolarPanel.aspx'>Panneau solaire</a></li><li><a href='/fr/Facility/DevotionSanctuary.aspx'>Sancutaire de dévôts</a></li><li><a href='/fr/Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a></li><li><a href='/fr/Facility/Silo.aspx'>Silo</a></li><li><a href='/fr/Facility/WormHoleCreator.aspx'>Synthétiseur à trou stellaire</a></li><li><a href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Extracteur de Mithril" runat="server" /></h1>

	<div class="description">
		The <a class='mithrilextractor' href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a> is a <a href='/fr/Race/LightHumans.aspx'>Utopians</a> facility that extracts <a class='mithril' href='/fr/Intrinsic/Mithril.aspx'>Mithril</a> from <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> planets. Each <a class='mithrilextractor' href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a>'s
  level increases +1 on the planet's <a class='mithril' href='/fr/Intrinsic/Mithril.aspx'>Mithril</a> income.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/MithrilExtractorR.png' alt='Extracteur de Mithril' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Extracteur de Mithril Niveau 1</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centre de Commandement</a> Niveau 4</li></ul></td><td><ul><li>220 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>200 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li></ul></td><td class='duration'>10 Minutes </td><td><ul><li>+4 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Extracteur de Mithril Niveau 2</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li>Aucune dépendance</li></td><td><ul><li>120 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>880 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>800 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>100 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>30 Minutes </td><td><ul><li>+32 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Extracteur de Mithril Niveau 3</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li>Aucune dépendance</li></td><td><ul><li>320 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>1980 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>1800 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>350 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>1 Heure 30 Minutes </td><td><ul><li>+108 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Extracteur de Mithril Niveau 4</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li>Aucune dépendance</li></td><td><ul><li>600 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>3520 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>3200 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>700 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>140 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Heures 40 Minutes </td><td><ul><li>+256 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Extracteur de Mithril Niveau 5</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centre de Commandement</a> Niveau 5</li></ul></td><td><ul><li>960 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>5500 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>5000 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>1150 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>7 Heures </td><td><ul><li>+500 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Extracteur de Mithril Niveau 6</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centre de Commandement</a> Niveau 6</li></ul></td><td><ul><li>1400 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>7920 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>7200 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>1700 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>260 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>940 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>12 Heures </td><td><ul><li>+864 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Extracteur de Mithril Niveau 7</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centre de Commandement</a> Niveau 7</li></ul></td><td><ul><li>1920 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>10780 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>9800 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>2350 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>715 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1460 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>19 Heures </td><td><ul><li>+1372 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Extracteur de Mithril Niveau 8</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centre de Commandement</a> Niveau 8</li></ul></td><td><ul><li>2520 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>14080 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>12800 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>3100 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>420 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1240 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2060 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Jour 4 Heures 10 Minutes </td><td><ul><li>+2048 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Extracteur de Mithril Niveau 9</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centre de Commandement</a> Niveau 9</li></ul></td><td><ul><li>3200 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>17820 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>16200 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>3950 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>930 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1835 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2740 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>166 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Jour 16 Heures 10 Minutes </td><td><ul><li>+2916 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Extracteur de Mithril Niveau 10</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Centre de Commandement</a> Niveau 10</li></ul></td><td><ul><li>3960 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>22000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>20000 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>4900 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>3500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Jours 7 Heures 10 Minutes </td><td><ul><li>+4000 Au score</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>