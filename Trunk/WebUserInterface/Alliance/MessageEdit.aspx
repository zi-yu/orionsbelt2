<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master"
    Inherits="OrionsBelt.WebUserInterface.Alliance.MessageEdit" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:PrivateBoardEditor runat="server" Source="QueryString" >

        <table class="table">
            <tr>
                <td>
                    <div class="messageBoardInput">
                        <OrionsBelt:PrivateBoardMessageEditor runat="server" />
                    </div>
                </td>
            </tr>
        </table>
        <Orionsbelt:UpdateButton ID="update" CssClass="button" runat="server" />
    </OrionsBelt:PrivateBoardEditor>
</asp:Content>
