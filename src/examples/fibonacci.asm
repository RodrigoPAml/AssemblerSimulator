  -- program that output fibonacci
  addi s0 s0 0
  addi s1 s1 1
  addi s3 s3 10

  addi v0 v0 1
loop:
  add s2 s0 s1
  move s0 s1
  move s1 s2
  
  move a0 s2
  syscall

  addi s3 s3 -1
  bne s3 zero loop

