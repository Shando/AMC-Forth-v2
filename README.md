# AMC Forth v2 by Shando

This is a re-imagining of **AMC Forth by Eccentric-Anomalies**, a Forth based programming language for Godot. 

It requires **Godot 4.5** with the mono extension (Godot_v4.5-dev4_mono_win64).


My version is meant to replicate an old computer with a few extra goodies (such as hi-res graphics, stack viewer, sprite maker etc.).

It includes many new words, including words for Graphics, Sounds, Strings, Keyboard Input and Database. I haven't followed the true Forth paradigm of creating all extra words in Forth, as some simply call Godot functions, and some are written in CSharp (soooo much easier lol). To view the words in a Forth(y) manner, in GitHub, go to **addons/amc_forth/docs** and open up the **builtins.md** file. This provides a complete list of **ALL** words available in this version of Forth. By clicking on the word's hyperlink it will take you to another page that has all the relevant information about the selected word.


NOTE: It **CANNOT** be used as an extension to the original AMC Forth as I have made quite a few changes to the original code to enable some of my words to function correctly.

NOTE: It has a built in Code Editor (complete with syntax highlighting - see CustomSyntaxHighlighter.gd).

NOTE: Any reference to **id** in the below words refer to the data stored in the **USER DATA FOLDER**.


## USER DATA FOLDER

This folder **MUST** be moved to the project's **USER DATA FOLDER** before running the application.


It contains the following:

Backgrounds - 256x background screens (more can be added, just don't go beyond 999 in total)

Data - This should contain your database(s)

Images - Some basic textures for the initial Foreground & Background

logs - Standard Godot Log Files

shader_cache - Standard Godot Shader Cache

Sounds - Sound and Music files. It currently contains the Sounds and Music used in Frogger (all from https://computerarcheology.com/Arcade/Frogger/)

Sprites - 256x Sprites and 256x Shadow Sprites (in 'Shadows' folder, if you have any need to use Shadow Sprites). As with Backgrounds, more can be added, just don't go beyond 999 in total!).

vulkan - Standard Godot Vulkan Files

There is also a file called **temp.fth**. This contains the last code run and will autoload next time you reload the application.


## GRAPHICS

These use the **800px x 480px** graphics display in the UI.


**AT-XYG** - Configure graphics display so next character displayed will appear at column 'x', row 'y' of the graphics display (origin in upper left).

**CHANGESPRITETEXTURE** - Change the texture of the sprite denoted by its spriteid ('id') to the texture 'x', where x = 000, 001 etc.

**CLEARBACKGROUND** - Clears the background layer.

**CLEARSCREEN** - Fills the foreground screen with colour ('r', 'g', 'b', 'a').

**CLEARSCREENPARTIAL** - Fills the area of the foreground screen denoted by the starting pixel ('x', 'y'), the width ('w') and the height ('h') with colour ('r', 'g', 'b', 'a').

**CREATESPRITEWINDOW** - Create a sub-window where sprites will be visible. 'x' and 'y' are the top left of the window, 'w' and 'h' are the width and the height.

**DRAWARC** - Draws an arc of radius ('ra'), width ('w') and colour ('r', 'g', 'b', 'a') around pixel ('x', 'y'), with a start angle ('sa') and end angle ('ea'), consisting of ('p') points.

**DRAWCIRCLE** - Draws a circle of radius ('ra'), width ('w1') and colour ('r1', 'g1', 'b1', 'a1') around pixel ('x', 'y'). This will also draw a border of width ('w2') and colour ('r2', 'g2', 'b2', 'a2').

**DRAWLINE** - Draws a line from pixel ('x1', 'y1') to pixel ('x2', 'y2') with colour ('r', 'g', 'b', 'a') and width ('w').

**DRAWRECTANGLE** - Draws a rectangle starting at pixel ('x', 'y'), with width ('w1'), height ('h1'), line width ('lw') and fill colour ('r1', 'g1', 'b1', 'a1'). This also draws a second rectangle outside the first with line width ('bw'), and fill colour ('r2', 'g2', 'b2', 'a2').

**DRAWSTRING** - Draws the string of characters of length ('l'), denoted by their ASCII codes, with a foreground colour ('r', 'g', 'b', 'a'), starting at the pixel location stored using **AT-XYG**. A background colour ('rb', 'gb', 'bb', 'ab') and size ('s') can also be specified.

**DRAWSTRING$** - Draws the contents of the string variable 'var$' with a foreground colour ('r', 'g', 'b', 'a'), starting at the pixel location stored using **AT-XYG**. A background colour ('rb', 'gb', 'bb', 'ab') and size ('si') can also be specified.

**GETPIXEL** - Gets the colour ('r', 'g', 'b', 'a') of the pixel 'x', 'y'.

**GETSPRITEPOSITION** - Gets the position ('x', 'y') of the top left pixel of the sprite denoted by 'id'.

**GETTIMEMS** - Get the current System Time in milliseconds (no decimal) as a double.

**GETTIMES** - Get the current System Time in seconds (no decimal) as a double.

**HIDESPRITE** - Hide the sprite denoted by its spriteid ('id').

**LOADBACKGROUND** - Load the background image denoted by its 'id' at position ('x', 'y').

**LOADSPRITE** - Load the sprite denoted by sprite id ('id1') with texture id ('id2') and its top left at pixel ('x', 'y'). 'p' should be set to 1 for the player character, 0 for any character that can interact with the player character, -1 otherwise.

**MOVESPRITE** - Move the sprite denoted by its spriteid ('id'). If type ('t') = 0 then move by the number of pixels in the 'x' and 'y' directions.

**REPLACESPRITE** - Replaces the sprite denoted by spriteid ('id1') with the sprite denoted by spriteid ('id2').

**SCROLLBACKGROUND** - Scroll the background image by setting scroll speed in the 'x' and 'y' directions.

**SETPIXEL** - Sets the pixel denoted by 'x', 'y' to the colour ('r', 'g', 'b', 'a').

**SHOWSPRITE** - Show the sprite denoted by its spriteid ('id').


## SOUNDS


**PAUSEMUSIC** - Pauses any music that is currently playing.

**PLAYMUSIC** - Plays the music file denoted by 'id', at the volume denoted by 'vol' (0 - 100).

**PLAYSOUND** - Plays the sound effect file denoted by 'id' at the volume denoted by 'vol' (0 - 100).

**RESUMEMUSIC** - Resumes music if it is currently paused.

**SETMASTERVOLUME** - Sets the master volume to the value denoted by 'vol' (0 - 100).

**STOPMUSIC** - Stops any music that is currently playing.


## STRINGS

To use string variables, they **MUST** be created using **VAR$** and can **ONLY** be the maximum length specified in **VAR$**.


**ADD$** - Adds the string denoted by 'addr' (address) and 'len' (length) to string variable 'var$'.

**GETCUR$** - Gets the current length ('u') of string variable 'var$'.

**GET$** - Gets the address ('addr') and current length ('len') of string variable 'var$'.

**GETMAX$** - Gets the maximum length of string variable 'var$'.

**INC$** - Adds the character denoted by 'char' to string variable 'var$'.

**REPLACE$** - Replaces the characters in string variable 'var$' from position start using the provided string.

**SET$** - Stores the string denoted by 'addr' (address) and 'len' (length) in string variable 'var$'.

**VARADD$** - Adds the string variable 'var2$' to the string variable 'var1$'.

**VAR$** - Creates an uninitialised string buffer called 'name' of maximum length 'maxlen'.

**VARREPLACE$** - Replaces the characters in string variable 'var1$' from position start using string variable 'var2$'. This will replace the characters in 'var1$', starting from character 6, with the contents of string variable 'var2$'.


## KEYBOARD INPUT


**KEY** - If a key has been pressed, pushes the key's value ('key') to the stack.

**KEY?** - If a key has been pressed, pushes 'TRUE' to the stack, else pushes 'FALSE'.


## DATABASE

This implementation used **DuckDB** (https://duckdb.org/). Where there are two versions of the same command (one with **$**, and one without), these generally mean that at least one required input **MUST** be a **String Variable**.


**DUCKCLOSEDB** - Closes the currently opened database.

**DUCKINT2REAL** - Converts an integer to a string based 'real' and stores it in the denoted string variable 'strvar'.

**DUCKREAL2INT** - Converts a string based 'real' to an integer and pushes it onto the stack.

**DUCKDATECOMPARE$** - Compares two Dates, both of which must be string variables and in the ISO format: YYYY-MM-DD.

**DUCKGETROWDATA** - Gets the data returned after calling DUCKRUNQUERY or DUCKRUNQUERY$.

**DUCKGETROWDATA$** - Gets the data returned after calling DUCKRUNQUERY or DUCKRUNQUERY$.

**DUCKOPENDB** - Opens the database, 'db' (a string created using S\").

**DUCKOPENDB$** - Opens the database, 'db' (a string variable).

**DUCKREALCOMPARE** - Compares two 'real' (i.e. Double, Decimal or Float) numbers, both of which must be string variables.

**DUCKREALCOMPARE$** - Compares two 'real' (i.e. Double, Decimal or Float) numbers, both of which must be string variables.

**DUCKRUNQUERY** - Runs an SQL query against the currently opened database. The 'qry' must be created using S\".

**DUCKRUNQUERY$** - Runs an SQL query against the currently opened database. The 'qry' must be a string variable.

**DUCKTIMECOMPARE** - Compares two Times, both of which must be string variables and in the ISO format: hh:mm:ss.

**DUCKTIMECOMPARE$** - Compares two Times, both of which must be string variables and in the ISO format: hh:mm:ss.

**DUCKTIMESTAMPCOMPARE** - Compares two Timestamps, both of which must be string variables and in the ISO format: YYYY-MM-DD hh:mm:ss.

**DUCKTIMESTAMPCOMPARE$** - Compares two Timestamps, both of which must be string variables and in the ISO format: YYYY-MM-DD hh:mm:ss.


## FROGGER

To show the Graphics in action, I have created an almost-working Frogger (copyright KONAMI 1981) clone (yes, there are a few things that don't work properly, but, unfortunately, I don't have time to fix them!').

The code can be found in **Frogger.forth**, which you can paste into the Code Editor and run by clicking on the **Compile/Run** button.


## LICENCE

AMC Forth v2 is under the **MIT Licence** (https://opensource.org/license/mit).


## ACKNOWLEDGEMENTS

AMC-Forth itself:\
AMC-Forth by Eccentric-Anomalies is licenced under an MIT Licence (https://opensource.org/license/mit) - https://github.com/Eccentric-Anomalies/AMC-Forth


Fonts:\
'G7StarForce' by GenShichi Yasui is Freeware - https://www.fontspace.com/g7-star-force-font-f5955\
'VT100 Regular' by Karl Stange is licenced under a Creative Commons Attribution license (http://creativecommons.org/licenses/by/3.0/) - https://fontstruct.com/fontstructions/show/232678


Graphics:\
Frogger Graphics by GaryCXJk (garycxjkl@multiverseworks.com) - LICENCE UNKNOWN - https://excamera.com/sphinx/gameduino/tutorials/frogger1.html


Godot Assets:\
'godot-duckdb' by mrjsj is licenced under an MIT Licence (https://opensource.org/license/mit) - https://github.com/mrjsj/godot-duckdb


Thanks, Shando


PS: I will **NOT** be making many more (if any) updates to this. However, I will try to answer any queries / issues as soon as I can, though I can't guarantee it will be a quick turnaround! Sorry!
