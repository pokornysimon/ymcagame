namespace BlazorSignalRApp.Client.Models;

public class Resource
{
    public static int ExRateLowAmount = 1;
    public static int ExRateLow = 10;
    public static int ExRateMedAmount = 2;
    public static int ExRateMed = 20;
    public static int ExRateHighAmount = 3;
    
    public static int HomeResourceAmountFreeMoreThan = 30;
    // ----
    
    public string Name { get; set; }
    public int Amount { get; set; }
    public bool HomeResource { get; set; }
    
    // ----

    public int GetExchangeRate(Resource targetResource)
    {
        return GetExchangeRate(this.Amount, targetResource.Amount);
    }
    
    public static int GetExchangeRate(int offeredResourceAmount, int targetResourceAmount)
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