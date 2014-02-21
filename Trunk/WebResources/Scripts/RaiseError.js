var Message = {
	raiseAlert : function( key ) {
		var k = Language.getToken(key);
		var text = k;
		alert(text);
	},
	
	raiseConfirm : function( key ) {
		var k = Language.getToken(key);
		return confirm(k);
	},
	
	messageCallBack : function(responseTree, responseElements, responseHTML, responseJavaScript ) {
        if( responseHTML != '' ) {
            Message.raiseAlert(responseHTML);
        }
    }
}

var RaiseError = {
	
	alreadyAttacked : function() {
		Message.raiseAlert( "AlreadyAttacked");
	},
	
	invalidQuantity : function() {
		Message.raiseAlert("QuantityError");
	},
	
	attackFirstMove : function() {
		Message.raiseAlert("AttackFirstMove");
	},
	
	moves : function() {
		Message.raiseAlert("Moves");
	},
	
	ultimateUnitAttack : function() {
		Message.raiseAlert("UltimateUnitAttack");
	},
	
	unitsNotPositioned : function( result ) { 
		Message.raiseAlert("UnitsNotPositioned");
	},
	
	minimumMove : function(quantitySelected,unitName,minRest) {
		Message.raiseAlert("MinimumMove");
	},
	
	minimumRest : function(quantityRest,unitName,minRest) {
		Message.raiseAlert("MinimumRest");
	},
	
	noMovesToSplit : function(cost) {
	    var k1 = Language.getToken("NoMovesToSplit");
	    var k2 = Language.getToken("NoMovesToSplit2");
	    //alert(k1+" "+cost+" "+k2);
	},
	
	paralysed : function() { 
		Message.raiseAlert("Paralysed");
	},
	
	coolDown : function() { 
		Message.raiseAlert("CoolDown");
	},
	
	fleetInBattle : function() { 
		Message.raiseAlert("FleetInBattle");
	},
	
	cantPassWormHoles : function() {
	    Message.raiseAlert("FleetCantPassWormHole");
	},
	
	deploySaved : function() {
	    Message.raiseAlert("DeploySaved");
	},
	
	deployLoaded: function() {
	    Message.raiseAlert("DeployLoaded");
	},
	
	noDeploySaved: function() {
	    Message.raiseAlert("NoDeploySaved");
	},
	
	unloadCargoFleetInBattle: function() {
	    Message.raiseAlert("UnloadCargoFleetInBattle");
	},
	
	dropCargoFleetInBattle: function() {
	    Message.raiseAlert("DropCargoFleetInBattle");
	},
	
	invalidCoordinate : function() {
	    Message.raiseAlert("InvalidCoordinate");
	},
	
	needToSelectAFleetFirst : function() {
	    Message.raiseAlert("NeedToSelectAFleetFirst");
	},
	
	notDiscoveredCoordinate  : function() {
	    Message.raiseAlert("NotDiscoveredCoordinate");
	},
	
	fleetIsMoving : function() {
	    Message.raiseAlert("FleetIsMoving");
	},
	
	fleetAtMaximum : function() {
	    Message.raiseAlert("FleetAtMaximum");
	}
}