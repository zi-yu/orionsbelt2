<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Alliance.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.AlliancePage" MasterPageFile="~/Tops/Tops.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="TopByAlliance" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Name" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Score" runat="server" /></th>
		            <th><OrionsBelt:Label Key="MembersNum" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Planets" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Relics" runat="server" /> / <OrionsBelt:Label Key="Income" runat="server" /></th>
		        </tr>
                <asp:Literal ID="allianceRank" runat="server" />
	        </table>
        </div>
        <div class='bottom'></div>
    </div>
</asp:Content>