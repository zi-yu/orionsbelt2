<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
		Missões e Profissões
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
		<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Missões e Actividades</h1>
<div class="description">
    No início, há <a href='/pt/Quests.aspx'>Missões</a> disponíveis que te guiam enquanto aprendes os conceitos básicos
    do jogo. Após esta parte inicial, é possível seguir <a href='/pt/Quests.aspx'>Missões</a> específicas de determinadas <a href='/pt/Quests.aspx#Professions'>Actividades</a>.
    As <a href='/pt/Quests.aspx'>Missões</a> são basicamente uma forma de te entreter e te ocupar enquanto jogas. Não é obrigatório
    fazer <a href='/pt/Quests.aspx'>Missões</a> para ter sucesso, mas seguir as <a href='/pt/Quests.aspx'>Missões</a> ajuda-te a evoluir mais rapidamente.
    <p />
    Uma <a href='/pt/Quests.aspx'>Missão</a> é definida por um objectivo e uma recompensa. Se conseguires atingir o objectivo da <a href='/pt/Quests.aspx'>Missão</a>,
    então ganhas a recompensa associada, tão simples quanto isto.
    <p />
    O jogo oferece uma variedade interessante de <a href='/pt/Quests.aspx'>Missões</a> para jogar: podes atacar outros jogadores, fazer
    <a href='/pt/Universe/Raids.aspx'>Pilhagem</a> aos seus planetas, aceitar <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a> ou até <a href='/pt/BountyHunterQuests.aspx'>Cabeças a Prémio</a>.
  </div>
<a name="Types" id="Types"></a>
<h3>Tipos de Missões</h3>
<div class="description">
    Há dois tipos diferentes de missões:
    <ul><li><b>Missões de Meta</b> - Nestas missões só precisas de atingir uma dada meta para as poderes entregar.
    Por exemplo: na missão <a href='/pt/Quest/ColonizeOnePlanetQuest.aspx'>Colonizar um outro planeta na tua zona privada</a>, basta-te <a href='/pt/Universe/Colonize.aspx'>Colonizar</a> um planeta e entregar a missão.
  </li><li><b>Missões de Tarefa</b> - Estas missões têm um intervalo de tempo (que pode ter limite ou não). Tens de as
    aceitar e só depois as tuas acções contam para completar a missão. Exemplo:
    na missão <a href='/pt/Quest/FinishABattleQuest.aspx'>Fazer uma batalha na zona pública</a>, tens de aceitar a missão primeiro, depois fazer uma batalha e só
    depois entregar a missão.
  </li></ul></div>
<a name="Professions" id="Professions"></a>
<h2>Actividades</h2>
<div class="description">
    Uma <a href='/pt/Quests.aspx#Professions'>Actividade</a> é um caminho que podes seguir para melhor te definir como jogador. Tu podes fazer
    o que quiseres no jogo, mas também podes seguir um caminho específico e ficar perito numa
    dada profissão. Desta forma vais ter acesso a <a href='/pt/Quests.aspx'>Missões</a> mais avançadas e com recompesas melhores.
    <p />
    Há três profissões principais, e deves escolher uma delas. Tu podes fazer <a href='/pt/Quests.aspx'>Missões</a> para todas as
    <a href='/pt/Quests.aspx#Professions'>Actividades</a> a qualquer altura, mas dessa forma não vais conseguir evoluir somente numa profissão
    e tirar o melhor partido disso. Portanto, deves escolher uma das seguintes profissões principais:
    <ul><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a> - efectua <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a> e concentra-te em acções económicas</li><li><a href='/pt/PirateQuests.aspx'>Pirata</a> - ataca, efectua <a href='/pt/Universe/Raids.aspx'>Pilhagens</a>, torna-te no vilão! Não tens de construir nada, rouba o que precisas!</li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a> - estes são os bons da história, eles caçam qualquer <a href='/pt/PirateQuests.aspx'>Pirata</a> para tornar o <a href='/pt/Universe/Default.aspx'>Universo</a> um local mais seguro</li></ul>
    Também podes seguir outras profissões secundárias:
    <ul><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a> - foca-te em colonizar, conquistar e gerir planetas</li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a> - procura <a href='/pt/Universe/Arenas.aspx'>Arenas</a> no universo e tornate o gladiador supremo</li></ul></div>
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
	
</asp:Content>