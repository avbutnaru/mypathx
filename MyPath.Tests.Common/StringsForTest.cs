using System;
using System.Linq;

namespace MyPath.Tests.Common
{
    public static class StringsForTest
    {
        public static string RandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }

        public static string FixedString()
        {
            return "ksdfljsdlkjlk";
        }
    }
}