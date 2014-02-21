﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Vollende 8 Handelsrouten indem du Alkohol oder Medizin benutzt
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Vollende 8 Handelsrouten indem du Alkohol oder Medizin benutzt" runat="server" /></h1>
	
	<div class="description">
		Beende acht Handelsrouten indem du  Alkohol oder Medizin benutzt
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +4000</li><li><a href='/de/MerchantQuests.aspx'>Händler</a> : +240</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +2400</li><li><a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> : +2400</li><li><a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a> : +2400</li><li><a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a> : +2400</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +2400</li></ul>
	</div>
	
</asp:Content>