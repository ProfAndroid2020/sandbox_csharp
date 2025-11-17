using sandbox_csharp.physicParams;

LengthParam length = new(50);
SpeedParam speed1 = new(25);
SpeedParam speed2 = new(10);
LengthParam length2 = length / speed1 * speed2;
Console.WriteLine(length2.Value);
