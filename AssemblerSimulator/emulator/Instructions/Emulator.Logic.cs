namespace AssemblerEmulator
{
    public partial class Emulator
    {
        /// <summary>
        /// Contains the main logic operation instructions implementations
        /// </summary>
        private void Logic(string registerD, string registerL, string registerR, LogicOperationEnum op)
        {
            byte[] value = null;

            switch(op)
            {
                case LogicOperationEnum.And:
                    value = ByteAnd(GetRegister(registerL).Value, GetRegister(registerR).Value);
                    break;
                case LogicOperationEnum.Or:
                    value = ByteOr(GetRegister(registerL).Value, GetRegister(registerR).Value);
                    break;
                case LogicOperationEnum.Xor:
                    value = ByteXor(GetRegister(registerL).Value, GetRegister(registerR).Value);
                    break;
                case LogicOperationEnum.ShiftLeft:
                    value = ByteShiftLeft(GetRegister(registerL).Value, GetRegister(registerR).GetIntValue());
                    break;
                case LogicOperationEnum.ShiftRight:
                    value = ByteShiftRight(GetRegister(registerL).Value, GetRegister(registerR).GetIntValue());
                    break; 
                case LogicOperationEnum.Not:
                    value = ByteNot(GetRegister(registerL).Value);
                    break;
            }

            var regD = GetRegister(registerD);

            regD.SetValue(value);

            if (_onRegisterChange != null)
                _onRegisterChange(registerD, regD.Value);
        }

        private byte[] ByteAnd(byte[] arr1, byte[] arr2)
        {
            byte[] result = new byte[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
                result[i] = (byte)(arr1[i] & arr2[i]);

            return result;
        }

        private byte[] ByteOr(byte[] arr1, byte[] arr2)
        {
            byte[] result = new byte[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
                result[i] = (byte)(arr1[i] | arr2[i]);

            return result;
        }

        private byte[] ByteXor(byte[] arr1, byte[] arr2)
        {
            byte[] result = new byte[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
                result[i] = (byte)(arr1[i] ^ arr2[i]);

            return result;
        }

        private byte[] ByteNot(byte[] arr)
        {
            byte[] result = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                result[i] = (byte)(~arr[i]);

            return result;
        }

        private byte[] ByteShiftLeft(byte[] arr, int n)
        {
            byte[] result = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                result[i] = (byte)(arr[i] << n);

            return result;
        }

        private byte[] ByteShiftRight(byte[] arr, int n)
        {
            byte[] result = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                result[i] = (byte)(arr[i] >> n);

            return result;
        }
    }
}
