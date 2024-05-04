extends spawner
const GameManager = preload("res://Scenes/Levels/level_manager.gd")
var entitySpawns: int = 5;

var colors = [
	Color(0, 1, 0),
	Color(0, 1, 1),
	Color(0, 0.5, 1)
]

func _ready():
	entitySpawns+=LevelManager.get_current_level()*2
	super._ready()
	set_entity(load("res://Scenes/Collectibles/heart.tscn"), 100)
	spawn_entities(entitySpawns)

func is_valid_entity(new_pos, effective_radius):
	return super.is_valid_entity(new_pos, effective_radius)
