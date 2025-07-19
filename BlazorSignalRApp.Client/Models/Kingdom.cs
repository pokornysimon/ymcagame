namespace BlazorSignalRApp.Client.Models;

public class Kingdom(string kingdomName)
{
    private int _totalAmount = 100;
    public string KingdomName { get; } = kingdomName;

    public List<Resource> Resources { get; set; } =
    [
        new Resource { Name = "Oheň", Amount = 0 },
        new Resource { Name = "Zlato", Amount = 0 },
        new Resource { Name = "Obilí", Amount = 0 },
        new Resource { Name = "Mléko", Amount = 0 },
        // new Resource { Name = "Šupiny", Amount = 0 },
    ];

    public void UpdateResource(string resourceName, int amount)
    {
        var r = this.Resources.First(res => res.Name == resourceName);
        r.Amount += amount;
    }

    public void RecalculateResourceValues()
    {
        foreach (var resource in Resources)
        {
            resource.Value = _totalAmount / (resource.Amount + 1); // čím méně máš, tím větší hodnota
        }
    }

    public int GetExchangeAmount(string offeredResourceName, string targetResourceName)
    {
        RecalculateResourceValues();

        var offered = Resources.FirstOrDefault(r => r.Name == offeredResourceName);
        var target = Resources.FirstOrDefault(r => r.Name == targetResourceName);

        if (offered == null || target == null)
            throw new ArgumentException("Jedna ze zadaných surovin neexistuje.");

        if (target.Amount == 0) // Cílová surovina není dostupná
            return 0;

        if (offered.Amount == 0) // Nabízená surovina není dostupná
            return 0;

        // Výpočet poměru hodnot
        double ratio = (double)offered.Value / target.Value;

        // Omezit na rozsah 1–4 (škálování)
        // Ratio 1 → 1 kus, Ratio >= maxRatio → 4 kusy
        double maxRatio = 5.0;
        double scaled = 1 + (ratio - 1) * (3 / (maxRatio - 1)); // škáluj na rozsah 1–4
        int result = (int)Math.Round(Math.Clamp(scaled, 1, 4));

        return result;
    }
}