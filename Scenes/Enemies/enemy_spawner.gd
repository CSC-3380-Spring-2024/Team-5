extends spawner
const GameManager = preload("res://Scenes/Levels/level_manager.gd")
var entitySpawns: int =1 ;

var colors: Array = [
	Color(0, 1, 0),
	Color(0, 1, 1),
	Color(0, 0.5, 1)
]

func _ready():
    super._ready()
    entitySpawns+=LevelManager.get_current_level()*5
    set_entity(load("res://Scenes/Enemies/jellyfish.tscn"), 220)
    spawn_entities(entitySpawns, colors, "jellyfishSprite")

func is_valid_entity(new_pos: Vector2, effective_radius: float):
    return super.is_valid_entity(new_pos, effective_radius)