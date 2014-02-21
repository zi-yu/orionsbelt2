<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.PlayerResource" 
MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <h1><OrionsBelt:Label Key="PlayerResource" runat="server" />:</h1>
    <br />
	
	<OrionsBeltUI:ResourcesStats runat="server" />



</asp:Content>