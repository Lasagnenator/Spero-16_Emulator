; John Conway's Game of Life
; https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
;
; Rules:
;   1. Any live cell with fewer than two live neighbours dies,
;      as if by underpopulation.
;   2. Any live cell with two or three live neighbours lives on
;      to the next generation.
;   3. Any live cell with more than three live neighbours dies,
;      as if by overpopulation.
;   4. Any dead cell with exactly three live neighbours becomes
;      a live cell, as if by reproduction.
;
; This implementation uses two 2D grids. Every cell is inspected
; every update, regardless.There are no optimizations applied.
;
; The world is a flat 2D 128x128 pixel grid, mapped to a torus.
; Each grid element is a 16-bit word. A dead cell has the value 0,
; while an alive cell has a non-zero value (usually 1).
;
; Button 0: Randomize the 128x128 cell grid
;        1: Preset "R-pentomino"
;        2: Preset "Diehard"
;        3: Preset "Acorn"
;        7: Run the 128x128 cell grid, press again to stop
;    LED 7: When lit, game is running
;
; Internally, the buttons are "momentary push" but are implemented
; using checkboxes. The checkboxes are ticked to act as being "pressed"
; and must then be unchecked to act as being "released".
;
; Fixed register allocation:
;   RF = program counter
;   RE = link register
;   RD = second link register
;   R0 = always zero

.Start

    ; -----------------------------------------
    ; Main control loop.
    ; Wait for user to choose an action.
    ;
.Mainloop
    load    re,#.getUserInput       ; cycle the RNG
    jump    .NextRandom             ; do this while waiting for user input
                                    ;
.getUserInput
    load    r2,#0010                ; I/O address of push buttons
    readio  r1,r2                   ; R1 = bitmap of pushbuttons
                                    ;
    load    r2,#0001                ; button #0 "Randomize Cells"
    jumpeq  r1,r2,.RandomPopulate   ; pressed?
                                    ;
    load    r2,#0002                ; button #1 "R-pentomino" preset
    jumpeq  r1,r2,.PresetRpentomino ; pressed?
                                    ;
    load    r2,#0004                ; button #2 "Diehard" preset
    jumpeq  r1,r2,.PresetDiehard    ; pressed?
                                    ;
    load    r2,#0008                ; button #3 "Acorn" preset
    jumpeq  r1,r2,.PresetAcorn      ; pressed?
                                    ;
    load    r2,#0080                ; button #7 "Run/Stop"
    jumpeq  r1,r2,.RunGameOfLife    ; pressed?
                                    ;
    jump    .Mainloop               ; do it forever

    ; -----------------------------------------
    ; Generate a random population of cells.
    ;
.RandomPopulate
    load    re,#.doRandom           ;
    jump    .WaitButtonsRelease     ;
                                    ;
.doRandom
    load    r4,#.CellArrays         ; address of current array in .CellArrays
    load    r7,#1                   ; constant 1
    load    r8,#4000                ; size of 128x128 array
                                    ;
    load    r5,#1F                  ;
    load    r6,#0                   ; probability of one in 32 cells is set alive
                                    ;
.randomNextCell
    load    re,#.randomizeCell      ;
    jump    .NextRandom             ; R2 = 16-bit random number
                                    ;
.randomizeCell
    or      r1,r0,r0                ; presume cell is set dead (0)
    and     r2,r2,r5                ;
    jumpgt  r2,r6,.randomCellState  ;
    or      r1,r7,r7                ; cell is to be set alive (1)
.randomCellState
    store   r1,*r4                  ;
                                    ;
    add     r4,r7,r0                ; next cell
    sub     r8,r7,r0                ;
    jumpne  r8,r0,.randomNextCell   ;
                                    ;
    store   r0,.CurrentOffset       ; offset of current array in .CellArrays
    load    re,#.Mainloop           ;
    jump    .RenderCurrentCells     ; finally, draw the result

    ; -----------------------------------------
    ; Initialize the cells array with presets.
    ;
.PresetRpentomino
    load    rb,#.RpentominoCells    ; The "R-pentomino".
    jump    .DrawPreset             ;

.PresetDiehard
    load    rb,#.DieHardCells       ; The "diehard".
    jump    .DrawPreset             ;

.PresetAcorn
    load    rb,#.AcornCells         ; The "acorn".
    jump    .DrawPreset             ;

    ; -----------------------------------------
    ; Run the "Game of Life".
    ; Continues until the "Run/Stop" button is pressed.
    ;
.RunGameOfLife
    store   r0,.CurrentOffset       ; offset of current array in .CellArrays
    load    r1,#4000                ; size of 128x128 array
    store   r1,.NextOffset          ; offset of next array in .CellArrays
                                    ;
    load    re,#.runGo              ;
    jump    .WaitButtonsRelease     ; wait for "RUN" button to be released
                                    ;
.runGo
    load    re,#.runMainloop        ;
    jump    .TurnOnRunLED           ;
                                    ;
.runMainloop
    load    re,#.returnFromMNC      ; inner mainloop
    jump    .MakeNextCells          ; create the next array of cells from current array
.returnFromMNC
                                    ;
    load    re,#.returnFromSCB      ;
    jump    .SwapCellBuffers        ; next (newly generated) becomes current
.returnFromSCB
                                    ;
    load    re,#.returnFromRCC      ;
    jump    .RenderCurrentCells     ; display the newly current grid of cells
.returnFromRCC
                                    ;
    load    re,#.returnFromSTT      ;
    jump    .SynchronizeToTick      ; aiming for 20 Hz refresh rate
.returnFromSTT
                                    ;
    load    r3,#0010                ; I/O address of push buttons
    readio  r1,r3                   ; R1 = bitmap of pushbuttons
    load    r2,#0080                ; button #7 "Run/Stop"
    jumpne  r1,r2,.runMainloop      ; keep playing if not pressed
                                    ;
    load    re,#.runStop            ;
    jump    .WaitButtonsRelease     ; wait for "STOP" button to be released
                                    ;
.runStop
    load    re,#.Mainloop           ; end this game
    jump    .TurnOffRunLED          ;

    ; -----------------------------------------
    ; Take current array of cells and create the next array of cells.
    ; Entry RE = return address
    ; Uses  All registers
    ;
.MakeNextCells
    load    r1,#.CellArrays         ; cells array base address
    load    rb,.CurrentOffset       ;
    add     rb,r1,r0                ; address of current array in .CellArrays
    load    r6,.NextOffset          ;
    add     r6,r1,r0                ; address of next array in .CellArrays
                                    ;
    load    r7,#2                   ; minimum number of neighbours
    load    r8,#3                   ; maximum number of neighbours
    load    r1,#1                   ; constant 1
                                    ;
    load    rc,#0                   ; relative offset into current array
    load    r9,#4000                ; size of 128x128 array
    load    ra,#3FFF                ; array index masking
                                    ;
.doNextCell
    load    rd,#.updateCell         ;
    jump    .CountCellNeighbours    ; R4 = count of alive neighbours (0..8)
                                    ;
.updateCell
    or      r2,r0,r0                ; R2 = 0, presume that cell will die
    jumplt  r4,r7,.setCell          ; not enough neighbours: die
    jumpgt  r4,r8,.setCell          ; too many neighbours: die
    jumpne  r4,r8,.cellNoChange     ; not exactly MAX neighbours: no change
    or      r2,r1,r1                ; R2 = 1, cell is to be born
    jump    .setCell                ;
                                    ;
.cellNoChange
    or      r4,rc,rc                ;
    add     r4,rb,r0                ; R4 = address into current array memory
    load    r2,*r4                  ; get whatever the cell currently is
                                    ;
.setCell
    store   r2,*r6                  ; zero = dead, non-zero = alive
    add     r6,r1,r0                ; advance through the next array
                                    ;
    add     rc,r1,r0                ; next relative offset
    jumplt  rc,r9,.doNextCell       ; loop until all cells are updated
                                    ;
    jump    re                      ; return

    ; Entry RD = return address
    ;       RC = relative offset into current array
    ;       RB = address of current array in .CellArrays
    ;       RA = constant &H3FFF array index masking
    ;       R1 = constant 1
    ; Uses  R2, R3, R5
    ; Exit  R4 = count of alive neighbours (0..8)
    ;
.CountCellNeighbours
    load    r2,#.cellOffsets        ; pointer
    load    r3,#8                   ; number of neighbouring cells to examine
    load    r4,#0                   ; number of alive neighbours
                                    ;
.getNeighbour
    load    r5,*r2                  ;
    add     r5,rc,r0                ; get relative offset to neighbour
    and     r5,r5,ra                ; 128x128 array (world is a torus)
    add     r5,rb,r0                ; R5 = address into current array memory

    load    r5,*r5                  ; get the cell: 0 = dead, non-zero = alive
    jumpeq  r5,r0,.nextNeighbour    ;
    add     r4,r1,r0                ; count another alive neighbour
                                    ;
.nextNeighbour
    add     r2,r1,r0                ; next cell neighbour offset
    sub     r3,r1,r0                ;
    jumpne  r3,r0,.getNeighbour     ; loop until all 8 neighbours are checked
                                    ;
    jump    rd                      ; return

.cellOffsets
    dw      FF7F                    ; -129  upper-left
    dw      FF80                    ; -128  upper-center
    dw      FF81                    ; -127  upper-right
    dw      FFFF                    ;   -1  center-left
    dw      0001                    ;    1  center-right
    dw      007F                    ;  127  lower-left
    dw      0080                    ;  128  lower-center
    dw      0081                    ;  129  lower-right

    ; -----------------------------------------
    ; Double buffer the cells so that all updates are synchronous.
    ; Entry RE = return address
    ; Uses  R1, R2
    ;
.SwapCellBuffers
    load    r1,.CurrentOffset       ;
    store   r1,.NextOffset          ; next = current
    load    r2,#4000                ; size of 128x128 array
    xor     r1,r1,r2                ; swap current with next
    store   r1,.CurrentOffset       ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Draw the current array of cells to bitmap display.
    ; Entry RE = return address
    ; Uses  All registers
    ;
.RenderCurrentCells
    load    rc,#.CellArrays         ; cells array base address
    load    r1,.CurrentOffset       ;
    add     rc,r1,r0                ; RC = address of current array in .CellArrays
                                    ;
    load    r8,#0000                ; bitmap I/O: X position
    load    r9,#0001                ; bitmap I/O: Y position
    load    ra,#0002                ; bitmap I/O: pixel RGB colour
                                    ;
    load    r1,#1                   ; constant 1
    load    r2,#80                  ; constant 128
    load    r3,#FFFF                ; constant RGB white (alive)
                                    ;
    load    r7,#0                   ; Y coord (top-most row)
.nextRow
    load    r6,#0                   ; X coord (left-most column)
                                    ;
.nextColumn
    or      r5,r0,r0                ; R5 = presume dead cell (RGB black)
    load    r4,*rc                  ; get the cell: 0 = dead, non-zero = alive
    jumpeq  r4,r0,.drawCell         ;
    or      r5,r3,r3                ; R5 = cell is alive (RGB white)
.drawCell
    writeio r6,r8                   ; X position
    writeio r7,r9                   ; Y position
    writeio r5,ra                   ; RGB color
                                    ;
    add     rc,r1,r0                ; next cell
                                    ;
    add     r6,r1,r0                ; next X position
    jumplt  r6,r2,.nextColumn       ; keep going until done right-most column
                                    ;
    add     r7,r1,r0                ; next Y position
    jumplt  r7,r2,.nextRow          ; keep going until done bottom-most row
                                    ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Utility function.
    ; Entry RE = return address
    ; Uses  R1, R2, R3
    ; Exit  R2 = 16-bit random number
    ;
    ; Polynomial tap XOR followed by a right shift:
    ;
    ;         X <------------+
    ;   +---- O              |
    ;   |     R <-------+    |
    ;   |               |    |
    ;   +---> FEDCBA9876543210 --> Cy
    ;
    ; This method produces a very even spread. Out of 10 million
    ; iterations, and taking only the lower 8-bits, every number
    ; from 1 to 255 was generated just over 39000 times. Only the
    ; value 0 was generated less than this at 38451 times.
    ;
    ; Note that the seed must never be zero. The entire 16-bit number
    ; will never attain the value of zero. To get a value of zero it
    ; is necessary to use a mask of, for example, the lowest 8-bits.
    ;
.NextRandom
    load    r2,.RandomNumber        ;
    or      r3,r2,r0                ; also put into R4
                                    ;
    shiftr  r3,r0                   ;
    shiftr  r3,r0                   ;
    shiftr  r3,r0                   ;
    shiftr  r3,r0                   ;
    shiftr  r3,r0                   ;
    xor     r3,r3,r2                ; bit 5 XOR bit 0
    shiftr  r3,r3                   ; R3 = result is 0 or 1
                                    ;
    shiftr  r2,r0                   ;
    load    r1,#7FFF                ;
    and     r2,r2,r1                ; clear MSB of .RandomNumber
                                    ;
    add     r3,r1,r0                ;
    load    r1,#8000                ;
    and     r3,r3,r1                ; either 0 or &H8000
                                    ;
    or      r2,r2,r3                ; set new MSB
    store   r2,.RandomNumber        ;
                                    ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Utility function.
    ; Wait for any pressed buttons to be released.
    ; Entry RE = return address
    ; Uses  R1, R2
    ;
.WaitButtonsRelease
    load    r2,#0010                ; I/O address of push buttons
.waitBR
    readio  r1,r2                   ; R1 = bitmap of pushbuttons
    jumpne  r1,r0,.waitBR           ; wait for all buttons to be released
    jump    re                      ; return

    ; -----------------------------------------
    ; Utility function.
    ; Entry RE = return address
    ; Uses  R2
    ;
.TurnOnRunLED
    load    r2,#0020                ; I/O address of LEDs
    load    r1,#0080                ; only turn LED #7 on
    writeio r1,r2                   ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Utility function.
    ; On entry RE = return address
    ; Uses  R2
    ;
.TurnOffRunLED
    load    r2,#0020                ; I/O address of LEDs
    writeio r0,r2                   ; turn all LEDs off
    jump    re                      ; return

    ; -----------------------------------------
    ; Utility function.
    ; On entry RE = return address
    ; Uses  R1, R2, R3
    ;
.SynchronizeToTick
    load    r3,#0030                ; I/O address of 50 ms tick count
    readio  r1,r3                   ; current value
.syncTick
    readio  r2,r3                   ; new value
    jumpeq  r1,r2,.syncTick         ; only care about when it changes
    jump    re                      ; return

    ; -----------------------------------------
    ; Generate a preset population of cells.
    ; Centered in bitmap display.
    ; Entry RC = address of preset data
    ;
.DrawPreset
    load    re,#.presetDo           ;
    jump    .WaitButtonsRelease     ;
                                    ;
.presetDo
    load    r1,#1                   ; constant 1
                                    ;
    load    r2,#.CellArrays         ;
    load    r3,#4000                ; size of 128x128 array
.clearForPreset
    store   r0,*r2                  ;
    add     r2,r1,r0                ;
    sub     r3,r1,r0                ;
    jumpne  r3,r0,.clearForPreset   ;
                                    ;
    load    r2,#.CellArrays         ;
                                    ;
    load    r3,*rb                  ; get centering offset
    add     r2,r3,r0                ; cells array pointer
    add     rb,r1,r0                ;
                                    ;
    load    r3,*rb                  ; get number of rows
    add     rb,r1,r0                ;
                                    ;
    load    r4,*rb                  ; get number of columns
    add     rb,r1,r0                ;
                                    ;
.nextPresetRow
    or      r6,r2,r2                ; working copy of cells array pointer
    or      r5,r4,r4                ; working copy of number of columns
                                    ;
.nextPresetCol
    load    r7,*rb                  ;
    store   r7,*r6                  ;
                                    ;
    add     rb,r1,r0                ; next preset cell
    add     r6,r1,r0                ; next current array cell
                                    ;
    sub     r5,r1,r0                ;
    jumpne  r5,r0,.nextPresetCol    ;
                                    ;
    load    r5,#80                  ; next row
    add     r2,r5,r0                ;
                                    ;
    sub     r3,r1,r0                ; another preset cell has been done
    jumpne  r3,r0,.nextPresetRow    ;
                                    ;
    store   r0,.CurrentOffset       ; offset of current array in .CellArrays
    load    re,#.Mainloop           ;
    jump    .RenderCurrentCells     ; finally, draw the result

    ; -----------------------------------------
    ; "R-pentomino"
    ; 3x3 grid, in the center of the bitmap display:
    ;   -oo
    ;   oo-
    ;   -o-
    ;
.RpentominoCells
    dw      1FBF                    ; centering offset with current array
    dw      3                       ; number of rows
    dw      3                       ; number of columns, for all rows
    dw      0                       ; row 1
    dw      1                       ;
    dw      1                       ;
    dw      1                       ; row 2
    dw      1                       ;
    dw      0                       ;
    dw      0                       ; row 3
    dw      1                       ;
    dw      0                       ;

    ; -----------------------------------------
    ; "Diehard"
    ; 8x3 grid, in the center of the bitmap display:
    ;   ------o-
    ;   oo------
    ;   -o---ooo
    ;
.DiehardCells
    dw      1FBC                    ; centering offset with current array
    dw      3                       ; number of rows
    dw      8                       ; number of columns, for all rows
    dw      0                       ; row 1
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      1                       ;
    dw      0                       ;
    dw      1                       ; row 2
    dw      1                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ; row 3
    dw      1                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      1                       ;
    dw      1                       ;
    dw      1                       ;

    ; -----------------------------------------
    ; "Acorn"
    ; 7x3 grid, in the center of the bitmap display:
    ;   -o-----
    ;   ---o---
    ;   oo--ooo
    ;
.AcornCells
    dw      1FBD                    ; centering offset with current array
    dw      3                       ; number of rows
    dw      7                       ; number of columns, for all rows
    dw      0                       ; row 1
    dw      1                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ; row 2
    dw      0                       ;
    dw      0                       ;
    dw      1                       ;
    dw      0                       ;
    dw      0                       ;
    dw      0                       ;
    dw      1                       ; row 3
    dw      1                       ;
    dw      0                       ;
    dw      0                       ;
    dw      1                       ;
    dw      1                       ;
    dw      1                       ;

    ; -----------------------------------------
    ; Variables

.RandomNumber
    dw      AA55                    ; initial seed (at program load)

.CurrentOffset
    ds      1                       ; offset into .CellArrays of current

.NextOffset
    ds      1                       ; offset into .CellArrays of next

.CellArrays
    ds      4000                    ; current array of * 128x128 cells
    ds      4000                    ; next array of * 128x128 cells

    ; END
