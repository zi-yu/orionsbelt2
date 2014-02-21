<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Attaquer et détruire 3 escadrilles
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Attaquer et détruire 3 escadrilles" runat="server" /></h1>
	
	<div class="description">
		S'engager dans un cobat avec une autre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> est aussi facile que conquérir une <a href='/fr/Universe/Planets.aspx'>Planète</a>.
 Il suffit d'envoyer une <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> sélectionné (Celle avec laquelle vous voulez attaquer) et cliquer L'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> que vous voulez combattre. <p />
  Un petit menu apparaîtra avec l'option "suivre et attaquer l'escadrille", cliquez et votre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> va suivre et automatiquement attaquer cette <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>.
  Lorsque votre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>attainte l'autre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> le combat commence et il vous faudra vous dirger dans le menu des combats. <p /> 
  Votre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> sera immobilisé pour la durée du combat. 
  Lorsque le combat termine (et si vous gagneze) vous pourrez contrôler votre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> comme d'habitude, 
  mais si vous perdez,  l'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> est complètement détruite avec sa cargaison (Ressources incluent). 
  Il faut donc faire attention avant d'attaquer une autre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> de vous assurer que l'escadrille d'attaque ne possède pas des ressouces que vous voulez perdre.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +3500</li><li><a href='/fr/PirateQuests.aspx'>Pirate</a> : +20</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +1500</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +1500</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +1500</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +1500</li><li><a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1500</li></ul>
	</div>
	
</asp:Content>