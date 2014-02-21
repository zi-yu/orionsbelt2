<%@ Page Language="C#" MasterPageFile="~/Main.Master" Inherits="Language.WebUserInterface.Project" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <Language:LanguageFileList ID="fileList" runat="server">
    
        <h1><asp:Literal ID="title" runat="server" /></h1>
        <table class="table">
            <tr>
                <th>File</th>
                <LanguageUI:LanguageFileFlags runat="server" />
                <th>Tokens</th>
            </tr>
            <Language:LanguageFileItem runat="server">
                <tr>
                    <td><LanguageUI:LanguageFileLink runat="server" /></td>
                    <LanguageUI:LanguageFileTokensPerFlag runat="server" />
                    <td><LanguageUI:LanguageFileTokens runat="server" /></td>
                </tr>
            </Language:LanguageFileItem>
        </table>
    
    </Language:LanguageFileList>

</asp:Content>
