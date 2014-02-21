<%@ Page Language="C#" EnableViewState="false" EnableEventValidation="false" AutoEventWireup="false" Inherits="Institutional.WebUserInterface.Default" MasterPageFile="~/MainMasterMainPage.Master" %>
<asp:Content ContentPlaceHolderID="content" runat="server">   
    <div id='top'>
        <div id='logo'>
            <h1 style="margin-top:130px;">
                <Institutional:Label Key="TagLine" runat="server" />
            </h1>
            <h2>
                <InstitutionalUI:PlayNow Key="RegisterHere" ID="PlayNow2" runat="server" />
            </h2>
        </div>
        <div id='loginArea'>
            <div id='loginBox'>
                <div class='adjust'>
                    <form id="form" action="Default.aspx">
                        <InstitutionalUI:GameLogin runat="server" />
                    </form>
                </div>
            </div>
        </div>
    </div>
    
    <div id='middle'>
        <div id='bigDialog'>
            <div id='bigDialogTop'>
                <div>
                    <h1>Orion's Belt : <Institutional:Label ID="Label2" Key="ScreenShots" runat="server" /></h1>
                    <a href="ScreenShots.aspx">
                        <img src="http://resources.orionsbelt.eu/Institutional/Images/ScreenShots.jpg" />
                    </a>
                </div>
            </div>
            <div id='bigDialogMiddle'>
                <Institutional:Label ID="Label1" Key="FrontPageContent" runat="server" />

                <h1>Orion's Belt : <Institutional:Label ID="Label5" Key="Universe" runat="server" /></h1>
                <Institutional:Label ID="Label6" Key="AboutUniverse" runat="server" />
                <p />
                <a href="ScreenShots.aspx"><img src="http://resources.orionsbelt.eu/Institutional/Images/UniverseSample.jpg" /></a>
                
                <h1>Orion's Belt : <Institutional:Label ID="Label3" Key="Battles" runat="server" /></h1>
                <Institutional:Label ID="Label4" Key="AboutBattles" runat="server" />
                <p />
                <a href="ScreenShots.aspx"><img src="http://resources.orionsbelt.eu/Institutional/Images/BattleSample.gif" /></a>
            </div>
            <div id='bigDialogBottom'>
                <div class='playNowFooter'>
                    <InstitutionalUI:PlayNow ID="PlayNow1" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>