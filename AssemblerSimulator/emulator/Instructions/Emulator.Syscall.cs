namespace AssemblerSimulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the main logic operation instructions implementations
        /// </summary>
        private void Syscall()
        {
            int syscallCode = GetRegister("v0").GetIntValue();

            if (syscallCode < 1 && syscallCode > 3)
                throw new Exception($"Unknow syscall code at v0 at address at address {ProgramCounterAdrress}");

            LocalOnSyscall(syscallCode, GetRegister("a0").Value);
        }
    }
}
