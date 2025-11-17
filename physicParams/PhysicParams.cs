namespace sandbox_csharp.physicParams;

class LengthParam(double value)
{
    public double Value { get; private set; } = value;


    public static TimeParam operator /(LengthParam a, SpeedParam b)
    {
        return new TimeParam(a.Value / b.Value);
    }

    public static SpeedParam operator /(LengthParam a, TimeParam b)
    {
        return new SpeedParam(a.Value / b.Value);
    }
}

class SpeedParam(double value)
{
    public double Value { get; private set; } = value;
}

class TimeParam(double value)
{
    public double Value { get; private set; } = value;

    public static LengthParam operator *(TimeParam a, SpeedParam b)
    {
        return new LengthParam(a.Value * b.Value);
    }
}

enum PhysicType
{
    LENGTH,
    SPEED,
    ACCELERATION,
    TIME
}



