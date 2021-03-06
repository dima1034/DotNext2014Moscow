﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo2.AsyncVoid
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Main method is not allowed to be async
                MainAsync().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured: " + e.ToString());
            }
        }

        private async static Task MainAsync()
        {
            Console.WriteLine("Started");
            try
            {
                DelayAndThrowAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured: " + e.Message);
            }
            Console.WriteLine("Finished");

            // waiting for exception to be thrown
            await Task.Delay(1000);
        }

        private async static void DelayAndThrowAsync()
        {
            await Task.Delay(100);
            throw new InvalidOperationException();
        }
    }
}
