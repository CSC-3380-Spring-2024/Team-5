
extends Area2D
const GameManager = preload("res://Scenes/Map/Levels/level_manager.gd")

func _ready():
	var whirlpool_sprite = get_node("whirlpool_sprite") as AnimatedSprite2D
	whirlpool_sprite.play("default")
	pass

func _on_area_entered(area: Area2D):
	if area.is_in_group("player"):
		if(get_tree().current_scene.scene_file_path.to_int() != 3):
			var next_lvl_num = get_tree().current_scene.scene_file_path.to_int() + 1
			var next_lvl_path = "res://Scenes/Map/Levels/level_" + str(next_lvl_num) + ".tscn"
			LevelManager.increase_level()
			print(LevelManager.get_current_level())
			get_tree().change_scene_to_file(next_lvl_path)
		else:
			get_tree().change_scene_to_file("res://Scenes/Map/Levels/level_1.tscn")
			LevelManager.increase_level()
			print(LevelManager.get_current_level())


	


