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
        kingdom.RecalculateResourceValues();
        
        await Clients.All.SendAsync("NewGameData", gameDataService.GameData);
    }

    public async Task ResetGame()
    {
        gameDataService.GameData = new GameData();
        gameDataService.GameData.LastUpdated = DateTime.Now;
        await Clients.All.SendAsync("NewGameData", gameDataService.GameData);
    }

    public async Task Sync()
    {
        gameDataService.GameData.LastUpdated = DateTime.Now;
        await Clients.All.SendAsync("NewGameData", gameDataService.GameData);
    }
}
