extends Node

@onready var cont_grid: GridContainer = $HBox_Map/Control_Map/Grid_Continent
@onready var world_grid: GridContainer = $HBox_Map/Control_Map/Grid_World

var cont_array: Array 
var world_array: Array 

func _ready():
	cont_array = cont_grid.get_children()
	world_array = world_grid.get_children()
	populate_conts()


func _on_node_map_map_generated():
	populate_conts()


func populate_conts():
	print("populating cont UI")
	#adding tooltips and info
	for i in range(36):
		world_array[i].tooltip_text = maps.map[i]["type"]
		var cont_label: Label = world_array[i].get_child(0)
		cont_label.text = maps.map[i]["type"]