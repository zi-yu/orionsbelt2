<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.ManageDiplomacy" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
     <div id="allianceDiplomacyManage" class='mediumBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="AllianceManageDiplomacyTitle" runat="server"></OrionsBelt:Label></h2></div>
        <div class='center'>
            <div>
                <asp:Literal ID="currentStatus" runat="server" />
            </div>
            
            <OrionsBeltUI:InteractionsControl ID="interactions" runat="server" />
            <br />
         </div>
         <div class="bottom">   
            <asp:PlaceHolder ID="options" runat="server">
                <div>
                    <ul>
                        <li><asp:Button CssClass="button" ID="declareWar" runat="server" /></li>
                        <li><asp:Button CssClass="button" ID="endWar" runat="server" /></li>
                        <li><asp:Button CssClass="button" ID="ofterConfederation" runat="server" /></li>
                        <li><asp:Button CssClass="button" ID="ofterNonAggressionPact" runat="server" /></li>
                        <li><asp:Button CssClass="button" ID="setNeutral" runat="server" /></li>
                    </ul>
                </div>
            </asp:PlaceHolder>
          </div>
    </div>
</asp:Content>
