extends Node

var rng: RandomNumberGenerator

var map_x: int = -22
var map_y: int = 22
var map_pos = 22
var map_neg = -22
var map_cap: int = 23
var cont_size: int = 8
var map_inc: int = 9

# used for inital generation
var base_cont_data: Array = [
	{ "type" = "Fire", "sh" = "Fi"},
	{ "type" = "Water", "sh" = "Wa"},
	{ "type" = "Earth", "sh" = "Ea"},
	{ "type" = "Air", "sh" = "Ai"},
	{ "type" = "Arcane", "sh" = "Ar"},
	{ "type" = "Mystic", "sh" = "My"},
	{ "type" = "Time", "sh" = "Ti"},
	{ "type" = "Summoner", "sh" = "Su"},
	{ "type" = "Plant", "sh" = "Pl"},
	{ "type" = "Ghost", "sh" = "Gh"},
	{ "type" = "Hallow", "sh" = "Ha"}
]

func _ready():
	emit.connect("generate_map", generate_map)

func generate_map(data):	
	log.add_event("(Re)creating map","test")

	# creates randomiser
	rng = RandomNumberGenerator.new()
	rng.randomize()
	
	# checks if map exists before generating
	data["continents"].clear()
	data["tiles"].clear()


	# generating continents and alerting player
	data["continents"] = generate_conts()

	for i in range(data["continents"].size()):
		apply_coords(data["continents"][i])

	#generating world
	generate_world(data)

	#adding names and flavour text
	base_details()

	#generating terrain
	#pick tile to become populated tiles
	add_population()

	global.set_directions(51)

	global.save(global.MAP)

	emit.map_generated.emit()

func generate_conts():
	var generated_cont_data: Array = []

	for i in range(2):
		for cont in base_cont_data:
			var new_cont = {
				"size": i,
				"type": cont["type"],
				"reputation": 0,
				"discovered": false
			}
			generated_cont_data.append(new_cont)

	
	for i in range(generated_cont_data.size(), 25):
		var sea_cont: Dictionary = {
			"size": 3,
			"type": "Sea",
			"reputation": -1,
			"discovered": false
		}
		generated_cont_data.append(sea_cont)


	# shuffle states
	generated_cont_data.shuffle()

	return generated_cont_data

func apply_coords(cont: Dictionary):
	cont["x_limit"] = [map_x,map_x+cont_size]
	cont["y_limit"] = [map_y,map_y-cont_size]
	map_x += map_inc
	if map_x >= map_cap:
		map_x = map_neg
		map_y -= map_inc

func generate_world(data: Dictionary):
	# create world tiles based on size
	for i in range(global.map["continents"].size()*81):
		var tile: Dictionary = {}
		data["tiles"].append(tile)

	map_x = map_neg
	map_y = map_pos
	for tile in data["tiles"]:
		tile["pos"] = [map_x,map_y]
		map_x += 1
		if map_x == map_cap:
			map_x = map_neg
			map_y -= 1


	#assigns type based on content, clean
	assign_cont()	

	# ocean borders
	for i in range(0, data["tiles"].size()):
		global.set_directions(i, data)
		var change: float = randf_range(0,1)
		ocean_check(data["tiles"][i] ,change)

	# mixing	
	for tile in global.map["tiles"]:
		var rand_num = randi_range(0,base_cont_data.size()-1)
		var rand_assign = base_cont_data[rand_num]["type"]
		var change: float = randf_range(0,1)
		if tile["type"] != "Sea":
			if change <= 0.3:
				tile["type"] = rand_assign


	add_shorthand(data["tiles"])

func assign_cont():
	# assign according to continent
	
	var tiles = global.map["tiles"]

	for cont in global.map["continents"]:
		var tile_ids: Array = []
		var x_lower = cont["x_limit"][0]
		var x_upper = cont["x_limit"][1]
		var y_lower = cont["y_limit"][1]
		var y_upper = cont["y_limit"][0]
		for i in global.map["tiles"].size():
			if (tiles[i]["pos"][0] >= x_lower
			&&  tiles[i]["pos"][0] <= x_upper
			&&  tiles[i]["pos"][1] >= y_lower
			&&  tiles[i]["pos"][1] <= y_upper):
				tiles[i]["type"] = cont["type"]
				tile_ids.append(i)
		cont["tile_ids"] = tile_ids

func ocean_check(tile: Variant, change: float):
	for key in global.map["adjacent"].keys():
		var dir = global.map["adjacent"][key]
		if dir != null:
			var dir_type = global.map["adjacent"][key]["type"]
			if dir_type == "Sea" && change < 0.3:
				tile["type"] = "Sea"

func add_shorthand(tiles: Array):
	for tile in tiles:
		for cont in base_cont_data:
			if tile["type"] == cont["type"]:
				tile["shorthand"] = cont["sh"]

func base_details():
	for cont in global.map["continents"]:
		for tile in cont["tile_ids"]:
			var tile_to_update = global.map["tiles"][tile]
			if tile_to_update["type"] != "Sea":
				var tile_info = data.get_tile_entry(cont["type"],tile_to_update["type"])
				tile_to_update.merge(tile_info)

func add_population():
	for cont in global.map["continents"]:
		if cont["type"] != "Sea":
			add_major(cont)

	for tile in global.map["tiles"]:
		var chance: float = randf_range(0,1)
		if chance <= 0.2 and tile["type"] != "Sea":
			add_minor(tile)

func add_major(cont: Variant):
	# pick tile to become major tile
	var selected: bool = false
	var _tile: Variant
	var tile_from_db: Variant
	var tile_id: int = 0

	while selected == false:
		tile_id = cont["tile_ids"].pick_random()
		if global.map["tiles"][tile_id]["type"] == cont["type"]:
			_tile = global.map["tiles"][tile_id]
			selected = true

	# assing major based on capital tier: Capital, City, Town
	match cont["size"]:
		0:
			for entry in data.tiles:
				tile_from_db = data.get_tile_entry(cont["type"],"Capital")
		1:
			for entry in data.tiles:
				tile_from_db = data.get_tile_entry(cont["type"],"City")
		2:
			for entry in data.tiles:
				tile_from_db = data.get_tile_entry(cont["type"],"Town")
	_tile.merge(tile_from_db)
	
func add_minor(tile: Variant):
	var subcat = data.minor_locations.pick_random()
	var tile_from_db: Variant = data.get_tile_entry(tile["type"], subcat)
	tile.merge(tile_from_db)
