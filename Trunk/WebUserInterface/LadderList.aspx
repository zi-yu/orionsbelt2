<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="LadderList.aspx.cs" Inherits="OrionsBelt.WebUserInterface.LadderList" MasterPageFile="~/OrionsBeltTournament.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class='pagination'>
        <asp:Literal ID="pagination" runat="server" />
    </div>
	<div id='ladderList' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="Ladder" runat="server" /></h2></div>
        <div class='center'>
	        <OrionsBelt:PrincipalPagedList Where="LadderActive=True" OrderBy="LadderPosition" ItemsPerPage="55" ID="paged" runat="server" >
	       
	        <table class="newtable">
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="PrincipalName" runat="server" /></th>
		            <th>ELO</th>
			        <th><OrionsBelt:Label Key="IsInBattle" runat="server" /></th>
			        <th><OrionsBelt:Label Key="IsResting" runat="server" /></th>
			        <th style='width:160px'></th>
		        </tr>
		        <OrionsBelt:PrincipalItem runat="server">
		        <tr <OrionsBeltUI:PrincipalYou runat="server" />>
		            <td><OrionsBeltUI:Position runat="server" /></td>
		            <td><OrionsBeltUI:PrincipalLinkAndAvatar ID="PrincipalLinkAndAvatar1" runat="server" /></td>
		            <td><OrionsBelt:PrincipalEloRanking runat="server" /></td>
			        <td><OrionsBeltUI:IsInBattle runat="server" /></td>
			        <td><OrionsBeltUI:IsResting runat="server" /></td>
			        <td><OrionsBeltUI:Challenge runat="server" /></td>
		        </tr>
		        </OrionsBelt:PrincipalItem>
	        </table>
	        </OrionsBelt:PrincipalPagedList>
        </div>
        <div class='bottom'></div>
    </div>
    <div class='pagination'>
        <asp:Literal ID="pagination1" runat="server" />
    </div>
</asp:Content>