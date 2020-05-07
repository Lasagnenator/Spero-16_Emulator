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
; This is the standard Game of Life, symbolized as B3/S23.
;
; This implementation uses two 2D grids: a current and a next.
; Every cell is inspected every update, regardless. There are no
; algorithm optimizations applied to speed things up.
;
; The world is a flat 2D 128x128 pixel grid, mapped to a torus.
; Each grid element is a 16-bit word. A dead cell has the value 0,
; while an alive cell has a non-zero value (implemented using 1).
;
; User controls
;   Button 0: Randomize the 128x128 cell grid
;          1: Preset "R-pentomino"
;          2: Preset "Diehard"
;          3: Preset "Acorn"
;          4: Preset "Kaleidoscope"
;          5: Preset "Gosper Glider Gun"
;          6: Preset "60P5H2V0 spaceship"
;          7: Run the 128x128 cell grid, press again to stop
;      LED 0: When lit, game is running
;
; Internally, the buttons are "momentary push" but are implemented
; using checkboxes. The checkboxes are ticked to indicate "pressed"
; and must then be unchecked to indicate "released".
;
; Fixed register allocation:
;   RF = program counter
;   RE = link register
;   RD = second link register
;   R0 = always zero

    ; Execution always begins at address &H0000
.Start
    jump    .Initialize

    ; -----------------------------------------
    ; Initial pseudo-RNG seed (at program load).
    ; The RNG is implemented using a polynominal counter.
    ; Do not seed with &H0000, as that is the error state.
    ;
    ; If "random populate" is performed and it is wished to replay that
    ; specific game again then take note of the value in .SavedRandomSeed
    ; before stopping the current run. Next, manually type the seed value
    ; over the '0000' field of the DW (define data word) pseudo-op. Save
    ; this source file, re-assemble, reload and then re-run.

.RandomSeed
    dw      AA55                    ; any value except &H0000

.SavedRandomSeed
    dw      0000                    ; seed at time of "random populate"

    ; -----------------------------------------
    ; Cell colors.
    ;
    ; Blue  Green    Red    MSB     ...     LSB     Hex
    ; 00000_000000_00000    0000_0000_0000_0000     0000    Black
    ; 00000_000000_01111    0000_0000_0000_1111     000F    Dark Red
    ; 00000_000000_11111    0000_0000_0001_1111     001F    Full Red
    ; 00000_011111_00000    0000_0011_1110_0000     03E0    Dark Green
    ; 00000_111111_00000    0000_0111_1110_0000     07E0    Full Green
    ; 01111_000000_00000    0111_1000_0000_0000     7800    Dark Blue
    ; 11111_000000_00000    1111_1000_0000_0000     F800    Full Blue
    ; 11111_111111_11111    1111_1111_1111_1111     1111    White
    ;
    ;   Dark Red     &H000F, Full Red     &H001F
    ;        Brown   &H29ED,      Orange  &H03FF
    ;   Dark Yellow  &H03EF, Full Yellow  &H07FF
    ;   Dark Green   &H03E0, Full Green   &H07E0
    ;   Dark Cyan    &H7BE0, Full Cyan    &HFFE0
    ;   Dark Blue    &H7800, Full Blue    &HF800
    ;   Dark Magenta &H780F, Full Magenta &HF81F
    ;
    ; Note that brown is a relative color. It must always occur in
    ; context with a background, such as yellow or orange, to be seen.

.AliveRGBColor
    dw      0000                    ; black

.DeadRGBColor
    dw      FFFF                    ; white

    ; -----------------------------------------
    ; One time initialization, performed at power on.
    ;
.Initialize
    load    re,#.initClearDone      ;
    jump    .ClearCellArrays        ;
.initClearDone
    load    re,#.initSeeding        ;
    store   r0,.CurrentOffset       ; select .CellArrays[current]
    jump    .RenderCurrentCells     ; draw the empty world
                                    ;
.initSeeding
    load    r1,.SavedRandomSeed     ; have a game to replay?
    jumpeq  r1,r0,.initNewGame      ;
                                    ;
    store   r1,.RandomNumber        ; use the saved seed
    load    re,#.Mainloop           ; immediately display the configuration
    jump    .RandomPopulate         ;
                                    ;
.initNewGame
    load    r1,.RandomSeed          ;
    store   r1,.RandomNumber        ;
    jump    .Mainloop               ;

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
    load    r2,#0010                ; button #4 "Kaleidoscope" preset
    jumpeq  r1,r2,.PresetKaleido    ; pressed?
                                    ;
    load    r2,#0020                ; button #5 "Gosper Gun" preset
    jumpeq  r1,r2,.PresetGosperGun  ; pressed?
                                    ;
    load    r2,#0040                ; button #6 "60P5H2V0 spaceship" preset
    jumpeq  r1,r2,.PresetSpaceship  ; pressed?
                                    ;
    load    r2,#0080                ; button #7 "Run/Stop"
    jumpeq  r1,r2,.RunGameOfLife    ; pressed?
                                    ;
    jump    .Mainloop               ; do it forever

    ; -----------------------------------------
    ; Generate a random population of cells.
    ; Called from and returns directly to .Mainloop
    ;
.RandomPopulate
    load    re,#.randomClear        ;
    jump    .WaitButtonsRelease     ;
                                    ;
.randomClear
    load    re,#.randomDo           ;
    jump    .ClearCellArrays        ;
                                    ;
.randomDo
    load    r1,.RandomNumber        ; retain current seed for replay of game
    store   r1,.SavedRandomSeed     ;
                                    ;
    store   r0,.CurrentOffset       ; select .CellArrays[current]
    load    r4,#.CellArrays         ; base address of .CellArrays[current]
    load    r1,#1020                ;
    add     r4,r1,r0                ; centered 64x64
                                    ;
    load    r7,#1                   ; constant 1
    load    r8,#80                  ; world has 128 cells across
                                    ;
    load    rc,#3F                  ; magic parameters that help generate
    load    r5,#D                   ; a "random" pattern that looks random
    load    r6,#3                   ;
                                    ;
    load    rb,#40                  ; draw for 64 cells down
                                    ;
.randomNextRow
    load    ra,#40                  ; draw for 64 cells across
                                    ;
    or      r9,r4,r4                ; working copy of .CellArrays[current] pointer
    add     r4,r8,r0                ; next row down
                                    ;
.randomNextCol
    load    re,#.randomizeCell      ;
    jump    .NextRandom             ; R2 = 16-bit pseudo-random number
                                    ;
.randomizeCell
    and     r2,r2,rc                ;
.randomMagic
    jumplt  r2,r5,.randomSetCell    ; apply magic factors for "better random"
    sub     r2,r5,r0                ;
    jump    .randomMagic            ;
                                    ;
.randomSetCell
    sub     r2,r6,r1                ; R1 = borrow: 0 (dead) or 1 (alive)
    store   r1,*r9                  ;
                                    ;
    add     r9,r7,r0                ; next cell across
    sub     ra,r7,r0                ;
    jumpne  ra,r0,.randomNextCol    ;
                                    ;
    sub     rb,r7,r0                ; next row down
    jumpne  rb,r0,.randomNextRow    ;
                                    ;
    load    re,#.Mainloop           ;
    jump    .RenderCurrentCells     ; finally, draw the result

    ; -----------------------------------------
    ; Initialize the cells array with presets.
    ; Each is called from and returns directly to .Mainloop
    ;
.PresetRpentomino
    load    rc,#.RpentominoCells    ; The "R-pentomino".
    jump    .DrawPreset             ;

.PresetDiehard
    load    rc,#.DieHardCells       ; The "diehard".
    jump    .DrawPreset             ;

.PresetAcorn
    load    rc,#.AcornCells         ; The "acorn".
    jump    .DrawPreset             ;

.PresetKaleido
    load    rc,#.KaleidoscopeCells  ; The "kaleidoscope".
    jump    .DrawPreset             ;

.PresetGosperGun
    load    rc,#.GosperGunCells     ; The "Gosper gun".
    jump    .DrawPreset             ;

.PresetSpaceship
    load    rc,#.SpaceshipCells     ; The "60P5H2V0 spaceship".
    jump    .DrawPreset             ;

    ; -----------------------------------------
    ; Run the "Game of Life".
    ; Continues until the "Run/Stop" button is pressed.
    ; Called from and returns directly to .Mainloop
    ;
.RunGameOfLife
    store   r0,.CurrentOffset       ; configure .CellArrays[current]
                                    ;
    load    r1,#4000                ; size of 128x128 array
    store   r1,.NextOffset          ; configure .CellArrays[next]
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
;; flat-out with no sync looks better
;;    load    re,#.returnFromSTT      ;
;;    jump    .SynchronizeToTick      ; aiming for 20 Hz refresh rate
;;.returnFromSTT
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
    ;
    ; Entry RE = return address
    ; Uses  All registers
    ;
.MakeNextCells
    load    r1,#.CellArrays         ; cells array base address
    load    rc,#3FFF                ; relative offset into .CellArrays[current]
                                    ;
    load    rb,.CurrentOffset       ;
    add     rb,r1,r0                ; base address of .CellArrays[current]
                                    ;
    load    ra,.NextOffset          ;
    add     ra,r1,r0                ;
    add     ra,rc,r0                ; starting address within .CellArrays[next]
                                    ;
    load    r1,#1                   ; constant 1
    load    r7,#3F80                ; world array Y mask, upper 7-bits
    load    r8,#007F                ; world array X mask, lower 7-bits
                                    ;
.doNextCell
    load    rd,#.updateCell         ;
    jump    .CountCellNeighbours    ; R4 = count of alive neighbours (0..8)
                                    ;
.updateCell
    or      r2,r0,r0                ; R2 = 0, presume that cell will die
                                    ;
    load    r9,#2                   ; minimum number of neighbours
    jumplt  r4,r9,.setCell          ; not enough neighbours: die
                                    ;
    load    r9,#3                   ; maximum number of neighbours
    jumpgt  r4,r9,.setCell          ; too many neighbours: die
    jumpne  r4,r9,.cellNoChange     ; not exactly max neighbours: no change
                                    ;
    or      r2,r1,r1                ; R2 = 1, cell is to be born
    jump    .setCell                ; if there is already a live cell in this array
                                    ; position then it will simply be "born" again
.cellNoChange
    or      r4,rc,rc                ;
    add     r4,rb,r0                ; R4 = address into .CellArrays[current]
    load    r2,*r4                  ; get whatever the cell status currently is
                                    ;
.setCell
    store   r2,*ra                  ; zero = dead, non-zero = alive
    sub     ra,r1,r0                ; advance backwards through .CellArrays[next]
                                    ;
    sub     rc,r1,r0                ; advance backwards through .CellArrays[current]
    jumpgt  rc,r0,.doNextCell       ; loop until all cells are updated
    jumpeq  rc,r0,.doNextCell       ;
                                    ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Returns how many live neighbours a cell has.
    ; A cell can have at most 8 neighbours.
    ;
    ; Entry RD = return address
    ;       RC = relative offset into .CellArrays[current]
    ;       RB = base address of .CellArrays[current]
    ;       R7 = world array Y position upper 7-bits mask
    ;       R8 = world array X position upper 7-bits mask
    ;       R1 = constant 1
    ; Uses  R2, R3, R5, R6
    ; Exit  R4 = count of alive neighbours (0..8)
    ;
.CountCellNeighbours
    load    r2,#.cellOffsets        ; pointer
    load    r3,#8                   ; number of neighbouring cells to examine
    load    r4,#0                   ; number of alive neighbours
                                    ;
.getNeighbour
    load    r5,*r2                  ; Y offset (-1, 0, +1)
    add     r2,r1,r0                ; 7-bits in bit positions 13..8
    add     r5,rc,r0                ;
    and     r5,r5,r7                ;
                                    ;
    load    r6,*r2                  ; X offset (-1, 0, +1)
    add     r2,r1,r0                ; 7-bits in bit positions 7..0
    add     r6,rc,r0                ;
    and     r6,r6,r8                ;
                                    ;
    or      r5,r5,r6                ; construct relative offset to neighbour
    add     r5,rb,r0                ; R5 = address into current array memory
                                    ;
    load    r5,*r5                  ; get the cell: 0 = dead, non-zero = alive
    jumpeq  r5,r0,.nextNeighbour    ;
    add     r4,r1,r0                ; count another alive neighbour
                                    ;
.nextNeighbour
    sub     r3,r1,r0                ;
    jumpne  r3,r0,.getNeighbour     ; loop until all 8 neighbours are checked
                                    ;
    jump    rd                      ; return

.cellOffsets
    dw      3F80                    ; upper  (-1)
    dw      007F                    ; left   (-1)
                                    ;
    dw      3F80                    ; upper  (-1)
    dw      0000                    ; center ( 0)
                                    ;
    dw      3F80                    ; upper  (-1)
    dw      0001                    ; right  (+1)
                                    ;
    dw      0000                    ; center ( 0)
    dw      007F                    ; left   (-1)
                                    ;
    dw      0000                    ; center ( 0)
    dw      0001                    ; right  (+1)
                                    ;
    dw      0080                    ; lower  (+1)
    dw      007F                    ; left   (-1)
                                    ;
    dw      0080                    ; lower  (+1)
    dw      0000                    ; center ( 0)
                                    ;
    dw      0080                    ; lower  (+1)
    dw      0001                    ; right  (+1)

    ; -----------------------------------------
    ; Double buffer the cells so that all updates are synchronous.
    ;
    ; Entry RE = return address
    ; Uses  R1, R2
    ;
.SwapCellBuffers
    load    r1,.CurrentOffset       ;
    store   r1,.NextOffset          ; next = current
                                    ;
    load    r2,#4000                ; size of 128x128 array
    xor     r1,r1,r2                ; swap current with next
    store   r1,.CurrentOffset       ;
                                    ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Draw the newest generation of cells to the bitmap display.
    ; The bitmap display itself is B5:G6:R5 color per pixel.
    ; However, the world is monochrome.
    ;
    ; Entry RE = return address
    ; Uses  All registers
    ;
.RenderCurrentCells
    load    rc,#.CellArrays         ; cells array base address
    load    r1,.CurrentOffset       ;
    add     rc,r1,r0                ; RC = base address of .CellArrays[current]
                                    ;
    load    r8,#0000                ; bitmap I/O: X position
    load    r9,#0001                ; bitmap I/O: Y position
    load    ra,#0002                ; bitmap I/O: pixel RGB colour
                                    ;
    load    r3,.AliveRGBColor       ; RGB color for alive cell
    load    rb,.DeadRGBColor        ; RGB color for dead cell
                                    ;
    load    r1,#1                   ; constant 1
    load    r2,#80                  ; constant 128
                                    ;
    load    r7,#0                   ; Y coord (top-most row)
.nextRow
    load    r6,#0                   ; X coord (left-most column)
                                    ;
.nextColumn
    or      r5,rb,rb                ; R5 = presume dead cell
    load    r4,*rc                  ; get the cell: 0 = dead, non-zero = alive
    jumpeq  r4,r0,.drawCell         ;
    or      r5,r3,r3                ; R5 = cell is alive
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
    ; Generates and returns a 16-bit pseudo-random number.
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
    ; Entry RE = return address
    ; Uses  R1, R2, R3
    ; Exit  R2 = 16-bit random number
    ;
.NextRandom
    load    r2,.RandomNumber        ;
                                    ;
    or      r3,r2,r0                ; shift bit 5 into the bit 0 position
    shiftr  r3,r0                   ;
    shiftr  r3,r0                   ;
    shiftr  r3,r0                   ;
    shiftr  r3,r0                   ;
    shiftr  r3,r0                   ;
                                    ;
    xor     r3,r3,r2                ; essentially perform bit 5 XOR bit 0
    shiftr  r3,r3                   ; R3 = result is 0 or 1
                                    ;
    shiftr  r2,r0                   ;
    load    r1,#7FFF                ;
    and     r2,r2,r1                ; clear MSB of .RandomNumber
                                    ;
    add     r3,r1,r0                ; convert the 0 and 1 result
    load    r1,#8000                ; so that R3 = &H0000 or &H8000, respectively
    and     r3,r3,r1                ;
                                    ;
    or      r2,r2,r3                ; set new MSB from XOR of bits 5 and 0
    store   r2,.RandomNumber        ; save as seed for next generation
                                    ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Utility function.
    ; Wait for any pressed buttons to be released.
    ;
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
    ;
    ; Entry RE = return address
    ; Uses  R1, R2
    ;
.TurnOnRunLED
    load    r2,#0020                ; I/O address of LEDs
    load    r1,#0001                ; only turn LED #0 on
    writeio r1,r2                   ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Utility function.
    ;
    ; Entry RE = return address
    ; Uses  R2
    ;
.TurnOffRunLED
    load    r2,#0020                ; I/O address of LEDs
    writeio r0,r2                   ; turn all LEDs off
    jump    re                      ; return

    ; -----------------------------------------
    ; Utility function.
    ; Used for smooth consistent display updating.
    ;
    ; Entry RE = return address
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
    ; Utility function.
    ; Set all cell arrays to zero (dead cells).
    ;
    ; Entry RE = return address
    ; Uses  R1, R2, R3
    ;
.ClearCellArrays
    load    r1,#1                   ; constant 1
    load    r2,#.CellArrays         ;
    load    r3,#8000                ; size of 2 contiguous 128x128 arrays
                                    ;
.clearLoop
    store   r0,*r2                  ;
    add     r2,r1,r0                ;
    sub     r3,r1,r0                ;
    jumpne  r3,r0,.clearLoop        ;
                                    ;
    jump    re                      ; return

    ; -----------------------------------------
    ; Generate a preset population of cells.
    ; Centered in bitmap display.
    ;
    ; Entry RC = address of preset data
    ; Uses  All registers
    ; Called from and returns directly to .Mainloop
    ;
.DrawPreset
    load    re,#.presetClear        ;
    jump    .WaitButtonsRelease     ;
                                    ;
.presetClear
    load    re,#.presetDo           ;
    jump    .ClearCellArrays        ;
                                    ;
.presetDo
    load    r1,#1                   ; constant 1
                                    ;
    store   r0,.CurrentOffset       ; select .CellArrays[current]
    load    r2,#.CellArrays         ; draw into .CellArrays[current]
                                    ;
    load    r3,*rc                  ; get centering offset
    add     r2,r3,r0                ; cells array pointer
    add     rc,r1,r0                ;
                                    ;
    load    r3,*rc                  ; get number of rows
    add     rc,r1,r0                ;
                                    ;
    load    r4,*rc                  ; get number of columns of 16-bits
    add     rc,r1,r0                ;
                                    ;
.nextPresetRow
    or      r6,r2,r2                ; working copy of cells array pointer
    or      r5,r4,r4                ; working copy of number of columns of 16-bits
                                    ;
.nextPresetCol
    load    r7,*rc                  ;
    add     rc,r1,r0                ;
                                    ;
    load    r9,#10                  ; 16 bits = 16 cells
.nextPresetBit
    or      r8,r0,r0                ;
    add     r7,r7,r8                ; shift the bit pattern left and from the
    store   r8,*r6                  ; MSB set the cell status (0 = dead cell, 1= alive)
    add     r6,r1,r0                ; next array cell
    sub     r9,r1,r0                ;
    jumpne  r9,r0,.nextPresetBit    ;
                                    ;
    sub     r5,r1,r0                ; next column of 16-bits
    jumpne  r5,r0,.nextPresetCol    ;
                                    ;
    load    r5,#80                  ; next row (128 cells per row)
    add     r2,r5,r0                ;
                                    ;
    sub     r3,r1,r0                ;
    jumpne  r3,r0,.nextPresetRow    ;
                                    ;
    load    re,#.Mainloop           ;
    jump    .RenderCurrentCells     ; finally, draw the result

    ; -----------------------------------------
    ; "R-pentomino"
    ; 3x3 grid, in the center of the bitmap display:
    ;
    ; Pattern   Bits 15 --> 0           Hex
    ;   -oo     0110_0000_0000_0000     &H6000
    ;   oo-     1100_0000_0000_0000     &HC000
    ;   -o-     0100_0000_0000_0000     &H4000
    ;
.RpentominoCells
    dw      1FBF                    ; centering offset within .CellArrays[current]
    dw      3                       ; number of rows
    dw      1                       ; number of 16-bit columns, for all rows
    dw      6000                    ; row 1
    dw      C000                    ; row 2
    dw      4000                    ; row 3

    ; -----------------------------------------
    ; "Diehard"
    ; 8x3 grid, in the center of the bitmap display:
    ;
    ;   ------o-    0000_0010_0000_0000     &H0200
    ;   oo------    1100_0000_0000_0000     &HC000
    ;   -o---ooo    0100_0111_0000_0000     &H4700
    ;
.DiehardCells
    dw      1FBC                    ; centering offset within .CellArrays[current]
    dw      3                       ; number of rows
    dw      1                       ; number of 16-bit columns, for all rows
    dw      0200                    ; row 1
    dw      C000                    ; row 2
    dw      4700                    ; row 3

    ; -----------------------------------------
    ; "Acorn"
    ; 7x3 grid, in the center of the bitmap display:
    ;
    ;   -o-----     0100_0000_0000_0000     &H4000
    ;   ---o---     0001_0000_0000_0000     &H1000
    ;   oo--ooo     1100_1110_0000_0000     &HCE00
    ;
.AcornCells
    dw      1FBD                    ; centering offset with current array
    dw      3                       ; number of rows
    dw      1                       ; number of 16-bit columns, for all rows
    dw      4000                    ; row 1
    dw      1000                    ; row 2
    dw      CE00                    ; row 3

    ; -----------------------------------------
    ; "Kaleidoscope"
    ; 126x1 grid, in the center of the bitmap display:
    ;
.KaleidoscopeCells
    dw      2000                    ; centering offset within .CellArrays[current]
    dw      1                       ; number of rows
    dw      8                       ; number of 16-bit columns, for all rows
    dw      7FFF                    ; row 1
    dw      FFFF                    ;
    dw      FFFF                    ;
    dw      FFFF                    ;
    dw      FFFF                    ;
    dw      FFFF                    ;
    dw      FFFF                    ;
    dw      FFFE                    ;

    ; -----------------------------------------
    ; "Gosper Glider Gun"
    ; 36x9 grid, in the center of the bitmap display:
    ;
    ;   ------------------------o-----------
    ;   ----------------------o-o-----------
    ;   ------------oo------oo------------oo
    ;   -----------o---o----oo------------oo
    ;   oo--------o-----o---oo--------------
    ;   oo--------o---o-oo----o-o-----------
    ;   ----------o-----o-------o-----------
    ;   -----------o---o--------------------
    ;   ------------oo----------------------
    ;
    ;   0000_0000_0000_0000  0000_0000_1000_0000  0000_0000_0000_0000       &H0000 &H0080 &H0000
    ;   0000_0000_0000_0000  0000_0010_1000_0000  0000_0000_0000_0000       &H0000 &H0280 &H0000
    ;   0000_0000_0000_1100  0000_1100_0000_0000  0011_0000_0000_0000       &H000C &H0C00 &H3000
    ;   0000_0000_0001_0001  0000_1100_0000_0000  0011_0000_0000_0000       &H0011 &H0C00 &H3000
    ;   1100_0000_0010_0000  1000_1100_0000_0000  0000_0000_0000_0000       &HC020 &H8C00 &H0000
    ;   1100_0000_0010_0010  1100_0010_1000_0000  0000_0000_0000_0000       &HC022 &HC280 &H0000
    ;   0000_0000_0010_0000  1000_0000_1000_0000  0000_0000_0000_0000       &H0020 &H8080 &H0000
    ;   0000_0000_0001_0001  0000_0000_0000_0000  0000_0000_0000_0000       &H0011 &H0000 &H0000
    ;   0000_0000_0000_1100  0000_0000_0000_0000  0000_0000_0000_0000       &H000C &H0000 &H0000
    ;
.GosperGunCells
    dw      1BAE                    ; centering offset within .CellArrays[current]
    dw      9                       ; number of rows
    dw      3                       ; number of 16-bit columns, for all rows
    dw      0000                    ; row 1
    dw      0080                    ;
    dw      0000                    ;
    dw      0000                    ; row 2
    dw      0280                    ;
    dw      0000                    ;
    dw      000C                    ; row 3
    dw      0C00                    ;
    dw      3000                    ;
    dw      0011                    ; row 4
    dw      0C00                    ;
    dw      3000                    ;
    dw      C020                    ; row 5
    dw      8C00                    ;
    dw      0000                    ;
    dw      C022                    ; row 6
    dw      C280                    ;
    dw      0000                    ;
    dw      0020                    ; row 7
    dw      8080                    ;
    dw      0000                    ;
    dw      0011                    ; row 8
    dw      0000                    ;
    dw      0000                    ;
    dw      000C                    ; row 9
    dw      0000                    ;
    dw      0000                    ;

    ; -----------------------------------------
    ; "60P5H2V0 Spaceship"
    ; 11x21 grid, in the center of the bitmap display:
    ;
    ;   oo--o------     1100_1000_0000_0000     &HC800
    ;   -----o-----     0000_0100_0000_0000     &H0400
    ;   o----o-----     1000_0100_0000_0000     &H8400
    ;   --oo-o-----     0011_0100_0000_0000     &H3400
    ;   ---ooo-oo--     0001_1101_1000_0000     &H1D80
    ;   ----oooooo-     0000_1111_1100_0000     &H0FC0
    ;   ----oo----o     0000_1100_0010_0000     &H0C20
    ;   ----ooo-oo-     0000_1110_1100_0000     &H0EC0
    ;   o------oo--     1000_0001_1000_0000     &H8180
    ;   ooooooo----     1111_1110_0000_0000     &HFE00
    ;   -----------     0000_0000_0000_0000     &H0000
    ;   ooooooo----     1111_1110_0000_0000     &HFE00
    ;   o------oo--     1000_0001_1000_0000     &H8180
    ;   ----ooo-oo-     0000_1110_1100_0000     &H0EC0
    ;   ----oo----o     0000_1100_0010_0000     &H0C20
    ;   ----oooooo-     0000_1111_1100_0000     &H0FC0
    ;   ---ooo-oo--     0001_1101_1000_0000     &H1D80
    ;   --oo-o-----     0011_0100_0000_0000     &H3400
    ;   o----o-----     1000_0100_0000_0000     &H8400
    ;   -----o-----     0000_0100_0000_0000     &H0400
    ;   oo--o------     1100_1000_0000_0000     &HC800
    ;
.SpaceshipCells
    dw      1ABB                    ; centering offset within .CellArrays[current]
    dw      15                      ; number of rows
    dw      1                       ; number of 16-bit columns, for all rows
    dw      C800                    ; row 1
    dw      0400                    ; row 2
    dw      8400                    ; row 3
    dw      3400                    ; row 4
    dw      1D80                    ; row 5
    dw      0FC0                    ; row 6
    dw      0C20                    ; row 7
    dw      0EC0                    ; row 8
    dw      8180                    ; row 9
    dw      FE00                    ; row 10
    dw      0000                    ; row 11
    dw      FE00                    ; row 12
    dw      8180                    ; row 13
    dw      0EC0                    ; row 14
    dw      0C20                    ; row 15
    dw      0FC0                    ; row 16
    dw      1D80                    ; row 17
    dw      3400                    ; row 18
    dw      8400                    ; row 19
    dw      0400                    ; row 20
    dw      C800                    ; row 21

    ; -----------------------------------------
    ; Variables

.RandomNumber
    ds      1                       ; current random value (seed for next)

.CurrentOffset
    ds      1                       ; offset into .CellArrays, current generation

.NextOffset
    ds      1                       ; offset into .CellArrays, next generation

.CellArrays
    ds      4000                    ; current generation of 128x128 cells
    ds      4000                    ; next generation of 128x128 cells

    ; END
