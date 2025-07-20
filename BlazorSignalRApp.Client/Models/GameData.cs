namespace BlazorSignalRApp.Client.Models;

public class GameData
{
    public int ExRateLowAmount { get; set; } = 1;
    public int ExRateLow { get; set; } = 10;
    public int ExRateMedAmount { get; set; } = 2;
    public int ExRateMed { get; set; } = 20;
    public int ExRateHighAmount { get; set; } = 3;
    
    public int HomeResourceAmountFreeMoreThan { get; set; } = 30;
    public int HomeResourceAmountFree { get; set; } = 1;

    public DateTime LastUpdated { get; set; } = DateTime.MinValue;

    public List<Kingdom> Kingdoms { get; set; } =
    [
        new Kingdom("Synové světla")
        {
            Resources =
            [
                new Resource { Name = "Oheň", Amount = 100, HomeResource = true },
                new Resource { Name = "Zlato", Amount = 0 },
                new Resource { Name = "Obilí", Amount = 0 },
                new Resource { Name = "Mléko", Amount = 0 },
                new Resource { Name = "Krystaly", Amount = 0 },
            ]
        },
        new Kingdom("Strážci hornin")
        {
            Resources =
            [
                new Resource { Name = "Oheň", Amount = 0 },
                new Resource { Name = "Zlato", Amount = 100, HomeResource = true },
                new Resource { Name = "Obilí", Amount = 0 },
                new Resource { Name = "Mléko", Amount = 0 },
                new Resource { Name = "Krystaly", Amount = 0 },
            ]
        },
        new Kingdom("Strážci řemesel")
        {
            Resources =
            [
                new Resource { Name = "Oheň", Amount = 0 },
                new Resource { Name = "Zlato", Amount = 0 },
                new Resource { Name = "Obilí", Amount = 100, HomeResource = true },
                new Resource { Name = "Mléko", Amount = 0 },
                new Resource { Name = "Krystaly", Amount = 0 },
            ]
        },
        new Kingdom("Strážci řeči")
        {
            Resources =
            [
                new Resource { Name = "Oheň", Amount = 0 },
                new Resource { Name = "Zlato", Amount = 0 },
                new Resource { Name = "Obilí", Amount = 0 },
                new Resource { Name = "Mléko", Amount = 100, HomeResource = true },
                new Resource { Name = "Krystaly", Amount = 0 },
            ]
        },
        new Kingdom("Strážci lesů a půdy")
        {
            Resources =
            [
                new Resource { Name = "Oheň", Amount = 0 },
                new Resource { Name = "Zlato", Amount = 0 },
                new Resource { Name = "Obilí", Amount = 0 },
                new Resource { Name = "Mléko", Amount = 0 },
                new Resource { Name = "Krystaly", Amount = 100, HomeResource = true },
            ]
        },
    ];

    // ----


    public int GetExchangeRate(int offeredResourceAmount, int targetResourceAmount)
    {
        if (targetResourceAmount == 0)
            return 0;

        var diff = targetResourceAmount - offeredResourceAmount;

        int ret;
        if (diff > ExRateMed)
            ret = ExRateHighAmount;
        else if (diff > ExRateLow)
            ret = ExRateMedAmount;
        else if (diff < -ExRateMed)
            ret = -ExRateHighAmount;
        else if (diff < -ExRateLow)
            ret = -ExRateMedAmount;
        else
            ret = ExRateLowAmount;

        return ret;
    }
}