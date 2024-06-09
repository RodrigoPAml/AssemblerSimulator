namespace AssemblerEmulator
{
    /// <summary>
    /// Represents a memory operation
    /// </summary>
    public enum MemoryOperationEnum
    {
        LoadWord,  // lw reg1 integer reg2 -> reg1 = memory[reg2 + integer]
        StoreWord, // sw reg1 integer reg2 -> memory[reg2 + integer] = reg1
        LoadByte,  // lb reg1 integer reg2 -> reg1 = memory[reg2 + integer]
        StoreByte, // sb reg1 integer reg2 -> memory[reg2 + integer] = reg1

        LoadByteRegister, // lbr reg1 hex_value -> load hex_value into reg1
        LoadCharRegister, // lcr reg1 char(ASCII) -> load char into reg1
        LoadIntRegister, // lir reg1 integer -> load integer into reg1
        LoadFloatRegister, // lfr reg1 float -> load float into reg1

        Move, // move reg1 reg2 -> reg1 = reg2
        ConvertFloatInt, // cfi reg1 reg2 -> reg1 = (float)reg2
        ConvertIntFloat, // cif reg1 reg2 -> reg1 = (int)reg2
    }
}
