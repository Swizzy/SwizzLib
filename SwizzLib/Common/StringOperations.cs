namespace SwizzLib.Common {
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public static class StringOperations {
        private static readonly char[] HexCharTable = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        public static string ArrayToHex(ref byte[] data, int index = 0, int length = -1) {
            if (length == -1)
                length = data.Length;
            else
                length = length + index;
            if (data.Length < index + length)
                throw new ArgumentOutOfRangeException();
            var c = new char[(length - index) * 2];
            for (var p = 0; index < length; index++) {
                c[p++] = HexCharTable[data[index] / 0x10];
                c[p++] = HexCharTable[data[index] % 0x10];
            }
            return new string(c);
        }

        public static byte[] HexToArray(string input) {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input can't be nothing!");
            input = StripNonHex(input);
            if (input.Length % 2 > 0)
                throw new ArgumentException("Input must be dividable by 2!");
            var ret = new byte[input.Length / 2];
            for (var i = 0; i < input.Length; i += 2)
                ret[i / 2] = byte.Parse(input.Substring(i, 2), NumberStyles.HexNumber);
            return ret;
        }

        public static bool StringIsHex(string input) { return Regex.IsMatch(input, "^[0-9A-Fa-f]+$"); }

        public static string StripNonHex(string input) { return Regex.Replace(StripHexIdentifier(input), "[^A-Fa-f0-9]", ""); }

        public static string StripHexIdentifier(string input) { return Regex.Replace(input, "^0x", ""); }

        public static bool IsIPv4(string input) { return Regex.IsMatch(input, "^([0-9]{1,3}\\.){3}[0-9]{1,3}$"); }

        public static bool IsMacAddress(string input) { return Regex.IsMatch(input, "^([0-9a-fA-F]{2}\\:){4}[0-9a-fA-F]{2}$"); }
    }
}