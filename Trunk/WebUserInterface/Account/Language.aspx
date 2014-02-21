<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Account/Settings.Master" Inherits="OrionsBelt.WebUserInterface.Account.Language" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
        
<div id='changeLanguage' class='smallBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="Language" runat="server" /></h2></div>
    <div class='center'></div>
    <div class='bottom'>
        <asp:DropDownList ID="languageList" CssClass='styled' runat="server" />
    </div>
</div>
    

    
</asp:Content>
