﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Posjeduje jedan planet nivoa 7 u hot zoni
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Posjeduje jedan planet nivoa 7 u hot zoni" runat="server" /></h1>
	
	<div class="description">
		Posjeduj jedan planet nivoa 7 na hot zoni
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +2000</li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a> : +57</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +500</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +400</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +800</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +800</li></ul>
	</div>
	
</asp:Content>