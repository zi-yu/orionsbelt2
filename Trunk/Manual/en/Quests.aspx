<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
		Quests and Professions
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
		<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Quests and Professions</h1>
<div class="description">
    At first, you have some <a href='/en/Quests.aspx'>Quests</a> that will guide you trough the game and teach you the basic concepts.
    After that, you may follow <a href='/en/Quests.aspx'>Quests</a> for a given <a href='/en/Quests.aspx#Professions'>Profession</a>. <a href='/en/Quests.aspx'>Quests</a> are basically a way to entertain you
    and keep you occupied while you play. You don't have to do any <a href='/en/Quests.aspx'>Quests</a> to succeed in <a href='http://www.orionsbelt.eu'>Orion's Belt</a>, but doing
    so will help you to improve faster.
    <p />
    A quest is defined by an objective and a reward. If you accomplish the defined objective you will gain the
    defined reward, it's as simple as that.
    <p />
    The game offers you a wide choice of quests to play: you can attack other players, <a href='/en/Universe/Raids.aspx'>Raid</a> their planets,
    or event accept <a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a> or <a href='/en/BountyHunterQuests.aspx'>Bounties</a>.
  </div>
<a name="Types" id="Types"></a>
<h3>Quest Types</h3>
<div class="description">
    There are two different types of quest:
    <ul><li><b>Checkpoint Quests</b> - On these quests you just have to achieve the objective to be able to deliver
    them. You don't need to accept them. Example: on the <a href='/en/Quest/ColonizeOnePlanetQuest.aspx'>Colonize one additional planet on your private zone</a>, you only need to
    <a href='/en/Universe/Colonize.aspx'>Colonize</a> a planet and deliver the quest.
  </li><li><b>Task Quests</b> - These quests have a time interval (that may be limited or not). You must accept
    them and only after that your actions will count for completing the quest. Example: on the <a href='/en/Quest/FinishABattleQuest.aspx'>Finish a battle on the hot zone</a>
    you need to accept the quest, then perform the battle, and only then deliver the quest.
  </li></ul></div>
<a name="Professions" id="Professions"></a>
<h2>Professions</h2>
<div class="description">
    A profession is a path you may follow to define your character on the game.
    You may do whatever you want, but you may also follow some specific
    actions and become proficient on a give profession. This will allow you
    access to better <a href='/en/Quests.aspx'>Quests</a> with better rewards.
    <p />
    There are three main professions, and you should choose only one of these.
    You may perform actions for all <a href='/en/Quests.aspx#Professions'>Professions</a> at any time, but while doing so
    you won't be able to improve on a specific <a href='/en/Quests.aspx#Professions'>Profession</a> and take the best
    advantage of it. So, you should choose one of the following:
    <ul><li><a href='/en/MerchantQuests.aspx'>Merchant</a> - perform <a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a> and focus on your economy</li><li><a href='/en/PirateQuests.aspx'>Pirate</a> - attack, <a href='/en/Universe/Raids.aspx'>Raid</a>, be the bad guy! You don't have to build anything, just steal it!</li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a> - this is the good guy, he'll hunt down any <a href='/en/PirateQuests.aspx'>Pirate</a> to make the <a href='/en/Universe/Default.aspx'>Universe</a> a safer place</li></ul>
    You may also follow other secundary <a href='/en/Quests.aspx#Professions'>Professions</a>:
    <ul><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a> - focus on colonizing or conquering planets and managing them</li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a> - search the universe for <a href='/en/Universe/Arenas.aspx'>Arenas</a> and become the ultimate gladiator</li></ul></div>
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
	
</asp:Content>