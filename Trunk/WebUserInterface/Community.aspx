<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Community.aspx.cs" Inherits="OrionsBelt.WebUserInterface.Community" MasterPageFile="~/OrionsBeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBeltUI:CommunityRender runat="server"/>

    <div id='socialNetworks'>
    <h2><OrionsBelt:Label Key="SocialConnect" runat="server" /></h2>
    <ul>
        <li><a href="http://twitter.com/orionsbelt"><div class='twitter'></div></a></li>
        <li><a href="http://www.facebook.com/people/Orions-Belt/1494290881"><div class='facebook'></div></a></li>
        <li><a href="http://orionsbelt-game.hi5.com"><div class='hi5'></div></a></li>
        <li><a href="http://technorati.com/blogs/blog.orionsbelt.eu?reactions"><div class='technorati'></div></a></li>
        <li><a href="http://www.linkedin.com/groups?gid=100018"><div class='linkedin'></div></a></li>
    </ul>
    </div>
   
</asp:Content>



