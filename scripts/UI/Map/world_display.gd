extends GridContainer

var tiles: Dictionary = {
	"Base" = "res://themes/base.tres",
	"Fire" = "res://themes/fire-light.tres",
	"Water" = "res://themes/water-light.tres",
	"Earth" = "res://themes/earth-light.tres",
	"Air" = "res://themes/air-dark.tres",
	"Arcane" = "res://themes/arcane-dark.tres",
	"Mystic" = "res://themes/mystic-light.tres",
	"Time" = "res://themes/time-dark.tres",
	"Summoner" = "res://themes/summoner-dark.tres",
	"Plant" = "res://themes/plant-light.tres",
	"Ghost" = "res://themes/ghost-dark.tres",
	"Hallow" = "res://themes/hallow-dark.tres",
	"Sea" = "res://themes/sea.tres",
}

var icons: Dictionary = {
	"Capital Dark" = load("res://assets/images/icons/capital-dark.png"),
	"City Dark" = load("res://assets/images/icons/city-dark.png"),
	"Town Dark" = load("res://assets/images/icons/town-dark.png"),
	"Capital Light" = load("res://assets/images/icons/capital-light.png"),
	"City Light" = load("res://assets/images/icons/city-light.png"),
	"Town Light" = load("res://assets/images/icons/town-light.png")
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
		var icon_info = [-1,false,-1]
		var tileButton: Button = Button.new()
		tileButton.theme = load(tiles[tile["type"]])
		tileButton.custom_minimum_size = tile_size
		tileButton.expand_icon = true
		if tiles[tile["type"]].contains("light"):
			icon_info[0] = true
		match tile["category"]:
			"Capital":
				icon_info[1] = 0				
			"City":
				icon_info[1] = 1				
			"Town":
				icon_info[1] = 2				
		print(icon_info)	
		match (icon_info):
			[false,0]:
				image = icons["Capital Dark"]
			[false,1]:
				image = icons["City Dark"]
			[false,2]:
				image = icons["Town Dark"]
			[true,0]:
				image = icons["Capital Light"]
			[true,1]:
				image = icons["City Light"]
			[true,2]:
				image = icons["Town Light"]
		tileButton.icon = image
		add_child(tileButton)

