extends Control


func _on_button_test_pressed():
	emit.generate_map.emit(global.map)

func _on_button_test_2_pressed():
	emit.map_generated.emit()
