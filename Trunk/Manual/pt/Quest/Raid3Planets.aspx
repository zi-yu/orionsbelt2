<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pilhar 3 planetas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Pilhar 3 planetas" runat="server" /></h1>
	
	<div class="description">
		Pilhar um <a href='/pt/Universe/Planets.aspx'>Planeta</a> é uma acção idêntica a conquistar um <a href='/pt/Universe/Planets.aspx'>Planeta</a>.
  Quando carregas com o botão esquerdo do rato (e tens uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> previamente seleccionada) num <a href='/pt/Universe/Planets.aspx'>Planeta</a> que tenha dono duas opções aparecem:
  "Atacar Planeta e Conquistar" e "Pilhar Planeta". Já sabes o que significa a primeira opção, mas o que é a segunda? Pilhar?
  Pilhar é quase o mesmo que conquistar um <a href='/pt/Universe/Planets.aspx'>Planeta</a>, todas as regras se aplicam, só uma coisa muda: o prémio.<p />
  Na primeira opção se ganhares, ganhas o direito ao <a href='/pt/Universe/Planets.aspx'>Planeta</a>.
  Na segunda opção roubas recursos do <a href='/pt/Universe/Planets.aspx'>Planeta</a>. Se o <a href='/pt/Universe/Planets.aspx'>Planeta</a> não tiver <a href='/pt/Universe/Fleet.aspx'>Armada</a> de defesa o <a href='/pt/Universe/Raids.aspx'>Pilhagem</a> é automático, caso contrário começa
  uma batalha, e se ganhares a <a href='/pt/Universe/Raids.aspx'>Pilhagem</a> é executada com sucesso.<p />
  Enquanto tiveres um nível baixo de pilhagem pode não parecer uma acção interessante porque até normalmente tens todos os recursos
  que necessitas, mas quando progrides no jogo vais ter mais necessidades de recursos e existem mais recursos para roubar. Claro que não
  é possível pilhar um <a href='/pt/Universe/Planets.aspx'>Planeta</a> sem dono.<p />
  Nota: Pilhar só rouba recursos raros, a probabilidade do recurso roubado depende da <a href='/pt/Race/Races.aspx'>Raça</a> do jogador que é dono do <a href='/pt/Universe/Planets.aspx'>Planeta</a>.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +5500</li><li><a href='/pt/PirateQuests.aspx'>Pirata</a> : +30</li><li><a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a> : +600</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +600</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +600</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +600</li><li><a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a> : +600</li></ul>
	</div>
	
</asp:Content>