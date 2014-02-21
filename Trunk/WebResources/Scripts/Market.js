window.addEvent('domready', function(){
    var market = $('marketTable');
    if( market != null) {
        market.getElements('tr>td>input[type=text]').addEvent('keyup', function(event)
        {
            this.value = ClearAlphas(this.value);
            this.getNext('div').lastChild.innerHTML = this.value * this.parentNode.previousSibling.previousSibling.innerHTML;
        });
    }
});

function ClearAlphas(repString) {
    
    var toReturn="";
    
    for(var iter = 0; iter < repString.length; ++iter)
    {
        var num_test=parseFloat(repString[iter]);
        if(!isNaN(num_test))
        {
            toReturn += repString[iter];
        }
    }
    return toReturn;
}

function AHFilter(){
    var hidden = $('searchChange');
    hidden.value = 1;
}