namespace AssemblerSimulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the arithmetic instructions implementations
        /// </summary>
        private void Arithmetic(string registerD, string registerL, string registerR, ArithmeticOperationEnum op)
        {
            int value = 0;

            switch(op)
            {
                case ArithmeticOperationEnum.Add:
                    value = GetRegister(registerL).GetIntValue() + GetRegister(registerR).GetIntValue();
                    break;
                case ArithmeticOperationEnum.Subtract:
                    value = GetRegister(registerL).GetIntValue() - GetRegister(registerR).GetIntValue();
                    break;
                case ArithmeticOperationEnum.Divide:
                    int vl1 = GetRegister(registerL).GetIntValue();
                    int vl2 = GetRegister(registerR).GetIntValue();

                    value = vl1 / vl2;
                    
                    int rest = vl1 % vl2;

                    // Store the division rest
                    var re = GetRegister("re");
                    re.SetValue(rest);

                    if (_onRegisterChange != null)
                        _onRegisterChange(re.Name, re.Value);
                    break;
                case ArithmeticOperationEnum.Multiply:
                    value = GetRegister(registerL).GetIntValue() * GetRegister(registerR).GetIntValue();
                    break;
                case ArithmeticOperationEnum.AddImmediate:
                    value = GetRegister(registerL).GetIntValue() + int.Parse(registerR);
                    break;
                case ArithmeticOperationEnum.SubtractImmediate:
                    value = GetRegister(registerL).GetIntValue() - int.Parse(registerR);
                    break;
                case ArithmeticOperationEnum.MultiplyImmediate:
                    value = GetRegister(registerL).GetIntValue() * int.Parse(registerR);
                    break;
                case ArithmeticOperationEnum.DivideImmediate:
                    value = GetRegister(registerL).GetIntValue() / int.Parse(registerR);
                    break;
                case ArithmeticOperationEnum.SetEqual:
                    value = GetRegister(registerL).Value.SequenceEqual(GetRegister(registerR).Value)
                        ? 1
                        : 0;
                    break;
                case ArithmeticOperationEnum.SetNotEqual:
                    value = !GetRegister(registerL).Value.SequenceEqual(GetRegister(registerR).Value)
                          ? 1
                          : 0;
                    break;
                case ArithmeticOperationEnum.SetLessThan:
                    value = GetRegister(registerL).GetIntValue() < GetRegister(registerR).GetIntValue()
                         ? 1
                         : 0;
                    break;
                case ArithmeticOperationEnum.SetLessThanOrEqual:
                    value = GetRegister(registerL).GetIntValue() <= GetRegister(registerR).GetIntValue()
                        ? 1
                        : 0;
                    break;
                case ArithmeticOperationEnum.SetGreaterThan:
                    value = GetRegister(registerL).GetIntValue() > GetRegister(registerR).GetIntValue() 
                        ? 1
                        : 0;
                    break;
                case ArithmeticOperationEnum.SetGreaterThanOrEqual:
                    value = GetRegister(registerL).GetIntValue() >= GetRegister(registerR).GetIntValue() 
                        ? 1
                        : 0;
                    break;
            }

            var regD = GetRegister(registerD);

            regD.SetValue(value);

            if(_onRegisterChange != null)
                _onRegisterChange(registerD, regD.Value);
        }

        /// <summary>
        /// Contains the arithmetic with float instructions implementations
        /// </summary>
        private void ArithmeticFloat(string registerD, string registerL, string registerR, ArithmeticOperationEnum op)
        {
            float value = 0;
            bool isBool = false;

            switch (op)
            {
                case ArithmeticOperationEnum.AddFloat:
                    value = GetRegister(registerL).GetFloatValue() + GetRegister(registerR).GetFloatValue();
                    break;
                case ArithmeticOperationEnum.SubtractFloat:
                    value = GetRegister(registerL).GetFloatValue() - GetRegister(registerR).GetFloatValue();
                    break;
                case ArithmeticOperationEnum.DivideFloat:
                    float vl1 = GetRegister(registerL).GetFloatValue();
                    float vl2 = GetRegister(registerR).GetFloatValue();

                    value = vl1 / vl2;

                    float rest = vl1 % vl2;

                    // Store the division rest
                    var re = GetRegister("ref");
                    re.SetValue(rest);

                    if (_onRegisterChange != null)
                        _onRegisterChange(re.Name, re.Value);
                    break;
                case ArithmeticOperationEnum.MultiplyFloat:
                    value = GetRegister(registerL).GetFloatValue() * GetRegister(registerR).GetFloatValue();
                    break;
                case ArithmeticOperationEnum.AddFloatImmediate:
                    value = GetRegister(registerL).GetFloatValue() + float.Parse(registerR);
                    break;
                case ArithmeticOperationEnum.SubtractFloatImmediate:
                    value = GetRegister(registerL).GetFloatValue() - float.Parse(registerR);
                    break;
                case ArithmeticOperationEnum.MultiplyFloatImmediate:
                    value = GetRegister(registerL).GetFloatValue() * float.Parse(registerR);
                    break;
                case ArithmeticOperationEnum.DivideFloatImmediate:
                    value = GetRegister(registerL).GetFloatValue() / float.Parse(registerR);
                    break;
                case ArithmeticOperationEnum.SetLessThanFloat:
                    isBool = true;
                    value = GetRegister(registerL).GetFloatValue() < GetRegister(registerR).GetFloatValue()
                        ? 1
                        : 0;
                    break;
                case ArithmeticOperationEnum.SetLessThanOrEqualFloat:
                    isBool = true;
                    value = GetRegister(registerL).GetFloatValue() <= GetRegister(registerR).GetFloatValue()
                        ? 1
                        : 0;
                    break;
                case ArithmeticOperationEnum.SetGreaterThanFloat:
                    isBool = true;
                    value = GetRegister(registerL).GetFloatValue() > GetRegister(registerR).GetFloatValue()
                        ? 1
                        : 0;
                    break;
                case ArithmeticOperationEnum.SetGreaterThanOrEqualFloat:
                    isBool = true;
                    value = GetRegister(registerL).GetFloatValue() >= GetRegister(registerR).GetFloatValue()
                        ? 1
                        : 0;
                    break;
            }

            var regD = GetRegister(registerD);

            if (isBool)
                regD.SetValue((int)value);
            else 
                regD.SetValue(value);

            if (_onRegisterChange != null)
                _onRegisterChange(registerD, regD.Value);
        }
    }
}
