# Generic state machine
class_name StateMachine extends Node

# Emit when transitioning to a new state.
signal transitioned(state_name)

@export var initial_state : NodePath = NodePath("WalkingState")

@onready var state: State = get_node(initial_state)

func _ready() -> void:
	for child in get_children():
		child.state_machine = self
	state.enter()

func _process(delta: float) -> void:
	state.update(delta)

func _physics_process(delta: float) -> void:
	state.physics_update(delta)


func transition_to(target_state_name: String, msg: Dictionary = {}) -> void:
	if not has_node(target_state_name):
		return

	state.exit()
	state = get_node(target_state_name)
	state.enter(msg)
	emit_signal("transitioned", state.name)