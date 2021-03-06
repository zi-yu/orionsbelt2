﻿<%@ Page Language="C#" Inherits="OrionsBelt.WebAdmin.Admin.Default" MasterPageFile="~/Admin/adminMaster.master" %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Aplication Status</h2>
	
	<p><asp:Label id="appState" runat=server /></p>
	<asp:LinkButton id="toggleStatus" onclick="ToggleApplicationStatus" runat="server" />
	
	<h2>Application Evolution</h2>
	<div class="appEvolution">
	    <Admin:ApplicationEvolution runat="server" />
	</div>

</asp:Content>