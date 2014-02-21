<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercs
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Raças</h2><ul><li><a href='/pt/Race/LightHumans.aspx'>Utopianos</a></li><li><a href='/pt/Race/DarkHumans.aspx'>Renegados</a></li><li><a href='/pt/Race/Bugs.aspx'>Levyr</a></li><li><a href='/pt/Race/Mercs.aspx'>Mercs</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Mercs</h1>
	
	<div class="content">
  <p>Eles vêm dos confins da galáxia. São um grupo de piratas, mercenários, bandidos... chamem-lhes o que quiseres. Eles são a destruição.</p>
  <p>Eles atacam tudo onde põe os olhos em cima. Com as suas naves superiores, equipadas com tecnologia roubada ao longo dos séculos, fazem com que sejam um inimigo a ter cuidado.</p>
  <p>Liderados pelo um bandido sem escrúpulos chamado Barba Metálica e a sua quase indestrutível nave, eles são uma verdadeira ameaça para todas as raças da galáxia.</p>
</div>
	
	<div class="content">
		<ul class='resourceList'><li><a class='reaper' href='/pt/Unit/Reaper.aspx'>Ceifeiro</a></li><li><a class='scourge' href='/pt/Unit/Scourge.aspx'>Flagelo</a></li><li><a class='titan' href='/pt/Unit/Titan.aspx'>Titã</a></li><li><a class='silverbeard' href='/pt/Unit/SilverBeard.aspx'>Barba de Prata</a></li><li><a class='metallicbeard' href='/pt/Unit/MetallicBeard.aspx'>Barba Metálica</a></li><li><a class='walker' href='/pt/Unit/Walker.aspx'>Caminhante</a></li><li><a class='sentry' href='/pt/Unit/Sentry.aspx'>Vigilante</a></li></ul>
	</div>
	
</asp:Content>