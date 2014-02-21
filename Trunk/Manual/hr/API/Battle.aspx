<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	API bitke
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>API i Utilities</h2><ul><li><a href='/hr/API/Battle.aspx'>API bitke</a></li><li><a href='/hr/API/UniverseXML.aspx'>Svemir XML</a></li><li><a href='/hr/API/UnitsJSON.aspx'>Specifikacije Jedinica</a></li><li><a href='/hr/API/Utilities.aspx'>Utilities iz zajednice Orions Belta</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>API bitke</h1>
	<div class="content">
    The <b>Battle API</b> allows third party applications to play battles on <a href='http://www.orionsbelt.eu'>Orioniv Pojas</a> as a <i>bot</i>. You may use this API to create artificial
    intelligence bots or game clients that'll be able to battle with other players or bots on the <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>. Example of a battle:
    
    <img src="/Resources/Images/Battle.png" class="block" /><h2>Contents</h2><ul><li><a href="#Apply">How to Apply</a></li><li><a href="#Overview">Overview</a></li><li><a href="#AskBattles">Ask For Battles</a></li><li><a href="#Deploy">Deploy</a></li><li><a href="#TurnMoves">Turn Moves</a></li><li><a href="#More">More Information</a></li></ul><a name="Apply" id="apply"></a><h2>How to Apply</h2>
    In order to be able to develop an application using the Battle API, you'll have to contact us. Then we will prepare the development environment
    for you and get you started.
    <p />
    You may contact us using the <a href="mailto:manual@orionsbelt.eu">manual@orionsbelt.eu</a> mail.

    <a name="Overview" id="Overview"></a><h2>Overview</h2>
    The Battle API is very simple to use. You may create an application that will comunicate with <a href='http://www.orionsbelt.eu'>Orioniv Pojas</a> and send/receive moves and battle states.
    You'll have to code your application to perform deploys and turns. The basic interaction is the following:
    <ul><li>#1 You ask the server for battles, and receive a XML file with the battles you have to play</li><li>#2 For each battle received you'll send a HTTP reques to a provided URL with a deploy or moves</li><li>#3 Wait a while and then return to step #1</li></ul><p />
    You have available a XML file with the complete <a href="UnitsJSON.aspx">units specification</a>. When we configure your bot/client, you'll
    be able to create a <a href='/hr/Battles/Friendly.aspx'>Prijateljski</a> with it and try your bot in action.

    <a name="AskBattles" id="AskBattles"></a><h2>Ask For Battles</h2>
    The first time you ask for battles, you won't get any. You'll have to create a <a href='/hr/Battles/Friendly.aspx'>Prijateljski</a> with your bot, and only then you'll get some battles
    to play. To ask for battles you'll have to make an HTTP request to:
    
    <pre class="code">http://<u>server</u>.orionsbelt.eu/Ajax/Battle/BotBattle.ashx?type=<u>botGetBattles</u>&amp;botId=<u>1111</u>&amp;verificationCode=<u>ABC</u></pre>

    Note that you'll have to send the request for the right server. You'll have a bot per server, so if you're registered on more than one server you'll have to act
    accordinally. You also have to give the bot ID and the bot verification code.

    <a name="Deploy" id="Deploy"></a><h2>Deploy</h2>
    The first part of the battle is the <a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a>. When you request battles using the previous URL you'll receive something like:
    <pre class="code">
  &lt;Battles&gt;
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
    This is a very simple battle between <u>Bot001</u> and <u>nunos</u>, and you'd have to deploy now. The combat <a href='/hr/Universe/Fleet.aspx'>Flota</a> only has the <a class='raptor' href='/hr/Unit/Raptor.aspx'>Raptor</a>, no more <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>
    are present. You'd now have to make a request to <u>ResponseUrl</u> indicating how you'd like to <a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a>:
    <pre class="code"><u>[ResponseUrl]</u>?type=<u>botdeploy</u>&amp;id=<u>1234</u>&amp;moves=<u>p:rp-8_1-2;p:rp-8_2-8;</u>&amp;botId=<u>321</u>&amp;verificationCode=<u>ABC</u></pre>
    The <u>moves</u> parameter is the most important one and has the following format:
    <pre class="code">p:<u>unit_code</u>-<u>coordinate</u>-<u>quantity</u></pre>
    You'd have to build a string like this one for each unit block on the deploy zone. You have the unit codes on the <a href="UnitsJSON.aspx">units specification</a>. After invoking
    the correctly formed URL, the battle will continue.

    <a name="TurnMoves" id="TurnMoves"></a><h2>Turn Moves</h2>
    After the deploy you may ask again for your battles, and you will now have to play your moves. Note that on these examples only a battle is being returned, but
    if you had several battles to play, you'd receive several &lt;Battle/&gt; elements. When's your turn to play, you'll receive something like:
    <pre class="code">
  &lt;Battles&gt;
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
    Note that the state changed from <u>deploy</u> to <u>battle</u>. Now you receive the current <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> disposition, each unit group, quantity, coordinate, etc.
    After calculating your moves, you'd have to send your response again to the game, using the given <u>ResponseUrl</u>. An example URL would be:
    
    <pre class="code"><u>[ResponseUrl]</u>?type=<u>botbattle</u>&amp;id=<u>1111</u>&amp;moves=<u>r:7_3-n-w;b:7_3-7_2;m:8_3-8_2-5-n;b:8_2-7_2;</u>&amp;botId=<u>321</u>&amp;verificationCode=<u>ABC</u></pre>
    
    The <u>moves</u> parameter is again a list of moves with the following syntax:
    
    <table class="table" style="width:100%;margin-top:10px;margin-bottom:10px;"><tr><th>Type</th><th>Syntax</th><th>Description</th></tr><tr><td>Move</td><td><pre>m:<u>unit_coordinate</u>-<u>destination_coordinate</u>-<u>quantity</u>-<u>direction</u>;</pre></td><td>Moves a unit group from one square to another adjacent square</td></tr><tr><td>Rotate</td><td><pre>r:<u>unit_coordinate</u>-<u>current_direction</u>-<u>next_direction</u>;</pre></td><td>Rotates a unit group; direction can be: N, S, E and W</td></tr><tr><td>Attack</td><td><pre>b:<u>unit_coordinate</u>-<u>target_coordinate</u>;</pre></td><td>Attacks the adversary unit group</td></tr></table>
    
    Then it's your opponents turn to play. When he's done, you'll receive the new <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> state and you have to make more moves. This continues until
    the battle isn't finished. Note that your movements can't spend more than 6 <a href='/hr/Battles/Movement.aspx#MovPoints'>Bodovi Pokreta</a>.
    
    <a name="More" id="More"></a><h2>More Information</h2>
    If you have any questions or suggestions please contact us and we'll be happy to help you.
  </div>
	
</asp:Content>