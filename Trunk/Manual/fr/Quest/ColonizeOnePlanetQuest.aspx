<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonisez une planète additionnel sur votre zone privée
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Colonisez une planète additionnel sur votre zone privée" runat="server" /></h1>
	
	<div class="description">
		The objective of this mission is to learn how to conquerer a <a href='/fr/Universe/Planets.aspx'>Planète</a>. In your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> you can't be plagued
  by other players, so you do not have to have concerns about being attacked. <p />
  Search the universe with a <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> to find a <a href='/fr/Universe/Planets.aspx'>Planète</a>. Then select the <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>, click on top of the <a href='/fr/Universe/Planets.aspx'>Planète</a> and
  conquerer it. The following image shows an example, and you have the mission ready to be delivered.
  <img class="block" src="/Resources/Images/en/colonize.png" alt="Colonize" title="Colonize" />
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a> : +5</li></ul>
	</div>
	
</asp:Content>