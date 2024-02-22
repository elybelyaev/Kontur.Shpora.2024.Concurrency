
using Concurrency;

Console.WriteLine("before wait all");
TaskDemo.MyWaitAll(Enumerable.Range(0, 10).Select(i => Task.Run(() => { Thread.Sleep(i + 1000); Console.WriteLine(i);})).ToArray());
Console.WriteLine("after wait all");


Console.WriteLine("before when all");
var t = TaskDemo.MyWhenAll(Enumerable.Range(0, 10).Select(i => Task.Run(() => { Thread.Sleep(i + 1000); Console.WriteLine(i);})).ToArray());
Console.WriteLine("after when all");
t.Wait();
Console.WriteLine("after wait when all task");
