<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Races</h2><ul><li><a href='/fr/Race/LightHumans.aspx'>Utopians</a></li><li><a href='/fr/Race/DarkHumans.aspx'>Renegades</a></li><li><a href='/fr/Race/Bugs.aspx'>Levyr</a></li><li><a href='/fr/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mercs</h1>
	
	<div class="content">
  <p>Ils viennent des profondeurs noirs de l'univers. C'est un groupe de pirates composés des pires brutes, lascars et mercenaires...appelés les comme bon vous semble.</p>
  <p> Ils sont synonymes de destruction. Ils attaquent tout ce qu'ils voient. Avec leurs vaisseaux supérieurs, construit è l'aide de technologies volés au fil des pillages, c'est unr armée formidablement féroce.</p>
  <p>Dirigé par l'impitoyable Barbe Métallique et sont vaisseau pratiquement indestructible, les Mercs sont une menace pour tous ce qui respire sur l'univers...</p>
</div>
	
	<div class="content">
		<ul class='resourceList'><li><a class='reaper' href='/fr/Unit/Reaper.aspx'>Reaper</a></li><li><a class='scourge' href='/fr/Unit/Scourge.aspx'>Scourge</a></li><li><a class='titan' href='/fr/Unit/Titan.aspx'>Titan</a></li><li><a class='silverbeard' href='/fr/Unit/SilverBeard.aspx'>Silver Beard</a></li><li><a class='metallicbeard' href='/fr/Unit/MetallicBeard.aspx'>Metallic Beard</a></li><li><a class='walker' href='/fr/Unit/Walker.aspx'>Walker</a></li><li><a class='sentry' href='/fr/Unit/Sentry.aspx'>Sentry</a></li></ul>
	</div>
	
</asp:Content>