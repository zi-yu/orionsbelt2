<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InviteTeammate.ascx.cs" Inherits="OrionsBelt.WebUserInterface.Controls.Tournament.InviteTeammate" %>


<div id='sentInvitations' class='normalBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="SentInvitations" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBelt:InteractionPagedList ID="list" ItemsPerPage="50" runat="server">
            <table class="newtable">
                <tr>
                    <th><OrionsBelt:Label ID="Label2" Key="Receiver" runat="server" /></th>
                    <th><OrionsBelt:Label ID="Label3" Key="State" runat="server" /></th>
                    <th><OrionsBelt:Label ID="Label4" Key="Delete" runat="server" /></th>
                </tr>
                <OrionsBelt:InteractionItem ID="TournamentItem1" runat="server">
                    <tr>
                        <td><OrionsBeltUI:InteractionReceiver ID="InteractionReceiver1"  runat="server" /></td>
                        <td><OrionsBeltUI:InteractionState ID="InteractionState1"  runat="server" /></td>
                        <td><OrionsBeltUI:InteractionRemove ID="delete"  runat="server" /></td>
                    </tr>
                </OrionsBelt:InteractionItem>
            </table>
        </OrionsBelt:InteractionPagedList>
    </div>
    <div class='bottom'></div>
</div>

<OrionsBeltUI:ChooseOpponent ID="targetChoice" TitleToken="TeamMate" HtmlId="chooseTeamMate" runat="server" />

<div id='inviteTeamMate' class='smallBorder'>
    <div class='top'><h2><asp:Literal ID="title" runat="server" /></h2></div>
    <div class='bottom'>
        <asp:Button id="invite" OnClick="Invite" CssClass="button" runat="server" />
    </div>
</div>




