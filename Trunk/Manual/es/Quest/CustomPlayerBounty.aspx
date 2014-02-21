<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ordered Player Bounty Hunt
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ordered Player Bounty Hunt</h1>
	<div class="description">
    Players can request custom bounties on any target. When a player creates a custom target,
    he has to pay a <a href='/es/Commerce/Orions.aspx'>Orions</a> reward to the players that assist him/her. Several players may accept a bounty hunt,
    and they progress by taking points from the target on battles on the <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>.
    <p />
    If more than one hunter steals points, the <a href='/es/Commerce/Orions.aspx'>Orions</a> reguard will be split.
  </div>
	
</asp:Content>