<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrivateBoardSender.ascx.cs" Inherits="OrionsBelt.WebUserInterface.Controls.Generic.PrivateBoardSender" %>

<OrionsBelt:PrivateBoardEditor ID="pbEditor" Source="New" runat="server">

    <div class="messageBoardInput">
        <OrionsBelt:PrivateBoardMessageEditor IsMultiline="true" CssClass="messageBoardInput" runat="server" />
    </div>
    <OrionsBeltUI:PrivateBoardDefaultsEditor ID="defaults" Visible="false" runat="server" />
    <OrionsBelt:UpdateButton ID="updateButton" CssClass="button" runat="server" />
    

</OrionsBelt:PrivateBoardEditor>