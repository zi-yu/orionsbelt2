<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Caça a um Jogador Encomendada
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Caça a um Jogador Encomendada</h1>
	<div class="description">
    Os jogadores podem encomendar caças a qualquer alvo que queiram. Quando um jogador cria uma caça, tem de
    oferecer uma recompensa em <a href='/pt/Commerce/Orions.aspx'>Orions</a> para os jogadores que a aceitarem. Vários jogadores podem aceitar a caça
    e eles progridem através de ataques ao alvo.
    <p />
    Se mais do que um caçador retira pontos ao alvo, a recompensa será dividida.
  </div>
	
</asp:Content>