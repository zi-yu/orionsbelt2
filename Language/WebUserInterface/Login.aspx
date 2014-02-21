<%@ Page Language="C#" MasterPageFile="~/Main.Master" Inherits="Language.WebUserInterface.Login" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <Language:RoleVisible Role="user" runat="server">
        <asp:LoginStatus runat="server" />
    </Language:RoleVisible>
    <Language:RoleVisible Role="guest" runat="server">
        <Language:Login runat="server">
            <LayoutTemplate>
                <div id="loginLayout">
                    <div>
                        <div class="name">
                            <Language:Label Key="UserName" runat="server" />
                        </div>
                        <asp:TextBox ID="UserName" CssClass="username" runat="server">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            ErrorMessage="*" ToolTip="Required" ValidationGroup="login">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <div class="name">
                            <Language:Label Key="Password" runat="server" />
                        </div>
                        <asp:TextBox ID="Password" CssClass="password" runat="server" TextMode="Password">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            ErrorMessage="*" ToolTip="Required" ValidationGroup="login">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                    </div>
                    <div class="loginButton">
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="login" />
                    </div>
                    <div>
                        <asp:Label ID="error" runat="server" />
                    </div>
                </div>
            </LayoutTemplate>
        </Language:Login>
    </Language:RoleVisible>
</asp:Content>
