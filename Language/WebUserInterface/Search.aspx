<%@ Page Language="C#" MasterPageFile="~/Main.Master" Inherits="Language.WebUserInterface.Search" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <h1>Search</h1>
    
    <asp:TextBox ID="searchToken" runat="server" />
    <asp:Button ID="doSearch" Text="Search" runat="server" />
    
    <h2>Results</h2>
    
    <Language:LanguageEntryList ID="entryList" runat="server">
        <asp:Literal ID="title" runat="server" />
        <table class="table">
            <tr>
                <th>Token</th>
                <th>Content Preview</th>
                <th>Actions</th>
            </tr>
            <Language:LanguageEntryItem ID="LanguageEntryItem1" runat="server">
                <tr>
                    <td><LanguageUI:LanguageEntryName ID="LanguageEntryName1" runat="server" /></td>
                    <td><LanguageUI:LanguageEntryLocalePreview ID="LanguageEntryLocalePreview1" runat="server" /></td>
                    <td><LanguageUI:LanguageEntryActions ID="LanguageEntryActions1" runat="server" /></td>
                </tr>
            </Language:LanguageEntryItem>
        </table>
    </Language:LanguageEntryList>
    
</asp:Content>
