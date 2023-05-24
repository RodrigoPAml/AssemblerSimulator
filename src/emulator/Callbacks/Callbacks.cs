namespace AssemblerEmulator
{
    /// <summary>
    /// Callbacks to notify changes in the emulator
    /// </summary>
    public delegate void OnRegisterChange(string name, byte[] value);
    public delegate void OnMemoryChange(int address, byte value);
    public delegate void OnSyscall(int code, byte[] value);
}
