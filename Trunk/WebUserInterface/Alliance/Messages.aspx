<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Messages" %>
<%@ Register TagPrefix="MSG" TagName="Sender" Src="~/Controls/Generic/PrivateBoardSender.ascx" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    
     <div id='empireMessages' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="Messages" runat="server" /></h2></div>
        <div class='center'>
            <MSG:Sender ID="sender" runat="server" />
            <OrionsBeltUI:PrivateBoardViewer ID="board" ReceiverType="Alliance" runat="server" />   
        </div>
        <div class='bottom'></div>
    </div>
</asp:Content>
