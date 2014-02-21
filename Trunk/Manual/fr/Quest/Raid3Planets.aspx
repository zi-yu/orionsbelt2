<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Piller 3 planètes
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Piller 3 planètes" runat="server" /></h1>
	
	<div class="description">
		Piller une <a href='/fr/Universe/Planets.aspx'>Planète</a> est similaire à essayer d'en conquérir une.
  Lorsque vous cliquez (et vous avez une <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> sélectionné, évidement) sur une <a href='/fr/Universe/Planets.aspx'>Planète</a> et il y aura deux options qui vous seront donnés: 
  "Attaquer et conquérir la planèete" et "Piller la planète".
  Vous savez ce que fait le premier, mais qu'est-ce que fait le pillage? 
  Le pillage se passe de la même façon en s'attaquant à la <a href='/fr/Universe/Planets.aspx'>Planète</a>, les même règles s'appliquent, la seule chose qui change est la récompense.<p />
  La première option vous permet de prendre possession de la <a href='/fr/Universe/Planets.aspx'>Planète</a>.
  la deuxième vous permet de voler les ressources de cette <a href='/fr/Universe/Planets.aspx'>Planète</a>. Si il n'y a pas d'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a>  de défense sur la <a href='/fr/Universe/Planets.aspx'>Planète</a>, le <a href='/fr/Universe/Raids.aspx'>Pillage</a>fonctionne automatiquement.Sinon, un combat commence, et vous devez le gagner pour que votre <a href='/fr/Universe/Raids.aspx'>Pillage</a> soit un succès.<p />
  Le pillage ne semble pas utile au début car vous avez souvent toutes les ressources nécessaires, mais en progressant, votre soif de ressources pourra être comblé à l'aide de pillage.
  Vous ne pouvez pas piller une <a href='/fr/Universe/Planets.aspx'>Planète</a> non-habité.<p />
  Note: Le pillage vous donne accès à des ressources rare et la race de celui à qui appartient la planète détermine quel ressource risque d'être pillé.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +5500</li><li><a href='/fr/PirateQuests.aspx'>Pirate</a> : +30</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +600</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +600</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +600</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +600</li><li><a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +600</li></ul>
	</div>
	
</asp:Content>