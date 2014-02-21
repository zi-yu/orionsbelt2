var divCurr = $("firstDiv");
var divBackup = $("secondDiv");

var currImage,oldImage;
var fadeInterval,loadImage;

var SlideShow = {
    type : '',
    deltaWidth:0,
    deltaHeight:0,
    interval:0,
    
    loadFirstImage : function() {
        SlideShow.type = SlideShow.getType(Utils.queryString("Type"));
        SlideShow.type = SlideShow.type.substr(0,1).toUpperCase() + SlideShow.type.substr(1,SlideShow.type.length);
        var image = shots[currIndex];
        SlideShow.loadPassedImage(image,"1");
    },
    
    loadPassedImage : function(image,first) {
        oldImage = currImage;
        currImage = new Image();
        currImage.src = SlideShow.getImage(image);
        
        SlideShow.loadImage(first);
    },
    
    loadImage : function(first){
        if( currImage.complete) {
            if(first == "1"){
                divBackup.setStyles({"opacity":1,"margin":"auto","width":currImage.width,"height":currImage.height});
                divCurr.setStyles({"opacity":1,"width":currImage.width,"height":currImage.height,"backgroundImage":"url('"+currImage.src+"')"});
            }else{
                divBackup.setStyles({"margin":"auto","opacity":1,"width":oldImage.width,"height":oldImage.height,"backgroundImage":divCurr.style.backgroundImage});
                divCurr.setStyles({"opacity":0,"width":oldImage.width,"height":oldImage.height,"backgroundImage":"url('"+currImage.src+"')"});
                SlideShow.deltaWidth = currImage.width - oldImage.width;
                SlideShow.deltaHeight = currImage.height - oldImage.height;
                if( SlideShow.deltaWidth == 0 && SlideShow.deltaHeight == 0 ) {
                    divCurr.fade("in");
                }else{
                    log.debug("setTimeout");
                    fadeInterval = setInterval("SlideShow.fadeIn()",50);
                }
            }
        }else{
            loadImage = setTimeout("SlideShow.loadImage('"+first+"')",200);
        }
    },
    
    getImage : function(name) {
        return $("instImagePath").value + SlideShow.type + "/" + name;
    },
    
    getType : function(type) {
        if(type == "artwork"){
            return "ArtWork";
        }
        return "ScreenShots";
    },
    
    loadImages : function(currentImage,currIndex, loadImage) {
	    nextShot = new Image();
	    nextShot.src = SlideShow.getImage( (shots[currIndex+1]) ? shots[currIndex+1] : shots[0] );
	    prevShot = new Image();
	    prevShot.src = SlideShow.getImage( (shots[currIndex-1]) ? shots[currIndex-1] : shots[shots.length-1] );
    },
    
    incrementIndex : function() {
        ++currIndex;
        if(currIndex == shots.length) {
            currIndex = 0;
        }
    },
    
    decrementIndex : function() {
        --currIndex;
        if(currIndex == 0) {
            currIndex = shots.length-1;
        }
    },
    
    next : function() {
        SlideShow.incrementIndex();       
        SlideShow.loadPassedImage(shots[currIndex],"0");
    },
    
    previous : function() {
        SlideShow.decrementIndex();       
        SlideShow.loadPassedImage(shots[currIndex],"0");
    },
    
    fadeIn : function() {
        if(SlideShow.interval > 100 ) {
            window.clearInterval(fadeInterval);
            SlideShow.interval = 0;
	    }else{
	        var opacity = SlideShow.interval/100;
	        
	        var width = (oldImage.width+(SlideShow.deltaWidth*SlideShow.interval/100))+"px";
	        var height = (oldImage.height+(SlideShow.deltaHeight*SlideShow.interval/100))+"px";
	        
	        divCurr.setStyles({"opacity":opacity,"width":width,"height":height});
	        divBackup.setStyles({"width":width,"height":height});

		    SlideShow.interval += 10;
	    }
    }
};

window.addEvent('domready', function() {
    if( window.shots != null )  {
	    SlideShow.loadFirstImage();
	}
});