namespace sandbox_csharp.physicParams;
/// <summary>
/// Базовый класс для физических величин
/// </summary>
abstract class PhysicalValue<TUnits>(double value, TUnits unit, Dictionary<TUnits, double> ratios)
    where TUnits : Enum
{
    public double Value { get; private set; } = ConvertToBase(value, unit, ratios);

    protected Dictionary<TUnits, double> Ratios { get; } = ratios;

    private static double ConvertToBase(double value, TUnits fromUnit, Dictionary<TUnits, double> ratios)
    {
        ArgumentNullException.ThrowIfNull(ratios);
        if (!ratios.ContainsKey(fromUnit))
        {
            throw new ArgumentException($"Unknown unit: {fromUnit}", nameof(fromUnit));
        }
        return value * ratios[fromUnit];
    }

    public double GetInUnits(TUnits unit)
    {
        if (Ratios is null)
        {
            throw new InvalidOperationException("Ratios dictionary is not initialized");
        }
        if (!Ratios.ContainsKey(unit))
        {
            throw new ArgumentException($"Unknown unit: {unit}", nameof(unit));
        }
        return this.Value / Ratios[unit];
    }

    public string ToString(TUnits unit)
    {
        return $"{GetInUnits(unit):F2} {GetUnitName(unit)}";
    }

    public override string ToString()
    {
        return ToString(GetDefaultUnit());
    }

    protected abstract string GetUnitName(TUnits unit);
    protected abstract TUnits GetDefaultUnit();
}