extends Node

var data: Dictionary = {
    "displayName": "Player",

    "location": [0,0],

    "stamina": 0.0,
    "staminaMax": 0.0,

    "skills": []
}

func _ready():
    player.data = save.load_data(save.PLAYER, player.data, data)

func save_player():
    save.save_data(save.PLAYER, player.player)
