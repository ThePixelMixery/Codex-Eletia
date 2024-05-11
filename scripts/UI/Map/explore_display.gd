extends Node



func _ready():
	emit.connect("map_generated", populate_explore)
	if global.map["adjacent"].size() != 0:
		populate_explore()

func populate_explore():
	print("populating explore UI")

	if get_child_count() != 0:
		for child in get_children():
			child.queue_free() 
	
	for dir in global.map["adjacent"].size():
		var tile_info = global.map["adjacent"][dir]
		
		var dir_button: Button = Button.new()
		dir_button.size_flags_horizontal= Control.SIZE_EXPAND_FILL
		dir_button.size_flags_vertical= Control.SIZE_EXPAND_FILL
		add_child(dir_button)

		var vbox: VBoxContainer = VBoxContainer.new()
		vbox.set_anchors_preset(Control.PRESET_FULL_RECT)
		vbox.size_flags_horizontal= Control.SIZE_EXPAND_FILL
		vbox.size_flags_vertical= Control.SIZE_EXPAND_FILL
		dir_button.add_child(vbox)

		var label: Label = Label.new()
		label.horizontal_alignment = HORIZONTAL_ALIGNMENT_CENTER
		label.vertical_alignment = VERTICAL_ALIGNMENT_CENTER
		label.size_flags_vertical= Control.SIZE_EXPAND_FILL
		label.size_flags_horizontal= Control.SIZE_EXPAND_FILL
		label.size_flags_stretch_ratio = 0.25
		label.text = tile_info["name"]
		vbox.add_child(label)

		var action_grid: GridContainer = GridContainer.new()
		action_grid.size_flags_vertical= Control.SIZE_EXPAND_FILL
		action_grid.size_flags_horizontal= Control.SIZE_EXPAND_FILL
		vbox.add_child(action_grid)

