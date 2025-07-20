namespace BlazorSignalRApp.Client.Models;

public class Kingdom(string kingdomName)
{
    public static int ExRateLowAmount = 1;
    public static int ExRateLow = 10;
    public static int ExRateMedAmount = 2;
    public static int ExRateMed = 20;
    public static int ExRateHighAmount = 3;

    public static int HomeResourceAmountFreeMoreThan = 30;
    
    public string KingdomName { get; } = kingdomName;

    public List<Resource> Resources { get; set; }

    public void UpdateResource(string resourceName, int amount)
    {
        var r = this.Resources.First(res => res.Name == resourceName);
        r.Amount += amount;
    }

    public int GetExchangeAmount(string offeredResourceName, string targetResourceName)
    {
        var offered = Resources.FirstOrDefault(r => r.Name == offeredResourceName);
        var target = Resources.FirstOrDefault(r => r.Name == targetResourceName);

        var diff = target!.Amount - offered!.Amount;

        int ret;
        if (diff > Kingdom.ExRateMed)
            ret = Kingdom.ExRateHighAmount;
        else if (diff > Kingdom.ExRateLow)
            ret = Kingdom.ExRateMedAmount;
        else if (diff < -Kingdom.ExRateMed)
            ret = -Kingdom.ExRateHighAmount;
        else if (diff < -Kingdom.ExRateLow)
            ret = -Kingdom.ExRateMedAmount;
        else
            ret = Kingdom.ExRateLowAmount;

        return ret;
    }
}