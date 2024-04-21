extends Node

@onready var check_settings: CheckButton = $VBox_Events/HBox_Title/Check_Settings
@onready var settings_box: HBoxContainer = $VBox_Events/HBox_Title/HBox_Settings
@onready var check_time: CheckButton = $VBox_Events/HBox_Title/HBox_Settings/Check_Time
@onready var check_story: CheckButton = $VBox_Events/HBox_Title/HBox_Settings/Check_Story
@onready var check_loot: CheckButton = $VBox_Events/HBox_Title/HBox_Settings/Check_Loot
@onready var check_unlock: CheckButton = $VBox_Events/HBox_Title/HBox_Settings/Check_Unlock
@onready var log_box: VBoxContainer = $VBox_Events/VBox_Log

func _ready():
	emit.connect("log_entry",log_entry)
	
	check_settings.button_pressed = sets.settings["events"]["settings"]
	_on_check_settings_toggled(sets.settings["events"]["settings"])
	check_time.button_pressed = sets.settings["events"]["time"]
	check_story.button_pressed = sets.settings["events"]["story"]
	check_loot.button_pressed = sets.settings["events"]["loot"]
	check_unlock.button_pressed = sets.settings["events"]["unlock"]

func save_settings():
	save.save_data(save.SETTINGS, sets.settings)

func _on_check_time_toggled(toggled_on:bool):
	sets.settings["events"]["time"] = toggled_on
	save_settings()

func _on_check_story_toggled(toggled_on:bool):
	sets.settings["events"]["story"] = toggled_on
	save_settings()

func _on_check_loot_toggled(toggled_on:bool):
	sets.settings["events"]["loot"] = toggled_on
	save_settings()

func _on_check_unlock_toggled(toggled_on:bool):
	sets.settings["events"]["unlock"] = toggled_on
	save_settings()

func _on_check_settings_toggled(toggled_on:bool):
	sets.settings["events"]["settings"] = toggled_on
	save_settings()
	if (toggled_on):
		settings_box.show()
	else:
		settings_box.hide()

func log_entry(entry:Node):
	log_box.add_child(entry)
