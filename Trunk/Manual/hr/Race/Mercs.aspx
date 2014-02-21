<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Rase</h2><ul><li><a href='/hr/Race/LightHumans.aspx'>Utopians</a></li><li><a href='/hr/Race/DarkHumans.aspx'>Renegades</a></li><li><a href='/hr/Race/Bugs.aspx'>Levyr</a></li><li><a href='/hr/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mercs</h1>
	
	<div class="content">
  <p>Došli su iz dubina Svemira. Oni su grupa pirata, plaćenika, razbijača...zovite ih kako god da želite. </p>
  <p>Oni su destrukcija. Napadaju sve na što im padne pogled. Sa njihovom superiornom tehnologijom koju st ukrali tokom stoljeća, oni su žestok neprijatelj. </p>
  <p>Vođeni od okrutnoga Metalne Brade i njegovoga skoro neuništivoga broda, predstavljaju ozbiljnu prijetnju svim rasam u svemiru.</p>
</div>
	
	<div class="content">
		<ul class='resourceList'><li><a class='reaper' href='/hr/Unit/Reaper.aspx'>Žetalica</a></li><li><a class='scourge' href='/hr/Unit/Scourge.aspx'>Bič</a></li><li><a class='titan' href='/hr/Unit/Titan.aspx'>Titan</a></li><li><a class='silverbeard' href='/hr/Unit/SilverBeard.aspx'>Srebrena Brada</a></li><li><a class='metallicbeard' href='/hr/Unit/MetallicBeard.aspx'>Metalna Brada</a></li><li><a class='walker' href='/hr/Unit/Walker.aspx'>Walker</a></li><li><a class='sentry' href='/hr/Unit/Sentry.aspx'>Stražar</a></li></ul>
	</div>
	
</asp:Content>