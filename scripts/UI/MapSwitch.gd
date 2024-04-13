extends HBoxContainer

@onready var tabs: TabContainer = $Tab_Map
@onready var cont_map: GridContainer = $Control_Map/Grid_Continent
@onready var world_map: GridContainer = $Control_Map/Grid_World

func _ready():
	print(cont_map)
	print(world_map)

func _on_tab_map_tab_clicked(tab):
	if tab:
		world_map.hide()
		cont_map.show()
	else:
		world_map.show()
		cont_map.hide()
