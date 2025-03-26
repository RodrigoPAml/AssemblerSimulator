  -- program that output fibonacci
  lir s0 0
  lir s1 1
  lir s3 20
loop:
  add s2 s0 s1
  move s0 s1
  move s1 s2
  
  lir v0 1
  move a0 s2
  syscall

  lir v0 3
  lir a0 32
  syscall

  addi s3 s3 -1
  bne s3 zero loop

