using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public static class ValidationMethods
    {
        public static bool IsHaveDigit(string str)
        {
            foreach (var symbol in str)
            {
                if (Char.IsDigit(symbol))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsHaveLowerCase(string str)
        {
            foreach (var symbol in str)
            {
                if (!Char.IsUpper(symbol))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsHaveUpperCase(string str)
        {
            foreach (var symbol in str)
            {
                if (Char.IsUpper(symbol))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
