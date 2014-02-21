<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Team.aspx.cs" Inherits="OrionsBelt.WebUserInterface.Team"
    MasterPageFile="~/OrionsBeltTournament.Master" %>
<%@ Register TagPrefix="Team" TagName="Create" Src="~/Controls/Tournament/CreateTeam.ascx" %>
<%@ Register TagPrefix="Team" TagName="Invite" Src="~/Controls/Tournament/InviteTeammate.ascx" %>
<%@ Register TagPrefix="Team" TagName="View" Src="~/Controls/Tournament/ViewTeam.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsbeltUI:TeamLadderMenu runat="server"></OrionsbeltUI:TeamLadderMenu>
    
    <Team:Create ID="create" runat="server" />
    <Team:Invite ID="invite" runat="server" />
    <Team:View ID="view" runat="server" />
</asp:Content>
