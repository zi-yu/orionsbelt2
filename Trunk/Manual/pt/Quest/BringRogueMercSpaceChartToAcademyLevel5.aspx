<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trás um mapa espacial de um Rogue Merc a uma Academia nível 5
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Trás um mapa espacial de um Rogue Merc a uma Academia nível 5" runat="server" /></h1>
	
	<div class="description">
		Os Mercs têm uns dos melhores mapas do universo. Preciso de adquiras um desses mapas a uma fleet de Rogue Mercs. Quando o adquirires, leva o mapa a uma Academia de nível 5.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +8500</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +4500</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +4500</li><li><a class='scourge' href='/pt/Unit/Scourge.aspx'>Flagelo</a> : +40</li></ul>
	</div>
	
</asp:Content>