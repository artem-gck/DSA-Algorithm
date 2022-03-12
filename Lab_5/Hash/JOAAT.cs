using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Hash
{
    /// <summary>
    /// JOAAT class.
    /// </summary>
    public static class JOAAT
    {
        /// <summary>
        /// Hashes the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static uint Hash(string input)
        {
            uint hash = 0;

            foreach (var item in input)
            {
                var byte_of_data = (byte)item;

                hash += byte_of_data;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;
            
            return hash;
        }
    }
}
