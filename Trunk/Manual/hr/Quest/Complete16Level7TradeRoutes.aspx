﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Završi 16 trgovačkih ruta sa Živom ili Dijamantima unutar 24 sata
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Završi 16 trgovačkih ruta sa Živom ili Dijamantima unutar 24 sata" runat="server" /></h1>
	
	<div class="description">
		Završite 16 trgovačkih ruta koristeči se Živom ili Dijamantima unutar 24 sata
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +8000</li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a> : +480</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +1600</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +1600</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +1600</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +1600</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1600</li></ul>
	</div>
	
</asp:Content>