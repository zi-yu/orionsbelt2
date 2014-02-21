<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ovo je najvažnija misija koju sam ti dao do danas. Moraš pretražiti nivoe 9 i 10 i završiti prijetnju Metalne Brade. Donesi njegovu glavu na bilo koju Akademiju nivoa 10.
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Ovo je najvažnija misija koju sam ti dao do danas. Moraš pretražiti nivoe 9 i 10 i završiti prijetnju Metalne Brade. Donesi njegovu glavu na bilo koju Akademiju nivoa 10." runat="server" /></h1>
	
	<div class="description">
		Ovo je najvažnija misija koju sam vam dao do danas. Trebate pretražiti zone 9 i 10 i završiti sa prijetnjom Metalne Brade. Donesite njegovu glavu na bilo koju Akademiju nivoa 10.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li><a href='/hr/Commerce/Orions.aspx'>Orioni</a> : +3000</li><li>Rezultat : +100000</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +25000</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +25000</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +25000</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +25000</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +25000</li><li><a class='metallicbeard' href='/hr/Unit/MetallicBeard.aspx'>Metalna Brada</a> : +1</li></ul>
	</div>
	
</asp:Content>