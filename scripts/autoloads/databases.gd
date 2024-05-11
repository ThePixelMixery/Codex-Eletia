extends Node


var actions: Array = []
var tiles: Dictionary = {}

var minor_locations = [
	"Outpost",
	"Colony",
	"Refuge",
	"Hamlet",
	"Fort",
	"Sanctuary",
	"Stronghold"
]

var prefixes: Dictionary = {
	"enemies" = [
		"lethal",
		"ruthless",
		"predatory",
		"menacing",
		"ferocious",
		"savage",
		"deadly",
		"perilous",
		"treacherous",
		"vicious",
		"sinister",
		"threatening",
		"murderous",
		"merciless",
		"diabolical",
		"fierce",
		"hostile",
		"terrifying",
		"aggressive",
		"cunning",
		"intimidating",
		"brutal",
		"vile",
		"malicious",
		"ravenous",
		"predacious",
		"bloodthirsty",
		"cruel",
		"destructive",
		"ominous",
		"devious",
		"sinister",
		"wicked",
		"evil",
		"menacing",
		"macabre",
		"gruesome",
		"monstrous",
		"dangerous",
		"dire",
		"hazardous",
		"unforgiving",
		"dreadful",
		"formidable",
		"sinister",
		"villainous",
		"sinister"
	],
	"location" = {
		"Fire" = [
			"creative",
			"passionate",
			"vibrant",
			"dynamic",
			"inspiring",
			"flamboyant",
			"expressive",
			"bold",
			"fiery",
			"energetic"
		],
		"Water" = [
			"resourceful",
			"resilient",
			"adaptable",
			"stoic",
			"tough",
			"pragmatic",
			"hardy",
			"weathered",
			"cunning",
			"tenacious"
		],
		"Earth" = [
			"serene",
			"contemplative",
			"tranquil",
			"introspective",
			"calm",
			"peaceful",
			"harmonious",
			"reclusive",
			"zen-like",
			"solitary"
		],
		"Air" = [
			"arid",
			"dry",
			"sandy",
			"barren",
			"scorching",
			"dusty",
			"bleak",
			"sun-baked",
			"isolated",
			"harsh"
		],
		"Arcane" = []
	}
}

func _ready():
#	populate("actions")
	populate("tiles")

	# remove title row
#	actions.pop_front()

func populate(data:String):
	var file: FileAccess 
	file = FileAccess.open("res://assets/databases/" + data +"/" + data +".csv", FileAccess.READ)
	match data:
		"tiles":
			while !file.eof_reached():
				make_tile_entry(file.get_csv_line())
		_:
			pass

func database_entry(data: String, entry: Array):
	match data:
		"actions":
			var action: Dictionary = {
				"name": entry[0],
				"dragon": true if entry[1] == "Yes" else false,
				"type":entry[2],
				"action":entry[3]
			}
			actions.append(action)

func make_tile_entry(entry: Array):
	var tile_info: Dictionary = {
		"category" = entry [1],
		"name" = entry[2],
		"pop_min" = entry[3],
		"pop_max" = entry[4],
		"flavour" = entry[5]
	}
	if !tiles.has(entry[0]):
		tiles[entry[0]] = {}
	tiles[entry[0]][entry[1]] = tile_info

func get_tile_entry(type: String, cat: String):
	return tiles[type][cat]
