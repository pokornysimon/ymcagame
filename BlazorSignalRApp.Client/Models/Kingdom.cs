namespace BlazorSignalRApp.Client.Models;

public class Kingdom(string kingdomName)
{
    public string KingdomName { get; } = kingdomName;

    public List<Resource> Resources { get; set; }

    public void UpdateResource(string resourceName, int amount)
    {
        var r = this.Resources.First(res => res.Name == resourceName);
        r.Amount += amount;
    }

    public Resource GetHomeResource()
    {
        return this.Resources.First(res => res.HomeResource);
    }
}