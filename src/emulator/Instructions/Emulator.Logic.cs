namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the main logic operation instructions 
        /// </summary>
        private void Logic(string registerD, string registerL, string registerR, LogicOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"Invalid register {registerD} at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerL))
                throw new Exception($"Invalid register {registerL} at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerR) && op != LogicOperationEnum.Not)
                throw new Exception($"Invalid register {registerR} at address {ProgramCounterAdrress}");
  
            int value = 0;

            switch(op)
            {
                case LogicOperationEnum.And:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) & BitConverter.ToInt32(GetRegister(registerR).Value);
                    break;
                case LogicOperationEnum.Or:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) | BitConverter.ToInt32(GetRegister(registerR).Value);
                    break;
                case LogicOperationEnum.Xor:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) ^ BitConverter.ToInt32(GetRegister(registerR).Value);
                    break;
                case LogicOperationEnum.ShiftLeft:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) << BitConverter.ToInt32(GetRegister(registerR).Value);
                    break;
                case LogicOperationEnum.ShiftRight:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) >> BitConverter.ToInt32(GetRegister(registerR).Value);
                    break;
                case LogicOperationEnum.Not:
                    if(!string.IsNullOrEmpty(registerR))
                        throw new Exception($"registerR {registerR} not expected in not instruct at address {ProgramCounterAdrress}");

                    value = ~BitConverter.ToInt32(GetRegister(registerL).Value);
                    break;
            }

            var regD = GetRegister(registerD);

            regD.SetValue(value);

            if (_onRegisterChange != null)
                _onRegisterChange(registerD, regD.Value);
        }
    }
}
