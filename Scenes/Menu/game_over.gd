extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _on_restart_pressed()-> void:
	LevelManager.set_current_level(1)
	get_tree().change_scene_to_file("res://Scenes/Levels/level_1.tscn")


func _on_return_home_pressed()-> void:
	LevelManager.set_current_level(1)
	get_tree().change_scene_to_file("res://Scenes/Menu/MainMenu.tscn")
	
