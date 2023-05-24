namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the main memory instructions 
        /// </summary>
        private void Memory(string registerD, string registerL, string registerR, MemoryOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"Invalid register {registerD} at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerL) && 
                op != MemoryOperationEnum.Load && 
                op != MemoryOperationEnum.Store &&
                op != MemoryOperationEnum.StoreByte &&
                op != MemoryOperationEnum.LoadByte 
            )
            {
                throw new Exception($"Invalid register {registerL} at address {ProgramCounterAdrress}");
            }

            if (!RegisterExists(registerR) && op != MemoryOperationEnum.Move)
            {
                throw new Exception($"Invalid register {registerR} at address {ProgramCounterAdrress}");
            }

            switch (op)
            {
                case MemoryOperationEnum.Move:
                    {
                        var regD = GetRegister(registerD);

                        regD.SetValue(GetRegister(registerL).GetValue());

                        if (_onRegisterChange != null)
                            _onRegisterChange(registerD, regD.Value);
                    }

                    break;
                case MemoryOperationEnum.Load:
                    {
                        if(!int.TryParse(registerL, out int offset))
                            throw new Exception($"Unexpected value in registerL with load instruction at address {ProgramCounterAdrress}");

                        var address = GetRegister(registerR).GetValue();

                        int mem = address + offset;

                        if (mem >= _memory.Count || mem+3 >= _memory.Count)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        byte[] bytes = new byte[4];

                        bytes[0] = _memory[mem];
                        bytes[1] = _memory[mem+1];
                        bytes[2] = _memory[mem+2];
                        bytes[3] = _memory[mem+3];

                        var regD = GetRegister(registerD);

                        regD.SetValue(bytes);

                        if (_onRegisterChange != null)
                            _onRegisterChange(registerD, regD.Value);
                    }
                    break;
                case MemoryOperationEnum.Store:
                    {
                        var value = GetRegister(registerD).Value;
                        var address = GetRegister(registerR).GetValue();

                        if (!int.TryParse(registerL, out int offset))
                            throw new Exception($"Unexpected value in registerL with store instruction at address {ProgramCounterAdrress}");

                        int mem = address + offset;

                        if (mem >= _memory.Count || mem+3 >= _memory.Count)
                            throw new Exception($"Out of range memory write at address {ProgramCounterAdrress}");

                        _memory[mem] = value[0];
                        _memory[mem+1] = value[1];
                        _memory[mem+2] = value[2];
                        _memory[mem+3] = value[3];

                        _onMemoryChange(mem, value[0]);
                        _onMemoryChange(mem+1, value[1]);
                        _onMemoryChange(mem+2, value[2]);
                        _onMemoryChange(mem+3, value[3]);
                    }
                    break;
                case MemoryOperationEnum.LoadByte:
                    {
                        if (!int.TryParse(registerL, out int offset))
                            throw new Exception($"Unexpected value in registerL with load instruction at address {ProgramCounterAdrress}");

                        var address = GetRegister(registerR).GetValue();

                        int mem = address + offset;

                        if (mem >= _memory.Count)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        var @byte = _memory[mem];
                      
                        var regD = GetRegister(registerD);

                        regD.   SetValue(@byte);

                        if (_onRegisterChange != null)
                            _onRegisterChange(registerD, regD.Value);
                    }
                    break;
                case MemoryOperationEnum.StoreByte:
                    {
                        var value = GetRegister(registerD).Value;
                        var address = GetRegister(registerR).GetValue();

                        if (!int.TryParse(registerL, out int offset))
                            throw new Exception($"Unexpected value in registerL with store instruction at address {ProgramCounterAdrress}");

                        int mem = address + offset;

                        if (mem >= _memory.Count)
                            throw new Exception($"Out of range memory write at address {ProgramCounterAdrress}");

                        _memory[mem] = value[0];
                        _onMemoryChange(mem, value[0]);
                    }
                    break;
            }
        }
    }
}
