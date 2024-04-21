extends Node

var map: Dictionary = {
	"continents": [],
	"tiles": [],
	"world_size":6
}

var map_gen_script: Script = load("res://scripts/statics/map_gen.gd")

func _ready():
	maps.map = save.load_data(save.MAP, maps.map, map)
	
func map_gen():
	maps.map_gen_script.call("generate_map", true)
	save.save_data(save.MAP, maps.map)
