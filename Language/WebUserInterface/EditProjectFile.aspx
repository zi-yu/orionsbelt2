<%@ Page Language="C#" MasterPageFile="~/Main.Master" Inherits="Language.WebUserInterface.EditProjectFile" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <Language:LanguageEntryList ID="entryList" runat="server">
        <asp:Literal ID="title" runat="server" />
        <table class="table">
            <tr>
                <th>Token</th>
                <th>Content Preview</th>
                <th>Actions</th>
            </tr>
            <Language:LanguageEntryItem runat="server">
                <tr>
                    <td><LanguageUI:LanguageEntryName runat="server" /></td>
                    <td><LanguageUI:LanguageEntryLocalePreview runat="server" /></td>
                    <td><LanguageUI:LanguageEntryActions runat="server" /></td>
                </tr>
            </Language:LanguageEntryItem>
        </table>
    </Language:LanguageEntryList>

</asp:Content>
