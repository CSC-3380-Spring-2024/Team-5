extends Camera2D

@export var tilemap: TileMap
# Called when the node enters the scene tree for the first time.
"""
func _ready() -> void:
	setCam()
	pass # Replace with function body.
"""


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

"""
func setCam():
	if LevelManager.get_current_level()%3==0:
		var map_width_pixels = 110 * 80 
		var map_height_pixels = 55 * 40 
		limit_right = map_width_pixels
		limit_top = 55
		limit_left=135
		limit_bottom = map_height_pixels
		
		pass
	elif LevelManager.get_current_level()%2==0:
		var map_width_pixels = 55 * 80 
		var map_height_pixels = 55 * 80 
		limit_right = map_width_pixels
		limit_top = 55
		limit_left=135
		limit_bottom = map_height_pixels
		pass
	else:
		var map_width_pixels = 55 * 80 
		var map_height_pixels = 55 * 40 
		limit_right = map_width_pixels
		limit_top = 55
		limit_left=135
		limit_bottom = map_height_pixels
		pass
	"""
