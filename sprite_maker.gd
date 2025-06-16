extends AcceptDialog

@onready var spnX = $VBoxContainer/PanelContainer/VBoxContainer/CenterContainer/HBoxContainer2/spnX
@onready var spnY = $VBoxContainer/PanelContainer/VBoxContainer/CenterContainer/HBoxContainer2/spnY
@onready var maingrid = $VBoxContainer/PanelContainer/VBoxContainer/HBoxContainer/PanelContainer/GridContainer
@onready var cp = $VBoxContainer/PanelContainer/VBoxContainer/HBoxContainer/PanelContainer2/VBoxContainer/ColorPicker
@onready var btnClear = $VBoxContainer/PanelContainer/VBoxContainer/CenterContainer/HBoxContainer2/btnClear
@onready var cent = $VBoxContainer/PanelContainer/VBoxContainer/HBoxContainer/PanelContainer/CenterContainer

const CELLSCENEPATH = "res://Cell.tscn"
var col = Color(1, 1, 1, 1)
var curCell = 0
var bSelected = false
var sT = ""
var hsep
var vsep
var inp = 0

func _ready():
	cent.visible = true
	maingrid.visible = false
	spnX.editable = false
	spnY.editable = false
	btnClear.disabled = true

	hsep = HSeparator.new();
	hsep.add_theme_constant_override("thickness", 5)
	hsep.add_theme_constant_override("separation", 5)
	hsep.custom_minimum_size.y = 5

	vsep = VSeparator.new();
	vsep.add_theme_constant_override("thickness", 5)
	vsep.add_theme_constant_override("separation", 5)
	vsep.custom_minimum_size.x = 5

func gui_input_L(x):
	$".".title = "Sprite Maker - " + sT + "*"
	col = cp.color
	curCell = x
	updateButton()

func gui_input_R(x):
	$".".title = "Sprite Maker - " + sT + "*"
	col = Color(0.0, 0.0, 0.0, 1.0)
	curCell = x
	updateButton()

func addChildren():
	for y in range(spnY.value):
		for x in range(spnX.value):
			var cell = load(CELLSCENEPATH).instantiate()
			maingrid.add_child(cell)
			cell.connect("left_click", Callable(self, "gui_input_L").bind(y * spnX.value + x))
			cell.connect("right_click", Callable(self, "gui_input_R").bind(y * spnX.value + x))

	var w = Common.sprites[Common.selSprite].W	# old width
	var h = Common.sprites[Common.selSprite].H	# old height

	for y in range(spnY.value):
		for x in range(spnX.value):
			var d = Color(0.0, 0.0, 0.0, 1.0)

			if x < w and y < h:
				d.r = Common.sprites[Common.selSprite].D[y * w + x][0]
				d.g = Common.sprites[Common.selSprite].D[y * w + x][1]
				d.b = Common.sprites[Common.selSprite].D[y * w + x][2]
				d.a = Common.sprites[Common.selSprite].D[y * w + x][3]
			else:
				d.r = 0.0
				d.g = 0.0
				d.b = 0.0
				d.a = 1.0

			col = d
			curCell = y * spnX.value + x
			updateButton()

	UpdateSpriteData()
	spnX.editable = true
	spnY.editable = true
	btnClear.disabled = false

func UpdateSpriteData():
	var allBtns = maingrid.get_children()
	Common.sprites[Common.selSprite].W = spnX.value
	Common.sprites[Common.selSprite].H = spnY.value
	Common.sprites[Common.selSprite].D = []
	var dD = []

	for x in range(spnX.value * spnY.value):
		col = allBtns[x].getColour()
		dD.push_back([col.r, col.g, col.b, col.a])

	Common.sprites[Common.selSprite].D = dD

func removeChildren():
	spnX.editable = false
	spnY.editable = false
	var children = maingrid.get_children()

	for child in children:
		child.free()

func _on_spn_x_value_changed(value: float) -> void:
	removeChildren()
	maingrid.columns = value
	addChildren()

func _on_spn_y_value_changed(_value: float) -> void:
	removeChildren()
	addChildren()

func updateButton():
	var allBtns = maingrid.get_children()
	allBtns[curCell].updateColour(col)

func _on_confirmed() -> void:
	if bSelected:
		Common.sprites[Common.selSprite].W = spnX.value
		Common.sprites[Common.selSprite].H = spnY.value

		UpdateSpriteData()

		var img = Image.create(spnX.value, spnY.value, false, Image.FORMAT_RGBA8)

		for y in range(spnY.value):
			for x in range(spnX.value):
				col = Color(Common.sprites[Common.selSprite].D[y * spnX.value + x][0], 
							Common.sprites[Common.selSprite].D[y * spnX.value + x][1],
							Common.sprites[Common.selSprite].D[y * spnX.value + x][2],
							Common.sprites[Common.selSprite].D[y * spnX.value + x][3])
				img.set_pixel(x, y, col)

		var err = img.save_png(Common.sprites[Common.selSprite].L)

		if err == 0:
			img.save_png(Common.sprites[Common.selSprite].L1)

		if err == 0:
			$".".title = "Sprite Maker - " + sT + " - SAVED"

func _on_btn_load_pressed() -> void:
	$DlgLoad.show()

func _on_dlg_load_file_selected(path: String) -> void:
	bSelected = true
	cent.visible = false
	maingrid.visible = true
	sT = path.substr(15, 9)	#	user://Sprites/Sprite000.png
	Common.selSprite = int(sT.right(3))
	$".".title = "Sprite Maker - " + sT

	var children = maingrid.get_children()

	for child in children:
		child.free()

	var w = Common.sprites[Common.selSprite].W
	var h = Common.sprites[Common.selSprite].H

	spnX.set_value_no_signal(w)
	spnY.set_value_no_signal(h) 

	maingrid.columns = spnX.value
	addChildren()

func _on_btn_clear_pressed() -> void:
	var allBtns = maingrid.get_children()
	col = Color.BLACK

	for x in allBtns.size():
		curCell = x
		updateButton()

func _on_canceled() -> void:
	var main = get_tree().get_root().get_node("Control")
	main.bRam = false
	self.queue_free()
