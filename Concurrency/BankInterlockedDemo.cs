namespace Concurrency;

public static class BankInterlockedDemo
{
    public static void BankDemo()
    {
        static void SendMoney(BankAccount from, BankAccount to, long value)
        {
            if (from.Rubles < value) 
                return;
                
            from.Rubles -= value;
            to.Rubles += value;
        }
            
        for (var i = 0; i < 42; i++)
        {
            var vasya = new BankAccount("Vasya") {Rubles = 100};            
            var petya = new BankAccount("Petya");
            var sasha = new BankAccount("Sasha");

            var thread1 = StartBckThread(() =>
            {
                lock (vasya)
                {
                    lock (petya)
                    {
                        SendMoney(vasya, petya, 100);
                    }
                }
            });
                
            var thread2 = StartBckThread(() =>
            {
                lock (vasya)
                {
                    lock (sasha)
                    {
                        SendMoney(vasya, sasha, 100);
                    }
                }
            });

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"ATTEMPT #{i:00}: {vasya}, {petya}, {sasha}");
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