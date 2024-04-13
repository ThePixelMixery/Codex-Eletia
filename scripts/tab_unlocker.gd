extends Node

static var info_locked: Control
static var info_tab: TabContainer
static var play_locked: Control
static var play_tab: TabContainer

static var locked_info: Array
static var unlocked_info: Array
static var locked_play: Array
static var unlocked_play: Array

func _ready():
	info_locked = $/root/Control_Base/Split_Base/Info_Locked
	info_tab = $/root/Control_Base/Split_Base/Tab_Info
	play_locked = $/root/Control_Base/Split_Base/Split_Log/Play_Locked
	play_tab = $/root/Control_Base/Split_Base/Split_Log/Tab_Play

	locked_info = info_locked.get_children()
	unlocked_info = info_tab.get_children()
	locked_play = play_locked.get_children()
	unlocked_play = play_tab.get_children()

static func unlock(info:bool, tab_name: String):
	var tab_to_move: Node
	if info:
		for tab in locked_info:
			if tab.name == tab_name:
				tab_to_move = tab
		if tab_to_move != null:
			tab_to_move.reparent(info_tab)
	else:
		for tab in locked_play:
			if tab.name == tab_name:
				tab_to_move = tab
		if tab_to_move != null:
			tab_to_move.reparent(play_tab)
