using Lab_5.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    /// <summary>
    /// AlgorithmsMethods class.
    /// </summary>
    public static class AlgorithmsMethods
    {
        private const string CryptChoose = "1. Get key\n2. Get signature\n3. Validate signature";
        private const string Choice = "Input your choise: ";
        private const string Key = "Input secure key: ";
        private const string InputPath = "Input path to input file: ";
        private const string TrueSignature = "Signature is true";
        private const string FalseSignature = "Signature is false";

        private static (BigInteger a, BigInteger b) signature;
        private static (BigInteger p, BigInteger q, BigInteger y) key;

        /// <summary>
        /// AlGamal method.
        /// </summary>
        /// <returns></returns>
        public static bool DSA()
        {
            Console.WriteLine(CryptChoose);
            var choose = ConsoleValidation.ValidateInt(Choice, 1, 3);

            switch (choose)
            {
                case 1:
                    var pq = KeyManagment.GetPQPurtOfKey();
                    //Console.WriteLine($"p = {pq.p}");
                    //Console.WriteLine($"q = {pq.q}");

                    var x = ConsoleValidation.ValidateInt(Key);
                    key = KeyManagment.GetPublicKeys(pq, x);

                    Console.WriteLine($"Public key: \np = {key.p}\nq = {key.q}\ny = {key.y}");
                    Console.WriteLine($"Private key: {x}");
                    
                    return true;

                    break;

                case 2:
                    Console.Write(InputPath);
                    var inputPath = Console.ReadLine();

                    x = ConsoleValidation.ValidateInt(Key);

                    signature = FileWorker.SignatureFile(inputPath, key, x);

                    Console.WriteLine(signature);

                    return true;

                    break;

                case 3:

                    Console.Write(InputPath);
                    inputPath = Console.ReadLine();

                    var answer = FileWorker.ValidateFile(inputPath, key, signature);

                    Console.WriteLine(answer ? TrueSignature : FalseSignature);

                    return answer;

                    break;

                default:
                    return false;
            }
        }
    }
}
