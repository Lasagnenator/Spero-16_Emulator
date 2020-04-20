;fills the whole screen then clear and repeat
;R1 is 1
;R2 is 2
;R3 is x
;R4 is y
;R5 is colour
;R6 is 128


load R1,#1
load R2,#2
load R6,#80 ;128 in hex

.start
load R3,#0
load R4,#0
load R5,#0 ;black

.loop
writeio R3,R0
writeio R4,R1
writeio R5,R2

add     R3,R1,R0
jumpne  R3,R6,.loop
;increment y and reset x
load    r3,#0
add     R4,R1,R0
jumpne  R4,R6,.loop
;change colour

jumpne  R5,R0,.start ;reset if not black
load    R5,#ffff ;white
load    R4,#0 ;no need to reset x as it's already done
jump    .loop

