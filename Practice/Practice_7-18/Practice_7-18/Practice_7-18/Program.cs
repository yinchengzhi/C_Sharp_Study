using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice_7_18
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder greetingBuilder = new StringBuilder("Hello from all the guys at Wrox Press. ", 150);
            greetingBuilder.AppendFormat("We do hope you enjoy this book as much as we " + "enjoyed writing it");

            Console.WriteLine("Not Encoded:\n" + greetingBuilder);

            for(int i = 'z'; i >= 'a'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(old1, new1);
            }

            for(int i = 'Z'; i >= 'A'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(old1, new1);
            }
            Console.WriteLine("Encoded:\n" + greetingBuilder);
   


            double d = 13.45;
            int j = 45;
            Console.WriteLine("The double is {0,10:E} and the int contains {1}", d, j);
            Console.Read();

        }
    }
}
