namespace Concurrency;

public class BankLockDemo
{
    public static void BankDemo()
    {
        for (var i = 0; i < 42; i++)
        {
            var vasya = new BankAccount("Vasya") {Rubles = 100};            
            var petya = new BankAccount("Petya");
            var sasha = new BankAccount("Sasha");

            var thread1 = StartBckThread(() =>
            {
                SendMoney(vasya, petya, 100);
            });
                
            var thread2 = StartBckThread(() =>
            {
                SendMoney(vasya, sasha, 100);
            });

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"ATTEMPT #{i:00}: {vasya}, {petya}, {sasha}");
        }
    }
    
    private static void SendMoney(BankAccount from, BankAccount to, long value)
    {
        if (from.Rubles >= value)
        {
            Thread.Sleep(new Random().Next(0, 100));
            from.Rubles -= value;
            to.Rubles += value;
            Console.WriteLine($"Transaction completed: {from.OwnerName} -> {to.OwnerName}: {value}");
        }
        else
        {
            Console.WriteLine($"Transaction rejected: {from.OwnerName}, нужно больше золота!");
        }
    }
    
    private static Thread StartBckThread(Action action)
    {
        var thread = new Thread(() => action())
        {
            IsBackground = true
        };

        thread.Start();
            
        return thread;
    }
}