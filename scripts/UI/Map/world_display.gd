extends GridContainer

var tiles: Dictionary = {
	"Base" = load("res://assets/images/tiles/base.png"),
	"Fire" = load("res://assets/images/tiles/world_fire.png"),
	"Water" = load("res://assets/images/tiles/world_water.png"),
	"Earth" = load("res://assets/images/tiles/world_earth.png"),
	"Air" = load("res://assets/images/tiles/world_air.png"),
	"Arcane" = load("res://assets/images/tiles/world_arcane.png"),
	"Mystic" = load("res://assets/images/tiles/world_mystic.png"),
	"Time" = load("res://assets/images/tiles/world_time.png"),
	"Summoner" = load("res://assets/images/tiles/world_summoner.png"),
	"Plant" = load("res://assets/images/tiles/world_plant.png"),
	"Ghost" = load("res://assets/images/tiles/world_ghost.png"),
	"Hallow" = load("res://assets/images/tiles/world_hallow.png"),
	"Sea" = load("res://assets/images/tiles/world_sea.png"),
}
var tile_size: = Vector2(40,40)

func _ready():
	emit.connect("map_generated", populate_tiles)
	if global.map["tiles"].size() != 0:
		populate_tiles()

func populate_tiles():
	if get_child_count() != 0:
		for child in get_children():
			child.queue_free() 

	var image: CompressedTexture2D
	print("populating world UI")
	for tile in global.map["tiles"]:
		var tileButton = Button.new()
		tileButton.set_size(tile_size)
		image = tiles[tile["type"]]
		tileButton.custom_minimum_size = tile_size
		tileButton.expand_icon = true
		tileButton.icon = image
		add_child(tileButton)
