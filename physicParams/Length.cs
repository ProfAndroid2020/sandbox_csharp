namespace sandbox_csharp.physicParams;

/// <summary>
/// Класс для физических величин <b>Длина</b>
/// </summary>
class Length(double value, LengthUnits unit = LengthUnits.METER)
    : PhysicalValue<LengthUnits>(value, unit, new Dictionary<LengthUnits, double>
    {
        [LengthUnits.METER] = 1.0,
        [LengthUnits.FOOT] = 0.3048,
        [LengthUnits.NAUTIC_MILE] = 1852.0,
        [LengthUnits.KILOMETER] = 1000.0
    })
{
    protected override string GetUnitName(LengthUnits unit) => unit switch
    {
        LengthUnits.METER => "m",
        LengthUnits.FOOT => "ft",
        LengthUnits.NAUTIC_MILE => "nmi",
        LengthUnits.KILOMETER => "km",
        _ => "unknown"
    };

    protected override LengthUnits GetDefaultUnit() => LengthUnits.METER;

    public static Time operator /(Length a, Speed b)
    {
        if (b.Value == 0)
        {
            throw new Exception("Деление на ноль");
        }
        return new Time(a.Value / b.Value);
    }

    public static Speed operator /(Length a, Time b)
    {
        return new Speed(a.Value / b.Value);
    }
}

enum LengthUnits
{
    METER,
    FOOT,
    NAUTIC_MILE,
    KILOMETER
}



