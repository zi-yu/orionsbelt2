<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Completar 10 rotas comerciais de Ferramentas ou Mantimentos em 24 horas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Completar 10 rotas comerciais de Ferramentas ou Mantimentos em 24 horas" runat="server" /></h1>
	
	<div class="description">
		Completar dez rotas comerciais de Ferramentas ou Mantimentos em 24 horas
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +5000</li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a> : +300</li><li><a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a> : +1000</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +1000</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +1000</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +1000</li><li><a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1000</li></ul>
	</div>
	
</asp:Content>