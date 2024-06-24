
using System.Collections.Generic;

[System.Serializable]
public class PlayersData
{
    public List<player> myPlayers;

    public PlayersData()
    {
        myPlayers = new List<player>();
    }
}
[System.Serializable]
public class player
{
    public string playerName;
    public string playerPassword;
    public int playerScore;
}
