using System;
using System.Threading;

    public class Example
    {
        public class Worker
        {
        public bool Screwdriver { get; set; }

        public bool Wrench { get; set; }

        public void Assemble(ProductionLine line)
        {
            line.Assemble();
        }
    }

    public class ProductionLine
    {
        public int assemblyTime { get; set; }
        public int productionTime { get; set; }
        public int quota { get; set; }
        public void Assemble()
        {
            this.quota--;
            this.productionTime -= assemblyTime;
        }
    }

    public static void Main()
    {

        Worker worker1 = new Worker();
        Worker worker2 = new Worker();
        Worker worker3 = new Worker();
        Worker worker4 = new Worker();
        ProductionLine productionLine = new ProductionLine
        {
            assemblyTime = 4,
            productionTime = 1110,
            quota = 230
        };

        worker1.Screwdriver = true;
        worker1.Wrench = false;
        worker2.Screwdriver = false;
        worker2.Wrench = true;
        worker3.Screwdriver = true;
        worker3.Wrench = false;
        worker4.Screwdriver = false;
        worker4.Wrench = true;


        // Queue the task.
        ThreadPool.QueueUserWorkItem(ThreadProc);
        Thread.Sleep(1000);

        Console.WriteLine("Main thread exits.");
    }

    // This thread procedure performs the task.
    static void ThreadProc(Object stateInfo)
    {
        // No state object was passed to QueueUserWorkItem, so stateInfo is null.
        
    }
}