namespace AssemblerEmulator
{
    /// <summary>
    /// Represents a control flow operation
    /// </summary>
    public enum ControlFlowOperationEnum
    {
        Jump, // j label -> go to instruction at address of label
        JumpAndLink, // jal label -> go to instruction at address of label, and save previous address+1 at ra
        
        JumpRegister, // jr register -> go to instruction at address contained in register
        
        BranchEqual, // beq reg1 reg2 label -> if reg1 and reg2 are same bytes go to address of label
        BranchNotEqual, // beq reg1 reg2 label -> if reg1 and reg2 are same bytes go to address of label
    }
}
