<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Torna-te campeão de 15 arenas ao mesmo tempo
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Torna-te campeão de 15 arenas ao mesmo tempo" runat="server" /></h1>
	
	<div class="description">
		Explora o <a href='/pt/Universe/Default.aspx'>Universo</a>, encontras as <a href='/pt/Universe/Arenas.aspx'>Arenas</a> e torna-te o campeão incontestado em pelo menos 15 arenas.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a> : +150</li><li><a class='doomer' href='/pt/Unit/Doomer.aspx'>Aniquiladora</a> : +500</li><li><a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a> : +15000</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +15000</li><li><a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a> : +15000</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +15000</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +15000</li></ul>
	</div>
	
</asp:Content>