var FleetCargo = {
    fleetCargos: null,
    quantityInput : null,
    currentClone : null,
    currentItem : null,
    changeLog : "",
        
    load : function() {
        FleetCargo.fleetCargos = $$(".fleetCargo");
        
	    if( FleetCargo.fleetCargos.length > 0  ) {
            FleetCargo.fleetCargos.each( function(item){
                FleetCargo.setCargoDrag(item);
            });
            
            $('transferCargoQuantity').addEvent('click',FleetCargo.transferQuantity);
            $('cancelCargoTransfer').addEvent('click',FleetCargo.clearTransferInfo);
            FleetCargo.quantityInput = $('quantityCargo');
        }
    },
   
    setCargoDrag : function(parent) {
        var element = parent.getPrevious('div');
        parent.getElements('div').each(function(item){
            if(item.hasClass('cargoList')){
                item.addEvent('mousedown', function(e) {
                    if(element == null) {
                        return;
                    }
                    
                    if( Fleet.isInBattle(element) ){
                        RaiseError.fleetInBattle();
                        return;
                    }
                    
                    if( Fleet.isMoving(element) ){
                        RaiseError.fleetIsMoving();
                        return;
                    }
                    FleetCargo.resourceClick(this, parent, e );
                });
            }
        });
    },
    
    resourceClick : function(item, parent, e) {
        var clone = Fleet.getClone(item);
		
		var drag = clone.makeDraggable({
			droppables: FleetCargo.fleetCargos,
            onDrop: function(element, droppable){
                if(droppable == null) {
                    clone.dispose();
                    return;
                }
                if( FleetCargo.isInBattle(droppable) ) {
                    RaiseError.fleetInBattle(); 
                    clone.dispose();
                    droppable.removeClass('fleetCargoOver');
                    return;
                }
                
                if( FleetCargo.isMoving(droppable) ) {
                    RaiseError.fleetIsMoving(); 
                    clone.dispose();
                    droppable.removeClass('fleetCargoOver');
                    return;
                }
                            
                var p = item.getParent();
                                
                if (droppable && droppable != p && FleetCargo.isFleetAround(p,droppable) ) {
                    FleetCargo.dropCargoEvent(clone, item, droppable);
                }else{
                    clone.dispose();
                }
            },
            onEnter: function(element, droppable){
                var p = item.getParent();
                if( droppable != p && FleetCargo.isFleetAround(p,droppable) ) { 
                    droppable.addClass('fleetCargoOver');
                }
            },
            onLeave: function(element, droppable){
                if( droppable != parent ) { 
                    droppable.removeClass('fleetCargoOver');
                }
            }
		});
		
		drag.start(e);
    },
    
    
    isInBattle : function(element){
        return Fleet.isInBattle(element.getPrevious());
    },
    
    isMoving : function(element){
        return Fleet.isMoving(element.getPrevious());
    },
    
    isFleetAround : function(src, dst){
        return Fleet.isFleetAround(src.getPrevious(),dst.getPrevious());
    },
    
    clearTransferInfo : function() {
        var menu = $('quantityCargoSelector');
        menu.addClass('hidden');
        
        FleetCargo.currentClone.dispose(); 
        FleetCargo.currentDestiny.removeClass('fleetCargoOver');
        FleetCargo.currentClone = null;
        FleetCargo.currentItem = null;
        FleetCargo.currentDestiny = null;
    },
    
    dropCargoEvent : function( clone, item, destiny ) {
        if( FleetCargo.currentClone != null ) {
            FleetCargo.clearTransferInfo();
        }
    
        var menu = $('quantityCargoSelector');
        Menu.positionByElement(menu,clone,{x: 30, y: 30});
        menu.removeClass('hidden');
        FleetCargo.quantityInput.focus();
        FleetCargo.quantityInput.value = clone.getChildren('span')[0].innerHTML;
        FleetCargo.currentClone = clone;
        FleetCargo.currentItem = item;
        FleetCargo.currentDestiny = destiny;
    },
    
    transferQuantity : function() {
        var resourceName = FleetCargo.currentClone.getFirst().getAttribute("resourceName");
        var quantityToTransfer = Number(FleetCargo.quantityInput.value);
        var originalQuantity = Number(FleetCargo.getQuantity(FleetCargo.currentClone));
        
        if( quantityToTransfer > 0 && quantityToTransfer <= originalQuantity  ) {
            var added = FleetCargo.addQuantity(resourceName,quantityToTransfer);
            if(added){
                if( quantityToTransfer == originalQuantity ) {
                    FleetCargo.currentItem.destroy(); 
                }else{
                    var newQuant = Number(originalQuantity) - Number(quantityToTransfer);
                    FleetCargo.changeQuantity(FleetCargo.currentItem, newQuant);
                }
            }
            FleetCargo.clearTransferInfo();
        }else{
            RaiseError.invalidQuantity();
        }
    },
    
    getQuantity : function(element){
        return FleetCargo.getQuantitySpan(element).innerHTML;
    },
    
    getQuantitySpan : function(element){
        return element.getChildren('span')[0];
    },
    
    addQuantity : function(resourceName,quantity) {
        var added = false;
        
        var elements = FleetCargo.currentDestiny.getElements('.cargoList');
        
        elements.each(function(item){
            if( added ) {
                return;
            }
            var name = item.getFirst().getAttribute("resourcename");     
            if( name == resourceName ) {
                FleetCargo.registerChange(resourceName,quantity);
                var resourceQuantity = FleetCargo.getQuantity(item)
                var total = Number(resourceQuantity)+Number(quantity);
                FleetCargo.changeQuantity(item, total);
                added = true;
            }
        });
        if(added){
            return true;
        }
        
        var clone = FleetCargo.currentItem.clone();
        clone.addEvent('mousedown', function(e) {
            FleetCargo.resourceClick(this, FleetCargo.currentDestiny, e );
        });
        FleetCargo.currentDestiny.adopt(clone);
        FleetCargo.changeQuantity(clone, quantity);
        FleetCargo.registerChange(resourceName,quantity);
        return true;
    },
    
    changeQuantity: function(elem, quantity) {
        var img = elem.getFirst();
        img.setAttribute("quantity", quantity);
        var span = FleetCargo.getQuantitySpan(elem);
        span.empty();
        span.appendText(quantity);
    },
    
    registerChange : function(resourceName, quantity) {
        var srcId = FleetCargo.currentItem.getParent().getPrevious().getAttribute('fleetId');
        var dstId = FleetCargo.currentDestiny.getPrevious().getAttribute('fleetId');
        FleetCargo.changeLog += srcId + "-" + dstId + "-" + resourceName + "-" + quantity + ";";
        $('saveChanges').disabled = false;
    }
}