namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = new System.TimeSpan(0, 0, 1);
            timer.OnTick += OnTick;
            timer.Start();
        }

        static void OnTick(object sender, TimerTickEventArgs args)
        {
            System.Console.WriteLine("1 second elapsed");
        }
    }
}
