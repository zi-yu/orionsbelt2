﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destrói o Comandante Fox
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destrói o Comandante Fox" runat="server" /></h1>
	
	<div class="description">
		Estou farto. Trás-me a cabeça do Comandante Fox. Esta é a missão mais importante que alguma vez te vou dar, por isso não falhes ou vais-te arrepender. Tens de procurar os níveis 9 e 10 e trazer a sua cabeça a qualquer Baía de Piratas de nível 10.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +50000</li><li><a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a> : +12000</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +12000</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +12000</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +12000</li><li><a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a> : +12000</li><li><a class='commanderfox' href='/pt/Unit/CommanderFox.aspx'>Comandante Raposa</a> : +1</li></ul>
	</div>
	
</asp:Content>