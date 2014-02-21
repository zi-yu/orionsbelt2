
var PositioningReset = {
	
	reset : function() {
		if( $("numberOfPlayers").value == "2" ) {
			PositioningReset.reset2();
		}else{
			PositioningReset.reset4();
		}
	},
	
	reset2 : function() {
		Positioning.cleanSelected();
		for( var i = 1; i < 9; ++i ) {
			PositioningReset.resetSector("7_"+i);
			PositioningReset.resetSector("8_"+i);
		}
	},
	
	reset4 : function() {
		Positioning.cleanSelected();
		for( var i = 3; i < 11; ++i ) {
			PositioningReset.resetSector("11_"+i);
			PositioningReset.resetSector("12_"+i);
		}
	},
	
	resetSector: function( id ){
		var e = $(id);		
		if( Utils.hasChilds(e) ) {
			var item = Utils.getItem(e);
			var newItem = new Item( $(item.unit().name.toLowerCase()) );
			
			newItem.insert( item, item.getQuantity(), null );
			
			item.removeAll();
			item.node.item = null;
		}
	}
}