<%@ Page Language="C#" AutoEventWireup="false" Codebehind="PirateBay.aspx.cs" Inherits="OrionsBelt.WebUserInterface.PirateBayPage" MasterPageFile="~/PopupWindow.Master" %>
<%@ Register TagPrefix="PirateBay" TagName="PirateBayControl" Src="~/Controls/PirateBay/PirateBayControl.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div>
   <OrionsBeltUI:ErrorBoard ID="ErrorBoard1" runat="server" />
    <PirateBay:PirateBayControl ID="bay" runat="server" />
</div>
<OrionsBeltUI:Script id='scriptRegister' runat="server" />
</asp:Content>





