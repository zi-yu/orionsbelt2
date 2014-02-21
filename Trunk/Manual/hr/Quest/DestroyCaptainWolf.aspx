<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Captain Wolf
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Captain Wolf" runat="server" /></h1>
	
	<div class="description">
		The Space Force is destroying our empire and we need to stop it. Captain Wolf, the right hand of their leader, Commander Fox, has to be stopped. Bring me his head! Reports locate him in the level 7 zone but sometimes he wonders in the level 9 and level 10 zones. Find him and bring his Head to any level 7 Pirate Bay.
	</div>
	
	<h2>Nagrada</h2>
	<div class="description">
		<ul><li>Rezultat : +100000</li><li><a class='astatine' href='/hr/Intrinsic/Astatine.aspx'>Astatin</a> : +25000</li><li><a class='radon' href='/hr/Intrinsic/Radon.aspx'>Radon</a> : +25000</li><li><a class='prismal' href='/hr/Intrinsic/Prismal.aspx'>Prismal</a> : +25000</li><li><a class='argon' href='/hr/Intrinsic/Argon.aspx'>Argon</a> : +25000</li><li><a class='cryptium' href='/hr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +25000</li><li><a class='captainwolf' href='/hr/Unit/CaptainWolf.aspx'>CaptainWolf</a> : +1</li></ul>
	</div>
	
</asp:Content>