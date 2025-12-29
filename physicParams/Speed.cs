namespace sandbox_csharp.physicParams;

/// <summary>
/// Класс для физических величин <b>Скорость</b>
/// </summary>
class Speed(double value, SpeedUnits unit = SpeedUnits.METER_PER_SECOND)
    : PhysicalValue<SpeedUnits>(value, unit, _ratios)
{
    private static readonly Dictionary<SpeedUnits, double> _ratios = new()
    {
        [SpeedUnits.METER_PER_SECOND] = 1.0,
        [SpeedUnits.KILOMETER_PER_HOUR] = 1.0 / 3.6,
        [SpeedUnits.MILE_PER_HOUR] = 0.44704,
        [SpeedUnits.KNOT] = 0.514444
    };

    protected override string GetUnitName(SpeedUnits unit) => unit switch
    {
        SpeedUnits.METER_PER_SECOND => "m/s",
        SpeedUnits.KILOMETER_PER_HOUR => "km/h",
        SpeedUnits.MILE_PER_HOUR => "mph",
        SpeedUnits.KNOT => "knots",
        _ => "unknown"
    };

    protected override SpeedUnits GetDefaultUnit() => SpeedUnits.METER_PER_SECOND;

    public static Length operator *(Speed a, Time b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);
        return new Length(a.Value * b.Value);
    }
}

enum SpeedUnits
{
    METER_PER_SECOND,
    KILOMETER_PER_HOUR,
    MILE_PER_HOUR,
    KNOT
}