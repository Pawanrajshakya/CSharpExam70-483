using System;
using System.Threading;

namespace CSharp_70_483
{
    class Program
    {
        [ThreadStatic]
        public static int _Count;
        static void Main(string[] args)
        {
            //ThreadMain();
            ThreadStaticExample();
        }

        static void ThreadStaticExample()
        {
            new Thread(()=>{
                for(int i = 0; i < 10; i++){
                    _Count++;
                    Console.WriteLine("Thread 1 {0}", _Count);
                }
            }).Start();

            new Thread(()=>{
                for(int i = 0; i < 10; i++){
                    _Count--;
                    Console.WriteLine("Thread 2 {0}", _Count);                    
                }
            }).Start();
        }

        static void ThreadMain()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(10);

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Main Thread");
                Thread.Sleep(1);
            }

            t.Join();
        }
        static void ThreadMethod(object j)
        {
            for (int i = 0; i <= (int)j; i++)
            {
                Console.WriteLine("ThreadMethod: {0}", i);
                Thread.Sleep(1);
            }
        }
    }
}
