
var Advertising = {
   index:0,
   bootstrap: function()
   {
        if(null != window.Auction && 1 < window.Auction.length)
        { 
            for( var i = 0; i < 10; ++i ) {
                Advertising.fetchData();
            }
            setInterval('Advertising.fetchData();', 3000);
        }
   },
   
   fetchData: function()
   {
        if(Advertising.index >= window.Auction.length-1)
        {
            Advertising.index=0;
        }
        var obj = window.Auction[++Advertising.index];
        var table = $('ahAd');
        
        var newTr = new Element("tr", {styles:{opacity:0}});
        var parent = table.getElement('tr').getParent();
	    newTr.inject(parent);
	    
	    var newTd = new Element("td", {html:obj.quant});
	    newTd.inject(newTr);
	    newTd = new Element("td", {html:"<img class='smallShip' src='"+Utils.resolveImage(obj.name)+"' alt='obj.name' title='obj.name'/>"});
	    newTd.inject(newTr);
	    newTd = new Element("td", {html:obj.bid});
	    newTd.inject(newTr);
	    newTd = new Element("td", {html:obj.buy});
	    newTd.inject(newTr);
	    
        var fx = new Fx.Tween(newTr, {property: 'opacity', duration: 1000});
        if(parent.getChildren().length > 11)
        {
            parent.getElements('tr:nth-child(2)').dispose();
        }
        fx.start(1);
        
   }
};

window.addEvent('domready', Advertising.bootstrap);
