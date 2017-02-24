using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DTAReadable
{
    class Program
    {
        static void Main(string[] args)
        {
            S();
        }

        static void S()
        {
            StreamReader objInput = new StreamReader("C:/Users/Dennis/Documents/GitHub/DTA-Readable/bd.dta", System.Text.Encoding.Default);
            string contents = objInput.ReadToEnd().Trim();
            string[] split = Regex.Split(contents, "\\s+", RegexOptions.None);
            foreach (string s in split)
            {
                Console.WriteLine(s);
            }
        }

        static void R()
        {
            // 1.
            using (BinaryReader b = new BinaryReader(File.Open("C:/Users/Dennis/Documents/GitHub/DTA-Readable/bd.dta", FileMode.Open)))
            {
                // 2.
                // Position and length variables.
                int pos = 0;
                // 2A.
                // Use BaseStream.
                int length = (int)b.BaseStream.Length;
                while (pos < length)
                {
                    // 3.
                    // Read integer.
                    try
                    {
                        Console.WriteLine(b.ReadInt32());
                        Console.WriteLine("/");
                    }
                    catch { }
                    try
                    {
                        Console.WriteLine(b.Read());
                        Console.WriteLine("/");

                    }
                    catch { }
                    try
                    {
                        Console.WriteLine(b.ReadString());
                        Console.WriteLine("/");

                    }
                    catch { }
                    try
                    {
                        Console.WriteLine(b.ReadChar());
                        Console.WriteLine("/");
                    }
                    catch { }
                    try
                    {
                        Console.WriteLine(b.ReadChars(1000));
                        Console.WriteLine("/");

                    }
                    catch { }


                    // 4.
                    // Advance our position variable.
                    pos += sizeof(int);
                }

                Console.ReadKey();
            }
        }
    }
}
