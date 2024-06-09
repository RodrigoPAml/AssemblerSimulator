using System.Globalization;

namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Validate memory instructions (loads and stores)
        /// </summary>
        private void ValidateMemoryType1(string registerD, string registerL, string registerR, MemoryOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"RegisterD {registerD} do not exist at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerR))
                throw new Exception($"RegisterR register {registerR} at address {ProgramCounterAdrress}");

            switch (op)
            {
                case MemoryOperationEnum.LoadWord:
                case MemoryOperationEnum.StoreWord:
                case MemoryOperationEnum.LoadByte:
                case MemoryOperationEnum.StoreByte:
                    {
                      
                        if (!int.TryParse(registerL, out int _))
                            throw new Exception($"Unexpected value in registerL with load instruction at address {ProgramCounterAdrress}");
                    }
                    break;
            }
        }

        /// <summary>
        /// Validate memory instructions of load immediate type
        /// </summary>
        private void ValidateMemoryType2(string registerD, string registerL, string registerR, MemoryOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"RegisterD {registerD} do not exist at address {ProgramCounterAdrress}");

            if (!string.IsNullOrEmpty(registerR))
                throw new Exception($"registerR {registerR} should be empty at address {ProgramCounterAdrress}");

            switch (op)
            {
                case MemoryOperationEnum.LoadByteRegister:
                    {
                        if (registerL.Count() < 3 || !byte.TryParse(registerL.Substring(2), NumberStyles.HexNumber, null, out byte _))
                            throw new Exception($"Unexpected value in registerL with load instruction at address {ProgramCounterAdrress}");
                    }
                    break;
                case MemoryOperationEnum.LoadIntRegister:
                    {
                        if (!int.TryParse(registerL, out int _))
                            throw new Exception($"Unexpected value in registerL with load instruction at address {ProgramCounterAdrress}");
                    }
                    break;
                case MemoryOperationEnum.LoadFloatRegister:
                    {
                        if (!float.TryParse(registerL, out float _))
                            throw new Exception($"Unexpected value in registerL with load instruction at address {ProgramCounterAdrress}");
                    }
                    break;
                case MemoryOperationEnum.LoadCharRegister:
                    {
                        if (registerL.Count() != 3 || !registerL.StartsWith("'") || !registerL.EndsWith("'"))
                            throw new Exception($"Unexpected value in registerL with load instruction at address {ProgramCounterAdrress}");
                    }
                    break;
            }
        }

        /// <summary>
        /// Validate memory instructions of move and convert
        /// </summary>
        private void ValidateMemoryType3(string registerD, string registerL, string registerR, MemoryOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"RegisterD {registerD} do not exist at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerL))
                throw new Exception($"RegisterL {registerL} do not exist at address {ProgramCounterAdrress}");

            if (!string.IsNullOrEmpty(registerR))
                throw new Exception($"RegisterR not expected at address {ProgramCounterAdrress}");
        }
    }
}
