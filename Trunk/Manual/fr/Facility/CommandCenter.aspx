﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Centre de Commandement Bâtiment
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Constructions</h2><ul><li><a href='/fr/Facility/BattleMoonAssembler.aspx'>Assembleur de lune de bataille</a></li><li><a href='/fr/Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a></li><li><a href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a></li><li><a href='/fr/Facility/Devastation.aspx'>Dévastation</a></li><li><a href='/fr/Facility/SlaveWarehouse.aspx'>Entrepôt d'esclavage</a></li><li><a href='/fr/Facility/Extractor.aspx'>Extracteur</a></li><li><a href='/fr/Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a></li><li><a href='/fr/Facility/ProtolExtractor.aspx'>Extracteur de Protol</a></li><li><a href='/fr/Facility/SeriumExtractor.aspx'>Extracteur de Serium</a></li><li><a href='/fr/Facility/TitaniumExtractor.aspx'>Extracteur de Titane</a></li><li><a href='/fr/Facility/ElkExtractor.aspx'>Extracteur d'Elk</a></li><li><a href='/fr/Facility/NuclearFacility.aspx'>Extracteur d'Uranium</a></li><li><a href='/fr/Facility/UnitYard.aspx'>Hangar de construction</a></li><li><a href='/fr/Facility/DominationYard.aspx'>Hangar de Domination</a></li><li><a href='/fr/Facility/Incubator.aspx'>Incubateur</a></li><li><a href='/fr/Facility/QueenHatchery.aspx'>Incubateur de la reine</a></li><li><a href='/fr/Facility/Nest.aspx'>Nid</a></li><li><a href='/fr/Facility/SolarPanel.aspx'>Panneau solaire</a></li><li><a href='/fr/Facility/DevotionSanctuary.aspx'>Sancutaire de dévôts</a></li><li><a href='/fr/Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a></li><li><a href='/fr/Facility/Silo.aspx'>Silo</a></li><li><a href='/fr/Facility/WormHoleCreator.aspx'>Synthétiseur à trou stellaire</a></li><li><a href='/fr/Facility/DarknessHall.aspx'>Tour Obscure</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Centre de Commandement" runat="server" /></h1>

	<div class="description">
		The <a class='commandcenter' href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a> is the <a href='/fr/Race/LightHumans.aspx'>Utopians</a> main facility. All other <a href='/fr/Race/LightHumans.aspx'>Utopians</a> facilities depend on the <a class='commandcenter' href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a>.
  Each <a class='commandcenter' href='/fr/Facility/CommandCenter.aspx'>Centre de Commandement</a> level increases the production of <a class='energy' href='/fr/Intrinsic/Energy.aspx'>Énergie</a>, <a class='serium' href='/fr/Intrinsic/Serium.aspx'>Serium</a>, <a class='mithril' href='/fr/Intrinsic/Mithril.aspx'>Mithril</a> and increases the <a href='/fr/Universe/Planets.aspx#Capacity'>Limite de ressource</a>.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/CommandCenterR.png' alt='Centre de Commandement' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Centre de Commandement Niveau 1</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li>Aucune dépendance</li></td><td><ul><li>Aucun coût</li></td><td class='duration'>Commence à être construit</td><td><ul><li>+10 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li><li>+1000 Capacité</li></ul></td><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 1</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 1</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Centre de Commandement Niveau 2</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 1</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 1</li></ul></td><td><ul><li>315 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>257 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li></ul></td><td class='duration'>40 Minutes </td><td><ul><li>+80 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li></ul></td><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 2</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 1</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 2</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 1</li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Centre de Commandement Niveau 3</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 2</li></ul></td><td><ul><li>1170 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>954 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li></ul></td><td class='duration'>2 Heures </td><td><ul><li>+270 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li></ul></td><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 3</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 3</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 3</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 3</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Centre de Commandement Niveau 4</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 3</li></ul></td><td><ul><li>2835 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>2310 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>380 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>4 Heures 40 Minutes </td><td><ul><li>+640 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li></ul></td><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 4</li><li><a href='../Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a> Niveau 1</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 4</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 4</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 4</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Centre de Commandement Niveau 5</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 4</li></ul></td><td><ul><li>1200 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>5580 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>4547 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>1219 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>250 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>9 Heures </td><td><ul><li>+1250 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li><li>+1000 Capacité</li></ul></td><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 5</li><li><a href='../Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a> Niveau 5</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 5</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 5</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 5</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Centre de Commandement Niveau 6</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 5</li></ul></td><td><ul><li>5750 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>9675 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>7884 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>2470 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>160 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1160 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>15 Heures 30 Minutes </td><td><ul><li>+2160 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 6</li><li><a href='../Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a> Niveau 6</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 6</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 6</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 6</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Centre de Commandement Niveau 7</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 6</li></ul></td><td><ul><li>12100 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>15390 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>12541 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>4216 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1430 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2430 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>1 Jour 40 Minutes </td><td><ul><li>+3430 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul><li><a href='../Facility/DeepSpaceScanner.aspx'>Satellite d'observation</a> Niveau 1</li><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 7</li><li><a href='../Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a> Niveau 7</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 7</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 7</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 7</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Centre de Commandement Niveau 8</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 7</li></ul></td><td><ul><li>20550 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>22995 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>18737 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>6540 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3120 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>4120 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1180 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Jour 12 Heures 50 Minutes </td><td><ul><li>+5120 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul><li><a href='../Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a> Niveau 1</li><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 8</li><li><a href='../Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a> Niveau 8</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 8</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 8</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 8</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Centre de Commandement Niveau 9</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 8</li></ul></td><td><ul><li>31400 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>32760 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>26694 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>9524 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>5290 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>6290 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>4435 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>968 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Jours 4 Heures 30 Minutes </td><td><ul><li>+7290 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 9</li><li><a href='../Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a> Niveau 9</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 9</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 9</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 9</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Centre de Commandement Niveau 10</a></h2><table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 9</li></ul></td><td><ul><li>44950 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>44955 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>36631 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>13250 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>8000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>9000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>8500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>3000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>3 Jours </td><td><ul><li>+10000 Au score</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Énergie</a> Par tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Par tick</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Par tick</li></ul></td><td><ul><li><a href='../Facility/SolarPanel.aspx'>Panneau solaire</a> Niveau 10</li><li><a href='../Facility/MithrilExtractor.aspx'>Extracteur de Mithril</a> Niveau 10</li><li><a href='../Facility/Silo.aspx'>Silo</a> Niveau 10</li><li><a href='../Facility/SeriumExtractor.aspx'>Extracteur de Serium</a> Niveau 10</li><li><a href='../Facility/UnitYard.aspx'>Hangar de construction</a> Niveau 10</li></ul></td></tr></table>
	
</asp:Content>