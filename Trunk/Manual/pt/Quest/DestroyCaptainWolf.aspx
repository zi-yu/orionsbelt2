<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destrói o Capitão Wolf
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destrói o Capitão Wolf" runat="server" /></h1>
	
	<div class="description">
		A Space Force está a destruir o nosso império e precisamos de os parar. O Capitão Wolf, a mão direita do lider, o Comandante Fox, tem de ser parado. Trás-me a sua cabeça! Relatórios localizam-no na zona de nivel 7, mas também já foi visto em zonas de nivel 9 e nivel 10. Encontra-o e trás a sua cabeça a qualquer Baía de Piratas de nível 7.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +100000</li><li><a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a> : +25000</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +25000</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +25000</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +25000</li><li><a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a> : +25000</li><li><a class='captainwolf' href='/pt/Unit/CaptainWolf.aspx'>Capitão Lobo</a> : +1</li></ul>
	</div>
	
</asp:Content>