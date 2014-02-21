<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Alliance/Alliance.Master" Inherits="OrionsBelt.WebUserInterface.Alliance.List" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <OrionsBelt:AllianceStoragePagedList ID="AllianceStoragePagedList1" ItemsPerPage="50" runat="server">
        <OrionsBelt:AllianceStorageNumberPagination ID="AllianceStorageNumberPagination1" ItemsPerPage="50" runat="server"></OrionsBelt:AllianceStorageNumberPagination>
        <div class='bigBorder'>
            <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="EmpireMessages" runat="server" /></h2></div>
            <div class='center'>
                
                <table class="newtable">
                    <tr>
                        <th><OrionsBelt:Label ID="Label1" Key="AllianceName" runat="server" /></th>
                    </tr>
                    <OrionsBelt:AllianceStorageItem runat="server">
                        <tr>
                            <td><OrionsBeltUI:AllianceLink runat="server" /></td>
                        </tr>
                    </OrionsBelt:AllianceStorageItem>
                </table>
            </div>
            <div class='bottom'></div>
        </div>
        <OrionsBelt:AllianceStorageNumberPagination ID="AllianceStorageNumberPagination3" ItemsPerPage="50" runat="server"></OrionsBelt:AllianceStorageNumberPagination>
    </OrionsBelt:AllianceStoragePagedList>
</asp:Content>
