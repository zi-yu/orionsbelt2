
var Ticker = {

    data : [],
    
    tickerPanel : null,
    
    elements : [],

    bootstrap : function(args) {
        if( $("tickerPlaceHolder") == null ) {
            return;
        }
        Ticker.tickerPanel = $("ticker");
        log.debug("Bootstrap Ticker...");
        Ticker.sendRequest(true);
        setInterval('Ticker.fetchData();', 750);
    },
    
    fetchData : function() {
        var value = Ticker.data.pop();
        log.debug("Fetching data... " );
        if( value != null ) {
            log.info(value);
            var newElem = new Element("li", {html:value,styles:{opacity:0}});
            newElem.inject(Ticker.tickerPanel, "top");
            var fx = new Fx.Tween(newElem, {property: 'opacity', duration: 500});
            fx.start(1);
            Ticker.elements.push(newElem);
        }
        
        if( Ticker.elements.length > 25 ) {
            var toRemove = Ticker.elements.shift();
            toRemove.dispose();
        }
    },
    
    updateTicker : function() {
        log.debug("Got response: " + (window.tickerData.length-1) + " items");
        for(var i = 1; i < window.tickerData.length; ++i ) {
            Ticker.data.push(window.tickerData[i]);
        }
        setTimeout('Ticker.sendRequest(false);', 1000 * 5);
    },

    sendRequest : function(bootstrap) {
        log.debug("Sending request to Ticker...");
        var url = "Ajax/Utils/Ticker.ashx";
        if( bootstrap ) {
            url += "?Bootstrap=1";
        }
        Utils.ajaxRequest('get', url, $("tickerPlaceHolder"), Ticker.updateTicker);
    }
  
};

window.addEvent('domready', Ticker.bootstrap);
