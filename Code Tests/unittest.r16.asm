;This is a test of all instructions
;It should not produce erroneous data

load    R1,#1
load    R2,ffff  ;Is zero
load    R3,*R1   ;Should become one
add     R3,R1,R0 ;R3 should be 2

store   R3,1     ;Writes 2 to address 1
add     R3,R1,R0 ;R3 should be 3
store   R3,*R1   ;Writes 3 to address 1
sub     R3,R1,R0 ;R3 should be 2
and     R4,R3,R3 ;R4 should be 2
or      R5,R3,R3 ;R5 should be 2
sub     R5,R1,R0 ;R5 should be 1
shiftr  R5,R6    ;R5 should be 0, R6 should be 1

;These jump statements should all fail
jumplt  R3,R5,1024
jumpgt  R3,R3,0
jumpeq  R3,R5,0
jumpnv  R3,R3,2048
jumpbl  R3,R5,0
jumpab  R5,R3,0
jumpne  R3,R3,4096

;Testing unconditional jumps
load    R7,#.label1
jump    R7

.label1
jump    .end

.end
readio  R7,R0    ;r+w zero because no peripherals attached
writeio R7,R0

;Infinite jump loop so it basically stops.
jump    Rf