using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Algorithms
{
    /// <summary>
    /// KeyManagment class.
    /// </summary>
    public static class KeyManagment
    {
        /// <summary>
        /// Gets the pq purt of key.
        /// </summary>
        /// <returns></returns>
        public static (BigInteger p, BigInteger q) GetPQPurtOfKey()
        {
            var q = BigInteger.genPseudoPrime(720, 10, new Random());

            return (GeyPPurtOfKey(q), q);
        }

        /// <summary>
        /// Gets the public keys.
        /// </summary>
        /// <param name="purtOfPQKey">The purt of pq key.</param>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">x</exception>
        public static (BigInteger p, BigInteger q, BigInteger y) GetPublicKeys((BigInteger p, BigInteger q) purtOfPQKey, BigInteger x)
        {
            x = x < purtOfPQKey.q ? x : throw new ArgumentOutOfRangeException(nameof(x));

            var g = new BigInteger(2).modPow((purtOfPQKey.p - 1) / purtOfPQKey.q, purtOfPQKey.p);
            //var g = Power(2, (p - 1) / q);
            var y = g.modPow(x, purtOfPQKey.p);

            return (purtOfPQKey.p, purtOfPQKey.q, y);
        }

        /// <summary>
        /// Geys the p purt of key.
        /// </summary>
        /// <param name="q">The q.</param>
        /// <returns></returns>
        private static BigInteger GeyPPurtOfKey(BigInteger q)
        {
            var rand = new Random();
            BigInteger p;

            do
            {
                var randNumber = rand.Next() % 100000 + 2;

                p = q * randNumber;

            } while (!(p + 1).isProbablePrime(10));

            return p + 1;
        }
    }
}