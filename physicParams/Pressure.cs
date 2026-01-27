namespace sandbox_csharp.physicParams
{
    internal class Pressure(double value, PressureUnits unit = PressureUnits.PA)
        : PhysicalValue<PressureUnits>(value, unit, _ratios)
    {
        private static readonly Dictionary<PressureUnits, double> _ratios = new()
        {
            [PressureUnits.PA] = 1.0,
            [PressureUnits.ATM] = 101325.0,
            [PressureUnits.H_PA] = 100.0,
            [PressureUnits.MM_HG] = 133.322
        };

        protected override string GetUnitName(PressureUnits unit) => unit switch
        {
            PressureUnits.PA => "Pa",
            PressureUnits.ATM => "Atm",
            PressureUnits.H_PA => "HPa",
            PressureUnits.MM_HG => "mm HG",
            _ => "unknown"
        };

        protected override PressureUnits GetDefaultUnit() => PressureUnits.PA;
    }

    enum PressureUnits
    {
        PA,
        ATM,
        H_PA,
        MM_HG,
    }
}
