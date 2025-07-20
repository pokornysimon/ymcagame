using BlazorSignalRApp.Client;
using BlazorSignalRApp.Client.Models;
using BlazorSignalRApp.Services;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs;

internal class GameDataHub(GameDataService gameDataService) : Hub
{
    public async Task UpdateGameData(GameDataUpdateContract  updateContract)
    {
        gameDataService.GameData.LastUpdated = DateTime.Now;
        var kingdom = gameDataService.GameData.Kingdoms.First(k => k.KingdomName == updateContract.KingdomName);
        kingdom.UpdateResource(updateContract.ResourceName, updateContract.Amount);
        
        await Clients.All.SendAsync("NewGameData", gameDataService.GameData);
    }

    public async Task ResetGame()
    {
        gameDataService.GameData = new GameData();
        gameDataService.GameData.LastUpdated = DateTime.Now;
        await Clients.All.SendAsync("NewGameData", gameDataService.GameData);
    }

    public async Task UpdateResourceParameters(UpdateResourceParameter parameter, int amount)
    {
        switch (parameter)
        {
            case UpdateResourceParameter.UPDATE_C1:
                gameDataService.GameData.ExRateLowAmount += amount;
                break;
            case UpdateResourceParameter.UPDATE_C2:
                gameDataService.GameData.ExRateMedAmount += amount;
                break;
            case UpdateResourceParameter.UPDATE_C3:
                gameDataService.GameData.ExRateHighAmount += amount;
                break;
            case UpdateResourceParameter.UPDATE_R1:
                gameDataService.GameData.ExRateLow += amount;
                break;
            case UpdateResourceParameter.UPDATE_R2:
                gameDataService.GameData.ExRateMed += amount;
                break;
            case UpdateResourceParameter.UPDATE_F1:
                gameDataService.GameData.HomeResourceAmountFreeMoreThan += amount;
                break;
            case UpdateResourceParameter.UPDATE_F2:
                gameDataService.GameData.HomeResourceAmountFree += amount;
                break;
            default:
                break;
        }
        
        gameDataService.GameData.LastUpdated = DateTime.Now;
        await Clients.All.SendAsync("NewGameData", gameDataService.GameData);
    }
    
    public async Task Sync()
    {
        gameDataService.GameData.LastUpdated = DateTime.Now;
        await Clients.All.SendAsync("NewGameData", gameDataService.GameData);
    }
}
