function Attack( source, dest, range, unit ) {
	this.r = range;
	this.s_x = Number(source[0]);
	this.s_y = Number(source[1]);
	this.d_x = Number(dest[0]);
	this.d_y = Number(dest[1]);
	this.unit = unit;
	
	this.checkPathVert = function( stat, src, dst ) {
	    var hasAbility = BattleElements[this.s_x+"_"+this.s_y].hasAbility;
		//hack para a battle moon
		var c = AttackUtils.ultimateUnitAttackCoord();
		if( stat == c ) { 
			stat = c-1;
		}
	
		for( var i = src; i < dst; ++i ) {
			var item = Utils.getItem($(i+"_"+stat));
			if( item.hasChildNodes() && !(unit.catapult && hasAbility) ) {
				return false;
			}
		}
		return true;
	}
	
	this.checkPathHoriz = function( stat, src, dst ) {
	    var hasAbility = BattleElements[this.s_x+"_"+this.s_y].hasAbility;
		for( var i = src; i < dst; ++i ) {
			var item = Utils.getItem($(stat+"_"+i));
			if( item.hasChildNodes() && !(unit.catapult && hasAbility) ) {
				return false;
			}
		}
		return true;
	}
	
	this.n = function() {
		var v = this.s_x-this.r;
		
		if( v <= 0 && this.d_x == 0 && this.d_y == 0) {
			return this.checkPathVert(this.s_y,this.d_x+1,this.s_x)
		}
		
		if( this.checkPathVert(this.s_y,this.d_x+1,this.s_x) ){
			var first = this.d_x < this.s_x && this.d_x >= v;
			if( this.s_y == AttackUtils.ultimateUnitAttackCoord() ) {
				return first;
			}
			return  first && this.s_y == this.d_y;
		}
		return false;
	}
	
	this.s = function() {
		var v = this.s_x+this.r;
		if( this.checkPathVert(this.s_y,this.s_x+1,this.d_x) ){
			return this.d_x > this.s_x && this.d_x <= v && this.s_y == this.d_y;
		}
		return false;
	}
	
	this.w = function() {
		var v = this.s_y-this.r;
		if( this.checkPathHoriz(this.s_x,this.d_y+1,this.s_y) ) {
			return this.d_y < this.s_y && this.d_y >= v && this.s_x == this.d_x;
		}
		return false;
	}
	
	this.e = function() {
		var v = this.s_y+this.r;
		if( this.checkPathHoriz(this.s_x,this.s_y+1,this.d_y) ) {
			return this.d_y > this.s_y && this.d_y <= v && this.s_x == this.d_x;
		}
		return false;
	}
}