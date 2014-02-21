<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pirat
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Pirat</h1><div class='description'>Kao <a href='/hr/PirateQuests.aspx'>Pirat</a> vi ćete biti ološ <a href='/hr/Universe/Default.aspx'>Svemir</a>! Napadati ćete nevine flote, <a href='/hr/Universe/Raids.aspx'>Pljačka</a> nezaštićene planete i igrače i krasti od koga god da možete!</div><h2>Pirat Misije</h2><div class='description'>Da biste imali ove misije dostupne, prvo završite: <ul><li><a href='Quest/FinishABattleQuest.aspx'>Završi bitku u hot zoni</a></li></ul></div><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3Fleets.aspx'>Napadni i uništi tri flote</a></td></tr><tr><td colspan='6'><a href='Quest/Raid3Planets.aspx'>Opljačkaj 3 planeta</a></td></tr></table>
	
</asp:Content>