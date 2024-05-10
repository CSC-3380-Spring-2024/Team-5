extends Node

class_name playerManaager
var instance

# Player data
var player_health: float = 100
var player_position: Vector2 = Vector2(0, 0)
var max_speed: int = 350
var acceleration: int = 3500
var dodge_time: float = 0.5
var dodge_cooldown: float = 1.5
var dodge_speed_multiplier: float = 2
var player_experience: float = 0


func _get_instance():
	if not instance:
		instance = self
	return instance


func update_player_health(health: float) -> void:
	_get_instance().player_health = health


func update_player_position(position: Vector2) -> void:
	_get_instance().player_position = position

func update_player_experience(experience: float) -> void:
	_get_instance().player_experience = experience


func get_player_health() -> float:
	return _get_instance().player_health


func get_player_position() -> Vector2:
	return _get_instance().player_position


func get_max_speed() -> int:
	return _get_instance().max_speed


func get_acceleration() -> int:
	return _get_instance().acceleration


func get_dodge_time() -> float:
	return _get_instance().dodge_time

func get_dodge_cooldown() -> float:
	return _get_instance().dodge_cooldown


func get_dodge_speed_multiplier() -> float:
	return _get_instance().dodge_speed_multiplier

func get_player_experience() -> float:
	return _get_instance().player_experience
