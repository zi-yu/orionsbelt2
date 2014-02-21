<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Commander Fox
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Commander Fox" runat="server" /></h1>
	
	<div class="description">
		I've done with it. Bring me Commander Fox head now. This is the most important mission i will give you until today, so don't fail or you will regreat. You must search levels 9 and 10 and bring his head to a level 10 Pirate Bay.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +50000</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +12000</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +12000</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +12000</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +12000</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +12000</li><li><a class='commanderfox' href='/hr/Unit/CommanderFox.aspx'>Commander Fox</a> : +1</li></ul>
	</div>
	
</asp:Content>