<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Possédez 1 planète de niveau 1 sur la zone publique
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Possédez 1 planète de niveau 1 sur la zone publique" runat="server" /></h1>
	
	<div class="description">
		Possédez 1 planète niveau sur la zone publique.

 Conquérir une planète sur la <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> se fait de la même façon que sur <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>, avec une petite différence. La <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> est publique; signifiant que vous êtes en compétition pour l'acquisition de planètes avec les autres joueurs.<p />
  Les <a href='/fr/Universe/Planets.aspx'>Planète</a> que vous alez conquérir peuvent appartenir à quelqu'un d'autre. Dans ce cas, il peut arriver 2 choses: la <a href='/fr/Universe/Planets.aspx'>Planète</a> est immédiatement conquit car il n'y a pas d'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> sur la planète, ou la <a href='/fr/Universe/Planets.aspx'>Planète</a> est effectivement défendu.<p />
  Dans le premier cas, vous allez immédiatement acuérir possession de la planète, et dans le deuxième cas, il y aura combat contre l'escadrille de défense. Le joueur qui gagne sera celui qui gagne ou conserve la planète. <a href="../Battles/BattleConcepts.aspx">Battle</a><p />
  À noter que sur le <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> les planètes sont différentes que sur le <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>car vous pouvez seulement construire des extracteurs.
  <a href="../Facility/Extractor.aspx">Extractors</a>.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a> : +50</li><li>Score : +80</li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a> : +2</li><li><a class='darkrain' href='/fr/Unit/DarkRain.aspx'>Bruine Noire</a> : +3</li></ul>
	</div>
	
</asp:Content>