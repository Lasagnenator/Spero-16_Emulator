;LED test
;R1 is 1
;R2 is 20 (address of led io)
;R3 is the shifting value

load R1,#1
load R2,#20

.start
load R3,#780 ;Pattern

.loop
writeio R3,R2 ;Send R3 to LEDs
shiftr  R3,R0 ;Don't need the shift out
jumpne  R3,R0,.loop
jump    .start