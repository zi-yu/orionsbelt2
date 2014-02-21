<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zerstöre Silber Bart
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Zerstöre Silber Bart" runat="server" /></h1>
	
	<div class="description">
		Wir haben die rücksichtslose Rechte Hand von Metallic Beard lokalisiert. He nennt sich selbst Silver Beard. Berichte sagen dass er sich in der Level 7 Zone aufhält  aber manchmal wandert er in Level 9 und Level 10 Zonen herum. Finde ihn und bringe seinen Kopf zu einer Level 7 Akademie.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +50000</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +12000</li><li><a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> : +12000</li><li><a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a> : +12000</li><li><a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a> : +12000</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +12000</li><li><a class='silverbeard' href='/de/Unit/SilverBeard.aspx'>Silberbart</a> : +1</li></ul>
	</div>
	
</asp:Content>