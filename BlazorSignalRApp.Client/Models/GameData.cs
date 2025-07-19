namespace BlazorSignalRApp.Client.Models;

public class GameData
{
    public DateTime LastUpdated { get; set; } = DateTime.MinValue;

    public List<Kingdom> Kingdoms { get; set; } =
    [
        new Kingdom("Synové světla")
        {
            Resources =
            [
                new Resource { Name = "Oheň", Amount = 100, HomeResource = true},
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
}