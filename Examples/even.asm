  -- print even numbers and store in the stack
  lir t0 100
  lir s0 2  
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
  
  lir v0 1
  move a0 t0
  syscall

  lir v0 3
  lir a0 32
  syscall

  j continue
end:
  