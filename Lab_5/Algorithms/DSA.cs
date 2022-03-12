using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Algorithms
{
    /// <summary>
    /// DSA class.
    /// </summary>
    public static class DSA
    {
        /// <summary>
        /// Get signature.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="publicKey"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static (BigInteger r, BigInteger s) GetSignature(BigInteger hash, (BigInteger p, BigInteger q, BigInteger y) publicKey, BigInteger x)
        {
            var g = new BigInteger(2).modPow((publicKey.p - 1) / publicKey.q, publicKey.p);

            var k = BigInteger.genPseudoPrime(500, 10, new Random());

            var r = g.modPow(k, publicKey.p) % publicKey.q;

            var a = (hash + x * r) % publicKey.q;

            var pow = k.modPow(publicKey.q - 2, publicKey.q);
            var s = (a * pow) % publicKey.q;

            if (r == 0 || s == 0)
                return GetSignature(hash, publicKey, x);

            return (r, s);
        }

        /// <summary>
        /// Validate signature.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="publicKey"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static bool ValidateSignature(BigInteger hash, (BigInteger p, BigInteger q, BigInteger y) publicKey, (BigInteger r, BigInteger s) signature)
        {
            var g = new BigInteger(2).modPow((publicKey.p - 1) / publicKey.q, publicKey.p);

            var w = signature.s.modPow(publicKey.q - 2, publicKey.q);
            
            var u1 = (hash * w).modPow(1, publicKey.q);
            var u2 = (signature.r * w).modPow(1, publicKey.q);
            var a = g.modPow(u1, publicKey.p);
            var b = publicKey.y.modPow(u2, publicKey.p);
            var c = (a * b).modPow(1, publicKey.p);
            var v = c.modPow(1, publicKey.q);

            return v == signature.r;
        }
    }
}
