<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Kopfgeld gesetzt auf Spieler
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Kopfgeld gesetzt auf Spieler</h1>
	<div class="description">
    Spieler können Custom-Kopfgelder auf irgendein Ziel setzen. Wenn ein Spieler ein Custom-Ziel 
    kreiert, muss er dem/der Spieler(in) eine <a href='/de/Commerce/Orions.aspx'>Orions</a> Belohnung bezahlen der beauftragt wird . Es 
    können mehrere Spieler die Kopfgeld- Mission akzeptieren und ihr Fortschritt besteht dadurch das 
    sie dem Gejagten Punkte stehlen auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>.
    <p>
     Wenn mehr als ein Jäger Punkte stiehlt, wird die <a href='/de/Commerce/Orions.aspx'>Orions</a> Belohnung aufgeteilt.
  </p></div>
	
</asp:Content>