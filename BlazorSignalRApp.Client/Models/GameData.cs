namespace BlazorSignalRApp.Client.Models;

public class GameData
{
    public List<Kingdom> Kingdoms { get; set; } =
    [
        new Kingdom("Synové světla"),
        new Kingdom("Strážci hornin"),
        new Kingdom("Strážci ohně"),
        new Kingdom("Strážci lesů a půdy"),
        new Kingdom("Drak")
    ];
}