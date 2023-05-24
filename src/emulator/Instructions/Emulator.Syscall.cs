namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the main logic operation instructions 
        /// </summary>
        private void Syscall()
        {
            int syscallCode = _registers.Where(x => x.Name == "v0").First().GetValue();

            if (syscallCode != 1)
                throw new Exception($"Unknow syscall code at v0 at address at address {ProgramCounterAdrress}");

            if (_onSyscall != null)
                _onSyscall(syscallCode, GetRegister("a0").Value);
        }
    }
}
