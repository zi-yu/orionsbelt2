<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	API de Combat
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API et Utilités</h2><ul><li><a href='/fr/API/Battle.aspx'>API de Combat</a></li><li><a href='/fr/API/UniverseXML.aspx'>XML de l'Univers</a></li><li><a href='/fr/API/UnitsJSON.aspx'>Spécifications des unités de combat</a></li><li><a href='/fr/API/Utilities.aspx'>Utilités créer par la communauté d'Orions's Belt</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>API de Combat</h1>
	<div class="content">
    L'<b>API de Combat</b> permet à un tierce partie extérieur d'utiliser les logiciels pour jouer des combats sur <a href='http://www.orionsbelt.eu'>Orion's Belt</a> contre <i>"qu'escadrlle préprogrammé</i>. Vous pouvez utiliser cet API pour créer des escadrilles ayant une intelligence artificielle (communément appelés E.A.I.) ou créer des "Game clients" capable de combattre d'autres joueurs ou d'autres E.A.I. sur le You may use this API to create artificial <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>. Exemple de bataille:
    
    <img src="/Resources/Images/Battle.png" class="block" /><h2>Contents</h2><ul><li><a href="#Apply">How to Apply</a></li><li><a href="#Overview">Overview</a></li><li><a href="#AskBattles">Ask For Battles</a></li><li><a href="#Deploy">Deploy</a></li><li><a href="#TurnMoves">Turn Moves</a></li><li><a href="#More">More Information</a></li></ul><a name="Apply" id="apply"></a><h2>How to Apply</h2>
    Pour pouvoir développer un logiciel en utilisant l'API de combat, vous devez nous contacter. Nous pourrons ensuite vous préparer un environnement de création et vous aider à débuter.
    <p>
    Vous pouvez nous contecter en utilisant ce courriel: <a href="mailto:manual@orionsbelt.eu">manual@orionsbelt.eu</a><a name="Overview" id="Overview"></a></p><h2>Overview</h2>
    L'API de combat est très simple à utiliser. Vous pouvez créer un logociel en communication avec avec<a href='http://www.orionsbelt.eu'>Orion's Belt</a> pour envoyer et recevoir les mouvements et l'état du combat. and send/receive moves and battle states.
    Vous devrez coder le logiciel pour exécuter les déploiments et les tours. L'interation principales est celle-ci:
    <ul><li>#1 Vous demandez au serveur pour des combats et vous recevez un fichier XML avec les batailles que vous devez jouer.</li><li>#2 Pour chaque bataille reçu, vous allez envoyer une demande HTTP à l'URL qui vous sera fournit aves un déploiement ou les mouvements.</li><li>#3 Attendez un momment et répéter l'étape #1.</li></ul><p>
    Vous avez un fichier XML disponible avec les<a href="UnitsJSON.aspx">spécifications des unités</a>. Lorsque nous aurons configuré votre E.A.I/"client", vous serez capale de créer un <a href='/fr/Battles/Friendly.aspx'>Amical</a> avec lui et le tester en action.
    <a name="AskBattles" id="AskBattles"></a></p><h2>Ask For Battles</h2>
    La première que vous ferez une demande pour un combat, Il n'y en aura pas. Vous devrez d'abord créer un <a href='/fr/Battles/Friendly.aspx'>Amical</a> avec votre E.A.I. pour ensuite pouvoir jouer des batailles. La demande en HTTP pour les batailles doivent se faire à:
    
    <pre class="code">http://<u>server</u>.orionsbelt.eu/Ajax/Battle/BotBattle.ashx?type=<u>botGetBattles</u>&amp;botId=<u>1111</u>&amp;verificationCode=<u>ABC</u></pre>

    Notez que vous devez envoyer votre demande directement pour le bon serveur. Vous aurez un E.A.I. par serveur, alors si vous êtes enregistré à plus d'un serveur, vous devrez agir en conséquence. Vous devez aussi donner L'identification de votre E.A.I. ainsi que son ode de vérification.
    <a name="Deploy" id="Deploy"></a><h2>Deploy</h2>
    La première partie de la bataille est le déploiment. Quand vous faites une demande pour des combats en utilisant l'URL précédent, vous recevrez quelque chose comme:
    <pre class="code">  &lt;Battles&gt;
    &lt;Battle id='1339260' state='<u>deploy</u>'&gt;
  &lt;ResponseUrl&gt;http://source_server/Ajax/Battle/BotBattle.ashx&lt;/ResponseUrl&gt;
  &lt;Players&gt;
    &lt;Player id='0' ownerId='1339159'&gt;<u>Bot001</u>&lt;/Player&gt;
    &lt;Player id='1' ownerId='203'&gt;<u>nunos</u>&lt;/Player&gt;
  &lt;/Players&gt;
  &lt;CurrentPlayer id='0' ownerId='1339159'&gt;Bot001&lt;/CurrentPlayer&gt;
  &lt;Units&gt;
    &lt;Unit quantity='10' name='Raptor' code='rp' /&gt;
  &lt;/Units&gt;
    &lt;/Battle&gt;
  &lt;/Battles&gt;
    </pre>
    Voici une bataille très simple entre <u>E.A.I.001</u> et <u>nunos</u>, et vous devez maintenat faire le déploiement. L'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> de combat a seulement des <a class='raptor' href='/fr/Unit/Raptor.aspx'>Raptor</a>, aucune autre <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>
    est présente. Vous auriez à faire une demande à <u>RéponseUrl</u> indiquant vous aimerez votre <a href='/fr/Battles/Deploy.aspx'>Déploiement</a>:
    <pre class="code"><u>[ResponseUrl]</u>?type=<u>botdeploy</u>&amp;id=<u>1234</u>&amp;moves=<u>p:rp-8_1-2;p:rp-8_2-8;</u>&amp;botId=<u>321</u>&amp;verificationCode=<u>ABC</u></pre>
    The <u>moves</u> Ce paramètre est le plus important et a le format suivant:
    <pre class="code">p:<u>unit_code</u>-<u>coordinate</u>-<u>quantity</u></pre>
    Vous auriez à construire un fil comme celui-çi pour chaque case où il y a une unité lors du déploiement. Vous avez les codes des unités sur You have the unit codes on the <a href="UnitsJSON.aspx">units specification</a>. Après avoir invoquer le format correcte URL, le combat continue.

    <a name="TurnMoves" id="TurnMoves"></a><h2>Turn Moves</h2>
    Après le déploiment, vous pouvez encore demander pour les combats et vous devrez maintenant exécuter vos mouvements.Notez que sur cet example il y a seulement une bataile, mais si vous en auriez plusieurs, vous recevrez plusieurs éléments de N &lt;Bataille/&gt;. Quand c?est à votre tour de jouer, vous recevrez:
    <pre class="code">  &lt;Battles&gt;
    &lt;Battle id='1339264' state='<u>battle</u>'&gt;
  &lt;ResponseUrl&gt;http://source_server/Ajax/Battle/BotBattle.ashx&lt;/ResponseUrl&gt;
  &lt;Players&gt;
    &lt;Player id='0' ownerId='1339159'&gt;<u>Bot001</u>&lt;/Player&gt;
    &lt;Player id='1' ownerId='204'&gt;<u>tsousa</u>&lt;/Player&gt;
  &lt;/Players&gt;
  &lt;CurrentPlayer id='0' ownerId='1339159'&gt;<u>Bot001</u>&lt;/CurrentPlayer&gt;
  &lt;Elements&gt;
    &lt;Element coordinate='2_4' canBeMoved='True' canUseSpecialHabilities='True' 
  id='1' ownerId='204' direction='S' quantity='1' remainingDefense='300' code='rp'/&gt;
    &lt;Element coordinate='8_1' canBeMoved='True' canUseSpecialHabilities='True' 
  id='0' ownerId='1339159' direction='N' quantity='1' remainingDefense='300' code='rp'/&gt;
  &lt;/Elements&gt;
    &lt;/Battle&gt;
  &lt;/Battles&gt;
    </pre>
    Notez que l?état a changé de <u>déploiment</u> to <u>combat</u>. Vous recevez maintenant les dispositions actuelles du <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>, de chaque groupe d?unités, la quantité, les coordonées, etc.
    Après avoir calculé vos mouvements, vous devriez envoyer votre réponse encore une fois au jeu en utilisant la <u>RéponseURL</u>. Un exemple d?URL serait:
    
    <pre class="code"><u>[ResponseUrl]</u>?type=<u>botbattle</u>&amp;id=<u>1111</u>&amp;moves=<u>r:7_3-n-w;b:7_3-7_2;m:8_3-8_2-5-n;b:8_2-7_2;</u>&amp;botId=<u>321</u>&amp;verificationCode=<u>ABC</u></pre>
    
    Le paramètre de <u>mouvement</u> est encore une liste de mouvements avec la syntaxe suivante:
    
    <table class="table" style="width: 100%; margin-top: 10px; margin-bottom: 10px;"><tbody><tr><th>Type</th><th>Syntax</th><th>Description</th></tr><tr><td>Move</td><td><pre>m:<u>unit_coordinate</u>-<u>destination_coordinate</u>-<u>quantity</u>-<u>direction</u>;</pre></td><td>Bouge un groupe d?unité d?une case à une autre adjacente.</td></tr><tr><td>Rotate</td><td><pre>r:<u>unit_coordinate</u>-<u>current_direction</u>-<u>next_direction</u>;</pre></td><td>Change la direction d?un groupe; les possibilités étant: N, S, E et O</td></tr><tr><td>Attack</td><td><pre>b:<u>unit_coordinate</u>-<u>target_coordinate</u>;</pre></td><td>Attacks the adversary unit group</td></tr></tbody></table>
    
    C?est ensuite le tour à vos adversaires de jouer. Quand il a terminé, vous recevrez le nouveau état du <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a> et pourrez faire de nouveaux mouvements. Cela continue jusqu?a ce que la bataille est terminé. À noter que vous ne pouvez pas dépenser plus de 6 <a href='/fr/Battles/Movement.aspx#MovPoints'>Points de mouvement</a>.
    
    <a name="More" id="More"></a><h2>More Information</h2>
    Si jamais vous avez des questions ou suggestions, nous serons heureux de vous aider. Il suffit de nous contacter.
  </div>
	
</asp:Content>