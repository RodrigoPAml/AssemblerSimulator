namespace AssemblerEmulator
{
    /// <summary>
    /// Represents a control flow operation
    /// </summary>
    public enum ControlFlowOperationEnum
    {
        Jump,
        JumpRegister,
        JumpAndLink,
        BranchEqual,
        BranchNotEqual,
        SetLessThan,
        SetGreaterThan,
    }
}
