  -- print even numbers and store in the stack
  addi t0 t0 100
  addi s0 s0 2  
loop:
  div t9 t0 s0
  beq re zero print_stack

continue:
  addi t0 t0 -1
  beq t0 zero end
  j loop
-- prints and put in the stack
print_stack:
  sw t0 0 sp
  addi sp sp 4
  
  addi v0 zero 1
  move a0 t0
  syscall
  j continue
end:
  

  
  
  
  