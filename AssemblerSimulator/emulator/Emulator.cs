using System.Globalization;

namespace AssemblerSimulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Instructions (or memory instruction)
        /// </summary>
        private List<string> _instructions = new();

        /// <summary>
        /// Label in the code (reference to an address)
        /// </summary>
        private Dictionary<string, int> _labels = new();

        /// <summary>
        /// Registers
        /// </summary>
        private Dictionary<string, Register> _registers = new();

        /// <summary>
        /// The program main memory
        /// </summary>
        private List<byte> _memory = new();

        /// <summary>
        /// The program counter
        /// </summary>
        private int ProgramCounter => GetRegister("pc").GetIntValue();

        /// <summary>
        /// The program counter in hexadecimal format
        /// </summary>
        private string ProgramCounterAdrress => $"0x{string.Join("", GetRegister("pc").Value.Select(x => string.Format("{0:X2}", x)))}";

        /// <summary>
        /// Return a copy of the memory
        /// </summary>
        /// <returns></returns>
        public List<byte> GetMemory() => new List<byte>(_memory);

        /// <summary>
        /// Return a copy of the registers
        /// </summary>
        /// <returns></returns>
        public List<Register> GetRegisters() => _registers.Select(x => new Register(x.Key, x.Value.Value)).ToList();

        /// <summary>
        /// Return if a register exists
        /// </summary>
        private bool RegisterExists(string reg) => _registers.ContainsKey(reg);

        /// <summary>
        /// Return a register
        /// </summary>
        private Register GetRegister(string reg) => _registers[reg];

        public Emulator(OnMemoryChange onMemoryChange, OnRegisterChange onRegisterChange, OnSyscall onSyscall)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            Reset();

            this.onMemoryChange = onMemoryChange;
            this.onRegisterChange = onRegisterChange;
            this.onSyscall = onSyscall;
        }

        /// <summary>
        /// Resets the emulator state
        /// </summary>
        public void Reset()
        {
            ClearPostergation();

            _registers.Clear();
            _memory.Clear();
            _instructions.Clear();
            _labels.Clear();

            _registers.Add("zero", new Register("zero", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("one", new Register("one", 1));

            _registers.Add("s0", new Register("s0", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("s1", new Register("s1", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("s2", new Register("s2", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("s3", new Register("s3", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("s4", new Register("s4", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("s5", new Register("s5", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("s6", new Register("s6", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("s7", new Register("s7", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add("t0", new Register("t0", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t1", new Register("t1", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t2", new Register("t2", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t3", new Register("t3", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t4", new Register("t4", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t5", new Register("t5", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t6", new Register("t6", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t7", new Register("t7", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t8", new Register("t8", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("t9", new Register("t9", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add("a0", new Register("a0", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("a1", new Register("a1", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("a2", new Register("a2", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("a3", new Register("a3", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add("v0", new Register("v0", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("v1", new Register("v1", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add("re", new Register("re", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("ref", new Register("ref", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _registers.Add("sp", new Register("sp", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("ra", new Register("ra", Enumerable.Repeat((byte)0x0, 4).ToArray()));
            _registers.Add("pc", new Register("pc", Enumerable.Repeat((byte)0x0, 4).ToArray()));

            _memory.AddRange(Enumerable.Repeat((byte)0x0, 1_000));
        }

        public void SetCallbacks(OnMemoryChange onMemoryChange, OnRegisterChange onRegisterChange, OnSyscall onSyscall)
        {
            this.onMemoryChange = onMemoryChange;
            this.onRegisterChange = onRegisterChange;
            this.onSyscall = onSyscall;

            ClearPostergation();
        }

        public void RemoveCallbacks()
        {
            onMemoryChange = null;
            onRegisterChange = null;
            onSyscall = null;

            ClearPostergation();
        }

        /// <summary>
        /// Execute all instructions
        /// </summary>
        public void ExecuteAll()
        {
            while (ExecuteLine()) { }
        }

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
                case "addf":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.AddFloat);
                    break;
                case "addi":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.AddImmediate);
                    break;
                case "addfi":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.AddFloatImmediate);
                    break;
                case "sub":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Subtract);
                    break;
                case "subi":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SubtractImmediate);
                    break;
                case "subf":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.SubtractFloat);
                    break;
                case "subfi":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.SubtractFloatImmediate);
                    break;
                case "mul":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Multiply);
                    break;
                case "mulf":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.MultiplyFloat);
                    break;
                case "muli":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.MultiplyImmediate);
                    break;
                case "mulfi":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.MultiplyFloatImmediate);
                    break;
                case "div":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Divide);
                    break;
                case "divi":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.DivideImmediate);
                    break;
                case "divf":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.DivideFloat);
                    break;
                case "divfi":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.DivideFloatImmediate);
                    break;
                case "se":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetEqual);
                    break;
                case "sne":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetNotEqual);
                    break;
                case "slt":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetLessThan);
                    break;
                case "sgt":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetGreaterThan);
                    break;
                case "slte":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetLessThanOrEqual);
                    break;
                case "sgte":
                    Arithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetGreaterThanOrEqual);
                    break;
                case "sltf":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.SetLessThanFloat);
                    break;
                case "sgtf":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.SetGreaterThanFloat);
                    break;
                case "sltof":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.SetLessThanOrEqualFloat);
                    break;
                case "sgtef":
                    ArithmeticFloat(registerD, registerL, registerR, ArithmeticOperationEnum.SetGreaterThanOrEqualFloat);
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
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.LoadWord);
                    break;
                case "sw":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.StoreWord);
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
                case "lcr":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.LoadCharRegister);
                    break;
                case "lbr":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.LoadByteRegister);
                    break;
                case "lfr":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.LoadFloatRegister);
                    break;
                case "lir":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.LoadIntRegister);
                    break;
                case "cfi":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.ConvertFloatInt);
                    break;
                case "cif":
                    Memory(registerD, registerL, registerR, MemoryOperationEnum.ConvertIntFloat);
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
                case "syscall":
                    if (parts.Count != 1)
                        throw new Exception("Invalid syscall format");
                    Syscall();
                    break;
                default:
                    throw new Exception($"Invalid instruction: {operation} in line {programCounter}");
            }

            if (changedPc == false)
            {
                // Increment pc
                programCounter++;

                var regPc = GetRegister("pc");
                regPc.SetValue(programCounter);

                LocalOnRegisterChange(regPc.Name, regPc.Value);
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
                _labels.Add(instruction.Trim(), _instructions.Count-1);
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

        /// <summary>
        /// Validate all instructions
        /// </summary>
        public void ValidateInstructions()
        {
            var pc = GetRegister("pc");
            foreach (string instruction in _instructions)
            {
                ValidateInstruction(instruction);
                pc.SetValue(pc.GetIntValue() + 1);
            }

            pc.SetValue(0);
        }

        /// <summary>
        /// Validate a instruction
        /// </summary>
        /// <param name="instruction"></param>
        /// <exception cref="Exception"></exception>
        private void ValidateInstruction(string instruction)
        {
            List<string> parts = instruction.Split(' ').Where(x => x.Length > 0).ToList();

            if (parts.Count() < 1 || parts.Count > 4)
                throw new Exception($"Invalid instruction: {instruction}");

            string operation = parts[0];
            string registerD = parts.Count() > 1 ? parts[1] : string.Empty;
            string registerL = parts.Count() > 2 ? parts[2] : string.Empty;
            string registerR = parts.Count() > 3 ? parts[3] : string.Empty;

            switch (operation)
            {
                case "add":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Add);
                    break;
                case "addf":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.AddFloat);
                    break;
                case "addi":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.AddImmediate);
                    break;
                case "addfi":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.AddFloatImmediate);
                    break;
                case "sub":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Subtract);
                    break;
                case "subi":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SubtractImmediate);
                    break;
                case "subf":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SubtractFloat);
                    break;
                case "subfi":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SubtractFloatImmediate);
                    break;
                case "mul":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Multiply);
                    break;
                case "mulf":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.MultiplyFloat);
                    break;
                case "muli":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.MultiplyImmediate);
                    break;
                case "mulfi":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.MultiplyFloatImmediate);
                    break;
                case "div":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.Divide);
                    break;
                case "divi":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.DivideImmediate);
                    break;
                case "divf":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.DivideFloat);
                    break;
                case "divfi":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.DivideFloatImmediate);
                    break;
                case "se":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetEqual);
                    break;
                case "sne":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetNotEqual);
                    break;
                case "slt":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetLessThan);
                    break;
                case "sgt":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetGreaterThan);
                    break;
                case "slte":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetLessThanOrEqual);
                    break;
                case "sgte":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetGreaterThanOrEqual);
                    break;
                case "sltf":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetLessThanFloat);
                    break;
                case "sgtf":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetGreaterThanFloat);
                    break;
                case "sltof":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetLessThanOrEqualFloat);
                    break;
                case "sgtef":
                    ValidateArithmetic(registerD, registerL, registerR, ArithmeticOperationEnum.SetGreaterThanOrEqualFloat);
                    break;
                case "and":
                    ValidateLogic(registerD, registerL, registerR, LogicOperationEnum.And);
                    break;
                case "or":
                    ValidateLogic(registerD, registerL, registerR, LogicOperationEnum.Or);
                    break;
                case "xor":
                    ValidateLogic(registerD, registerL, registerR, LogicOperationEnum.Xor);
                    break;
                case "not":
                    ValidateLogic(registerD, registerL, registerR, LogicOperationEnum.Not);
                    break;
                case "sfl":
                    ValidateLogic(registerD, registerL, registerR, LogicOperationEnum.ShiftLeft);
                    break;
                case "sfr":
                    ValidateLogic(registerD, registerL, registerR, LogicOperationEnum.ShiftRight);
                    break;
                case "lw":
                    ValidateMemoryType1(registerD, registerL, registerR, MemoryOperationEnum.LoadWord);
                    break;
                case "sw":
                    ValidateMemoryType1(registerD, registerL, registerR, MemoryOperationEnum.StoreWord);
                    break;
                case "lb":
                    ValidateMemoryType1(registerD, registerL, registerR, MemoryOperationEnum.LoadByte);
                    break;
                case "sb":
                    ValidateMemoryType1(registerD, registerL, registerR, MemoryOperationEnum.StoreByte);
                    break;
                case "lcr":
                    ValidateMemoryType2(registerD, registerL, registerR, MemoryOperationEnum.LoadCharRegister);
                    break;
                case "lbr":
                    ValidateMemoryType2(registerD, registerL, registerR, MemoryOperationEnum.LoadByteRegister);
                    break;
                case "lfr":
                    ValidateMemoryType2(registerD, registerL, registerR, MemoryOperationEnum.LoadFloatRegister);
                    break;
                case "lir":
                    ValidateMemoryType2(registerD, registerL, registerR, MemoryOperationEnum.LoadIntRegister);
                    break;
                case "cfi":
                    ValidateMemoryType3(registerD, registerL, registerR, MemoryOperationEnum.ConvertFloatInt);
                    break;
                case "cif":
                    ValidateMemoryType3(registerD, registerL, registerR, MemoryOperationEnum.ConvertIntFloat);
                    break;
                case "move":
                    ValidateMemoryType3(registerD, registerL, registerR, MemoryOperationEnum.Move);
                    break;
                case "j":
                    ValidadeControlFlowType1(registerD, registerL, registerR, ControlFlowOperationEnum.Jump);
                    break;
                case "jal":
                    ValidadeControlFlowType1(registerD, registerL, registerR, ControlFlowOperationEnum.JumpAndLink);
                    break;
                case "jr":
                    ValidadeControlFlowType2(registerD, registerL, registerR, ControlFlowOperationEnum.JumpRegister);
                    break;
                case "beq":
                    ValidadeControlFlowType3(registerD, registerL, registerR, ControlFlowOperationEnum.BranchEqual);
                    break;
                case "bne":
                    ValidadeControlFlowType3(registerD, registerL, registerR, ControlFlowOperationEnum.BranchNotEqual);
                    break;
                case "syscall":
                    if (parts.Count != 1)
                        throw new Exception("Invalid syscall format");
                    break;
                default:
                    throw new Exception($"Invalid instruction: {instruction}");
            }
        }
    }
}
