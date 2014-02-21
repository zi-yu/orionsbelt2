<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.GivePrize" 
MasterPageFile="~/Account/Account.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <OrionsBeltUI:InformationBoard runat="server" />    
    <div class='givePrizeContainer'>
    <OrionsBeltUI:GivePrizeControl TitleToken="Principal" id="givePrize" runat="server"/>
    </div>
    <div class="clear"></div>
</asp:Content>