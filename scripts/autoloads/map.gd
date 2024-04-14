extends Node

var map: Array = []

var map_gen_script: Script = load("res://scripts/singletons/map_gen.gd")

signal map_generated

func _ready():
	maps.map = save.load_data(save.MAP_SAVE_PATH, maps.map)

func map_gen():
	maps.map_gen_script.call("generate_map", true)
	save.save_data(save.MAP_SAVE_PATH, maps.map)

func _on_button_test_2_pressed():
	map_generated.emit()
