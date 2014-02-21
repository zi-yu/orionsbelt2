
function Moves() {
	this.moveElement = $("moves");

	this.none = function( src, dst ) {
		return false;
	}
	
	this.all = function( src, dst ) {
		var s_x = Number(src[0]);
		var s_y = Number(src[1]);
		var d_x = Number(dst[0]);
		var d_y = Number(dst[1]);

		if( d_x <= s_x + 1 && d_x >= s_x - 1 ) {
			if( d_y <= s_y + 1 && d_y >= s_y - 1 ) {
				return true;
			}
		}
		return false;
	}
	this.normal = function( src, dst ) {
		var s_x = Number(src[0]);
		var s_y = Number(src[1]);
		var d_x = Number(dst[0]);
		var d_y = Number(dst[1]);

		if( d_x <= s_x + 1 && d_x >= s_x - 1 && s_y == d_y ) {
			return true;
		} 
		
		if( d_y <= s_y + 1 && d_y >= s_y - 1 && s_x == d_x ) {
			return true;
		}
		return false;
	}
	
	this.front = function( src, dst ) {
		return this[lastSelection.getPosition()](src,dst);
	}
	
	this.blink = function( src, dst ) {
		var d_x = Number(dst[0]);
		return d_x > 4;
	}
	
	this.diagonal = function( src, dst ) {
		var s_x = Number(src[0]);
		var s_y = Number(src[1]);
		var d_x = Number(dst[0]);
		var d_y = Number(dst[1]);

		return d_x == s_x+1 && d_y == s_y+1 ||
			d_x == s_x-1 && d_y == s_y-1 ||
			d_x == s_x+1 && d_y == s_y-1 ||
			d_x == s_x-1 && d_y == s_y+1;
	}
	this.drop = function(src,dst){
	    
	}
	
	this.n = function(src, dst) {
		var s_x = Number(src[0]);
		var d_x = Number(dst[0]);
		var s_y = Number(src[1]);
		var d_y = Number(dst[1]);
			
		return d_x == s_x-1 && s_y == d_y;
	}
	this.s = function(src, dst) {
		var s_x = Number(src[0]);
		var d_x = Number(dst[0]);
		var s_y = Number(src[1]);
		var d_y = Number(dst[1]);
			
		return d_x == s_x+1  && s_y == d_y;			
	}
	
	this.w = function(src, dst) {
		var s_y = Number(src[1]);
		var d_y = Number(dst[1]);
		var s_x = Number(src[0]);
		var d_x = Number(dst[0]);
		
		return d_y == s_y-1 && s_x == d_x;
	}
	this.e = function(src, dst) {
		var s_y = Number(src[1]);
		var d_y = Number(dst[1]);
		var s_x = Number(src[0]);
		var d_x = Number(dst[0]);
		
		return d_y == s_y+1 && s_x == d_x;
	}
	
	this.incrementMoves = function( quant ) {
		var mValue = Number( this.moveElement.innerHTML );
		this.moveElement.innerHTML = mValue + quant;
	}
	
	this.decrementMoves = function( quant ) {
		var mValue = Number( this.moveElement.innerHTML );
		this.moveElement.innerHTML = mValue - quant;
	}
	
	this.hasMoves = function( quant ) {
		var m = Number( this.moveElement.innerHTML );		

		if( m < quant ) {
			RaiseError.moves();
			return false;
		}
		return true;
	}
	
	this.silentHasMoves = function( quant ) {
		var m = Number( this.moveElement.innerHTML );		

		if( m < quant ) {
			return false;
		}
		return true;
	}
	
	this.hasValidMoves = function( quant ) {
		var m = Number( this.moveElement.innerHTML );		
		if( m < quant ) {
			return false;
		}
		return true;
	}
	
	this.decrementMoves = function( quant ) {
		var mValue = Number( this.moveElement.innerHTML );
		this.moveElement.innerHTML = mValue - quant;
	}
}

var movesObj = new Moves();