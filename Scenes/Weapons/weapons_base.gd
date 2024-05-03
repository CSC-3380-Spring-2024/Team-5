class_name WeaponBase extends Node2D

@export var direction: Vector2
@export var speed: float = 400
@export var scale_vector: Vector2 = Vector2(3,3)
@export var damage_amount: float = 10
@export var cooldown: float = 1
@export var spread_radius: float = 0
var can_fire: bool = true
var rng = RandomNumberGenerator.new()

@onready var sfx_shoot: Node = $sfx_shoot
var projectile_scene: PackedScene = preload("res://Scenes/Weapons/projectile.tscn")

func ready():
	$WeaponCooldown.wait_time = cooldown

func _process(_delta):
	if(Input.is_action_pressed("attack")&&can_fire):
		fire()
		sfx_shoot.play()
		can_fire = false
		$WeaponCooldown.start()

func fire() -> void:
	var projectile = projectile_scene.instantiate()
	projectile.direction = $AimDirection.global_position - global_position
	projectile.direction += Vector2(rng.randf_range(-spread_radius,spread_radius),rng.randf_range(-spread_radius,spread_radius))
	projectile.global_position = global_position
	projectile.scale = scale_vector
	projectile.speed = speed
	projectile.damage_amount = damage_amount
	get_tree().get_root().add_child(projectile)

func _on_weapon_cooldown_timeout():
	$WeaponCooldown.stop()
	can_fire = true
