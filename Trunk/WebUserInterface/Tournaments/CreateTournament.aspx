<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CreateTournament.aspx.cs"
    Inherits="OrionsBelt.WebUserInterface.CreateTournament" MasterPageFile="~/OrionsBeltTournament.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1>
        <OrionsBelt:Label Key="CreateTournament" runat="server" />
    </h1>
    <table class="data">
        <tr>
            <td>
                <OrionsBelt:Label Key="TournamentName" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox ID="tournamentName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="TournamentType" runat="server" />
                :
            </td>
            <td>
                <asp:DropDownList ID="tournamentType" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="Prize" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox ID="prize" runat="server" TextMode="MultiLine" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="Credits" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox ID="credits" runat="server" />
                <asp:RegularExpressionValidator ControlToValidate="credits" Display="Dynamic" ID="creditsValidator"
                    ValidationExpression="^\d+" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="IsPublic" runat="server" />
                :
            </td>
            <td>
                <asp:CheckBox Checked="true" ID="isPublic" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="IsSurvival" runat="server" />
                :
            </td>
            <td>
                <asp:CheckBox ID="isSurvival" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="TurnTime" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox ID="turnTime" runat="server" />
                <OrionsBelt:Label Key="Hours" runat="server" />
                <asp:RegularExpressionValidator ControlToValidate="turnTime" Display="Dynamic" ID="turnTimeValidator"
                    ValidationExpression="^\d+" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="RegistTime" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox ID="registTime" runat="server" />
                <OrionsBelt:Label Key="Days" runat="server" />
                <asp:RegularExpressionValidator ControlToValidate="registTime" Display="Dynamic"
                    ID="registTimeValidator" ValidationExpression="^\d+" runat="server" />
                <br />
                <OrionsBelt:Label Key="ZeroMessage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="RegistPlayers" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox ID="registPlayers" runat="server" />
                <asp:RegularExpressionValidator ControlToValidate="registPlayers" Display="Dynamic"
                    ID="registPlayersValidator" ValidationExpression="^\d+" runat="server" />
                <br />
                <OrionsBelt:Label Key="ZeroMessage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="MinRegistPlayers" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox ID="minRegistPlayers" runat="server" />
                <asp:RegularExpressionValidator ControlToValidate="minRegistPlayers" Display="Dynamic"
                    ID="registMinPlayersValidator" ValidationExpression="^\d+" runat="server" />
                 <asp:CustomValidator ControlToValidate="minRegistPlayers" Display="Dynamic" 
                 OnServerValidate="ValidateMinMax" ValidateEmptyText="false" ID="minMaxValidator" runat="server" />
                <br />
                <OrionsBelt:Label Key="ZeroMessage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="MaxElo" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox ID="maxElo" runat="server" />
                <asp:RegularExpressionValidator ControlToValidate="maxElo" Display="Dynamic" ID="maxEloValidator"
                    ValidationExpression="^\d+" runat="server" />
                <br />
                <OrionsBelt:Label Key="ZeroMessage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label  Key="MinElo" runat="server" />:
            </td>
            <td>
                <asp:TextBox ID="minElo" runat="server" />
                <asp:RegularExpressionValidator ControlToValidate="minElo" Display="Dynamic" ID="minEloValidator"
                    ValidationExpression="^\d+" runat="server" />
                <br />
                <OrionsBelt:Label Key="ZeroMessage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <OrionsBelt:Label Key="PlayoffNum" runat="server" />
                :
            </td>
            <td>
                <asp:TextBox Text="32" ID="playoffNum" runat="server" />
                <asp:RegularExpressionValidator ControlToValidate="playoffNum" Display="Dynamic"
                    ID="playoffNumValidator" ValidationExpression="^\d+" runat="server" />
                <asp:CustomValidator ControlToValidate="playoffNum" Display="Dynamic" 
                    OnServerValidate="ValidateQuantity" ValidateEmptyText="true" ID="invalidQuantity" runat="server" />
                <br />
                <OrionsBelt:Label Key="Default32" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <OrionsBelt:Label Key="Instructions" runat="server" />
    <br />
    <OrionsBeltUI:DisplayUnits ID="displayUnits" runat="server" />
    <p>
        <input type="submit" causesvalidation="true" id="create" runat="server" />
    </p>
</asp:Content>
