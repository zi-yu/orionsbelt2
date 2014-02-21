<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Quests/Quests.Master" Inherits="OrionsBelt.WebUserInterface.Quests.BountyPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <h2><OrionsBelt:Label Key="PlayerBounty" runat="server" /></h2>
    <p>
        <asp:Literal ID="info" runat="server" />
    </p>
    <asp:Button ID="accept" CssClass="button" runat="server" />
    <asp:Button ID="abandon" CssClass="button" runat="server" />
    
    <asp:PlaceHolder ID="completingQuest" Visible="false" runat="server">
        <OrionsBelt:Label ID="Label1" Key="PlayerBountyCompleting" runat="server" />
    </asp:PlaceHolder>
    
    <asp:PlaceHolder ID="questCompleted" Visible="false" runat="server">
        <OrionsBelt:Label ID="Label2" Key="PlayerBountyCompleted" runat="server" />
    </asp:PlaceHolder>
    
    <OrionsBeltUI:BountyParticipants runat="server" />
</asp:Content>
