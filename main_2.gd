extends Node

@onready var ce = $PanelContainer/HBoxContainer/PanelContainer/VBoxContainer/PanelContainer/VBoxContainer/CodeEdit
@onready var cl = $PanelContainer/HBoxContainer/PanelContainer2/VBoxContainer2/CommandLine
@onready var commands = $PanelContainer/HBoxContainer/PanelContainer2/VBoxContainer2/PanelContainer2/Commands
@onready var drawing = $PanelContainer/HBoxContainer/PanelContainer2/VBoxContainer2/PanelContainer3/PanelContainer
#@onready var fore = $PanelContainer/HBoxContainer/PanelContainer2/VBoxContainer2/PanelContainer3/PanelContainer/SubViewport2/Foreground
#@onready var back = $PanelContainer/HBoxContainer/PanelContainer2/VBoxContainer2/PanelContainer3/PanelContainer/SubViewport/Background
@onready var fore = $PanelContainer/HBoxContainer/PanelContainer2/VBoxContainer2/PanelContainer3/PanelContainer/SubViewport2/FG
@onready var back = $PanelContainer/HBoxContainer/PanelContainer2/VBoxContainer2/PanelContainer3/PanelContainer/SubViewport/BG

@onready var btnLoad = $PanelContainer/HBoxContainer/PanelContainer/VBoxContainer/PanelContainer/VBoxContainer/VBoxContainer/HBoxContainer4/btnLoad
@onready var btnSave = $PanelContainer/HBoxContainer/PanelContainer/VBoxContainer/PanelContainer/VBoxContainer/VBoxContainer/HBoxContainer4/btnSave

@onready var btnSprite = $PanelContainer/HBoxContainer/PanelContainer/VBoxContainer/PanelContainer/VBoxContainer/VBoxContainer/HBoxContainer4/btnSpriteMaker
@onready var btnRAM = $PanelContainer/HBoxContainer/PanelContainer/VBoxContainer/PanelContainer/VBoxContainer/VBoxContainer/HBoxContainer4/btnRAM

@onready var bError = false

var sm = preload("res://SpriteMaker.tscn")
var rv = preload("res://RamViewer.tscn")

var forth
var mat
var sMat
var size = 16
var textureBackground
var textureForeground
var font = load("res://Fonts/vt100-regular.ttf")
var bRam = false
var bNorm = true
var bCompile = false

# Declare properties with default values
var exec : String = ""
var files : Array = []
var verbose : bool = false
var hidestack : bool = false
var datasize : int = 262144  # Config.MediumStack equivalent
var paramsize : int = 16384  # Config.SmallStack equivalent
var returnsize : int = 16384  # Config.SmallStack equivalent
var padsize : int = 1024
var sourcesize : int = 1024
var wordsize : int = 1024

@export var lastKey = -1

@onready var asp_music = $ASP_Music
@onready var asp_sfx = $ASP_Sfx

var bCLFocus = true

signal ops(value: int)

func _ready():
	#restartForth()
	reset()
	#add_child(Docs.new())
	$DlgSave.set_filters(["*.fth ; Forth format"])
	var allowed = ["*.4th", "*.f", "*.forth", "*.fs", "*.fth"]
	$DlgLoad.set_filters(allowed)
	forth.AddInputSignal(100, ops)
	var custom_highlighter = CustomSyntaxHighlighter.new()
	ce.set_syntax_highlighter(custom_highlighter)

func _input(event):
	if event is InputEventKey and event.is_pressed() and !event.is_echo() and lastKey == -1:
		var k = event.keycode

		if k == 32 or k == 39 or (k >= 44 and k <= 57) or k == 59 or k == 61 or (k >= 65 and k <= 93) or k == 96 \
			or k == 4194305 or k == 4194306 or (k >= 4194308 and k <= 4194312) or (k >= 4194317 and k <= 4194324) \
			or (k >= 4194332 and k <= 4194343) or (k >= 4194433 and k <= 4194447):
				lastKey = k

func opsEmit(inI):
	#ops.emit(inI)
	forth.InputEvent(100, inI)

func restartForth():
	forth = AMCForth.new()
	forth.Initialize(self)

func reset():
	var file = FileAccess.open("user://temp.fth", FileAccess.READ)
	var content = file.get_as_text()
	file = null
	ce.text = content
	bRam = false
	bNorm = false
	Common.bClearBackground = true
	fore.cls()
	forth = null
	restartForth()
	Common.forth = forth
	commands.text = ""
	cl.text = ""

	call_deferred("updateCommands", "Based on: AMC Forth by Eccentric-Anomalies (2025)\n\n")

	forth.TerminalOut.connect(_on_forth_output)

	#file = FileAccess.open("res://Forth.fth", FileAccess.READ)

	#if file.get_length() > 0:
	#	forth.TerminalIn("INCLUDE Forth.fth" + Common.CRLF, true)

	file = null
	Common.bStop = false
	bCLFocus = true

func _on_btn_reset_pressed() -> void:
	forth.Cleanup()
	Common.bStop = true
	get_tree().reload_current_scene()

func _process(_delta: float) -> void:
	if bRam == false && bNorm == false:
		if bCLFocus:
			cl.grab_focus()
			bCLFocus = true

		bNorm = true

func _on_forth_output(_text: String) -> void:
	call_deferred("updateCommands", _text)

func updateCommands(_text):
	commands.text += _text

	if commands.get_line_count() > 100:
		commands.remove_paragraph(0)

func nl():
	call_deferred("updateCommands", "\r\n")

func resetSprite(inS):
	var y = str(inS)
	var d = []

	if inS < 10:
		y = "00" + y
	elif inS < 100:
		y = "0" + y

	for a in range(64):
		d.append([0, 0, 0, 1])

	Common.sprites[inS] = {"S": inS, "X": 0, "Y": 0, "W": 8, "H": 8,
			"U": false, "L": "user://Sprites/Sprite" + y + ".png",
			"D": d}

func _notification(what: int) -> void:
	if what == NOTIFICATION_WM_CLOSE_REQUEST:
		forth.Cleanup()
		Common.bStop = true
		get_tree().quit()

func _on_btn_run_pressed() -> void:
	bError = false

	if bCompile:
		forth.Cleanup()
		restartForth()

	if ce.text != "":
		updateCommands("[color=#FF00FF]COMPILING / RUNNING[/color]\r\n")
		var file = FileAccess.open("user://temp.fth", FileAccess.WRITE)
		file.store_string(ce.text)
		file = null
		forth.TerminalIn("INCLUDE temp.fth" + Common.CRLF, true)

	updateCommands("[color=#FFFFFF]ok.[/color]\r\n")
	cl.text = ""
	get_viewport().gui_release_focus()
	bCLFocus = false
	bCompile = true

func _on_btn_load_pressed() -> void:
	$DlgLoad.visible = true

func _on_dlg_load_file_selected(path: String) -> void:
	if path != "":
		var file = FileAccess.open(path, FileAccess.READ)
		ce.text = file.get_as_text()
		file = null
		updateCommands("[color=#FF00FF]File " + path + " loaded[/color]\r\n")
		updateCommands("[color=#FFFFFF]ok.[/color]\r\n")

	if bCLFocus:
		cl.grab_focus()
		bCLFocus = true

func _on_btn_save_pressed() -> void:
	$DlgSave.visible = true

func _on_dlg_save_file_selected(path: String) -> void:
	if path != "":
		var file = FileAccess.open(path, FileAccess.WRITE)
		file.store_string(ce.text)
		file = FileAccess.open("user://temp.fth", FileAccess.WRITE)
		file.store_string(ce.text)
		file = null
		updateCommands("[color=#FF00FF]File " + path + " saved[/color]\r\n")
		updateCommands("[color=#FFFFFF]ok.[/color]\r\n")

	if bCLFocus:
		cl.grab_focus()
		bCLFocus = true

func _on_command_line_text_submitted(new_text: String) -> void:
	if new_text != "":
		new_text += "\r\n"
		call_deferred("updateCommands", "[color=#FF00FF]" + new_text + "[/color]") 
		forth.TerminalIn(new_text + Common.CRLF, false)

	cl.text = ""
	cl.grab_focus()
	bCLFocus = true

func get_overlap_area(rect1, rect2):
	var x1 = max(rect1.x, rect2.x)
	var y1 = max(rect1.y, rect2.y)
	var x2 = min(rect1.x + rect1.width, rect2.x + rect2.width)
	var y2 = min(rect1.y + rect1.height, rect2.y + rect2.height)

	if x1 < x2 and y1 < y2:
		return Rect2(x1, y1, x2 - x1, y2 - y1)
	else:
		return null

func get_overlapping_pixels(rect1, rect2):
	var overlap_area = get_overlap_area(rect1, rect2)

	if overlap_area:
		var overlapping_pixels = []
		
		for x in range(overlap_area.position.x, overlap_area.position.x + overlap_area.size.x):
			for y in range(overlap_area.position.y, overlap_area.position.y + overlap_area.size.y):
				overlapping_pixels.append(Vector2(x, y))

		return overlapping_pixels
	else:
		return []

func _on_btn_sprite_maker_pressed() -> void:
	bRam = true
	bNorm = false
	var instance = sm.instantiate()
	add_child(instance)

func _on_btn_ram_pressed() -> void:
	bRam = true
	bNorm = false
	var instance = rv.instantiate()
	add_child(instance)

func _on_btn_clear_op_pressed() -> void:
	commands.text = ""

func _on_btn_copy_op_pressed() -> void:
	DisplayServer.clipboard_set(commands.text)
