; The `-->` is not needed for comments. I am using it to show translation
load    R1,#5     ;--> 0100 0005
load    Rc,3efc   ;--> 1C00 3efc

load    R4 , *R5  ;--> 2450

store   R0,3efc   ;--> 3000 3efc (Always writes zero as R0 is always zero)
.start
store   R1,*R2    ;--> 4120
add     R7,R8,R9  ;--> 5789
sub     R7,R8,R9  ;--> 6789
and     R7,R8,R9  ;--> 7789
or      R7,R8,R9  ;--> 8789
shiftr  Ra,Rc     ;--> 9A0C
readio  Rb,R7     ;--> EB70
writeio Rb,R7     ;--> FB70

jump    .end      ;--> A000 0020 (forward reference)
jumplt  R0,R4,3efc;--> A041 3efc
jumpgt  R1,R5,3efc;--> A152 3efc
jumpeq  R2,R6,3efc;--> A263 3efc
jumpnv  R2,R6,3efc;--> A264 3efc (Basically a no-op)
jumpbl  R3,R7,3efc;--> A375 3efc
jumpab  R4,R8,3efc;--> A486 3efc
jumpne  R5,R9,.start;--> A597 0007
jump    Rf       ;--> BF00 (This jumps to itself as Rf = program counter)

.end
jump    3         ;--> A000 0003 (This actually jumps to erroneous data)
jump    .start    ;--> A000 0007 (backward reference)

load    R4,.end   ;--> 1400 0020
store   R5,.end   ;--> 3500 0020