namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Validate flow control instructions (jump and jump and link)
        /// </summary>
        private void ValidadeControlFlowType1(string registerD, string registerL, string registerR, ControlFlowOperationEnum op)
        {
            if (string.IsNullOrEmpty(registerD))
                throw new Exception($"No value provided for label at address {ProgramCounterAdrress}");

            if (!string.IsNullOrEmpty(registerL))
                throw new Exception($"RegisterL should not be provided at address {ProgramCounterAdrress}");

            if (!string.IsNullOrEmpty(registerR))
                throw new Exception($"registerR should not be provided at addres {ProgramCounterAdrress}");

            switch (op)
            {
                case ControlFlowOperationEnum.Jump:
                case ControlFlowOperationEnum.JumpAndLink:
                    {
                        string key = $"{registerD}:";

                        if (!_labels.ContainsKey(key))
                            throw new Exception($"Unexpected label in instruction {op} at address {ProgramCounterAdrress}");

                        int address = _labels[key] + 1;

                        if (_instructions.Count < address)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");
                    }
                    break;
            }
        }

        /// <summary>
        /// Validate flow control instructions (jump register)
        /// </summary>
        private void ValidadeControlFlowType2(string registerD, string registerL, string registerR, ControlFlowOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"RegisterD {registerD} not provided at address {ProgramCounterAdrress}");

            if (!string.IsNullOrEmpty(registerL))
                throw new Exception($"RegisterL should not be provided at address {ProgramCounterAdrress}");

            if (!string.IsNullOrEmpty(registerR))
                throw new Exception($"registerR should not be provided at addres {ProgramCounterAdrress}");
        }

        /// <summary>
        /// Validate flow control instructions (Branch Equal, Branch Not Equal)
        /// </summary>
        private void ValidadeControlFlowType3(string registerD, string registerL, string registerR, ControlFlowOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"RegisterD {registerD} not provided at address {ProgramCounterAdrress}");

            // Verify register L
            if (!RegisterExists(registerL))
                throw new Exception($"RegisterL {registerL} do not exist at address {ProgramCounterAdrress}");

            // Verify register R
            if (string.IsNullOrEmpty(registerR))
                throw new Exception($"Label not provided at address {ProgramCounterAdrress}");

            switch (op)
            {
                case ControlFlowOperationEnum.BranchEqual:
                case ControlFlowOperationEnum.BranchNotEqual:
                    {
                        string key = $"{registerR}:";

                        if (!_labels.ContainsKey(key))
                            throw new Exception($"Unexpected label in instruction {op} at address {ProgramCounterAdrress}");

                        int address = _labels[key] + 1;

                        if (_instructions.Count < address)
                            throw new Exception($"Out of range memory access at address {ProgramCounterAdrress}");
                    }
                    break;
            }
        }
    }
}
