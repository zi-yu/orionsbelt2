<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.PlayerInfo"
    MasterPageFile="~/Profile/PlayerProfile.Master" %>
<%@ Register TagPrefix="MSG" TagName="Sender" Src="~/Controls/Generic/PrivateBoardSender.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">   
    <OrionsBeltUI:PlayerBattleStats runat="server" />
    
    <%--<OrionsBeltUI:PrivateMessages ID="privateMessages" runat="server" /> --%>
    
    <div id='privateMessages' class='normalBorder'>
        <div class='top'><h2><asp:Literal ID="header" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBeltUI:InformationBoard runat="server" />
            <MSG:Sender ID="sender" runat="server" />
            <OrionsBeltUI:PrivateBoardViewerPrincipal ID="board" ReceiverType="Player" runat="server" />  
            <OrionsBeltUI:DialogueInteractions ID="dialogueInteractions" runat="server" />
        </div>
        <div class='bottom'></div>
    </div>
    
    
</asp:Content>
