namespace AssemblerEmulator
{
    /// <summary>
    /// Represents an arithmetic operation
    /// </summary>
    public enum ArithmeticOperationEnum
    {
        Add, // add reg1 reg2 reg3 -> reg1 = reg2 + reg3
        AddImmediate, // addi reg1 reg2 integer -> reg1 = reg2 + integer
        Subtract, // sub reg1 reg2 reg3 -> reg1 = reg2 - reg3
        SubtractImmediate, // subi reg1 reg2 integer -> reg1 = reg2 - integer
        Divide, // div reg1 reg2 reg3 -> reg1 = reg2 / reg3
        DivideImmediate, // divi reg1 reg2 integer -> reg1 = reg2 / integer
        Multiply, // mul reg1 reg2 reg3 -> reg1 = reg2 * reg3
        MultiplyImmediate, // muli reg1 reg2 integer -> reg1 = reg2 * integer

        AddFloat, // addf reg1 reg2 reg3 -> reg1 = reg2 + reg3
        AddFloatImmediate, // addfi reg1 reg2 float =-> reg1 = reg2 + float
        SubtractFloat, // subf reg1 reg2 reg3 -> reg1 = reg2 - reg3
        SubtractFloatImmediate, // subfi reg1 reg2 float -> reg1 = reg2 - float
        DivideFloat, // divf reg1 reg2 reg3 -> reg1 = reg2 / reg3
        DivideFloatImmediate, // divfi reg1 reg2 float -> reg1 = reg2 / float
        MultiplyFloat, // mulf reg1 reg2 reg3 -> reg1 = reg2 * reg3
        MultiplyFloatImmediate, // mulfi reg1 reg2 float -> reg1 = reg2 * float

        SetEqual, // se reg1 reg2 reg3 -> set reg1 as one if reg2 equals reg3 content, else set zero
        SetNotEqual, // sne reg1 reg2 reg3 -> set reg1 as one if reg2 not equals reg3 content, else set zero

        SetLessThan, // slt reg1 reg2 reg3 -> set reg1 as one if reg2 < reg3 (int comparision) else set zero
        SetGreaterThan, // sgt reg1 reg2 reg3 -> set reg1 as one if reg2 > reg3 (int comparision) else set zero
        SetLessThanOrEqual, // slte reg1 reg2 reg3 -> set reg1 as one if reg2 <= reg3 (int comparision) else set zero
        SetGreaterThanOrEqual, // sgte reg1 reg2 reg3 -> set reg1 as one if reg2 >= reg3 (int comparision) else set zero

        SetLessThanFloat, // sltf reg1 reg2 reg3 -> set reg1 as one if reg2 < reg3 (float comparision) else set zero
        SetGreaterThanFloat, // sgtf reg1 reg2 reg3 -> set reg1 as one if reg2 > reg3 (float comparision) else set zero
        SetLessThanOrEqualFloat, // sltef reg1 reg2 reg3 -> set reg1 as one if reg2 <= reg3 (float comparision) else set zero
        SetGreaterThanOrEqualFloat, // sgtef reg1 reg2 reg3 -> set reg1 as one if reg2 >= reg3 (float comparision) else set zero
    }
}
