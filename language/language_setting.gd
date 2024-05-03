extends Node

func _on_return_pressed():
	get_tree().change_scene_to_file("res://Scenes/options.tscn")

func _on_option_button_item_selected(index):
	if index == 0:
		TranslationServer.set_locale("en")
	elif index == 1:
		TranslationServer.set_locale("zh")
