
//movesList
//finalState

var Replay = {
	currentTurn : 0,
	currentMove : -1,
	space : "span",
	
	isTheEnd : function() {
		return movesList.length == Replay.currentTurn;
	},
	
	isTheBeginning : function() {
		return Replay.currentTurn <= 0&& Replay.currentMove < 0;
	},
	
	incrementTurn : function() {
		if( Replay.currentTurn < movesList.length ) {
			++Replay.currentTurn;
		}
		var turnElem = $('turn');
		if( turnElem != null ) {
		    turnElem.innerHTML = Replay.currentTurn;
		}
	},
	
	decrementTurn : function() {
		if( Replay.currentTurn > 0 ) {
			--Replay.currentTurn;
		}
		$('turn').innerHTML = Replay.currentTurn;
	},
		
	forward : function() {
		Utils.hideImage("enemy");
		if( Replay.isTheEnd() ) {
			return;
		}
		
		var mList = movesList[Replay.currentTurn];
				
		Replay.resolveForwarReplay(mList);
	},
	
	resolveForwarReplay : function(mList) {
		var m = mList.split(";");
		if( Replay.currentMove >= m.length-1 ) {
			Replay.nextTurn();
		}else{
			var move = m[++Replay.currentMove];
			if( move != "" ) {
				Replay.parseMoveForward( move );
			}else{
				Replay.nextTurn();
			}
		}
	},
	
	backward : function() {
		Utils.hideImage("enemy");
		if( Replay.isTheBeginning() ) {
			return;
		}
		
		if( Replay.currentMove < 0 ) {
			if( Replay.currentTurn > -1 ) {
				Replay.previousTurn();
				return;
			}
		}
		
		var mList = movesList[Replay.currentTurn]
		if( mList == "") {
			Replay.decrementTurn();
			return;
		}
			
		var m = mList.split(";");
		Replay.parseMoveBackward( m[Replay.currentMove] );
		--Replay.currentMove;
	},
	
	nextTurn : function() {
		Replay.incrementTurn();
		Replay.currentMove = -1;
		Replay.loadCurrentTurn(0);
	},
	
	previousTurn : function() {
		Replay.loadCurrentTurn(1);
		Replay.decrementTurn();		
		var mList = movesList[Replay.currentTurn];
		if( mList != "" ) {
			var m = mList.split(";");
			for( var i = 0; i < m.length ; ++i  ) {
				var move = m[i];
				if( move != "" ) {
					Utils.hideImage("enemy");
					Replay.parseMoveForward( move );
				}
			}
			Replay.currentMove = m.length-2;
		}else{
			Replay.currentMove = -1;
		}
	},
	
	loadLastTurn : function() {
		Replay.currentTurn = movesList.length;
		Replay.currentMove = -1;
		Replay.loadCurrentTurn(0);
		
	},
	
	loadFirstTurn : function() {
		Replay.currentTurn = 0;
		Replay.currentMove = -1;
		Replay.loadCurrentTurn(1);
	},
	
	loadCurrentTurn : function(dec) {
		Utils.hideImage("enemy");
		Replay.cleanBoard();
		
		var current = Replay.currentTurn-dec;
		if( current < 0 ) {
			current = 0;
		}
		
		var turnElem = $('turn');
		if( turnElem != null ) {
		    turnElem.innerHTML = current;
		}
		
		var fs = finalState[current];
		var playerId = $('playerId').value;
			
		var fsList = fs.split(';');
		for( var i = 0; i < fsList.length; ++i ) {
			var fsElement = fsList[i];
			if( fsElement != '' ) {
				Replay.insertElement(fsElement,playerId);
			}
		}
	},
	
	cleanBoard : function() {
		var board;
		if( Utils.numberOfPlayers() == 2 ) {
			board = $('board2').getElements('td');
		}else{
			board = $('board4').getElements('td');
		}
		
		var areCoordinatesToIgnore = Utils.numberOfPlayers() == 4;
		
		board.each( function( td ) {
			if( !(areCoordinatesToIgnore && !Utils.coordinateValid(td.id)) ){
				td.empty();
				var spanElement = document.createElement(Replay.space);
				td.appendChild( spanElement );
				td.className = "";
			}
		});
	},
	
	insertElement : function( state, playerId ) {
		var e = state.split(':');
		var element = e[1].split('-');
		var unit = Unit[element[0]]();
		var td = $(element[1]);
		var quantity = element[2];
		var position = element[3].toLowerCase();
		
		var imgElement = document.createElement("img");
		imgElement.src = unitPath + unit.name.toLowerCase() + "_" + position + ".png"
		imgElement.title = quantity;
		imgElement.alt = unit.name.toLowerCase();	
		
		td.empty();
		td.appendChild(imgElement);	
		
		if( e[0] != playerId ) {
			if( Utils.numberOfPlayers() == 2 ) {
				td.className = "enemyBorder";
			}else{
				td.className = "enemyBorder"+e[0];
			}
		}
	},
	
	parseMoveForward : function( move ) {
		var m = move.split(":");
		params = m[1].split("-");

		Replay[m[0]]( params );
	},
	
	parseMoveBackward : function( move ) {
		var m = move.split(":");
		params = m[1].split("-");

		Replay[m[0]+"b"]( params );
	},

	m : function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		var quant = Number(params[2]);
		var dstQuant = Number(dst.getQuantity());
		var srcQuant = Number(src.getQuantity());
		
		var moveCost = 1;
		if( dst.hasChildNodes() ) {
			dst.setQuantity( dstQuant + quant );
			var sum = srcQuant - quant;
			if( sum == 0 ) {
				Replay.clearItem(src);
			}else{
				src.setQuantity( sum );
			}
		} else {
			if( srcQuant == quant ) {
				dst.removeAll();
				dst.insert(src, quant );
				dst.setClass( src.getClass() );	
				Replay.clearItem(src);
			}else{
				dst.insert(src, quant );
				dst.setClass( src.getClass() );	
				src.setQuantity( srcQuant - quant );
				moveCost = 2;
			}
		}
	},
	
	bk : function( params ) {
	    m(params);
	},
	
	r : function( params ) {
		var src = Utils.getItem($(params[0]));
		var newpos = params[2];
		
		src.setPosition( newpos.toLowerCase() );
	},
	
	b : function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		src.hasAttacked = true;
		
		Utils.showImage(dst,"enemy",null);
	},
	
	mb : function( params ) {
		var src = Utils.getItem($(params[0]));
		var dst = Utils.getItem($(params[1]));
		var quant = Number(params[2]);
		var srcQuant = Number(src.getQuantity());
		var dstQuant = Number(dst.getQuantity());
		
		var moveCost = 1;
		if( src.hasChildNodes() ) {
			src.setQuantity( srcQuant + quant );
			
			var sum = dstQuant - quant;
			if( sum == 0 ) {
				Replay.clearItem(dst);
			}else{
				dst.setQuantity( sum );
			}
			
			moveCost = 2;
		} else {
			if( dstQuant == quant ) {
				src.removeAll();
				src.insert(dst, quant );
				src.setClass( dst.getClass() );	
				Replay.clearItem(dst);
			}else{
				src.insert(dst, quant );
				src.setClass( dst.getClass() );	
				dst.setQuantity( dstQuant - quant );
			}
		}	
	},
	
	rb : function( params ) {
		var src = Utils.getItem($(params[0]));
		var oldpos = params[1];
		
		src.setPosition( oldpos.toLowerCase() );
	},
	
	bb : function( params ) {
		var src = Utils.getItem($(params[0]));
		src.hasAttacked = false;
		var dst = Utils.getItem($(params[1]));
		Utils.showImage(dst,"enemy",null);
	},
	
	clearItem : function(item){
		item.removeAll();
		item.setClass("");
		item.insertSpace();
		item.node.item = null;
	}
}