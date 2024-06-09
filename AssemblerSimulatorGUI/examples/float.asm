  -- program that runs a float sum a print it
  lfr s0 10.5
  lfr s1 25.3
  addf s2 s0 s1

  -- print
  lir v0 2  
  move a0 s2
  syscall
