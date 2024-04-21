extends Node

static var rng: RandomNumberGenerator

static var x: int = -27
static var y: int = -27

static var dir: Dictionary = {
}

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
	{ "type": "Hallow"}
]

static func generate_map(reset: bool = false):	
	# creates randomiser
	rng = RandomNumberGenerator.new()
	rng.randomize()
	
	# checks if map exists before generating
	if reset:
		maps.map["continents"].clear()
		maps.map["tiles"].clear()


	# generating continents and alerting player
	maps.map["continents"] = generate_conts()

	for i in range(maps.map["continents"].size()):
		apply_coords(maps.map["continents"][i])

	#generating world
	generate_world(maps.map)
	log.add_event("(Re)creating map","test")

	#generating terrain
	#pick tile to become 


	emit.map_generated.emit()


static func generate_conts():
	var generated_cont_data: Array = []

	for i in range(2):
		for cont in base_cont_data:
			var new_cont = {
				"type": cont["type"],
				"reputation": 0,
				"discovered": false
			}
			if i == 0:
				new_cont["capital"] = true
			else:
				new_cont["capital"] = false
			generated_cont_data.append(new_cont)

	
	# add sea until 24 states
	for i in range(generated_cont_data.size(), 36):
		var sea_cont: Dictionary = {
			"type": "Sea",
		}
		generated_cont_data.append(sea_cont)


	# shuffle states
	generated_cont_data.shuffle()

	# 1 of all types
	for cont in generated_cont_data:
		if cont["type"] != "Sea":
			cont["reputation"] = 0
			cont["discovered"] = false
		else:
			cont["reputation"] = -1
			cont["discovered"] = false


	return generated_cont_data


static func apply_coords(cont: Dictionary):
	cont["x_limit"] = [x,x+8]
	cont["y_limit"] = [y,y+8]
	x += 9
	if x >= 27:
		x = -27
		y += 9

static func generate_world(map_data: Dictionary):
	# create world tiles based on size
	for i in range(27,-27,-1):
		for j in range(-27,27):
			var tile = {"pos": [j,i]}
			map_data["tiles"].append(tile)

	# assign according to continent
	for cont in map_data["continents"]:
		for tile in maps.map["tiles"]:
			if (tile["pos"][0] >= cont["x_limit"][0] 
			&&  tile["pos"][0] <= cont["x_limit"][1]
			&&  tile["pos"][1] >= cont["y_limit"][0]
			&&  tile["pos"][1] <= cont["y_limit"][1]):
				tile["type"] = cont["type"]


	# ocean borders
	for i in range(0, maps.map["tiles"].size()):
		var change: float = randf_range(0,1)
		#if ocean_check(i, maps.map["tiles"]):
		#	if change < 0.3:
		#		maps.map["tiles"][i]["type"]= "Sea"

	# mixing	
	for tile in map_data["tiles"]:
		var rand_num = randi_range(0,base_cont_data.size()-1)
		var rand_assign = base_cont_data[rand_num]["type"]
		var change: float = randf_range(0,1)
		if tile["type"] != "Sea":
			if change <= 0.3:
				tile["type"] = rand_assign


static func assign_cont(tiles: Array, cont: Dictionary):
	# select tiles based on 
	for tile in tiles:
		if (tile["pos"][0] >= cont["x_limit"][0] 
	 	&&  tile["pos"][0] <= cont["x_limit"][1]
	 	&&  tile["pos"][1] >= cont["y_limit"][0]
	 	&&  tile["pos"][1] <= cont["y_limit"][1]):
			tile["type"] = cont["type"]

	return cont

static func set_directions(index: int):
	var pos_x: int = maps.map["tiles"][index]["pos"][0]
	var pos_y: int = maps.map["tiles"][index]["pos"][1]
	


	# try pos approach?

	'''
	
	# checks north side 
	# if goes above north, checks from the bottom?
	if north <= -1: 
		north = north + 2024

	# checks east side 
	# if goes above 54, checks from the left end?
	if east % 54 == 0 || east == 2024: 
		east = 54 - east

	# checks south side 
	# if goes beyond south, checks from the top?
	if south > 2025: 
		south = south - 2024

	# checks west side 
	# if goes beyond west, checks from the right end?
	if west % 53 == 0 || west == -1: 
		west = west + 54

	if west >= 2025:
		west = 2024

	if south >= 2025:
		south = 2024


	if tiles[north]["type"] == "Sea":
		return true
	if tiles[east]["type"] == "Sea":
		return true
	if tiles[south]["type"] == "Sea":
		return true
	if tiles[west]["type"] == "Sea":
		return true
	return false
	'''
