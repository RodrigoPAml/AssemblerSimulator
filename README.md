# Assembler Simulator

An assembler simulator based on MIPS architecture

The program uses windows form for the user interface part

- With code editor to load an save asm files and add code comments
- Option to run the code, reset the simulator and see output
- View of the program memory and instruction memory
- View of the registers and address that labels refers to
- 32 bits registers implemented
- Address is oriented in byte (8 bits)
- Syscall for output of char, integers and floats
- You can disable the emulator feed (GUI, callbacks, etc) to have max performance

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/ac2505b2-7e64-4d98-9922-4692665b86ea)

# Views

## Instructions memory

Show the instructions in memory view

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/596b4b4c-cce3-47d4-b3a7-452ba675a2fd)

## Labels View

Show the labels poiting addresses

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/ddf7c58e-7b11-4c06-a168-94708d78c70e)

## Memory View

Show program memory per byte or char

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/aae590fe-fefb-4bee-837e-34a204a9daf6)

## Registers View

Show registers values

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/6b45463e-2837-420f-8c98-64e3a09c8a10)

## Code and output view

Show the code with options in the top and output

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/83d4e1ce-e361-4b66-bd18-9d3d02f4f3e8)

# Implemented instructions

List of implementes instructions from MIPS

## Arithmetic

Instructions to do arithmetic operations

```asm
add reg1 reg2 reg3 ; reg1 = reg2 + reg3
addi reg1 reg2 integer ; reg1 = reg2 + integer
sub reg1 reg2 reg3 ; reg1 = reg2 - reg3
div reg1 reg2 reg3 ; reg1 = reg2 / reg3
mul reg1 reg2 reg3 ; reg1 = reg2 * reg3
muli reg1 reg2 integer ; reg1 = reg2 * integer

addf reg1 reg2 reg3 ; reg1 = reg2 + reg3
addfi reg1 reg2 float ; reg1 = reg2 + float
subf reg1 reg2 reg3 ; reg1 = reg2 - reg3
divf reg1 reg2 reg3 ; reg1 = reg2 / reg3
mulf reg1 reg2 reg3 ; reg1 = reg2 * reg3
mulfi reg1 reg2 float ; reg1 = reg2 * float

se reg1 reg2 reg3 ; set reg1 as one if reg2 equals reg3 content, else set zero
sne reg1 reg2 reg3 ; set reg1 as one if reg2 not equals reg3 content, else set zero

slt reg1 reg2 reg3 ; set reg1 as one if reg2 < reg3 (int comparision) else set zero
sgt reg1 reg2 reg3 ; set reg1 as one if reg2 > reg3 (int comparision) else set zero
slte reg1 reg2 reg3 ; set reg1 as one if reg2 <= reg3 (int comparision) else set zero
sgte reg1 reg2 reg3 ; set reg1 as one if reg2 >= reg3 (int comparision) else set zero

sltf reg1 reg2 reg3 ; set reg1 as one if reg2 < reg3 (float comparision) else set zero
sgtf reg1 reg2 reg3 ; set reg1 as one if reg2 > reg3 (float comparision) else set zero
sltef reg1 reg2 reg3 ; set reg1 as one if reg2 <= reg3 (float comparision) else set zero
sgtef reg1 reg2 reg3 ; set reg1 as one if reg2 >= reg3 (float comparision) else set zero
```

## Logic

Instructios to do logic operations


```asm
and reg1 reg2 reg3 ; reg1 = reg2 & reg3
xor reg1 reg2 reg3 ; reg1 = reg2 ^ reg3
or reg1 reg2 reg3 ; reg1 = reg2 | reg3
sfl reg1 reg2 reg3 ; reg1 = reg2 << reg3 
sfr reg1 reg2 reg3 ; reg1 = reg2 >> reg3
not reg1 reg2 ; reg1 = ~reg2
```

## Flow Control

Instructions to control program flow

```asm
j label ; go to instruction at address of label
jal label ; go to instruction at address of label, and save previous address+1 at ra
jr register ; go to instruction at address contained in register
beq reg1 reg2 label ; if reg1 and reg2 are same bytes go to address of label
beq reg1 reg2 label ; if reg1 and reg2 are same bytes go to address of label
```

## Memory

Instructions to control program memory

```asm
lw reg1 integer reg2 ; reg1 = memory[reg2 + integer]
sw reg1 integer reg2 ; memory[reg2 + integer] = reg1
lb reg1 integer reg2 ; reg1 = memory[reg2 + integer]
sb reg1 integer reg2 ; memory[reg2 + integer] = reg1

lbr reg1 hex_value ; load hex_value into reg1
lcr reg1 char(ASCII) ; load char into reg1
lir reg1 integer ; load integer into reg1
lfr reg1 float ; load float into reg1

move reg1 reg2 ; reg1 = reg2
cfi reg1 reg2 ; reg1 = (float)reg2
cif reg1 reg2 ; reg1 = (int)reg2
```

## Syscall

Syscall for output integer (number 1), float(number2), char(number3) 

```asm
addi v0 v0 1
move a0 t0
syscall
```

# Registers

#### register zero 
Register that stores the zero value
#### register one 
Register that stores the one value
#### registers s0 to s7
Registers for saved values
#### regtisters t0 to t9
Registers for temp values
#### registers a0 to a3
Arguments registers
#### regtisters v0 to v1
Returned values registers
#### register ve
Register that store the rest of some integer division
#### register vef
Register that store the rest of some float division
#### register gp and sp
Heap and stack pointer
#### register ra
Register to hold the return address
#### register pc
Program counter register

# Examples

Below some examples that you can run

## Fibonnaci

A program that outputs n numbers from fibonnaci sequence

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/17ea12e0-c983-4b32-a631-de503fd8ff36)

## Even number in the stack

A program that outputs even numbers and stack it on memory

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/5e15857e-c566-444b-a155-13d6711ca029)

## ASCII
A program that print some ascii chars

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/e58c5218-72f9-4b5f-a75d-97334d27ef8a)

## Float
A program that do a float sum and print it

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/1648e049-328e-4aa3-9e70-a14376c06e68)

# Using the API

Take a look at Program.cs of the AssemblerSimulator project to see the example below

``` C#
public static void Main()
{
    Emulator emulator = new Emulator(OnMemoryChange, OnRegisterChange, OnSyscall);

    emulator.AddInstruction("lir t0 10"); // Carrega valor 10 em t0
    emulator.AddInstruction("sw t0 0 sp");  // Carrega na pilha o valor 10
    
    // Syscall para printar inteiro
    emulator.AddInstruction("addi v0 v0 1");
    emulator.AddInstruction("move a0 t0");
    emulator.AddInstruction("syscall");

    emulator.ValidateInstructions();
    emulator.ExecuteAll();
}
```

Output
```
OnRegisterChange t0 10 0 0 0
OnRegisterChange pc 1 0 0 0
OnMemoryChange 0 10
OnMemoryChange 1 0
OnMemoryChange 2 0
OnMemoryChange 3 0
OnRegisterChange pc 2 0 0 0
OnRegisterChange v0 1 0 0 0
OnRegisterChange pc 3 0 0 0
OnRegisterChange a0 10 0 0 0
OnRegisterChange pc 4 0 0 0
OnSyscall 1 10 0 0 0
OnRegisterChange pc 5 0 0 0
```


