<%@ Page Language="C#" MasterPageFile="~/Main.Master" Inherits="Language.WebUserInterface.Register" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <asp:CreateUserWizard ContinueDestinationPageUrl="Login.aspx"  runat="server" />
    
</asp:Content>
