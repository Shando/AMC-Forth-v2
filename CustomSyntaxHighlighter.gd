class_name CustomSyntaxHighlighter extends SyntaxHighlighter

var BUILTINS = [
		"#", "#>", "#S", ">", ">=", ">BODY", ">IN", "<", "<#", "<>", "<=", "*/", "*/MOD", "+!", ",\"", "-HEAD",
		"-TAIL", "/", "/MOD", "/STRING", "0>", "0<", "0<>", "0=", "1+", "1-", "2*",
		"2+", "2-", "2/", ":", ";", "=", "?", "ABORT", "ABS", "ADD$", "AND", "AT-XY", "AT-XYG", "BASE",
		"BOUNDS", "BUFFER:", "C,", "CHANGESPRITETEXTURE", "CLEARBACKGROUND", "CLEARSCREEN",
		"CLEARSCREENPARTIAL", "CLOSE-FILE", "COMPARE", "COUNT", "CREATESPRITEWINDOW", "D>S", "D<", "D+", "D-", "D.",
		"D.R", "D0<", "D0=", "D2*", "D2/", "D=", "DABS", "DECIMAL", "DEPTH", "DMAX", "DMIN", "DNEGATE", "DRAWARC",
		"DRAWCIRCLE", "DRAWLINE", "DRAWRECTANGLE", "DRAWSTRING", "DRAWSTRING$", "DROP", "DU<", "DUCKCLOSEDB",
		"DUCKDATECOMPARE", "DUCKDATECOMPARE$", "DUCKGETROWDATA", "DUCKGETROWDATA$", "DUCKINT2REAL", "DUCKOPENDB",
		"DUCKOPENDB$", "DUCKREAL2INT", "DUCKRUNQUERY", "DUCKRUNQUERY$", "DUCKTIMECOMPARE", "DUCKTIMECOMPARE$",
		"DUCKTIMESTAMPCOMPARE", "DUCKTIMESTAMPCOMPARE$", "EVALUATE", "FALSE", "FILE-STATUS", "GET$", "GETCUR$",
		"GETMAX$", "GETPIXEL", "GETSPRITEPOSITION", "GETTIMEMS", "GETTIMES", "HEX",
		"HIDESPRITE", "HOLD", "HOLDS", "IN", "IN-ADDR", "INC$", "INCLUDE", "INCLUDE-FILE", "INCLUDED", "INVERT",
		"LISTEN", "LISTENX", "LOAD-SNAP", "LOADBACKGROUND", "LOADSPRITE", "LSHIFT", "M*", "M*/", "M+", "M-", "M/",
		"MARKER", "MAX", "MIN", "MOD", "MOVESPRITE", "NEGATE", "NOT", "NUMBER?", "OPEN-FILE", "OR", "OUT", "OUT-ADDR",
		"P-STOP", "P-TIMER", "P-TIMERX", "PAGE", "PARSE", "PARSE-NAME", "PAUSEMUSIC", "PLAYMUSIC", "PLAYSOUND",
		"R/O", "R/W", "RAND", "READ-LINE", "REMOVESPRITE", "REPLACE$", "REPLACESPRITE", "RESUMEMUSIC", "RSHIFT", "S>D",
		"SAVE-SNAP", "SCAN", "SCROLLBACKGROUND", "SEARCH", "SET$", "SETMASTERVOLUME", "SETPIXEL", "SHOWSPRITE",
		"SIGN", "SKIP", "SM/REM", "SOURCE", "SOURCE-ID", "STOPMUSIC", "TRUE", "U>", "U<", "U.",
		"U.R", "UM*", "UM/MOD", "UNLISTEN", "UNUSED", "VAR$", "VARADD$", "VARREPLACE$", "W/O", "XOR", "\\", "*", "+",
		"-", "[", "]"
	]

var PRINT = [
	".", ".\"", ".R", ".S", "ABORT\"", "BL", "C\"", "HELP", "HELPS", "HELPWS", "S\""
]

var BASICCHAROPS = [
	"-TRAILING", "[CHAR]", "CHAR", "CR", "EMIT", "KEY", "KEY?", "TYPE", "WORD", "WORDS",
]

var ADDRESSOPS = [
	"!", ">R", "@", "@+", "?DUP", "-ROT", "2!", "2>R", "2@", "2DROP", "2DUP", "2NIP", "2OVER", "2R>", "2R@", "2ROT", "2SWAP",
	"2TUCK", "3DROP", "3DUP", "4DROP", "ALIGN", "ALIGNED", "ALLOT", "BLANK", "C!", "C+!", "C@", "C>NUMBER", "CELL+",
	"CELLS", "CHAR+", "CHARS", "CMOVE", "CMOVE>", "DUMPP", "DUMPR", "DUMPRAM", "DUP", "ERASE", "FILL", "HERE", "MOVE", "NIP", 
	"OVER", "PICK", "R>", "R@", "ROT", "SWAP", "TUCK"
]

var DEFINE = [
	"'", ",", "2CONSTANT", "2LITERAL", "2VARIABLE", "CONSTANT", "CREATE", "CS-PICK", "CS-ROLL", "EXECUTE", "IMMEDIATE",
	"LITERAL", "POSTPONE", "TO", "VALUE", "VARIABLE", "[']"
]

var CONTROL = [
	"+LOOP", "?DO", "AGAIN", "AHEAD", "BEGIN", "DO", "ELSE", "EXIT", "I", "IF", "J", "LEAVE", "LOOP", "REPEAT", "THEN",
	"UNLOOP", "UNTIL", "WHILE","WITHIN"
]

var colComment = Color("6272A4")
var colIdentifier = Color("8BE9FD")
var colControl = Color("8BE9FD")	# ITALIC
var colKeywords = Color("FF79C6")
var colDefWords = Color("8BE9FD")
var colPreWord1 = Color("8BE9FD")	# ITALIC
var colPreWord2 = Color("8BE9FD")	# BOLD + ITALIC
var colNumber = Color("BD93F9")
var colString = Color("50FA7B")
var colLocale = Color("F8F8F2")

func _get_line_syntax_highlighting(line: int) -> Dictionary:
	var color_map = {}
	var text_editor = get_text_edit()
	var regex = RegEx.new()

	var myLine = text_editor.get_line(line)
	var split = myLine.split(" ")
	var iCount = 0

	var bQuote = false
	var bComment = false

	for word in split:
		if !bQuote and !bComment:
			if word in CONTROL:
				color_map[iCount] = {"color": colControl}
			elif word in DEFINE:
				color_map[iCount] = {"color": colDefWords}
			elif word in ADDRESSOPS:
				color_map[iCount] = {"color": colPreWord1}
			elif word in BASICCHAROPS:
				color_map[iCount] = {"color": colPreWord1}
			elif word in PRINT:
				color_map[iCount] = {"color": colPreWord2}

				if word in [".\"", "ABORT\"", "C\"", "S\""]:
					color_map[iCount] = {"color": colString}
					bQuote = true
			elif word in BUILTINS:
				color_map[iCount] = {"color": colKeywords}
			elif word == "(":
				color_map[iCount] = {"color": colComment}
				bComment = true
			else:
				regex.compile("^[-+]?\\d+$")
				var result = regex.search(word)

				if result:
					color_map[iCount] = {"color": colNumber}
				else:
					color_map[iCount] = {"color": colLocale}
		else:
			if bComment:
				color_map[iCount] = {"color": colComment}

				if word.contains(")"):
					bComment = false
			elif bQuote:
				color_map[iCount] = {"color": colString}

				if word.contains('"'):
					bQuote = false

		iCount += word.length() + 1

	return color_map
