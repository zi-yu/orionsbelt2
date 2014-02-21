<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/OrionsBeltMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    
    <div class="note">
        <OrionsBelt:Label Key="ErrorMessage" runat="server" />
        <p />
        <a href="javascript:history.go(-1)"><OrionsBelt:Label ID="Label1" Key="TryAgain" runat="server" /></a>
    </div>
    
</asp:Content>