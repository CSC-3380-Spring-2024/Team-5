class_name WalkingState extends State

var max_speed: int 
var acceleration: int 
var dodging: bool = false
var can_dodge: bool = true
var dodge_time: float 
var dodge_cooldown: float 
var dodge_speed_mult: float
@onready var sfx_dodge = $"../../sfx_dodge"

var alter_max_speed: int
var player: Node = null
var animator: Node = null
var cooldown_timer: Node = null

func _ready() -> void:
	player = get_parent().get_parent()
	animator = player.get_node("AnimatedSprite2D")
	cooldown_timer = player.get_node("CooldownTimer")
	
	max_speed=player.max_speed
	acceleration=player.acceleration
	dodge_time=player.dodge_time
	dodge_cooldown=player.dodge_cooldown
	dodge_speed_mult = player.dodge_speed_multiplier
	
	alter_max_speed = max_speed
	$DodgeTimer.wait_time = dodge_time
	player.set_bars()

func physics_update(delta: float) -> void: 
	movement_handler(delta)

func movement_handler(delta: float) -> void:
	var direction: Vector2
	if (!dodging):
		direction = get_input_direction()
		if direction == Vector2.ZERO:
			player.velocity=Vector2.ZERO
			state_machine.transition_to("IdleState")
		else:
			accelerate(direction * acceleration * delta)
		player.move_and_slide()
		if Input.is_action_just_pressed("dodge")&&can_dodge:
			dodge()
			sfx_dodge.play()
	else: #accelerate fast & direction locked while dodge
		player.move_and_slide()



func get_input_direction() -> Vector2:
	var direction: Vector2
	direction.x = Input.get_action_strength("moveRight") - Input.get_action_strength("moveLeft")
	direction.y = Input.get_action_strength("moveDown") - Input.get_action_strength("moveUp")
	#also handle animation here
	match direction:
		Vector2(0, -1):
			animator.animation = "b_walk"
			animator.flip_h = false
		Vector2(0, 1):
			animator.animation = "f_walk"
			animator.flip_h = false
		Vector2(-1, 0):
			animator.animation = "fr_walk"
			animator.flip_h = true
		Vector2(-1, -1):
			animator.animation = "br_walk"
			animator.flip_h = true
		Vector2(-1, 1):
			animator.animation = "fr_walk"
			animator.flip_h = true
		Vector2(1, 0):
			animator.animation = "fr_walk"
			animator.flip_h = false
		Vector2(1, -1):
			animator.animation = "br_walk"
			animator.flip_h = false
		Vector2(1, 1):
			animator.animation = "fr_walk"
			animator.flip_h = false
	return direction.normalized()

func accelerate(magnitude: Vector2) -> void:
		#add to velocity until reach max speed
	#at that point, get unit vector and scalar mult
	player.velocity += magnitude
	if player.velocity.length() > max_speed:
		player.velocity = player.velocity.normalized() * max_speed

func dodge() -> void:
	dodging = true
	can_dodge = false
	max_speed *= dodge_speed_mult
	player.velocity *= dodge_speed_mult
	$DodgeTimer.start()
	cooldown_timer.start()

func _on_cooldown_timer_timeout() -> void:
	can_dodge = true
	cooldown_timer.stop()

func _on_dodge_timer_timeout() -> void:
	#reset speed and stop dodge
	max_speed = alter_max_speed
	dodging = false
	$DodgeTimer.stop()
