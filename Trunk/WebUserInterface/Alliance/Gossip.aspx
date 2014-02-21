<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Gossip" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <div id='allianceLounge' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="EmpireMessages" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBeltUI:MessageList ID="messageList" Css="newtable" IncludeElapsedTime="true" IncludeImages="false" runat="server" />
        </div>
        <div class='bottom'></div>
    </div>
    
</asp:Content>
