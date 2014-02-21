<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trás um mapa espacial de um Merc a uma Academia nível 1
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Trás um mapa espacial de um Merc a uma Academia nível 1" runat="server" /></h1>
	
	<div class="description">
		Os Mercs têm uns dos melhores mapas do universo. Preciso de adquiras um desses mapas a uma fleet de Mercs. Quando o adquirires, leva o mapa a uma Academia de nível 1.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +3500</li><li><a class='sentry' href='/pt/Unit/Sentry.aspx'>Vigilante</a> : +50</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +2500</li></ul>
	</div>
	
</asp:Content>