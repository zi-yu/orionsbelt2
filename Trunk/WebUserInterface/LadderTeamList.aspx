<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LadderTeamList.aspx.cs" Inherits="OrionsBelt.WebUserInterface.LadderTeamList" MasterPageFile="~/OrionsBeltTournament.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsbeltUI:TeamLadderMenu ID="TeamLadderMenu1" runat="server"></OrionsbeltUI:TeamLadderMenu>

    <div class='pagination'>
        <asp:Literal ID="pagination" runat="server" />
    </div>
    
    <div id='ladderList' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="LadderTeam" runat="server" /></h2></div>
        <div class='center'>
	        <OrionsBelt:TeamStoragePagedList Where="LadderActive=True and IsComplete=True" OrderBy="LadderPosition" ItemsPerPage="55" ID="paged" runat="server" >
	        <table class="newtable">
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="TeamName" runat="server" /></th>
		            <th>ELO</th>
			        <th><OrionsBelt:Label Key="IsInBattle" runat="server" /></th>
			        <th><OrionsBelt:Label Key="IsResting" runat="server" /></th>
			        <th style="width:160px"><OrionsBelt:Label Key="Challenge" runat="server" /></th>
		        </tr>
		        <OrionsBelt:TeamStorageItem runat="server">
		        <tr <OrionsBeltUI:TeamYours runat="server"/>>
		            <td><OrionsBeltUI:TeamPosition runat="server" /></td>
		            <td><OrionsBeltUI:TeamLinkedName runat="server" /></td>
		            <td><OrionsBelt:TeamStorageEloRanking runat="server" /></td>
			        <td><OrionsBeltUI:TeamIsInBattle runat="server" /></td>
			        <td><OrionsBeltUI:TeamIsResting runat="server" /></td>
			        <td><OrionsBeltUI:ChallengeTeam runat="server" /></td>
		        </tr>
		        </OrionsBelt:TeamStorageItem>
	        </table>
	        </OrionsBelt:TeamStoragePagedList>
	    </div>
        <div class='bottom'></div>
    </div>
    <div class='pagination'>
        <asp:Literal ID="pagination1" runat="server" />
    </div>

	
</asp:Content>