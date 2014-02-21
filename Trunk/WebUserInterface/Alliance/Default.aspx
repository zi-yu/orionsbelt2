<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.Default" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<asp:Literal ID="message" runat="server" />
<div style="float:left;width:490px;margin-top:20px;">
    

    <OrionsBeltUI:InteractionsControl ID="interactions" runat="server" />
    <asp:Panel ID="allianceMessagesPanel" runat="server" Visible="false">
        <div id='empireMessages' class='mediumBorder'>
            <div class='top'><h2><OrionsBelt:Label Key="EmpireMessages" runat="server" /></h2></div>
            <div class='center'>
                <OrionsBeltUI:MessageList ID="allianceMessages" Css="newtable allianceMessages" runat="server" />
            </div>
            <div class='bottom'></div>
        </div>
    </asp:Panel>
</div>
<div style="float:left;width:450px;">
    <OrionsBeltUI:AllianceBoard Type="Private" runat="server" />
</div>
</asp:Content>
