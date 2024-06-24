using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelDoor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                //load next scene
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                //last scene and finish game
                UiManager.instance.wonPanel.SetActive(true);
            }
        }

    }
}

