class_name Sniper extends "res://Scenes/Weapons/weapons_base.gd"

func _ready():
	speed = 1400
	scale_vector = Vector2(1,1)
	damage_amount = 100
	$WeaponCooldown.wait_time = 1.3

