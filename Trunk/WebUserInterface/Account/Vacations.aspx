<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Account/Settings.Master" Inherits="OrionsBelt.WebUserInterface.Account.Vacations" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div id='vacationPage'>
<OrionsBeltUI:VacationManager runat="server" />
<OrionsBeltUI:VacationMerchant runat="server" />
</div>
</asp:Content>
