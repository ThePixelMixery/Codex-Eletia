extends GridContainer

func _ready():
	emit.connect("map_generated", populate_conts)
	if global.map["continents"].size() != 0:
		populate_conts()

func populate_conts():
	print("populating cont UI")

	if get_child_count() != 0:
		for child in get_children():
			child.queue_free() 

	for cont in global.map["continents"]:
		var cont_button: Button = Button.new()
		cont_button.set_anchors_preset(Control.PRESET_FULL_RECT)
		cont_button.size_flags_horizontal= Control.SIZE_EXPAND_FILL
		cont_button.size_flags_vertical= Control.SIZE_EXPAND_FILL
		add_child(cont_button)
		
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
