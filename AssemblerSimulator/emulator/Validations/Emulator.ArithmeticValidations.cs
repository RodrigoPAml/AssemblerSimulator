namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Validate arithmetic instructions 
        /// </summary>
        private void ValidateArithmetic(string registerD, string registerL, string registerR, ArithmeticOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"RegisterD {registerD} do not exist at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerL))
                throw new Exception($"RegisterL {registerL} do not exist at address {ProgramCounterAdrress}");

            switch(op)
            {
                case ArithmeticOperationEnum.Subtract:
                case ArithmeticOperationEnum.Add:
                case ArithmeticOperationEnum.Divide:
                case ArithmeticOperationEnum.Multiply:
                case ArithmeticOperationEnum.AddFloat:
                case ArithmeticOperationEnum.MultiplyFloat:
                case ArithmeticOperationEnum.SubtractFloat:
                case ArithmeticOperationEnum.DivideFloat:
                case ArithmeticOperationEnum.SetEqual:
                case ArithmeticOperationEnum.SetNotEqual:
                case ArithmeticOperationEnum.SetLessThan:
                case ArithmeticOperationEnum.SetGreaterThan:
                case ArithmeticOperationEnum.SetLessThanOrEqual:
                case ArithmeticOperationEnum.SetGreaterThanOrEqual:
                case ArithmeticOperationEnum.SetLessThanFloat:
                case ArithmeticOperationEnum.SetGreaterThanFloat:
                case ArithmeticOperationEnum.SetLessThanOrEqualFloat:
                case ArithmeticOperationEnum.SetGreaterThanOrEqualFloat:
                    if (!RegisterExists(registerR))
                        throw new Exception($"RegisterR {registerR} do not exist at address {ProgramCounterAdrress}");
                    break;
                case ArithmeticOperationEnum.AddImmediate:
                case ArithmeticOperationEnum.MultiplyImmediate:
                case ArithmeticOperationEnum.DivideImmediate:
                case ArithmeticOperationEnum.SubtractImmediate:
                    {
                        bool isValid = false;

                        if (int.TryParse(registerR, out int _))
                            isValid = true;

                        if (!isValid)
                            throw new Exception($"Invalid value for immediate at address {ProgramCounterAdrress}");
                    }
                    break;
                case ArithmeticOperationEnum.AddFloatImmediate:
                case ArithmeticOperationEnum.MultiplyFloatImmediate:
                case ArithmeticOperationEnum.SubtractFloatImmediate:
                case ArithmeticOperationEnum.DivideFloatImmediate:
                    {
                        bool isValid = false;

                        if (float.TryParse(registerR, out float _))
                            isValid = true;

                        if (!isValid)
                            throw new Exception($"Invalid value for immediate at address {ProgramCounterAdrress}");
                    }
                    break;
            }
        }
    }
}
