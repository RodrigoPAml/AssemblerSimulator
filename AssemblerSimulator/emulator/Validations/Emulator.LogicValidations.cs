namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Validate logic instructions 
        /// </summary>
        private void ValidateLogic(string registerD, string registerL, string registerR, LogicOperationEnum op)
        {
            if (!RegisterExists(registerD))
                throw new Exception($"RegisterD {registerD} do not exist at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerL))
                throw new Exception($"RegisterL {registerL} do not exist at address {ProgramCounterAdrress}");

            if (!RegisterExists(registerR) && op != LogicOperationEnum.Not )
                throw new Exception($"RegisterR {registerR} do not exist at address {ProgramCounterAdrress}");
    
            switch (op)
            {
                case LogicOperationEnum.Not:
                    if (!string.IsNullOrEmpty(registerR))
                        throw new Exception($"registerR {registerR} not expected in not instruct at address {ProgramCounterAdrress}");
                    break;
            }
        }
    }
}
