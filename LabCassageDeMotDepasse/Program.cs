using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LabCassageDeMotDepasse
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string ComputeHash(string input, HashAlgorithm algorithm)
            {
                Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

                return BitConverter.ToString(hashedBytes);
            }

            String line;
            try
            {
                StreamReader sr = new StreamReader("F:\\Projects\\LabCassageDeMotDepasse\\input.txt");
                line = sr.ReadLine();
                StreamWriter sw = new StreamWriter("F:\\Projects\\LabCassageDeMotDepasse\\output.txt");
                while (line != null)
                {
                    string hPassword = ComputeHash(line, new SHA256CryptoServiceProvider());
                    sw.WriteLine(hPassword);
                    line = sr.ReadLine();
                }
                sr.Close();
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Exécution terminée");
            }
        }
    }
}
