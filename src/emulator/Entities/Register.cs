using Microsoft.Win32;
using System;

namespace AssemblerEmulator
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
        /// Register size in bits
        /// </summary>
        public int Size => Value.Length * 4;

        public Register(string name, byte[] value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Set register value
        /// </summary>
        public void SetValue(int value)
        {
            Value = BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Set register value
        /// </summary>
        public void SetValue(byte value)
        {
            Value[0] = value;
        }

        /// <summary>
        /// Set register value
        /// </summary>
        public void SetValue(byte[] value)
        {
            Value = value;
        }

        /// <summary>
        /// Get register value in int32 format
        /// </summary>
        /// <returns></returns>
        public int GetValue()
        {
            return BitConverter.ToInt32(Value);
        }
    }
}
