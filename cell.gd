# Cell scene script
extends TextureButton

signal left_click() # note that you can't use "gui_input" or you get a redefined error
signal right_click()

func _ready():
	updateColour(Color.BLACK)

func updateColour(col):
	material.set_shader_parameter("color", col)

func getColour():
	return material.get_shader_parameter("color")

func _gui_input(event: InputEvent) -> void:
	if event is InputEventMouseButton:
		if event.pressed and event.button_index == MOUSE_BUTTON_LEFT:
			left_click.emit()

		if event.pressed and event.button_index == MOUSE_BUTTON_RIGHT:
			right_click.emit()
