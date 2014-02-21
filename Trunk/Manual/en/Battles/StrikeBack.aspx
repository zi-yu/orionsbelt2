<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Strike Back
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Strike Back</h1>
	<div class="content">
    The <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> is an attack that is nice to have but is not essential to win a battle. What happens is that when a group of
    <a href='/en/UnitIndex.aspx'>Units</a> with this caracteristic is attacked, the <a href='/en/UnitIndex.aspx'>Units</a> in that group who survive, will attack automatically attack without 
    using any <a href='/en/Battles/Movement.aspx'>Movement</a>. <p />
    But this attack has some limitations, not all attacks are likely to be counter attacked, the next images
    help you to understand these limitations:

    <div class="block"><img style="margin-right:90px" src="/Resources/Images/strikeBack1.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack4.png" alt="Strike Back" /></div><br /><div class="block"><img style="margin-right:34px" src="/Resources/Images/strikeBack3.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack2.png" alt="Strike Back" /></div><br />
  The <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> is an unit that has the ability to <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> and in all examples, we will show you attacks on <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a>.
  In the first image <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> does not <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> because they are being attacked by <a class='spider' href='/en/Unit/Spider.aspx'>Spider</a> that have the ability to [Paralyze],
  the <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> will not <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> because they are paralyzed. <p />
    In the second image <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> are being attacked by <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a>, but <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a> and <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> have <a class='raptor' href='/en/Unit/Raptor.aspx'>Raptor</a> between them, and so <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a> will
    use the <a href='/en/Battles/Catapult.aspx'>Catapult</a>, wich will block the [Pretorian <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> ability.<p />
    The third attack also does not cause <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> because the <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a> are not frontally attacking the <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a>. <p />
  Finally, the fourth attack is the only one that will cause <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a>, because the <a class='raptor' href='/en/Unit/Raptor.aspx'>Raptor</a> are frontally attacking <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a>
  and do not have any ability to avoid the <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a>. <p />
  There are still two other situation in wich the <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> is not activated. In the case of the unit with <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a>
  does not have enough <a href='/en/Battles/Range.aspx'>Range</a> to <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a>. For example if <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> are attacked by <a class='nova' href='/en/Unit/Nova.aspx'>Nova</a> in a <a href='/en/Battles/Range.aspx'>Range</a> of 5, they will not respond
  to the attack because they have only <a href='/en/Battles/Range.aspx'>Range</a> 3. The last situation where the <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> is not activated, is when the unit
  (eg: <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a>) with the ability of <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> is reached by <a href='/en/Battles/Rebound.aspx'>Rebound</a>.
    </div>
	
</asp:Content>