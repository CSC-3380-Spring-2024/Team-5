class_name Cannon extends "res://Scenes/Weapons/weapons_base.gd"


func _ready():
	speed = 400
	scale = Vector2(3,3)
	damage_amount = 200
	spread_radius = 0
	$WeaponCooldown.wait_time = 2.5


func _process(_delta):
	if(Input.is_action_pressed("attack")&&can_fire):
		fire()
		sfx_shoot.play()
		can_fire = false
		$WeaponCooldown.start()
