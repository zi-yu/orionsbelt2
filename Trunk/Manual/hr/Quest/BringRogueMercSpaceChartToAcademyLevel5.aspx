<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs imaju jednu od najboljih karata svemira. Trebam da mi nabaviš jednu od tih svemirskih karata od Rogue Mercs Flote. Kada je nabaviš, donesi je na bilo  koju akademiju nivoa 5.
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Mercs imaju jednu od najboljih karata svemira. Trebam da mi nabaviš jednu od tih svemirskih karata od Rogue Mercs Flote. Kada je nabaviš, donesi je na bilo  koju akademiju nivoa 5." runat="server" /></h1>
	
	<div class="description">
		Mercs imaju jednu od najboljih karata svemira. Trebam da mi nabavite jednu od tih svemirskih karata od Rogue Mercs flote. Kada je nabavite donesite je na bilo koju Akademiju nivoa 5.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +8500</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +4500</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +4500</li><li><a class='scourge' href='/hr/Unit/Scourge.aspx'>Bič</a> : +40</li></ul>
	</div>
	
</asp:Content>