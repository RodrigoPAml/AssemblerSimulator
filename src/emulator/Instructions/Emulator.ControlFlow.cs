using System.Globalization;

namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the main flow control instructions 
        /// </summary>
        private bool ControlFlow(string registerD, string registerL, string registerR, ControlFlowOperationEnum op)
        {
            if (!RegisterExists(registerD) &&
                op != ControlFlowOperationEnum.Jump &&
                op != ControlFlowOperationEnum.JumpAndLink
            )
            {
                throw new Exception($"Invalid register {registerD} at address {ProgramCounterAdrress}");
            }

            if (!RegisterExists(registerL) && 
                op != ControlFlowOperationEnum.Jump && 
                op != ControlFlowOperationEnum.JumpRegister &&
                op != ControlFlowOperationEnum.JumpAndLink
            )
            {
                throw new Exception($"Invalid register {registerL} at address {ProgramCounterAdrress}");
            }

            if (!RegisterExists(registerD) &&
                (op == ControlFlowOperationEnum.SetLessThan ||
                op == ControlFlowOperationEnum.SetGreaterThan)
            )
            {
                throw new Exception($"Invalid register {registerD} at address {ProgramCounterAdrress}");
            }

            bool changePc = false;

            switch (op)
            {
                case ControlFlowOperationEnum.Jump:
                    {
                        bool isValid = false;
                        int address = 0;

                        if (registerD.StartsWith("0x"))
                        {
                            isValid = true;
                            address = Convert.ToInt16(registerD, 16);
                        }
                        else
                        {
                            string key = $"{registerD}:";

                            if (_labels.ContainsKey(key))
                            {
                                isValid = true;
                                address = _labels[key]+1;
                            }
                        }

                        if (!isValid)
                            throw new Exception($"Unexpected value in jump instruction at address {ProgramCounterAdrress}");

                        if (_instructions.Count < address)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.JumpRegister:
                    {
                        var address = GetRegister(registerD).GetValue();

                        if (_instructions.Count < address)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.JumpAndLink:
                    {
                        bool isValid = false;
                        int address = 0;

                        if (registerD.StartsWith("0x"))
                        {
                            isValid = true;
                            address = Convert.ToInt16(registerD, 16);
                        }
                        else
                        {
                            string key = $"{registerD}:";

                            if (_labels.ContainsKey(key))
                            {
                                isValid = true;
                                address = _labels[key]+1;
                            }
                        }

                        if (!isValid)
                            throw new Exception($"Unexpected value in jump instruction at address {ProgramCounterAdrress}");

                        if (_instructions.Count < address)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        var ra = _registers.Where(x => x.Name == "ra").FirstOrDefault();
                        ra.SetValue(ProgramCounter+1);

                        if (_onRegisterChange != null)
                            _onRegisterChange(ra.Name, ra.Value);

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.BranchEqual:
                    {
                        if (GetRegister(registerD).GetValue() != GetRegister(registerL).GetValue())
                            break;

                        bool isValid = false;
                        int address = 0;

                        if (registerR.StartsWith("0x"))
                        {
                            isValid = true;
                            address = Convert.ToInt16(registerR, 16);
                        }
                        else
                        {
                            string key = $"{registerR}:";

                            if (_labels.ContainsKey(key))
                            {
                                isValid = true;
                                address = _labels[key]+1;
                            }
                        }

                        if (!isValid)
                            throw new Exception($"Unexpected value in beq instruction at address {ProgramCounterAdrress}");

                        if (_instructions.Count < address)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.BranchNotEqual:
                    {
                        if (GetRegister(registerD).GetValue() == GetRegister(registerL).GetValue())
                            break;

                        bool isValid = false;
                        int address = 0;

                        if (registerR.StartsWith("0x"))
                        {
                            isValid = true;
                            address = Convert.ToInt16(registerR, 16);
                        }
                        else
                        {
                            string key = $"{registerR}:";

                            if (_labels.ContainsKey(key))
                            {
                                isValid = true;
                                address = _labels[key]+1;
                            }
                        }

                        if (!isValid)
                            throw new Exception($"Unexpected value in bne instruction at address {ProgramCounterAdrress}");

                        if (_instructions.Count < address)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.SetLessThan:
                    {
                        bool value = GetRegister(registerL).GetValue() > GetRegister(registerR).GetValue();

                        var regD = GetRegister(registerD);
                            
                        regD.SetValue(value ? 1 : 0);

                        if (_onRegisterChange != null)
                            _onRegisterChange(regD.Name, regD.Value);
                    }
                    break;
                case ControlFlowOperationEnum.SetGreaterThan:
                    {
                        bool value = GetRegister(registerL).GetValue() < GetRegister(registerR).GetValue();

                        var regD = GetRegister(registerD);
                        regD.SetValue(value ? 1 : 0);

                        if (_onRegisterChange != null)
                            _onRegisterChange(regD.Name, regD.Value);
                    }
                    break;
            }

            if(changePc)
            {
                var regPc = GetRegister("pc");

                if (_onRegisterChange != null)
                    _onRegisterChange(regPc.Name, regPc.Value);
            }

            return changePc; 
        }
    }
}
