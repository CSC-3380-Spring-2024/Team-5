extends Camera2D



func _ready() -> void:
	setCam()
	

	pass 

func setCam():
	var map_width_pixels: int  = 0
	var map_height_pixels: int = 0 
	if LevelManager.get_current_level()%3==0:
		map_width_pixels  = 110 * 81 
		map_height_pixels = 55 * 40 
		limit_right = map_width_pixels
		limit_top = 55
		limit_left=135
		limit_bottom = map_height_pixels
		#all base members of base Camera
		
		pass
	elif LevelManager.get_current_level()%3==2:
		map_width_pixels = 55 * 80 
		map_height_pixels = 55 * 81 
		limit_right = map_width_pixels
		limit_top = 55
		limit_left=135
		limit_bottom = map_height_pixels
		#all base members of base Camera
		pass
	else:
		map_width_pixels = 55 * 80 
		map_height_pixels = 55 * 40 
		limit_right = map_width_pixels
		limit_top = 55
		limit_left=135
		limit_bottom = map_height_pixels
		#all base members of base Camera
		pass
	
