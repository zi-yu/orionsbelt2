<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CreateArena.aspx.cs"
    Inherits="OrionsBelt.WebUserInterface.CreateArena" MasterPageFile="~/Arenas/Arena.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <asp:Literal ID="message" runat="server" />

    <div id='arenaCreate' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="CreateArena" runat="server" /></h2></div>
        <div class='center'> 
            <dl>
                <dt>
                    <OrionsBelt:Label Key="ArenaName" runat="server" />:
                </dt>
                <dd>
                    <asp:TextBox ID="arenaName" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="arenaName"
                    ID="arenaNameRequired" runat="server" />
                </dd>
                <dt>
                    <OrionsBelt:Label Key="BattleType" runat="server" />:
                </dt>
                <dd>
                    <asp:DropDownList ID="arenaType" runat="server" />
                </dd>
            
                <dt>
                    <OrionsBelt:Label Key="ChampionPrize" runat="server" />:
                </dt>
                <dd>
                    <asp:TextBox ID="prize" MaxLength="5" Width="50" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="prize"
                    ID="prizeRequired" runat="server" />
                    <asp:RegularExpressionValidator ControlToValidate="prize" Display="Dynamic" ID="prizeValidator"
                        ValidationExpression="^\d+" runat="server" />
                </dd>
                <dt>
                    <OrionsBelt:Label Key="Level" runat="server" />:
                </dt>
                <dd>
                    <asp:TextBox ID="level" MaxLength="1" Width="20" runat="server" />
                    <asp:RangeValidator ControlToValidate="level" Display="Dynamic" ID="levelRange" MaximumValue="6" MinimumValue="1"
                     runat="server" Type="Integer" />
                </dd>
                <dt>
                    <OrionsBelt:Label Key="Coordinates" runat="server" />:
                </dt>
                <dd>
                    <asp:TextBox ID="sysX" MaxLength="2" Width="20" runat="server" /> : <asp:TextBox ID="sysY" MaxLength="2" Width="20" runat="server" /> : <asp:TextBox ID="secX" MaxLength="1" Width="20" runat="server" /> : <asp:TextBox ID="secY" MaxLength="2" Width="20" runat="server" />
                </dd>
            </dl>
            </div>
            <div class='bottom'>
                <p><asp:CustomValidator ControlToValidate="sysX" Display="Dynamic" 
                            OnServerValidate="ValidateAnyEmpty" ValidateEmptyText="true" ID="coordinatesCustom" runat="server" /></p>
                <p><asp:RangeValidator ControlToValidate="sysX" Display="Dynamic" ID="sysXRange" MaximumValue="37" MinimumValue="1"
                 runat="server" Type="Integer" /></p>
                 <p><asp:RangeValidator ControlToValidate="sysY" Display="Dynamic" ID="sysYRange" MaximumValue="37" MinimumValue="1"
                 runat="server" Type="Integer" /></p>
                 <p><asp:RangeValidator ControlToValidate="secX" Display="Dynamic" ID="secXRange" MaximumValue="7" MinimumValue="1"
                 runat="server" Type="Integer" /></p>
                 <p><asp:RangeValidator ControlToValidate="secY" Display="Dynamic" ID="secYRange" MaximumValue="10" MinimumValue="1"
                 runat="server" Type="Integer" /></p>
            </div>
    </div>
    <div id='arenaCreateArena' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="CreateArena" runat="server" /></h2></div>
        <div class='center'> 
            <OrionsBeltUI:DisplayUnits ID="displayUnits" runat="server" />
        </div>
        <div class='bottom'>
            <input type="submit" class="button" causesvalidation="true" id="create" runat="server" />
        </div>
    </div>
</asp:Content>
