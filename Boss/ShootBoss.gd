extends stateBoss

class_name ShootBoss
@export var bullet_boss_node :PackedScene

@onready var timer = $Timer

func transition():
	if not ray_cast.is_colliding():
		if owner.health == 2:
			get_parent().change_state("Follow")
		else:
			get_parent().change_state("Dash")

func enter():
	super.enter()
	timer.start()

func exit():
	super.exit()
	timer.stop()


func _on_timer_timeout():
	ShootBoss()


func ShootBoss():
	var bullet = bullet_boss_node.instantiate()
	
	bullet.position = global_position
	bullet.direction = (player.global_position - global_position).normalized()
	
	get_tree().current_scene.call_deferred("add_child",bullet)
