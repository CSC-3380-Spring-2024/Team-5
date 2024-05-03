class_name Shotgun extends WeaponBase

func _ready() -> void:
	speed = 600
	scale_vector = Vector2(0.5,0.5)
	damage_amount = 2.5
	spread_radius = 20
	$WeaponCooldown.wait_time = 1


func _process(_delta) -> void:
	if(Input.is_action_pressed("attack")&&can_fire):
		for x in 50:
			fire()
		sfx_shoot.play()
		can_fire = false
		$WeaponCooldown.start()
