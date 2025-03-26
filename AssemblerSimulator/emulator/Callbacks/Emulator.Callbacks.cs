namespace AssemblerSimulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Callbacks to notify changes in memory and registers, or syscalls
        /// </summary>
        private OnRegisterChange onRegisterChange;
        private OnMemoryChange onMemoryChange;
        private OnSyscall onSyscall;

        /// <summary>
        /// Decide when the callbacks will be invoked by invoking InvokeCallbacks()
        /// Helps increase performance because the program will run without calling blocking callbacks
        /// After calling InvokeCallbacks() all the callbacks will be invoked in the ogirinal order
        /// </summary>
        public bool PostergateCallbacks { get; set; } = false;

        private List<(string, byte[])> _localRegisterChanges = new();
        private List<(int, byte)> _localMemoryChanges = new();
        private List<(int, byte[])> _localSyscalls = new();

        public void InvokeCallbacks()
        {
            if (!PostergateCallbacks)
            {
                return;
            }

            if (onRegisterChange != null)
            {
                foreach (var registerChange in _localRegisterChanges)
                {
                    onRegisterChange(registerChange.Item1, registerChange.Item2);  
                }
            }

            if (onMemoryChange != null)
            {
                foreach (var memoryChange in _localMemoryChanges)
                {
                    onMemoryChange(memoryChange.Item1, memoryChange.Item2);
                }
            }

            if (onSyscall != null)
            {
                foreach (var syscall in _localSyscalls)
                {
                    onSyscall(syscall.Item1, syscall.Item2);
                }
            }

            ClearPostergation();
        }

        private void ClearPostergation()
        {
            _localRegisterChanges.Clear();
            _localSyscalls.Clear();
            _localMemoryChanges.Clear();
        }

        private void LocalOnRegisterChange(string name, byte[] value)
        {
            if(PostergateCallbacks)
            {
                _localRegisterChanges.Add((name, value));
                return;
            }

            if(onRegisterChange != null)
                onRegisterChange(name, value);
        }

        private void LocalOnMemoryChange(int address, byte value)
        {
            if (PostergateCallbacks)
            {
                _localMemoryChanges.Add((address, value));
                return;
            }

            if (onMemoryChange != null)
                onMemoryChange(address, value);
        }

        private void LocalOnSyscall(int code, byte[] value)
        {
            if (PostergateCallbacks)
            {
                _localSyscalls.Add((code, value));
                return;
            }

            if (onSyscall != null)
                onSyscall(code, value);
        }
    }
}
