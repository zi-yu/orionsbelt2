<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Battle
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Battle</h1><div class='description'><a href='/en/Quests.aspx'>Quests</a> that focus on battles.</div><h2>Battle Quests</h2><div class='description'>To have these quests available, you must first complete: <ul><li><a href='Quest/FindPrivateWormHoleQuest.aspx'>Find a Worm Hole on your private zone and use it to travel to the hot zone</a></li></ul></div><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/FinishABattleQuest.aspx'>Finish a battle on the hot zone</a></td></tr></table>
	
</asp:Content>