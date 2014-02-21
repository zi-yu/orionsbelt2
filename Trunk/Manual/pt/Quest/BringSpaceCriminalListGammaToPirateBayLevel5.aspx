<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trás Lista de Criminosos Gamma a uma Baía de Piratas nível 5
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Trás Lista de Criminosos Gamma a uma Baía de Piratas nível 5" runat="server" /></h1>
	
	<div class="description">
		A Gamma Force possui uma lista com os criminosos mais procurados na zona de nível 5. Queremos que encontres essa lista e a tragas a qualquer baía de piratas de nível 5.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +8500</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +4500</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +4500</li></ul>
	</div>
	
</asp:Content>