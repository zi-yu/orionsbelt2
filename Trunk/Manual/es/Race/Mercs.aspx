<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Razas</h2><ul><li><a href='/es/Race/LightHumans.aspx'>Utopianos</a></li><li><a href='/es/Race/DarkHumans.aspx'>Renegados</a></li><li><a href='/es/Race/Bugs.aspx'>Levyr</a></li><li><a href='/es/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mercs</h1>
	
	<div class="content">
  <p>They come from the depths of the Universe. They are a group of pirates, mercenaries, thugs... call them whatever you like.</p>
  <p>They are destruction. They attack everything they put their eyes on. With their superior units, built with technology stolen through the centuries, they are a fierce enemy.</p>
  <p>Lead by the ruthless Metallic Beard and it's almost indestructible ship, they oppose a serious threat to all the races in the universe.</p>
</div>
	
	<div class="content">
		<ul class='resourceList'><li><a class='reaper' href='/es/Unit/Reaper.aspx'>Reaper</a></li><li><a class='scourge' href='/es/Unit/Scourge.aspx'>Flagelo</a></li><li><a class='titan' href='/es/Unit/Titan.aspx'>Titan</a></li><li><a class='silverbeard' href='/es/Unit/SilverBeard.aspx'>Silver Beard</a></li><li><a class='metallicbeard' href='/es/Unit/MetallicBeard.aspx'>Barba de Metal</a></li><li><a class='walker' href='/es/Unit/Walker.aspx'>Walker</a></li><li><a class='sentry' href='/es/Unit/Sentry.aspx'>Sentry</a></li></ul>
	</div>
	
</asp:Content>