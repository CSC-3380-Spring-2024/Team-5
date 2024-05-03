class_name Attack extends Area2D

@export var direction: Vector2
@export var speed: float = 400
@export var Scale: Vector2 = Vector2(3,3)
@export var damage_amount: float = 10

func _process(delta):
	translate(direction.normalized() * speed * delta)

func _on_body_entered(body):
	if (body.has_method("damage")):
		body.damage(damage_amount)
		queue_free();

func _on_visible_on_screen_notifier_2d_screen_exited():
	queue_free()
