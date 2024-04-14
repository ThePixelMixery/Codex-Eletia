extends Node

var displayName: String

var location: Array

var stamina: float
var staminaMax: float

var skills: Array

func save_player():
    save.save_data(save.PLAYER_SAVE_PATH, player)
