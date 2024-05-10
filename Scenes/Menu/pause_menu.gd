extends Control

@onready var player : Node= get_node("/root/PlayerManager")

var _is_paused:bool = false:
	set = set_paused

func _unhandled_input(event):
	if event.is_action_pressed("esc"):
		_is_paused = !_is_paused
		set_paused(_is_paused)

func set_paused(value:bool) ->void:
	_is_paused = value
	get_tree().paused = _is_paused
	visible = _is_paused
	if _is_paused:
		AudioServer.set_bus_mute(AudioServer.get_bus_index("Master"), true)
	else:
		AudioServer.set_bus_mute(AudioServer.get_bus_index("Master"), false)


func unpause_game():
	set_paused(false)

func _on_resume_pressed():
	_is_paused = false


func _on_restart_pressed():
	player.update_player_health(100)
	player.update_player_experience(0)
	LevelManager.set_current_level(1)
	set_paused(false)
	get_tree().change_scene_to_file("res://Scenes/Levels/level_1.tscn")

func _on_quit_pressed():
	set_paused(false)
	get_tree().quit()

func _on_main_menu_pressed():
	player.update_player_health(100)
	LevelManager.set_current_level(1)
	set_paused(false)
	get_tree().change_scene_to_file("res://Scenes/Menu/MainMenu.tscn")

func _on_fullscreen_toggled(toggled_on):
	
		if toggled_on:
			DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_FULLSCREEN)
		else:
			DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)

func _on_vsync_item_selected(index):
	DisplayServer.window_set_vsync_mode(index)

func _on_borderless_toggled(toggled_on):
	DisplayServer.window_set_flag(DisplayServer.WINDOW_FLAG_BORDERLESS, toggled_on)
