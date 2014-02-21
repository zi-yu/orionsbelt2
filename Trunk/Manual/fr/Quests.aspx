<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
		Quêtes et professions
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
		<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Quests and Professions</h1>
<div class="description">
    At first, you have some <a href='/fr/Quests.aspx'>Quêtes</a> that will guide you trough the game and teach you the basic concepts.
    After that, you may follow <a href='/fr/Quests.aspx'>Quêtes</a> for a given <a href='/fr/Quests.aspx#Professions'>Profession</a>. <a href='/fr/Quests.aspx'>Quêtes</a> are basically a way to entertain you
    and keep you occupied while you play. You don't have to do any <a href='/fr/Quests.aspx'>Quêtes</a> to succeed in <a href='http://www.orionsbelt.eu'>Orion's Belt</a>, but doing
    so will help you to improve faster.
    <p />
    A quest is defined by an objective and a reward. If you accomplish the defined objective you will gain the
    defined reward, it's as simple as that.
    <p />
    The game offers you a wide choice of quests to play: you can attack other players, <a href='/fr/Universe/Raids.aspx'>Pillage</a> their planets,
    or event accept <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> or <a href='/fr/BountyHunterQuests.aspx'>Mises à prix</a>.
  </div>
<a name="Types" id="Types"></a>
<h3>Quest Types</h3>
<div class="description">
    There are two different types of quest:
    <ul><li><b>Checkpoint Quests</b> - On these quests you just have to achieve the objective to be able to deliver
    them. You don't need to accept them. Example: on the <a href='/fr/Quest/ColonizeOnePlanetQuest.aspx'>Colonisez une planète additionnel sur votre zone privée</a>, you only need to
    <a href='/fr/Universe/Colonize.aspx'>Coloniser</a> a planet and deliver the quest.
  </li><li><b>Task Quests</b> - These quests have a time interval (that may be limited or not). You must accept
    them and only after that your actions will count for completing the quest. Example: on the <a href='/fr/Quest/FinishABattleQuest.aspx'>Terminer une bataille sur la zone publique</a>
    you need to accept the quest, then perform the battle, and only then deliver the quest.
  </li></ul></div>
<a name="Professions" id="Professions"></a>
<h2>Professions</h2>
<div class="description">
    A profession is a path you may follow to define your character on the game.
    You may do whatever you want, but you may also follow some specific
    actions and become proficient on a give profession. This will allow you
    access to better <a href='/fr/Quests.aspx'>Quêtes</a> with better rewards.
    <p />
    There are three main professions, and you should choose only one of these.
    You may perform actions for all <a href='/fr/Quests.aspx#Professions'>Professions</a> at any time, but while doing so
    you won't be able to improve on a specific <a href='/fr/Quests.aspx#Professions'>Profession</a> and take the best
    advantage of it. So, you should choose one of the following:
    <ul><li><a href='/fr/MerchantQuests.aspx'>Marchand</a> - perform <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> and focus on your economy</li><li><a href='/fr/PirateQuests.aspx'>Pirate</a> - attack, <a href='/fr/Universe/Raids.aspx'>Pillage</a>, be the bad guy! You don't have to build anything, just steal it!</li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a> - this is the good guy, he'll hunt down any <a href='/fr/PirateQuests.aspx'>Pirate</a> to make the <a href='/fr/Universe/Default.aspx'>Univers</a> a safer place</li></ul>
    You may also follow other secundary <a href='/fr/Quests.aspx#Professions'>Professions</a>:
    <ul><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a> - focus on colonizing or conquering planets and managing them</li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a> - search the universe for <a href='/fr/Universe/Arenas.aspx'>Arenas</a> and become the ultimate gladiator</li></ul></div>
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
	
</asp:Content>