<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Become champion of 22 arenas at the same time
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Become champion of 22 arenas at the same time" runat="server" /></h1>
	
	<div class="description">
		Explore the <a href='/hr/Universe/Default.aspx'>Svemir</a>, find <a href='/hr/Universe/Arenas.aspx'>Arene</a> and become the undisputed champion in at least 22 arenas.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a> : +220</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +22000</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +22000</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +22000</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +22000</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +22000</li></ul>
	</div>
	
</asp:Content>