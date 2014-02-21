<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VotePage.aspx.cs" Inherits="OrionsBelt.WebUserInterface.VotePage" MasterPageFile="~/OrionsBeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
        <h1><OrionsBelt:Label Key="VoteForOrionsBelt" runat="server" /></h1>
        <div class='votingMessage'><asp:Panel ID='voteMessage' runat="server"></asp:Panel></div>
        <OrionsBeltUI:VoteControl runat="server"/>
</asp:Content>
