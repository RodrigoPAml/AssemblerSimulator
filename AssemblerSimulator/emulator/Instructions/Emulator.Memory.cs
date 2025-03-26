using System.Globalization;
using System.Text;

namespace AssemblerSimulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the main memory instructions implementations
        /// </summary>
        private void Memory(string registerD, string registerL, string registerR, MemoryOperationEnum op)
        {
            switch (op)
            {
                case MemoryOperationEnum.Move:
                    {
                        var regD = GetRegister(registerD);

                        regD.SetValue(GetRegister(registerL).Value);

                        LocalOnRegisterChange(registerD, regD.Value);
                    }

                    break;
                case MemoryOperationEnum.LoadWord:
                    {
                        var address = GetRegister(registerR).GetIntValue();
                        int mem = address + int.Parse(registerL);

                        if (mem >= _memory.Count || mem+3 >= _memory.Count)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        byte[] bytes = new byte[4];

                        bytes[0] = _memory[mem];
                        bytes[1] = _memory[mem+1];
                        bytes[2] = _memory[mem+2];
                        bytes[3] = _memory[mem+3];

                        var regD = GetRegister(registerD);

                        regD.SetValue(bytes);

                        LocalOnRegisterChange(registerD, regD.Value);
                    }
                    break;
                case MemoryOperationEnum.StoreWord:
                    {
                        var value = GetRegister(registerD).Value;
                        var address = GetRegister(registerR).GetIntValue();
                        int mem = address + int.Parse(registerL);

                        if (mem >= _memory.Count || mem+3 >= _memory.Count)
                            throw new Exception($"Out of range memory write at address {ProgramCounterAdrress}");

                        _memory[mem] = value[0];
                        _memory[mem+1] = value[1];
                        _memory[mem+2] = value[2];
                        _memory[mem+3] = value[3];
                   
                        LocalOnMemoryChange(mem, value[0]);
                        LocalOnMemoryChange(mem + 1, value[1]);
                        LocalOnMemoryChange(mem + 2, value[2]);
                        LocalOnMemoryChange(mem + 3, value[3]);
                    }
                    break;
                case MemoryOperationEnum.LoadByte:
                    {
                        var address = GetRegister(registerR).GetIntValue();
                        int mem = address + int.Parse(registerL);

                        if (mem >= _memory.Count)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        var @byte = _memory[mem];
                      
                        var regD = GetRegister(registerD);

                        regD.SetValue(@byte);

                        LocalOnRegisterChange(registerD, regD.Value);
                    }
                    break;
                case MemoryOperationEnum.StoreByte:
                    {
                        var value = GetRegister(registerD).Value;
                        var address = GetRegister(registerR).GetIntValue();
                        int mem = address + int.Parse(registerL);

                        if (mem >= _memory.Count)
                            throw new Exception($"Out of range memory write at address {ProgramCounterAdrress}");

                        _memory[mem] = value[0];
                        
                        LocalOnMemoryChange(mem, value[0]);
                    }
                    break;
                case MemoryOperationEnum.LoadIntRegister:
                    {
                        var value = int.Parse(registerL);
                        var reg = GetRegister(registerD);

                        reg.SetValue(value);

                        LocalOnRegisterChange(registerD, reg.Value);
                    }
                    break;
                case MemoryOperationEnum.LoadByteRegister:
                    {
                        var value = byte.Parse(registerL.Substring(2), NumberStyles.HexNumber);
                        var reg = GetRegister(registerD);
                        
                        reg.SetValue(value);

                        LocalOnRegisterChange(registerD, reg.Value);
                    }
                    break;
                case MemoryOperationEnum.LoadFloatRegister:
                    {
                        var value = float.Parse(registerL);
                        var reg = GetRegister(registerD);

                        reg.SetValue(value);

                        LocalOnRegisterChange(registerD, reg.Value);
                    }
                    break;
                case MemoryOperationEnum.LoadCharRegister:
                    {
                        var value = Encoding.ASCII.GetBytes(new char[] { registerL[1] }); ;
                        var reg = GetRegister(registerD);

                        reg.SetValue(value[0]);

                        LocalOnRegisterChange(registerD, reg.Value);
                    }
                    break;
                case MemoryOperationEnum.ConvertIntFloat:
                    {
                        var reg = GetRegister(registerD);
                        var regValue = GetRegister(registerL);

                        reg.SetValue((float)regValue.GetIntValue());

                        LocalOnRegisterChange(registerD, reg.Value);
                    }
                    break;
                case MemoryOperationEnum.ConvertFloatInt:
                    {
                        var reg = GetRegister(registerD);
                        var regValue = GetRegister(registerL);

                        reg.SetValue((int)regValue.GetFloatValue());

                        LocalOnRegisterChange(registerD, reg.Value);
                    }
                    break;
            }
        }
    }
}
