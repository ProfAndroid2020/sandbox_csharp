namespace sandbox_csharp.physicParams;

/// <summary>
/// Класс для физических величин <b>Масса</b>
/// </summary>
class Mass(double value, MassUnits unit = MassUnits.KILOGRAM)
    : PhysicalValue<MassUnits>(value, unit, _ratios)
{
    private static readonly Dictionary<MassUnits, double> _ratios = new()
    {
        // base unit: kilogram
        [MassUnits.KILOGRAM] = 1.0,
        [MassUnits.GRAM] = 1.0 / 1000.0,
        [MassUnits.POUND] = 0.45359237
    };

    protected override string GetUnitName(MassUnits unit) => unit switch
    {
        MassUnits.KILOGRAM => "kg",
        MassUnits.GRAM => "g",
        MassUnits.POUND => "lb",
        _ => "unknown"
    };

    protected override MassUnits GetDefaultUnit() => MassUnits.KILOGRAM;

    // Basic arithmetic
    public static Mass operator +(Mass a, Mass b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));
        return new Mass(a.Value + b.Value);
    }

    public static Mass operator -(Mass a, Mass b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));
        return new Mass(a.Value - b.Value);
    }

    public static Mass operator *(Mass a, double scalar)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        return new Mass(a.Value * scalar);
    }

    public static Mass operator *(double scalar, Mass a) => a * scalar;

    public static Mass operator /(Mass a, double scalar)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (scalar == 0) throw new DivideByZeroException("Деление массы на ноль");
        return new Mass(a.Value / scalar);
    }

    // Create force from mass and acceleration (acceleration in m/s^2)
    public Force ToForce(double acceleration)
    {
        return new Force(this.Value * acceleration);
    }
}

enum MassUnits
{
    KILOGRAM,
    GRAM,
    POUND
}
