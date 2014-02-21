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
		Own one <a href='/fr/Universe/Planets.aspx'>Planète</a> in the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a>.
  Conquering Planets on the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> is just about the same as conquering Planets on your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>, there's only one catch. The <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> is
  a public zone, that means you'll be competing with other Players for Planets.<p />
  The <a href='/fr/Universe/Planets.aspx'>Planète</a> you want to conquer may already be possession of someone else. In this case two things can happen: the <a href='/fr/Universe/Planets.aspx'>Planète</a> you are trying to conquer has
  no defenses (the <a href='/fr/Universe/Planets.aspx'>Planète</a> has no Defense <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>), or the <a href='/fr/Universe/Planets.aspx'>Planète</a> does have defenses.<p />
  In the first case you immediatly gain ownership of the <a href='/fr/Universe/Planets.aspx'>Planète</a> in question, just like conquering in the <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>. On the second case the <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> you used
  to try and conquer the Planet will enter in a Battle with the defense <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> of the <a href='/fr/Universe/Planets.aspx'>Planète</a>. The Player who gains the <a href="../Battles/BattleConcepts.aspx">Battle</a> will
  be the owner of the <a href='/fr/Universe/Planets.aspx'>Planète</a>.<p />
  Note that <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> planets are different from your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> planets, on the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> planets you will only be able to build one Facility,
  <a href="../Facility/Extractor.aspx">Extractors</a>.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a> : +50</li><li>Score : +80</li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a> : +2</li><li><a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a> : +3</li></ul>
	</div>
	
</asp:Content>