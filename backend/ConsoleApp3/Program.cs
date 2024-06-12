
using System;

class Example
{
    private static Semaphore _pool;
    private static int _padding;
    public static void Main()
    {
        _pool = new Semaphore(0, 3);
        for(int i = 1; i < 5; i++)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Worker));
            t.Start(i);
        }
        Thread.Sleep(500);
        Console.WriteLine("Main thread calls Release(3).");
        _pool.Release(releaseCount: 3);
        Console.WriteLine("Main thread exits.");
    }

    private static void Worker(object num)
    {
        Console.WriteLine("Thread {0} begins and waits for the semaphore.");
        _pool.WaitOne();
        int padding = Interlocked.Add(ref _padding, 100);
        Console.WriteLine("Thread {0} enters the semaphore.", num);
        Thread.Sleep(1000 + padding);
        Console.WriteLine("Thread {0} releases the semaphore.", num);
        Console.WriteLine("Thread {0} previous semaphore count: {1}",
            num, _pool.Release());
    }
}