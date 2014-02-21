<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewTeam.ascx.cs" Inherits="OrionsBelt.WebUserInterface.Controls.Tournament.ViewTeam" %>

<div id='teamEloStats' class='normalBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="TournamentStats" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBeltUI:TeamELOStats ID="eloStats" runat="server" />
    </div>
    <div class='bottom'></div>
</div>


<div id='teamPlayers' class='smallBorder'>
    <div class='top'><h2><asp:Literal ID="title" runat="server" /></h2></div>
    <div class='center'>
        <asp:Literal ID="players" runat="server" />
    </div>
    <div class='bottom'><asp:Literal ID="abandon" runat="server" /></div>
</div>

<div id='teamChart' class='smallBorder'>
    <div class='top'><h2><asp:Literal ID="Literal1" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBeltUI:TeamInfoReader ID="reader" runat="server" />
    </div>
    <div class='bottom'><asp:Literal ID="Literal2" runat="server" /></div>
</div>




