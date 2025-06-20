extends Node

const SCREEN_WIDTH = 80
const SCREEN_HEIGHT = 24

const CTRLA = "\u0001"
const BSP = "\u0008"
const CR_CHAR = "\u000D"
const LF = "\u000A"
const CRLF = "\r\n"
const ESC = "\u001B"
const DEL_LEFT = "\u007F"
const BL_CHAR = " "
const DEL = "\u001B[3~"
const UP = "\u001B[A"
const DOWN = "\u001B[B"
const RIGHT = "\u001B[C"
const LEFT = "\u001B[D"
const CLRLINE = "\u001B[2K"
const CLRSCR = "\u001B[2J"
const PUSHXY = "\u001B7"
const POPXY = "\u001B8"
const MODESOFF = "\u001B[m"
const BOLD = "\u001B[1m"
const LOWINT = "\u001B[2m"
const UNDERLINE = "\u001B[4m"
const BLINK = "\u001B[5m"
const REVERSE = "\u001B[7m"
const INVISIBLE = "\u001B[8m"
const ATXY_START = "\u001B["

var sprites = []
var selSprite = 0
var forth
var blank_line: PackedInt32Array
var screen_width: int
var screen_height: int

var bClearBackground = false
var bLoadBackground = false
var bScrollBackground = false

var bLine = false
var bSetPixel = false
var bClearScreen = false
var bClearScreenPartial = false
var bCircle = false
var bArc = false
var bRectangle = false
var bString = false

var bStop = false

func _ready() -> void:
	for x in range(256):
		var dD = []
		var y = str(x)

		if x < 10:
			y = "00" + y
		elif x < 100:
			y = "0" + y

		var path = "user://Sprites/Sprite" + y + ".png"
		var path1 = "user://Sprites/Shadows/Sprite" + y + ".png"
		var img = Image.load_from_file(path)

		var w = img.get_width()
		var h = img.get_height()

		for h1 in range(h):
			for w1 in range(w):
				var c = img.get_pixel(w1, h1)
				dD.push_back([c.r, c.g, c.b, c.a])

		var s = {"S": x, "X": 0, "Y": 0, "W": w, "H": h,
			"U": false, "L": path, "L1": path1, "D": dD}

		sprites.push_back(s)
