namespace AssemblerSimulator
{
    /// <summary>
    /// Represents a logic operation
    /// </summary>
    public enum LogicOperationEnum
    {
        And, // and reg1 reg2 reg3 -> reg1 = reg2 & reg3
        Xor, // xor reg1 reg2 reg3 -> reg1 = reg2 ^ reg3
        Or, // or reg1 reg2 reg3 -> reg1 = reg2 | reg3
        ShiftLeft, // sfl reg1 reg2 reg3 -> reg1 = reg2 << reg3
        ShiftRight, // sfr reg1 reg2 reg3 -> reg1 = reg2 >> reg3
        Not // not reg1 reg2 -> reg1 = ~reg2
    }
}
