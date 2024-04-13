extends Node

var settings: Dictionary = {
    "events":{
        "settings": true,
        "time": true,
        "story": true,
        "loot": true,
        "unlock": true
    }

}

func _ready():
    sets.settings = save.load_data(save.SETTINGS_SAVE_PATH, settings)


func soft_reset():
    settings = {
        "events":{
        "settings": true,
        "time": true,
        "story": true,
        "loot": true,
        "unlock": true
    }
}

func hard_reset():
    settings = {
        "events":{
            "settings": true,
            "time": true,
            "story": true,
            "loot": true,
            "unlock": true
        },
        "tabs_unlocked":{
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
