extends Node

const SETTINGS_SAVE_PATH = "user://saves/settings_save.json"
const PASS = "Emizzy"

func load_data(file_path: String, default_data: Variant) -> Variant:
	var loaded_data = default_data

	if not FileAccess.file_exists(file_path):
		print("First run, setting data to default")
		DirAccess.make_dir_absolute("user://saves")
		save_data(file_path, default_data)
	else:
		var save_file = FileAccess.open_encrypted_with_pass(file_path, FileAccess.READ, PASS)
		print("Found a save at ", file_path)
		var json = JSON.new()
		var parse_result = json.parse(save_file.get_line())
		if parse_result == OK:
			loaded_data = json.get_data()
		else:
			print("JSON Parse Error: ", json.get_error_message(), " in ", file_path, " at line ", json.get_error_line())

	return loaded_data


func save_data(file_path: String, data: Variant):
	var save_file = FileAccess.open_encrypted_with_pass(file_path, FileAccess.WRITE,PASS)
	var json_string = JSON.stringify(data)
	save_file.store_line(json_string)
	print(file_path, " saved")
