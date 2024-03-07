namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the main arithmetic instructions 
        /// </summary>
        private void Arithmetic(string registerD, string registerL, string registerR, ArithmeticOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"Invalid register {registerD} at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerL))
                throw new Exception($"Invalid register {registerL} at address {ProgramCounterAdrress}");

            short number = 0;
            if(op == ArithmeticOperationEnum.AddImmediate || op == ArithmeticOperationEnum.MultiplyImmediate)
            {
                bool isValid = false;

                if (short.TryParse(registerR, out short val))
                {
                    isValid = true;
                    number = val;
                }
                else if (registerR.StartsWith("0x"))
                {

                    isValid = true;
                    number = Convert.ToInt16(registerR, 16);
                }

                if(!isValid)
                    throw new Exception($"Invalid value at address {ProgramCounterAdrress}");
            }
            else if (!RegisterExists(registerR))
                throw new Exception($"Invalid register {registerR} at address {ProgramCounterAdrress}");

            int value = 0;

            switch(op)
            {
                case ArithmeticOperationEnum.Add:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) + BitConverter.ToInt32(GetRegister(registerR).Value);
                    break;
                case ArithmeticOperationEnum.Subtract:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) - BitConverter.ToInt32(GetRegister(registerR).Value);
                    break;
                case ArithmeticOperationEnum.Divide:
                    int vl1 = BitConverter.ToInt32(GetRegister(registerL).Value);
                    int vl2 = BitConverter.ToInt32(GetRegister(registerR).Value);
                    
                    value = vl1 / vl2;
                    
                    int rest = vl1 % vl2;

                    // Store the division rest
                    var re = GetRegister("re");
                    re.SetValue(rest);

                    if (_onRegisterChange != null)
                        _onRegisterChange(re.Name, re.Value);
                    break;
                case ArithmeticOperationEnum.Multiply:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) * BitConverter.ToInt32(GetRegister(registerR).Value);
                    break;
                case ArithmeticOperationEnum.AddImmediate:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) + number;
                    break;
                case ArithmeticOperationEnum.MultiplyImmediate:
                    value = BitConverter.ToInt32(GetRegister(registerL).Value) * number;
                    break;
            }

            var regD = GetRegister(registerD);

            regD.SetValue(value);

            if(_onRegisterChange != null)
                _onRegisterChange(registerD, regD.Value);
        }
    }
}
