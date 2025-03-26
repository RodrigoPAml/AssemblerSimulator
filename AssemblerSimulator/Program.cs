namespace AssemblerSimulator
{
    public class Program
    {
        // Callback quando valor do registrador muda
        public static void OnRegisterChange(string name, byte[] value)
        {
            Console.WriteLine($"{nameof(OnRegisterChange)} {name} {string.Join(" ", value)}");
        }

        // Callback quando memoria muda
        public static void OnMemoryChange(int address, byte value)
        {
            Console.WriteLine($"{nameof(OnMemoryChange)} {address} {value}");
        }

        // Callback para syscall
        public static void OnSyscall(int code, byte[] value)
        {
            Console.WriteLine($"{nameof(OnSyscall)} {code} {string.Join(" ", value)}");
        }

        public static void Main()
        {
            Emulator emulator = new Emulator(OnMemoryChange, OnRegisterChange, OnSyscall);

            emulator.AddInstruction("lir t0 10"); // Carrega valor 10 em t0
            emulator.AddInstruction("sw t0 0 sp");  // Carrega na pilha o valor 10
            
            // Syscall para printar inteiro
            emulator.AddInstruction("addi v0 v0 1");
            emulator.AddInstruction("move a0 t0");
            emulator.AddInstruction("syscall");

            emulator.ValidateInstructions();
            emulator.ExecuteAll();
        }
    }
}