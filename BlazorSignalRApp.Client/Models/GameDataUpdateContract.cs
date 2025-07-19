namespace BlazorSignalRApp.Client.Models;

public class GameDataUpdateContract
{
    public string KingdomName { get; set; }
    public string ResourceName { get; set; }
    public int Amount { get; set; }
}