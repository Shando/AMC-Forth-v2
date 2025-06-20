0 CONSTANT LHS       ( LHS OF SCREEN ) 
256 CONSTANT RHS     ( RHS OF SCREEN ) 
246 CONSTANT V1Y     ( TOP OF VEHICLE LANE 1 ) 
228 CONSTANT V2Y     ( TOP OF VEHICLE LANE 2 ) 
210 CONSTANT V3Y     ( TOP OF VEHICLE LANE 3 ) 
192 CONSTANT V4Y     ( TOP OF VEHICLE LANE 4 ) 
174 CONSTANT V5Y     ( TOP OF VEHICLE LANE 5 ) 
156 CONSTANT SY      ( Y POS OF SNAKE )
138 CONSTANT R1Y     ( TOP OF RIVER LANE 1 ) 
120 CONSTANT R2Y     ( TOP OF RIVER LANE 2 ) 
102 CONSTANT R3Y     ( TOP OF RIVER LANE 3 ) 
84 CONSTANT R4Y      ( TOP OF RIVER LANE 4 ) 
68 CONSTANT R5Y      ( TOP OF RIVER LANE 5 ) 
48 CONSTANT HY       ( TOP OF HOME - FROG MUST MATCH THIS +- 2 TO BE 'HOME' ) 
8 CONSTANT H1X       ( LEFT OF HOME 1 - FROG MUST MATCH THIS +- 2 TO BE 'HOME' ) 
64 CONSTANT H2X      ( LEFT OF HOME 2 - FROG MUST MATCH THIS +- 2 TO BE 'HOME' ) 
120 CONSTANT H3X     ( LEFT OF HOME 3 - FROG MUST MATCH THIS +- 2 TO BE 'HOME' ) 
176 CONSTANT H4X     ( LEFT OF HOME 4 - FROG MUST MATCH THIS +- 2 TO BE 'HOME' ) 
232 CONSTANT H5X     ( LEFT OF HOME 5 - FROG MUST MATCH THIS +- 2 TO BE 'HOME' ) 
488 CONSTANT LBEND   ( LAST 8x8 FOR LIFEBAR ) 
372 CONSTANT LBTOP   ( TOP OF LIFEBAR ) 
176 CONSTANT SCORE1X ( SCORE 1 X ) 
184 CONSTANT SCORE2X ( SCORE 2 X ) 
192 CONSTANT SCORE3X ( SCORE 3 X ) 
200 CONSTANT SCORE4X ( SCORE 4 X ) 
208 CONSTANT SCORE5X ( SCORE 5 X ) 
14 CONSTANT SCOREY   ( SCORE Y ) 
128 CONSTANT STARTX  ( STARTING POINT OF FROG X ) 
264 CONSTANT STARTY  ( STARTING POINT OF FROG Y ) 
284 CONSTANT LIVESY  ( LIVES Y ) 
4 CONSTANT LIVES1X   ( LIFE 1 X ) 
16 CONSTANT LIVES2X  ( LIFE 2 X ) 
28 CONSTANT LIVES3X  ( LIFE 3 X ) 
30 CONSTANT LIVES4X  ( LIFE 4 X ) 
42 CONSTANT LIVES5X  ( LIFE 5 X ) 
VARIABLE SCORE       ( SCORE ) 
VARIABLE LIVES       ( # LIVES ) 
VARIABLE TEMP        ( TEMP VARIABLE ) 
VARIABLE TEMPS       ( TEMPS VARIABLE ) 
VARIABLE RUNGAME     ( RUNGAME 1 = Yes, 0 = No ) 
VARIABLE TIMER       ( GAME TIMER ) 
VARIABLE FX          ( X POS OF FROG ) 
VARIABLE FY          ( Y POS OF FROG ) 
VARIABLE SS          ( CUR SPRITE OF SNAKE )
VARIABLE HOME1       ( 0 = EMPTY, 1 = FLY, 2 = CROC, 3 = FROG ) 
VARIABLE HOME2       ( 0 = EMPTY, 1 = FLY, 2 = CROC, 3 = FROG ) 
VARIABLE HOME3       ( 0 = EMPTY, 1 = FLY, 2 = CROC, 3 = FROG ) 
VARIABLE HOME4       ( 0 = EMPTY, 1 = FLY, 2 = CROC, 3 = FROG ) 
VARIABLE HOME5       ( 0 = EMPTY, 1 = FLY, 2 = CROC, 3 = FROG ) 
VARIABLE LASTKEY     ( LAST KEY PRESSED ) 
VARIABLE RCY1X       ( YELLOW RACING CAR 1 X ) 
VARIABLE RCY2X       ( YELLOW RACING CAR 2 X ) 
VARIABLE D1X         ( DIGGER 1 X ) 
VARIABLE D2X         ( DIGGER 2 X ) 
VARIABLE D3X         ( DIGGER 3 X ) 
VARIABLE C1X         ( CAR 1 X ) 
VARIABLE C2X         ( CAR 2 X ) 
VARIABLE C3X         ( CAR 3 X ) 
VARIABLE C4X         ( CAR 4 X ) 
VARIABLE C5X         ( CAR 5 X ) 
VARIABLE RCW1X       ( WHITE RACING CAR 1 X ) 
VARIABLE RCW2X       ( WHITE RACING CAR 2 X ) 
VARIABLE RCW3X       ( WHITE RACING CAR 3 X ) 
VARIABLE RCW4X       ( WHITE RACING CAR 4 X ) 
VARIABLE T1X         ( TRUCK 1 X ) 
VARIABLE T2X         ( TRUCK 2 X ) 
VARIABLE T3X         ( TRUCK 3 X ) 
VARIABLE SNAKEX      ( SNAKE X ) 
VARIABLE TURTLE11X   ( TURTLE 1 1 X ) 
VARIABLE TURTLE21X   ( TURTLE 2 1 X ) 
VARIABLE TURTLE31X   ( TURTLE 3 1 X ) 
VARIABLE TURTLE41X   ( TURTLE 4 1 X ) 
VARIABLE TURTLE51X   ( TURTLE 5 1 X ) 
VARIABLE TURTLE61X   ( TURTLE 6 1 X ) 
VARIABLE TURTLE71X   ( TURTLE 7 1 X ) 
VARIABLE TURTLE81X   ( TURTLE 8 1 X ) 
VARIABLE LOGS12X     ( LOG SMALL 1 2 X ) 
VARIABLE LOGS22X     ( LOG SMALL 2 2 X ) 
VARIABLE LOGS32X     ( LOG SMALL 3 2 X ) 
VARIABLE LOGL13X     ( LOG LARGE 1 3 X ) 
VARIABLE LOGM13X     ( LOG MEDIUM 1 3 X ) 
VARIABLE TURTLE14X   ( TURTLE 1 4 X ) 
VARIABLE TURTLE24X   ( TURTLE 2 4 X ) 
VARIABLE TURTLE34X   ( TURTLE 3 4 X ) 
VARIABLE TURTLE44X   ( TURTLE 4 4 X ) 
VARIABLE TURTLE54X   ( TURTLE 5 4 X ) 
VARIABLE TURTLE64X   ( TURTLE 6 4 X ) 
VARIABLE TURTLE74X   ( TURTLE 7 4 X ) 
VARIABLE TURTLE84X   ( TURTLE 8 4 X ) 
VARIABLE LOGS15X     ( LOG SMALL 1 5 X ) 
VARIABLE LOGM15X     ( LOG MEDIUM 1 5 X ) 
VARIABLE CROC15X     ( CROC 1 5 X ) 
VARIABLE CROCTYPE    ( CROC TYPE 13 = JAW CLOSED, 14 = JAW OPEN ) 
VARIABLE LOGS25X     ( LOG SMALL 2 5 X ) 
VARIABLE FLYX        ( FLY X ) 
VARIABLE CROCHOMEX   ( CROCHOME X ) 
VARIABLE TSINK11     ( TURTLE11X, TURTLE21X & TURTLE31X SINKING - 0 = NO, 1 = START, 2 = MID, 3 = FINISH ) 
VARIABLE TSINK21     ( TURTLE41X & TURTLE51X SINKING ) 
VARIABLE TSINK31     ( TURTLE61X, TURTLE71X & TURTLE81X SINKING ) 
VARIABLE TSINK14     ( TURTLE14X & TURTLE24X SINKING ) 
VARIABLE TSINK24     ( TURTLE34X, TURTLE44X & TURTLE54X SINKING ) 
VARIABLE TSINK34     ( TURTLE64X, TURTLE74X & TURTLE84X SINKING ) 
VARIABLE ONTURLOG    ( ON TURTLE OR LOG - VALUE IS BETWEEN 27 AND 50 ) 
VARIABLE CROCHOMEVIS ( CROCHOME VISIBLE? 1 = Yes, 0 = No ) 
VARIABLE FLYVIS      ( FLY VISIBLE? 1 = Yes, 0 = No ) 
VARIABLE RESTARTCROCTIMER  ( RESTART CROCHOME TIMER? 1 = Yes, 0 = No ) 
VARIABLE RESTARTFLYTIMER   ( RESTART FLY TIMER? 1 = Yes, 0 = No ) 
VARIABLE FLYLOC      ( HOME LOCATION OF FLY ) 
VARIABLE CROCLOC     ( HOME LOCATION OF CROCHOME ) 

: SETVARS 
    0 SCORE ! 
    5 LIVES ! 
    0 TEMP ! 
    0 TEMPS ! 
    0 RUNGAME ! 
    120 TIMER ! 
    0 HOME1 ! 
    0 HOME2 ! 
    0 HOME3 ! 
    0 HOME4 ! 
    0 HOME5 ! 
    128 FX ! 
    264 FY ! 
    15 SS ! 
    -1 LASTKEY ! 
    128 RCY1X ! 
    0 RCY2X ! 
    0 D1X ! 
    84 D2X ! 
    170 D3X ! 
    48 C1X ! 
    96 C2X ! 
    144 C3X ! 
    192 C4X ! 
    240 C5X ! 
    16 RCW1X ! 
    48 RCW2X ! 
    140 RCW3X ! 
    172 RCW4X ! 
    160 T1X ! 
    80 T2X ! 
    0 T3X ! 
    -1 SNAKEX ! 
    16 TURTLE11X ! 
    32 TURTLE21X ! 
    48 TURTLE31X ! 
    112 TURTLE41X ! 
    128 TURTLE51X ! 
    160 TURTLE61X ! 
    176 TURTLE71X ! 
    192 TURTLE81X ! 
    0 LOGS12X ! 
    64 LOGS22X ! 
    144 LOGS32X ! 
    16 LOGL13X ! 
    144 LOGM13X ! 
    48 TURTLE14X ! 
    64 TURTLE24X ! 
    112 TURTLE34X ! 
    128 TURTLE44X ! 
    144 TURTLE54X ! 
    208 TURTLE64X ! 
    224 TURTLE74X ! 
    240 TURTLE84X ! 
    0 LOGS15X ! 
    64 LOGM15X ! 
    -1 CROC15X ! 
    13 CROCTYPE ! 
    144 LOGS25X ! 
    -1 FLYX ! 
    -1 CROCHOMEX ! 
    0 TSINK11 ! 
    0 TSINK21 ! 
    0 TSINK31 ! 
    0 TSINK14 ! 
    0 TSINK24 ! 
    0 TSINK34 ! 
    -1 ONTURLOG ! 
    0 CROCHOMEVIS ! 
    0 FLYVIS ! 
    0 RESTARTCROCTIMER ! 
    0 RESTARTFLYTIMER ! 
    0 FLYLOC ! 
    0 CROCLOC ! 
;

: UPDATEFINALSCORE 
    SCORE @ DUP TEMPS ! 10000 >= 
    IF 
        TEMPS @ 10000 / TEMP ! 
        62 TEMP @ 45 + 548 136 -1 0 LOADSPRITE 
        62 SHOWSPRITE 
        TEMPS @ 10000 TEMP @ * - TEMPS ! 
    THEN 
    TEMPS @ 1000 >= 
    IF 
        TEMPS @ 1000 / TEMP ! 
        63 TEMP @ 45 + 580 136 -1 0 LOADSPRITE 
        63 SHOWSPRITE 
        TEMPS @ 1000 TEMP @ * - TEMPS ! 
    THEN 
    TEMPS @ 100 >= 
    IF 
        TEMPS @ 100 / TEMP ! 
        64 TEMP @ 45 + 612 136 -1 0 LOADSPRITE 
        64 SHOWSPRITE 
        TEMPS @ 100 TEMP @ * - TEMPS ! 
    THEN 
    TEMPS @ 10 >= 
    IF 
        TEMPS @ 10 / TEMP ! 
        65 TEMP @ 45 + 644 136 -1 CHANGESPRITETEXTURE 
        65 SHOWSPRITE 
        TEMPS @ 10 TEMP @ * - TEMPS ! 
    THEN 
    66 TEMPS @ 45 + 676 136 -1 0 LOADSPRITE 
    66 SHOWSPRITE 
 ;

: GAMEOVER 
    0 DROP 
;

: PLACEFROG 
    -1 ONTURLOG ! 
    STARTX FX ! STARTY FY ! 
    0 0 CHANGESPRITETEXTURE 
    0 STARTX STARTY 1 MOVESPRITE 
    0 SHOWSPRITE 
;

: FDIE 
    1 0 0 1 MOVESPRITE 
    1 HIDESPRITE 
;

: FROGDIE 
    ." FROG DIE " CR 
    0 HIDESPRITE 
    1 FX FY 1 MOVESPRITE 
    1 SHOWSPRITE 
    ['] FDIE 12 1500 P-TIMERX 
    LIVES @ 1- LIVES ! 
    LIVES @ 1 < 
    IF 
        GAMEOVER 
    ELSE 
        PLACEFROG 
        LIVES @ 4 = 
        IF 
            6 REMOVESPRITE 
        ELSE 
            LIVES @ 3 = 
            IF 
                5 REMOVESPRITE 
            ELSE 
                LIVES @ 2 = 
                IF 
                    4 REMOVESPRITE 
                ELSE 
                    3 REMOVESPRITE 
                THEN 
            THEN 
        THEN 
    THEN 
;

: RESETCROCLOC 
    CROCLOC @ 1 = 
    IF 
        0 HOME1 !
    ELSE 
        CROCLOC @ 2 = 
        IF 
            0 HOME2 !
        ELSE 
            CROCLOC @ 3 = 
            IF 
                0 HOME3 !
            ELSE 
                CROCLOC @ 4 = 
                IF 
                    0 HOME4 !
                ELSE 
                    CROCLOC @ 5 = 
                    IF 
                        0 HOME5 !
                    THEN 
                THEN 
            THEN 
        THEN 
    THEN 
    CROCLOC ! 
;

: MOVECROCHOME 
    ." MOVECROCHOME " CR 
    RUNGAME @ 1 = 
    IF 
        CROCHOMEVIS @ 1 = 
        IF 
            8 HIDESPRITE 
            0 CROCHOMEVIS ! 
            -1 CROCHOMEX ! 
            8 -1 0 1 MOVESPRITE 
            1 RESTARTCROCTIMER ! 
        ELSE 
            CROCHOMEX @ -1 = 
            IF 
                HOME1 @ 0= 
                IF 
                    H1X CROCHOMEX ! 
                    2 HOME1 ! 
                    1 RESETCROCLOC 
                ELSE 
                    HOME4 @ 0= 
                    IF 
                        H4X CROCHOMEX ! 
                        2 HOME4 ! 
                        4 RESETCROCLOC 
                    ELSE 
                        HOME2 @ 0= 
                        IF 
                            H2X CROCHOMEX ! 
                            2 HOME2 ! 
                            2 RESETCROCLOC 
                        ELSE 
                            HOME5 @ 0= 
                            IF 
                                H5X CROCHOMEX ! 
                                2 HOME5 ! 
                                5 RESETCROCLOC 
                            ELSE 
                                HOME3 @ 0= 
                                IF 
                                    H3X CROCHOMEX ! 
                                    2 HOME3 ! 
                                    3 RESETCROCLOC 
                                THEN 
                            THEN 
                        THEN 
                    THEN 
                THEN 
                1 CROCHOMEVIS ! 
                8 CROCHOMEX @ HY 1 MOVESPRITE 
                8 SHOWSPRITE 
                1 RESTARTCROCTIMER ! 
            THEN 
        THEN 
    THEN 
;

: UPDATESCORE 
    SCORE @ TEMPS ! 
    TEMPS @ 10000 >= 
    IF 
        TEMPS @ 10000 / TEMP ! 
        51 TEMP @ 35 + CHANGESPRITETEXTURE 
        51 SHOWSPRITE 
        TEMPS @ 10000 TEMP @ * - TEMPS ! 
    THEN 
    TEMPS @ 1000 >= 
    IF 
        TEMPS @ 1000 / TEMP ! 
        52 TEMP @ 35 + CHANGESPRITETEXTURE 
        52 SHOWSPRITE 
        TEMPS @ 1000 TEMP @ * - TEMPS ! 
    THEN 
    TEMPS @ 100 >= 
    IF 
        TEMPS @ 100 / TEMP ! 
        53 TEMP @ 35 + CHANGESPRITETEXTURE 
        53 SHOWSPRITE 
        TEMPS @ 100 TEMP @ * - TEMPS ! 
    THEN 
    TEMPS @ 10 >= 
    IF 
        TEMPS @ 10 / TEMP ! 
        54 TEMP @ 35 + CHANGESPRITETEXTURE 
        54 SHOWSPRITE 
        TEMPS @ 10 TEMP @ * - TEMPS ! 
    THEN 
    55 TEMPS @ 35 + CHANGESPRITETEXTURE 
 ;

: RESETFLYLOC 
    FLYLOC @ 1 = 
    IF 
        0 HOME1 !
    ELSE 
        FLYLOC @ 2 = 
        IF 
            0 HOME2 !
        ELSE 
            FLYLOC @ 3 = 
            IF 
                0 HOME3 !
            ELSE 
                FLYLOC @ 4 = 
                IF 
                    0 HOME4 !
                ELSE 
                    FLYLOC @ 5 = 
                    IF 
                        0 HOME5 !
                    THEN 
                THEN 
            THEN 
        THEN 
    THEN 
    FLYLOC ! 
;

: MOVEFLY 
    ." MOVEFLY " CR 
    RUNGAME @ 1 = 
    IF 
        HOME1 @ 0= 
        IF 
            H1X FLYX ! 
            1 HOME1 ! 
            1 RESETFLYLOC 
        ELSE 
            HOME4 @ 0= 
            IF 
                H4X FLYX ! 
                1 HOME4 ! 
                4 RESETFLYLOC 
            ELSE 
                HOME2 @ 0= 
                IF 
                    H2X FLYX ! 
                    1 HOME2 ! 
                    2 RESETFLYLOC 
                ELSE 
                    HOME5 @ 0= 
                    IF 
                        H5X FLYX ! 
                        1 HOME5 ! 
                        5 RESETFLYLOC 
                    ELSE 
                        HOME3 @ 0= 
                        IF 
                            H3X FLYX ! 
                            1 HOME3 ! 
                            3 RESETFLYLOC 
                        THEN 
                    THEN 
                THEN 
            THEN 
        THEN 
        7 FLYX @ HY 1 MOVESPRITE 
        1 RESTARTFLYTIMER ! 
        FLYVIS @ 0 = 
        IF 
            7 SHOWSPRITE 
            1 FLYVIS ! 
        THEN 
    THEN 
;

: COLLISION 
    DUP -999 = 
    IF 
        DROP 
    ELSE 
        ." COLLISION WITH: " DUP . CR
        DUP DUP 
        9 >= SWAP 26 <= AND ( VEHICLE ) 
        IF 
            DROP 
            3 33 PLAYSOUND 
            FROGDIE 
        ELSE 
            DUP 
            61 = ( CROCINPLAY ) 
            IF 
                DROP 
                4 33 PLAYSOUND 
                FROGDIE 
            ELSE 
                DUP DUP 
                27 >= SWAP 34 <= ( TURTLES 1 ) 
                IF 
                   ONTURLOG ! 
                ELSE 
                    DUP DUP 
                    40 >= SWAP 47 <= ( TURTLES 2 ) 
                    IF 
                        ONTURLOG ! 
                    ELSE 
                        DUP DUP 
                        35 >= SWAP 39 <= ( LOGS 1 ) 
                        IF 
                            ONTURLOG ! 
                        ELSE 
                            DUP DUP 
                            48 >= SWAP 50 <= ( LOGS 2 ) 
                            IF 
                                ONTURLOG ! 
                            ELSE 
                                DUP 
                                8 = ( CROCHOME ) 
                                IF 
                                    DROP 
                                    4 33 PLAYSOUND 
                                    FROGDIE 
                                    -1 CROCHOMEX ! 
                                    0 CROCHOMEVIS ! 
                                    8 0 0 MOVESPRITE 
                                    8 HIDESPRITE
                                    ['] MOVECROCHOME 2 15 30 RAND 1000 * P-TIMERX 
                                ELSE 
                                    DUP 
                                    9 = ( SNAKE ) 
                                    IF 
                                        3 33 PLAYSOUND 
                                        DROP 
                                        FROGDIE 
                                    ELSE 
                                        DUP 
                                        7 = ( FLY ) 
                                        IF 
                                            2 33 PLAYSOUND 
                                            SCORE @ 150 + SCORE ! 
                                            UPDATESCORE 
                                            -1 FLYX ! 
                                            0 FLYVIS ! 
                                            7 0 0 MOVESPRITE 
                                            7 HIDESPRITE 
                                            ['] MOVEFLY 2 75 200 RAND 100 * P-TIMERX 
                                        THEN 
                                    THEN 
                                THEN 
                            THEN 
                        THEN 
                    THEN 
                THEN 
            THEN 
        THEN 
    THEN 
;

: CROCINPLAY 
    ." CROCINPLAY " CR 
    RUNGAME @ 1 = 
    IF 
        -2 CROC15X ! 
    THEN 
;

: UPDATETIME 
    RUNGAME @ 1 = 
    IF 
        LBEND TIMER @ - LBTOP 
        LBEND LBTOP 
        0 0 0 255 8 0 DRAWLINE 
        TIMER @ 2 - TIMER ! 
        LBEND TIMER @ - LBTOP 
        LBEND LBTOP 
        0 255 0 255 8 0 DRAWLINE 
        TIMER @ 10 < 
        IF 
            5 33 PLAYSOUND 
        ELSE 
            TIMER @ 0 <= 
            IF 
                3 33 PLAYSOUND 
                FROGDIE 
            THEN 
        THEN 
    THEN 
;

: STARTSNAKE 
    ." STARTSNAKE " CR 
    RUNGAME @ 1 = 
    IF 
        SNAKEX @ -1 = 
        IF 
            0 SNAKEX ! 
            15 SS ! 
            9 SNAKEX @ SY 1 MOVESPRITE 
            9 15 CHANGESPRITETEXTURE 
            9 SHOWSPRITE 
            6 33 PLAYSOUND 
        THEN 
    THEN 
;

: MOVEROAD1 
    RCY1X @ 8 - RCY1X ! 
    RCY2X @ 8 - RCY2X ! 
    RCY2X @ -15 < 
    IF 
        256 RCY2X ! 
    THEN 
    RCY1X @ -15 < 
    IF 
        255 RCY1X ! 
    THEN 
    10 RCY1X @ V1Y 1 MOVESPRITE 
    11 RCY2X @ V1Y 1 MOVESPRITE 
;

: MOVEROAD2 
    D1X @ 2 + D1X ! 
    D2X @ 2 + D2X ! 
    D3X @ 2 + D3X ! 
    D3X @ 256 > 
    IF 
        -15 D3X ! 
    THEN 
    D2X @ 256 > 
    IF 
        -15 D2X ! 
    THEN 
    D1X @ 256 > 
    IF 
        -15 D1X ! 
    THEN 
    12 D1X @ V2Y 1 MOVESPRITE 
    13 D2X @ V2Y 1 MOVESPRITE 
    14 D3X @ V2Y 1 MOVESPRITE 
;

: MOVEROAD3 
    C1X @ 4 - C1X ! 
    C2X @ 4 - C2X ! 
    C3X @ 4 - C3X ! 
    C4X @ 4 - C4X ! 
    C5X @ 4 - C5X ! 
    C5X @ -15 < 
    IF 
        255 C5X ! 
    THEN 
    C4X @ -15 < 
    IF 
        255 C4X ! 
    THEN 
    C3X @ -15 < 
    IF 
        255 C3X ! 
    THEN 
    C2X @ -15 < 
    IF 
        255 C2X ! 
    THEN 
    C1X @ -15 < 
    IF 
        255 C1X ! 
    THEN 
    15 C1X @ V3Y 1 MOVESPRITE 
    16 C2X @ V3Y 1 MOVESPRITE 
    17 C3X @ V3Y 1 MOVESPRITE 
    18 C4X @ V3Y 1 MOVESPRITE 
    19 C5X @ V3Y 1 MOVESPRITE 
;

: MOVEROAD4 
    RCW1X @ 8 + RCW1X ! 
    RCW2X @ 8 + RCW2X ! 
    RCW3X @ 8 + RCW3X ! 
    RCW4X @ 8 + RCW4X ! 
    RCW4X @ 256 > 
    IF 
        -15 RCW4X ! 
    THEN 
    RCW3X @ 256 > 
    IF 
        -15 RCW3X ! 
    THEN 
    RCW2X @ 256 > 
    IF 
        -15 RCW2X ! 
    THEN 
    RCW1X @ 256 > 
    IF 
        -15 RCW1X ! 
    THEN 
    20 RCW1X @ V4Y 1 MOVESPRITE 
    21 RCW2X @ V4Y 1 MOVESPRITE 
    22 RCW3X @ V4Y 1 MOVESPRITE 
    23 RCW4X @ V4Y 1 MOVESPRITE 
;

: MOVEROAD5 
    T1X @ 2 - T1X ! 
    T2X @ 2 - T2X ! 
    T3X @ 2 - T3X ! 
    T3X @ -31 < 
    IF 
        255 T3X ! 
    THEN 
    T2X @ -31 < 
    IF 
        255 T2X ! 
    THEN 
    T1X @ -31 < 
    IF 
        255 T1X ! 
    THEN 
    24 T1X @ V5Y 1 MOVESPRITE 
    25 T2X @ V5Y 1 MOVESPRITE 
    26 T3X @ V5Y 1 MOVESPRITE 
;

: T11SINK 
    ." T11SINK " CR 
    RUNGAME @ 1 = 
    IF 
        6 P-STOP 
        1 TSINK11 ! 
    THEN 
;

: T21SINK 
    ." T21SINK " CR 
    RUNGAME @ 1 = 
    IF 
        7 P-STOP 
        1 TSINK21 ! 
    THEN 
;

: T31SINK 
    ." T31SINK " CR 
    RUNGAME @ 1 = 
    IF 
        8 P-STOP 
        1 TSINK31 ! 
    THEN 
;

: T14SINK 
    ." T14SINK " CR 
    RUNGAME @ 1 = 
    IF 
        9 P-STOP 
        1 TSINK14 ! 
    THEN 
;

: T24SINK 
    ." T24SINK " CR 
    RUNGAME @ 1 = 
    IF 
        10 P-STOP 
        1 TSINK24 ! 
    THEN 
;

: T34SINK 
    ." T34SINK " CR 
    RUNGAME @ 1 = 
    IF 
        11 P-STOP 
        1 TSINK34 ! 
    THEN 
;

: MOVERIVER1 
    TURTLE11X @ 4 - TURTLE11X ! 
    TURTLE21X @ 4 - TURTLE21X ! 
    TURTLE31X @ 4 - TURTLE31X ! 
    TURTLE41X @ 4 - TURTLE41X ! 
    TURTLE51X @ 4 - TURTLE51X ! 
    TURTLE61X @ 4 - TURTLE61X ! 
    TURTLE71X @ 4 - TURTLE71X ! 
    TURTLE81X @ 4 - TURTLE81X ! 
    ONTURLOG @ -1 > ONTURLOG @ 99 < AND 
    IF 
        FX @ 4 - FX ! 
        0 -4 0 0 MOVESPRITE 
    THEN 
    TURTLE81X @ -15 < 
    IF 
        255 TURTLE81X ! 
        ONTURLOG @ 33 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE71X @ -15 < 
    IF 
        255 TURTLE71X ! 
        ONTURLOG @ 32 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE61X @ -15 < 
    IF 
        255 TURTLE61X ! 
        ONTURLOG @ 31 = 
        IF 
            99 ONTURLOG ! 
        THEN 
        0 TSINK31 ! 
        ['] T31SINK 8 20 40 RAND 1000 * P-TIMERX 
    THEN 
    TURTLE51X @ -15 < 
    IF 
        255 TURTLE51X ! 
        ONTURLOG @ 30 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE41X @ -15 < 
    IF 
        255 TURTLE41X ! 
        ONTURLOG @ 29 = 
        IF 
            99 ONTURLOG ! 
        THEN 
        0 TSINK21 ! 
        [']  T21SINK 7 20 40 RAND 1000 * P-TIMERX 
    THEN 
    TURTLE31X @ -15 < 
    IF 
        255 TURTLE31X ! 
        ONTURLOG @ 28 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE21X @ -15 < 
    IF 
        255 TURTLE21X ! 
        ONTURLOG @ 27 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE11X @ -15 < 
    IF 
        255 TURTLE11X ! 
        0 TSINK11 ! 
         ['] T11SINK 6 20 40 RAND 1000 * P-TIMERX 
    THEN 
    ONTURLOG @ 99 = 
    IF 
        FROGDIE 
    ELSE 
        FY @ R1Y @ = ONTURLOG @ -1 = AND 
        IF 
            FROGDIE 
        THEN 
    THEN 
    0 TSINK11 @ = 
    IF 
        27 18 CHANGESPRITETEXTURE 
        27 TURTLE11X @ R1Y 1 MOVESPRITE 
        27 SHOWSPRITE 
        28 18 CHANGESPRITETEXTURE 
        28 TURTLE21X @ R1Y 1 MOVESPRITE 
        28 SHOWSPRITE 
        29 18 CHANGESPRITETEXTURE 
        29 TURTLE31X @ R1Y 1 MOVESPRITE 
        29 SHOWSPRITE 
    ELSE 
        1 TSINK11 @ = 
        IF 
            2 TSINK11 ! 
            27 21 CHANGESPRITETEXTURE 
            27 TURTLE11X @ R1Y 1 MOVESPRITE 
            28 21 CHANGESPRITETEXTURE 
            28 TURTLE21X @ R1Y 1 MOVESPRITE 
            29 21 CHANGESPRITETEXTURE 
            29 TURTLE31X @ R1Y 1 MOVESPRITE 
        ELSE 
            2 TSINK11 @ = 
            IF 
                3 TSINK11 ! 
                27 22 CHANGESPRITETEXTURE 
                27 TURTLE11X @ R1Y 1 MOVESPRITE 
                28 22 CHANGESPRITETEXTURE 
                28 TURTLE21X @ R1Y 1 MOVESPRITE 
                29 22 CHANGESPRITETEXTURE 
                29 TURTLE31X @ R1Y 1 MOVESPRITE 
            ELSE 
                27 HIDESPRITE 
                28 HIDESPRITE 
                29 HIDESPRITE 
            THEN 
        THEN 
    THEN 
    0 TSINK21 @ = 
    IF 
        30 18 CHANGESPRITETEXTURE 
        30 TURTLE41X @ R1Y 1 MOVESPRITE 
        30 SHOWSPRITE 
        31 18 CHANGESPRITETEXTURE 
        31 TURTLE51X @ R1Y 1 MOVESPRITE 
        31 SHOWSPRITE 
    ELSE 
        1 TSINK21 @ = 
        IF 
            2 TSINK21 ! 
            30 21 CHANGESPRITETEXTURE 
            30 TURTLE41X @ R1Y 1 MOVESPRITE 
            31 21 CHANGESPRITETEXTURE 
            31 TURTLE51X @ R1Y 1 MOVESPRITE 
        ELSE 
            2 TSINK21 @ = 
            IF 
                3 TSINK31 ! 
                30 22 CHANGESPRITETEXTURE 
                30 TURTLE41X @ R1Y 1 MOVESPRITE 
                31 22 CHANGESPRITETEXTURE 
                31 TURTLE51X @ R1Y 1 MOVESPRITE 
            ELSE 
                30 SHOWSPRITE 
                31 SHOWSPRITE 
            THEN 
        THEN 
    THEN 
    0 TSINK31 @ = 
    IF 
        32 18 CHANGESPRITETEXTURE 
        32 TURTLE61X @ R1Y 1 MOVESPRITE 
        32 SHOWSPRITE 
        33 18 CHANGESPRITETEXTURE 
        33 TURTLE71X @ R1Y 1 MOVESPRITE 
        33 SHOWSPRITE 
        34 18 CHANGESPRITETEXTURE 
        34 TURTLE81X @ R1Y 1 MOVESPRITE 
        34 SHOWSPRITE 
    ELSE 
        1 TSINK31 @ = 
        IF 
            2 TSINK31 ! 
            32 21 CHANGESPRITETEXTURE 
            32 TURTLE61X @ R1Y 1 MOVESPRITE 
            33 21 CHANGESPRITETEXTURE 
            33 TURTLE71X @ R1Y 1 MOVESPRITE 
            34 21 CHANGESPRITETEXTURE 
            34 TURTLE81X @ R1Y 1 MOVESPRITE 
        ELSE 
            2 TSINK31 @ = 
            IF 
                3 TSINK31 ! 
                32 22 CHANGESPRITETEXTURE 
                32 TURTLE61X @ R1Y 1 MOVESPRITE 
                33 22 CHANGESPRITETEXTURE 
                33 TURTLE71X @ R1Y 1 MOVESPRITE 
                34 22 CHANGESPRITETEXTURE 
                34 TURTLE81X @ R1Y 1 MOVESPRITE 
            ELSE 
                32 SHOWSPRITE 
                33 SHOWSPRITE 
                34 SHOWSPRITE 
            THEN 
        THEN 
    THEN 
;

: MOVERIVER2 
    LOGS12X @ 8 + LOGS12X ! 
    LOGS22X @ 8 + LOGS22X ! 
    LOGS32X @ 8 + LOGS32X ! 
    ONTURLOG @ -1 > ONTURLOG @ 99 < AND 
    IF 
        FX @ 8 + FX ! 
        0 8 0 0 MOVESPRITE 
    THEN 
    LOGS32X @ 256 > 
    IF 
        -47 LOGS32X ! 
        ONTURLOG @ 37 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    LOGS22X @ 256 > 
    IF 
        -47 LOGS22X ! 
        ONTURLOG @ 36 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    LOGS12X @ 256 > 
    IF 
        -47 LOGS12X ! 
        ONTURLOG @ 35 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    ONTURLOG @ 99 = 
    IF 
        FROGDIE 
    ELSE 
        FY @ R2Y @ = ONTURLOG @ -1 = AND 
        IF 
            FROGDIE 
        THEN 
    THEN 
    35 LOGS12X @ R2Y 1 MOVESPRITE 
    36 LOGS22X @ R2Y 1 MOVESPRITE 
    37 LOGS32X @ R2Y 1 MOVESPRITE 
;

: MOVERIVER3 
    LOGL13X @ 2 + LOGL13X ! 
    LOGM13X @ 2 + LOGM13X ! 
    ONTURLOG @ -1 > ONTURLOG @ 99 < AND 
    IF 
        FX @ 2 + FX ! 
        0 2 0 0 MOVESPRITE 
    THEN 
    LOGM13X @ 256 > 
    IF 
        -63 LOGM13X ! 
        ONTURLOG @ 39 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    LOGL13X @ 256 > 
    IF 
        -95 LOGL13X ! 
        ONTURLOG @ 38 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    ONTURLOG @ 99 = 
    IF 
        FROGDIE 
    ELSE 
        FY @ R3Y @ = ONTURLOG @ -1 = AND 
        IF 
            FROGDIE 
        THEN 
    THEN 

    38 LOGL13X @ R3Y 1 MOVESPRITE 
    39 LOGM13X @ R3Y 1 MOVESPRITE 
;

: MOVERIVER4 
    TURTLE14X @ 4 - TURTLE14X ! 
    TURTLE24X @ 4 - TURTLE24X ! 
    TURTLE34X @ 4 - TURTLE34X ! 
    TURTLE44X @ 4 - TURTLE44X ! 
    TURTLE54X @ 4 - TURTLE54X ! 
    TURTLE64X @ 4 - TURTLE64X ! 
    TURTLE74X @ 4 - TURTLE74X ! 
    TURTLE84X @ 4 - TURTLE84X ! 
    ONTURLOG @ -1 > ONTURLOG @ 99 < AND 
    IF 
        FX @ 4 - FX ! 
        0 -4 0 0 MOVESPRITE 
    THEN 
    TURTLE84X @ -15 < 
    IF 
        255 TURTLE84X ! 
        ONTURLOG @ 47 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE74X @ -15 < 
    IF 
        255 TURTLE74X ! 
        ONTURLOG @ 46 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE64X @ -15 < 
    IF 
        255 TURTLE64X ! 
        ONTURLOG @ 45 = 
        IF 
            99 ONTURLOG ! 
        THEN 
        0 TSINK34 ! 
        ['] T34SINK 11 20 40 RAND 1000 * P-TIMERX 
    THEN 
    TURTLE54X @ -15 < 
    IF 
        255 TURTLE54X ! 
        ONTURLOG @ 44 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE44X @ -15 < 
    IF 
        255 TURTLE44X ! 
        ONTURLOG @ 43 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE34X @ -15 < 
    IF 
        255 TURTLE34X ! 
        ONTURLOG @ 42 = 
        IF 
            99 ONTURLOG ! 
        THEN 
        0 TSINK24 ! 
        ['] T24SINK 10 20 40 RAND 1000 * P-TIMERX 
    THEN 
    TURTLE24X @ -15 < 
    IF 
        255 TURTLE24X ! 
        ONTURLOG @ 41 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    TURTLE14X @ -15 < 
    IF 
        255 TURTLE14X ! 
        ONTURLOG @ 40 = 
        IF 
            99 ONTURLOG ! 
        THEN 
        0 TSINK14 ! 
        ['] T14SINK 9 20 40 RAND 1000 * P-TIMERX 
    THEN 
    ONTURLOG @ 99 = 
    IF 
        FROGDIE 
    ELSE 
        FY @ R4Y @ = ONTURLOG @ -1 = AND 
        IF 
            FROGDIE 
        THEN 
    THEN 
    0 TSINK14 @ = 
    IF 
        40 18 CHANGESPRITETEXTURE 
        40 TURTLE14X @ R4Y 1 MOVESPRITE 
        40 SHOWSPRITE 
        41 18 CHANGESPRITETEXTURE 
        41 TURTLE24X @ R4Y 1 MOVESPRITE 
        41 SHOWSPRITE 
    ELSE 
        1 TSINK14 @ = 
        IF 
            2 TSINK14 ! 
            40 21 CHANGESPRITETEXTURE 
            40 TURTLE14X @ R4Y 1 MOVESPRITE 
            41 21 CHANGESPRITETEXTURE 
            41 TURTLE24X @ R4Y 1 MOVESPRITE 
        ELSE 
            2 TSINK14 @ = 
            IF 
                3 TSINK14 ! 
                40 22 CHANGESPRITETEXTURE 
                40 TURTLE14X @ R4Y 1 MOVESPRITE 
                41 22 CHANGESPRITETEXTURE 
                41 TURTLE24X @ R4Y 1 MOVESPRITE 
            ELSE 
                40 HIDESPRITE 
                41 HIDESPRITE 
            THEN 
        THEN 
    THEN 
    0 TSINK24 @ = 
    IF 
        42 18 CHANGESPRITETEXTURE 
        42 TURTLE34X @ R4Y 1 MOVESPRITE 
        42 SHOWSPRITE 
        43 18 CHANGESPRITETEXTURE 
        43 TURTLE44X @ R4Y 1 MOVESPRITE 
        43 SHOWSPRITE 
        44 18 CHANGESPRITETEXTURE 
        44 TURTLE54X @ R4Y 1 MOVESPRITE 
        44 SHOWSPRITE 
    ELSE 
        1 TSINK24 @ = 
        IF 
            2 TSINK24 ! 
            42 21 CHANGESPRITETEXTURE 
            42 TURTLE34X @ R4Y 1 MOVESPRITE 
            43 21 CHANGESPRITETEXTURE 
            43 TURTLE44X @ R4Y 1 MOVESPRITE 
            44 21 CHANGESPRITETEXTURE 
            44 TURTLE54X @ R4Y 1 MOVESPRITE 
        ELSE 
            2 TSINK24 @ = 
            IF 
                3 TSINK34 ! 
                42 22 CHANGESPRITETEXTURE 
                42 TURTLE34X @ R4Y 1 MOVESPRITE 
                43 22 CHANGESPRITETEXTURE 
                43 TURTLE44X @ R4Y 1 MOVESPRITE 
                44 22 CHANGESPRITETEXTURE 
                44 TURTLE54X @ R4Y 1 MOVESPRITE 
            ELSE 
                42 HIDESPRITE 
                43 HIDESPRITE 
                44 HIDESPRITE 
            THEN 
        THEN 
    THEN 
    0 TSINK34 @ = 
    IF 
        45 18 CHANGESPRITETEXTURE 
        45 TURTLE64X @ R4Y 1 MOVESPRITE 
        45 SHOWSPRITE 
        46 18 CHANGESPRITETEXTURE 
        46 TURTLE74X @ R4Y 1 MOVESPRITE 
        46 SHOWSPRITE 
        47 18 CHANGESPRITETEXTURE 
        47 TURTLE84X @ R4Y 1 MOVESPRITE 
        47 SHOWSPRITE 
    ELSE 
        1 TSINK34 @ = 
        IF 
            2 TSINK34 ! 
            45 21 CHANGESPRITETEXTURE 
            45 TURTLE64X @ R4Y 1 MOVESPRITE 
            46 21 CHANGESPRITETEXTURE 
            46 TURTLE74X @ R4Y 1 MOVESPRITE 
            47 21 CHANGESPRITETEXTURE 
            47 TURTLE84X @ R4Y 1 MOVESPRITE 
        ELSE 
            2 TSINK34 @ = 
            IF 
                3 TSINK34 ! 
                45 22 CHANGESPRITETEXTURE 
                45 TURTLE64X @ R4Y 1 MOVESPRITE 
                46 22 CHANGESPRITETEXTURE 
                46 TURTLE74X @ R4Y 1 MOVESPRITE 
                47 22 CHANGESPRITETEXTURE 
                47 TURTLE84X @ R4Y 1 MOVESPRITE 
            ELSE 
                45 HIDESPRITE 
                46 HIDESPRITE 
                47 HIDESPRITE 
            THEN 
        THEN 
    THEN 
;

: MOVERIVER5 
    ONTURLOG @ -1 > ONTURLOG @ 99 < AND 
    IF 
        FX @ 2 + FX ! 
        0 2 0 0 MOVESPRITE 
    THEN 
    -1 CROC15X @ = 
    IF 
        LOGS15X @ 2 + LOGS15X ! 
        LOGS25X @ 2 + LOGS25X ! 
        LOGS25X @ 256 > 
        IF 
            -47 LOGS25X ! 
            ONTURLOG @ 50 = 
            IF 
                99 ONTURLOG ! 
            THEN 
        THEN 
        LOGS15X @ 256 > 
        IF 
            -47 LOGS15X ! 
            ONTURLOG @ 48 = 
            IF 
                99 ONTURLOG ! 
            THEN 
        THEN 
    ELSE 
        CROC15X @ -2 =
        IF
            LOGS15X @ 2 + LOGS15X ! 
            LOGS25X @ 2 + LOGS25X ! 
            LOGS15X @ 256 > 
            IF 
                ONTURLOG @ 48 = 
                IF 
                    99 ONTURLOG ! 
                THEN 
                -1 LOGS15X ! 
                48 -1 0 1 MOVESPRITE 
                48 HIDESPRITE 
                61 -47 R5Y 1 MOVESPRITE 
                61 SHOWSPRITE 
                -47 CROC15X !
                13 CROCTYPE ! 
                ['] CROCINPLAY 5 15 30 RAND 1000 * P-TIMERX 
            ELSE 
                LOGS25X @ 256 > 
                IF 
                    ONTURLOG @ 50 = 
                    IF 
                        99 ONTURLOG ! 
                    THEN 
                    -1 LOGS25X ! 
                    50 -1 0 1 MOVESPRITE 
                    50 HIDESPRITE 
                    61 -47 R5Y 1 MOVESPRITE 
                    61 SHOWSPRITE 
                    -47 CROC15X ! 
                    13 CROCTYPE !
                    ['] CROCINPLAY 5 15 30 RAND 1000 * P-TIMERX 
                THEN 
            THEN 
        ELSE 
            LOGS15X @ -1 = 
            IF 
                CROC15X @ 2 + CROC15X ! 
                LOGS25X @ 2 + LOGS25X ! 
                LOGS25X @ 256 > 
                IF 
                    -47 LOGS25X ! 
                    ONTURLOG @ 50 = 
                    IF 
                        99 ONTURLOG ! 
                    THEN 
                THEN 
                CROC15X @ 256 > 
                IF 
                    -1 CROC15X ! 
                    61 -1 0 1 MOVESPRITE 
                    61 HIDESPRITE 
                    -47 LOGS15X ! 
                    48 -47 R5Y 1 MOVESPRITE 
                    48 SHOWSPRITE 
                ELSE 
                    CROCTYPE @ 13 = 
                    IF 
                        14 CROCTYPE ! 
                        61 14 CHANGESPRITETEXTURE 
                    ELSE 
                        13 CROCTYPE ! 
                        61 13 CHANGESPRITETEXTURE 
                    THEN 
                THEN 
            ELSE 
                LOGS25X @ -1 = 
                IF 
                    CROC15X @ 2 + CROC15X ! 
                    LOGS15X @ 2 + LOGS15X ! 
                    LOGS15X @ 256 > 
                    IF 
                        -47 LOGS15X ! 
                        ONTURLOG @ 48 = 
                        IF 
                            99 ONTURLOG ! 
                        THEN 
                    THEN 
                    CROC15X @ 256 > 
                    IF 
                        -1 CROC15X ! 
                        61 -1 0 1 MOVESPRITE 
                        61 HIDESPRITE 
                        -47 LOGS25X ! 
                        50 -47 R5Y 1 MOVESPRITE 
                        50 SHOWSPRITE 
                    ELSE 
                        CROCTYPE @ 13 = 
                        IF 
                            14 CROCTYPE ! 
                            61 14 CHANGESPRITETEXTURE 
                        ELSE 
                            13 CROCTYPE ! 
                            61 13 CHANGESPRITETEXTURE 
                        THEN 
                    THEN 
                THEN 
            THEN 
        THEN 
    THEN 
    LOGM15X @ 2 + LOGM15X ! 
    LOGM15X @ 256 > 
    IF 
        -63 LOGM15X ! 
        ONTURLOG @ 49 = 
        IF 
            99 ONTURLOG ! 
        THEN 
    THEN 
    ONTURLOG @ 99 = 
    IF 
        FROGDIE 
    ELSE 
        FY @ R5Y @ = ONTURLOG @ -1 = AND 
        IF 
            FROGDIE 
        THEN 
    THEN 
    49 LOGM15X @ R5Y 1 MOVESPRITE 
    CROC15X @ 0> 
    IF 
        61 CROC15X @ R5Y 1 MOVESPRITE 
        LOGS15X @ -1 = 
        IF 
            50 LOGS25X @ R5Y 1 MOVESPRITE 
        ELSE 
            48 LOGS15X @ R5Y 1 MOVESPRITE 
        THEN 
    ELSE 
        48 LOGS15X @ R5Y 1 MOVESPRITE 
        50 LOGS25X @ R5Y 1 MOVESPRITE 
    THEN 
;

: MOVESNAKE 
    4 P-STOP 
    SNAKEX @ 4 + SNAKEX ! 
    SNAKEX @ 256 > 
    IF 
        -1 SNAKEX ! 
        9 HIDESPRITE 
        ['] STARTSNAKE 4 10 40 RAND 1000 * P-TIMERX 
    THEN 
    SS @ 15 = 
    IF 
        9 16 CHANGESPRITETEXTURE 
        9 SNAKEX @ SY 1 MOVESPRITE 
        16 SS ! 
    ELSE 
        SS @ 16 = 
        IF 
            9 17 CHANGESPRITETEXTURE 
            9 SNAKEX @ SY 1 MOVESPRITE 
            17 SS ! 
        ELSE 
            9 15 CHANGESPRITETEXTURE 
            9 SNAKEX @ SY 1 MOVESPRITE 
            15 SS ! 
        THEN 
    THEN 
;

: SAFE1 
    HOME1 @ 2 >= 
    IF 
        FROGDIE 
    ELSE 
        56 9 H1X HY -1 0 LOADSPRITE 
        HOME1 @ 1 = 
        IF 
            SCORE @ 250 + SCORE ! 
        ELSE 
            SCORE @ 50 + SCORE ! 
        THEN 
        3 HOME1 ! 
        UPDATESCORE 
        PLACEFROG 
    THEN 
;

: SAFE2 
    HOME2 @ 2 >= 
    IF 
        FROGDIE 
    ELSE 
        57 9 H2X HY -1 0 LOADSPRITE 
        HOME2 @ 1 = 
        IF 
            SCORE @ 250 + SCORE ! 
        ELSE 
            SCORE @ 50 + SCORE ! 
        THEN 
        3 HOME2 ! 
        UPDATESCORE 
        PLACEFROG 
    THEN 
;

: SAFE3 
    HOME3 @ 2 >= 
    IF 
        FROGDIE 
    ELSE 
        58 9 H3X HY -1 0 LOADSPRITE 
        HOME3 @ 1 = 
        IF 
            SCORE @ 250 + SCORE ! 
        ELSE 
            SCORE @ 50 + SCORE ! 
        THEN 
        3 HOME3 ! 
        UPDATESCORE 
        PLACEFROG 
    THEN 
;

: SAFE4 
    HOME4 @ 2 >= 
    IF 
        FROGDIE 
    ELSE 
        59 9 H4X HY -1 0 LOADSPRITE 
        HOME4 @ 1 = 
        IF 
            SCORE @ 250 + SCORE ! 
        ELSE 
            SCORE @ 50 + SCORE ! 
        THEN 
        3 HOME4 ! 
        UPDATESCORE 
        PLACEFROG 
    THEN 
;

: SAFE5 
    HOME5 @ 2 >= 
    IF 
        FROGDIE 
    ELSE 
        60 9 H5X HY -1 0 LOADSPRITE 
        HOME5 @ 1 = 
        IF 
            SCORE @ 250 + SCORE ! 
        ELSE 
            SCORE @ 50 + SCORE ! 
        THEN 
        3 HOME5 ! 
        UPDATESCORE 
        PLACEFROG 
    THEN 
;

: CHECKFROGHOME 
    FY @ HY = 
    IF 
        FX @ H1X 2 - >= FX @ H1X 2 + <= AND 
        IF 
            H1X FX ! 
            SAFE1 -1 
            2 33 PLAYSOUND 
        ELSE 
            FX @ H2X 2 - >= FX @ H2X 2 + <= AND 
            IF 
                H2X FX ! 
                SAFE2 -1 
                2 33 PLAYSOUND 
            ELSE 
                FX @ H3X 2 - >= FX @ H3X 2 + <= AND 
                IF 
                    H3X FX ! 
                    SAFE3 -1 
                    2 33 PLAYSOUND 
                ELSE 
                    FX @ H4X 2 - >= FX @ H4X 2 + <= AND 
                    IF 
                        H4X FX ! 
                        SAFE4 -1 
                        2 33 PLAYSOUND 
                    ELSE 
                        FX @ H5X 2 - >= FX @ H5X 2 + <= AND 
                        IF 
                            H5X FX ! 
                            SAFE5 -1 
                            2 33 PLAYSOUND 
                        ELSE 
                            FROGDIE 0 
                        THEN 
                    THEN 
                THEN 
            THEN 
        THEN 
    ELSE 
        -1 
    THEN 
;

: MOVEFROGUP 
    1 33 PLAYSOUND 
    -1 ONTURLOG ! 
    FY @ 6 - FY ! 0 0 -6 0 MOVESPRITE 
    0 1 CHANGESPRITETEXTURE 
    FY @ 6 - FY ! 0 0 -6 0 MOVESPRITE 
    0 2 CHANGESPRITETEXTURE 
    FY @ 6 - FY ! 0 0 -6 0 MOVESPRITE 
    0 0 CHANGESPRITETEXTURE 
    FY @ . CR 
    CHECKFROGHOME 
    IF 
        SCORE @ 40 + SCORE ! 
    THEN 
    SCORE @ 10 + SCORE ! 
    UPDATESCORE 
;

: MOVEFROGLEFT 
    1 33 PLAYSOUND 
    -1 ONTURLOG ! 
    FX @ 16 - LHS < 
    IF 
        FROGDIE 
    ELSE 
        0 5 CHANGESPRITETEXTURE 
        FX @ 16 - FX ! 0 -16 0 0 MOVESPRITE 
        0 3 CHANGESPRITETEXTURE 
    THEN 
;

: MOVEFROGRIGHT 
    1 33 PLAYSOUND 
    -1 ONTURLOG ! 
    FX @ 16 + RHS > 
    IF 
        FROGDIE 
    ELSE 
        0 8 CHANGESPRITETEXTURE 
        FX @ 16 + FX ! 0 16 0 0 MOVESPRITE 
        0 6 CHANGESPRITETEXTURE 
    THEN 
;

: UPDATELIVES 
    2 34 LIVES1X LIVESY 0 0 LOADSPRITE 
    3 34 LIVES2X LIVESY 0 0 LOADSPRITE 
    4 34 LIVES3X LIVESY 0 0 LOADSPRITE 
    5 34 LIVES4X LIVESY 0 0 LOADSPRITE 
    6 34 LIVES5X LIVESY 0 0 LOADSPRITE 
;

: PLACEROAD 
    10 24 RCY1X @ V1Y 0 -2 LOADSPRITE 
    11 24 RCY2X @ V1Y 0 -2 LOADSPRITE 
    12 23 D1X @ V2Y 0 -2 LOADSPRITE 
    13 23 D2X @ V2Y 0 -2 LOADSPRITE 
    14 23 D3X @ V2Y 0 -2 LOADSPRITE 
    15 26 C1X @ V3Y 0 -2 LOADSPRITE 
    16 26 C2X @ V3Y 0 -2 LOADSPRITE 
    17 26 C3X @ V3Y 0 -2 LOADSPRITE 
    18 26 C4X @ V3Y 0 -2 LOADSPRITE 
    19 26 C5X @ V3Y 0 -2 LOADSPRITE 
    20 25 RCW1X @ V4Y 0 -2 LOADSPRITE 
    21 25 RCW2X @ V4Y 0 -2 LOADSPRITE 
    22 25 RCW3X @ V4Y 0 -2 LOADSPRITE 
    23 25 RCW4X @ V4Y 0 -2 LOADSPRITE 
    24 27 T1X @ V5Y 0 -2 LOADSPRITE 
    25 27 T2X @ V5Y 0 -2 LOADSPRITE 
    26 27 T3X @ V5Y 0 -2 LOADSPRITE 
;

: PLACERIVER 
    27 18 TURTLE11X @ R1Y 0 0 LOADSPRITE 
    28 18 TURTLE21X @ R1Y 0 0 LOADSPRITE 
    29 18 TURTLE31X @ R1Y 0 0 LOADSPRITE 
    30 18 TURTLE41X @ R1Y 0 0 LOADSPRITE 
    31 18 TURTLE51X @ R1Y 0 0 LOADSPRITE 
    32 18 TURTLE61X @ R1Y 0 0 LOADSPRITE 
    33 18 TURTLE71X @ R1Y 0 0 LOADSPRITE 
    34 18 TURTLE81X @ R1Y 0 0 LOADSPRITE 
    35 28 LOGS12X @ R2Y 0 0 LOADSPRITE 
    36 28 LOGS22X @ R2Y 0 0 LOADSPRITE 
    37 28 LOGS32X @ R2Y 0 0 LOADSPRITE 
    38 30 LOGL13X @ R3Y 0 0 LOADSPRITE 
    39 29 LOGM13X @ R3Y 0 0 LOADSPRITE 
    40 18 TURTLE14X @ R4Y 0 0 LOADSPRITE 
    41 18 TURTLE24X @ R4Y 0 0 LOADSPRITE 
    42 18 TURTLE34X @ R4Y 0 0 LOADSPRITE 
    43 18 TURTLE44X @ R4Y 0 0 LOADSPRITE 
    44 18 TURTLE54X @ R4Y 0 0 LOADSPRITE 
    45 18 TURTLE64X @ R4Y 0 0 LOADSPRITE 
    46 18 TURTLE74X @ R4Y 0 0 LOADSPRITE 
    47 18 TURTLE84X @ R4Y 0 0 LOADSPRITE 
    48 28 LOGS15X @ R5Y 0 0 LOADSPRITE 
    49 29 LOGM15X @ R5Y 0 0 LOADSPRITE 
    50 28 LOGS25X @ R5Y 0 0 LOADSPRITE 
    61 13 -1 0 0 0 LOADSPRITE 
    61 HIDESPRITE 
;

: CREATESCORE 
    51 35 SCORE1X SCOREY -1 0 LOADSPRITE 
    51 HIDESPRITE 
    52 35 SCORE2X SCOREY -1 0 LOADSPRITE 
    52 HIDESPRITE 
    53 35 SCORE3X SCOREY -1 0 LOADSPRITE 
    53 HIDESPRITE 
    54 35 SCORE4X SCOREY -1 0 LOADSPRITE 
    54 HIDESPRITE 
    55 35 SCORE5X SCOREY -1 0 LOADSPRITE 
;


: PROCESS 
    RESTARTFLYTIMER @ 1 = 
    IF 
        0 RESTARTFLYTIMER ! 
        ['] MOVEFLY 2 75 200 RAND 100 * P-TIMERX 
    THEN 
    RESTARTCROCTIMER @ 1 = 
    IF 
        0 RESTARTCROCTIMER ! 
        ['] MOVECROCHOME 3 15 30 RAND 1000 * P-TIMERX 
    THEN 
    KEY? 
    IF 
        KEY LASTKEY ! 
        LASTKEY @ 65 = LASTKEY @ 97 = OR 
        IF 
            MOVEFROGLEFT 
        ELSE 
            LASTKEY @ 87 = LASTKEY @ 119 = OR 
            IF 
                MOVEFROGUP 
            ELSE 
                LASTKEY @ 68 = LASTKEY @ 100 = OR 
                IF 
                    MOVEFROGRIGHT 
                THEN 
            THEN 
        THEN 
        -1 LASTKEY ! 
    THEN 
    MOVEROAD1 
    MOVEROAD2 
    MOVEROAD3 
    MOVEROAD4 
    MOVEROAD5 
    SNAKEX @ -1 > 
    IF 
        MOVESNAKE 
    THEN 
    MOVERIVER1 
    MOVERIVER2 
    MOVERIVER3 
    MOVERIVER4 
    MOVERIVER5 
    LIVES @ 0= TIMER @ 1 < OR 
    IF 
        GAMEOVER 
    THEN 
;

: STARTGAME 
    272 84 256 312 CREATESPRITEWINDOW 
    0 0 0 0 LOADBACKGROUND 
    SETVARS 
    CREATESCORE 
    UPDATESCORE 
    UPDATELIVES 
    1 10 0 0 0 0 LOADSPRITE 
    1 HIDESPRITE 
    PLACEROAD 
    PLACERIVER 
    7 11 0 0 0 0 LOADSPRITE 
    7 HIDESPRITE 
    8 12 0 0 0 0 LOADSPRITE 
    8 HIDESPRITE 
    9 15 0 0 0 0 LOADSPRITE 
    9 HIDESPRITE 
    0 0 STARTX STARTY 1 0 LOADSPRITE 
    ['] UPDATETIME 1 2000 P-TIMERX 
    ['] MOVEFLY 2 75 200 RAND 100 * P-TIMERX 
    ['] MOVECROCHOME 3 15 30 RAND 1000 * P-TIMERX 
    ['] STARTSNAKE 4 20 40 RAND 1000 * P-TIMERX 
    ['] CROCINPLAY 5 15 30 RAND 1000 * P-TIMERX 
    ['] T11SINK 6 20 40 RAND 1000 * P-TIMERX 
    ['] T21SINK 7 20 40 RAND 1000 * P-TIMERX 
    ['] T31SINK 8 20 40 RAND 1000 * P-TIMERX 
    ['] T14SINK 9 20 40 RAND 1000 * P-TIMERX 
    ['] T24SINK 10 20 40 RAND 1000 * P-TIMERX 
    ['] T34SINK 11 20 40 RAND 1000 * P-TIMERX 
    ['] COLLISION 100 0 LISTENX 
    ['] PROCESS 99 100 P-TIMERX 
    1 RUNGAME ! 
;

: CHKKEY2 
    KEY? 
    IF 
        STOPMUSIC 
        12 P-STOP 
        -1 LASTKEY ! 
        KEY DUP 
        81 = SWAP 113 = OR 
        IF 
            66 62 
            DO 
                I REMOVESPRITE 
            LOOP 
            CLEARBACKGROUND 
        ELSE 
            STARTGAME 
        THEN 
    THEN 
;

: GAMEOVER 
    2 33 PLAYMUSIC 
    99 P-STOP 
    1 P-STOP 
    2 P-STOP 
    3 P-STOP 
    4 P-STOP 
    5 P-STOP 
    6 P-STOP 
    7 P-STOP 
    8 P-STOP 
    9 P-STOP 
    10 P-STOP 
    11 P-STOP 
    61 0 
    DO 
        I REMOVESPRITE 
    LOOP 
    0 0 0 0 0 CLEARSCREEN 
    2 0 0 0 LOADBACKGROUND 
    UPDATEFINALSCORE 
    KEY DROP 
    -1 LASTKEY ! 
    ['] CHKKEY2 12 500 P-TIMERX 
;

: CHKKEY 
    KEY? 
    IF 
        12 P-STOP 
        -1 LASTKEY ! 
        STOPMUSIC 
        STARTGAME 
    THEN 
;

: FROGGER 
    KEY DROP 
    -1 LASTKEY ! 
    1 0 0 0 LOADBACKGROUND 
    ['] CHKKEY 12 500 P-TIMERX 
    1 33 PLAYMUSIC 
;

