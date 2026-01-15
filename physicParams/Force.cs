namespace sandbox_csharp.physicParams;

/// <summary>
/// Класс для физических величин <b>Сила</b>
/// </summary>
class Force(double value, ForceUnits unit = ForceUnits.NEWTON)
    : PhysicalValue<ForceUnits>(value, unit, _ratios)
{
    private static readonly Dictionary<ForceUnits, double> _ratios = new()
    {
        // base unit: newton
        [ForceUnits.NEWTON] = 1.0,
        [ForceUnits.KILONEWTON] = 1000.0,
        [ForceUnits.POUND_FORCE] = 4.4482216152605
    };

    protected override string GetUnitName(ForceUnits unit) => unit switch
    {
        ForceUnits.NEWTON => "N",
        ForceUnits.KILONEWTON => "kN",
        ForceUnits.POUND_FORCE => "lbf",
        _ => "unknown"
    };

    protected override ForceUnits GetDefaultUnit() => ForceUnits.NEWTON;

    // Basic arithmetic
    public static Force operator +(Force a, Force b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));
        return new Force(a.Value + b.Value);
    }

    public static Force operator -(Force a, Force b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));
        return new Force(a.Value - b.Value);
    }

    public static Force operator *(Force a, double scalar)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        return new Force(a.Value * scalar);
    }

    public static Force operator *(double scalar, Force a) => a * scalar;

    public static Force operator /(Force a, double scalar)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (scalar == 0) throw new DivideByZeroException("Деление силы на ноль");
        return new Force(a.Value / scalar);
    }

    // Force divided by mass gives acceleration (m/s^2)
    public static double operator /(Force f, Mass m)
    {
        if (f is null) throw new ArgumentNullException(nameof(f));
        if (m is null) throw new ArgumentNullException(nameof(m));
        if (m.Value == 0) throw new DivideByZeroException("Деление на ноль при делении силы на массу");
        return f.Value / m.Value;
    }
}

enum ForceUnits
{
    NEWTON,
    KILONEWTON,
    POUND_FORCE
}
