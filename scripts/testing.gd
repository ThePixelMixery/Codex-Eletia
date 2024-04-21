extends Control


func _on_button_test_pressed():
	maps.map_gen()

func _on_button_test_2_pressed():
	emit.map_generated.emit()
