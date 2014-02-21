<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trás destroços de Black Mercs a uma Academia nível 9
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Trás destroços de Black Mercs a uma Academia nível 9" runat="server" /></h1>
	
	<div class="description">
		Eu necessito de components nas unidades principais dos Black Mercs. Trás esses componentes a qualquer Academia nível 9.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +13000</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +7000</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +7000</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +7000</li></ul>
	</div>
	
</asp:Content>