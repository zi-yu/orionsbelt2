<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="SpaceBrowserGame.aspx.cs" Inherits="WebUserInterface.SpaceBrowserGamePT" MasterPageFile="~/ContentPageMaster.Master" %>

<asp:Content ContentPlaceHolderID="mainHeader" runat="server">
    <div id='pageTitle'>
        Jogo de Estrat�gia Espacial
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="contentPageContent" runat="server">

    <div style="float:left;width:455px;padding-right:25px;">
    
    <p>
    O <a href="http://www.orionsbelt.eu">Orion�s Belt</a> � um novo <strong>jogo de estrat�gia espacial</strong>! Este jogo � jogado num browser, pelo que o
    podes jogar em qualquer computador, sem ser preciso fazeres download ou instalar nada. Foi desenhado para consumir pouco tempo por dia, e no entanto ser
    muito interessante, desafiador e divertido.
    </p>

    <img class="alignnone size-full wp-image-490" title="Zona P�blica" src="http://blog.orionsbelt.eu/wp-content/uploads/2009/01/hz.png" alt="" width="280" height="296"/>

    <h1>Ambiente de Estrat�gia Espacial</h1>
    
    <p>
    Este jogo  jogo � passado num ambiente espacial. Se gostas de jogos como Master of Orion, Alpha Centauri, ou Stargate Worlds, por certo ir�s
    gostar do Orion's Belt. Come�as o jogo numa pequena zona privada com cinco planeas. Este � o teu espa�o e ningu�m o pode atacar.
    Quando tiveres pronto podes usar uma <a href="http://pt.wikipedia.org/wiki/Dobra_espacial_(Star_Trek)">dobra espacial</a> para viajar para a zona p�blica.
    � na zona p�blica que a ac��o <a href="http://www.orionsbelt.eu/pt/jogo-estrategia-online-por-turnos-gratis/">por turnos</a> come�a a ficar interessante, 
    pois come�ar�s a interagir com outros jogadores.
    </p>
    
    <p>
    Tal como em qualquer <strong>jogo de estrat�gia espacial</strong> ter�s planetas para conquistar, armadas para gerir, edif�cios para construir, e poderosas
    unidades de combate para usar. Tamb�m ter�s algumas ra�as dispon�veis para escolheres, cada uma com a sua pr�pria forma de jogar. Enquanto viajas pelo
    espa�o, tamb�m encontrar�s ra�as e fac��es controladas pelo computador. Estes encontros tornam este jogo de 
    <a href="http://www.orionsbelt.eu/pt/jogo-ficcao-cientifica-online-gratis/">fic��o cientifica</a> mais interessante.
    </p>
    
    <h1>Estrat�gia Espacial</h1>
    
    <p>
    No <a href="http://www.orionsbelt.eu">Orion�s Belt</a> tens v�rias miss�es para seguir. Cada uma destas miss�es vai-te ajudar a aprender a jogar � medida
    que vais evoluindo, e ir�o-se tornar um grande desafio de estrat�gia espacial quando tiveres mais avan�ado no jogo. Podes escolher v�rias profiss�es:
    mercador, pirata, ca�ador de pr�mios, colonizador ou gladiador. Cada profiss�o tem v�rias miss�es associadas, espalhadas pelo espa�o, para tu completares.
    </p>
    
    <p>
    Um <strong>jogo de estrat�gia espacial</strong> n�o o � sem alian�as. O Orion's Belt foi feito a pensar nas guerras entre alian�as! H� diversas rel�quias
    pelo jogo que as alian�as devem conquistar para terem supremacia. Isto torna este jogo t�ctico espacial muito empolgante. Uma rel�quia d� a cada membro
    da alian�a recursos raros, pelo que � do interesse das alina�as o dom�nio espacial das rel�quias.
    </p>
    
    <h1>O Orion's Belt � o Jogo de Estrat�gia Espacial que Procuravas!</h1>
    
    <p>
    N�o tens de procurar mais! Como podes ver neste artigo o <a href="http://www.orionsbelt.eu">Jogo Online Orion's Belt</a> tem tudo o que precisas
    para te divertires imenso. Aponta o teu browser/navegador para <a href="http://www.orionsbelt.eu">orionsbelt.eu</a> e come�a j� a jogar
    este grande <strong>jogo de estrat�gia espacial</strong>!
    </p>

    </div>
    
    <div style="float:left;width:190px;padding-right:20px;">
    
        <InstitutionalUI:PlayNow ID="PlayNow1" IntergalacticTournament="true" runat="server" />
        
        <InstitutionalUI:SeoPTMenu runat="server" />
        
    </div>

    <div style="float:left;width:210px">
        <script type="text/javascript" src="http://w.sharethis.com/button/sharethis.js#publisher=c2aac02a-6326-4d2b-9038-a4d7f84aee51&amp;type=website&amp;buttonText=Partilha%20esta%20P%C3%A1gina"></script>
    
        <h1>Exemplos de Batalhas</h1>
        <img src="http://www.orionsbelt.eu/Images/Battles.jpg" alt="Orion's Belt Battles" />
    </div>
    
    <div class="clear"></div>

</asp:Content>
