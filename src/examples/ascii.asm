-- print some ascii chars
  lcr t0 '!'
  lcr t1 '~'
  lir t2 32
  lir v0 3  
loop: 
  -- print current char
  move a0 t0
  syscall

  -- increment char
  addi t0 t0 1

  -- print space
  move a0 t2
  syscall

  bne t0 t1 loop