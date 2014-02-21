<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateFriendly.aspx.cs" Inherits="OrionsBelt.WebUserInterface.CreateFriendly" MasterPageFile="~/OrionsBeltTournament.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div class='bigBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="Units" runat="server" /></h2></div>
    <div class='center'> 
        <OrionsBeltUI:DisplayUnits id="displayUnits" runat="server"/>
    </div>
    <div class='bottom'></div>
</div>
<div id='friendlyOpponents'>
	<OrionsBeltUI:ChooseOpponent TitleToken="SearchOpponent" id="chooseOpponent" HtmlId="chooseOpponentFriendly" runat="server"/>
	<OrionsBeltUI:ChooseBot id="chooseBot" runat="server"/>
</div>
<div class='clear'></div>
<div id="createBattle">
	<asp:Button class="button" ID="createBattle" runat="server" />
</div>

</asp:Content>


