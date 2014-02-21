<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Contre-attaque
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Contre-attaque</h1>
	<div class="content">
    L’attaque <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> est intéressante, mais pas essentielle pour gagner un combat. Lorsqu’un <a href='/fr/UnitIndex.aspx'>Unités</a> avec cette caractéristique est attaqué, si des <a href='/fr/UnitIndex.aspx'>Unités</a> (une certaine quantité) dans ce groupe survivent, il y a riposte automatique sans même utiliser des points de <a href='/fr/Battles/Movement.aspx'>Mouvement</a>. <p />
    Mais cette attaque est limitée, car elle fonctionne seulement dans certains cas. Voici quelques images pour vous aidez à comprendre:
    <div class="block"><img style="margin-right:90px" src="/Resources/Images/strikeBack1.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack4.png" alt="Strike Back" /></div><br /><div class="block"><img style="margin-right:34px" src="/Resources/Images/strikeBack3.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack2.png" alt="Strike Back" /></div><br />
  Le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> est un type d’unité ayant <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> et dans tous les exemples, c’est le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> qui est attaqué.
  Dans la première image, le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> n’a pas de <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> parce qu’il est attaqué par des <a class='spider' href='/fr/Unit/Spider.aspx'>Araignée</a> possédant l’aptitude [Paralyze],
  et le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> ne peut <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> car il est paralysé. <p />
    Dans la seconde image, le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> est attaqué par un <a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a>, mais il y a un <a class='raptor' href='/fr/Unit/Raptor.aspx'>Raptor</a> entre les deux. L’<a class='eagle' href='/fr/Unit/Eagle.aspx'>Aigle</a>  va donc utiliser <a href='/fr/Battles/Catapult.aspx'>Catapulte</a>, bloquant l’aptitude du <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> ability.<p />
    <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> ne fonctionne pas dans la troisième image, car les <a class='kamikaze' href='/fr/Unit/Kamikaze.aspx'>Kamikaze</a> ne font pas une attaque de front sur le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a>. <p />
  Finalement, la quatrième attaque, qui est la seule qui provoque <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a>, car les <a class='raptor' href='/fr/Unit/Raptor.aspx'>Raptor</a> attaque le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> sur le front et est incapable d’éviter l’aptitude <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a>. <p />
  Il existe deux autres situations ou l’aptitude <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> n’est pas activée. Si l’unité ayant <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> qui est attaqué a une plus petite <a href='/fr/Battles/Range.aspx'>Portée</a> que l’attaquant, alors
  <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> ne fonctionne pas. Par exemple, si le <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a> est attaqué par des <a class='nova' href='/fr/Unit/Nova.aspx'>Nova</a>ayant une<a href='/fr/Battles/Range.aspx'>Portée</a> de 5, il n’y a pas de riposte,
  car une <a href='/fr/Battles/Range.aspx'>Portée</a> de 3 est insuffisante. Il existe un dernier car où <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> ne fonctionne pas : quand une unité
  (eg: <a class='pretorian' href='/fr/Unit/Pretorian.aspx'>Prédateur</a>) avec l’aptitude <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> est atteinte à l’aide de l’aptitude <a href='/fr/Battles/Rebound.aspx'>Rebond</a>.
    </div>
	
</asp:Content>