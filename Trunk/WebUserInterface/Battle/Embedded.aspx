<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.Battles.Embedded" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Orion's Belt Battle</title>
    <OrionsBeltUI:Style id='styleRegister' runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <OrionsBeltUI:BattleRenderer ID="battle" Embedded="true" runat="server"></OrionsBeltUI:BattleRenderer>
    </form>
    <OrionsBeltUI:Script id='scriptRegister' runat="server" />
</body>
</html>
