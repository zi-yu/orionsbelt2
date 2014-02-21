<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateTeam.ascx.cs" Inherits="OrionsBelt.WebUserInterface.Controls.Tournament.CreateTeam" %>

<div id='createTeam' class='normalBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="CreateTeam" runat="server" /></h2></div>
    <div class='center'>
        <dl>
            <dt><OrionsBelt:Label ID="Label2" Key="TeamName" runat="server" /></dt>
            <dd>
                <asp:TextBox ID="name" runat="server" />                            
                <asp:RequiredFieldValidator ID="teamNameValidator" ControlToValidate="name" Display="Dynamic" runat="server" />
            </dd>
        </dl>
    </div>
    <div class='bottom'>
        <asp:Button id="create" OnClick="Create" CssClass="button" runat="server" />
    </div>
</div>   
            