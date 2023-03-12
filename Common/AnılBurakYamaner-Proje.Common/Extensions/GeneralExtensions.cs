using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Extensions
{
    public static class GeneralExtensions
    {
        public static long ToUnixTime(this DateTime date)
        {
            long unixTimeStamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimeStamp /= TimeSpan.TicksPerSecond;
            return unixTimeStamp;
        }

        public static string Encrypt(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var encodeStr = UrlBase64.Encode(bytes);

            if (!string.IsNullOrEmpty(encodeStr))
            {
                return encodeStr;
            }
            return str;
        }

        public static string Decrypt(this string str)
        {
            var decoded = UrlBase64.Decode(str);

            var decrypted = Encoding.UTF8.GetString(decoded);

            if (!string.IsNullOrEmpty(decrypted))
            {
                return decrypted;
            }
            return str;
        }
    }

    #region "URLBASE64 HELPER"
    public static class UrlBase64
    {
        private static readonly char[] TwoPads = { '=', '=' };

        public static string Encode(byte[] bytes, PaddingPolicy padding = PaddingPolicy.Discard)
        {
            var encoded = Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_');
            if (padding == PaddingPolicy.Discard)
            {
                encoded = encoded.TrimEnd('=');
            }

            return encoded;
        }

        public static byte[] Decode(string encoded)
        {
            var chars = new List<char>(encoded.ToCharArray());
            for (int i = 0; i < chars.Count; i++)
            {
                if (chars[i] == '_')
                {
                    chars[i] = '/';
                }
                else if (chars[i] == '-')
                {
                    chars[i] = '+';
                }
            }

            switch (encoded.Length % 4)
            {
                case 2:
                    chars.AddRange(TwoPads);
                    break;
                case 3:
                    chars.Add('=');
                    break;
                default:
                    break;
            }

            var array = chars.ToArray();

            return Convert.FromBase64CharArray(array, 0, array.Length);
        }
    }

    public enum PaddingPolicy
    {
        Discard,
        Preserve
    }
    #endregion
}

