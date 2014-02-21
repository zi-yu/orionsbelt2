<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs imaju jednu od najboljih karata svemira. Trebamm da mi nabaviš jednu od ovih karata od Mercs Flote. Kada nabaviš jednu, donensi je na Akademiju nivoa 1.
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Mercs imaju jednu od najboljih karata svemira. Trebamm da mi nabaviš jednu od ovih karata od Mercs Flote. Kada nabaviš jednu, donensi je na Akademiju nivoa 1." runat="server" /></h1>
	
	<div class="description">
		Mercs imaju jednu od najboljih karata svemira. Trebam vas da mi nabavite jednu od tih svemirskih karata od Merc Flote. Kada nabavite jednu, donesite mi je na Akademiju nivoa 1.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +3500</li><li><a class='sentry' href='/hr/Unit/Sentry.aspx'>Stražar</a> : +50</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +2500</li></ul>
	</div>
	
</asp:Content>