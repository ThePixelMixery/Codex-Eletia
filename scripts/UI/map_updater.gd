extends Node

@onready var cont_grid: GridContainer = $HSplit_Map/Control_Map/Control_Buffer/Grid_Conts
@onready var explore_grid: GridContainer = $HSplit_Map/Control_Map/Control_Buffer/Grid_Explore
@onready var world_grid: GridContainer = $HSplit_Map/Control_Map/Control_Buffer/Scroll_World/Grid_World

var cont_array: Array 
var world_array: Array 
var tile_size: = Vector2(40,40)
	
var base: CompressedTexture2D = load("res://assets/images/tiles/base.png")
var fire: CompressedTexture2D = load("res://assets/images/tiles/world_fire.png")
var water: CompressedTexture2D = load("res://assets/images/tiles/world_water.png")
var earth: CompressedTexture2D = load("res://assets/images/tiles/world_earth.png")
var air: CompressedTexture2D = load("res://assets/images/tiles/world_air.png")
var arcane: CompressedTexture2D = load("res://assets/images/tiles/world_arcane.png")
var mystic: CompressedTexture2D = load("res://assets/images/tiles/world_mystic.png")
var time: CompressedTexture2D = load("res://assets/images/tiles/world_time.png")
var summoner: CompressedTexture2D = load("res://assets/images/tiles/world_summoner.png")
var plant: CompressedTexture2D = load("res://assets/images/tiles/world_plant.png")
var overseer: CompressedTexture2D = load("res://assets/images/tiles/world_overseer.png")
var ghost: CompressedTexture2D = load("res://assets/images/tiles/world_ghost.png")
var channel: CompressedTexture2D = load("res://assets/images/tiles/world_channel.png")
var hallow: CompressedTexture2D = load("res://assets/images/tiles/world_hallow.png")
var sea: CompressedTexture2D = load("res://assets/images/tiles/world_sea.png")

func _ready():
	emit.connect("map_generated", populate_ui)
	
	cont_array = cont_grid.get_children()
	world_array = world_grid.get_children()
	if global.map["continents"] != []:
		populate_conts()
		populate_tiles()

func populate_ui():
	populate_conts()
	populate_tiles()

func populate_conts():
	print("populating cont UI")

	if cont_grid.get_child_count() != 0:
		for child in cont_grid.get_children():
			child.queue_free() 

	for cont in global.map["continents"]:
		var cont_button: Button = Button.new()
		cont_button.set_anchors_preset(Control.PRESET_FULL_RECT)
		cont_button.size_flags_horizontal= Control.SIZE_EXPAND_FILL
		cont_button.size_flags_vertical= Control.SIZE_EXPAND_FILL
		cont_grid.add_child(cont_button)
		
		var cont_label: Label = Label.new()
		
		#label inside cont tile
		cont_label.set_anchors_preset(Control.PRESET_FULL_RECT)
		cont_label.horizontal_alignment = HORIZONTAL_ALIGNMENT_CENTER
		cont_label.vertical_alignment = VERTICAL_ALIGNMENT_CENTER
		cont_label.size_flags_horizontal= Control.SIZE_EXPAND_FILL
		cont_label.size_flags_vertical= Control.SIZE_EXPAND_FILL
		#if global.map["continents"][i]["disovered"]:
			#cont_label.text = global.map["continents"][i]["type"]
		if cont["size"] == 0:
			cont_label.text = cont["type"] + "\n Capital"
		else:
			cont_label.text = cont["type"]
		cont_button.add_child(cont_label)

func populate_tiles():

	if world_grid.get_child_count() != 0:
		for child in world_grid.get_children():
			child.queue_free() 

	var image: CompressedTexture2D
	print("populating world UI")
	for tile in global.map["tiles"]:
		var tileButton = Button.new()
		tileButton.set_size(tile_size)
		match tile["type"]:
			"Fire":
				image = fire
			"Water":
				image = water
			"Earth":
				image = earth
			"Air":
				image = air
			"Arcane":
				image = arcane
			"Mystic":
				image = mystic
			"Time":
				image = time
			"Summoner":
				image = summoner
			"Plant":
				image = plant
			"Overseer":
				image = overseer
			"Ghost":
				image = ghost
			"Channel":
				image = channel
			"Hallow":
				image = hallow
			"Sea":
				image = sea
			_:
				image = base		
		tileButton.custom_minimum_size = tile_size
		tileButton.expand_icon = true
		tileButton.icon = image
		world_grid.add_child(tileButton)
