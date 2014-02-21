<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trebam infiltrirati Rogue Mercs flotu i za to trebam određene predmete. 10 Rogue Mercs uniformi da budem točan. Donesi mi ih na bilo koju Akademiju nivoa 5.
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Trebam infiltrirati Rogue Mercs flotu i za to trebam određene predmete. 10 Rogue Mercs uniformi da budem točan. Donesi mi ih na bilo koju Akademiju nivoa 5." runat="server" /></h1>
	
	<div class="description">
		Trebam se infiltrirati u Rogue Mercs flotu i za to trebam određene predmete. 10 Rogue Mercs uniformi da budem točan. Donesite mi ih na bilo koju Akademiju nivoa 5.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +8000</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +4500</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +4500</li></ul>
	</div>
	
</asp:Content>