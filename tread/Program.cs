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
        private static object index;
        private static object thread;

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

            var list = new List<Thread>();
            //qui creiamo ed eseguiamo cinque worker thread for (int index=0; index <5; index++)

            {
                var myThread = new Thread((currentIndex) =>
                {
                    Console.WriteLine("Thread {0} è iniziato", currentIndex);
                    Thread.Sleep(500);
                    Console.WriteLine("Thread {0} è terminato", currentIndex);
                });
                myThread.Start(index);
                list.Add(myThread);
            }
            //Attesa del completamento di ognuno dei worker thread 
            foreach (Thread thread in list)
           
            {
                thread.Join();
            }
            Console.WriteLine("Esecuzione di tutti i thread terminata");
            //Attesa di massimo un secondo thread.join(1000);
            Thread workerThread = new Thread(() =>
            {
                Console.WriteLine("inizio di un thread molto lungo");
                Thread.Sleep(5000);
                Console.WriteLine("Termine workwe thread");

            });
            workerThread.Start();
            workerThread.Join(500);

            //se i worker thread è ancora in esecuzione lo si cancella 
            if (workerThread.ThreadState != ThreadState.Stopped)
            {
                workerThread.Abort();
            }
            Console.WriteLine("Termine applicazione");

            var workerThread = new Thread(() =>
            {
                try
                {
                    Console.WriteLine("Inizio di un thread molto lungo");
                    Thread.Sleep(5000);
                    Console.WriteLine("Termine worker thread ");

                }
                catch (ThreadAbortException ex)
                {
                    //qui codice per gestire l'eccezione
                }

            });

            workerThread.IsBackground = false; workerThread.Priority = ThreadPriority.Lowest;
            Console.ReadLine();
        }
        
    }
}
