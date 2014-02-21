<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="XLPartyTournaments.ascx.cs" Inherits="OrionsBelt.WebUserInterface.Controls.Tournament.XLPartyTournaments" %>

    <OrionsBelt:TournamentPagedList ID="TournamentPagedList1" ItemsPerPage="50" runat="server" Where="CreatedDate = StartTime and Token = 'XLPartyTournament'">
            <OrionsBelt:TournamentItem ID="TournamentItem1" runat="server">
                <tr>
                    <td>
                        <OrionsBeltUI:TournamentNameRender ID="TournamentNameRender1" runat="server" />
                    </td>
                    <td>
                        <OrionsBeltUI:TournamentTypeRender ID="TournamentTypeRender1" runat="server" />
                    </td>
                    <td>
                        <OrionsBelt:TournamentPrize ID="TournamentPrize1" runat="server" />
                    </td>
                    <td>
                        <OrionsBelt:TournamentCostCredits ID="TournamentCostCredits1" runat="server" />
                    </td>
                    <td>
                        <OrionsBeltUI:SubscriptionTimeRender ID="SubscriptionTimeRender1" runat="server" />
                    </td>
                    <td>
                        <OrionsBeltUI:NPlayersRender ID="NPlayersRender1" runat="server" />
                    </td>
                    <td>
                        <OrionsBeltUI:MaxEloRender ID="MaxEloRender1" runat="server" />
                    </td>
                    <td>
                        <OrionsBeltUI:MinEloRender ID="MinEloRender1" runat="server" />
                    </td>
                    <td>
                        <OrionsBeltUI:MakeRegist ID="MakeRegist1" runat="server" />
                    </td>
                </tr>
            </OrionsBelt:TournamentItem>
    </OrionsBelt:TournamentPagedList>