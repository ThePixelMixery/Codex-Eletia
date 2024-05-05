extends Node

var actions: Array = []
var tiles: Array = []

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
	populate("actions")
	populate("tiles")

	# remove title row
	actions.pop_front()
	tiles.pop_front()

func populate(data:String):
	var file: FileAccess 
	file = FileAccess.open("res://assets/databases/" + data +"/" + data +".csv", FileAccess.READ)
	while !file.eof_reached():
		database_entry(data, file.get_csv_line())

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
		"tiles":
			var tile: Dictionary = {
				#"prefix": true if entry[0] == "Yes" else false,
				"name": entry[0],
				"pop min": entry[1],
				"pop max": entry[2],
				"type": entry[3],
				"cat": entry[4],
				"subcat": entry[5],
				"flavour": entry[6]
			}
			tiles.append(tile)
