<%@ Page Language="C#" AutoEventWireup="false" Codebehind="Academy.aspx.cs" Inherits="OrionsBelt.WebUserInterface.AcademyPage" MasterPageFile="~/PopupWindow.Master" %>
<%@ Register TagPrefix="Academy" TagName="AcademyControl" Src="~/Controls/Academy/AcademyControl.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div>
   <OrionsBeltUI:ErrorBoard ID="ErrorBoard1" runat="server" />
    <Academy:AcademyControl ID="academy" runat="server" />
    <OrionsBeltUI:AcademyQuestDelivery runat="server" />
</div>
<OrionsBeltUI:Script id='scriptRegister' runat="server" />
</asp:Content>




