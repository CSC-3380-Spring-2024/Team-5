extends CharacterBody2D

#Able to alter any of these values for upgrades
@export var max_health: float = 100
var current_health:= max_health 

@export var max_speed: int = 350
@export var acceleration: int = 3500
@export var dodge_time: float = 0.5
@export var dodge_cooldown: float = 1.5
@export var dodge_speed_multiplier: float = 2
@onready var damage_numbers_origin: Node2D = $DamageNumbersOrigin

@onready var sfx_take_damage: Node = $sfx_take_damage

var invunerable: bool = false
var is_dead: bool =false
var enemies_in_hitbox:Array =[];

var weapon_type: Dictionary = {
	sniper = "res://Scenes/Weapons/Types/sniper.tscn",
	machine_gun = "res://Scenes/Weapons/Types/machine_gun.tscn",
	cannon = "res://Scenes/Weapons/Types/cannon.tscn",
	shotgun = "res://Scenes/Weapons/Types/shotgun.tscn",
	pulse = "res://Scenes/Weapons/Types/shotgun.tscn",
	weapon_base = "res://Scenes/Weapons/weapon_base.tscn"
}

func _ready() -> void:
	set_bars()
	set_cooldown()
	$damageTimer.timeout.connect(_on_damage_timer_timeout)
	#change_weapon("pulse")

func _process(_delta) -> void:
	$CooldownBar.value = $CooldownTimer.time_left
	$AnimatedSprite2D.play()

func take_damage(amount: float) -> void:
	sfx_take_damage.play()
	current_health -= amount
	$HealthBar.value = current_health
	if current_health<=0:
		die();

func die() -> void:
	is_dead=true
	get_tree().change_scene_to_file("res://Scenes/Menu/game_over.tscn")

func _on_player_hitbox_area_entered(area) -> void:
	if area.is_in_group("seashell"):
		print("shell collected")
	if area.is_in_group("heart"):
		if current_health!=max_health:
			current_health += 20 
			$HealthBar.value = current_health
	if area.is_in_group("enemy"):
		enemies_in_hitbox.append(area)
		take_damage(15)
		DamageNumbers.display_number(15, damage_numbers_origin.global_position)
		$damageTimer.start();
		$HealthBar.value = current_health

func _on_player_hitbox_area_exited(area) -> void:
	if area.is_in_group("enemy"):
		enemies_in_hitbox.erase(area)
		$damageTimer.stop()

func _on_damage_timer_timeout() -> void:
	for enemy in enemies_in_hitbox:
		take_damage(15)


func set_bars() -> void:
	$CooldownBar.max_value = dodge_cooldown
	$HealthBar.max_value = max_health
	$HealthBar.value = current_health

func set_cooldown() -> void:
	$CooldownTimer.wait_time = dodge_cooldown

#String weapon is name of var in weapon_types dict
func change_weapon(weapon: String) -> void:
	if $Hand/Sprite2D.get_child_count() != 0:
		$Hand/Sprite2D.get_child(0).queue_free()  
	var new_weapon_instance = load(weapon_type[weapon]).instantiate() 
	$Hand/Sprite2D.add_child(new_weapon_instance)  

