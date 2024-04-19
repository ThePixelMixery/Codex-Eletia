extends Node

static var rng: RandomNumberGenerator

# used for inital generation
static var base_cont_data: Array = [
	{ "type": "Fire"},
	{ "type": "Water"},
	{ "type": "Earth"},
	{ "type": "Air"},
	{ "type": "Arcane"},
	{ "type": "Mystic"},
	{ "type": "Time"},
	{ "type": "Summoner"},
	{ "type": "Plant"},
	{ "type": "Overseer"},
	{ "type": "Ghost"},
	{ "type": "Channel"},
	{ "type": "Necrotic"},
	{ "type": "Illusion"}
]

static func generate_map(reset: bool = false):
	# creates randomiser
	rng = RandomNumberGenerator.new()
	rng.randomize()
	
	# checks if map exists before generating
	if reset:
		maps.map["continents"].clear()
		maps.map["tiles"].clear()


	# generating the map and alerting player
	generate_conts(maps.map["continents"])
	generate_world(maps.map)
	log.add_event("(Re)creating map","test")

static func generate_conts(conts: Array):
	var new_cont: Dictionary
	
	# arctic north
	for i in range(0,6):
		new_cont = {
			"type":"Arctic 
			North",
			"reputation":-1,
			"discovered": true,
			"shorthand": "AN"
		}
		conts.append(new_cont)
	
	# main map area
	conts.append_array(create_main_cont())

	# arctic south
	for i in range(0,6):
		new_cont = {
			"type":"Arctic 
			South",
			"reputation":-1,
			"discovered": true,
			"shorthand": "AS"
		}
		conts.append(new_cont)
	print("conts generated")

static func create_main_cont():
	var generated_cont_data: Array
	var sea_cont: Dictionary = {
		"type": "Sea",
		"reputation": -1,
		"discovered": false,
			"shorthand": "Sea"
	}

	# 1 of all types
	generated_cont_data = base_cont_data.duplicate(true)
	for cont in generated_cont_data:
		cont["reputation"] = 0
		cont["discovered"] = false
	
	# add sea until 24 states
	for i in range(generated_cont_data.size(), 24):
		generated_cont_data.append(sea_cont)

	# shuffle states
	generated_cont_data.shuffle()

	return generated_cont_data

static func generate_world(map_data: Dictionary):
	var conts: Array = map_data["continents"]
	var tiles: Array = map_data["tiles"]
	var size: int = map_data["world_size"]
	var tile: Dictionary

	# create base tiles based on size
	while tiles.size()<(conts.size()*size):
		tiles.append(tile)

	# select blocks of tiles based on size
	# and apply a type to them. based on continents
	''' example v would select [0,0; 1,0; 0,1; 1,1]
		xx-xx-00-00
		xx-xx-00-00
		00-00-00-00
		00-00-00-00
	'''

	# ocean tiles?
	# border mixing?

	map_data["tiles"] = tiles