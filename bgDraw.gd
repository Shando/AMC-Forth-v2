extends Node2D

var arrLoadBG = []

var path = ""
var image : Image

@onready var main = $"../../../../../../../.."
@onready var spBG = $"../../spBG"
@onready var tex = preload("res://Images/textureBackground.png")

var tex1
var scrolledImage
var bAA = false
#var sql: SQLite
var duck: GDDuckDB
var db
var qryResults
var aTmp = []
var bgOffset = Vector2(0.0, 0.0)

func _ready():
	DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)
	Common.bClearBackground = true

func _process(_delta: float) -> void:
	if !Common.bStop:
		queue_redraw()

func _draw():
	if Common.bClearBackground:
		Common.bClearBackground = false
		spBG.texture = tex
	elif Common.bLoadBackground:
		Common.bLoadBackground = false
		aTmp = arrLoadBG.duplicate(true)
		arrLoadBG = []

		for xx in aTmp:
			if xx.aa == 0:
				bAA = false
			else:
				bAA = true

			image = Image.new()
			image.load(xx.t)
			tex1 = ImageTexture.new()
			tex1.set_image(image)
			spBG.texture = tex1

func addClearBG():
	if !Common.bStop:
		Common.bClearBackground = true

func addLoadBG(texIn, x, y, aa):
	if !Common.bStop:
		arrLoadBG.push_back({"t": texIn, "x": x, "y": y, "aa": aa})
		bgOffset.x = x
		bgOffset.y = y
		Common.bLoadBackground = true

func openDb(dbName, ro):		# LEAVES DB OPEN
	db = GDDuckDB.new()
	var dbPath = ProjectSettings.globalize_path("user://Data/" + dbName + ".duckdb")
	db.set_path(dbPath)

	if ro == 0:
		db.set_read_only(true)

	var res = db.open_db()

	if !res:
		main.updateCommands("[color=#FFA500]DUCKDBERROR: Failed to open database '" + dbName + "'.[/color]\r\n")
		main.forth.Stack.Push(0)
		db.close_db()
	else:
		res = db.connect()

		if !res:
			main.updateCommands("[color=#FFA500]DUCKDBERROR: Failed to connect to database '" + dbName + "'.[/color]\r\n")
			main.forth.Stack.Push(0)
			db.close_db()
		else:
			main.forth.Stack.Push(-1)

func closeDb():
	var res = db.disconnect()

	if !res:
		main.updateCommands("[color=#FFA500]DUCKDBERROR: Failed to disconnect from database.[/color]\r\n")
		main.forth.Stack.Push(0)
	else:
		var res1 = db.close_db()

		if !res1:
			main.updateCommands("[color=#FFA500]DUCKDBERROR: Failed to close database.[/color]\r\n")
			main.forth.Stack.Push(0)
		else:
			main.forth.Stack.Push(-1)

func getRowData(row, col):	# row = int, col = string
	if qryResults != null and !qryResults.is_empty():
		if row < 0 or row > qryResults.size():
			main.updateCommands("[color=#FFA500]DUCKDBERROR: Row " +  str(row) + " is outside the bounds of the results.[/color]\r\n")
			main.forth.Stack.Push(-1)
		else:
			var res = qryResults[row]

			if res.has(col):
				var value = res[col]

				if value is int:
					main.forth.Stack.Push(value)
					main.forth.Stack.Push(0)
				elif value is bool:
					if value:
						main.forth.Stack.Push(-1)
					else:
						main.forth.Stack.Push(0)

					main.forth.Stack.Push(0)
				elif value is String:
					var strArr = value.to_ascii_buffer()

					for i in strArr.size():
						main.forth.Ram.SetByte(main.forth.DictTopP + i, strArr[i])

					main.forth.Stack.Push(main.forth.DictTopP)
					main.forth.Stack.Push(value.length())
					main.forth.Stack.Push(1)
				else:
					var strArr = str(value).to_ascii_buffer()

					for i in strArr.size():
						main.forth.Ram.SetByte(main.forth.DictTopP + i, strArr[i])

					main.forth.Stack.Push(main.forth.DictTopP)
					main.forth.Stack.Push(strArr.size())
					main.forth.Stack.Push(1)
			else:
				main.updateCommands("[color=#FFA500]DUCKDBERROR: Column '" +  col + "' is not a valid column name.[/color]\r\n")
				main.forth.Stack.Push(-1)
	else:
		main.updateCommands("[color=#FFA500]DUCKDBERROR: Error retrieving data from query results.[/color]\r\n")
		main.forth.Stack.Push(-1)

func runQuery(qry):	# REQUIRES DB TO BE OPEN
	var res = db.query(qry)

	if !res:
		var error_result = db.get_query_result()
		main.updateCommands("[color=#FFA500]DUCKDBERROR: Failed to run query: " + error_result + ".[/color]\r\n")
		main.forth.Stack.Push(0)
	else:
		qryResults = db.get_query_result()

		if !qryResults.is_empty():
			if qry.left(6) == "SELECT":
				main.forth.Stack.Push(qryResults.size())
			elif qry.left(6) == "INSERT" or qry.left(6) == "UPDATE" or qry.left(6) == "DELETE":
				main.forth.Stack.Push(qryResults[0].Count)
			else:
				main.forth.Stack.Push(0)

		main.forth.Stack.Push(-1)

func compareDates(date1, date2, comp):
	if compDates(date1, date2, comp):
		main.forth.Stack.Push(-1)
	else:
		main.forth.Stack.Push(0)

func compareTimes(time1, time2, comp):
	if compTimes(time1, time2, comp):
		main.forth.Stack.Push(-1)
	else:
		main.forth.Stack.Push(0)

func compareTimestamps(timestamp1, timestamp2, comp):
	var date1 = timestamp1.left(10)
	var date2 = timestamp2.left(10)

	if compDates(date1, date2, comp):
		var time1 = timestamp1.mid(11, 8)
		var time2 = timestamp2.mid(11, 8)

		if compTimes(time1, time2, comp):
			main.forth.Stack.Push(-1)
		else:
			main.forth.Stack.Push(0)
	else:
		main.forth.Stack.Push(0)

func compareReals(real1, real2, comp):
	if real1.is_valid_float():
		if real2.is_valid_float():
			var r1 = real1.to_float()
			var r2 = real2.to_float()

			match comp:
				">":
					if r1 > r2:
						main.forth.Stack.Push(-1)
					else:
						main.forth.Stack.Push(0)
				">=":
					if r1 >= r2:
						main.forth.Stack.Push(-1)
					else:
						main.forth.Stack.Push(0)
				"==":
					if r1 == r2:
						main.forth.Stack.Push(-1)
					else:
						main.forth.Stack.Push(0)
				"<=":
					if r1 <= r2:
						main.forth.Stack.Push(-1)
					else:
						main.forth.Stack.Push(0)
				"<":
					if r1 < r2:
						main.forth.Stack.Push(-1)
					else:
						main.forth.Stack.Push(0)
				"<>":
					if r1 != r2:
						main.forth.Stack.Push(-1)
					else:
						main.forth.Stack.Push(0)
		else:
			main.updateCommands("[color=#FFA500]DUCKDBERROR: Invalid real number: " + real2 + ".[/color]\r\n")
			main.forth.Stack.Push(0)
	else:
		main.updateCommands("[color=#FFA500]DUCKDBERROR: Invalid real number: " + real1 + ".[/color]\r\n")
		main.forth.Stack.Push(0)

func compDates(date1, date2, comp):
	var regex = RegEx.new()
	regex.compile("^\\d{4}(-\\d\\d(-\\d\\d)?)?$")
	var res = regex.search(date1)

	if res:
		var res1 = regex.search(date2)

		if res1:
			var firstDay = date1.substr(8, 2).to_int()
			var firstMonth = date1.substr(5, 2).to_int()
			var firstYear = date1.substr(0, 4).to_int()
			var secondDay = date2.substr(8, 2).to_int()
			var secondMonth = date2.substr(5, 2).to_int()
			var secondYear = date2.substr(0, 4).to_int()

			match comp:
				">":
					if firstYear > secondYear:
						return true
					elif firstYear < secondYear:
						return false
					else: # if years are equal compare months
						if firstMonth > secondMonth:
							return true
						elif firstMonth < secondMonth:
							return false
						else: # if months are equal compare days
							if firstDay > secondDay:
								return true
							elif firstDay < secondDay:
								return false
							else: # if days are equal
								return false
				">=":
					if firstYear > secondYear:
						return true
					elif firstYear < secondYear:
						return false
					else: # if years are equal compare months
						if firstMonth > secondMonth:
							return true
						elif firstMonth < secondMonth:
							return false
						else: # if months are equal compare days
							if firstDay > secondDay:
								return true
							elif firstDay < secondDay:
								return false
							else: # if days are equal
								return true
				"==":
					if firstYear > secondYear:
						return false
					elif firstYear < secondYear:
						return false
					else: # if years are equal compare months
						if firstMonth > secondMonth:
							return false
						elif firstMonth < secondMonth:
							return false
						else: # if months are equal compare days
							if firstDay > secondDay:
								return false
							elif firstDay < secondDay:
								return false
							else: # if days are equal
								return true
				"<=":
					if firstYear > secondYear:
						return false
					elif firstYear < secondYear:
						return true
					else: # if years are equal compare months
						if firstMonth > secondMonth:
							return false
						elif firstMonth < secondMonth:
							return true
						else: # if months are equal compare days
							if firstDay > secondDay:
								return false
							elif firstDay < secondDay:
								return true
							else: # if days are equal
								return true
				"<":
					if firstYear > secondYear:
						return false
					elif firstYear < secondYear:
						return true
					else: # if years are equal compare months
						if firstMonth > secondMonth:
							return false
						elif firstMonth < secondMonth:
							return true
						else: # if months are equal compare days
							if firstDay > secondDay:
								return false
							elif firstDay < secondDay:
								return true
							else: # if days are equal
								return false
				"<>":
					if firstYear > secondYear:
						return true
					elif firstYear < secondYear:
						return true
					else: # if years are equal compare months
						if firstMonth > secondMonth:
							return true
						elif firstMonth < secondMonth:
							return true
						else: # if months are equal compare days
							if firstDay > secondDay:
								return true
							elif firstDay < secondDay:
								return true
							else: # if days are equal
								return false
		else:
			main.updateCommands("[color=#FFA500]DUCKDBERROR: Invalid date format: " + date2 + ".[/color]\r\n")
			return false
	else:
		main.updateCommands("[color=#FFA500]DUCKDBERROR: Invalid date format: " + date1 + ".[/color]\r\n")
		return false

func compTimes(time1, time2, comp):
	var regex = RegEx.new()
	regex.compile("^(2[0-3]|[01][0-9]):?([0-5][0-9]):?([0-5][0-9])$")
	var res = regex.search(time1)

	if res:
		var res1 = regex.search(time2)

		if res1:
			var firstHour = time1.substr(0, 2).to_int()
			var firstMinute = time1.substr(3, 2).to_int()
			var firstSecond = time1.substr(5, 2).to_int()
			var secondHour = time2.substr(0, 2).to_int()
			var secondMinute = time2.substr(3, 2).to_int()
			var secondSecond = time2.substr(5, 2).to_int()

			match comp:
				">":
					if firstHour > secondHour:
						return true
					elif firstHour < secondHour:
						return false
					else: # if hours are equal compare minutes
						if firstMinute > secondMinute:
							return true
						elif firstMinute < secondMinute:
							return false
						else: # if minutes are equal compare seconds
							if firstSecond > secondSecond:
								return true
							elif firstSecond < secondSecond:
								return false
							else: # if seconds are equal
								return false
				">=":
					if firstHour > secondHour:
						return true
					elif firstHour < secondHour:
						return false
					else: # if hours are equal compare minutes
						if firstMinute > secondMinute:
							return true
						elif firstMinute < secondMinute:
							return false
						else: # if minutes are equal compare seconds
							if firstSecond > secondSecond:
								return true
							elif firstSecond < secondSecond:
								return false
							else: # if seconds are equal
								return true
				"==":
					if firstHour > secondHour:
						return false
					elif firstHour < secondHour:
						return false
					else: # if hours are equal compare minutes
						if firstMinute > secondMinute:
							return false
						elif firstMinute < secondMinute:
							return false
						else: # if minutes are equal compare seconds
							if firstSecond > secondSecond:
								return false
							elif firstSecond < secondSecond:
								return false
							else: # if seconds are equal
								return true
				"<=":
					if firstHour > secondHour:
						return false
					elif firstHour < secondHour:
						return true
					else: # if hours are equal compare minutes
						if firstMinute > secondMinute:
							return false
						elif firstMinute < secondMinute:
							return true
						else: # if minutes are equal compare seconds
							if firstSecond > secondSecond:
								return false
							elif firstSecond < secondSecond:
								return true
							else: # if seconds are equal
								return true
				"<":
					if firstHour > secondHour:
						return false
					elif firstHour < secondHour:
						return true
					else: # if hours are equal compare minutes
						if firstMinute > secondMinute:
							return false
						elif firstMinute < secondMinute:
							return true
						else: # if minutes are equal compare seconds
							if firstSecond > secondSecond:
								return false
							elif firstSecond < secondSecond:
								return true
							else: # if seconds are equal
								return false
				"<>":
					if firstHour > secondHour:
						return true
					elif firstHour < secondHour:
						return true
					else: # if hours are equal compare minutes
						if firstMinute > secondMinute:
							return true
						elif firstMinute < secondMinute:
							return true
						else: # if minutes are equal compare seconds
							if firstSecond > secondSecond:
								return true
							elif firstSecond < secondSecond:
								return true
							else: # if seconds are equal
								return false
		else:
			main.updateCommands("[color=#FFA500]DUCKDBERROR: Invalid time: " + time2 + ".[/color]\r\n")
			return false
	else:
		main.updateCommands("[color=#FFA500]DUCKDBERROR: Invalid time: " + time1 + ".[/color]\r\n")
		return false

func updCommands(inStr):
	main.updateCommands(inStr)
