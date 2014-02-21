<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Naručeni Lov Na Glavu Igrača
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Naručeni Lov Na Glavu Igrača</h1>
	<div class="description">
    Igrači mogu zahtjevati ucjene na glacvu na bilo koju metu. Kada igrač odredi metu, mora platiti <a href='/hr/Commerce/Orions.aspx'>Orioni</a> nagradu igraču koji mu pomogne. Nekoliko igrača može prihvatiti lov na glavu, i oni napreduju tako da uzimaju bodove od mete preko bitki na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>.
    <p />
    Ako više od jednoga lovca ukrade bodove, <a href='/hr/Commerce/Orions.aspx'>Orioni</a> će biti podijeljenji.
  </div>
	
</asp:Content>