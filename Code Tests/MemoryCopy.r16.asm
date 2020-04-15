; Test of memory copy

.TestMemCopy
    load    R1,#.TestSource         ; 0000 Test #1, source overlaps destination
    load    R2,#.TestDestination    ; 0002
    load    R3,#10                  ; 0004 16 words
    load    RE,#.TestReturn1        ; 0006
    jump    .MemCopy                ; 0008
.TestReturn1
                                    ;
    load    R1,#.TestDestination    ; 000A Test #2, swap the source and dest
    load    R2,#.TestSource         ; 000C Source does not overlap destination
    load    R3,#10                  ; 000E 16 words
    load    RE,#.TestReturn2        ; 0010
    jump    .MemCopy                ; 0012
.TestReturn2
                                    ;
    jump    .TestMemCopy            ; 0014 Do the tests forever
                                    ;
.TestSource; <- Test #2, source read start
    and     R0,R0,R0                 ; 0016 First 4 words of source
    and     R0,R0,R1                 ; 0017
    and     R0,R0,R2                 ; 0018
    and     R0,R0,R3                 ; 0019
.TestDestination; <- Test #2, destination write start
    and     R0,R0,R4                 ; 001A First 12 words of destination
    and     R0,R0,R5                 ; 001B And last 12 words of source
    and     R0,R0,R6                 ; 001C
    and     R0,R0,R7                 ; 001D
    and     R0,R0,R8                 ; 001E
    and     R0,R0,R9                 ; 001F
    and     R0,R0,RA                 ; 0020
    and     R0,R0,RB                 ; 0021
    and     R0,R0,RC                 ; 0022
    and     R0,R0,RD                 ; 0023
    and     R0,R0,RE                 ; 0024
    and     R0,R0,RF                 ; 0025 <- Test #1, source read start
.BufferRemainder
    and     R0,R0,R0                 ; 0026 Final 4 words of 16-word destination
    and     R0,R0,R0                 ; 0027
    and     R0,R0,R0                 ; 0028
    and     R0,R0,R0                 ; 0029 <- Test #1, destination write start


; Memory Copy
; In    R1 = Source
;       R2 = Destination
;       R3 = Length (in 16-bit words)
;       RE = Return address
; Out   R1 = ?
;       R2 = ?
;       R3 = 0
; Uses  R4 = ?
;       R5 = ?

.MemCopy
    jumpeq  R3,R0,.FinishedCopy     ; 002A Copying zero words?
                                    ;
    or      R4,R1,R0                ; 002C R4 <- R1
    add     R4,R3,R0                ; 002D R4 <- Source + Length
    jumplt  R4,R2,.NotOverlap       ; 002E R4 < R2, Source is fully before destination
    jumpeq  R4,R2,.NotOverlap       ; 0030 R4 = R2, Source is fully before destination
                                    ;
    or      R5,R2,R0                ; 0032 R5 <- R2
    add     R5,R3,R0                ; 0033 R5 <- Destination + Length
    jumpgt  R4,R5,.NotOverlap       ; 0034 R4 > R5, Source is fully after destination
    jumpeq  R4,R5,.NotOverlap       ; 0036 R4 = R5, Source is fully after destination
                                    ;
.IsOverlap
    load    R2,#1                   ; 0038 Constant one value
.ReverseCopy
    sub     R4,R2,R0                ; 003A Next source
    sub     R5,R2,R0                ; 003B Next destination
    load    R1,*R4                  ; 003C R4 = Address of last Source word
    store   R1,*R5                  ; 003D R5 = Address of last Destination word
    sub     R3,R2,R0                ; 003E Count another word copied
    jumpne  R3,R0,.ReverseCopy      ; 003F
.FinishedCopy
    jump    RE                      ; 0041 Return, RF (program address) <- RE
                                    ;
.NotOverlap
    load    R5,#1                   ; 0042 Constant one value
.ForwardCopy
    load    R4,*R1                  ; 0044 R1 = Address of first Source word
    store   R4,*R2                  ; 0045 R2 = Address of first Destination word
    add     R1,R5,R0                ; 0046 Next source
    add     R2,R5,R0                ; 0047 Next destination
    sub     R3,R5,R0                ; 0048 Count another word copied
    jumpne  R3,R0,.ForwardCopy      ; 0049
    jump    RE                      ; 004B Return
;004C (end)




