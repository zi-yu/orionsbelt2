var undo = new Undo();

function Undo() {
	this.undo = function() {
		var movesMade = $("movesMade");
		if( $("movesMade").value == "" ) {
			return;
		}
		var m = movesMade.value.split(";");
		movesMade.value = "";
		for( var i = 0; i < m.length-2 ; ++i ) {
			movesMade.value += m[i] + ";";
		}
		
		this.parseMove( m[m.length-2] );
	}
	
	this.reset = function() {
		var movesMade = $("movesMade");
		if(movesMade.value == "" ) {
			return;
		}
		
		var m = movesMade.value.split(";");
		movesMade.value = "";
		for( var i = m.length-2; i >= 0; --i ) {
			this.parseMove( m[i] );
		}
	}
	
	this.parseMove = function( move ) {
		var m = move.split(":");
		params = m[1].split("-");

		undo[m[0]]( params );
	}

	this.m = function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		var quant = Number(params[2]);
		var position = params[3];
		var dstQuant = Number(dst.getQuantity());
		
		var moveCost = 1;
		if( src.hasChildNodes() ) {
			src.setQuantity( src.getQuantity() + quant );
			moveCost = 2;
		} else {
			src.removeAll();
			src.insert(dst, quant );
		}
		
		src.setPosition(position);
		var cost = src.unit().movementCost * moveCost;
		movesObj.incrementMoves( cost );
		
		src.hasAttacked = dst.hasAttacked;
		BattleElements[src.id] = BattleElements[dst.id];
		Utils.updateSpecialEffectsImages(dst,src);
		if( lastSelection != null ) {
			lastSelection.setClass("");
			lastSelection = null;
		}
		
		if( dstQuant > quant ) {
			dst.setQuantity( dstQuant - quant );
		}else{
			if( dstQuant == quant || dstQuant < quant ) {
				dst.removeAll();
				dst.insertSpace();
				dst.node.item = null;
				delete BattleElements[dst.id];
			}
		}	
	}
	
	this.bk = function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		var quant = Number(params[2]);
		var position = params[3];
		var dstQuant = Number(dst.getQuantity());
		
		if( src.hasChildNodes() ) {
			src.setQuantity( src.getQuantity() + quant );
		} else {
			src.removeAll();
			src.insert(dst, quant );
		}
		
		src.setPosition(position);
		movesObj.incrementMoves( Unit["blinker"].movementCost );
		
		src.hasAttacked = dst.hasAttacked;
		if( lastSelection != null ) {
			lastSelection.setClass("");
			lastSelection = null;
		}
		
		BattleElements[src.id] = BattleElements[dst.id];
		if( dstQuant > quant ) {
			dst.setQuantity( dstQuant - quant );
		}else{
			if( dstQuant == quant || dstQuant < quant ) {
				dst.removeAll();
				dst.insertSpace();
				dst.node.item = null;
				delete BattleElements[dst.id];
			}
		}	
	}
	
	this.e = function( params ) {
	    var dst = Utils.getItem($(params[0]));
	    dst.removeAll();
	    movesObj.incrementMoves( Unit["queen"].movementCost );
	}
	
	this.r = function( params ) {
		var src = Utils.getItem($(params[0]));
		var oldpos = params[1];
		var newpos = params[2];
		
		src.setPosition( oldpos );
		movesObj.incrementMoves( 1 );
	}
	
	this.b = function( params ) {
		var src = Utils.getItem($(params[0]));
		src.hasAttacked = false;
		movesObj.incrementMoves( src.unit().attackCost );
	}
}