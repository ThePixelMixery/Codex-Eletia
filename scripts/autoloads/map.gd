extends Node

var map: Dictionary = {
	"continents": [],
	"world_size":1,
	"tiles": []
}

var map_gen_script: Script = load("res://scripts/singletons/map_gen.gd")


signal map_generated

func _ready():
	maps.map = save.load_data(save.MAP, maps.map, map)
	
func map_gen():
	maps.map_gen_script.call("generate_map", true)
	# map_generated.emit()
	save.save_data(save.MAP, maps.map)
