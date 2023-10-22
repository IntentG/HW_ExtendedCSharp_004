namespace ConsoleApp4
{
    public interface IBits
    {
        bool GetBit(int i);
        void SetBit(bool bit, int index);

    }

    public class Bits : IBits
    {
        private ulong bits;


        public Bits(ulong bits)
        {
            this.bits = bits;
        }

        public static implicit operator Bits(long value)
        {
            return new Bits((ulong)value);
        }

        public static implicit operator Bits(int value)
        {
            return new Bits((ulong)value);
        }

        public static implicit operator Bits(byte value)
        {
            return new Bits((ulong)value);
        }

        public long Value { get; set; } = 0;
        private int MaxBitsCount { get; set; }

        public override string ToString()
        {
            return bits.ToString();
        }

        public bool GetBit(int index)
        {
            if (index > MaxBitsCount || index < 0)
            {
                Console.WriteLine($"Выход за пределы от 0 до {MaxBitsCount}");
                return false;
            }

            return ((Value >> index) & 1) == 1;
        }

        public void SetBit(bool bit, int index)
        {
            if (index > MaxBitsCount || index < 0)
            {
                Console.WriteLine($"Выход за пределы от 0 до {MaxBitsCount}");
                return;
            }
            if (bit == true)
                Value = (byte)(Value | (1 << index));
            else
            {
                var mask = (byte)(1 << index);
                mask = (byte)(0xff ^ mask);
                Value &= (byte)(Value & mask);
            }


        }


        static void Main()
        {
            long lValue = 128;
            int iValue = 128;
            byte bValue = 128;

            Bits bitsFromLong = lValue;
            Bits bitsFromInt = iValue;
            Bits bitsFromByte = (byte)bValue;

            Console.WriteLine(bitsFromLong);
            Console.WriteLine(bitsFromInt);
            Console.WriteLine(bitsFromByte);

        }
    }
}