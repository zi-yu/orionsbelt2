<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Locirali smo nemilosrdnu desnu ruku Metalne Brade. Zove se Srebrena Brada. Izvještaji ga lociraju u zonu nivo 7 ali katkada odluta do zona nivo 9 i 10. Nađi ga i donesi njegovu glavu na bilo koju Akademiju nivoa 7.
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Locirali smo nemilosrdnu desnu ruku Metalne Brade. Zove se Srebrena Brada. Izvještaji ga lociraju u zonu nivo 7 ali katkada odluta do zona nivo 9 i 10. Nađi ga i donesi njegovu glavu na bilo koju Akademiju nivoa 7." runat="server" /></h1>
	
	<div class="description">
		Locirali smo nemilosrdnu desnu ruku Metalne Brade. Zove sebe Srebrena Brada. Izvještaju ga lociraju u zonu nivoa 7. ali katkada odluta do zona nivo 9 i 10. Pronađite ga i donesite njegovu glavu na bilo koju Akademiju nivoa 7.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +50000</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +12000</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +12000</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +12000</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +12000</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +12000</li><li><a class='silverbeard' href='/hr/Unit/SilverBeard.aspx'>Srebrena Brada</a> : +1</li></ul>
	</div>
	
</asp:Content>