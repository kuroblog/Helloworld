﻿
namespace Helloworld.Basic
{
    using System;

    class Program
    {
        private const string Msg = nameof(Helloworld);

        static void Main(string[] args)
        {
            Console.WriteLine(Msg);
            Console.ReadKey();
        }
    }
}
