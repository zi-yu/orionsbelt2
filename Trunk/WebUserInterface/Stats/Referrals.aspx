<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.ReferralsPage" 
MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <h1>Referrals</h1>
    
    <div style="float:left;width:400px;">
        <asp:Literal ID="referrals" runat="server" />
    </div>
    
    <div style="float:left;width:200px;">
        <asp:Literal ID="campaigns" runat="server" />
    </div>
    
    <div style="float:left;right:-100px; position:relative;">
        <asp:Literal ID="lastDay" runat="server" />
    </div>

</asp:Content>