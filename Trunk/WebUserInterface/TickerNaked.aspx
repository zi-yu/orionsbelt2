<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.TickerNaked" %>

<html>
<head>
    <title>Orion's Belt Free Browser Game</title>
    <OrionsBeltUI:Style ID='styleRegister' runat="server" />
</head>
<body style="background-image: none;">
    <form id="form" runat="server">
        <ul id="ticker">
        </ul>
        <div id="tickerPlaceHolder" style="display: none;">
        </div>
        <OrionsBeltUI:Script ID='scriptRegister' runat="server" />

        <script type="text/javascript">
		var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
		document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
        </script>

        <script type="text/javascript">
		var pageTracker = _gat._getTracker("UA-681136-30");
		pageTracker._trackPageview();
        </script>

    </form>
</body>
</html>
