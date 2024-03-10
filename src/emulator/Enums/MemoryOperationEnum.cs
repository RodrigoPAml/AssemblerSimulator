namespace AssemblerEmulator
{
    /// <summary>
    /// Represents a memory operation
    /// </summary>
    public enum MemoryOperationEnum
    {
        LoadWord,  // lw reg1 number reg2 -> reg1 = memoria[reg2 + number]
        StoreWord, // sw reg1 number reg2 -> memoria[reg2 + number] = reg1
        LoadByte,  // lb reg1 number reg2 -> reg1 = memoria[reg2 + number]
        StoreByte, // sb reg1 number reg2 -> memoria[reg2 + number] = reg1

        LoadByteRegister, // lbr reg1 hex_value
        LoadCharRegister, // lcr reg1 char(ASCII)
        LoadIntRegister, // lir reg1 int
        LoadFloatRegister, // lfr reg1 float

        Move, // move reg1 reg2 -> reg1 = reg2
        ConvertFloatInt, // cfi reg1 reg2 -> reg1 = (float)reg2
        ConvertIntFloat, // cif reg1 reg2 -> reg1 = (int)reg2
    }
}
