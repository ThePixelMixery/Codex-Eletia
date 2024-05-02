extends Node

var rng: RandomNumberGenerator

var map_x: int = -27
var map_y: int = -27

# used for inital generation
var base_cont_data: Array = [
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

func _ready():
	emit.connect("generate_map", generate_map)

func generate_map(data):	
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
	log.add_event("(Re)creating map","test")

	#generating terrain
	#pick tile to become 


	emit.map_generated.emit()


func generate_conts():
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

	
	# add sea until 46 states
	for i in range(generated_cont_data.size(), 36):
		var sea_cont: Dictionary = {
			"type": "Sea",
		}
		generated_cont_data.append(sea_cont)


	# shuffle states
	generated_cont_data.shuffle()

	# set reputation
	for cont in generated_cont_data:
		if cont["type"] != "Sea":
			cont["reputation"] = 0
			cont["discovered"] = false
		else:
			cont["reputation"] = -1
			cont["discovered"] = false


	return generated_cont_data


func apply_coords(cont: Dictionary):
	cont["x_limit"] = [map_x,map_x+8]
	cont["y_limit"] = [map_y,map_y+8]
	map_x += 9
	if map_x >= 27:
		map_x = -27
		map_y += 9

func generate_world(data: Dictionary):
	# create world tiles based on size
	for i in range(global.map["continents"].size()):
		var tile: Dictionary = {}
		data["tiles"].append(tile)

	var pos_x = -27
	var pos_y = 27
	var count = 0
	for tile in data["tiles"]:
		tile["pos"] = [pos_x,pos_y]
		pos_x += 1
		if pos_x == 2:
			count += 1
		if pos_x == 27:
			pos_x = -27
			pos_y -= 1

	print(count)

	assign_cont(data)	

	set_directions(0, data)
	print(data["adjacent"])

	# ocean borders
	for i in range(0, data["tiles"].size()):
		var change: float = randf_range(0,1)
		#if ocean_check(i, data["tiles"]):
		#	if change < 0.3:
		#		data["tiles"][i]["type"]= "Sea"

	# mixing	
#	for tile in map_data["tiles"]:
#		var rand_num = randi_range(0,base_cont_data.size()-1)
#		var rand_assign = base_cont_data[rand_num]["type"]
#		var change: float = randf_range(0,1)
		#if tile["type"] != "Sea":
		#	if change <= 0.3:
		#		tile["type"] = rand_assign
	global.save_data(global.MAP, global.map)


func assign_cont(data: Dictionary):
	var count = data["tiles"].size()-1
	# assign according to continent
	for cont in data["continents"]:
		var x_lower = cont["x_limit"][0]
		var x_upper = cont["x_limit"][1]
		var y_lower = cont["y_limit"][0]
		var y_upper = cont["y_limit"][1]
		for tile in data["tiles"]:
			if (tile["pos"][0] >= x_lower
			&&  tile["pos"][0] <= x_upper
			&&  tile["pos"][1] >= y_lower
			&&  tile["pos"][1] <= y_upper):
				tile["type"] = cont["type"]
				count -= 1
	print(count," tiles left")

func set_directions(index: int, data: Dictionary):
	var pos_x: int = data["tiles"][index]["pos"][0]
	var pos_y: int = data["tiles"][index]["pos"][1]
	print ("initial tile pos: ", pos_x,", ", pos_y)
	data["adjacent"]["self"] = data["tiles"][index]
	data["adjacent"]["NE"] = get_tile_from_pos(pos_x+1,pos_y+1)
	data["adjacent"]["N"] = get_tile_from_pos(pos_x,pos_y+1)
	data["adjacent"]["NW"] = get_tile_from_pos(pos_x-1,pos_y+1)
	data["adjacent"]["E"] = get_tile_from_pos(pos_x+1,pos_y)
	data["adjacent"]["W"] = get_tile_from_pos(pos_x-1,pos_y)
	data["adjacent"]["SE"] = get_tile_from_pos(pos_x+1,pos_y-1)
	data["adjacent"]["S"] = get_tile_from_pos(pos_x,pos_y-1)
	data["adjacent"]["SW"] = get_tile_from_pos(pos_x-1,pos_y-1)

func get_tile_from_pos(x:int, y:int, data:Dictionary = global.map):
	for tile in data["tiles"]:
		if tile["pos"][0] == x && tile["pos"][1] == y:
			return tile
