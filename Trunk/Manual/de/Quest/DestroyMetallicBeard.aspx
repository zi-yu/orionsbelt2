<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zerstöre Metallischer Bart
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Zerstöre Metallischer Bart" runat="server" /></h1>
	
	<div class="description">
		Dies ist die wichtigste Mission die ich dir heute geben werde. Du musst die Levels 9 und 10 durchsuchen und die Bedrohung die von Metallic Beard ausgeht, beenden. Bring seinen Kopf zu einer Level 10 Academy.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a> : +3000</li><li>Spielstand : +100000</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +25000</li><li><a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> : +25000</li><li><a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a> : +25000</li><li><a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a> : +25000</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +25000</li><li><a class='metallicbeard' href='/de/Unit/MetallicBeard.aspx'>Metallischer Bart</a> : +1</li></ul>
	</div>
	
</asp:Content>