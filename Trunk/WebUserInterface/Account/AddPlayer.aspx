<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Account/Account.Master" Inherits="OrionsBelt.WebUserInterface.Account.AddPlayer" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <div id='addPlayer' class='smallBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="ChooseThePlayerName" runat="server" /></h2></div>
        <div class='center'>
            <asp:TextBox ID="playerName" MaxLength="20" runat="server" />        
        </div>
        <div class='bottom'>
            <asp:Button ID="goToChooseRace" CssClass="button" Text="»" runat="server" />
        </div>
    </div>
    
    
</asp:Content>
