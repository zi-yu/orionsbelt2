<%@ Page Language="C#" MasterPageFile="~/Main.Master" Inherits="Language.WebUserInterface.Default" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <Language:LanguageProjectList runat="server">
    
        <table class="table">
            <tr>
                <th>Project</th>
            </tr>
            <Language:LanguageProjectItem runat="server">
                <tr>
                    <td><LanguageUI:LanguageProjectLink runat="server" /></td>
                </tr>
            </Language:LanguageProjectItem>
        </table>
    
    </Language:LanguageProjectList>
    
    <h1>Project <u>Game</u> Statistics</h1>
    <LanguageUI:LanguageStats ReportFile="Game.html" runat="server" />
    
    <h1>Project <u>Institutional</u> Statistics</h1>
    <LanguageUI:LanguageStats ReportFile="Institutional.html" runat="server" />

</asp:Content>

