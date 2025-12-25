using sandbox_csharp.physicParams;

AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Необработанное исключение: {e.ExceptionObject.ToString()}");
    Console.ResetColor();
    Environment.Exit(1);
};

Length length = new(35, LengthUnits.METER);
Speed speed1 = new(10);
Speed speed2 = new(10);
Length length2 = length / speed1 * speed2;
Console.WriteLine(length2.ToString());
