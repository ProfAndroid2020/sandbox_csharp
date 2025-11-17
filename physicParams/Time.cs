namespace sandbox_csharp.physicParams;

/// <summary>
/// Класс для физических величин <b>Время</b>
/// </summary>
class Time(double value, TimeUnits unit = TimeUnits.SECOND)
    : PhysicalValue<TimeUnits>(value, unit, new Dictionary<TimeUnits, double>
    {
        [TimeUnits.SECOND] = 1.0,
        [TimeUnits.MINUTE] = 60.0,
        [TimeUnits.HOUR] = 3600.0,
        [TimeUnits.DAY] = 86400.0
    })
{
    protected override string GetUnitName(TimeUnits unit) => unit switch
    {
        TimeUnits.SECOND => "s",
        TimeUnits.MINUTE => "min",
        TimeUnits.HOUR => "h",
        TimeUnits.DAY => "days",
        _ => "unknown"
    };

    protected override TimeUnits GetDefaultUnit() => TimeUnits.SECOND;

    public static Length operator *(Time a, Speed b)
    {
        return new Length(a.Value * b.Value);
    }
}

enum TimeUnits
{
    SECOND,
    MINUTE,
    HOUR,
    DAY
}