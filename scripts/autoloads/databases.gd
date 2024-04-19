extends Node

var actions: Array = []

const ACTIONS = "res://assets/databases/actions/actions.csv"

func _ready():
	populate("actions")

func populate(data:String):
	var file: FileAccess 
	match data:
		"actions":
			file = FileAccess.open("res://assets/databases/actions/actions.csv", FileAccess.READ)
	while !file.eof_reached():
		database_entry(data, file.get_csv_line())

func database_entry(data: String, entry: Array):
	match data:
		"actions":
			var action: Dictionary = {
				"name": entry[0],
				"dragon": true if entry[1] == "Yes" else false,
				"type":entry[2],
				"action":entry[3]
			}
			actions.append(action)