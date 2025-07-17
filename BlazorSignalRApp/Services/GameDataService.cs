using BlazorSignalRApp.Client.Models;

namespace BlazorSignalRApp.Services;

internal class GameDataService
{
    public GameData GameData { get; set; } = new GameData();
}