extends Node

var settings: Dictionary = {
	"events" = {
		"settings" = true,
		"time" = true,
		"story" = true,
		"loot" = true,
		"unlock" = true
	},
    "layout" = {
        "colourblind" = false,
        "world_map_size" = 0
    }
}

var player: Dictionary = {
	"displayName" =  "Player",

	"stamina" = 0.0,
	"staminaMax" = 0.0,

	"skills" = []
}

var inv: Dictionary = {
	"tools": []
}

var map: Dictionary = {
	"continents" = [],
	"tiles" = [],
	"adjacent" = [],
}

var quest: Dictionary = {}

# consts
const password: String = "Emizzy"
const SETTINGS: String = "user://saves/settings_save.json"
const PLAYER: String = "user://saves/player_save.json"
const INV: String = "user://saves/inventory_save.json"
const MAP: String = "user://saves/map_save.json"
const QUEST: String = "user://saves/quest_save.json"

func _ready():
	var dir = DirAccess.open("user://saves")

	# checks save folder exists
	if dir:
		var files: Array = []
		dir.list_dir_begin() 
		# check file name
		var file_name : String = dir.get_next()
		#looks through whole folder
		while file_name != "":
			# if the file is has a .tres extension, adds file and nicename to list
			files.append(file_name)
			file_name = dir.get_next()
		for file in files:
			load_data("user://saves/"+file)

	else:
		#first save creates directory
		print("First run, setting data to default")
		DirAccess.make_dir_absolute("user://saves")
		save(global.SETTINGS)
		save(global.PLAYER)
		save(global.INV)
		save(global.MAP)
		save(global.QUEST)

func load_data(file:String):
	#nonprod
	var save_file = FileAccess.open(file, FileAccess.READ)
	#password locked, for prod
	#var save_file = FileAccess.open_encrypted_with_pass(file, FileAccess.READ, PASS)

	var json = JSON.new()
	var parse_result = json.parse(save_file.get_line())
	if parse_result == OK:    
		match file:
			SETTINGS:
				global.settings = json.get_data()
			PLAYER:
				global.player = json.get_data()
			INV:
				global.inv = json.get_data()
			MAP:
				global.map = json.get_data()
			QUEST:
				global.quest = json.get_data()
			_:
				print("unexpected file found")

	else:
		print("JSON Parse Error: ", json.get_error_message(), " in ", file, " at line ", json.get_error_line())

func select_data(data: String):
	var _json_string: String
	match data:
		SETTINGS:
			_json_string = JSON.stringify(global.settings)
		PLAYER:
			_json_string = JSON.stringify(global.player)
		INV:
			_json_string = JSON.stringify(global.inv)
		MAP:
			_json_string = JSON.stringify(global.map)
		QUEST:
			_json_string = JSON.stringify(global.quest)
		_:
			print("unexpected json string")
	return _json_string

func save(data: String):
	# password locked, for prod
	#   var save_file = FileAccess.open_encrypted_with_pass(file_path, FileAccess.WRITE,PASS)
	# nonprod
	var file = FileAccess.open(data, FileAccess.WRITE)
	file.store_string(select_data(data))
	print("Saved: ", data)
	log.add_event("%s saved" % data,"system")

func soft_reset():
	settings = {
		"events" = 
		{
			"settings" = true,
			"time" = true,
			"story" = true,
			"loot" = true,
			"unlock" = true
		}
	}

func hard_reset():
	settings = {
		"events" =
		{
			"settings" = true,
			"time" = true,
			"story" = true,
			"loot" = true,
			"unlock" = true
		},
		"tabs_unlocked" =
		{
			"play" = {
				"combat" = false
			},
			"info" = {
				"dragons" = false,
				"inv" = false,
				"quests" = false,
			}
		}
	}

func set_directions(index: int):
	var pos_x: int = global.map["tiles"][index]["pos"][0]
	var pos_y: int = global.map["tiles"][index]["pos"][1]
	global.map["adjacent"].clear()
	global.map["adjacent"].append(get_tile_from_pos(pos_x-1,pos_y+1))
	global.map["adjacent"].append(get_tile_from_pos(pos_x,pos_y+1))
	global.map["adjacent"].append(get_tile_from_pos(pos_x+1,pos_y+1))
	global.map["adjacent"].append(get_tile_from_pos(pos_x-1,pos_y))
	global.map["adjacent"].append(global.map["tiles"][index])
	global.map["adjacent"].append(get_tile_from_pos(pos_x+1,pos_y))
	global.map["adjacent"].append(get_tile_from_pos(pos_x-1,pos_y-1))
	global.map["adjacent"].append(get_tile_from_pos(pos_x,pos_y-1))
	global.map["adjacent"].append(get_tile_from_pos(pos_x+1,pos_y-1))

func get_tile_from_pos(x:int, y:int):
	if x <= -23 or x >= 23:
		x = map_opposite_edge(x)
	if y <= -23 or y >= 23:
		y = map_opposite_edge(y)
	for tile in global.map["tiles"]:
		if tile["pos"][0] == x && tile["pos"][1] == y:
			return tile

func map_opposite_edge(coord: int):
	if coord == 23:
		coord = -22
	elif coord == -23:
		coord = 22
	return coord
