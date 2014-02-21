var Fleet = {
    fleetLists: null,
    quantityInput: null,
    currentClone: null,
    currentItem: null,
    changeLog: "",

    load: function() {
        Fleet.fleetLists = $$(".fleetUnits, .BattleMoonUnits, .BlinkerUnits, .QueenUnits");

        if (Fleet.fleetLists.length > 0) {
            Fleet.fleetLists.each(function(item) {
                Fleet.setDrag(item);
            });

            $('transferQuantity').addEvent('click', Fleet.transferQuantity);
            $('cancelTransfer').addEvent('click', Fleet.clearTransferInfo);
            $('saveChanges').addEvent('click', Fleet.saveChangesPlanet);
            $('saveChanges').disabled = true;

            Fleet.quantityInput = $('quantity');

            FleetCargo.load();
        }
    },

    sendRequest: function(args) {
        var url = Site.appPath + "Ajax/Fleet/Fleet.ashx?1=1";
        for (var propName in args) {
            if (propName != 'CallBack') {
                url += "&" + propName + "=" + args[propName];
            }
        }
        if (args.CallBack == null) {
            args.CallBack = Fleet.genericCallBack;
        }
        Utils.ajaxRequest('get', url, null, args.CallBack);
    },

    setDrag: function(parent) {
        parent.getElements('div').each(function(item) {
            item.addEvent('mousedown', function(e) {
                if (parent == null) {
                    return;
                }

                if (Fleet.isInBattle(parent)) {
                    RaiseError.fleetInBattle();
                    return;
                }

                if (Fleet.isMoving(parent)) {
                    RaiseError.fleetIsMoving();
                    return;
                }

                Fleet.unitClick(this, parent, e);
            });
        });
    },

    isInBattle: function(element) {
        var attr = element.getAttribute('isInBattle');
        return attr == "true";
    },

    isMoving: function(element) {
        var attr = element.getAttribute('isMoving');
        return attr == "true";
    },

    unitClick: function(item, parent, e) {
        var clone = Fleet.getClone(item);

        var drag = clone.makeDraggable({
            droppables: Fleet.fleetLists,
            onDrop: function(element, droppable) {
                if (droppable == null) {
                    clone.dispose();
                    return;
                }
                if (Fleet.isInBattle(droppable)) {
                    RaiseError.fleetInBattle();
                    clone.dispose();
                    droppable.removeClass('fleetUnitsOver');
                    return;
                }

                if (Fleet.isMoving(droppable)) {
                    RaiseError.fleetIsMoving();
                    clone.dispose();
                    droppable.removeClass('fleetUnitsOver');
                    return;
                }

                var p = item.getParent();

                if (droppable && droppable != p && Fleet.isFleetAround(p, droppable)) {
                    Fleet.dropEvent(clone, item, droppable);

                } else {
                    clone.dispose();
                }
            },
            onEnter: function(element, droppable) {
                var p = item.getParent();
                if (droppable != p && Fleet.isFleetAround(p, droppable)) {
                    droppable.addClass('fleetUnitsOver');
                }
            },
            onLeave: function(element, droppable) {
                if (droppable != parent) {
                    droppable.removeClass('fleetUnitsOver');
                }
            }
        });

        drag.start(e);
    },

    chooseClassToAdd: function(droppable) {
        if (droppable.hasClass("BattleMoonUnits")) {
            droppable.addClass('BattleMoonUnitsOver');
            return;
        }
        if (droppable.hasClass("BlinkerUnits")) {
            droppable.addClass('BlinkerUnitsOver');
            return;
        }
        if (droppable.hasClass("QueenUnitsUnits")) {
            droppable.addClass('QueenUnitsUnitsOver');
            return;
        }
        droppable.addClass('fleetUnitsOver');
    },

    chooseClassToRemove: function(droppable) {
        if (droppable.hasClass("BattleMoonUnitsOver")) {
            droppable.removeClass('BattleMoonUnitsOver');
            return;
        }
        if (droppable.hasClass("BlinkerUnitsOver")) {
            droppable.removeClass('BlinkerUnitsOver');
            return;
        }
        if (droppable.hasClass("QueenUnitsUnitsOver")) {
            droppable.removeClass('QueenUnitsUnitsOver');
            return;
        }
        droppable.removeClass('fleetUnitsOver');
    },

    isFleetAround: function(srcFLeet, dstFLeet) {
        if (Fleets) {
            var dst = Fleets[dstFLeet.getAttribute('fleetid')];
            var src = Number(srcFLeet.getAttribute('fleetid'));
            if (!dst.p.contains(src)) {
                return false;
            }
        }
        return true;
    },

    getClone: function(item) {
        var clone = item.clone();
        var name = item.getAttribute("unitName");
        clone.setAttribute("unitName", name);

        clone.setStyles(item.getCoordinates());
        clone.setStyles({ 'opacity': 0.7, 'position': 'absolute' });
        clone.inject(document.body);
        return clone;
    },

    dropEvent: function(clone, item, destiny) {
        if (Fleet.currentClone != null) {
            Fleet.clearTransferInfo();
        }

        var menu = $('quantitySelector');
        Menu.positionByElement(menu, clone, { x: 30, y: 30 });
        menu.removeClass('hidden');
        Fleet.quantityInput.focus();
        Fleet.quantityInput.value = clone.getFirst().getAttribute("quantity");
        Fleet.currentClone = clone;
        Fleet.currentItem = item;
        Fleet.currentDestiny = destiny;
    },

    clearTransferInfo: function() {
        var menu = $('quantitySelector');
        menu.addClass('hidden');

        Fleet.currentClone.dispose();
        Fleet.currentDestiny.removeClass('fleetUnitsOver');
        Fleet.currentClone = null;
        Fleet.currentItem = null;
        Fleet.currentDestiny = null;
    },

    transferQuantity: function(e) {
        var unitName = Fleet.currentClone.getAttribute('unitName');

        var quantityToTransfer = Number(Fleet.quantityInput.value);
        var originalQuantity = Number(Fleet.currentClone.getFirst().getAttribute("quantity"));

        if (quantityToTransfer > 0 && quantityToTransfer <= originalQuantity) {
            var added = Fleet.addQuantity(unitName, quantityToTransfer);
            if (added) {
                if (quantityToTransfer == originalQuantity) {
                    Fleet.currentItem.destroy();
                } else {
                    var newQuant = Number(originalQuantity) - Number(quantityToTransfer);
                    Fleet.changeQuantity(Fleet.currentItem, newQuant);
                }
            } else {
                RaiseError.fleetAtMaximum();
            }
            Fleet.clearTransferInfo();
        } else {
            RaiseError.invalidQuantity();
        }
    },

    addQuantity: function(unitName, quantity) {
        var added = false;

        var elements = Fleet.currentDestiny.getElements('div');

        elements.each(function(item) {
            if (added) {
                return;
            }
            var name = item.getAttribute("unitName");
            if (name == unitName) {
                //alert(unitName);
                Fleet.registerChange(unitName, quantity);
                var unitQuantity = item.getFirst().getAttribute("quantity");
                var total = Number(unitQuantity) + Number(quantity);
                Fleet.changeQuantity(item, total);
                added = true;
            }
        });
        if (added) {
            return true;
        }
        if (elements.length < 8) {
            var clone = Fleet.currentItem.clone();
            clone.addEvent('mousedown', function(e) {
                Fleet.unitClick(this, Fleet.currentDestiny, e);
            });
            Fleet.currentDestiny.adopt(clone);
            Fleet.changeQuantity(clone, quantity);
            Fleet.registerChange(unitName, quantity);
            return true;
        }
        return false;
    },

    changeQuantity: function(elem, quantity) {
        var img = elem.getFirst();
        img.setAttribute("quantity", quantity);
        var span = elem.getElement('span');
        span.empty();
        span.appendText(quantity);
    },

    registerChange: function(unitName, quantity) {
        var srcId = Fleet.currentItem.getParent().getAttribute('fleetId');
        var dstId = Fleet.currentDestiny.getAttribute('fleetId');
        Fleet.changeLog += srcId + "-" + dstId + "-" + unitName + "-" + quantity + ";";
        $('saveChanges').disabled = false;
    },

    genericCallBack: function() {
        Fleet.changeLog = "";
        Fleet.load();
    },

    saveChangesPlanet: function() {
        Fleet.sendRequest({ Type: 'change', Changes: Fleet.changeLog, CargoChanges: FleetCargo.changeLog, IsInPlanet: 1, CallBack: Fleet.saveChangesCallBack });
    },

    saveChangesPlayer: function() {
        Fleet.sendRequest({ Type: 'change', Changes: Fleet.changeLog, CargoChanges: FleetCargo.changeLog, IsInPlanet: 0, CallBack: Fleet.saveChangesCallBack });
    },

    saveChangesCallBack: function() {
        Fleet.changeLog = "";
        Fleet.load();
        Message.raiseAlert("FleetSavedWithSuccess");
    },

    deleteFleet: function(planetId, fleetId, dstFleeId) {
        if (!Message.raiseConfirm("AreYouSureYouWantToDeleteFleet")) {
            return;
        }

        var fleet = $('fleet' + fleetId);
        var dstFleet = $('fleet' + dstFleeId);

        fleet.getElements('.fleetListUnit').each(function(item) {
            var name = item.getAttribute("unitName");
            var unitQuantity = item.getFirst().getAttribute("quantity");
            var added = false;
            var elements = dstFleet.getElements('.fleetListUnit')
            elements.each(function(dstitem) {
                var destinyName = dstitem.getAttribute("unitName");
                if (destinyName == name) {
                    var dstUnitQuantity = dstitem.getFirst().getAttribute("quantity");
                    var total = Number(unitQuantity) + Number(dstUnitQuantity);
                    Fleet.changeQuantity(dstitem, total);
                    added = true;
                }
            });
            if (!added) {
                dstFleet.adopt(item);
            }
        });

        fleet.getParent().dispose();

        Fleet.sendRequest({ Type: 'delete', PlanetId: planetId, FleetId: fleetId });
    },

    deleteEmptyFleet: function(fleetId) {
        if (!Message.raiseConfirm("AreYouSureYouWantToDeleteFleet")) {
            return;
        }
        var fleet = $('fleet' + fleetId);
        fleet.getParent().dispose();
        Fleet.sendRequest({ Type: 'deleteEmpty', FleetId: fleetId });
    },

    dropTradeCargo: function(fleetId, cargoId) {
        var cargoElement = $(cargoId);
        cargoElement.getElements(".cargoList").each(function(elem) {
            var isTradeResource = elem.getAttribute('isTradeResource');
            if (isTradeResource == 'true') {
                elem.destroy();
            }
        });
        if (cargoElement.getElements(".cargoList").length == 0) {
            cargoElement.destroy();
        } else {
            $(cargoId).getElements(".dropTradeFleetCargo").each(function(elem) {
                elem.destroy();
            });
        }

        Fleet.sendRequest({ Type: 'dropfleetcargo', FleetId: fleetId });
    }
}

window.addEvent('domready', function(){
    if( $('fleetList') ) {
        Fleet.load();
    }
});