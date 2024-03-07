namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Instructions (or memory instruction)
        /// </summary>
        private List<string> _instructions = new List<string>();

        /// <summary>
        /// Label in the code (reference to an address)
        /// </summary>
        private Dictionary<string, int> _labels = new Dictionary<string, int>();

        /// <summary>
        /// Registers
        /// </summary>
        private List<Register> _registers = new List<Register>();

        /// <summary>
        /// The program main memory
        /// </summary>
        private List<byte> _memory = new List<byte>();

        /// <summary>
        /// The program counter
        /// </summary>
        private int ProgramCounter => GetRegister("pc").GetValue();

        /// <summary>
        /// The program counter in hexadecimal format
        /// </summary>
        private string ProgramCounterAdrress => $"0x{string.Join("", GetRegister("pc").Value.Select(x => string.Format("{0:X2}", x)))}";

        /// <summary>
        /// Callbacks to notify changes in memory and registers, or syscalls
        /// </summary>
        private OnMemoryChange _onMemoryChange;
        private OnRegisterChange _onRegisterChange;
        private OnSyscall _onSyscall;

        public Emulator(OnMemoryChange onMemoryChange, OnRegisterChange onRegisterChange, OnSyscall onSyscall)
        {
            Reset();

            _onMemoryChange = onMemoryChange;
            _onRegisterChange = onRegisterChange;
            _onSyscall = onSyscall;
        }

        /// <summary>
        /// Resets the emulator state
        /// </summary>
        public void Reset()
        {
            _registers.Clear();
            _memory.Clear();
            _instructions.Clear();
            _labels.Clear();

            _registers.Add(new Register("zero", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add(new Register("s0", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("s1", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("s2", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("s3", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("s4", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("s5", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("s6", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("s7", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add(new Register("t0", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t1", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t2", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t3", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t4", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t5", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t6", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t7", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t8", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("t9", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add(new Register("a0", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("a1", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("a2", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("a3", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add(new Register("v0", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("v1", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add(new Register("re", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("gp", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("sp", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("ra", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add(new Register("pc", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _memory.AddRange(Enumerable.Repeat((byte)0x0, 1_000));

            _registers.Where(x => x.Name == "gp").First().SetValue(999);
        }

        /// <summary>
        /// Return a copy of the memory
        /// </summary>
        /// <returns></returns>
        public List<byte> GetMemory() => new List<byte>(_memory);

        /// <summary>
        /// Return a copy of the registers
        /// </summary>
        /// <returns></returns>
        public List<Register> GetRegisters() => _registers.Select(x => new Register(x.Name, x.Value)).ToList();

        /// <summary>
        /// Return if a register exists
        /// </summary>
        private bool RegisterExists(string reg) => _registers.Any(x => x.Name == reg);

        /// <summary>
        /// Return a register
        /// </summary>
        private Register GetRegister(string reg) => _registers.Where(x => x.Name == reg).FirstOrDefault();

        /// <summary>
        /// Execute one instruction
        /// </summary>
        public bool ExecuteLine()
        {
            int programCounter = ProgramCounter;

            if(programCounter >= _instructions.Count)
                return false;

            string line = _instructions[programCounter];

            List<string> parts = line.Split(' ').Where(x => x.Length > 0).ToList();

            if (parts.Count() < 1 || parts.Count > 4)
                throw new Exception($"Invalid instruction in line {programCounter}");

            string operation = parts[0];
            string registerD = parts.Count() > 1 ? parts[1] : string.Empty;
            string registerL = parts.Count() > 2 ? parts[2] : string.Empty;
            string registerR = parts.Count() > 3 ? parts[3] : string.Empty;
            bool changedPc = false;

            switch (operation)
            {
                case "add":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Add);
                    break;
                case "addi":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.AddImmediate);
                    break;
                case "sub":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Subtract);
                    break;
                case "mul":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Multiply);
                    break;
                case "muli":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.MultiplyImmediate);
                    break;
                case "div":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Divide);
                    break;
                case "and":
                    Logic(registerD, registerL, registerR, LogicOperationEnum.And);
                    break;
                case "or":
                    Logic(registerD, registerL, registerR, LogicOperationEnum.Or);
                    break;
                case "xor":
                    Logic(registerD, registerL, registerR, LogicOperationEnum.Xor);
                    break;
                case "not":
                    Logic(registerD, registerL, registerR, LogicOperationEnum.Not);
                    break;
                case "sfl":
                    Logic(registerD, registerL, registerR, LogicOperationEnum.ShiftLeft);
                    break;
                case "sfr":
                    Logic(registerD, registerL, registerR, LogicOperationEnum.ShiftRight);
                    break;
                case "lw":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.Load);
                    break;
                case "sw":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.Store);
                    break;
                case "lb":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.LoadByte);
                    break;
                case "sb":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.StoreByte);
                    break;
                case "move":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.Move);
                    break;
                case "j":
                    changedPc = ControlFlow(registerD, registerL, registerR, ControlFlowOperationEnum.Jump);
                    break;
                case "jr":
                    changedPc = ControlFlow(registerD, registerL, registerR, ControlFlowOperationEnum.JumpRegister);
                    break;
                case "jal":
                    changedPc = ControlFlow(registerD, registerL, registerR, ControlFlowOperationEnum.JumpAndLink);
                    break;
                case "beq":
                    changedPc = ControlFlow(registerD, registerL, registerR, ControlFlowOperationEnum.BranchEqual);
                    break;
                case "bne":
                    changedPc = ControlFlow(registerD, registerL, registerR, ControlFlowOperationEnum.BranchNotEqual);
                    break;
                case "slt":
                    ControlFlow(registerD, registerL, registerR, ControlFlowOperationEnum.SetLessThan);
                    break;
                case "sgt":
                    ControlFlow(registerD, registerL, registerR, ControlFlowOperationEnum.SetGreaterThan);
                    break;
                case "syscall":
                    if (parts.Count != 1)
                        throw new Exception("Invalid syscall format");
                    Syscall();
                    break;
                default:
                    throw new Exception($"Invalid instruction: {operation} in line {programCounter}");
            }

            if(changedPc == false)
            {
                // Increment pc
                programCounter++;

                var regPc = GetRegister("pc");
                regPc.SetValue(programCounter);

                if (_onRegisterChange != null)
                    _onRegisterChange(regPc.Name, regPc.Value);
            }

            return true;
        }

        /// <summary>
        /// Adds a instruction to be executed
        /// </summary>
        /// <param name="instruction"></param>
        public void AddInstruction(string instruction)
        {
            if (instruction.Contains("--"))
                return;

            if(instruction.Trim().EndsWith(":") && instruction.Trim().Count() >= 2)
                _labels.Add(instruction, _instructions.Count-1);
            else if(instruction.Trim().Count() > 0)
                _instructions.Add(instruction);
        }

        /// <summary>
        /// Add instructions to be executed
        /// </summary>
        /// <param name="instructions"></param>
        public void AddInstructions(List<string> instructions)
        {
            foreach (string instruction in instructions)
                AddInstruction(instruction);
        }
    }
}
