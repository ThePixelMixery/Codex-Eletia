extends Node

var inv: Dictionary = {
    "tools": []
}

var map: Dictionary = {
	"continents": [],
	"tiles": [],
	"adjacent": {},
}

var player: Dictionary = {
    "displayName": "Player",

    "stamina": 0.0,
    "staminaMax": 0.0,

    "skills": []
}

############## settings

var settings: Dictionary = {
	"events":{
		"settings": true,
		"time": true,
		"story": true,
		"loot": true,
		"unlock": true
	}
}


const PASS = "Emizzy"
const SETTINGS = "user://saves/settings_save.json"
const PLAYER = "user://saves/player_save.json"
const INVENTORY = "user://saves/inventory_save.json"
const MAP = "user://saves/map_save.json"
const QUEST = "user://saves/quest_save.json"

func load_data(file_path: String, data: Variant, base_data: Variant) -> Variant:
    
    var loaded_data = data

    #first save creates directory
    if not FileAccess.file_exists(file_path):
        print("First run, setting data to default")
        DirAccess.make_dir_absolute("user://saves")
        save_data(file_path, base_data)
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
    var subject: String = file_path
            
    log.add_event("%s saved" % subject,"system")



func soft_reset():
    settings = {
        "events": 
        {
            "settings": true,
            "time": true,
            "story": true,
            "loot": true,
            "unlock": true
        }
    }

func hard_reset():
    settings = {
        "events":
        {
            "settings": true,
            "time": true,
            "story": true,
            "loot": true,
            "unlock": true
        },
        "tabs_unlocked":
        {
            "play" = {
                "combat": false
            },
            "info" = {
                "dragons": false,
                "inv": false,
                "quests": false,
            }
        }
    }
