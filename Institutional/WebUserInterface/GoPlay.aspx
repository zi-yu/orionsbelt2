<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="GoPlay.aspx.cs" Inherits="WebUserInterface.GoPlay" %>

<html >
<head>
    <title>Orion's Belt</title>
    <link rel='shortcut icon' href='http://resources.orionsbelt.eu/Images/Common/favicon.ico' />
    <script type="text/javascript"> 
    var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
    document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script> 
    <script type="text/javascript"> 
    try {
    var pageTracker = _gat._getTracker("UA-681136-5");
    pageTracker._trackPageview();
    } catch(err) {}</script> 
    
    <script type="text/javascript">
        window.location = "<%= Institutional.WebUserInterface.Controls.WebUtilities.GetPlayUrl() %>";
    </script>
</head>
<body>
    Redirecting to <a href="<%= Institutional.WebUserInterface.Controls.WebUtilities.GetPlayUrl() %>">game</a>...
</body>
</html>
