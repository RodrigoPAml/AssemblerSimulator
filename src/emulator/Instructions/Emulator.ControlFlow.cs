namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the flow control instructions 
        /// </summary>
        private bool ControlFlow(string registerD, string registerL, string registerR, ControlFlowOperationEnum op)
        {
            bool changePc = false;

            switch (op)
            {
                case ControlFlowOperationEnum.Jump:
                    {
                        string key = $"{registerD}:";
                        int address = _labels[key] + 1;

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.JumpRegister:
                    {
                        var address = GetRegister(registerD).GetIntValue();

                        if (_instructions.Count < address)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.JumpAndLink:
                    {
                        string key = $"{registerD}:";
                        int address = _labels[key] + 1;

                        var ra = _registers.Where(x => x.Name == "ra").FirstOrDefault();
                        ra.SetValue(ProgramCounter + 1);

                        if (_onRegisterChange != null)
                            _onRegisterChange(ra.Name, ra.Value);

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.BranchEqual:
                    {
                        if (!GetRegister(registerD).Value.SequenceEqual(GetRegister(registerL).Value))
                            break;

                        string key = $"{registerR}:";
                        int address = _labels[key] + 1;

                        GetRegister("pc").SetValue(address);
                        changePc = true;
                    }
                    break;
                case ControlFlowOperationEnum.BranchNotEqual:
                    {
                        if (GetRegister(registerD).Value.SequenceEqual(GetRegister(registerL).Value))
                            break;

                        string key = $"{registerR}:";
                        int address = _labels[key] + 1;

                        GetRegister("pc").SetValue(address);
                        changePc = true;
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
