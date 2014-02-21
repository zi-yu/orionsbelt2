<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.ManageMember" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
     <div id="manageAlliancePlayer" class='mediumBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="AllianceManageMemberTitle" runat="server"></OrionsBelt:Label> - <asp:Literal ID="name" runat="server"></asp:Literal></h2></div>
        <div class='center'>
            <asp:DropDownList ID="ranks" CssClass="styled" runat="server" />
        </div>
        <div class="bottom">
            <asp:Button class="button" ID="changeRank" runat="server" />&nbsp;<asp:Button class="button" ID="kickPlayer" runat="server" />
        </div>
    </div>
            
    
</asp:Content>
