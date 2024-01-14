using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WelcomeScreen : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}
