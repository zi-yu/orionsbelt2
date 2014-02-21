<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.PlayerUnit" 
MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <h1><OrionsBelt:Label Key="PlayerUnit" runat="server" />:</h1>
    <br />
	
	<OrionsBeltUI:UnitsPerPlayer runat="server" />



</asp:Content>