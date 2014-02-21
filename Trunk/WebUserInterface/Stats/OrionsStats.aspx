<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.OrionsStats" 
MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <h1><OrionsBelt:Label Key="OrionsStats" runat="server" />:</h1>
    <br />
	
	<asp:Literal ID="graphics" runat="server" />



</asp:Content>