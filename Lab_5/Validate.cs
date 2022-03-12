using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab_5
{
    /// <summary>
    /// Validate class.
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Ints the validate key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool IntValidateKey(string key)
        {
            try
            {
                int.Parse(key);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
