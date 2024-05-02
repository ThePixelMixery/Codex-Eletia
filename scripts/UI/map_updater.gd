extends Node

@onready var cont_grid: GridContainer = $HBox_Map/Control_Map/Grid_Conts
@onready var explore_grid: GridContainer = $HBox_Map/Control_Map/Grid_Explore
@onready var world_grid: GridContainer = $HBox_Map/Control_Map/Scroll_World/Grid_World

var cont_array: Array 
var world_array: Array 

	
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
		#populate_tiles()

func populate_ui():
	populate_conts()
	#populate_tiles()
	pass

func populate_conts():
	print("populating cont UI")
	#adding tooltips and info
	for i in range(global.map["continents"].size()):
		var cont_label: Label = cont_array[i].get_child(0)
		#if global.map["continents"][i]["disovered"]:
			#cont_label.text = global.map["continents"][i]["type"]
		cont_label.text = global.map["continents"][i]["type"]

func populate_tiles():
	var image: CompressedTexture2D
	print("populating world UI")
	for i in global.map["tiles"].size()-1:
		var tex = TextureRect.new()
		match global.map["tiles"][i]["type"]:
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
		tex.texture = image
		world_grid.add_child(tex)
