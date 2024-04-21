extends HBoxContainer

@onready var tabs: TabContainer = $Tab_Map

@onready var cont_map: GridContainer = $Control_Map/Grid_Conts
@onready var world_map: GridContainer = $Control_Map/Grid_Explore
@onready var explore_map: ScrollContainer = $Control_Map/Scroll_World

var tab_array: Array = []

func _ready():
	tab_array = [cont_map, world_map, explore_map]

func _on_tab_map_tab_clicked(tab):
	hide_all()
	match tab:
		0:
			explore_map.show()
		1:
			cont_map.show()
		2:
			world_map.show()

func hide_all():
	for map in tab_array:
		map.hide()