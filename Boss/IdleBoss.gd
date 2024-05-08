extends stateBoss
class_name IdleBoss

func transition():
	if ray_cast.is_colliding():
		get_parent().change_state("Shoot")
