<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/OrionsBeltMaster.Master"
    Inherits="OrionsBelt.WebUserInterface.Chat" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div style="width: 1000px">
        <style>.mcrmeebo { display: block; background:url("http://widget.meebo.com/r.gif") no-repeat top right; } .mcrmeebo:hover { background:url("http://widget.meebo.com/ro.gif") no-repeat top right; } </style>
        <object width="100" height="500">
            <param name="movie" value="http://widget.meebo.com/mcr.swf?id=fCNCepbOHr" />
            <embed src="http://widget.meebo.com/mcr.swf?id=fCNCepbOHr" type="application/x-shockwave-flash"
                width="1000" height="500" /></object><a href="http://www.meebo.com/rooms" class="mcrmeebo"><img
                    alt="http://www.meebo.com/rooms" src="http://widget.meebo.com/b.gif" width="100"
                    height="45" style="border: 0px" /></a></div>
</asp:Content>
