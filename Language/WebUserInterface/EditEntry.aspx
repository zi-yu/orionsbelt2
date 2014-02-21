<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Main.Master" Inherits="Language.WebUserInterface.EditEntry" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <a name="translation" id="translation"></a>
    <h1><asp:Literal ID="title" runat="server" /></h1>
    
    <asp:Literal ID="message" EnableViewState="false" runat="server" />
    <asp:Literal ID="errors" EnableViewState="false" Visible="false" runat="server">
        <div class="red">
            <h3>Token Update Failed - There are errors on the Translation!</h3>
            <hr />
            The text is invalid XML, this usually happens on some browsers that don't copy exactly what we have on 
            the other tokens. But it's very easy to fix. For example, if you have:<br />
            &lt;img src="..."&gt;, you should fix it to &lt;img src="..." <u>/</u>&gt;<br />
            Another case may be having &lt;br&gt; that should be fixed to &lt;br<u>/</u>&gt;
            <p />
            If you have any questions, save the content elsewhere and contact us.
        </div>
    </asp:Literal>
    
    <Language:LanguageEntryItem Source="items" runat="server">
        <h2>Entry <u><Language:LanguageEntryName runat="server" /></u></h2>
    </Language:LanguageEntryItem>
    
    <Language:LanguageTranslationEditor ID="entryEditor" runat="server">
        <LanguageUI:LanguageTranslationTextEditor ID="textEditor" runat="server" />
        <br />
        <Language:UpdateButton ID="updateButton" runat="server" />
        <Language:UpdateButton ID="updateAndContinueButton" Text="Update and continue to next token" runat="server" />
    </Language:LanguageTranslationEditor>
    
    <h1>Other Translations</h1>
    
    <Language:LanguageTranslationList ID="otherLanguagesList" runat="server">
        <Language:LanguageTranslationItem runat="server">
            <h2>Language <u><Language:LanguageTranslationLocale runat="server" /></u> <LanguageUI:LanguageTranslationCopy runat="server" /></h2>
            <LanguageUI:LanguageTranslationText runat="server" />
        </Language:LanguageTranslationItem>
    </Language:LanguageTranslationList>


</asp:Content>
