using BlazorSignalRApp.Client;
using BlazorSignalRApp.Client.Models;
using BlazorSignalRApp.Services;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs;

internal class GameDataHub(GameDataService gameDataService) : Hub
{
    public async Task UpdateGameData(GameData  gameData)
    {
        gameDataService.GameData = gameData;
        foreach (var kingdom in gameData.Kingdoms)
        {
            kingdom.RecalculateResourceValues();
        }
        await Clients.All.SendAsync("NewGameData", gameData);
    }

    public async Task Sync()
    {
        await Clients.All.SendAsync("NewGameData", gameDataService.GameData);
    }
}
