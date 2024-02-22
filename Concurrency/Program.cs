
using Concurrency;

Console.WriteLine("before wait all");
TaskDemo.MyWaitAll(Enumerable.Range(0, 10).Select(i => Task.Run(() => { Thread.Sleep(i + 1000); Console.WriteLine(i);})).ToArray());
Console.WriteLine("after wait all");