<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.Default" MasterPageFile="~/OrionsBeltUniverse.Master" %>
<%@ Register TagPrefix="AH" TagName="Advertising" Src="~/Controls/Market/Advertising.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <OrionsBeltUI:WarningMessage runat="server" />
    <OrionsBeltUI:GlobalMessages id="globalMessages" runat="server" />
    
    
    <OrionsBeltUI:EmpireMessages runat="server"></OrionsBeltUI:EmpireMessages>
    <OrionsBeltUI:PrivateBoardViewerPreview ID="board" ReceiverType="Alliance" runat="server" />
    
    <div class="clear"></div>
	
	<OrionsBeltUI:BlogPreview ID="BlogPreview1" runat="server" />
	
	<OrionsBeltUI:AHAdvertising ID="Advertising1" runat="server" />
	
</asp:Content>
