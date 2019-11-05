using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace tread
{
    class Program
    {
        public static void Main(string[] args)
        {
            Thread mythread = new Thread(() =>
             {
                 Console.WriteLine("MyThread è iniziato");
                 Thread.Sleep(1000);
                 Console.WriteLine("MyThread è terminato");

             });

            //Esecuzione myThread
            mythread.Start();

            Thread.Sleep(500);
            Console.WriteLine("Main Thread");
            string someVariabile = "Matteo Tumiati";

            var workerThread = new Thread((o) =>
            {
                Console.WriteLine($"Saluti da: {someVariabile}");

            });

            workerThread.Start();
            someVariabile = "Daniele Bocchicchio";




            Console.ReadLine();
        }
        
    }
}
