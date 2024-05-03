#Generic State Machine, feel free to use whenever you need states.
#Changing this code will mess with player a lot
class_name StateMachine extends Node

#Can emit a signal when transitioning to a new state.

#Initial state should be placed first in state machine tree
signal transitioned(state_name)
@onready var state: State = get_child(0)

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

