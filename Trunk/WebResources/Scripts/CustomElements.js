var checkboxHeight = "25";
var radioHeight = "25";
var selectWidth = "190";

/* No need to change anything after this */

var Custom = {
    init: function() {
        var inputs = document.getElementsByTagName("input");
        var textnode;
        var option;
        var active;
        for (a = 0; a < inputs.length; a++) {
            Custom.initInput(inputs[a]);
        }

        inputs = document.getElementsByTagName("select");
        for (a = 0; a < inputs.length; a++) {
            Custom.initSelect(inputs[a]);
        }
    },

    initInput: function(input) {
        if ((input.type == "checkbox" || input.type == "radio") && input.className == "styled") {
            var span = document.createElement("span");
            span.className = input.type;

            if (input.checked == true) {
                if (input.type == "checkbox") {
                    position = "0 -" + (checkboxHeight * 2) + "px";
                    span.style.backgroundPosition = position;
                } else {
                    position = "0 -" + (radioHeight * 2) + "px";
                    span.style.backgroundPosition = position;
                }
            }
            input.parentNode.insertBefore(span[a], input);
            input.onchange = Custom.clear;
            span.onmousedown = Custom.pushed;
            span.onmouseup = Custom.check;
            document.onmouseup = Custom.clear;
        }
    },

    initSelect: function(select) {
        var value;
        if (select.selectedIndex >= 0) {
            value = select.options[select.selectedIndex].innerHTML;
        } else {
            value = "";
        }

        select.className = "styled";
        var span = document.createElement("span");
        span.className = "select";
        span.id = "select" + select.name;
        span.innerHTML = value;
        select.parentNode.insertBefore(span, select);
        select.correctOnChange = select.onchange;
        select.onchange = Custom.choose;

        Custom.initialChoose(select);

        if (navigator.userAgent.toLowerCase().indexOf('chrome') > -1) {
            var location = window.location + '';
            if (location.indexOf('AuctionHouse') > -1) {
                span.style.margin = "0px 0px 0px 0px";
                return;
            }
            if (location.indexOf('AddToAuction') > -1) {
                span.style.margin = "0px 0px 0px 120px";
                return;
            }
            if (location.indexOf('PaymentType.') > -1) {
                span.style.margin = "0px 0px 0px 190px";
                return;
            }
            if (location.indexOf('SearchPlayers.') > -1 || location.indexOf('CreateFriendly.') > -1) {
                span.style.margin = "0px 0px 0px 40px";
                return;
            }
            if (location.indexOf('CreateArena.') > -1) {
                span.style.margin = "0px 0px 0px 170px";
            }
            if (location.indexOf('Team.') > -1) {
                span.style.margin = "0px 0px 0px 40px";
            }
            if (location.indexOf('PaymentType.aspx?Type=Sms') > -1) {
                span.style.margin = "0px 0px 0px 120px";
                return;
            }
            
        }
    },

    pushed: function() {
        element = this.nextSibling;
        if (element.checked == true && element.type == "checkbox") {
            this.style.backgroundPosition = "0 -" + checkboxHeight * 3 + "px";
        } else if (element.checked == true && element.type == "radio") {
            this.style.backgroundPosition = "0 -" + radioHeight * 3 + "px";
        } else if (element.checked != true && element.type == "checkbox") {
            this.style.backgroundPosition = "0 -" + checkboxHeight + "px";
        } else {
            this.style.backgroundPosition = "0 -" + radioHeight + "px";
        }
    },

    check: function() {
        element = this.nextSibling;
        if (element.checked == true && element.type == "checkbox") {
            this.style.backgroundPosition = "0 0";
            element.checked = false;
        } else {
            if (element.type == "checkbox") {
                this.style.backgroundPosition = "0 -" + checkboxHeight * 2 + "px";
            } else {
                this.style.backgroundPosition = "0 -" + radioHeight * 2 + "px";
                group = this.nextSibling.name;
                inputs = document.getElementsByTagName("input");
                for (a = 0; a < inputs.length; a++) {
                    if (inputs[a].name == group && inputs[a] != this.nextSibling) {
                        inputs[a].previousSibling.style.backgroundPosition = "0 0";
                    }
                }
            }
            element.checked = true;
        }
    },
    clear: function() {
        inputs = document.getElementsByTagName("input");
        for (var b = 0; b < inputs.length; b++) {
            if (inputs[b].type == "checkbox" && inputs[b].checked == true && inputs[b].className == "styled") {
                inputs[b].previousSibling.style.backgroundPosition = "0 -" + checkboxHeight * 2 + "px";
            } else if (inputs[b].type == "checkbox" && inputs[b].className == "styled") {
                inputs[b].previousSibling.style.backgroundPosition = "0 0";
            } else if (inputs[b].type == "radio" && inputs[b].checked == true && inputs[b].className == "styled") {
                inputs[b].previousSibling.style.backgroundPosition = "0 -" + radioHeight * 2 + "px";
            } else if (inputs[b].type == "radio" && inputs[b].className == "styled") {
                inputs[b].previousSibling.style.backgroundPosition = "0 0";
            }
        }
    },

    choose: function() {
        if (this.correctOnChange != null) {
            this.correctOnChange();
        }

        var o = this.options[this.selectedIndex];
        document.getElementById("select" + this.name).innerHTML = o.innerHTML;
    },

    initialChoose: function(elem) {
        if (elem.selectedIndex >= 0) {
            var o = elem.options[elem.selectedIndex];
            document.getElementById("select" + elem.name).innerHTML = o.innerHTML;
        } else {
            document.getElementById("select" + elem.name).innerHTML = "";
        }
    }
}

window.addEvent('domready', function() {
	Custom.init();
});