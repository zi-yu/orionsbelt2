<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Quests/Quests.Master" Inherits="OrionsBelt.WebUserInterface.Quests.CreateBountyPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <asp:Literal ID="message" EnableViewState="false" runat="server" />

    <div id='createBountyMessage' class='bigBorderFlat'>
        <div class='top'></div>
        <div class='center'><asp:Literal ID="info" runat="server" /></div>
        <div class='bottom'></div>
    </div>
    
    <div id='createBountySearch'>
        <OrionsBeltUI:ChooseOpponent ID="targetChoice" TitleToken="SelectTarget" SearchPlayers="True" runat="server" /></tr>
    </div>
    
    <div id='createBounty' class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label5" Key="CreateBounty" runat="server" /></h2></div>
        <div class='center'>
            <table class="newtable">
                <tr>
                    <td><OrionsBelt:Label ID="Label3" Key="PointsToTake" runat="server" /></td>
                    <td>
                        <asp:DropDownList ID="pointsToTake" CssClass="styled" runat="server">
                            <asp:ListItem Text="" />
                            <asp:ListItem Text="100" />
                            <asp:ListItem Text="500" />
                            <asp:ListItem Text="1000" />
                            <asp:ListItem Text="2500" />
                            <asp:ListItem Text="7500" />
                            <asp:ListItem Text="12000" />
                            <asp:ListItem Text="20000" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><OrionsBelt:Label ID="Label4" Key="OrionsToGive" runat="server" /></td>
                    <td>
                        <asp:DropDownList ID="orionsToGive"  CssClass="styled" runat="server">
                            <asp:ListItem Text="" />
                            <asp:ListItem Text="50" />
                            <asp:ListItem Text="100" />
                            <asp:ListItem Text="250" />
                            <asp:ListItem Text="500" />
                            <asp:ListItem Text="750" />
                            <asp:ListItem Text="1000" />
                            <asp:ListItem Text="1500" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div class='bottom'><asp:Button CssClass="button" ID="create" runat="server" /></div>
    </div>
</asp:Content>
