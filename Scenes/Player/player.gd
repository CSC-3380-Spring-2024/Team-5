extends CharacterBody2D

@export var max_health: float = 100
var current_health= max_health

@export var max_speed: int = 350
@export var acceleration: int = 3000

var dodging: bool = false
var can_dodge: bool = true
@export var dodge_time: float = 0.3
@export var dodge_cooldown: float = 0.5
#dodge_cooldown not changing as intended, will fix
@export var dodge_speed_mult: float = 2
var alter_max_speed: int = max_speed

var invunerable: bool = false

func ready():
	$HealthBar.max_value = max_health
	$HealthBar.value = current_health
	$DodgeTimer.wait_time = dodge_time
	$CooldownTimer.wait_time = dodge_cooldown
	

func _physics_process(delta):
	movement_handler(delta)
	if (!can_dodge):
		$CooldownBar.value = $CooldownTimer.time_left
	

func movement_handler(delta):
	var direction: Vector2 = Vector2.ZERO
	
	if(!dodging):
		direction = get_input_direction()
		if direction == Vector2.ZERO:
			apply_friction(acceleration * delta)
		else:
			accelerate(direction * acceleration * delta)
		move_and_slide()
		if Input.is_action_just_pressed("dodge")&&can_dodge:
			dodge()
			take_damage(10)
	
	if(dodging):
		#accelerate fast & direction locked while dodge
		accelerate(direction*acceleration*acceleration*delta)
		move_and_slide()

func get_input_direction():
	var direction: Vector2
	direction.x = Input.get_action_strength("moveRight") - Input.get_action_strength("moveLeft")
	direction.y = Input.get_action_strength("moveDown") - Input.get_action_strength("moveUp")
	return direction.normalized()

func apply_friction(magnitude):
	if velocity.length() > magnitude:
		velocity -= velocity.normalized() * magnitude
	else:
		velocity = Vector2.ZERO

func accelerate(magnitude):
	velocity += magnitude
	if velocity.length() > max_speed:
		velocity = velocity.normalized() * max_speed

func dodge():
	dodging = true
	can_dodge = false
	max_speed *= dodge_speed_mult
	$DodgeTimer.wait_time = dodge_time
	$DodgeTimer.start()
	$CooldownTimer.start()

func _on_timer_timeout():
	#reset speed and stop dodge
	max_speed = alter_max_speed
	dodging = false
	$DodgeTimer.stop()

func _on_cooldown_timer_timeout():
	can_dodge = true
	$CooldownTimer.stop()
	$CooldownBar.value=$CooldownBar.max_value

func take_damage(amount):
	current_health -= amount
	if current_health < 0:
		print("dead, health reset")
		current_health = max_health
	$HealthBar.value = current_health
	#need a timer for invunerability

func _on_area_2d_area_entered(area):
	if area.is_in_group("seashell"):
		print("collected")
