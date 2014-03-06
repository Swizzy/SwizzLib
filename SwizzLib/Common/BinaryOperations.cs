namespace SwizzLib.Common {
    using System;

    public static class BinaryOperations {
        public static ulong Swap(ulong x) { return x << 56 | x << 40 & 0xff000000000000 | x << 24 & 0xff0000000000 | x << 8 & 0xff00000000 | x >> 8 & 0xff000000 | x >> 24 & 0xff0000 | x >> 40 & 0xff00 | x >> 56; }

        public static uint Swap(uint x) { return (x & 0x000000FF) << 24 | (x & 0x0000FF00) << 8 | (x & 0x00FF0000) >> 8 | (x & 0xFF000000) >> 24; }

        public static ushort Swap(ushort x) { return (ushort) ((0xFF00 & x) >> 8 | (0x00FF & x) << 8); }

        public static int CountSetBits(ulong x) {
            int count;
            for (count = 0; x > 0; count++)
                x &= x - 1;
            return count;
        }

        public static int CountByteInstance(ref byte[] data, byte instance, int offset = 0, int length = -1) {
            if (length <= 0)
                length = data.Length - offset;
            var count = 0;
            for (var i = offset; i < length - offset; i++) {
                if (data[i] == instance)
                    count++;
            }
            return count;
        }

        public static bool CompareByteArrays(ref byte[] a1, ref byte[] a2, int index = 0, int length = -1) {
            if (a1 == a2)
                return true; // Nothing to compare, they're the same instance!
            if (a1 == null || a2 == null || a1.Length == 0 || a2.Length == 0)
                throw new ArgumentException("a1 and a2 must not be a null reference nor a reference to a 0 byte array!");
            if (length <= 0) {
                if (a1.Length != a2.Length)
                    throw new ArgumentException("a1 and a2 must be the same length");
                length = a1.Length - index;
            }
            if (a1.Length < index + length || a2.Length < index + length)
                throw new ArgumentOutOfRangeException();
            for (var i = index; i < index + length; i++) {
                if (a1[i] != a2[i])
                    return false; // They're not equal
            }
            return true;
        }

        #region LittleEndian

        public static ushort Little16(ushort x) { return !BitConverter.IsLittleEndian ? Swap(x) : x; }

        public static ushort Little16(byte[] data, int offset = 0) { return Little16(ref data, offset); }

        public static ushort Little16(ref byte[] data, int offset = 0) { return Little16(BitConverter.ToUInt16(data, offset)); }

        public static uint Little32(uint x) { return !BitConverter.IsLittleEndian ? Swap(x) : x; }

        public static uint Little32(byte[] data, int offset = 0) { return Little32(ref data, offset); }

        public static uint Little32(ref byte[] data, int offset = 0) { return Little32(BitConverter.ToUInt32(data, offset)); }

        public static ulong Little64(ulong x) { return !BitConverter.IsLittleEndian ? Swap(x) : x; }

        public static ulong Little64(byte[] data, int offset = 0) { return Little64(ref data, offset); }

        public static ulong Little64(ref byte[] data, int offset = 0) { return Little64(BitConverter.ToUInt64(data, offset)); }

        #endregion

        #region BigEndian

        public static ushort Big16(ushort x) { return BitConverter.IsLittleEndian ? Swap(x) : x; }

        public static ushort Big16(byte[] data, int offset = 0) { return Big16(ref data, offset); }

        public static ushort Big16(ref byte[] data, int offset = 0) { return Big16(BitConverter.ToUInt16(data, offset)); }

        public static uint Big32(uint x) { return BitConverter.IsLittleEndian ? Swap(x) : x; }

        public static uint Big32(byte[] data, int offset = 0) { return Big32(ref data, offset); }

        public static uint Big32(ref byte[] data, int offset = 0) { return Big32(BitConverter.ToUInt32(data, offset)); }

        public static ulong Big64(ulong x) { return BitConverter.IsLittleEndian ? Swap(x) : x; }

        public static ulong Big64(byte[] data, int offset = 0) { return Big64(ref data, offset); }

        public static ulong Big64(ref byte[] data, int offset = 0) { return Big64(BitConverter.ToUInt64(data, offset)); }

        #endregion

    }
}