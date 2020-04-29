#RISC assembler
#Converts from assembly file to binary file
#
#

import sys #error displaying
failure = False #if at least one error present

#table of label, addr, references
label_table = dict()
#E.g. {".label" : 3f}

lineno = 1 #line numbers for error reporting.

class Line:
    lineno = -1 #line number in the input file
    pc = -1 #memory address of the start of this instruction
    noop = True #set to false if valid operation
    addr = "" #"" means unset. Any positive value is valid (0<=x<=65535)
    has_data = False #whether there is a 16 bit data on the end

    is_label = False
    has_reference = False

    is_ds = False

    bin_instruction = ""
    
    def __init__(self, string, lineno):
        self.string = string
        self.lineno = lineno
        #self.pc = pc
        self.Parse()

    def Parse(self):
        try: #removes any comments first
            string = self.string[:self.string.index(";")]
        except ValueError: #none found, so continue
            string = self.string

        string = string.upper() #make everything case insensitive

        if string.strip() == "": #empty line, do nothing
            self.noop = True
            return

        elif string[0] == ".": #label

            if string.count(" ")>0:
                raise RuntimeError("Label `{}` cannot have spaces in it!".format(self.string))
            
            self.noop = False
            self.is_label = True
            self.string = string
            return

        else: #split by space then remove cases with multiple spaces
            split = string.split(" ")
            try: #this block removes empty entries until none remain
                while True:
                    split.remove("")
            except ValueError:
                pass

        split = [split[0], "".join(split[1:])]

        #remove ALL whitespace in the rest of the instruction
        split[1] = split[1].translate(str.maketrans('', '', ' \n\t\r'))

        split[1] = split[1].split(",")
        
        if split[0] == "LOAD":
            Rn = hex(int(split[1][0][1], 16))[2:]
            if split[1][1][0] == "#": #immediate
                if split[1][1][1] == ".":
                    imm = split[1][1][1:]
                    self.has_data = True
                    self.has_reference = True
                    self.addr = imm
                    self.bin_instruction = "0{}00 {}".format(Rn, imm)
                else:
                    imm = hex(int(split[1][1][1:5], 16))[2:]
                    imm = imm.rjust(4, "0")
                    self.bin_instruction = "0{}00 {}".format(Rn, imm)
                    self.has_data = True
                
            elif split[1][1][0] == "*": #pointer
                Rm = hex(int(split[1][1][2], 16))[2:]
                self.bin_instruction = "2{}{}0".format(Rn, Rm)
                self.has_data = False

            elif split[1][1][0] == ".": #label
                self.bin_instruction = "1{}00 {}".format(Rn,split[1][1])
                self.addr = split[1][1]
                self.has_data = True
                self.has_reference = True
                
            else: #from address
                addr = hex(int(split[1][1][:4], 16))[2:]
                addr = addr.rjust(4, "0")
                self.bin_instruction = "1{}00 {}".format(Rn, addr)
                self.has_data = True
            self.noop = False
                
        elif split[0] == "STORE":
            Rn = hex(int(split[1][0][1], 16))[2:]
            if split[1][1][0] == "*": #pointer
                Rm = hex(int(split[1][1][2], 16))[2:]
                self.bin_instruction = "4{}{}0".format(Rn, Rm)
                self.has_data = False

            elif split[1][1][0] == ".": #label
                self.bin_instruction = "3{}00 {}".format(Rn,split[1][1])
                self.addr = split[1][1]
                self.has_data = True
                self.has_reference = True
                
            else: #to address
                addr = hex(int(split[1][1][:4], 16))[2:]
                addr = addr.rjust(4, "0")
                self.bin_instruction = "3{}00 {}".format(Rn, addr)
                self.has_data = True
            self.noop = False

        elif (split[0] == "ADD"):
            Rn = hex(int(split[1][0][1], 16))[2:]
            Rm = hex(int(split[1][1][1], 16))[2:]
            Rc = hex(int(split[1][2][1], 16))[2:]
            self.bin_instruction = "5{}{}{}".format(Rn,Rm,Rc)
            self.noop = False

        elif split[0] == "SUB":
            Rn = hex(int(split[1][0][1], 16))[2:]
            Rm = hex(int(split[1][1][1], 16))[2:]
            Rc = hex(int(split[1][2][1], 16))[2:]
            self.bin_instruction = "6{}{}{}".format(Rn,Rm,Rc)
            self.noop = False

        elif split[0] == "AND":
            Rn = hex(int(split[1][0][1], 16))[2:]
            Rm = hex(int(split[1][1][1], 16))[2:]
            Rc = hex(int(split[1][2][1], 16))[2:]
            self.bin_instruction = "7{}{}{}".format(Rn,Rm,Rc)
            self.noop = False

        elif split[0] == "OR":
            Rn = hex(int(split[1][0][1], 16))[2:]
            Rm = hex(int(split[1][1][1], 16))[2:]
            Rc = hex(int(split[1][2][1], 16))[2:]
            self.bin_instruction = "8{}{}{}".format(Rn,Rm,Rc)
            self.noop = False

        elif split[0] == "XOR":
            Rn = hex(int(split[1][0][1], 16))[2:]
            Rm = hex(int(split[1][1][1], 16))[2:]
            Rc = hex(int(split[1][2][1], 16))[2:]
            self.bin_instruction = "9{}{}{}".format(Rn,Rm,Rc)
            self.noop = False

        elif split[0] == "SHIFTR":
            Rn = hex(int(split[1][0][1], 16))[2:]
            Rc = hex(int(split[1][1][1], 16))[2:]
            self.bin_instruction = "A{}0{}".format(Rn,Rc)
            self.noop = False

        elif split[0] == "READIO":
            Rn = hex(int(split[1][0][1], 16))[2:]
            Rm = hex(int(split[1][1][1], 16))[2:]
            self.bin_instruction = "E{}{}0".format(Rn,Rm)
            self.noop = False

        elif split[0] == "WRITEIO":
            Rn = hex(int(split[1][0][1], 16))[2:]
            Rm = hex(int(split[1][1][1], 16))[2:]
            self.bin_instruction = "F{}{}0".format(Rn,Rm)
            self.noop = False

        elif split[0][:4] == "JUMP": #if label involved, process later
            jumptype = split[0][4:]
            self.jumptype = jumptype
            self.noop = False
            
            if split[1][-1][0] == ".": #address is a label, process later
                self.has_data = True
                self.has_reference = True

            elif jumptype == "": #unconditional. Either pointer or absolute
                if split[1][0][0] == "R": #pointer
                    Rn = hex(int(split[1][0][1], 16))[2:]
                    self.bin_instruction = "C{}00".format(Rn)
                    self.has_data = False
                    
                else: #absolute address
                    addr = hex(int(split[1][0][:4], 16))[2:]
                    addr = addr.rjust(4, "0")
                    self.bin_instruction = "B000 {}".format(addr)
                    self.has_data = True
                return

            self.addr = split[1][-1]
            if not self.has_reference: #not a label
                self.addr = hex(int(self.addr, 16))[2:].rjust(4, "0")

            if jumptype != "": #conditional jump
                self.Rn = hex(int(split[1][0][1], 16))[2:]
                self.Rm = hex(int(split[1][1][1], 16))[2:]
                self.has_data = True


            if jumptype == "":
                self.bin_instruction = "B000 {}".format(self.addr)
            elif jumptype == "LT":
                self.bin_instruction = "B{}{}1 {}".format(self.Rn, self.Rm, self.addr)
            elif jumptype == "GT":
                self.bin_instruction = "B{}{}2 {}".format(self.Rn, self.Rm, self.addr)
            elif jumptype == "EQ":
                self.bin_instruction = "B{}{}3 {}".format(self.Rn, self.Rm, self.addr)
            elif jumptype == "NV":
                self.bin_instruction = "B{}{}4 {}".format(self.Rn, self.Rm, self.addr)
            elif jumptype == "BL":
                self.bin_instruction = "B{}{}5 {}".format(self.Rn, self.Rm, self.addr)
            elif jumptype == "AB":
                self.bin_instruction = "B{}{}6 {}".format(self.Rn, self.Rm, self.addr)
            elif jumptype == "NE":
                self.bin_instruction = "B{}{}7 {}".format(self.Rn, self.Rm, self.addr)

        elif split[0] == "DS":
            self.num = int(split[1][0][:4], 16)
            self.bin_instruction = "0000" * self.num
            self.noop = False
            self.is_ds = True

        elif split[0] == "DW":
            if split[1][0][0] == ".": #is a label, process later
                self.has_reference = True
                self.noop = False
                self.bin_instruction = split[1][0]
                self.addr = split[1][0]
                return
            d = hex(int(split[1][0], 16))[2:].rjust(4, "0")
            self.bin_instruction = d
            self.noop = False

        else: #invalid instruction
            raise RuntimeError("Unknown instruction: {}".format(self.string))

        return

    def UpdateLabel(self):
        #run after pc of each instruction is given
        string = self.string.upper()
        try:
            if label_table[string] != -1: #already exists
                raise RuntimeError("Label: {} is being defined twice!".format(self.string))
            #is -1, so we can define it
            label_table[string] = self.pc
        except KeyError:
            #not in table yet, create it
            label_table[string] = self.pc
        pass

    def UpdateReference(self):
        label = self.addr
        if label not in label_table:
            raise RuntimeError("Label `{}` not defined!".format(label))
        addr = label_table[label]
        addr = hex(addr)[2:].rjust(4, "0")

        #print(label, addr, self.bin_instruction)
        
        self.bin_instruction = self.bin_instruction.replace(label, addr)

def make_asm(file_path):
    global label_table, lineno, failure
    failure = False
    label_table = dict()
    with open(file_path, "r") as file:
        lines = []
        lineno = 1
        print("Pass 1: Collecting instructions")
        for line in file:
            temp1 = line.replace("\n", "")
            
            try:
                temp2 = Line(temp1, lineno)
            except:
                print("({}) {}".format(lineno, sys.exc_info()[1]))
                failure = True
                
            if not temp2.noop: #remove noop's as soon as possible
                lines.append(temp2)
            lineno += 1 #increment the line counter

        print("Pass 2: Update pc of each instruction")
        counter = 0
        for line in lines:
            lineno = line.lineno
            line.pc = counter
            if line.is_label:
                
                try:
                    line.UpdateLabel()
                except:
                    print("({}) {}".format(lineno, sys.exc_info()[1]))
                    failure = True
                    
                continue #don't increment counter
            if line.is_ds:
                counter += line.num
                continue
            counter += 1
            if line.has_data:
                counter += 1

        print("Pass 3: Update lines that have references to labels")
        for line in lines:
            lineno = line.lineno
            if line.has_reference:
                try:
                    line.UpdateReference()
                except:
                    print("({}) {}".format(lineno, sys.exc_info()[1]))
                    failure = True

    asm = ""
    for line in lines:
        asm += line.bin_instruction

    asm = asm.replace(" ", "")

    print("Listings")
    print("Label\t\tAddress")
    for item in label_table:
        print("{}\t:\t{}".format(item, hex(label_table[item])[2:]))

    print("Total words: {}".format(hex(counter)[2:]))

    return asm.upper()
