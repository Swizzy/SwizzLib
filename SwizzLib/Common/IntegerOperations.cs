namespace SwizzLib.Common {
    public static class IntOperations {
        #region GetSmallest

        public static ushort GetSmallest(ushort val1, ushort val2) { return val1 < val2 ? val1 : val2; }

        public static uint GetSmallest(uint val1, uint val2) { return val1 < val2 ? val1 : val2; }

        public static ulong GetSmallest(ulong val1, ulong val2) { return val1 < val2 ? val1 : val2; }

        public static short GetSmallest(short val1, short val2) { return val1 < val2 ? val1 : val2; }

        public static int GetSmallest(int val1, int val2) { return val1 < val2 ? val1 : val2; }

        public static long GetSmallest(long val1, long val2) { return val1 < val2 ? val1 : val2; }

        #endregion

        #region GetBiggest

        public static ushort GetBiggest(ushort val1, ushort val2) { return val1 > val2 ? val1 : val2; }

        public static uint GetBiggest(uint val1, uint val2) { return val1 > val2 ? val1 : val2; }

        public static ulong GetBiggest(ulong val1, ulong val2) { return val1 > val2 ? val1 : val2; }

        public static short GetBiggest(short val1, short val2) { return val1 > val2 ? val1 : val2; }

        public static int GetBiggest(int val1, int val2) { return val1 > val2 ? val1 : val2; }

        public static long GetBiggest(long val1, long val2) { return val1 > val2 ? val1 : val2; }

        #endregion
    }
}