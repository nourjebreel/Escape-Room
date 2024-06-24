using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelScore;
    public string currentLevelEncryptionKeyl;

    public GameObject levelDoor;

    PlayersData levelPlayers;
    bool levelScoreToken;
    public void FinishLevel()
    {
        levelDoor.transform.rotation = Quaternion.Euler(0, -130, 0);

        levelPlayers = SaveManager.LoadData();
        foreach (player player in levelPlayers.myPlayers)
        {
            if (player.playerName == SaveManager.currentPlayer.playerName&&!levelScoreToken)
            {
                player.playerScore += levelScore;
                UiManager.instance.SetTextValue(UiManager.instance.scoreTxt, player.playerScore.ToString());
                levelScoreToken = true;
            }
        }
        SaveManager.SaveData(levelPlayers);
    }

   
}

