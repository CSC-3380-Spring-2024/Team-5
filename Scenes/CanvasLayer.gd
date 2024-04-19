extends CanvasLayer

@onready var inventory = $InventoryGui


## when game runs, inventory is closed
func _ready(): 
	inventory.close()

## "i" pressed toggles inventory
func _input(event):
	if event.is_action_pressed("toggle_inventory"):
		if inventory.isOpen:
			inventory.close()
		else:
			inventory.open()
