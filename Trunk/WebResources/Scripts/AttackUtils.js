var AttackUtils = {
	
	attack : function () {
		if( globalCounter == 1 ) {
			RaiseError.attackFirstMove();
			return;
		}
		
		var isUltimateUnit = lastSelection.isUltimateUnit();
				
		if( isUltimateUnit && !movesObj.hasValidMoves(6) ) {
			RaiseError.ultimateUnitAttack();
			Information.fixed = false;
			return;
		}
			
		if( !lastSelection.hasAttacked ) {
			lastSelection.hasAttacked = true;
			Utils.registerAttack(lastSelection,currentEnemy);
			$("enemy").className = "invisible";
						
			movesObj.decrementMoves(lastSelection.unit().attackCost);
					
			lastSelection.setClass("");
			lastSelection = null;
			Information.eraseAttackInfo();
			Information.fixed = false;
		}
	},
	
	canAttack : function( dst ) {
		if( lastSelection != null && !lastSelection.hasAttacked )  {	
		    var unit = lastSelection.unit();
		    if( !unit.canAttack ) {
		        return false;
		    }
		
			var src = lastSelection.id.split("_");
			var r = unit.range;
			var attack = new Attack( src, dst, r, unit );
			
			var can = attack[lastSelection.getPosition()]();
			if ( can ) {
				Information.fillAttackInfo( src, dst );
			}
			return can;
		}
		return false;
	},
	
	calculatePenalty : function( damage, src, dst) {
		var distance = AttackUtils.penalty(src,dst);
		if( distance < 4 ) {
			return damage;
		}
		var percent = (7 - distance)*0.25;
		
		return Math.round( (percent * damage) + 0.5 );
	},
	
	calculatePenaltyByDistance : function( damage, distance) {
		if( distance < 4 ) {
			return damage;
		}
		var percent = (7 - distance)*0.25;
		
		return Math.round( (percent * damage) + 0.5 );
	},
	
	penalty : function( src, dst) {
		
		var s_x = Number(src[0]);
		var s_y = Number(src[1]);
		
		var d_x = Number(dst[0]);
		var d_y = Number(dst[1]);
		
		if( s_x == 9 ) {
			return Math.abs(s_x-d_x);
		}
		
		if( s_y == d_y ) {
			return Math.abs(s_x-d_x);
		}
		return Math.abs(s_y-d_y);
	},
	
	addBonusAttack : function(object, attack, target, terrain ) {
		attack += AttackUtils.addUp( object.attackTargets, target.name );
		attack += AttackUtils.addUp( object.attackTargets, target.category );
		attack += AttackUtils.addUp( object.attackTargets, terrain );
		attack += AttackUtils.addUp( object.attackTargets, target.level );
		attack += AttackUtils.addUp( object.attackTargets, target.type );
		
		return attack;
	},

	addBonusDefense : function(object, defense, target, terrain ) {
		defense += AttackUtils.addUp( object.defenseTargets, target.name );
		defense += AttackUtils.addUp( object.defenseTargets, target.category );
		defense += AttackUtils.addUp( object.defenseTargets, terrain );
		defense += AttackUtils.addUp( object.defenseTargets, target.level );
		defense += AttackUtils.addUp( object.defenseTargets, target.type );
		
		return defense;
	},
	
	addBonusRange : function(object, range, target, terrain ) {
		range += AttackUtils.addUp( object.rangeTargets, target.name );
		range += AttackUtils.addUp( object.rangeTargets, target.category );
		range += AttackUtils.addUp( object.rangeTargets, terrain );
		range += AttackUtils.addUp( object.rangeTargets, target.level );
		range += AttackUtils.addUp( object.rangeTargets, target.type );
		
		return range;
	},

	getAttack : function( target, terrain ) {
		return AttackUtils.addBonusAttack( this,this.baseAttack, target, terrain);
	},

	getDefense : function( target, terrain ){
		return AttackUtils.addBonusDefense( this,this.baseDefense,target, terrain);
	},
	
	getRange : function( target, terrain ){
		return AttackUtils.addBonusRange( this,this.range,target, terrain);
	},
	
	addUp : function( hash, key ){
		if( hash == null ) {
			return 0;
		}
		
		var specific = hash[key];
		if( specific == null ) {
			return 0;
		}
		return specific;
	},
	
	ultimateUnitAttackCoord : function() {
	    if( Utils.numberOfPlayers() == 2 ) {
	        return 9;
	    }
	    return 13;
	}
}