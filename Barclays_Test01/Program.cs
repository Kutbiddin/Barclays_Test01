using System;
using System.IO;

namespace Barclays_Test01
{
    class Program
    {
        static void Main(string[] args)
        {
            string tmp;
            string[] lines1 = System.IO.File.ReadAllLines(@"C:\Users\Kudya\Desktop\EncodedMessage.txt");
            string klic = "QVH";
            string[] separators = { "#" };
            string path = @"C:\Users\Kudya\Desktop\DecodeMessage.txt";
            

            for (int i = 0; i < lines1.Length; i++)
            {
                string[] words = lines1[i].Split(separators, StringSplitOptions.None);
                string left = words[0];
                string right = words[2];
                string line = lines1[i];

                if (left == klic)
                { 
                    var rightChars = right.ToCharArray();
                    Array.Reverse(rightChars);
                    string rightReversed = string.Join("", rightChars);

                    line.Replace(right, rightReversed);
                    lines1[i] = line;

                    klic = rightReversed;
                    tmp = words[1];
                    Console.Write(tmp);

                    StreamWriter writer = new StreamWriter(path,true);
                    string tmp1 = tmp;
                        writer.Write(tmp1);
                        writer.Close();
                    i = -1;
                    continue;
                }

                /*for (int i = 0; i < lines1.Length; i++) // string line in lines1)
                {
                    string[] words = lines1[i].Split(separators, StringSplitOptions.None);
                    string left = words[0];
                    string right = words[2];
                    char[] charArray = right.ToCharArray();
                    Array.Reverse(charArray);
                    if (left == klic)
                    {
                        klic = new string(charArray);
                        tmp = words[1];
                        Console.WriteLine(tmp);
                    }
                    else i = 0;


                }*/
            }

        }
    }
}

