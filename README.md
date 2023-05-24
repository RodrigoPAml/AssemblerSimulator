# Assembler Simulator

An assembler simulator based on MIPS architecture

The program uses windows form for the user interface part

- With code editor to load an save asm files and add code comments
- Option to run the code, reset the simulator and see output
- View of the program memory and instruction memory
- View of the registers and address that labels point
- 32 bits registers implemented
- Address is oriented in byte (8 bits)
- Syscall for output

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/3b1a2ad0-bbe5-4513-99cc-2fc52398139f)

# Views

## Instructions memory

Show the instructions with address

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/f397f439-6f3e-4c72-9470-70f5a0c82c10)

## Labels View

Show the labels poiting addresses

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/ddf7c58e-7b11-4c06-a168-94708d78c70e)

## Memory View

Show program memory per byte

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/aa426e56-bcaf-4992-b86e-20fb6bfaf522)

## Registers View

Show registers values

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/ade239a1-21da-4b71-815e-42d2e1d1f901)

# Implemented instructions

List of implementes instructions from MIPS

## Arithmetic
```asm
add t0 t1 t2
addi t0 t1 10
sub t0 t1 t2
div t0 t1 t2
mul t0 t1 t2
muli t0 t1 t2
```

## Logic

sfl is shift left and sfr is shift right

```asm
and t1 t2 t3
or t1 t2 t3
xor t1 t2 t3
not t1 t2
sfl t1 t2 t3
sfr t1 t2 t3
```

## Flow Control

```asm
j label
jal label
jr t0
beq t0 t1 label
bne t0 t1 label
slt t0 t1 t2
sgt t0 t1 t2
```

## Memory

```asm
move t0 t1
lw t0 10 t1
sw t0 10 t1
lb t0 10 t1
sb t0 10 t1
```

## Syscall

Syscall for output integer (number 1) is implemented

```asm
addi v0 v0 1
move a0 t0
syscall
```

# Registers

#### register zero 
Register that stores the zero value
#### registers s0 to s7
Registers for saved values
#### regtisters t0 to t9
Registers for temp values
#### registers a0 to a3
Arguments registers
#### regtisters v0 to v1
Returned values registers
#### register ve
Register that store the rest of some division
#### register gp and sp
Heap and stack pointer
#### register ra
Register to hold the return address
#### register pc
Program counter register

# Examples

## Fibonnaci

A program that outputs n numbers from fibonnaci sequence

![image](https://github.com/RodrigoPAml/AssemblerSimulator/assets/41243039/1a34c950-937f-4338-88cf-a07f0e1f05f5)

## Prime Values

A program that output n prime numbers

