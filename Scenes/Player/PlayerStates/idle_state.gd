class_name IdleState extends State

var player: Node
var animator: Node

func _ready() -> void:
	player = get_parent().get_parent()
	animator = player.get_node("AnimatedSprite2D")

func physics_update(_delta: float) -> void:
	animate()
	if (Input.get_action_strength("moveRight")||Input.get_action_strength("moveLeft")||
	Input.get_action_strength("moveDown")||Input.get_action_strength("moveUp")): state_machine.transition_to("WalkingState")

func animate() -> void:
	var cursor_position = animator.get_global_mouse_position()
	var player_position = animator.global_position
	var angle_to_cursor = (cursor_position - player_position).angle()
	
	if(0<angle_to_cursor&&angle_to_cursor<=1.05): 
		animator.animation="fr_idle"
		animator.flip_h=false
	if(1.05<angle_to_cursor&&angle_to_cursor<=2.10): 
		animator.animation="f_idle"
		animator.flip_h=false
	if(2.10<angle_to_cursor&&angle_to_cursor<=3.1415): 
		animator.animation="fr_idle"
		animator.flip_h=true
	if(0>angle_to_cursor&&angle_to_cursor>=-1.05): 
		animator.animation="br_idle"
		animator.flip_h=false
	if(-1.05>angle_to_cursor&&angle_to_cursor>=-2.10): 
		animator.animation="b_idle"
		animator.flip_h=false
	if(-2.10>angle_to_cursor&&angle_to_cursor>=-3.1415): 
		animator.animation="br_idle"
		animator.flip_h=true
	
