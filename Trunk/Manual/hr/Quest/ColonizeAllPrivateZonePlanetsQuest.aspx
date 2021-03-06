﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Koloniziraj svih pet planeta u svojoj privatnoj zoni
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Koloniziraj svih pet planeta u svojoj privatnoj zoni" runat="server" /></h1>
	
	<div class="description">
		Sada kada ste naučili kako kolonizirati <a href='/hr/Universe/Planets.aspx'>Planeti</a>, vaš sljedeći <a href='/hr/Quests.aspx'>Misija</a> je kolonizirati sve planete u vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a>. U vašoj <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> ima 5 <a href='/hr/Universe/Planets.aspx'>Planeti</a>, otkrijte ih i kolonizirajete ih. <p />
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a> : +50</li></ul>
	</div>
	
</asp:Content>