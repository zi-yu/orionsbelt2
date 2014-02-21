<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Quests/Quests.Master" Inherits="OrionsBelt.WebUserInterface.Quests.Quest" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <h1><OrionsBelt:Label Key="DeliverQuest" runat="server" /></h1>
    
    <asp:Literal ID="resultPanel" runat="server" />
    
    <asp:PlaceHolder ID="content" runat="server">
        <div class="note"><asp:Literal ID="questDescription" runat="server" /></div>
        
        <h2><OrionsBelt:Label ID="Label1" Key="Reward" runat="server" /></h2>    
        <p><asp:Literal ID="questRewards" runat="server" /></p>
        
        <asp:Button ID="submitButton" runat="server" />
        <asp:Button ID="cancelButton" runat="server" />
    </asp:PlaceHolder>
    
</asp:Content>
