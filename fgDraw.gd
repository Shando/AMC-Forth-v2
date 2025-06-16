extends Node2D

@onready var stringFont = preload("res://Fonts/vt100-regular.ttf")
@onready var svc = $"../.."
@onready var main = $"../../../../../../../.."
@onready var spriteWindow = $"../../../SpriteWindow"
@onready var spriteDisplay = $"../../../SpriteWindow/sprites"
@onready var spSP = $"../../../spSP"

var rid
var dispSprites = []
var sprite
var shadow
var texture1
var playerID

var arrLine = []
var arrSetPix = []
var arrCLS = []
var arrCLSP = []
var arrCirc = []
var arrArc = []
var arrRect = []
var arrStr = []
var arrLoadSp = []
var arrMoveSp = []
var arrRemSp = []
var arrReplSp = []
var textPlaced = []
var aTmp = []

var bSpriteWindow = false

func _ready():
	DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)
	rid = get_canvas_item()

func _process(_delta: float) -> void:
	if !Common.bStop:
		queue_redraw()

func _draw():
	if Common.bLine:
		var aT = arrLine.duplicate(true)
		arrLine = []

		for xx in aT:
			var bAA = false

			if xx.aa == 1:
				bAA = true

			draw_line(xx.ls, xx.le, xx.c, xx.lw, bAA)

		Common.bLine = false
	elif Common.bSetPixel:
		var aT = arrSetPix.duplicate(true)
		arrSetPix = []

		for xx in aT:
			draw_rect(Rect2(xx.pts[0], Vector2(1.0, 1.0)), xx.c[0], true, 1.0, false)

		Common.bSetPixel = false
	elif Common.bClearScreen:
		var aT = arrCLS.duplicate(true)
		arrCLS = []
		var clsRect = Rect2(0.0, 0.0, 800.0, 480.0)

		for xx in aT:
			var bAA = false

			if xx.aa == 1:
				bAA = true

			draw_rect(clsRect, xx.c, true, -1, bAA)

		Common.bClearScreen = false
	elif Common.bClearScreenPartial:
		var aT = arrCLSP.duplicate(true)
		arrCLSP = []

		for xx in aT:
			var bAA = false

			if xx.aa == 1:
				bAA = true

			draw_rect(xx.r, xx.c, true, -1, bAA)

		Common.bClearScreenPartial = false
	elif Common.bCircle:
		var aT = arrCirc.duplicate(true)
		arrCirc = []

		for xx in aT:
			var bAA = false

			if xx.aa == 1:
				bAA = true

			if xx.bw > 0:
				draw_circle(xx.cen, xx.r + xx.bw, xx.bc, false, xx.bw, bAA)

			if xx.w > 0:
				draw_circle(xx.cen, xx.r, xx.c, false, xx.w, bAA)
			else:
				draw_circle(xx.cen, xx.r, xx.c, true, xx.w, bAA)

		Common.bCircle = false
	elif Common.bArc:
		var aT = arrArc.duplicate(true)
		arrArc = []

		for xx in aT:
			var bAA = false

			if xx.aa == 1:
				bAA = true

			draw_arc(xx.cen, xx.r, xx.sa, xx.ea, xx.pts, xx.c, xx.w, bAA)

		Common.bArc = false
	elif Common.bRectangle:
		var aT = arrRect.duplicate(true)
		arrRect = []

		for xx in aT:
			var bAA = false

			if xx.aa == 1:
				bAA = true

			if xx.bw > 0:
				draw_rect(xx.r2, xx.bc, true, xx.lw + xx.bw, bAA)

			if xx.lw > 0:
				draw_rect(xx.r1, xx.c, false, xx.lw, bAA)
			else:
				draw_rect(xx.r1, xx.c, true, xx.lw, bAA)

		Common.bRectangle = false
	elif Common.bString:
		aTmp = arrStr.duplicate(true)
		arrStr = []

		for xx in aTmp:
			draw_texture(xx.T, xx.P)

			if xx.S:
				scrollScreen()

		Common.bString = false

func addLine(ls, le, c, lw, aa):
	if !Common.bStop:
		arrLine.push_back({"ls": ls, "le": le, "c": c, "lw": lw, "aa": aa})
		Common.bLine = true

func addSetPixel(p, u, c):
	if !Common.bStop:
		arrSetPix.push_back({"pts": p, "uvs": u, "c": c})
		Common.bSetPixel = true

func addCLS(c, aa):
	if !Common.bStop:
		arrCLS.push_back({"c": c, "aa": aa})
		Common.bClearScreen = true

func addCLSP(r, c, aa):
	if !Common.bStop:
		arrCLSP.push_back({"r": r, "c": c, "aa": aa})
		Common.bClearScreenPartial = true

func addCirc(cen, r, w, c, bw, c2, aa):
	if !Common.bStop:
		arrCirc.push_back({"cen": cen, "r": r, "w": w, "c": c, "bw": bw, "bc": c2, "aa": aa})
		Common.bCircle = true

func addArc(cen, r, sa, ea, pts, c, w, aa):
	if !Common.bStop:
		arrArc.push_back({"cen": cen, "r": r, "sa": sa, "ea": ea, "pts": pts, "c": c, "w": w, "aa": aa})
		Common.bArc = true

func addRect(r1, lw, c, r2, bw, bc, aa):
	if !Common.bStop:
		arrRect.push_back({"r1": r1, "lw": lw, "c": c, "r2": r2, "bw": bw, "bc": bc, "aa": aa})
		Common.bRectangle = true

func addString(bc, p, fc, t, si):
	if !Common.bStop:
		drawString(bc, p, t, fc, si)

func createSpriteWindow(x, y, w, h):
	bSpriteWindow = true
	spriteWindow.set_size(Vector2i(w, h))
	spSP.offset = Vector2i(x, y)
	spSP.visible = true

func addLoadSprite(id1, id2, x, y, iPlayer, colSize):
	if !Common.bStop:
		var a2d = Area2D.new()

		if iPlayer == 1:
			a2d.connect("area_entered", Callable(self, "_area_entered"))

		var sp = Sprite2D.new()
		sp.texture_filter = CanvasItem.TEXTURE_FILTER_NEAREST
		updateSpriteTexture(id1, id2, sp)
		var sz = sp.texture.get_size()
		var cSize = sz

		if colSize > 0:
			cSize *= colSize
		elif colSize < 0:
			cSize /= (colSize * -1)

		var cs = CollisionShape2D.new()
		cs.shape = RectangleShape2D.new()
		cs.shape.set_size(cSize)
		var sptw = sz.x / 2
		var spth = sz.y / 2
		sp.offset = Vector2(sptw, spth)
		a2d.add_child(sp)
		a2d.add_child(cs)
		a2d.position = Vector2(x, y)
		a2d.add_to_group("Sprites")

		if bSpriteWindow:
			spriteDisplay.add_child(a2d)
		else:
			if spSP.is_visible_in_tree():
				spSP.visible = false

			svc.add_child(a2d)

		addSpriteData(id1, sp.get_path(), a2d.get_path(), iPlayer, a2d.get_instance_id(), colSize)

		if iPlayer == 1:
			playerID = a2d

func _area_entered(entered_area):
	if !Common.bStop:
		if entered_area != playerID:
			var gdDict = getSpriteDataIID(entered_area.get_instance_id())

			if gdDict.p == 0:
				main.opsEmit(gdDict.id)

func updateSpriteTexture(id, t, n = null):
	if !Common.bStop:
		var spritePath = "user://Sprites/Sprite" + "%03d" % t + ".png"
		sprite = Image.load_from_file(spritePath)
		var tex = ImageTexture.create_from_image(sprite)
		var node = n

		if node == null:
			var gdDict = getSpriteData(id)
			
			if gdDict["id"] > -1:
				node = get_node(gdDict["sp"])

		if node != null:
			node.texture = tex
		else:
			main.updateCommands("[color=#FFA500]ERROR: Failed to update Sprite " + str(id) + "'s Texture.[/color]\r\n")

func addMoveSprite(id, x, y, t):
	if !Common.bStop:
		var gdDict = getSpriteData(id)
		var node = get_node(gdDict["a"])

		if gdDict["id"] == -1:
			main.updateCommands("[color=#FFA500]ERROR: Failed to move Sprite" + str(id) + ".[/color]\r\n")
		else:
			if t == 0:
				node.position += Vector2(x, y)
			else:
				node.position = Vector2(x, y)

func addRemoveSprite(id):
	if !Common.bStop:
		var node
		var iC = -1

		for x in dispSprites:
			iC += 1

			if x.id == id:
				node = get_node(x.a)
				break

		if iC == -1:
			main.updateCommands("[color=#FFA500]ERROR: Failed to remove Sprite " + str(id) + ".[/color]\r\n")
		else:
			dispSprites.remove_at(iC)
			node.queue_free()

func addReplaceSprite(id1, id2, tex, p):
	if !Common.bStop:
		var gdDict = getSpriteData(id1)
		addRemoveSprite(id1)
		addLoadSprite(id2, tex, gdDict.a.position.x, gdDict.a.position.y, p, gdDict.cs)

func cls():
	if !Common.bStop:
		var node

		for x in dispSprites:
			node = get_node(x.a)
			node.queue_free()

		dispSprites = []
		arrCLS.push_back({"c": Color(0.0, 0.0, 0.0, 1.0), "aa": 0})

func drawString(bc, p, t1, fc, si):
	if !Common.bStop:
		var path = "res://Images/VT100Font/";
		var bFirstS = true
		var bScroll = false
		arrStr = []

		for x in range(t1.size()):
			var id = str(t1[x])
			var path1 = path + id + ".png"
			var img = ResourceLoader.load(path1, "", ResourceLoader.CACHE_MODE_IGNORE_DEEP) as Image

			for row in range(10):
				for col in range(10):
					if img.get_pixel(col, row).is_equal_approx(Color.BLACK):
						img.set_pixel(col, row, fc)
					else:
						img.set_pixel(col, row, bc)

			var tex1 = ImageTexture.create_from_image(img)
			tex1.set_size_override(Vector2i(20 * si, 20 * si))
			var tex : Texture2D = tex1
			appendString(p)

			if p.x >= 20:
				bFirstS = false

			if not bFirstS:
				p.x += 20 * si

				if p.x >= 800:
					p.x = 0
					p.y += 20 * si

				if p.y >= 460:
					p.y = 460
					bScroll = true
				else:
					bScroll = false
			else:
				bFirstS = false

			arrStr.push_back({"T": tex, "P": p, "S": bScroll})

		Common.bString = true

func appendString(p):
	# TODO: 
	if !Common.bStop:
		var tT = { "X": p.x, "Y": p.y}
		textPlaced.push_back(tT)

func removeString(p):
	# TODO:
	if !Common.bStop:
		var tT = { "X": -1, "Y": -1, "S": 0}

		for i in range(textPlaced.size()):
			if textPlaced[i].X == p.x and textPlaced[i].Y == p.y:
				tT.X = textPlaced[i].X
				tT.Y = textPlaced[i].Y
				tT.S = textPlaced[i].S
				textPlaced.remove_at(i)

		return tT

func scrollScreen():
	if !Common.bStop:
		var image = get_viewport().get_texture().get_image()
		var scrollX = 0
		var scrollY = 10
		scrollX %= image.get_width()
		scrollY %= image.get_height()
		var scrolledImage = Image.create_empty(image.get_width(), image.get_height(), false, image.get_format())

		for y in range(image.get_height()):
			for x in range(image.get_width()):
				var srcX = (x + scrollX) % image.get_width()
				var srcY = (y + scrollY) % image.get_height()
				var colour = image.get_pixel(srcX, srcY)
				scrolledImage.set_pixel(x, y, colour)

		texture1 = ImageTexture.create_from_image(scrolledImage)
		draw_texture(texture1, Vector2(0, 0))

func addSpriteData(inID, inSP, inA, inP, inIID, cs):
	if !Common.bStop:
		for x in dispSprites:
			if x.id == inID:
				return

		dispSprites.push_back({"id": inID, "sp": inSP, "a": inA, "p": inP, "iid": inIID, "cs": cs})

func getSpriteData(inID):
	if !Common.bStop:
		for x in dispSprites:
			if x.id == inID:
				return x

		return {"id": -1, "sp": -1, "a": -1, "p": -1, "iid": -1, "cs": 2}

func getSpriteDataIID(inID):
	if !Common.bStop:
		for x in dispSprites:
			if x.iid == inID:
				return x

		return {"id": -1, "sp": -1, "a": -1, "p": -1, "iid": -1, "cs": 2}

func showSprite(inID):
	if !Common.bStop:
		for x in dispSprites:
			if x.id == inID:
				var node = get_node(x.a)
				node.show()
				return

func hideSprite(inID):
	if !Common.bStop:
		for x in dispSprites:
			if x.id == inID:
				var node = get_node(x.a)
				node.hide()
				return
