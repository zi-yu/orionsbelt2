<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.Ticker" MasterPageFile="~/OrionsBeltMaster.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <h1><OrionsBelt:Label Key="Ticker" runat="server" /></h1>
	<ul id="ticker">
	</ul>
	<div id="tickerPlaceHolder" style="display:none;"></div>

</asp:Content>
