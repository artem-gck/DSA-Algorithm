using Lab_5.Algorithms;
using Lab_5.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    /// <summary>
    /// FileWorker class.
    /// </summary>
    public static class FileWorker
    {
        private const int SizeOfAlphabet = 26;
        private const char FirstLetterOfAlphabetSmall = 'a';
        private const char FirstLetterOfAlphabetBig = 'A';

        /// <summary>
        /// Encrypts the file.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="outputPath">The output path.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static (BigInteger a, BigInteger b) SignatureFile(string inputPath, (BigInteger p, BigInteger q, BigInteger y) key, BigInteger x)
        {
            using var streamReader = new StreamReader(new FileStream(inputPath, FileMode.Open));

            var text = streamReader.ReadToEnd();
            var hash = JOAAT.Hash(text);

            var answer = DSA.GetSignature(hash, key, x);

            return answer;
        }

        /// <summary>
        /// Decrypts the file.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="outputPath">The output path.</param>
        /// <param name="p">The p.</param>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public static bool ValidateFile(string inputPath, (BigInteger p, BigInteger q, BigInteger y) key, (BigInteger a, BigInteger b) signature)
        {
            using var streamReader = new StreamReader(new FileStream(inputPath, FileMode.Open));

            var text = streamReader.ReadToEnd();
            var hash = JOAAT.Hash(text);

            var answer = DSA.ValidateSignature(hash, key, signature);

            return answer;
        }
    }
}
