<%@ Page Language="C#" Inherits="OrionsBelt.WebUserInterface.UniverseControl" MasterPageFile="~/OrionsBeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
	<OrionsBeltUI:UniverseRenderer runat="server" />
	<br />
	<OrionsBelt:RoleVisible Role="gameMaster" runat="server">
	    <h1 class="subMenu">
            <a href="Arenas/Arena.aspx">
                <OrionsBelt:Label Key="Arenas" runat="server" />
            </a>
        </h1>
        <h1 class="subMenu">
            <a href="Markets.aspx">
                <OrionsBelt:Label Key="Markets" runat="server" />
            </a>
        </h1>
    </OrionsBelt:RoleVisible>
</asp:Content>


