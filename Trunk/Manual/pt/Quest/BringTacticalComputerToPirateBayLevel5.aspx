<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trás Computadores Tácticos a uma Baía de Piratas nível 5
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Trás Computadores Tácticos a uma Baía de Piratas nível 5" runat="server" /></h1>
	
	<div class="description">
		A Space Force está a ficar demasiado poderosa muito devido aos seus Computadores Tácticos. Temos de os obter. Trás 5 computadores táticos de uma armada da Gamma Force a qualquer Baía de Piratas de Nível 5.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +6500</li><li><a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a> : +4500</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +4500</li></ul>
	</div>
	
</asp:Content>