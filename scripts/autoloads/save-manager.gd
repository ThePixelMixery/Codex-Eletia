extends Node

const SETTINGS_SAVE_PATH = "user://saves/settings_save.json"
const PLAYER_SAVE_PATH = "user://saves/player_save.json"
const INVENTORY_SAVE_PATH = "user://saves/inventory_save.json"
const MAP_SAVE_PATH = "user://saves/map_save.json"
const QUEST_SAVE_PATH = "user://saves/quest_save.json"
const PASS = "Emizzy"

func load_data(file_path: String,  data: Variant) -> Variant:
	
	var loaded_data

	#first save creates directory
	if not FileAccess.file_exists(file_path):
		print("First run, setting data to default")
		DirAccess.make_dir_absolute("user://saves")
		save_data(file_path,  data)
	else:
		#nonprod
		var save_file = FileAccess.open(file_path, FileAccess.READ)
		#password locked, for prod
		#var save_file = FileAccess.open_encrypted_with_pass(file_path, FileAccess.READ, PASS)
		print("Found a save at ", file_path)
		var json = JSON.new()
		var parse_result = json.parse(save_file.get_line())
		if parse_result == OK:
			loaded_data = json.get_data()
		else:
			print("JSON Parse Error: ", json.get_error_message(), " in ", file_path, " at line ", json.get_error_line())

	return loaded_data


func save_data(file_path: String, data: Variant):
	#nonprod
	var save_file = FileAccess.open(file_path, FileAccess.WRITE)
	#password locked, for prod
	#var save_file = FileAccess.open_encrypted_with_pass(file_path, FileAccess.WRITE,PASS)
	var json_string = JSON.stringify(data)
	save_file.store_line(json_string)

	#Tells you what saved
	var subject: String
	match file_path:
		SETTINGS_SAVE_PATH:
			subject = "Settings"
		PLAYER_SAVE_PATH:
			subject = "Player"
		INVENTORY_SAVE_PATH:
			subject = "Inventory"
		MAP_SAVE_PATH:
			subject = "Map"
		QUEST_SAVE_PATH:
			subject = "Quest"
			
	log.add_event("%s saved" % subject,"system")


func _on_button_test_pressed():
	maps.map_gen()
