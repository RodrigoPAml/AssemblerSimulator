namespace AssemblerSimulator
{
    /// <summary>
    /// Callbacks to notify changes in the emulator, just used in the front-end
    /// </summary>
    public delegate void OnRegisterChange(string name, byte[] value);
    public delegate void OnMemoryChange(int address, byte value);
    public delegate void OnSyscall(int code, byte[] value);
}
