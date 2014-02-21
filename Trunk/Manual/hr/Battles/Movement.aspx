<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pokret
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Borbeni Koncepti</h2><ul><li><a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a></li><li><a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a></li><li><a href='/hr/Battles/Movement.aspx'>Pokret</a></li><li><a href='/hr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Napad</h2><ul><li><a href='/hr/Battles/Range.aspx'>Domet</a></li><li><a href='/hr/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/hr/Battles/ParalyseAttack.aspx'>Napad Paralize</a></li><li><a href='/hr/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/hr/Battles/StrikeBack.aspx'>Protunapad</a></li><li><a href='/hr/Battles/InfestationAttack.aspx'>Napad Obuzetosti</a></li><li><a href='/hr/Battles/RemoveAbilityAttack.aspx'>Makni Sposobnost Napad</a></li><li><a href='/hr/Battles/TripleAttack.aspx'>Trostruki Napad</a></li><li><a href='/hr/Battles/BombAttack.aspx'>Napad Bombom</a></li><li><a href='/hr/Battles/Rebound.aspx'>Povratni</a></li></ul><h2>Kategorija</h2><ul><li><a href='/hr/Battles/Light.aspx'>Lagani</a></li><li><a href='/hr/Battles/Medium.aspx'>Srednji</a></li><li><a href='/hr/Battles/Heavy.aspx'>Teški</a></li><li><a href='/hr/Battles/Ultimate.aspx'>Ultimativni</a></li><li><a href='/hr/Battles/Special.aspx'>Izvanredni</a></li></ul><h2>Tip Bitke</h2><ul><li><a href='/hr/Battles/TotalAnnihilation.aspx'>Totalno Uništenje</a></li><li><a href='/hr/Battles/Regicide.aspx'>Regicid</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Borbeni Pokreti</h1>
<div class="content">
Borneni pokreti  odnose se na čin pokretanja <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> nakon završavanja <a href='/hr/Battles/Deploy.aspx'>Raspoređivanje</a>.
Svaka jedinica ima svoj jedinstveni tip pokreta, a ti mogu biti jedni od sljedećih:
<ul><li><a href='/hr/Battles/Movement.aspx#MovAll'>Totalni Pokret</a></li><li><a href='/hr/Battles/Movement.aspx#MovNormal'>Normalni Pokret</a></li><li><a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a></li><li><a href='/hr/Battles/Movement.aspx#MovFront'>Frontalni Pokret</a></li><li><a href='/hr/Battles/Movement.aspx#MovDrop'>Pokret Ispuštanja</a></li><li><a href='/hr/Battles/Movement.aspx#MovNone'>Bez Pokreta</a></li></ul>
Tip pokreta i <a href='/hr/Battles/Movement.aspx#MovCost'>Cijena Pokreta</a> definiraju brzinu jedinice.

 <a name="MovAll" id="MovAll"></a><h2><a href='/hr/Battles/Movement.aspx#MovAll'>Totalni Pokret</a></h2> 
Sa <a href='/hr/Battles/Movement.aspx#MovAll'>Totalni Pokret</a> jedinca se može pokrenuti na bilo koji pridruženi kvadrat. Primjer:
<img class="block" src="/Resources/Images/MovAll.png" alt="Mov All" /><a name="MovNormal" id="MovNormal"></a><h2><a href='/hr/Battles/Movement.aspx#MovNormal'>Normalni Pokret</a></h2>
Sa <a href='/hr/Battles/Movement.aspx#MovNormal'>Normalni Pokret</a> jedinica se može pomaknuti na bilo koji pridruženi kvadrat, osim dijagonalnih. Primjer:
<img class="block" src="/Resources/Images/MovNormal.png" alt="Mov Normal" /><a name="MovDiagonal" id="MovDiagonal"></a><h2><a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a></h2>
Sa <a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a> jedinica se može pomicati samo dijagonalno (pazite se <a href='/hr/Battles/DiagonalTrap.aspx'>Dijagonalna Zamka</a>). Primjer:
<img class="block" src="/Resources/Images/MovDiagonal.png" alt="Mov Diagonal" /><a name="MovFront" id="MovFront"></a><h2><a href='/hr/Battles/Movement.aspx#MovFront'>Frontalni Pokret</a></h2>
Sa <a href='/hr/Battles/Movement.aspx#MovFront'>Frontalni Pokret</a> jedinica se može pokretati prema naprijed. Ako trebate promjeniti smjer, trebete promjeniti smjer onda trebate upotrijebiti rotaciju. Primjer:
<img class="block" src="/Resources/Images/MovFront.png" alt="Mov Front" /><a name="MovDrop" id="MovDrop"></a><h2><a href='/hr/Battles/Movement.aspx#MovDrop'>Pokret Ispuštanja</a></h2>
Jedinica sa pokretom <a href='/hr/Battles/Movement.aspx#MovDrop'>Pokret Ispuštanja</a> je jedinica koja može ispustiti drugu jedinicu na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a> sa pokretom.
Primjer: <a class='queen' href='/hr/Unit/Queen.aspx'>Kraljica</a> može ispustiti <a class='egg' href='/hr/Unit/Egg.aspx'>Jaje</a> na  <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>.

<a name="MovNone" id="MovNone"></a><h2><a href='/hr/Battles/Movement.aspx#MovNone'>Bez Pokreta</a></h2>
Jedinica sa <a href='/hr/Battles/Movement.aspx#MovNone'>Bez Pokreta</a> ne može se micati tokom bitke. Primjer:
<img class="block" src="/Resources/Images/MovNone.png" alt="Mov Nove" /><a name="MovCost" id="MovCost"></a><h2><a href='/hr/Battles/Movement.aspx#MovCost'>Cijena Pokreta</a></h2>
<a href='/hr/Battles/Movement.aspx'>Pokret</a> tip definira kako se jedinica može micati na <a href='/hr/Battles/GameBoard.aspx'>Tabla Igre</a>, ali sve <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> također imaju <a href='/hr/Battles/Movement.aspx#MovCost'>Cijena Pokreta</a> što se prevodi u njihovu brzinu. U svakom turnu bitke, igrač ima 6 <a href='/hr/Battles/Movement.aspx#MovPoints'>Bodovi Pokreta</a> za potrošiti: on može micati jedinice, napadati jedinice, ili čak ne činiti ništa.
Ako jedinica ima <a href='/hr/Battles/Movement.aspx#MovCost'>Cijena Pokreta</a> 2, to znači da je možemo pomaknuti 3 puta u istome turnu (6/2=3).
Na primjer, <a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a> ima cijenu 3 i <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a> ima cjenu 2. Ovo čini <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a> bržim od <a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a>, iako obje jedinice dijele tip pokreta <a href='/hr/Battles/Movement.aspx#MovDiagonal'>Dijagonalni Pokret</a>.
<a name="MovPoints" id="MovPoints"></a><h2><a href='/hr/Battles/Movement.aspx#MovPoints'>Bodovi Pokreta</a></h2>
<a href='/hr/Battles/Movement.aspx#MovPoints'>Bodovi Pokreta</a> predsravljaju koliko pokreta možete izvesti u vašem turnu bitke. Na svakom turnu dobit ćete šest <a href='/hr/Battles/Movement.aspx#MovPoints'>Bodovi Pokreta</a> za potrošiti, i postoji nekoliko akcija koje možete izvesti:
<ul><li>Napad se cijenom pokreta od 1 boda pokreta</li><li>Cijena pokretanja borbene jedince ovisi o tipu borbene jedinice. Sve <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a> imaju definirani <a href='/hr/Battles/Movement.aspx#MovCost'>Cijena Pokreta</a></li><li> Razdvajanje grupe neke jedinice košta duplo više nego pokretanje te grupe.</li></ul></div>
	
</asp:Content>