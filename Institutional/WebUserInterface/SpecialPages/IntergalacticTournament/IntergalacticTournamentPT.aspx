<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="IntergalacticTournamentPT.aspx.cs" Inherits="WebUserInterface.IntergalacticTournamentPT" MasterPageFile="~/ContentPageMaster.Master" %>

<asp:Content ContentPlaceHolderID="mainHeader" runat="server">
    <div id='pageTitle'>
        Primeiro Torneio Intergaláctico Orion's Belt
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="contentPageContent" runat="server">

    <div style="float:left;width:455px;padding-right:25px;">
    
    <p>
        O <a href="http://www.orionsbelt.eu">Jogo de Browser Orion's Belt</a> anuncia com orgulho o primeiro
        <a href="http://intergalactic.orionsbelt.eu">Torneio Intergaláctico</a>, onde os jogadores podem lutar por
        <strong style="font-size:14px;text-decoration:underline;">2000&euro; de prémios</strong>. O Torneio será travado
        num jogo de tabuleiro parecido ao xadrez. Terás de liderar as tuas unidades de combate numa demanda para ser
        o supremo campeão do Orion's Belt! Para participar somente precisas de te registar em 
        <a href="http://www.orionsbelt.eu">orionsbelt.eu</a> e entrar no torneio. A entrada no torneio são uns simbólicos 2&euro;.
    </p>    
    
    <h1>Estrutura do Torneio e Prémios</h1>
    
    <table class="table" style="width:150px;float:left;margin:15px;">
        <tr>
            <th>Posição</th>
            <th>Prémio</th>
        </tr>
        <tr>
            <td>1º</td>
            <td>1000&euro;</td>
        </tr>
        <tr>
            <td>2º</td>
            <td>650&euro;</td>
        </tr>
        <tr>
            <td>3º</td>
            <td>200&euro;</td>
        </tr>
        <tr>
            <td>4º</td>
            <td>100&euro;</td>
        </tr>
        <tr>
            <td>5º</td>
            <td>50&euro;</td>
        </tr>
        <tr>
            <td>6º</td>
            <td>5000 Orions</td>
        </tr>
        <tr>
            <td>7º</td>
            <td>4000 Orions</td>
        </tr>
        <tr>
            <td>8º</td>
            <td>3000 Orions</td>
        </tr>
        <tr>
            <td>9º</td>
            <td>2000 Orions</td>
        </tr>
        <tr>
            <td>10º</td>
            <td>1000 Orions</td>
        </tr>
    </table>
    
    <p>
        Um máximo de 1000 jogadores vão competir para ganhar o Torneio Intergaláctico do Orion's Belt, mas apenas 10 chegarão
        à fase final.
    </p>
    <p>    
        As inscrições para o torneio já estão abertas. Assim que te registares serás alocado a um grupo com outros jogadores e
        no dia <strong style="font-size:14px;text-decoration:underline;">15 de Janeiro</strong> será dado início ao torneio.
        Até lá, podes-te preparar para o torneio, seguindo as nossas dicas mais abaixo.
    </p>
    <p>
        O torneio terá várias fases de grupo onde apenas os jogadores nas posições cimeiras poderão avançar para a fase seguinte.
        Cada grupo terá até 10 jogadores que irão batalhar uns contra os outros por pontos. Aqueles que conseguirem mais pontos
        irão para a fase seguinte. 
    </p>
    <p>
        A fase final será um grupo com os 10 melhores jogadores! O vencedor será aquele que tiver a melhor eficácia em todos os combates.
        Os combates no Orion's Belt têm um sistema de pontos com base nas unidades destruidas. Quantas mais destruires, mais pontuação
        irás ter. Portanto, mesmo que possas perder um combate, tens de te esforçar para conseguir o máximo de pontuação possível,
        porque todos os pontos contarão para a classificação final!
    </p>
    
    <div class="clear"></div>
    <h1>Como Participar no Torneio</h1>
    
    <p>
        Para participares na primeira versão do Torneio Intergaláctico tens de criar uma conta em <a href="http://www.orionsbelt.eu">orionsbelt.eu</a>.
        Quando o fizeres terás de fazer um pagamento e então na Zona de Batalhas terás acesso ao registo no torneio. Serás colocado
        na lista de jogadores inscritos até o torneio começar.
    </p>
    
    <h1>Como te Podes Preparar Para o Torneio?</h1>
    
    <p>
        O sistema de combate do Orion's Belt é muito divertido e desafiante de ser jogado, mas vais ter de o dominar bem para que possas defrontar os melhores
        jogadores. Vais precisar de conhecer as <a href="http://manual.orionsbelt.eu/pt/UnitIndex.aspx">unidades de combat</a> e suas capacidades.
        E terás de saber como um jogo é processado. A primeira coisa que tens de fazer é aprender 
        os <a href="http://manual.orionsbelt.eu/pt/Battles/BattleConcepts.aspx">Conceitos de Batalha</a> básicos. 
        Quando começares a primeira batalha terás um pequeno tutorial que te irá ensinar a comandar as tuas unidades.
    </p>
    
    <p>    
        Para praticar, a melhor forma é jogar nas <a href="http://s1.orionsbelt.eu/Campaigns/Default.aspx">Campanhas</a> do jogo, onde irás
        defrontar a nossa inteligência artificial. Ela não é muito avançada mas será o suficente para te ajudar a perceber o jogo. Há vários 
        níveis nas campanhas que te irão introduzir à mecânica do jogo e às unidades de combate.
    </p>
    
    <p>
        Há diversas tácticas de combate bem estudadas que podes aprender para seres o melhor no tabuleiro de jogo. Podes encontrá-las no manual
        em <a href="http://manual.orionsbelt.eu/en/Battles/BattleTactics.aspx">Tácticas de Combate</a>.
        Na nossa <a href="http://gazette.orionsbelt.eu/">Gazeta</a>, também tens várias 
        <a href="http://gazette.orionsbelt.eu/category/battle-analysis/">batalhas comentadas</a> para analisar.
    </p>
    
    <p>
        Quando começares a perceber o jogo, podes entrar nos nossos <a href="http://s1.orionsbelt.eu/Tournaments.aspx">mini torneios</a>. 
        Estes torneios são começados automaticamente assim
        que obtêm 16 inscritos. São grátis e qualquer jogador pode participar neles. São uma excelente forma de testares as tuas
        capacidades  contra outros jogadores.
    </p>
    
    <p>
        Por último, podes sempre criar <a href="http://s1.orionsbelt.eu/Battle/CreateFriendly.aspx">jogos amigáveis</a> com outros jogadores
        para testares tácticas ou unidades de combate. A comunidade no Orion's Belt é espantosa e por certo terás vários jogadores que aceitarão
        de bom grado treinar contigo.
    </p>
    
    <h1>Sobre o Jogo Orion's Belt</h1>
    
    <p>
        O Jogo Orion's Belt é um jogo gratuito de estratégia por turnos que jogas num browser contra outros jogadores espalhados pelo mundo.
        Não precisas de fazer nenhum download para começar a jogar.
        
        O inovador deste jogo é que as batalhas são travadas num jogo de tabuleiro parecido com xadrez,
        onde terás várias unidades de combate muito poderosas ao teu dispôr para combater o teu adversário.
    </p>
    
    <h1>Recursos</h1>
    
    <ul>
        <li><a href="http://www.orionsbelt.eu">Site do Orion's Belt</a></li>
        <li><a href="http://blog.orionsbelt.eu">Blog do Orion's Belt</a></li>
        <li><a href="http://gazette.orionsbelt.eu">Orion's Belt Gazette</a></li>
        <li><a href="http://manual.orionsbelt.eu">Manual do Orion's Belt</a></li>
    </ul>
    
    </div>
    
    <div style="float:left;width:190px;padding-right:20px;">
    
        <InstitutionalUI:PlayNow ID="PlayNow1" IntergalacticTournament="true" runat="server" />
        
        <h1>Artigos no Blog</h1>
        <script src="http://feeds.feedburner.com/IntergalacticTournament?format=sigpro" type="text/javascript" ></script>
        
        <h1>Unidades do Torneio</h1>
        <InstitutionalUI:IntergalacticUnits ID="IntergalacticPartners1" runat="server" />
        
    </div>

    <div style="float:left;width:210px">
        <script type="text/javascript" src="http://w.sharethis.com/button/sharethis.js#publisher=c2aac02a-6326-4d2b-9038-a4d7f84aee51&amp;type=website&amp;buttonText=Partilha%20esta%20P%C3%A1gina"></script>
    
        <h1>Parceiros</h1>
        <InstitutionalUI:IntergalacticPartners runat="server" />
    
        <h1>Exemplos de Batalhas</h1>
        <img src="http://www.orionsbelt.eu/Images/Battles.jpg" alt="Orion's Belt Battles" />
    </div>
    
    <div class="clear"></div>

</asp:Content>
