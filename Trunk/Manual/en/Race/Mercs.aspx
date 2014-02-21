<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Races</h2><ul><li><a href='/en/Race/LightHumans.aspx'>Utopians</a></li><li><a href='/en/Race/DarkHumans.aspx'>Renegades</a></li><li><a href='/en/Race/Bugs.aspx'>Levyr</a></li><li><a href='/en/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mercs</h1>
	
	<div class="content">
  <p>They come from the depths of the Universe. They are a group of pirates, mercenaries, thugs... call them whatever you like.</p>
  <p>They are destruction. They attack everything they put their eyes on. With their superior units, built with technology stolen through the centuries, they are a fierce enemy.</p>
  <p>Lead by the ruthless Metallic Beard and it's almost indestructible ship, they oppose a serious threat to all the races in the universe.</p>
</div>
	
	<div class="content">
		<ul class='resourceList'><li><a class='reaper' href='/en/Unit/Reaper.aspx'>Reaper</a></li><li><a class='scourge' href='/en/Unit/Scourge.aspx'>Scourge</a></li><li><a class='titan' href='/en/Unit/Titan.aspx'>Titan</a></li><li><a class='silverbeard' href='/en/Unit/SilverBeard.aspx'>Silver Beard</a></li><li><a class='metallicbeard' href='/en/Unit/MetallicBeard.aspx'>Metallic Beard</a></li><li><a class='walker' href='/en/Unit/Walker.aspx'>Walker</a></li><li><a class='sentry' href='/en/Unit/Sentry.aspx'>Sentry</a></li></ul>
	</div>
	
</asp:Content>