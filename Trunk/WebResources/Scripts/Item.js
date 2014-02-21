if($("imagePath")){
    var unitPath = $("imagePath").value+"/Units/";
}
function Item(element) {
	this.id = element.id;
	this.node = element;
	this.hasAttacked = false;
	this.space = "span";
	
	this.x = function() {
		return this.id.split('_')[0];
	}
	
	this.y = function() {
		return this.id.split('_')[1];
	}
	
	this.isSpace = function() {
		return this.node.firstChild.nodeName.toLowerCase() == this.space;
	}
	
	this.insertSpace = function() {
		var spanElement = document.createElement(this.space);
		this.node.appendChild( spanElement );
	}
		
	this.getChildId = function() {
		return this.node.firstChild.id;
	}
	
	this.getQuantity = function() {
		return Number(this.node.firstChild.title);
	}
	
	this.setQuantity = function(value) {
		this.node.firstChild.title = value;
	}
	
	this.unitName = function() {
		return this.node.firstChild.alt;
	}
	
	this.unit = function() {
		return Unit[this.unitName()];
	}
	
	this.movementCost = function() {
		return Unit[this.node.firstChild.alt].movementCost;
	}
	
	this.insert = function( element, quantity, e ) {
	    this.setClass("");
		if( !this.hasChildNodes() )	{
			this.node.empty();
			var img = element.getImageElement();
		
			var imgElement = document.createElement("img");
			imgElement.src = element.getImage();
			imgElement.id = element.getChildId();
			imgElement.title = quantity;
			imgElement.alt = element.unitName();
			
			this.resolveEnemy(imgElement,img);
			this.resolveFriendly(imgElement,img);
			this.resolveInfestation(imgElement,img);
			
			this.node.appendChild(imgElement);
		}else{
			this.setQuantity( Number(this.getQuantity()) + Number(quantity) );
		}
	}
	
	this.insertSpecific = function( unit, quantity, e ) {
	    this.setClass("");
		if( !this.hasChildNodes() )	{
			this.node.empty();
			var name = unit.name.toLowerCase();
			var imgElement = new Element("img");
			imgElement.src = Utils.resolveUnitImage(name);
			imgElement.title = quantity;
			imgElement.alt = name;
			this.node.appendChild(imgElement);
		}
	}
	
	this.resolveEnemy = function( src, dst) {
	    var attr = dst.getAttribute("isEnemy");
	    if( attr != null ) {
		    src.setAttribute("isEnemy",attr);
		    if( attr == "true" ) {
		        this.node.addClass("enemyBorder");
		    }
		}
	}
	
	this.resolveFriendly = function( src, dst) {
	    var attr = dst.getAttribute("isFriendly");
	    if( attr != null ) {
		    src.setAttribute("isFriendly",attr);
		}
	}
	
	this.resolveInfestation = function( src, dst) {
	    var attr = dst.getAttribute("isInfestated");
	    if( attr != null ) {
		    src.setAttribute("isInfestated",attr);
		}
	}
	
	this.setClass = function( name ) {
		this.node.className = name;
	}
	
	this.getClass = function() {
		return this.node.className;
	}
	
	this.removeAll = function() {
		this.node.empty();
		this.setClass("");
		this.insertSpace();
	}
	
	this.hasChildNodes = function() {
		return this.node.hasChildNodes() && !this.isSpace();
	}
	
	this.getImage = function() {
		return this.getImageElement().src;
	}
	
	this.getImageElement = function() {
		return this.node.firstChild;		
	}
	
	this.getImageName = function() {
		var img = this.getImage();
		var imgArray = img.split("/");
		var name = imgArray[imgArray.length-1].split(".");
		return name[0];
	}
	
	this.getCleanImageName = function() {
		var name = this.getImageName();
		var pos = name.split("_");
		return pos[0].toLowerCase();
	}
	
	this.getPosition = function() {
		var name = this.getImageName();
		var pos = name.split("_");
		return pos[1];
	}
	
	this.setPosition = function( p ) {
		var pos = this.getCleanImageName();
		
		var image = unitPath + pos + "_" + p + ".png"
		this.node.firstChild.src = image;
	}
	
	this.equals = function( element ) {
		return element.unitName() == this.unitName();
	}
	
	this.isUltimateUnit = function() {
		var name = element.getFirst().getAttribute('isUltimate');
		return name == 'true';
	}
	
	this.isSource = function() {
		return this.id.split("_").length == 1;
	}
	
	this.parseBollAttr = function(attr) {
		if( this.hasChildNodes() ) {
			var img = this.node.firstChild;
			return img.getAttribute(attr) == "true";
		}
		return false;
	}
	
	this.isEnemyUnit = function() {
	    return this.parseBollAttr("isEnemy");
	}
	
	this.isFriendlyUnit = function() {
	    return this.parseBollAttr("isFriendly");
	}
	
	this.isInfestated = function() {
	    return this.parseBollAttr("isinfestated");
	}
	
	this.checkEffects = function() {
		var element = BattleElements[this.id];
		if( element ) {
			if( element.paralysed ) {
				RaiseError.paralysed();
				return true;
			}
		}
		return false;
	}
	
	this.isBlinker = function(){
	    return this.unitName() == "blinker";
	} 
	
	this.isQueen = function(){
	    return this.unitName() == "queen";
	} 
	
	this.canDeployEgg = function() {
	    var dest = this.id.split("_");
        return dest[0] == 7 || dest[0] == 8;
	}

}