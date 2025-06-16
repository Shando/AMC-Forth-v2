extends AcceptDialog

@onready var dsp = $PanelContainer/PanelContainer2/HBoxContainer/VBoxContainer/PanelContainer3/VBoxContainer/PanelContainer/MarginContainer/RamViewer
@onready var curPage = $PanelContainer/PanelContainer2/HBoxContainer/VBoxContainer/PanelContainer2/HBoxContainer2/SpinBox
@onready var lblBytes = $PanelContainer/PanelContainer2/HBoxContainer/VBoxContainer/PanelContainer2/HBoxContainer2/Label2

@onready var rsp = $PanelContainer/PanelContainer2/HBoxContainer/VBoxContainer2/PanelContainer5/VBoxContainer/PanelContainer3/MarginContainer/RetViewer
@onready var psp = $PanelContainer/PanelContainer2/HBoxContainer/VBoxContainer2/PanelContainer4/VBoxContainer/PanelContainer2/MarginContainer/ParamViewer

@onready var topDict = $PanelContainer/PanelContainer2/HBoxContainer/VBoxContainer/PanelContainer3/VBoxContainer/Label2
@onready var dsPointer = $PanelContainer/PanelContainer2/HBoxContainer/VBoxContainer2/PanelContainer4/VBoxContainer/Label2
@onready var rsPointer = $PanelContainer/PanelContainer2/HBoxContainer/VBoxContainer2/PanelContainer5/VBoxContainer/Label2

var data = []

func _ready():
	curPage.value = 0
	loadData()
	loadParam()
	loadReturn()

func loadData():
	var ds = Common.forth.Ram._Ram
	var tText = ""
	var iT = 4096 * curPage.value
	
	for i in range(0, 4096, 2):
		var ii = i + iT
		var sTmp = ""

		var sT1 = "%008X" % ds[ii]
		var sT2 = "%008X" % ds[ii + 1]

		var sArr = []
		var j = 0

		while j * 2 < sT1.length():
			sArr.push_back(sT1.substr(j * 2, 2))
			j += 1

		for y in sArr:
			var y1 = y.hex_to_int()

			if (y1 > 31 and y1 < 127) or y1 > 160:
				sTmp += char(y1)
			else:
				sTmp += "."

		sArr = []
		j = 0

		while j * 2 < sT2.length():
			sArr.push_back(sT2.substr(j * 2, 2))
			j += 1

		for y in sArr:
			var y1 = y.hex_to_int()

			if (y1 > 31 and y1 < 127) or y1 > 160:
				sTmp += char(y1)
			else:
				sTmp += "."

		sT1 = sT1.left(4) + " " + sT1.right(4)
		sT2 = sT2.left(4) + " " + sT2.right(4)

		tText += str(int_to_hex(ii)).pad_zeros(6) + ": " + sT1 
		tText += " - " + sT2 + "  " + sTmp + "\n"

	tText = tText.strip_edges()
	dsp.text = tText

	var sT = ""			# (Bytes 0 to 4095)

	if curPage.value == 0:
		sT = "(Cells 0000 to 4095)"
	else:
		sT = "(Cells " + str(iT) + " to " + str(iT + 4096) + ")"

	lblBytes.text = sT
	sT = "%x" % Common.forth.DictTopP
	topDict.text = "Current Top of Dictionary: " + sT.to_upper() + "H"

func int_to_hex(iIn):
	var hex_str = "%008X" % iIn
	return hex_str.strip_edges()

func int_to_hex_2(iIn):
	var hex_str = "%008X" % iIn
	var formatted_hex = ""

	for i in range(0, len(hex_str), 4):
		formatted_hex += hex_str.substr(i, 4) + " "

	return formatted_hex.strip_edges()

func loadData1():
	var ds = Common.forth.Ram._Ram
	var tText = ""
	var iT = 4096 * curPage.value
	var values = []

	for i in range(8):
		values.append(0)

	for i in range(4096):
		var ii = i + iT
		tText += str(ii).pad_zeros(6) + "        "
		var input = ds[ii]

		values[7] = input >> 0 & 0xFF;
		values[6] = input >> 8 & 0xFF;
		values[5] = input >> 16 & 0xFF;
		values[4] = input >> 24 & 0xFF;
		values[3] = input >> 32 & 0xFF;
		values[2] = input >> 40 & 0xFF;
		values[1] = input >> 48 & 0xFF;
		values[0] = input >> 56 & 0xFF;

		for x in range(7, -1, -2):
			var val1 = values[x]
			var val2 = values[x - 1]

			if val1 < 16:
				tText += "0"

			tText += ("%X" % val1)

			if val2 < 16:
				tText += "0"

			tText += ("%X" % val2) + " "

	tText = tText.strip_edges()
	dsp.text = tText

	var sT = ""			# (Bytes 0 to 4095)

	if curPage.value == 0:
		sT = "(Cells 0000 to 4095)"
	else:
		sT = "(Cells " + str(iT) + " to " + str(iT + 4096) + ")"

	lblBytes.text = sT

func loadParam():
	var ps = Common.forth.Stack.DataStack
	var tText = ""

	for i in range(0, ps.size(), 2):
		var sTmp = ""

		var sT1 = "%008X" % ps[i]
		var sT2 = "%008X" % ps[i + 1]

		var sArr = []
		var j = 0

		while j * 2 < sT1.length():
			sArr.push_back(sT1.substr(j * 2, 2))
			j += 1

		for y in sArr:
			var y1 = y.hex_to_int()

			if (y1 > 31 and y1 < 127) or y1 > 160:
				sTmp += char(y1)
			else:
				sTmp += "."

		sArr = []
		j = 0

		while j * 2 < sT2.length():
			sArr.push_back(sT2.substr(j * 2, 2))
			j += 1

		for y in sArr:
			var y1 = y.hex_to_int()

			if (y1 > 31 and y1 < 127) or y1 > 160:
				sTmp += char(y1)
			else:
				sTmp += "."

		sT1 = sT1.left(4) + " " + sT1.right(4)
		sT2 = sT2.left(4) + " " + sT2.right(4)

		tText += str(int_to_hex(i)).pad_zeros(6) + ": " + sT1 
		tText += " - " + sT2 + "  " + sTmp + "\n"

	tText = tText.strip_edges()
	psp.text = tText
	tText = "%x" % Common.forth.Stack.DsP
	dsPointer.text = "Current Data Stack Pointer: " + tText.to_upper() + "H"

func loadReturn():
	var rs = Common.forth.Stack.ReturnStack
	var tText = ""

	for i in range(0, rs.size(), 2):
		var sTmp = ""

		var sT1 = "%008X" % rs[i]
		var sT2 = "%008X" % rs[i + 1]

		var sArr = []
		var j = 0

		while j * 2 < sT1.length():
			sArr.push_back(sT1.substr(j * 2, 2))
			j += 1

		for y in sArr:
			var y1 = y.hex_to_int()

			if (y1 > 31 and y1 < 127) or y1 > 160:
				sTmp += char(y1)
			else:
				sTmp += "."

		sArr = []
		j = 0

		while j * 2 < sT2.length():
			sArr.push_back(sT2.substr(j * 2, 2))
			j += 1

		for y in sArr:
			var y1 = y.hex_to_int()

			if (y1 > 31 and y1 < 127) or y1 > 160:
				sTmp += char(y1)
			else:
				sTmp += "."

		sT1 = sT1.left(4) + " " + sT1.right(4)
		sT2 = sT2.left(4) + " " + sT2.right(4)

		tText += str(int_to_hex(i)).pad_zeros(6) + ": " + sT1 
		tText += " - " + sT2 + "  " + sTmp + "\n"

	tText = tText.strip_edges()
	rsp.text = tText
	tText = "%x" % Common.forth.Stack.RsP
	rsPointer.text = "Current Return Stack Pointer: " + tText.to_upper() + "H"

func _on_confirmed() -> void:
	var main = get_tree().get_root().get_node("Control")
	main.bRam = false
	self.queue_free()

func _on_canceled() -> void:
	_on_confirmed()

func _on_spin_box_value_changed(_value: float) -> void:
	loadData()
