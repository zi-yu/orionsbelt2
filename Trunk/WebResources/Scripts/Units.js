if( window.AttackUtils == null ) {
	window.AttackUtils = { getAttack : null, getDefense : null};
}
var Unit = {
	'bozer': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Bozer',
		'code' : 'bz',
		'category' : 'Heavy',
		'baseAttack' : 3200,
		'attackCost' : 1,
		'baseDefense' : 2800,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Air':4000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'bz': function() {
		return Unit['bozer'];
	},

	'commanderfox': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'CommanderFox',
		'code' : 'cf',
		'category' : 'Heavy',
		'baseAttack' : 50000,
		'attackCost' : 1,
		'baseDefense' : 100000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'cf': function() {
		return Unit['commanderfox'];
	},

	'hiveprotector': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'HiveProtector',
		'code' : 'hp',
		'category' : 'Medium',
		'baseAttack' : 1000,
		'attackCost' : 1,
		'baseDefense' : 4500,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'hp': function() {
		return Unit['hiveprotector'];
	},

	'doomer': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Doomer',
		'code' : 'doo',
		'category' : 'Heavy',
		'baseAttack' : 6000,
		'attackCost' : 1,
		'baseDefense' : 500,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 3,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'doo': function() {
		return Unit['doomer'];
	},

	'cypher': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Cypher',
		'code' : 'cp',
		'category' : 'Light',
		'baseAttack' : 1500,
		'attackCost' : 1,
		'baseDefense' : 1500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'cp': function() {
		return Unit['cypher'];
	},

	'stinger': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Stinger',
		'code' : 'sg',
		'category' : 'Medium',
		'baseAttack' : 500,
		'attackCost' : 1,
		'baseDefense' : 1000,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Light':1000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sg': function() {
		return Unit['stinger'];
	},

	'captainwolf': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'CaptainWolf',
		'code' : 'cw',
		'category' : 'Heavy',
		'baseAttack' : 100000,
		'attackCost' : 1,
		'baseDefense' : 1000000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 6,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'cw': function() {
		return Unit['captainwolf'];
	},

	'destroyer': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Destroyer',
		'code' : 'dy',
		'category' : 'Medium',
		'baseAttack' : 1100,
		'attackCost' : 1,
		'baseDefense' : 500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : true,
		'range' : 1,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'dy': function() {
		return Unit['destroyer'];
	},

	'myst': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Myst',
		'code' : 'mt',
		'category' : 'Medium',
		'baseAttack' : 300,
		'attackCost' : 1,
		'baseDefense' : 200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'mt': function() {
		return Unit['myst'];
	},

	'scarab': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Scarab',
		'code' : 'sc',
		'category' : 'Medium',
		'baseAttack' : 1900,
		'attackCost' : 1,
		'baseDefense' : 2300,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'front',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sc': function() {
		return Unit['scarab'];
	},

	'toxic': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Toxic',
		'code' : 'tx',
		'category' : 'Light',
		'baseAttack' : 450,
		'attackCost' : 1,
		'baseDefense' : 600,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Organic':1000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'tx': function() {
		return Unit['toxic'];
	},

	'fist': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Fist',
		'code' : 'ft',
		'category' : 'Heavy',
		'baseAttack' : 4200,
		'attackCost' : 1,
		'baseDefense' : 1800,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'ft': function() {
		return Unit['fist'];
	},

	'flag': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Flag',
		'code' : 'fg',
		'category' : 'Special',
		'baseAttack' : 1,
		'attackCost' : 1,
		'baseDefense' : 10000,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'fg': function() {
		return Unit['flag'];
	},

	'darktaurus': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'DarkTaurus',
		'code' : 'dt',
		'category' : 'Heavy',
		'baseAttack' : 6800,
		'attackCost' : 1,
		'baseDefense' : 3500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'dt': function() {
		return Unit['darktaurus'];
	},

	'egg': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Egg',
		'code' : 'eg',
		'category' : 'Light',
		'baseAttack' : 0,
		'attackCost' : 1,
		'baseDefense' : 1,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 0,
		'movementCost' : 0,
		'movementType' : 'none',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'eg': function() {
		return Unit['egg'];
	},

	'jumper': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Jumper',
		'code' : 'jp',
		'category' : 'Light',
		'baseAttack' : 200,
		'attackCost' : 1,
		'baseDefense' : 100,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : true,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'jp': function() {
		return Unit['jumper'];
	},

	'battlemoon': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'BattleMoon',
		'code' : 'bm',
		'category' : 'Ultimate',
		'baseAttack' : 1000000,
		'attackCost' : 6,
		'baseDefense' : 1000000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 6,
		'movementType' : 'none',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '9',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'bm': function() {
		return Unit['battlemoon'];
	},

	'metallicbeard': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'MetallicBeard',
		'code' : 'mb',
		'category' : 'Heavy',
		'baseAttack' : 100000,
		'attackCost' : 1,
		'baseDefense' : 1000000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 6,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'mb': function() {
		return Unit['metallicbeard'];
	},

	'darkcrusader': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'DarkCrusader',
		'code' : 'dc',
		'category' : 'Heavy',
		'baseAttack' : 2800,
		'attackCost' : 1,
		'baseDefense' : 2000,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 6,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'dc': function() {
		return Unit['darkcrusader'];
	},

	'scourge': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Scourge',
		'code' : 'so',
		'category' : 'Medium',
		'baseAttack' : 1450,
		'attackCost' : 1,
		'baseDefense' : 2000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'so': function() {
		return Unit['scourge'];
	},

	'crawler': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Crawler',
		'code' : 'cr',
		'category' : 'Medium',
		'baseAttack' : 2000,
		'attackCost' : 1,
		'baseDefense' : 1800,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : true,
		'paralyse' : true,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 3,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Medium':2000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'cr': function() {
		return Unit['crawler'];
	},

	'rain': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Rain',
		'code' : 'r',
		'category' : 'Light',
		'baseAttack' : 120,
		'attackCost' : 1,
		'baseDefense' : 70,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Heavy':1200

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'r': function() {
		return Unit['rain'];
	},

	'samurai': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Samurai',
		'code' : 's',
		'category' : 'Light',
		'baseAttack' : 150,
		'attackCost' : 1,
		'baseDefense' : 450,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	's': function() {
		return Unit['samurai'];
	},

	'panther': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Panther',
		'code' : 'p',
		'category' : 'Light',
		'baseAttack' : 300,
		'attackCost' : 1,
		'baseDefense' : 300,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'p': function() {
		return Unit['panther'];
	},

	'queen': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Queen',
		'code' : 'q',
		'category' : 'Ultimate',
		'baseAttack' : 1000000,
		'attackCost' : 4,
		'baseDefense' : 1000000,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 4,
		'movementType' : 'drop',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': false,
		'coolDown': '9',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'q': function() {
		return Unit['queen'];
	},

	'darkrain': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'DarkRain',
		'code' : 'dr',
		'category' : 'Light',
		'baseAttack' : 190,
		'attackCost' : 1,
		'baseDefense' : 20,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Heavy':600

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'dr': function() {
		return Unit['darkrain'];
	},

	'worm': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Worm',
		'code' : 'w',
		'category' : 'Medium',
		'baseAttack' : 1200,
		'attackCost' : 1,
		'baseDefense' : 1200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'w': function() {
		return Unit['worm'];
	},

	'taurus': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Taurus',
		'code' : 't',
		'category' : 'Heavy',
		'baseAttack' : 5000,
		'attackCost' : 1,
		'baseDefense' : 6800,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	't': function() {
		return Unit['taurus'];
	},

	'kamikaze': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Kamikaze',
		'code' : 'k',
		'category' : 'Medium',
		'baseAttack' : 4000,
		'attackCost' : 1,
		'baseDefense' : 1,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'k': function() {
		return Unit['kamikaze'];
	},

	'pretorian': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Pretorian',
		'code' : 'h',
		'category' : 'Medium',
		'baseAttack' : 450,
		'attackCost' : 1,
		'baseDefense' : 5550,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'h': function() {
		return Unit['pretorian'];
	},

	'seeker': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Seeker',
		'code' : 'sk',
		'category' : 'Light',
		'baseAttack' : 100,
		'attackCost' : 1,
		'baseDefense' : 40,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Medium':500

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sk': function() {
		return Unit['seeker'];
	},

	'nova': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Nova',
		'code' : 'n',
		'category' : 'Heavy',
		'baseAttack' : 2700,
		'attackCost' : 1,
		'baseDefense' : 1900,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Organic':4000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'n': function() {
		return Unit['nova'];
	},

	'maggot': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Maggot',
		'code' : 'm',
		'category' : 'Light',
		'baseAttack' : 500,
		'attackCost' : 1,
		'baseDefense' : 1000,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : true,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'm': function() {
		return Unit['maggot'];
	},

	'blackwidow': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'BlackWidow',
		'code' : 'b',
		'category' : 'Heavy',
		'baseAttack' : 2500,
		'attackCost' : 1,
		'baseDefense' : 2100,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : true,
		'paralyse' : true,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'b': function() {
		return Unit['blackwidow'];
	},

	'crusader': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Crusader',
		'code' : 'c',
		'category' : 'Heavy',
		'baseAttack' : 2400,
		'attackCost' : 1,
		'baseDefense' : 2200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 6,
		'movementCost' : 4,
		'movementType' : 'front',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'c': function() {
		return Unit['crusader'];
	},

	'anubis': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Anubis',
		'code' : 'a',
		'category' : 'Light',
		'baseAttack' : 200,
		'attackCost' : 1,
		'baseDefense' : 500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			'Heavy':1600

		},
		'rangeTargets' : {
			
		}
	},

	'a': function() {
		return Unit['anubis'];
	},

	'hiveking': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'HiveKing',
		'code' : 'hk',
		'category' : 'Heavy',
		'baseAttack' : 4000,
		'attackCost' : 1,
		'baseDefense' : 3200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : true,
		'rebound' : false,
		'infestation' : true,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'normal',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'hk': function() {
		return Unit['hiveking'];
	},

	'kahuna': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Kahuna',
		'code' : 'kh',
		'category' : 'Medium',
		'baseAttack' : 1000,
		'attackCost' : 1,
		'baseDefense' : 1300,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			'Terrest':400
,'Air':400

		},
		'rangeTargets' : {
			
		}
	},

	'kh': function() {
		return Unit['kahuna'];
	},

	'driller': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Driller',
		'code' : 'd',
		'category' : 'Medium',
		'baseAttack' : 1500,
		'attackCost' : 1,
		'baseDefense' : 1500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'd': function() {
		return Unit['driller'];
	},

	'eagle': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Eagle',
		'code' : 'e',
		'category' : 'Medium',
		'baseAttack' : 1100,
		'attackCost' : 1,
		'baseDefense' : 1200,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Medium':400

		},
		'defenseTargets' : {
			'Heavy':400

		},
		'rangeTargets' : {
			
		}
	},

	'e': function() {
		return Unit['eagle'];
	},

	'blinker': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Blinker',
		'code' : 'bk',
		'category' : 'Ultimate',
		'baseAttack' : 1000000,
		'attackCost' : 6,
		'baseDefense' : 1000000,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 5,
		'movementType' : 'none',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': false,
		'coolDown': '9',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'bk': function() {
		return Unit['blinker'];
	},

	'sentry': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Sentry',
		'code' : 'st',
		'category' : 'Light',
		'baseAttack' : 200,
		'attackCost' : 1,
		'baseDefense' : 100,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : true,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'st': function() {
		return Unit['sentry'];
	},

	'vector': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Vector',
		'code' : 'v',
		'category' : 'Medium',
		'baseAttack' : 2000,
		'attackCost' : 1,
		'baseDefense' : 1200,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'v': function() {
		return Unit['vector'];
	},

	'walker': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Walker',
		'code' : 'wk',
		'category' : 'Medium',
		'baseAttack' : 2200,
		'attackCost' : 1,
		'baseDefense' : 1500,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : true,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 3,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Heavy':2000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'wk': function() {
		return Unit['walker'];
	},

	'titan': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Titan',
		'code' : 'tt',
		'category' : 'Heavy',
		'baseAttack' : 3500,
		'attackCost' : 1,
		'baseDefense' : 2250,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'tt': function() {
		return Unit['titan'];
	},

	'silverbeard': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'SilverBeard',
		'code' : 'sb',
		'category' : 'Heavy',
		'baseAttack' : 50000,
		'attackCost' : 1,
		'baseDefense' : 100000,
		'strikeBack' : false,
		'catapult' : true,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sb': function() {
		return Unit['silverbeard'];
	},

	'fenix': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Fenix',
		'code' : 'f',
		'category' : 'Heavy',
		'baseAttack' : 2500,
		'attackCost' : 1,
		'baseDefense' : 2950,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : true,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 4,
		'movementCost' : 3,
		'movementType' : 'normal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'f': function() {
		return Unit['fenix'];
	},

	'interceptor': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Interceptor',
		'code' : 'it',
		'category' : 'Light',
		'baseAttack' : 100,
		'attackCost' : 1,
		'baseDefense' : 100,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : true,
		'bomb' : false,
		'range' : 1,
		'movementCost' : 1,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'it': function() {
		return Unit['interceptor'];
	},

	'reaper': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Reaper',
		'code' : 're',
		'category' : 'Light',
		'baseAttack' : 500,
		'attackCost' : 1,
		'baseDefense' : 250,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : true,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	're': function() {
		return Unit['reaper'];
	},

	'raptor': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Raptor',
		'code' : 'rp',
		'category' : 'Light',
		'baseAttack' : 280,
		'attackCost' : 1,
		'baseDefense' : 400,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 2,
		'movementCost' : 1,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			'Light':1000

		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'rp': function() {
		return Unit['raptor'];
	},

	'spider': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Spider',
		'code' : 'sp',
		'category' : 'Medium',
		'baseAttack' : 1800,
		'attackCost' : 1,
		'baseDefense' : 2200,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : true,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Ground',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'sp': function() {
		return Unit['spider'];
	},

	'krill': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'Krill',
		'code' : 'kr',
		'category' : 'Medium',
		'baseAttack' : 1500,
		'attackCost' : 1,
		'baseDefense' : 1000,
		'strikeBack' : true,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 3,
		'movementCost' : 2,
		'movementType' : 'all',
		'level' : 'Air',
		'type' : 'Mechanic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'kr': function() {
		return Unit['krill'];
	},

	'heavyseeker': {
		'getAttack' : AttackUtils.getAttack,
		'getDefense' : AttackUtils.getDefense,
		'name' : 'HeavySeeker',
		'code' : 'hr',
		'category' : 'Heavy',
		'baseAttack' : 2500,
		'attackCost' : 1,
		'baseDefense' : 2200,
		'strikeBack' : false,
		'catapult' : false,
		'triple' : false,
		'replicator' : false,
		'removeAbility' : false,
		'rebound' : false,
		'infestation' : false,
		'paralyse' : false,
		'bomb' : false,
		'range' : 5,
		'movementCost' : 4,
		'movementType' : 'diagonal',
		'level' : 'Air',
		'type' : 'Organic',
		'canAttack': true,
		'coolDown': '0',
		'attackTargets' : {
			
		},
		'defenseTargets' : {
			
		},
		'rangeTargets' : {
			
		}
	},

	'hr': function() {
		return Unit['heavyseeker'];
	},

	dummy : function(){}
}