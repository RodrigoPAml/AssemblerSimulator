namespace AssemblerSimulator
{
    /// <summary>
    /// Represents a register
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Register name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Register Value
        /// </summary>
        public byte[] Value { get; private set; }

        /// <summary>
        /// Register value casted as integer
        /// </summary>
        public int IntValue { get; private set; }

        /// <summary>
        /// Register value casted as float
        /// </summary>
        public float FloatValue { get; private set; }

        /// <summary>
        /// Register size in bits
        /// </summary>
        public int Size => Value.Length * 4;

        public Register(string name, byte[] value)
        {
            Name = name;
            Value = value;
            IntValue = BitConverter.ToInt32(Value);
            FloatValue = BitConverter.ToSingle(Value);
        }

        public Register(string name, int value)
        {
            Name = name;
            SetValue(value);    
        }

        /// <summary>
        /// Set register value
        /// </summary>
        public void SetValue(int value)
        {
            Value = BitConverter.GetBytes(value);
            IntValue = value;
            FloatValue = value;
        }

        /// <summary>
        /// Set register value
        /// </summary>
        public void SetValue(float value)
        {
            Value = BitConverter.GetBytes(value);
            FloatValue = value;
            IntValue = (int)value;
        }

        /// <summary>
        /// Set register value
        /// </summary>
        public void SetValue(byte value)
        {
            Value[0] = value;
            IntValue = BitConverter.ToInt32(Value);
            FloatValue = BitConverter.ToSingle(Value);
        }

        /// <summary>
        /// Set register value
        /// </summary>
        public void SetValue(byte[] value)
        {
            Value = value;
            IntValue = BitConverter.ToInt32(Value);
            FloatValue = BitConverter.ToSingle(Value);
        }

        /// <summary>
        /// Get register value in int32 format
        /// </summary>
        /// <returns></returns>
        public int GetIntValue()
        {
            return IntValue;
        }

        /// <summary>
        /// Get register value in float format
        /// </summary>
        /// <returns></returns>
        public float GetFloatValue()
        {
            return FloatValue;
        }
    }
}
